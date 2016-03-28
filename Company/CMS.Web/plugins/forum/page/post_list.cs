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
using CMS.Web.UI;

namespace CMS.Web.Plugin.Forum
{
    public partial class post_list : Web.UI.BasePage
    {
        protected int page; //当前页码
        protected int board_id;  //类别ID
        protected int totalcount; //OUT数据总数
        protected string pagelist;  //分页页码

        protected Model.forum_board model = new Model.forum_board(); //分类的实体
        /// <summary>
        /// 重写虚方法,此方法将在Init事件前执行
        /// </summary>
        protected override void ShowPage()
        {
            page = DTRequest.GetQueryInt("page", 1);
            board_id = DTRequest.GetQueryInt("board_id");
            BLL.forum_board bll = new BLL.forum_board();
            model.boardname = "全部帖子";
            if (board_id > 0) //如果ID获取到，将使用ID
            {
                if (bll.Exists(board_id))
                    model = bll.GetModel(board_id);
            }
        }



        public string get_user_name(int userid)
        {
            CMS.Model.users model = new CMS.BLL.users().GetModel(userid);
            if (model == null)
            {
                return "-";
            }
            return model.user_name;
        }


        /// <summary>
        /// 帖子分页列表
        /// </summary>
        /// <param name="page_size">页面大小</param>
        /// <param name="page_index">当前页码</param>
        /// <param name="strwhere">查询条件</param>
        /// <param name="totalcount">总记录数</param>
        /// <returns>DateTable</returns>
        public DataTable get_post_list(int board_id,int page_size, int page_index, string strwhere, out int totalcount)
        {
            DataTable dt = new DataTable();
            string _where = "id>0";
            if (!string.IsNullOrEmpty(strwhere))
            {
                _where += " and " + strwhere;
            }
            dt = new BLL.forum_posts().GetList(board_id,page_size, page_index, _where, "is_top desc,reply_time desc,add_time desc", out totalcount).Tables[0];
            return dt;
        }

    }
}
