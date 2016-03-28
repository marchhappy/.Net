using System;
using System.Data;
using System.Collections.Generic;
using CMS.Common;

namespace CMS.BLL
{
    /// <summary>
    /// 数据访问类:套餐站点可用数量表
    /// </summary>
    public partial class buyersite
    {
        private readonly Model.siteconfig siteConfig = new BLL.siteconfig().loadConfig(); //获得站点配置信息
        private DAL.buyersite dal;
        public buyersite()
        {
            dal = new DAL.buyersite(siteConfig.sysdatabaseprefix);
        }

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="modelbase"></param>
        /// <param name="datas"></param>
        public void AddList(Model.buyersitebase modelbase, List<Model.buyersiteext> datas)
        {
            dal.AddList(modelbase, datas);
        }

        /// <summary>
        /// 增加，返回记录ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.buyersite model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Exists(int id)
        {
            return dal.Exists(id);
        }

        /// <summary>
        /// 应用次数操作 递增/递减
        /// </summary>
        /// <param name="id"></param>
        /// <param name="increment">是否增加</param>
        /// <returns></returns>
        public int AppliedCrement(int id, bool increment)
        {
            return dal.AppliedCrement(id, increment);
        }

        /// <summary>
        /// 获取记录的用户名
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetUserName(int id)
        {
            return dal.GetUserName(id);
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

        /// <summary>
        /// 统计站点的总数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCountSubDomain(string strWhere)
        {
            return dal.GetCountSubDomain(strWhere);
        }
    }
}
