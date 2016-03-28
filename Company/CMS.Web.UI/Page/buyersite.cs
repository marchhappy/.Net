using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Web;
using CMS.Common;
using CMS.Model;
using CMS.BLL;

namespace CMS.Web.UI.Page
{
    /// <summary>
    /// 我的站点
    /// </summary>
    public partial class buyersite : Web.UI.UserPage
    {
        protected string action = string.Empty;
        protected int page;         //当前页码
        protected int totalcount;   //OUT数据总数

        /// <summary>
        /// 重写虚方法,此方法在Init事件执行
        /// </summary>
        protected override void InitPage()
        {
            action = DTRequest.GetQueryString("action");
            page = DTRequest.GetQueryInt("page", 1);
        }

        /// <summary>
        /// 站点分页列表
        /// </summary>
        /// <param name="page_size">页面大小</param>
        /// <param name="page_index">当前页码</param>
        /// <param name="strwhere">查询条件</param>
        /// <param name="totalcount">总记录数</param>
        /// <returns>DateTable</returns>
        protected DataTable GetList(int page_size, int page_index, string strwhere, out int totalcount)
        {
            return new BLL.buyersite_config().GetList(page_size, page_index, strwhere, "add_time desc,id desc", out totalcount).Tables[0];
        }

        /// <summary>
        /// 我的站点总数量
        /// </summary>
        /// <returns></returns>
        protected int GetCountSubDomain()
        {
            return new BLL.buyersite().GetCountSubDomain(" [user_id]=" + userModel.id.ToString());
        }

    }
}
