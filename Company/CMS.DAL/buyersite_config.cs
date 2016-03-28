using System;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Data.SqlClient;
using CMS.DBUtility;
using CMS.Common;

namespace CMS.DAL
{
    /// <summary>
    /// 数据访问类:套餐站点信息表
    /// </summary>
    public partial class buyersite_config
    {
        private string databaseprefix; //数据库表名前缀
        public buyersite_config(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "buyersite_config ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 判断是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "buyersite_config");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM " + databaseprefix + "buyersite_config ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(Model.buyersite_config model)
        {
            string sql = "update [" + databaseprefix + @"buyersite_config] set 
                          [site_name] = @site_name, [site_domain] = @site_domain, [site_config] = @site_config, [update_time] = @update_time, [stat] = @stat 
                          WHERE  [id] = @id  ";

            List<SqlParameter> sp = new List<SqlParameter>();
            sp.Add(new SqlParameter("@id", model.id));
            sp.Add(new SqlParameter("@site_name", model.site_name));
            sp.Add(new SqlParameter("@site_domain", model.site_domain));
            sp.Add(new SqlParameter("@site_config", model.site_config));
            sp.Add(new SqlParameter("@update_time", model.update_time));
            sp.Add(new SqlParameter("@stat", model.stat));

            return DbHelperSQL.ExecuteSql(sql, sp.ToArray());
        }

        /// <summary>
        /// 增加，返回记录ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.buyersite_config model)
        {
            string sql = @"INSERT INTO [" + databaseprefix + @"buyersite_config] (
                                [user_id],[site_type],[site_name],[site_domain],[site_config],[add_time],[update_time],[stat]
                            ) VALUES (
                                @user_id, @site_type, @site_name, @site_domain, @site_config, @add_time, @update_time, @stat
                            );
                            SELECT SCOPE_IDENTITY();";

            List<SqlParameter> sp = new List<SqlParameter>();
            sp.Add(new SqlParameter("@user_id", model.user_id));
            sp.Add(new SqlParameter("@site_type", model.site_type));
            sp.Add(new SqlParameter("@site_name", model.site_name));
            sp.Add(new SqlParameter("@site_domain", model.site_domain));
            sp.Add(new SqlParameter("@site_config", model.site_config));
            sp.Add(new SqlParameter("@add_time", model.add_time));
            sp.Add(new SqlParameter("@update_time", model.update_time));
            sp.Add(new SqlParameter("@stat", model.stat));

            object obj = DbHelperSQL.GetSingle(sql, sp.ToArray());
            return obj == null ? 0 : Convert.ToInt32(obj);
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM " + databaseprefix + "buyersite_config");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }

        /// <summary>
        /// 统计记录条数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT COUNT(1) AS H FROM " + databaseprefix + "buyersite_config ");
            if (string.IsNullOrWhiteSpace(strWhere) == false)
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
    }
}
