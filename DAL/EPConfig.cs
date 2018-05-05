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
    //EPConfig
    public class EPConfig
    {
        private static Model.EPConfig _EPConfigModel;
        public static Model.EPConfig EPConfigModel
        {
            get
            {
                if (_EPConfigModel == null)
                    _EPConfigModel = GetModel();
                return _EPConfigModel;
            }
            set
            {
                _EPConfigModel = value;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static WE_Project.Model.EPConfig GetModel()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 *  ");
            strSql.Append("  from EPConfig ");



            DataSet ds = DbHelperSQL.Query(strSql.ToString());

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return TranEntity(ds.Tables[0].Rows[0]);
            else
                return null;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static Hashtable Insert(WE_Project.Model.EPConfig model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into EPConfig(");
            strSql.Append("EPState,EPTimeOut,EPTimeOutCount,EPTimeOutJXCount,EPJYMAgencyTypeStr,EPStartTime,EPEndTime,EPJYType,EPJYMinMoney,EPJYBaseMoney,EPMoneyStr,EPProtocol,EPMoneyType,EPTakeOffMoney");
            strSql.Append(") values (");
            strSql.Append("@EPState,@EPTimeOut,@EPTimeOutCount,@EPTimeOutJXCount,@EPJYMAgencyTypeStr,@EPStartTime,@EPEndTime,@EPJYType,@EPJYMinMoney,@EPJYBaseMoney,@EPMoneyStr,@EPProtocol,@EPMoneyType,@EPTakeOffMoney");
            strSql.Append(") ");
            strSql.AppendFormat(";select '{0}'", guid);
            SqlParameter[] parameters = {
			            new SqlParameter("@EPState", SqlDbType.Bit,1) ,            
                        new SqlParameter("@EPTimeOut", SqlDbType.Int,4) ,            
                        new SqlParameter("@EPTimeOutCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@EPTimeOutJXCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@EPJYMAgencyTypeStr", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@EPStartTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@EPEndTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@EPJYType", SqlDbType.Int,4) ,            
                        new SqlParameter("@EPJYMinMoney", SqlDbType.Int,4) ,            
                        new SqlParameter("@EPJYBaseMoney", SqlDbType.Int,4) ,            
                        new SqlParameter("@EPMoneyStr", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@EPProtocol", SqlDbType.Text) ,            
                        new SqlParameter("@EPMoneyType", SqlDbType.VarChar,50),
                        new SqlParameter("@EPTakeOffMoney", SqlDbType.Decimal) 
              
            };

            parameters[0].Value = model.EPState;
            parameters[1].Value = model.EPTimeOut;
            parameters[2].Value = model.EPTimeOutCount;
            parameters[3].Value = model.EPTimeOutJXCount;
            parameters[4].Value = model.EPJYMAgencyTypeStr;
            parameters[5].Value = model.EPStartTime;
            parameters[6].Value = model.EPEndTime;
            parameters[7].Value = model.EPJYType;
            parameters[8].Value = model.EPJYMinMoney;
            parameters[9].Value = model.EPJYBaseMoney;
            parameters[10].Value = model.EPMoneyStr;
            parameters[11].Value = model.EPProtocol;
            parameters[12].Value = model.EPMoneyType;
            parameters[13].Value = model.EPTakeOffMoney;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Insert(WE_Project.Model.EPConfig model)
        {
            return DAL.CommonBase.RunHashtable(Insert(model, new Hashtable()));
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(WE_Project.Model.EPConfig model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update EPConfig set ");

            strSql.Append(" EPState = @EPState , ");
            strSql.Append(" EPTimeOut = @EPTimeOut , ");
            strSql.Append(" EPTimeOutCount = @EPTimeOutCount , ");
            strSql.Append(" EPTimeOutJXCount = @EPTimeOutJXCount , ");
            strSql.Append(" EPJYMAgencyTypeStr = @EPJYMAgencyTypeStr , ");
            strSql.Append(" EPStartTime = @EPStartTime , ");
            strSql.Append(" EPEndTime = @EPEndTime , ");
            strSql.Append(" EPJYType = @EPJYType , ");
            strSql.Append(" EPJYMinMoney = @EPJYMinMoney , ");
            strSql.Append(" EPJYBaseMoney = @EPJYBaseMoney , ");
            strSql.Append(" EPMoneyStr = @EPMoneyStr , ");
            strSql.Append(" EPProtocol = @EPProtocol , ");
            strSql.Append(" EPMoneyType = @EPMoneyType,  ");
            strSql.Append(" EPTakeOffMoney = @EPTakeOffMoney  ");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
			            new SqlParameter("@EPState", SqlDbType.Bit,1) ,            
                        new SqlParameter("@EPTimeOut", SqlDbType.Int,4) ,            
                        new SqlParameter("@EPTimeOutCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@EPTimeOutJXCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@EPJYMAgencyTypeStr", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@EPStartTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@EPEndTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@EPJYType", SqlDbType.Int,4) ,            
                        new SqlParameter("@EPJYMinMoney", SqlDbType.Int,4) ,            
                        new SqlParameter("@EPJYBaseMoney", SqlDbType.Int,4) ,            
                        new SqlParameter("@EPMoneyStr", SqlDbType.VarChar,100) ,            
                        new SqlParameter("@EPProtocol", SqlDbType.Text) ,            
                        new SqlParameter("@EPMoneyType", SqlDbType.VarChar,50) ,
                          new SqlParameter("@EPTakeOffMoney", SqlDbType.Decimal) 
              
            };

            parameters[0].Value = model.EPState;
            parameters[1].Value = model.EPTimeOut;
            parameters[2].Value = model.EPTimeOutCount;
            parameters[3].Value = model.EPTimeOutJXCount;
            parameters[4].Value = model.EPJYMAgencyTypeStr;
            parameters[5].Value = model.EPStartTime;
            parameters[6].Value = model.EPEndTime;
            parameters[7].Value = model.EPJYType;
            parameters[8].Value = model.EPJYMinMoney;
            parameters[9].Value = model.EPJYBaseMoney;
            parameters[10].Value = model.EPMoneyStr;
            parameters[11].Value = model.EPProtocol;
            parameters[12].Value = model.EPMoneyType;
            parameters[13].Value = model.EPTakeOffMoney;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(WE_Project.Model.EPConfig model)
        {
            return DAL.CommonBase.RunHashtable(Update(model, new Hashtable()));
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static Hashtable Delete(object obj, Hashtable MyHs)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from EPConfig ");
            strSql.AppendFormat(" where  in ({0})", obj);

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
            strSql.Append(" FROM EPConfig ");
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
            strSql.Append(" FROM EPConfig ");
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
            return DAL.CommonBase.GetTable("EPConfig", "", " asc,ID asc", strWhere, pageIndex, pageSize, out count);
        }


        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<WE_Project.Model.EPConfig> GetList(string strWhere)
        {
            List<WE_Project.Model.EPConfig> list = new List<WE_Project.Model.EPConfig>();

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
        public static List<WE_Project.Model.EPConfig> GetList(int top, string strWhere)
        {
            List<WE_Project.Model.EPConfig> list = new List<WE_Project.Model.EPConfig>();

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
        public static List<WE_Project.Model.EPConfig> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<WE_Project.Model.EPConfig> list = new List<WE_Project.Model.EPConfig>();

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
        private static WE_Project.Model.EPConfig TranEntity(DataRow dr)
        {
            if (dr != null)
            {
                WE_Project.Model.EPConfig model = new WE_Project.Model.EPConfig();

                if (!string.IsNullOrEmpty(dr["EPState"].ToString()))
                {
                    model.EPState = bool.Parse(dr["EPState"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["EPTimeOut"].ToString()))
                {
                    model.EPTimeOut = int.Parse(dr["EPTimeOut"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["EPTimeOutCount"].ToString()))
                {
                    model.EPTimeOutCount = int.Parse(dr["EPTimeOutCount"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["EPTimeOutJXCount"].ToString()))
                {
                    model.EPTimeOutJXCount = int.Parse(dr["EPTimeOutJXCount"].ToString());
                }
                model.EPJYMAgencyTypeStr = dr["EPJYMAgencyTypeStr"].ToString();
                if (!string.IsNullOrEmpty(dr["EPStartTime"].ToString()))
                {
                    model.EPStartTime = DateTime.Parse(dr["EPStartTime"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["EPEndTime"].ToString()))
                {
                    model.EPEndTime = DateTime.Parse(dr["EPEndTime"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["EPJYType"].ToString()))
                {
                    model.EPJYType = int.Parse(dr["EPJYType"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["EPJYMinMoney"].ToString()))
                {
                    model.EPJYMinMoney = int.Parse(dr["EPJYMinMoney"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["EPJYBaseMoney"].ToString()))
                {
                    model.EPJYBaseMoney = int.Parse(dr["EPJYBaseMoney"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["EPTakeOffMoney"].ToString()))
                {
                    model.EPTakeOffMoney = decimal.Parse(dr["EPTakeOffMoney"].ToString());
                }
                model.EPMoneyStr = dr["EPMoneyStr"].ToString();
                model.EPProtocol = dr["EPProtocol"].ToString();
                model.EPMoneyType = dr["EPMoneyType"].ToString();

                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
