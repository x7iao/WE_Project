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
    //FDBuyList
    public class FDBuyList
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static WE_Project.Model.FDBuyList GetModel(object BuyID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from FDBuyList ");
            strSql.Append(" where BuyID=@BuyID");
            SqlParameter[] parameters = {
					new SqlParameter("@BuyID", SqlDbType.Int,4)
			};
            parameters[0].Value = BuyID;


            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return TranEntity(ds.Tables[0].Rows[0]);
            else
                return null;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static Hashtable Insert(WE_Project.Model.FDBuyList model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FDBuyList(");
            strSql.Append("BuyMID,BuyCount,BuyMoney,BuyDate,CFState,MoneyType,BuyPrice,BuyState,BuyFDName");
            strSql.Append(") values (");
            strSql.Append("@BuyMID,@BuyCount,@BuyMoney,@BuyDate,@CFState,@MoneyType,@BuyPrice,@BuyState,@BuyFDName");
            strSql.Append(") ");
            strSql.AppendFormat(";select '{0}'", guid);
            SqlParameter[] parameters = {
			            new SqlParameter("@BuyMID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@BuyCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@BuyMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@BuyDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@CFState", SqlDbType.Bit,1) ,            
                        new SqlParameter("@MoneyType", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@BuyPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@BuyState", SqlDbType.Int,4),
			            new SqlParameter("@BuyFDName", SqlDbType.VarChar,10)             
              
            };

            parameters[0].Value = model.BuyMID;
            parameters[1].Value = model.BuyCount;
            parameters[2].Value = model.BuyMoney;
            parameters[3].Value = model.BuyDate;
            parameters[4].Value = model.CFState;
            parameters[5].Value = model.MoneyType;
            parameters[6].Value = model.BuyPrice;
            parameters[7].Value = model.BuyState;
            parameters[8].Value = model.BuyFDName;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Insert(WE_Project.Model.FDBuyList model)
        {
            return DAL.CommonBase.RunHashtable(Insert(model, new Hashtable()));
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(WE_Project.Model.FDBuyList model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FDBuyList set ");

            strSql.Append(" BuyMID = @BuyMID , ");
            strSql.Append(" BuyCount = @BuyCount , ");
            strSql.Append(" BuyMoney = @BuyMoney , ");
            strSql.Append(" BuyDate = @BuyDate , ");
            strSql.Append(" CFState = @CFState , ");
            strSql.Append(" MoneyType = @MoneyType , ");
            strSql.Append(" BuyPrice = @BuyPrice , ");
            strSql.Append(" BuyFDName = @BuyFDName , ");
            strSql.Append(" BuyState = @BuyState  ");
            strSql.Append(" where BuyID=@BuyID ");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
			            new SqlParameter("@BuyID", SqlDbType.Int,4) ,            
                        new SqlParameter("@BuyMID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@BuyCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@BuyMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@BuyDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@CFState", SqlDbType.Bit,1) ,            
                        new SqlParameter("@MoneyType", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@BuyPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@BuyState", SqlDbType.Int,4),            
                        new SqlParameter("@BuyFDName", SqlDbType.VarChar,10)             
              
            };

            parameters[0].Value = model.BuyID;
            parameters[1].Value = model.BuyMID;
            parameters[2].Value = model.BuyCount;
            parameters[3].Value = model.BuyMoney;
            parameters[4].Value = model.BuyDate;
            parameters[5].Value = model.CFState;
            parameters[6].Value = model.MoneyType;
            parameters[7].Value = model.BuyPrice;
            parameters[8].Value = model.BuyState;
            parameters[9].Value = model.BuyFDName;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(WE_Project.Model.FDBuyList model)
        {
            return DAL.CommonBase.RunHashtable(Update(model, new Hashtable()));
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static Hashtable Delete(object obj, Hashtable MyHs)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from FDBuyList ");
            strSql.AppendFormat(" where BuyID in ({0})", obj);

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
            strSql.Append(" FROM FDBuyList ");
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
            strSql.Append(" FROM FDBuyList ");
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
            return DAL.CommonBase.GetTable("FDBuyList", "BuyID", "BuyID desc", strWhere, pageIndex, pageSize, out count);
        }


        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<WE_Project.Model.FDBuyList> GetList(string strWhere)
        {
            List<WE_Project.Model.FDBuyList> list = new List<WE_Project.Model.FDBuyList>();

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
        public static List<WE_Project.Model.FDBuyList> GetList(int top, string strWhere)
        {
            List<WE_Project.Model.FDBuyList> list = new List<WE_Project.Model.FDBuyList>();

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
        public static List<WE_Project.Model.FDBuyList> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<WE_Project.Model.FDBuyList> list = new List<WE_Project.Model.FDBuyList>();

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
        private static WE_Project.Model.FDBuyList TranEntity(DataRow dr)
        {
            if (dr != null)
            {
                WE_Project.Model.FDBuyList model = new WE_Project.Model.FDBuyList();

                if (!string.IsNullOrEmpty(dr["BuyID"].ToString()))
                {
                    model.BuyID = int.Parse(dr["BuyID"].ToString());
                }
                model.BuyMID = dr["BuyMID"].ToString();
                if (!string.IsNullOrEmpty(dr["BuyCount"].ToString()))
                {
                    model.BuyCount = int.Parse(dr["BuyCount"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["BuyMoney"].ToString()))
                {
                    model.BuyMoney = decimal.Parse(dr["BuyMoney"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["BuyDate"].ToString()))
                {
                    model.BuyDate = DateTime.Parse(dr["BuyDate"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["CFState"].ToString()))
                {
                    model.CFState = bool.Parse(dr["CFState"].ToString());
                }
                model.MoneyType = dr["MoneyType"].ToString();
                if (!string.IsNullOrEmpty(dr["BuyPrice"].ToString()))
                {
                    model.BuyPrice = decimal.Parse(dr["BuyPrice"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["BuyState"].ToString()))
                {
                    model.BuyState = int.Parse(dr["BuyState"].ToString());
                }
                model.BuyFDName = dr["BuyFDName"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
