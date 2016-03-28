using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.Model
{
    /// <summary>
    /// 套餐站点信息表
    /// </summary>
    [Serializable]
    public partial class buyersite_config
    {
        /// <summary>
        /// 自增ID
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int user_id { get; set; }

        /// <summary>
        /// 站点类型
        /// </summary>
        public int site_type { get; set; }

        /// <summary>
        /// 站点名称
        /// </summary>
        public string site_name { get; set; }

        /// <summary>
        /// 站点主域名
        /// </summary>
        public string site_domain { get; set; }

        /// <summary>
        /// 站点配置
        /// </summary>
        public string site_config { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime add_time { get; set; }

        /// <summary>
        /// 最后更新时间
        /// </summary>
        public DateTime update_time { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int stat { get; set; }

    }
}
