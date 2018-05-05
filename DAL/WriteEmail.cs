using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DBUtility;
using System.Collections;

namespace WE_Project.DAL
{
    //WriteEmail
    public class WriteEmail
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.WriteEmail GetModel(object Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, Code, WriteTime, WriteBy, WriteContent, PublishBy, PublishTime  ");
            strSql.Append("  from WriteEmail ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
            parameters[0].Value = Id;


            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return TranEntity(ds.Tables[0].Rows[0]);
            else
                return null;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static Hashtable Insert(Model.WriteEmail model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into WriteEmail(");
            strSql.Append("Code,WriteTime,WriteBy,WriteContent,PublishBy,PublishTime");
            strSql.Append(") values (");
            strSql.Append("@Code,@WriteTime,@WriteBy,@WriteContent,@PublishBy,@PublishTime");
            strSql.Append(") ");
            strSql.AppendFormat(";select '{0}'", guid);
            SqlParameter[] parameters = {
			            new SqlParameter("@Code", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@WriteTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@WriteBy", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@WriteContent", SqlDbType.NText) ,            
                        new SqlParameter("@PublishBy", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@PublishTime", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = model.Code;
            parameters[1].Value = model.WriteTime;
            parameters[2].Value = model.WriteBy;
            parameters[3].Value = model.WriteContent;
            parameters[4].Value = model.PublishBy;
            parameters[5].Value = model.PublishTime;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Insert(Model.WriteEmail model)
        {
            return DAL.CommonBase.RunHashtable(Insert(model, new Hashtable()));
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(Model.WriteEmail model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WriteEmail set ");

            strSql.Append(" Code = @Code , ");
            strSql.Append(" WriteTime = @WriteTime , ");
            strSql.Append(" WriteBy = @WriteBy , ");
            strSql.Append(" WriteContent = @WriteContent , ");
            strSql.Append(" PublishBy = @PublishBy , ");
            strSql.Append(" PublishTime = @PublishTime  ");
            strSql.Append(" where Id=@Id ");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Code", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@WriteTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@WriteBy", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@WriteContent", SqlDbType.NText) ,            
                        new SqlParameter("@PublishBy", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@PublishTime", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.Code;
            parameters[2].Value = model.WriteTime;
            parameters[3].Value = model.WriteBy;
            parameters[4].Value = model.WriteContent;
            parameters[5].Value = model.PublishBy;
            parameters[6].Value = model.PublishTime;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(Model.WriteEmail model)
        {
            return DAL.CommonBase.RunHashtable(Update(model, new Hashtable()));
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static Hashtable Delete(object obj, Hashtable MyHs)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WriteEmail ");
            strSql.AppendFormat(" where Id in ({0})", obj);

            MyHs.Add(strSql.ToString(), null);
            return MyHs;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(object obj)
        {
            return DAL.CommonBase.RunHashtable(Delete(obj, new Hashtable()));
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataTable GetTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM WriteEmail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataTable GetTable(int top, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + top + " * ");
            strSql.Append(" FROM WriteEmail ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.CommonBase.GetTable("WriteEmail", "Id", "Id asc", strWhere, pageIndex, pageSize, out count);
        }


        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<Model.WriteEmail> GetList(string strWhere)
        {
            List<Model.WriteEmail> list = new List<Model.WriteEmail>();

            DataTable table = GetTable(strWhere);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(TranEntity(table.Rows[i]));
            }

            return list;
        }

        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<Model.WriteEmail> GetList(int top, string strWhere)
        {
            List<Model.WriteEmail> list = new List<Model.WriteEmail>();

            DataTable table = GetTable(top, strWhere);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(TranEntity(table.Rows[i]));
            }

            return list;
        }

        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<Model.WriteEmail> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.WriteEmail> list = new List<Model.WriteEmail>();

            DataTable table = GetTable(strWhere, pageIndex, pageSize, out count);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(TranEntity(table.Rows[i]));
            }

            return list;
        }

        /// <summary>
        ///  实体转换
        /// <summary>
        private static Model.WriteEmail TranEntity(DataRow dr)
        {
            if (dr != null)
            {
                Model.WriteEmail model = new Model.WriteEmail();

                if (!string.IsNullOrEmpty(dr["Id"].ToString()))
                {
                    model.Id = int.Parse(dr["Id"].ToString());
                }
                model.Code = dr["Code"].ToString();
                if (!string.IsNullOrEmpty(dr["WriteTime"].ToString()))
                {
                    model.WriteTime = DateTime.Parse(dr["WriteTime"].ToString());
                }
                model.WriteBy = dr["WriteBy"].ToString();
                model.WriteContent = dr["WriteContent"].ToString();
                model.PublishBy = dr["PublishBy"].ToString();
                if (!string.IsNullOrEmpty(dr["PublishTime"].ToString()))
                {
                    model.PublishTime = DateTime.Parse(dr["PublishTime"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }
    }
}

