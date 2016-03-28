using System;
using System.Data;
using System.Collections.Generic;
using CMS.Common;

namespace CMS.BLL
{
    /// <summary>
    /// 数据访问类:套餐站点信息表
    /// </summary>
    public partial class buyersite_config
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //获得站点配置信息
        private DAL.buyersite_config dal;
        public buyersite_config()
        {
            dal = new DAL.buyersite_config(siteConfig.sysdatabaseprefix);
        }

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Exists(int id)
        {
            return dal.Exists(id);   
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(Model.buyersite_config model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 增加，返回记录ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.buyersite_config model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            return dal.GetList(pageSize, pageIndex, strWhere, filedOrder, out recordCount);
        }

        /// <summary>
        /// 统计记录条数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount(string strWhere)
        {
            return dal.GetCount(strWhere);
        }
    }
}
