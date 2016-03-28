using System;
using System.Data;
using System.Collections.Generic;
using System.IO;
using CMS.Common;

namespace CMS.BLL
{
    /// <summary>
    /// 上传文件存储
    /// </summary>
    public partial class files
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //获得站点配置信息
        private readonly DAL.files dal;
        public files()
        {
            dal = new DAL.files(siteConfig.sysdatabaseprefix);
        }

        #region 基本方法============================
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string fileHashValue)
        {
            return dal.Exists(fileHashValue);
        }

        /// <summary>
        /// 增加一条数据(判断HASH值是否存在)
        /// </summary>
        public Int64 Add(Model.files model)
        {
            Int64 modelID = GetModeID(model.file_md5);
            return modelID > 0 ? modelID : dal.Add(model);
        }

        /// <summary>
        /// 增加一条数据(根据文件地址)
        /// </summary>
        /// <param name="fileUrl"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public Model.files Add(string fileUrl, int userID = 0, bool neednew = false)
        {
            string filePath = Utils.GetMapPath(fileUrl);
            Model.files model = new Model.files();
            model.file_name = Path.GetFileName(filePath);
            model.file_fullpath = Path.GetDirectoryName(filePath);
            model.file_path = fileUrl;
            string fileExtension = Path.GetExtension(filePath);
            model.file_endwith = fileExtension;
            if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".jpeg" || fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".gif")
            {
                model.file_type = 0;
            }
            else if (fileExtension.ToLower() == ".rar" || fileExtension.ToLower() == ".zip" || fileExtension.ToLower() == ".7z")
            {
                model.file_type = 1;
            }
            else if (fileExtension.ToLower() == ".xls" || fileExtension.ToLower() == ".xlsx" || fileExtension.ToLower() == ".doc" || fileExtension.ToLower() == ".docx")
            {
                model.file_type = 2;
            }
            else
            {
                model.file_type = 3;
            }
            model.file_md5 = Utils.GetMD5HashFromFile(filePath);
            model.file_server = Utils.GetAppSettings("LocalHost");
            model.file_state = 0;
            model.file_uptime = DateTime.Now;
            model.file_upuser = userID;
            model.file_usetimes = 0;
            Int64 modelID = GetModeID(model.file_md5);
            if (modelID > 0)
            {
                Model.files modelold = GetModel(modelID);
                if (!neednew)
                {
                    //检查原文件是否存在，存在则删除新文件，不存在则记录
                    if (File.Exists(Utils.GetMapPath(modelold.file_path)))
                    {
                        if (Utils.GetMD5HashFromFile(Utils.GetMapPath(modelold.file_path)).ToLower() == modelold.file_md5)
                        {
                            File.Delete(Utils.GetMapPath(model.file_path));
                            return modelold;
                        }
                        else
                        {
                            Delete(modelold.id);
                        }
                    }
                    else
                    {
                        Delete(modelold.id);
                    }
                }
                else
                {
                    //检查原文件是否存在，存在则删除，仅保留新文件
                    if (File.Exists(Utils.GetMapPath(modelold.file_path)))
                    {
                        File.Delete(Utils.GetMapPath(modelold.file_path));
                    }
                    Delete(modelold.id);
                }
            }
            model.id = Add(model);
            return model;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.files model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Int64 id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// 根据文件HASH值删除一条数据
        /// </summary>
        /// <param name="fileHashValue"></param>
        /// <returns></returns>
        public bool Delete(string fileHashValue)
        {
            Int64 modelID = GetModeID(fileHashValue);
            return modelID == 0 ? false : Delete(modelID);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.files GetModel(Int64 id)
        {
            return dal.GetModel(id);
        }

        /// <summary>
        /// 根据文件HASH值获得一个对象实体
        /// </summary>
        /// <param name="fileHashValue"></param>
        /// <returns></returns>
        public Model.files GetModel(string fileHashValue)
        {
            Int64 modelID = GetModeID(fileHashValue);
            return modelID == 0 ? null : GetModel(modelID);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        #endregion

        #region 扩展方法============================
        /// <summary>
        /// 根据HASH值返回ID
        /// </summary>
        public Int64 GetModeID(string fileHashValue)
        {
            return dal.GetModeID(fileHashValue);
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(Int64 id, string strValue)
        {
            dal.UpdateField(id, strValue);
        }

        /// <summary>
        /// 根据文件HASH值修改一列数据
        /// </summary>
        /// <param name="fileHashValue"></param>
        /// <param name="strValue"></param>
        public void UpdateField(string fileHashValue, string strValue)
        {
            Int64 modelID = GetModeID(fileHashValue);
            if (modelID > 0)
            {
                UpdateField(modelID, strValue);
            }
        }
        #endregion
    }
}