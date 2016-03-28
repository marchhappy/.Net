using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Configuration;
using CMS.Common;

namespace CMS.Web.UI
{
    public partial class BasePage : System.Web.UI.Page
    {
        protected internal Model.siteconfig config = new BLL.siteconfig().loadConfig();
        protected internal Model.userconfig uconfig = new BLL.userconfig().loadConfig();
        protected internal Model.channel_site site = new Model.channel_site();
        /// <summary>
        /// 父类的构造函数
        /// </summary>
        public BasePage()
        {
            //是否关闭网站
            if (config.webstatus == 0)
            {
                HttpContext.Current.Response.Redirect(linkurl("error", "?msg=" + Utils.UrlEncode(config.webclosereason)));
                return;
            }
            //取得站点信息
            site = GetSiteModel();
            //抛出一个虚方法给继承重写
            ShowPage();
        }

        #region 增加处理函数

        /// <summary>
        /// 判断条件返回字符串
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="trueString"></param>
        /// <param name="falseString"></param>
        /// <returns></returns>
        protected string TrueFalseEval(bool expression, string trueString, string falseString)
        {
            return expression ? trueString : falseString;
        }

        /// <summary>
        /// 清除金额的末尾0数据
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        protected string ClearMoney(object money)
        {
            return money.ToString().TrimEnd('0').TrimEnd('.');
        }

        /// <summary>
        /// 通过别名获取文章
        /// </summary>
        /// <param name="call_index"></param>
        /// <returns></returns>
        protected Model.article GetArticleByCI(string call_index)
        {
            if (string.IsNullOrEmpty(call_index)) return null;

            BLL.article bll = new BLL.article();
            if (bll.Exists(call_index))
            {
                return bll.GetModel(call_index);
            }
            return null;
        }

        #endregion


        /// <summary>
        /// 页面处理虚方法
        /// </summary>
        protected virtual void ShowPage()
        {
            //虚方法代码
        }

        #region 页面通用方法==========================================
        /// <summary>
        /// 返回站点信息
        /// </summary>
        protected Model.channel_site GetSiteModel()
        {
            string requestDomain = HttpContext.Current.Request.Url.Authority.ToLower(); //获得来源域名含端口号
            string requestPath = HttpContext.Current.Request.RawUrl.ToLower(); //当前的URL地址
            string sitePath = GetSitePath(requestPath, requestDomain);
            Model.channel_site modelt = SiteDomains.GetSiteDomains().SiteList.Find(p => p.build_path == sitePath);
            return modelt;
        }

