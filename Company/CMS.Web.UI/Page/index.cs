using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CMS.Web.UI.Page
{
    public partial class index : Web.UI.BasePage
    {
        /// <summary>
        /// 重写虚方法,此方法将在Init事件前执行
        /// </summary>
        protected override void ShowPage()
        {

        }

        /// <summary>
        /// 获取广告信息
        /// </summary>
        /// <param name="adId"></param>
        /// <returns></returns>
        protected DataTable GetAdvertBaner(int adId)
        {
            var ds = this.get_plugin_method("CMS.Web.Plugin.Advert", "DAL.advert_banner", "GetList2", "is_lock=0 and datediff(d,start_time,getdate())>=0 and datediff(d,end_time,getdate())<=0 and aid=" + adId.ToString());
            return ds;
        }
    }

}
