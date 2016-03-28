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
    /// 数据访问类:套餐站点可用数量表
    /// </summary>
    public partial class buyersite
    {
        private string databaseprefix; //数据库表名前缀
        public buyersite(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        /// <summary>
        /// 批量新增
        /// </summary>
        /// <param name="modelbase"></param>
        /// <param name="datas"></param>
        public void AddList(Model.buyersitebase modelbase, List<Model.buyersiteext> datas)
        {
            string aSql = @"IF EXISTS(SELECT TOP 1 id  FROM " + databaseprefix + @"buyersite WHERE order_no=@order_no) BEGIN
	                            SELECT 0;
                            END ELSE BEGIN
                                BEGIN TRANSACTION;
	                                _HOLDPLACE_
                                COMMIT TRANSACTION;
                                SELECT 1;
                            END";

            List<SqlParameter> sp = new List<SqlParameter>();
            List<string> sql = new List<string>();
            for (int i = 0; i < datas.Count; i++)
            {
                string k = i.ToString();
                sql.Add(@"INSERT INTO [" + databaseprefix + @"buyersite] (
                                [order_no],[user_id],[call_index],   [subdomain_num],  [subdomain_applied], [add_time],[stat]
                            ) VALUES (
                                @order_no, @user_id, @call_index{0}, @subdomain_num{0}, @subdomain_applied{0}, @add_time, @stat
                            );".Replace("{0}", k));

                sp.Add(new SqlParameter("@call_index" + k, datas[i].call_index));
                sp.Add(new SqlParameter("@subdomain_num" + k, datas[i].subdomain_num));
                sp.Add(new SqlParameter("@subdomain_applied" + k, datas[i].subdomain_applied));
            }

            sp.Add(new SqlParameter("@order_no", modelbase.order_no));
            sp.Add(new SqlParameter("@user_id", modelbase.user_id));
            sp.Add(new SqlParameter("@add_time", modelbase.add_time));
            sp.Add(new SqlParameter("@stat", modelbase.stat));

            aSql = aSql.Replace("_HOLDPLACE_", string.Join("\r\n", sql));

            object obj = DbHelperSQL.GetSingle(aSql, sp.ToArray());
        }


        /// <summary>
        /// 增加，返回记录ID
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Add(Model.buyersite model)
        {
            string sql = @" IF EXISTS(SELECT TOP 1 id  FROM dt_buyersite WHERE order_no=@order_no) BEGIN
	                            SELECT 0;
                            END ELSE BEGIN
	                            INSERT INTO [dt_buyersite] (
                                    [order_no],[user_id],[call_index],[subdomain_num],[subdomain_applied],[add_time],[stat]
                                ) VALUES (
                                    @order_no, @user_id, @call_index, @subdomain_num, @subdomain_applied, @add_time, @stat
                                );
                                SELECT SCOPE_IDENTITY();
                            END ".Replace("dt_", databaseprefix);

            List<SqlParameter> sp = new List<SqlParameter>();
            sp.Add(new SqlParameter("@order_no", model.order_no));
            sp.Add(new SqlParameter("@user_id", model.user_id));
            sp.Add(new SqlParameter("@call_index", model.call_index));
            sp.Add(new SqlParameter("@subdomain_num", model.subdomain_num));
            sp.Add(new SqlParameter("@subdomain_applied", model.subdomain_applied));
            sp.Add(new SqlParameter("@add_time", model.add_time));
            sp.Add(new SqlParameter("@stat", model.stat));

            object obj = DbHelperSQL.GetSingle(sql, sp.ToArray());
            return obj == null ? 0 : Convert.ToInt32(obj);
        }

        /// <summary>
        /// 是否存在记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Exists(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "buyersite");
            strSql.Append(" where id=@id ");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)};
            parameters[0].Value = id;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 应用次数操作 递增/递减
        /// </summary>
        /// <param name="id"></param>
        /// <param name="increment">是否增加</param>
        /// <returns></returns>
        public int AppliedCrement(int id, bool increment)
        {
            string opt = increment ? "+" : "-";
            string sql = "update " + databaseprefix + "buyersite set subdomain_applied=subdomain_applied" + opt + "1  where id=" + id.ToString() + " ";
            return DbHelperSQL.ExecuteSql(sql);
        }

        /// <summary>
        /// 获取记录的用户名
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetUserName(int id)
        {
            string sql = "select top 1 [user_name] from dt_users where id in(select top 1 [user_id] from dt_buyersite where id=" + id.ToString() + ")";
            var v = DbHelperSQL.GetSingle(sql);
            return v == null ? "" : v.ToString();
        }

        /// <summary>
        /// 获取列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM " + databaseprefix + "buyersite ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM " + databaseprefix + "buyersite");
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
            strSql.Append("SELECT COUNT(1) AS H FROM " + databaseprefix + "buyersite ");
            if (string.IsNullOrWhiteSpace(strWhere) == false)
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        /// <summary>
        /// 统计站点的总数
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public int GetCountSubDomain(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT SUM(subdomain_num) AS H FROM " + databaseprefix + "buyersite ");
            if (string.IsNullOrWhiteSpace(strWhere) == false)
            {
                strSql.Append(" WHERE " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }
    }
}
