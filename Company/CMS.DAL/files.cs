using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using CMS.DBUtility;
using CMS.Common;

namespace CMS.DAL
{
    /// <summary>
    /// 数据访问类:上传文件存储
    /// </summary>
    public partial class files
    {
        private string databaseprefix; //数据库表名前缀
        public files(string _databaseprefix)
        {
            databaseprefix = _databaseprefix;
        }

        #region 基本方法============================
        /// <summary>
        /// 是否存在该记录(根据文件HASH值判断)
        /// </summary>
        public bool Exists(string fileHashValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from " + databaseprefix + "files");
            strSql.Append(" where file_md5=@hashvalue");
            SqlParameter[] parameters = {
					new SqlParameter("@hashvalue", SqlDbType.NVarChar,50)};
            parameters[0].Value = fileHashValue;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public Int64 Add(Model.files model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into " + databaseprefix + "files(");
            strSql.Append("file_name,file_path,file_md5,file_server,file_uptime,file_upuser,file_usetimes,file_state,file_type,file_endwith,file_fullpath)");
            strSql.Append(" values (");
            strSql.Append("@file_name,@file_path,@file_md5,@file_server,@file_uptime,@file_upuser,@file_usetimes,@file_state,@file_type,@file_endwith,@file_fullpath)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@file_name", SqlDbType.NVarChar,50),
					new SqlParameter("@file_path", SqlDbType.NVarChar,255),
					new SqlParameter("@file_md5", SqlDbType.NVarChar,50),
					new SqlParameter("@file_server", SqlDbType.NVarChar,50),
					new SqlParameter("@file_uptime", SqlDbType.DateTime),
					new SqlParameter("@file_upuser", SqlDbType.Int,4),
					new SqlParameter("@file_usetimes", SqlDbType.BigInt),
                    new SqlParameter("@file_state", SqlDbType.Int,4),
                    new SqlParameter("@file_type", SqlDbType.Int,4),
                    new SqlParameter("@file_endwith", SqlDbType.NVarChar,10),
                    new SqlParameter("@file_fullpath",SqlDbType.NVarChar,255)
                                        };
            parameters[0].Value = model.file_name;
            parameters[1].Value = model.file_path;
            parameters[2].Value = model.file_md5;
            parameters[3].Value = model.file_server;
            parameters[4].Value = model.file_uptime;
            parameters[5].Value = model.file_upuser;
            parameters[6].Value = model.file_usetimes;
            parameters[7].Value = model.file_state;
            parameters[8].Value = model.file_type;
            parameters[9].Value = model.file_endwith;
            parameters[10].Value = model.file_fullpath;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt64(obj);
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(Model.files model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "files set ");
            strSql.Append("file_name=@file_name,");
            strSql.Append("file_path=@express_code,");
            strSql.Append("file_md5=@express_fee,");
            strSql.Append("file_server=@website,");
            strSql.Append("file_uptime=@remark,");
            strSql.Append("file_upuser=@sort_id,");
            strSql.Append("file_usetimes=@is_lock,");
            strSql.Append("file_state=@is_lock,");
            strSql.Append("file_type=@is_lock,");
            strSql.Append("file_endwith=@is_lock,");
            strSql.Append("file_fullpath=@file_fullpath");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@file_name", SqlDbType.NVarChar,50),
					new SqlParameter("@file_path", SqlDbType.NVarChar,255),
					new SqlParameter("@file_md5", SqlDbType.NVarChar,50),
					new SqlParameter("@file_server", SqlDbType.NVarChar,50),
					new SqlParameter("@file_uptime", SqlDbType.DateTime),
					new SqlParameter("@file_upuser", SqlDbType.Int,4),
					new SqlParameter("@file_usetimes", SqlDbType.BigInt),
                    new SqlParameter("@file_state", SqlDbType.Int,4),
                    new SqlParameter("@file_type", SqlDbType.Int,4),
                    new SqlParameter("@file_endwith", SqlDbType.NVarChar,10),
                    new SqlParameter("@file_fullpath",SqlDbType.NVarChar,255),
					new SqlParameter("@id", SqlDbType.BigInt)};
            parameters[0].Value = model.file_name;
            parameters[1].Value = model.file_path;
            parameters[2].Value = model.file_md5;
            parameters[3].Value = model.file_server;
            parameters[4].Value = model.file_uptime;
            parameters[5].Value = model.file_upuser;
            parameters[6].Value = model.file_usetimes;
            parameters[7].Value = model.file_state;
            parameters[8].Value = model.file_type;
            parameters[9].Value = model.file_endwith;
            parameters[10].Value = model.file_fullpath;
            parameters[11].Value = model.id;

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
        /// 删除一条数据
        /// </summary>
        public bool Delete(Int64 id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from " + databaseprefix + "files ");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
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
        /// 得到一个对象实体
        /// </summary>
        public Model.files GetModel(Int64 id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id,file_name,file_path,file_md5,file_server,file_uptime,file_upuser,file_usetimes,file_state,file_type,file_endwith,file_fullpath");
            strSql.Append(" from " + databaseprefix + "files");
            strSql.Append(" where id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.BigInt)};
            parameters[0].Value = id;

            Model.files model = new Model.files();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select id,file_name,file_path,file_md5,file_server,file_uptime,file_upuser,file_usetimes,file_state,file_type,file_endwith,file_fullpath ");
            strSql.Append(" FROM " + databaseprefix + "files ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by id desc");
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" id,file_name,file_path,file_md5,file_server,file_uptime,file_upuser,file_usetimes,file_state,file_type,file_endwith,file_fullpath ");
            strSql.Append(" FROM " + databaseprefix + "files ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得查询分页数据
        /// </summary>
        public DataSet GetList(int pageSize, int pageIndex, string strWhere, string filedOrder, out int recordCount)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM " + databaseprefix + "files");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            recordCount = Convert.ToInt32(DbHelperSQL.GetSingle(PagingHelper.CreateCountingSql(strSql.ToString())));
            return DbHelperSQL.Query(PagingHelper.CreatePagingSql(recordCount, pageSize, pageIndex, strSql.ToString(), filedOrder));
        }
        #endregion

        #region 扩展方法============================
        /// <summary>
        /// 根据HASH值返回ID
        /// </summary>
        public Int64 GetModeID(string fileHashValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 id from " + databaseprefix + "files");
            strSql.Append(" where file_md5='" + fileHashValue + "'");
            object temp = DbHelperSQL.GetSingle(strSql.ToString());
            return temp == null ? 0 : Convert.ToInt64(temp);
        }

        /// <summary>
        /// 修改一列数据
        /// </summary>
        public void UpdateField(Int64 id, string strValue)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update " + databaseprefix + "files set " + strValue);
            strSql.Append(" where id=" + id);
            DbHelperSQL.ExecuteSql(strSql.ToString());
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Model.files DataRowToModel(DataRow row)
        {
            Model.files model = new Model.files();
            if (row != null)
            {
                if (row["id"] != null && row["id"].ToString() != "")
                {
                    model.id = int.Parse(row["id"].ToString());
                }
                if (row["file_name"] != null)
                {
                    model.file_name = row["file_name"].ToString();
                }
                if (row["file_path"] != null)
                {
                    model.file_path = row["file_path"].ToString();
                }
                if (row["file_md5"] != null)
                {
                    model.file_md5 = row["file_md5"].ToString();
                }
                if (row["file_server"] != null)
                {
                    model.file_server = row["file_server"].ToString();
                }
                if (row["file_uptime"] != null && row["file_uptime"].ToString() != "")
                {
                    model.file_uptime = DateTime.Parse(row["file_uptime"].ToString());
                }
                if (row["file_upuser"] != null && row["file_upuser"].ToString() != "")
                {
                    model.file_upuser = int.Parse(row["file_upuser"].ToString());
                }
                if (row["file_usetimes"] != null && row["file_usetimes"].ToString() != "")
                {
                    model.file_usetimes = Int64.Parse(row["file_usetimes"].ToString());
                }
                if (row["file_state"] != null && row["file_state"].ToString() != "")
                {
                    model.file_state = int.Parse(row["file_state"].ToString());
                }
                if (row["file_type"] != null && row["file_type"].ToString() != "")
                {
                    model.file_type = int.Parse(row["file_type"].ToString());
                }
                if (row["file_endwith"] != null)
                {
                    model.file_endwith = row["file_endwith"].ToString();
                }
                if (row["file_fullpath"] != null)
                {
                    model.file_fullpath = row["file_fullpath"].ToString();
                }
            }
            return model;
        }
        #endregion
    }
}