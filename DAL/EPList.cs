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
    //EPList
    public class EPList
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static WE_Project.Model.EPList GetModel(object EPID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from EPList ");
            strSql.Append(" where EPID=@EPID");
            SqlParameter[] parameters = {
					new SqlParameter("@EPID", SqlDbType.Int,4)
			};
            parameters[0].Value = EPID;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return TranEntity(ds.Tables[0].Rows[0]);
            else
                return null;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static Hashtable Insert(WE_Project.Model.EPList model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into EPList(");
            strSql.Append("LastSellDate,SellMID,SellDate,MoneyType,Money,SellState,BuyMID,BuyDate,LastBuyDate,TakeOffMoney");
            strSql.Append(") values (");
            strSql.Append("@LastSellDate,@SellMID,@SellDate,@MoneyType,@Money,@SellState,@BuyMID,@BuyDate,@LastBuyDate,@TakeOffMoney");
            strSql.Append(") ");
            strSql.AppendFormat(";select '{0}'", guid);
            SqlParameter[] parameters = {
			            new SqlParameter("@LastSellDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@SellMID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SellDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@MoneyType", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@Money", SqlDbType.Decimal,4) ,            
                        new SqlParameter("@SellState", SqlDbType.Int,4) ,            
                        new SqlParameter("@BuyMID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@BuyDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@LastBuyDate", SqlDbType.DateTime) ,
                         new SqlParameter("@TakeOffMoney", SqlDbType.Decimal,4) 
              
            };

            parameters[0].Value = model.LastSellDate;
            parameters[1].Value = model.SellMID;
            parameters[2].Value = model.SellDate;
            parameters[3].Value = model.MoneyType;
            parameters[4].Value = model.Money;
            parameters[5].Value = model.SellState;
            parameters[6].Value = model.BuyMID;
            parameters[7].Value = model.BuyDate;
            parameters[8].Value = model.LastBuyDate;
            parameters[9].Value = model.TakeOffMoney;
          
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Insert(WE_Project.Model.EPList model)
        {
            return DAL.CommonBase.RunHashtable(Insert(model, new Hashtable()));
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(WE_Project.Model.EPList model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update EPList set ");

            strSql.Append(" LastSellDate = @LastSellDate , ");
            strSql.Append(" SellMID = @SellMID , ");
            strSql.Append(" SellDate = @SellDate , ");
            strSql.Append(" MoneyType = @MoneyType , ");
            strSql.Append(" Money = @Money , ");
            strSql.Append(" SellState = @SellState , ");
            strSql.Append(" BuyMID = @BuyMID , ");
            strSql.Append(" BuyDate = @BuyDate , ");
            strSql.Append(" LastBuyDate = @LastBuyDate,  ");
            strSql.Append(" TakeOffMoney = @TakeOffMoney  ");
            strSql.Append(" where EPID=@EPID ");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
			            new SqlParameter("@EPID", SqlDbType.Int,4) ,            
                        new SqlParameter("@LastSellDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@SellMID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SellDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@MoneyType", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@Money", SqlDbType.Decimal,4) ,            
                        new SqlParameter("@SellState", SqlDbType.Int,4) ,            
                        new SqlParameter("@BuyMID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@BuyDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@LastBuyDate", SqlDbType.DateTime) ,
                          new SqlParameter("@TakeOffMoney", SqlDbType.Decimal,4) 
              
            };

            parameters[0].Value = model.EPID;
            parameters[1].Value = model.LastSellDate;
            parameters[2].Value = model.SellMID;
            parameters[3].Value = model.SellDate;
            parameters[4].Value = model.MoneyType;
            parameters[5].Value = model.Money;
            parameters[6].Value = model.SellState;
            parameters[7].Value = model.BuyMID;
            parameters[8].Value = model.BuyDate;
            parameters[9].Value = model.LastBuyDate;
            parameters[10].Value = model.TakeOffMoney;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(WE_Project.Model.EPList model)
        {
            return DAL.CommonBase.RunHashtable(Update(model, new Hashtable()));
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static Hashtable Delete(object obj, Hashtable MyHs)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from EPList ");
            strSql.AppendFormat(" where EPID in ({0})", obj);

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
            strSql.Append(" FROM EPList ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        public static DataTable GetTopTable(string strWhere,int top,string orderBy)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top "+top+" * ");
            strSql.Append(" FROM EPList ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            if (orderBy.Trim() != "")
            {
                strSql.Append(" order by " + orderBy);
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
            strSql.Append(" FROM EPList ");
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
            return DAL.CommonBase.GetTable("EPList", "EPID", "EPID asc,SellDate asc", strWhere, pageIndex, pageSize, out count);
        }


        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<WE_Project.Model.EPList> GetList(string strWhere)
        {
            List<WE_Project.Model.EPList> list = new List<WE_Project.Model.EPList>();

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
        public static List<WE_Project.Model.EPList> GetTopList(int top, string strWhere,string OrderBy)
        {
            List<WE_Project.Model.EPList> list = new List<WE_Project.Model.EPList>();

            DataTable table = GetTopTable(strWhere, top, OrderBy);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(TranEntity(table.Rows[i]));
            }

            return list;
        }

        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<WE_Project.Model.EPList> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<WE_Project.Model.EPList> list = new List<WE_Project.Model.EPList>();

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
        private static WE_Project.Model.EPList TranEntity(DataRow dr)
        {
            if (dr != null)
            {
                WE_Project.Model.EPList model = new WE_Project.Model.EPList();

                if (!string.IsNullOrEmpty(dr["EPID"].ToString()))
                {
                    model.EPID = int.Parse(dr["EPID"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["LastSellDate"].ToString()))
                {
                    model.LastSellDate = DateTime.Parse(dr["LastSellDate"].ToString());
                }
                model.SellMID = dr["SellMID"].ToString();
                if (!string.IsNullOrEmpty(dr["SellDate"].ToString()))
                {
                    model.SellDate = DateTime.Parse(dr["SellDate"].ToString());
                }
                model.MoneyType = dr["MoneyType"].ToString();
                if (!string.IsNullOrEmpty(dr["Money"].ToString()))
                {
                    model.Money = decimal.Parse(dr["Money"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["SellState"].ToString()))
                {
                    model.SellState = int.Parse(dr["SellState"].ToString());
                }
                model.BuyMID = dr["BuyMID"].ToString();
                if (!string.IsNullOrEmpty(dr["BuyDate"].ToString()))
                {
                    model.BuyDate = DateTime.Parse(dr["BuyDate"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["LastBuyDate"].ToString()))
                {
                    model.LastBuyDate = DateTime.Parse(dr["LastBuyDate"].ToString());
                }

                if (!string.IsNullOrEmpty(dr["TakeOffMoney"].ToString()))
                {
                    model.TakeOffMoney = decimal.Parse(dr["TakeOffMoney"].ToString());
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
