using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMS.Model
{
    /// <summary>
    /// 套餐站点可用数量表 基类
    /// </summary>
    [Serializable]
    public class buyersitebase
    {
        /// <summary>
        /// 订单号
        /// </summary>
        public string order_no { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int user_id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime add_time { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public int stat { get; set; }
    }

    /// <summary>
    /// 套餐站点可用数量表 映射
    /// </summary>
    [Serializable]
    public class buyersiteext
    {
        /// <summary>
        /// 调用别名
        /// </summary>
        public string call_index { get; set; }

        /// <summary>
        /// 二级域名数量
        /// </summary>
        public int subdomain_num { get; set; }

        /// <summary>
        /// 已创建的域名数量
        /// </summary>
        public int subdomain_applied { get; set; }
    }


    /// <summary>
    /// 套餐站点可用数量表
    /// </summary>
    [Serializable]
    public partial class buyersite : buyersitebase
    {
        /// <summary>
        /// 自增ID
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 调用别名
        /// </summary>
        public string call_index { get; set; }

        /// <summary>
        /// 二级域名总数量
        /// </summary>
        public int subdomain_num { get; set; }

        /// <summary>
        /// 已创建的域名数量
        /// </summary>
        public int subdomain_applied { get; set; }
    }
}
