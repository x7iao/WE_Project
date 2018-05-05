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
    //RegistInfo
    public class RegistInfo
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.RegistInfo GetModel(object GId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append("  from RegistInfo ");
            strSql.Append(" where GId=@GId ");
            SqlParameter[] parameters = {
					new SqlParameter("@GId", SqlDbType.VarChar,70)			};
            parameters[0].Value = GId;


            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return TranEntity(ds.Tables[0].Rows[0]);
            else
                return null;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static Hashtable Insert(Model.RegistInfo model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into RegistInfo(");
            strSql.Append("GId,MID,MEmail,MCreateTime,UseTime,State");
            strSql.Append(") values (");
            strSql.Append("@GId,@MID,@MEmail,@MCreateTime,@UseTime,@State");
            strSql.Append(") ");
            strSql.AppendFormat(";select '{0}'", guid);
            SqlParameter[] parameters = {
			            new SqlParameter("@GId", SqlDbType.VarChar,70) ,            
                        new SqlParameter("@MID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@MEmail", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@MCreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@UseTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@State", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.GId;
            parameters[1].Value = model.MID;
            parameters[2].Value = model.MEmail;
            parameters[3].Value = model.MCreateTime;
            parameters[4].Value = model.UseTime;
            parameters[5].Value = model.State;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Insert(Model.RegistInfo model)
        {
            return DAL.CommonBase.RunHashtable(Insert(model, new Hashtable()));
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(Model.RegistInfo model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update RegistInfo set ");

            strSql.Append(" GId = @GId , ");
            strSql.Append(" MID = @MID , ");
            strSql.Append(" MEmail = @MEmail , ");
            strSql.Append(" MCreateTime = @MCreateTime , ");
            strSql.Append(" UseTime = @UseTime , ");
            strSql.Append(" State = @State  ");
            strSql.Append(" where GId=@GId  ");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
			            new SqlParameter("@GId", SqlDbType.VarChar,70) ,            
                        new SqlParameter("@MID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@MEmail", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@MCreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@UseTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@State", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.GId;
            parameters[1].Value = model.MID;
            parameters[2].Value = model.MEmail;
            parameters[3].Value = model.MCreateTime;
            parameters[4].Value = model.UseTime;
            parameters[5].Value = model.State;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(Model.RegistInfo model)
        {
            return DAL.CommonBase.RunHashtable(Update(model, new Hashtable()));
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static Hashtable Delete(object obj, Hashtable MyHs)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from RegistInfo ");
            strSql.AppendFormat(" where GId in ({0})", obj);

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
            strSql.Append(" FROM RegistInfo ");
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
            strSql.Append(" FROM RegistInfo ");
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
            return DAL.CommonBase.GetTable("RegistInfo", "GId", "GId asc,ID asc", strWhere, pageIndex, pageSize, out count);
        }


        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<Model.RegistInfo> GetList(string strWhere)
        {
            List<Model.RegistInfo> list = new List<Model.RegistInfo>();

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
        public static List<Model.RegistInfo> GetList(int top, string strWhere)
        {
            List<Model.RegistInfo> list = new List<Model.RegistInfo>();

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
        public static List<Model.RegistInfo> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.RegistInfo> list = new List<Model.RegistInfo>();

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
        private static Model.RegistInfo TranEntity(DataRow dr)
        {
            if (dr != null)
            {
                Model.RegistInfo model = new Model.RegistInfo();

                model.GId = dr["GId"].ToString();
                model.MID = dr["MID"].ToString();
                model.MEmail = dr["MEmail"].ToString();
                if (!string.IsNullOrEmpty(dr["MCreateTime"].ToString()))
                {
                    model.MCreateTime = DateTime.Parse(dr["MCreateTime"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["UseTime"].ToString()))
                {
                    model.UseTime = DateTime.Parse(dr["UseTime"].ToString());
                }
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
