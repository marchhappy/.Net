using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMS.BLL;
using CMS.Model;

namespace CMS.API.ClsDll
{
    /// <summary>
    /// 
    /// </summary>
    public class buyersite
    {
        /// <summary>
        /// 添加套餐站点可用数量表
        /// </summary>
        /// <param name="model"></param>
        public void Add(Model.orders model)
        {
            if (model == null) return;

            var dic = this.GetCallIndexNumMap(model);
            if (dic.Count == 0) return;

            var bi = new Model.buyersitebase()
            {
                user_id = model.user_id,
                order_no = model.order_no,
                add_time = DateTime.Now,                
                stat = 1
            };

            var map = dic.Select(x => new Model.buyersiteext() { call_index = x.Key, subdomain_num = x.Value, subdomain_applied = 0 }).ToList();

            new BLL.buyersite().AddList(bi, map);
        }

        /// <summary>
        /// 调用别名和二级域名数量映射
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Dictionary<string, int> GetCallIndexNumMap(Model.orders model)
        {
            Dictionary<string, int> ciNumMap = new Dictionary<string, int>(); //调用别名和二级域名数量映射

            foreach (var g in model.order_goods)
            {
                Model.article art = new BLL.article().GetModel(g.article_id);
                if (art == null) continue;
                if (string.IsNullOrWhiteSpace(art.call_index)) continue;
                if (art.fields.ContainsKey("subdomainnum") == false) continue;

                int sdNum; //二级域名数量
                if (Int32.TryParse(art.fields["subdomainnum"], out sdNum) == false) continue;
                if (sdNum < 0) continue;

                sdNum = sdNum * g.quantity; //最终的二级域名数量
                if (ciNumMap.ContainsKey(art.call_index))
                {
                    ciNumMap[art.call_index] = ciNumMap[art.call_index] + sdNum;
                }
                else
                {
                    ciNumMap.Add(art.call_index, sdNum);
                }
            }
            return ciNumMap;
        }
    }
}