        /// <summary>
        /// 返回URL重写统一链接地址
        /// </summary>
        public string linkurl(string _key, params object[] _params)
        {
            Hashtable ht = new BLL.url_rewrite().GetList(); //获得URL配置列表
            Model.url_rewrite model = ht[_key] as Model.url_rewrite; //查找指定的URL配置节点

            //如果不存在该节点则返回空字符串
            if (model == null)
            {
                return string.Empty;
            }

            string requestDomain = HttpContext.Current.Request.Url.Authority.ToLower(); //获得来源域名含端口号
            string requestPath = HttpContext.Current.Request.RawUrl.ToLower(); //当前的URL地址
            string linkStartString = GetLinkStartString(requestPath, requestDomain); //链接前缀

            //如果URL字典表达式不需要重写则直接返回
            if (model.url_rewrite_items.Count == 0)
            {
                //检查网站重写状态
                if (config.staticstatus > 0)
                {
                    if (_params.Length > 0)
                    {
                        return linkStartString + GetUrlExtension(model.page, config.staticextension) + string.Format("{0}", _params);
                    }
                    else
                    {
                        return linkStartString + GetUrlExtension(model.page, config.staticextension);
                    }
                }
                else
                {
                    if (_params.Length > 0)
                    {
                        return linkStartString + model.page + string.Format("{0}", _params);
                    }
                    else
                    {
                        return linkStartString + model.page;
                    }
                }
            }
            //否则检查该URL配置节点下的子节点
            foreach (Model.url_rewrite_item item in model.url_rewrite_items)
            {
                //如果参数个数匹配
                if (IsUrlMatch(item, _params))
                {
                    //检查网站重写状态
                    if (config.staticstatus > 0)
                    {
                        return linkStartString + string.Format(GetUrlExtension(item.path, config.staticextension), _params);
                    }
                    else
                    {
                        string queryString = Regex.Replace(string.Format(item.path, _params), item.pattern, item.querystring, RegexOptions.None | RegexOptions.IgnoreCase);
                        if (queryString.Length > 0)
                        {
                            queryString = "?" + queryString;
                        }
                        return linkStartString + model.page + queryString;
                    }
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// 根据站点目录和已生成的链接重新组合(实际访问页面用到)
        /// </summary>
        /// <param name="sitepath">站点目录</param>
        /// <param name="urlpath">URL链接</param>
        /// <returns>String</returns>
        public string getlink(string sitepath, string urlpath)
        {
            if (string.IsNullOrEmpty(sitepath) || string.IsNullOrEmpty(urlpath))
            {
                return urlpath;
            }
            string requestDomain = HttpContext.Current.Request.Url.Authority.ToLower(); //获取来源域名含端口号
            Dictionary<string, string> dic = SiteDomains.GetSiteDomains().Paths; //获取站点键值对
            //如果当前站点为默认站点则直接返回
            if (SiteDomains.GetSiteDomains().DefaultPath == sitepath.ToLower())
            {
                return urlpath;
            }
            //如果当前域名存在于域名列表则直接返回
            if (dic.ContainsKey(sitepath.ToLower()) && dic.ContainsValue(requestDomain))
            {
                return urlpath;
            }
            int indexNum = config.webpath.Length; //安装目录长度
            if (urlpath.StartsWith(config.webpath))
            {
                urlpath = urlpath.Substring(indexNum);
            }
            //安装目录+站点目录+URL
            return config.webpath + sitepath.ToLower() + "/" + urlpath;
        }

        /// <summary>
        /// 返回分页字符串
        /// </summary>
        /// <param name="pagesize">页面大小</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="totalcount">记录总数</param>
        /// <param name="_key">URL映射Name名称</param>
        /// <param name="_params">传输参数</param>
        protected string get_page_link(int pagesize, int pageindex, int totalcount, string _key, params object[] _params)
        {
            return Utils.OutPageList(pagesize, pageindex, totalcount, linkurl(_key, _params), 8);
        }

        /// <summary>
        /// 返回分页字符串
        /// </summary>
        /// <param name="pagesize">页面大小</param>
        /// <param name="pageindex">当前页</param>
        /// <param name="totalcount">记录总数</param>
        /// <param name="linkurl">链接地址</param>
        protected string get_page_link(int pagesize, int pageindex, int totalcount, string linkurl)
        {
            return Utils.OutPageList(pagesize, pageindex, totalcount, linkurl, 8);
        }
        #endregion

        #region 会员用户方法==========================================
        /// <summary>
        /// 判断用户是否已经登录
        /// Update  2015/11/21  登录采用Cookies+Redis的方式进行
        /// </summary>
        public bool IsUserLogin()
        {
            //通过Cookies获得SessionID
            string sessionID = Utils.GetCookie(DTKeys.COOKIE_USER_INFO_REMEMBER);
            if (!string.IsNullOrEmpty(sessionID))
            {
                //获取Redis中对应的登录信息
                Model.users model = CacheHelperRedis.Get<Model.users>(sessionID);
                if (model != null)
                {
                    if (model.model_login != null)
                    {
                        if (model.model_login.login_ip.Trim() == DTRequest.GetIP().Trim())
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    //删除对应的COOKIES
                    Utils.WriteCookie(DTKeys.COOKIE_USER_INFO_REMEMBER, "", 1);
                }
            }
            else
            {
                //删除对应的COOKIES
                Utils.WriteCookie(DTKeys.COOKIE_USER_INFO_REMEMBER, "", 1);
            }
            return false;
        }

        /// <summary>
        /// 取得当前用户准确信息
        /// </summary>
        public Model.users GetUserInfo(bool needNew = true)
        {
            Model.users_login modellogin = new Model.users_login();
            //通过Cookies获得SessionID
            string sessionID = Utils.GetCookie(DTKeys.COOKIE_USER_INFO_REMEMBER);
            if (!string.IsNullOrEmpty(sessionID))
            {
                //获取Redis中对应的登录信息
                Model.users model = CacheHelperRedis.Get<Model.users>(sessionID);
                if (model != null)
                {
                    if (model.model_login != null)
                    {
                        if (model.model_login.login_ip.Trim() == DTRequest.GetIP().Trim())
                        {
                            return needNew ? new BLL.users().GetModel(model.id) : model;
                        }
                    }
                }
            }
            return null;
        }
        #endregion

        #region 辅助方法(私有)========================================
        /// <summary>
        /// 获取当前页面包含的站点目录
        /// </summary>
        private string GetFirstPath(string requestPath)
        {
            int indexNum = config.webpath.Length; //安装目录长度
            //如果包含安装目录和aspx目录也要过滤掉
            if (requestPath.StartsWith(config.webpath + DTKeys.DIRECTORY_REWRITE_ASPX + "/"))
            {
                indexNum = (config.webpath + DTKeys.DIRECTORY_REWRITE_ASPX + "/").Length;
            }
            string requestFirstPath = requestPath.Substring(indexNum);
            if (requestFirstPath.IndexOf("/") > 0)
            {
                requestFirstPath = requestFirstPath.Substring(0, requestFirstPath.IndexOf("/"));
            }
            if (requestFirstPath != string.Empty && SiteDomains.GetSiteDomains().Paths.ContainsKey(requestFirstPath))
            {
                return requestFirstPath;
            }
            return string.Empty;
        }

        /// <summary>
        /// 获取链接的前缀
        /// </summary>
        /// <param name="requestPath">当前的URL地址</param>
        /// <param name="requestDomain">获得来源域名含端口号</param>
        /// <returns>String</returns>
        private string GetLinkStartString(string requestPath, string requestDomain)
        {
            string requestFirstPath = GetFirstPath(requestPath);//获得二级目录(不含站点安装目录)

            //检查是否与绑定的域名或者与默认频道分类的目录匹配
            if (SiteDomains.GetSiteDomains().Paths.ContainsValue(requestDomain))
            {
                return "/";
            }

            else if (requestFirstPath == string.Empty || requestFirstPath == SiteDomains.GetSiteDomains().DefaultPath)
            {
                return config.webpath;
            }
            else
            {
                return config.webpath + requestFirstPath + "/";
            }
        }

        /// <summary>
        /// 获取站点的目录
        /// </summary>
        /// <param name="requestPath">获取的页面，包含目录</param>
        /// <param name="requestDomain">获取的域名(含端口号)</param>
        /// <returns>String</returns>
        private string GetSitePath(string requestPath, string requestDomain)
        {
            //当前域名是否存在于站点目录列表
            if (SiteDomains.GetSiteDomains().Paths.ContainsValue(requestDomain))
            {
                return SiteDomains.GetSiteDomains().Domains[requestDomain];
            }

            // 获取当前页面包含的站点目录
            string pagePath = GetFirstPath(requestPath);
            if (pagePath != string.Empty)
            {
                return pagePath;
            }
            return SiteDomains.GetSiteDomains().DefaultPath;
        }

        /// <summary>
        /// 参数个数是否匹配
        /// </summary>
        private bool IsUrlMatch(Model.url_rewrite_item item, params object[] _params)
        {
            int strLength = 0;
            if (!string.IsNullOrEmpty(item.querystring))
            {
                strLength = item.querystring.Split('&').Length;
            }
            if (strLength == _params.Length)
            {
                //注意__id__代表分页页码，所以须替换成数字才成进行匹配
                if (Regex.IsMatch(string.Format(item.path, _params).Replace("__id__", "1"), item.pattern, RegexOptions.None | RegexOptions.IgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 替换扩展名
        /// </summary>
        private string GetUrlExtension(string urlPage, string staticExtension)
        {
            return Utils.GetUrlExtension(urlPage, staticExtension);
        }

        #endregion
    }
}
