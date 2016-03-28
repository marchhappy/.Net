using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMS.Common;
using System.Web;

namespace CMS.Web.Plugin.Forum
{
    public class post_pub : Web.UI.UserPage
    {
        protected string action = string.Empty;
        protected int board_id;  //版块ID
        protected int post_id;  //主题帖ID
        protected int is_moderator = 0;
        protected string title = string.Empty;
        protected string content = string.Empty;

        protected string rurl = string.Empty;

        /// <summary>
        /// 重写虚方法,此方法在Init事件执行
        /// </summary>
        protected override void InitPage()
        {
            action = DTRequest.GetQueryString("action");
            board_id = DTRequest.GetQueryInt("board_id");
            post_id = DTRequest.GetQueryInt("post_id");

            if (action == "edit")
            { 
                Model.forum_posts post = new BLL.forum_posts().GetModel(post_id);


                //判断是否是斑竹
                string moderator = new BLL.forum_board().GetModel(board_id).moderator_list;
                moderator += ",";
                string[] mlist = moderator.Split(',');
                foreach (string item in mlist)
                {
                    if (item != "" && item == userModel.user_name)
                    {
                        is_moderator = 1;
                    }
                }
                
                //如不是斑竹，判断是否是该用户的帖子
                if (is_moderator == 0)
                {
                    if (userModel.id != post.user_id)
                    {
                        Response.End();
                    }
                }

                title = post.title;
                content = post.content;
                board_id = post.board_id;
                post_id = post.id;
            }


            rurl = linkurl("forumpostlist", board_id);
            if (HttpContext.Current.Request.Url != null && HttpContext.Current.Request.UrlReferrer != null)
            {
                string currUrl = HttpContext.Current.Request.Url.ToString().ToLower(); //当前页面
                string refUrl = HttpContext.Current.Request.UrlReferrer.ToString().ToLower(); //上一页面
                string regPath = linkurl("register").ToLower(); //注册页面
                if (currUrl != refUrl && refUrl.IndexOf(regPath) == -1)
                {
                    rurl = HttpContext.Current.Request.UrlReferrer.ToString();
                }
            }
        }
    }
}
