using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DBUtility;
using System.Collections;
using System.Data.SqlClient;

namespace WE_Project.DAL
{
    //Remind
    public class Remind
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.Remind GetModel(object Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Id, RType, RTypeName, RemindMsg, State  ");
            strSql.Append("  from Remind ");
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
        public static Hashtable Insert(Model.Remind model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Remind(");
            strSql.Append("RType,RTypeName,RemindMsg,State");
            strSql.Append(") values (");
            strSql.Append("@RType,@RTypeName,@RemindMsg,@State");
            strSql.Append(") ");
            strSql.AppendFormat(";select '{0}'", guid);
            SqlParameter[] parameters = {
			            new SqlParameter("@RType", SqlDbType.Int,4) ,            
                        new SqlParameter("@RTypeName", SqlDbType.VarChar,150) ,            
                        new SqlParameter("@RemindMsg", SqlDbType.Text) ,            
                        new SqlParameter("@State", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.RType;
            parameters[1].Value = model.RTypeName;
            parameters[2].Value = model.RemindMsg;
            parameters[3].Value = model.State;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Insert(Model.Remind model)
        {
            return DAL.CommonBase.RunHashtable(Insert(model, new Hashtable()));
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(Model.Remind model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Remind set ");

            strSql.Append(" RType = @RType , ");
            strSql.Append(" RTypeName = @RTypeName , ");
            strSql.Append(" RemindMsg = @RemindMsg , ");
            strSql.Append(" State = @State  ");
            strSql.Append(" where Id=@Id ");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@RType", SqlDbType.Int,4) ,            
                        new SqlParameter("@RTypeName", SqlDbType.VarChar,150) ,            
                        new SqlParameter("@RemindMsg", SqlDbType.Text) ,            
                        new SqlParameter("@State", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.RType;
            parameters[2].Value = model.RTypeName;
            parameters[3].Value = model.RemindMsg;
            parameters[4].Value = model.State;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(Model.Remind model)
        {
            return DAL.CommonBase.RunHashtable(Update(model, new Hashtable()));
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static Hashtable Delete(object obj, Hashtable MyHs)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Remind ");
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
            strSql.Append(" FROM Remind ");
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
            strSql.Append(" FROM Remind ");
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
            return DAL.CommonBase.GetTable("Remind", "Id", "Id asc", strWhere, pageIndex, pageSize, out count);
        }


        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<Model.Remind> GetList(string strWhere)
        {
            List<Model.Remind> list = new List<Model.Remind>();

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
        public static List<Model.Remind> GetList(int top, string strWhere)
        {
            List<Model.Remind> list = new List<Model.Remind>();

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
        public static List<Model.Remind> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.Remind> list = new List<Model.Remind>();

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
        private static Model.Remind TranEntity(DataRow dr)
        {
            if (dr != null)
            {
                Model.Remind model = new Model.Remind();

                if (!string.IsNullOrEmpty(dr["Id"].ToString()))
                {
                    model.Id = int.Parse(dr["Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["RType"].ToString()))
                {
                    model.RType = int.Parse(dr["RType"].ToString());
                }
                model.RTypeName = dr["RTypeName"].ToString();
                model.RemindMsg = dr["RemindMsg"].ToString();
                if (!string.IsNullOrEmpty(dr["State"].ToString()))
                {
                    model.State = int.Parse(dr["State"].ToString());
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
