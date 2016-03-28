using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CMS.Common;

namespace CMS.Web.UI.Page
{
    /// <summary>
    /// 单页
    /// </summary>
    public partial class mysingle : Web.UI.BasePage
    {
        /// <summary>
        /// 当前显示的信息ID
        /// </summary>
        protected int CurentId { get; set; }
        
        /// <summary>
        /// 重写虚方法,此方法将在Init事件前执行
        /// </summary>
        protected override void ShowPage()
        {
            
        }

        /// <summary>
        /// 帮助页面定制内容
        /// </summary>
        protected string getCategoryContext(string channel_name, int category_id, string strwhere, string orderby)
        {
            int id = DTRequest.GetQueryInt("id");
            if (id < 1)
            {
                var dts = get_article_list(channel_name, category_id, 1, strwhere, orderby);
                if (dts == null || dts.Rows.Count == 0) return "";

                this.CurentId = Convert.ToInt32(dts.Rows[0]["id"].ToString());
                return dts.Rows[0]["content"].ToString();
            }
            else
            {                
                var model = new BLL.article().GetModel(id);
                if (model == null) return "";

                this.CurentId = model.id;
                return model.content;
            }
        }


    }
}
