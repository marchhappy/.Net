using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using CMS.Common;

namespace CMS.Web.Plugin.Forum
{
    public partial class board : Web.UI.BasePage
    {
        /// <summary>
        /// 重写虚方法,此方法将在Init事件前执行
        /// </summary>
        protected override void ShowPage()
        {
        }

        /// <summary>
        /// 获取所有板块列表
        /// </summary>
        /// <param name="top">显示条数</param>
        /// <param name="strwhere">查询条件</param>
        /// <returns>DataTable</returns>
        public DataTable get_board_list()
        {
            DataTable dt = new DataTable();
            dt = new BLL.forum_board().GetAllList(0);
            return dt;
        }
        
    }
}
