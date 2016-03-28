using System;
using System.Text;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.Common;

namespace CMS.Web.admin.buyersite
{
    public partial class userlist : Web.UI.ManagePage
    {
        protected int totalCount;
        protected int page;
        protected int pageSize;

        protected string keywords = string.Empty;

        BLL.users bllUser = null;
        BLL.article bllhp = null;
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //获得站点配置信息

        protected void Page_Load(object sender, EventArgs e)
        {
            bllUser = new BLL.users();
            bllhp = new BLL.article();

            this.keywords = DTRequest.GetQueryString("keywords");

            this.pageSize = GetPageSize(10); //每页数量
            if (!Page.IsPostBack)
            {
                ChkAdminLevel("buyersiteusers", DTEnums.ActionEnum.View.ToString()); //检查权限
                Model.manager model = GetAdminInfo(); //取得当前管理员信息
                RptBind(CombSqlTxt(keywords), "add_time asc,id desc");
            }
        }

        #region 数据绑定=================================
        private void RptBind(string _strWhere, string _orderby)
        {
            this.page = DTRequest.GetQueryInt("page", 1);
            txtKeywords.Text = this.keywords;
            BLL.buyersite bll = new BLL.buyersite();
            this.rptList.DataSource = bll.GetList(this.pageSize, this.page, _strWhere, _orderby, out this.totalCount);
            this.rptList.DataBind();

            //绑定页码
            txtPageNum.Text = this.pageSize.ToString();
            string pageUrl = Utils.CombUrlTxt("userlist.aspx", "keywords={0}&page={1}", this.keywords, "__id__");
            PageContent.InnerHtml = Utils.OutPageList(this.pageSize, this.page, this.totalCount, pageUrl, 8);
        }
        #endregion

        #region 组合SQL查询语句==========================
        protected string CombSqlTxt(string _keywords)
        {
            StringBuilder strTemp = new StringBuilder();
            _keywords = _keywords.Replace("'", "").Trim();
            if (!string.IsNullOrEmpty(_keywords))
            {
                strTemp.Append(" ([order_no]='" + _keywords + "') or ([user_id] IN (select s.id from " + siteConfig.sysdatabaseprefix + "users s where s.[user_name] like '%" + _keywords + "%'))");
            }

            return strTemp.ToString();
        }
        #endregion

        #region 返回每页数量=============================
        private int GetPageSize(int _default_size)
        {
            int _pagesize;
            if (int.TryParse(Utils.GetCookie("userlist_page_size", "CMSPage"), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    return _pagesize;
                }
            }
            return _default_size;
        }
        #endregion

        //关健字查询
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect(Utils.CombUrlTxt("userlist.aspx", "keywords={0}", txtKeywords.Text));
        }

        //设置分页数量
        protected void txtPageNum_TextChanged(object sender, EventArgs e)
        {
            int _pagesize;
            if (int.TryParse(txtPageNum.Text.Trim(), out _pagesize))
            {
                if (_pagesize > 0)
                {
                    Utils.WriteCookie("userlist_page_size", "CMSPage", _pagesize.ToString(), 14400);
                }
            }
            Response.Redirect(Utils.CombUrlTxt("userlist.aspx", "keywords={0}", this.keywords));
        }



        /// <summary>
        /// 获取用户名
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        protected string GetUserName(int userid)
        {
            var u = bllUser.GetModel(userid);
            return u == null ? userid.ToString() : u.user_name;
        }


        Dictionary<string, string> HomePlanMap = new Dictionary<string, string>();

        /// <summary>
        /// 获取套餐名称
        /// </summary>
        /// <param name="call_index"></param>
        /// <returns></returns>
        protected string GetHomePlanName(string call_index)
        {
            if (string.IsNullOrWhiteSpace(call_index)) return "-";

            if (HomePlanMap.ContainsKey(call_index)) return HomePlanMap[call_index];

            string name = "-";
            if (bllhp.Exists(call_index))
            {
                var art = bllhp.GetModel(call_index);
                name = art == null ? "-" : art.title;
            }
            HomePlanMap.Add(call_index, name);
            return name;
        }


    }
}