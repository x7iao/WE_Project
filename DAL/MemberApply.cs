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
    //MemberApply
    public class MemberApply
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.MemberApply GetModel(object Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  *  ");
            strSql.Append("  from MemberApply ");
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
        public static Hashtable Insert(Model.MemberApply model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into MemberApply(");
            strSql.Append("ApplyType,MID,MQQ,MQQGroup,MTel,ApplyTime,State,ConfirmTime,Remark");
            strSql.Append(") values (");
            strSql.Append("@ApplyType,@MID,@MQQ,@MQQGroup,@MTel,@ApplyTime,@State,@ConfirmTime,@Remark");
            strSql.Append(") ");
            strSql.AppendFormat(";select '{0}'", guid);
            SqlParameter[] parameters = {
			            new SqlParameter("@ApplyType", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@MID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@MQQ", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@MQQGroup", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@MTel", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@ApplyTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@State", SqlDbType.Int,4) ,            
                        new SqlParameter("@ConfirmTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Remark", SqlDbType.NVarChar,500)             
              
            };

            parameters[0].Value = model.ApplyType;
            parameters[1].Value = model.MID;
            parameters[2].Value = model.MQQ;
            parameters[3].Value = model.MQQGroup;
            parameters[4].Value = model.MTel;
            parameters[5].Value = model.ApplyTime;
            parameters[6].Value = model.State;
            parameters[7].Value = model.ConfirmTime;
            parameters[8].Value = model.Remark;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Insert(Model.MemberApply model)
        {
            return DAL.CommonBase.RunHashtable(Insert(model, new Hashtable()));
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(Model.MemberApply model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update MemberApply set ");

            strSql.Append(" ApplyType = @ApplyType , ");
            strSql.Append(" MID = @MID , ");
            strSql.Append(" MQQ = @MQQ , ");
            strSql.Append(" MQQGroup = @MQQGroup , ");
            strSql.Append(" MTel = @MTel , ");
            strSql.Append(" ApplyTime = @ApplyTime , ");
            strSql.Append(" State = @State , ");
            strSql.Append(" ConfirmTime = @ConfirmTime , ");
            strSql.Append(" Remark = @Remark  ");
            strSql.Append(" where Id=@Id ");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@ApplyType", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@MID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@MQQ", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@MQQGroup", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@MTel", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@ApplyTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@State", SqlDbType.Int,4) ,            
                        new SqlParameter("@ConfirmTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@Remark", SqlDbType.NVarChar,500)             
              
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.ApplyType;
            parameters[2].Value = model.MID;
            parameters[3].Value = model.MQQ;
            parameters[4].Value = model.MQQGroup;
            parameters[5].Value = model.MTel;
            parameters[6].Value = model.ApplyTime;
            parameters[7].Value = model.State;
            parameters[8].Value = model.ConfirmTime;
            parameters[9].Value = model.Remark;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(Model.MemberApply model)
        {
            return DAL.CommonBase.RunHashtable(Update(model, new Hashtable()));
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static Hashtable Delete(object obj, Hashtable MyHs)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from MemberApply ");
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

        public static string DeleteApply(string midlist)
        {
            string[] arr = midlist.Split(',');
            int succ = 0;
            int erro = 0;
            foreach (string mid in arr)
            {
                if (DbHelperSQL.ExecuteSql(string.Format("delete from MemberApply where Id in({0})", mid)) > 0)
                {
                    succ++;
                }
                else
                {
                    erro++;
                }
            }
            return "成功：" + succ.ToString() + " , 失败：" + erro.ToString();
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataTable GetTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM MemberApply ");
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
            strSql.Append(" FROM MemberApply ");
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
            return DAL.CommonBase.GetTable("MemberApply", "Id", "Id asc", strWhere, pageIndex, pageSize, out count);
        }

        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<Model.MemberApply> GetList(string strWhere)
        {
            List<Model.MemberApply> list = new List<Model.MemberApply>();

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
        public static List<Model.MemberApply> GetList(int top, string strWhere)
        {
            List<Model.MemberApply> list = new List<Model.MemberApply>();

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
        public static List<Model.MemberApply> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.MemberApply> list = new List<Model.MemberApply>();

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
        private static Model.MemberApply TranEntity(DataRow dr)
        {
            if (dr != null)
            {
                Model.MemberApply model = new Model.MemberApply();

                if (!string.IsNullOrEmpty(dr["Id"].ToString()))
                {
                    model.Id = int.Parse(dr["Id"].ToString());
                }

                model.ApplyType = dr["ApplyType"].ToString();
                model.MID = dr["MID"].ToString();
                model.MQQ = dr["MQQ"].ToString();
                model.MQQGroup = dr["MQQGroup"].ToString();
                model.MTel = dr["MTel"].ToString();
                if (!string.IsNullOrEmpty(dr["ApplyTime"].ToString()))
                {
                    model.ApplyTime = DateTime.Parse(dr["ApplyTime"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["State"].ToString()))
                {
                    model.State = int.Parse(dr["State"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["ConfirmTime"].ToString()))
                {
                    model.ConfirmTime = DateTime.Parse(dr["ConfirmTime"].ToString());
                }
                model.Remark = dr["Remark"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
