using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using DBUtility;

namespace WE_Project.DAL
{
        //BuyActiveCode
        public class BuyActiveCode
        {
            /// <summary>
            /// 得到一个对象实体
            /// </summary>
            public static Model.BuyActiveCode GetModel(object Id)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("select Id, CodeCount, FromMID, ToMID, PayTime, ConfirmTime, PicUrl, Remark, State, CreateTime  ");
                strSql.Append("  from BuyActiveCode ");
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
            public static Hashtable Insert(Model.BuyActiveCode model, Hashtable MyHs)
            {
                string guid = Guid.NewGuid().ToString();
                StringBuilder strSql = new StringBuilder();
                strSql.Append("insert into BuyActiveCode(");
                strSql.Append("CodeCount,FromMID,ToMID,PayTime,ConfirmTime,PicUrl,Remark,State,CreateTime");
                strSql.Append(") values (");
                strSql.Append("@CodeCount,@FromMID,@ToMID,@PayTime,@ConfirmTime,@PicUrl,@Remark,@State,@CreateTime");
                strSql.Append(") ");
                strSql.AppendFormat(";select '{0}'", guid);
                SqlParameter[] parameters = {
			            new SqlParameter("@CodeCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@FromMID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ToMID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@PayTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ConfirmTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@PicUrl", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@State", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime)             
              
            };

                parameters[0].Value = model.CodeCount;
                parameters[1].Value = model.FromMID;
                parameters[2].Value = model.ToMID;
                parameters[3].Value = model.PayTime;
                parameters[4].Value = model.ConfirmTime;
                parameters[5].Value = model.PicUrl;
                parameters[6].Value = model.Remark;
                parameters[7].Value = model.State;
                parameters[8].Value = model.CreateTime;
                MyHs.Add(strSql.ToString(), parameters);
                return MyHs;
            }

            /// <summary>
            /// 增加一条数据
            /// </summary>
            public static bool Insert(Model.BuyActiveCode model)
            {
                return DAL.CommonBase.RunHashtable(Insert(model, new Hashtable()));
            }


            /// <summary>
            /// 更新一条数据
            /// </summary>
            public static Hashtable Update(Model.BuyActiveCode model, Hashtable MyHs)
            {
                string guid = Guid.NewGuid().ToString();
                StringBuilder strSql = new StringBuilder();
                strSql.Append("update BuyActiveCode set ");

                strSql.Append(" CodeCount = @CodeCount , ");
                strSql.Append(" FromMID = @FromMID , ");
                strSql.Append(" ToMID = @ToMID , ");
                strSql.Append(" PayTime = @PayTime , ");
                strSql.Append(" ConfirmTime = @ConfirmTime , ");
                strSql.Append(" PicUrl = @PicUrl , ");
                strSql.Append(" Remark = @Remark , ");
                strSql.Append(" State = @State , ");
                strSql.Append(" CreateTime = @CreateTime  ");
                strSql.Append(" where Id=@Id ");
                strSql.AppendFormat(" ;select '{0}'", guid);

                SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@CodeCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@FromMID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@ToMID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@PayTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ConfirmTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@PicUrl", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@State", SqlDbType.Int,4) ,            
                        new SqlParameter("@CreateTime", SqlDbType.DateTime)             
              
            };

                parameters[0].Value = model.Id;
                parameters[1].Value = model.CodeCount;
                parameters[2].Value = model.FromMID;
                parameters[3].Value = model.ToMID;
                parameters[4].Value = model.PayTime;
                parameters[5].Value = model.ConfirmTime;
                parameters[6].Value = model.PicUrl;
                parameters[7].Value = model.Remark;
                parameters[8].Value = model.State;
                parameters[9].Value = model.CreateTime;
                MyHs.Add(strSql.ToString(), parameters);
                return MyHs;
            }

            /// <summary>
            /// 更新一条数据
            /// </summary>
            public static bool Update(Model.BuyActiveCode model)
            {
                return DAL.CommonBase.RunHashtable(Update(model, new Hashtable()));
            }


            /// <summary>
            /// 删除一条数据
            /// </summary>
            public static Hashtable Delete(object obj, Hashtable MyHs)
            {

                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from BuyActiveCode ");
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
                strSql.Append(" FROM BuyActiveCode ");
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
                strSql.Append(" FROM BuyActiveCode ");
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
                return DAL.CommonBase.GetTable("BuyActiveCode", "Id", "Id desc", strWhere, pageIndex, pageSize, out count);
            }


            /// <summary>
            /// 获得实体列表
            /// </summary>
            public static List<Model.BuyActiveCode> GetList(string strWhere)
            {
                List<Model.BuyActiveCode> list = new List<Model.BuyActiveCode>();

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
            public static List<Model.BuyActiveCode> GetList(int top, string strWhere)
            {
                List<Model.BuyActiveCode> list = new List<Model.BuyActiveCode>();

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
            public static List<Model.BuyActiveCode> GetList(string strWhere, int pageIndex, int pageSize, out int count)
            {
                List<Model.BuyActiveCode> list = new List<Model.BuyActiveCode>();

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
            private static Model.BuyActiveCode TranEntity(DataRow dr)
            {
                if (dr != null)
                {
                    Model.BuyActiveCode model = new Model.BuyActiveCode();

                    if (!string.IsNullOrEmpty(dr["Id"].ToString()))
                    {
                        model.Id = int.Parse(dr["Id"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["CodeCount"].ToString()))
                    {
                        model.CodeCount = int.Parse(dr["CodeCount"].ToString());
                    }
                    model.FromMID = dr["FromMID"].ToString();
                    model.ToMID = dr["ToMID"].ToString();
                    if (!string.IsNullOrEmpty(dr["PayTime"].ToString()))
                    {
                        model.PayTime = DateTime.Parse(dr["PayTime"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["ConfirmTime"].ToString()))
                    {
                        model.ConfirmTime = DateTime.Parse(dr["ConfirmTime"].ToString());
                    }
                    model.PicUrl = dr["PicUrl"].ToString();
                    model.Remark = dr["Remark"].ToString();
                    if (!string.IsNullOrEmpty(dr["State"].ToString()))
                    {
                        model.State = int.Parse(dr["State"].ToString());
                    }
                    if (!string.IsNullOrEmpty(dr["CreateTime"].ToString()))
                    {
                        model.CreateTime = DateTime.Parse(dr["CreateTime"].ToString());
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
