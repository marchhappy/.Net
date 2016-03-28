using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CMS.Web.UI.Page
{
    public partial class homeplan : Web.UI.BasePage
    {
        /// <summary>
        /// 重写虚方法,此方法将在Init事件前执行
        /// </summary>
        protected override void ShowPage()
        {
            
        }

        /// <summary>
        /// 获取套餐
        /// </summary>
        /// <param name="call_index"></param>
        /// <returns></returns>
        protected Model.article GetPlan(string call_index)
        {
            var art = GetArticleByCI(call_index);   
            return art == null ? new Model.article() : art;
        }
    }
}
