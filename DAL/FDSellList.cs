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
    //FDSellList
    public class FDSellList
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static WE_Project.Model.FDSellList GetModel(object SellID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from FDSellList ");
            strSql.Append(" where SellID=@SellID");
            SqlParameter[] parameters = {
					new SqlParameter("@SellID", SqlDbType.Int,4)
			};
            parameters[0].Value = SellID;


            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return TranEntity(ds.Tables[0].Rows[0]);
            else
                return null;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static Hashtable Insert(WE_Project.Model.FDSellList model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FDSellList(");
            strSql.Append("BuyID,SellMID,SellTotalCount,SellCount,SellPrice,SellMoney,SellDate,LastSellDate,SellState,SellFDName,BuyDate,ChaiFenCode");
            strSql.Append(") values (");
            strSql.Append("@BuyID,@SellMID,@SellTotalCount,@SellCount,@SellPrice,@SellMoney,@SellDate,@LastSellDate,@SellState,@SellFDName,@BuyDate,@ChaiFenCode");
            strSql.Append(") ");
            strSql.AppendFormat(";select '{0}'", guid);
            SqlParameter[] parameters = {
			            new SqlParameter("@BuyID", SqlDbType.Int,4) ,            
                        new SqlParameter("@SellMID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SellTotalCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@SellCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@SellPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@SellMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@SellDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@LastSellDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@SellState", SqlDbType.Int,4),            
                        new SqlParameter("@SellFDName", SqlDbType.VarChar,10),            
                        new SqlParameter("@BuyDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@ChaiFenCode", SqlDbType.Int,4)             
              
            };

            parameters[0].Value = model.BuyID;
            parameters[1].Value = model.SellMID;
            parameters[2].Value = model.SellTotalCount;
            parameters[3].Value = model.SellCount;
            parameters[4].Value = model.SellPrice;
            parameters[5].Value = model.SellMoney;
            parameters[6].Value = model.SellDate;
            parameters[7].Value = model.LastSellDate;
            parameters[8].Value = model.SellState;
            parameters[9].Value = model.SellFDName;
            parameters[10].Value = model.BuyDate;
            parameters[11].Value = model.ChaiFenCode;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Insert(WE_Project.Model.FDSellList model)
        {
            return DAL.CommonBase.RunHashtable(Insert(model, new Hashtable()));
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(WE_Project.Model.FDSellList model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FDSellList set ");

            strSql.Append(" BuyID = @BuyID , ");
            strSql.Append(" SellMID = @SellMID , ");
            strSql.Append(" SellTotalCount = @SellTotalCount , ");
            strSql.Append(" SellCount = @SellCount , ");
            strSql.Append(" SellPrice = @SellPrice , ");
            strSql.Append(" SellMoney = @SellMoney , ");
            strSql.Append(" SellDate = @SellDate , ");
            strSql.Append(" LastSellDate = @LastSellDate , ");
            strSql.Append(" SellFDName = @SellFDName , ");
            strSql.Append(" BuyDate = @BuyDate , ");
            strSql.Append(" ChaiFenCode = @ChaiFenCode , ");
            strSql.Append(" SellState = @SellState  ");
            strSql.Append(" where SellID=@SellID ");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
			            new SqlParameter("@SellID", SqlDbType.Int,4) ,            
                        new SqlParameter("@BuyID", SqlDbType.Int,4) ,            
                        new SqlParameter("@SellMID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SellTotalCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@SellCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@SellPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@SellMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@SellDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@LastSellDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@SellState", SqlDbType.Int,4),            
                        new SqlParameter("@SellFDName", SqlDbType.VarChar,10),            
                        new SqlParameter("@BuyDate", SqlDbType.DateTime),            
                        new SqlParameter("@ChaiFenCode", SqlDbType.Int,4)              
              
            };

            parameters[0].Value = model.SellID;
            parameters[1].Value = model.BuyID;
            parameters[2].Value = model.SellMID;
            parameters[3].Value = model.SellTotalCount;
            parameters[4].Value = model.SellCount;
            parameters[5].Value = model.SellPrice;
            parameters[6].Value = model.SellMoney;
            parameters[7].Value = model.SellDate;
            parameters[8].Value = model.LastSellDate;
            parameters[9].Value = model.SellState;
            parameters[10].Value = model.SellFDName;
            parameters[11].Value = model.BuyDate;
            parameters[12].Value = model.ChaiFenCode;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(WE_Project.Model.FDSellList model)
        {
            return DAL.CommonBase.RunHashtable(Update(model, new Hashtable()));
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static Hashtable Delete(object obj, Hashtable MyHs)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from FDSellList ");
            strSql.AppendFormat(" where SellID in ({0})", obj);

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
            strSql.Append(" FROM FDSellList ");
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
            strSql.Append(" FROM FDSellList ");
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
            return DAL.CommonBase.GetTable("FDSellList", "SellID", "BuyDate desc,SellID desc", strWhere, pageIndex, pageSize, out count);
        }


        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<WE_Project.Model.FDSellList> GetList(string strWhere)
        {
            List<WE_Project.Model.FDSellList> list = new List<WE_Project.Model.FDSellList>();

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
        public static List<WE_Project.Model.FDSellList> GetList(int top, string strWhere)
        {
            List<WE_Project.Model.FDSellList> list = new List<WE_Project.Model.FDSellList>();

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
        public static List<WE_Project.Model.FDSellList> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<WE_Project.Model.FDSellList> list = new List<WE_Project.Model.FDSellList>();

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
        private static WE_Project.Model.FDSellList TranEntity(DataRow dr)
        {
            if (dr != null)
            {
                WE_Project.Model.FDSellList model = new WE_Project.Model.FDSellList();

                if (!string.IsNullOrEmpty(dr["SellID"].ToString()))
                {
                    model.SellID = int.Parse(dr["SellID"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["BuyID"].ToString()))
                {
                    model.BuyID = int.Parse(dr["BuyID"].ToString());
                }
                model.SellMID = dr["SellMID"].ToString();
                if (!string.IsNullOrEmpty(dr["SellTotalCount"].ToString()))
                {
                    model.SellTotalCount = int.Parse(dr["SellTotalCount"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["SellCount"].ToString()))
                {
                    model.SellCount = int.Parse(dr["SellCount"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["SellPrice"].ToString()))
                {
                    model.SellPrice = decimal.Parse(dr["SellPrice"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["SellMoney"].ToString()))
                {
                    model.SellMoney = decimal.Parse(dr["SellMoney"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["SellDate"].ToString()))
                {
                    model.SellDate = DateTime.Parse(dr["SellDate"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["LastSellDate"].ToString()))
                {
                    model.LastSellDate = DateTime.Parse(dr["LastSellDate"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["BuyDate"].ToString()))
                {
                    model.BuyDate = DateTime.Parse(dr["BuyDate"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["SellState"].ToString()))
                {
                    model.SellState = int.Parse(dr["SellState"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["ChaiFenCode"].ToString()))
                {
                    model.ChaiFenCode = int.Parse(dr["ChaiFenCode"].ToString());
                }
                model.SellFDName = dr["SellFDName"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
