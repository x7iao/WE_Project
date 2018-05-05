using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using DBUtility;
using System.Data;

namespace WE_Project.DAL
{
    //ActiveCode
    public class ActiveCode
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.ActiveCode GetModel(object Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from ActiveCode ");
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
        public static Hashtable Insert(Model.ActiveCode model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ActiveCode(");
            strSql.Append("Code,MID,UseState,CreateTime,UseMID,UseTime,SwitchType");
            strSql.Append(") values (");
            strSql.Append("@Code,@MID,@UseState,@CreateTime,@UseMID,@UseTime,@SwitchType");
            strSql.Append(") ");
            strSql.AppendFormat(";select '{0}'", guid);
            SqlParameter[] parameters = {
			            new SqlParameter("@Code", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@MID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@UseState", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@UseMID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@UseTime", SqlDbType.DateTime),            
                        new SqlParameter("@SwitchType", SqlDbType.NVarChar,50)             
              
            };

            parameters[0].Value = model.Code;
            parameters[1].Value = model.MID;
            parameters[2].Value = model.UseState;
            parameters[3].Value = model.CreateTime;
            parameters[4].Value = model.UseMID;
            parameters[5].Value = model.UseTime;
            parameters[6].Value = model.SwitchType;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Insert(Model.ActiveCode model)
        {
            return DAL.CommonBase.RunHashtable(Insert(model, new Hashtable()));
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(Model.ActiveCode model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ActiveCode set ");

            strSql.Append(" Code = @Code , ");
            strSql.Append(" MID = @MID , ");
            strSql.Append(" UseState = @UseState , ");
            strSql.Append(" CreateTime = @CreateTime , ");
            strSql.Append(" UseMID = @UseMID , ");
            strSql.Append(" SwitchType = @SwitchType , ");
            strSql.Append(" UseTime = @UseTime  ");
            strSql.Append(" where Id=@Id ");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Code", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@MID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@UseState", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@UseMID", SqlDbType.VarChar,40) ,            
                        new SqlParameter("@UseTime", SqlDbType.DateTime),            
                        new SqlParameter("@SwitchType", SqlDbType.NVarChar,50)               
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.Code;
            parameters[2].Value = model.MID;
            parameters[3].Value = model.UseState;
            parameters[4].Value = model.CreateTime;
            parameters[5].Value = model.UseMID;
            parameters[6].Value = model.UseTime;
            parameters[7].Value = model.SwitchType;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(Model.ActiveCode model)
        {
            return DAL.CommonBase.RunHashtable(Update(model, new Hashtable()));
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static Hashtable Delete(object obj, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ActiveCode ");
            strSql.AppendFormat(" where Id in ({0})", obj);
            MyHs.Add(strSql.ToString(), null);
            return MyHs;
        }

        public static Hashtable LockActiveCode(object obj, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update  ActiveCode ");
            strSql.AppendFormat(" set UseState=4 where Id in ({0})", obj);
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
            strSql.Append(" FROM ActiveCode ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }
        public static DataTable GetTopTable(string strWhere, int top)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + top + " * ");
            strSql.Append(" FROM ActiveCode ");
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
            strSql.Append(" FROM ActiveCode ");
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
            return DAL.CommonBase.GetTable("ActiveCode", "Id", "Id asc", strWhere, pageIndex, pageSize, out count);
        }


        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<Model.ActiveCode> GetList(string strWhere)
        {
            List<Model.ActiveCode> list = new List<Model.ActiveCode>();

            DataTable table = GetTable(strWhere);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(TranEntity(table.Rows[i]));
            }

            return list;
        }
        public static List<Model.ActiveCode> GetTopList(string strWhere, int top)
        {
            List<Model.ActiveCode> list = new List<Model.ActiveCode>();

            DataTable table = GetTopTable(strWhere, top);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(TranEntity(table.Rows[i]));
            }

            return list;
        }

        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<Model.ActiveCode> GetList(int top, string strWhere)
        {
            List<Model.ActiveCode> list = new List<Model.ActiveCode>();

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
        public static List<Model.ActiveCode> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.ActiveCode> list = new List<Model.ActiveCode>();

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
        private static Model.ActiveCode TranEntity(DataRow dr)
        {
            if (dr != null)
            {
                Model.ActiveCode model = new Model.ActiveCode();

                if (!string.IsNullOrEmpty(dr["Id"].ToString()))
                {
                    model.Id = int.Parse(dr["Id"].ToString());
                }
                model.Code = dr["Code"].ToString();
                model.MID = dr["MID"].ToString();
                if (!string.IsNullOrEmpty(dr["UseState"].ToString()))
                {
                    model.UseState = int.Parse(dr["UseState"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["CreateTime"].ToString()))
                {
                    model.CreateTime = DateTime.Parse(dr["CreateTime"].ToString());
                }
                model.UseMID = dr["UseMID"].ToString();
                if (!string.IsNullOrEmpty(dr["UseTime"].ToString()))
                {
                    model.UseTime = DateTime.Parse(dr["UseTime"].ToString());
                }
                model.SwitchType = dr["SwitchType"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
