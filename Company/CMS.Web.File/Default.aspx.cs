using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using CMS.Common;

namespace CMS.Web.File
{
    public partial class _Default : System.Web.UI.Page
    {
        //定义缓存表格名称
        private string fileCacheName = "file_cache";
        /// <summary>
        /// 根据MD5值下载文件并显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //获得来源参数
                string FileHashValue = HttpContext.Current.Request.Url.Query.ToString();
                if (FileHashValue.StartsWith("?"))
                {
                    FileHashValue = FileHashValue.Substring(1);
                }
                //判断来源HASH是否为空
                if (string.IsNullOrEmpty(FileHashValue))
                {
                    Response.End();
                }
                //判断来源Hash是否存在于缓存
                Model.files model = CacheHelperRedis.Get<Model.files>(fileCacheName, FileHashValue);
                BLL.files bll = new BLL.files();
                if (model == null)
                {
                    model = bll.GetModel(FileHashValue);
                    if (model != null)
                    {
                        //写入缓存
                        CacheHelperRedis.Insert(fileCacheName, FileHashValue, model);
                    }
                }
                //根据文件信息下载文件
                if (model != null)
                {
                    //增加文件访问次数
                    bll.UpdateField(model.id, "file_usetimes=file_usetimes+1");
                    //检测是否被禁用或者删除
                    if (model.file_state != -1)
                    {
                        //从原始服务器上下载文件
                        remoteSaveAs(model);
                        if (model.file_type == 0)
                        {
                            //如果是图片类型则进行缓存控制并输出
                            string suffix = Utils.GetFileExt(model.file_path);
                            Response.ContentType = string.Format("image/{0}", suffix.ToLower().Equals("png") ? "x-png" : suffix);
                            DateTime contentModified = System.IO.File.GetLastWriteTime(Utils.GetMapPath(model.file_path));
                            if (IsClientCached(contentModified))
                            {
                                Response.StatusCode = 304;
                                Response.SuppressContent = true;
                            }
                            else
                            {
                                Response.Cache.SetETagFromFileDependencies();
                                Response.Cache.SetAllowResponseInBrowserHistory(true);
                                Response.Cache.SetLastModified(contentModified);
                                FileStream fs = new FileStream(Utils.GetMapPath(model.file_path), FileMode.Open, FileAccess.Read);
                                byte[] byData = new byte[fs.Length];
                                fs.Read(byData, 0, byData.Length);
                                fs.Close();
                                System.IO.MemoryStream ms = new System.IO.MemoryStream(byData);
                                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);
                                img.Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                                Response.BinaryWrite(ms.ToArray()); //新增内容
                                img.Dispose();
                            }
                        }
                        else
                        {
                            //其它类型文件则直接提供下载
                            Response.Clear();
                            Response.Buffer = true;
                            Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(model.file_name, System.Text.Encoding.UTF8));
                            Response.WriteFile(Server.MapPath(model.file_path));
                            Response.Flush();
                            Response.Close();
                        }
                    }
                }
                Response.End();
            }
            catch
            {
                Response.End();
            }
        }

        /// <summary>
        /// 保存远程文件到本地
        /// </summary>
        private string remoteSaveAs(Model.files model)
        {
            string upLoadPath = Path.GetDirectoryName(model.file_path);
            string fullUpLoadPath = Utils.GetMapPath(upLoadPath); //上传目录的物理路径
            //检查上传的物理路径是否存在，不存在则创建
            if (!Directory.Exists(fullUpLoadPath))
            {
                Directory.CreateDirectory(fullUpLoadPath);
            }
            //检查目标文件是否存在
            if (Utils.FileExists(model.file_path))
            {
                //如果存在同名文件，检查MD5值是否一样
                string newFileHash = Utils.GetMD5HashFromFile(Utils.GetMapPath(model.file_path));
                if (newFileHash.ToLower() == model.file_md5.ToLower())
                {
                    return model.file_path;
                }
            }
            //其余情况则下载文件
            WebClient client = new WebClient();
            try
            {
                client.DownloadFile(model.file_server + model.file_path, Utils.GetMapPath(model.file_path));
            }
            catch
            {
                return string.Empty;
            }
            client.Dispose();
            return model.file_path;
        }

        /// <summary>
        /// 判断是否是缓存
        /// </summary>
        /// <param name="contentModified"></param>
        /// <returns></returns>
        private bool IsClientCached(DateTime contentModified)
        {
            string header = Request.Headers["If-Modified-Since"];
            if (header != null)
            {
                DateTime isModifiedSince;
                if (DateTime.TryParse(header, out isModifiedSince))
                {
                    return isModifiedSince >= DateTime.Parse(contentModified.ToString());
                }
            }
            return false;
        }

    }
}
