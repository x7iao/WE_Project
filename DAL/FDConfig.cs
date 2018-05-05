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
    //FDConfig
    public class FDConfig
    {
        private static Dictionary<string, Model.FDConfig> _FDConfigModel;
        public static Dictionary<string, Model.FDConfig> FDConfigModel
        {
            get
            {
                if (_FDConfigModel == null || _FDConfigModel.Count == 0)
                    _FDConfigModel = GetList("");
                return _FDConfigModel;
            }
            set
            {
                _FDConfigModel = value;
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static WE_Project.Model.FDConfig GetModel()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select FDName, FDCloseRemark, FDState, FDCFFloat, FDMHBFloat, FDMGPFloat, FDMCWFloat, FDSellCount, FDPrice, FDStartTime, FDEndTime  ");
            strSql.Append("  from FDConfig ");


            DataSet ds = DbHelperSQL.Query(strSql.ToString());

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return TranEntity(ds.Tables[0].Rows[0]);
            else
                return null;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static Hashtable Insert(WE_Project.Model.FDConfig model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FDConfig(");
            strSql.Append("FDName,FDCloseRemark,FDState,FDCFFloat,FDMHBFloat,FDMGPFloat,FDMCWFloat,FDSellCount,FDPrice,FDStartTime,FDEndTime");
            strSql.Append(") values (");
            strSql.Append("@FDName,@FDCloseRemark,@FDState,@FDCFFloat,@FDMHBFloat,@FDMGPFloat,@FDMCWFloat,@FDSellCount,@FDPrice,@FDStartTime,@FDEndTime");
            strSql.Append(") ");
            strSql.AppendFormat(";select '{0}'", guid);
            SqlParameter[] parameters = {
			            new SqlParameter("@FDName", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@FDCloseRemark", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@FDState", SqlDbType.Bit,1) ,            
                        new SqlParameter("@FDCFFloat", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@FDMHBFloat", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@FDMGPFloat", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@FDMCWFloat", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@FDSellCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@FDPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@FDStartTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@FDEndTime", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = model.FDName;
            parameters[1].Value = model.FDCloseRemark;
            parameters[2].Value = model.FDState;
            parameters[3].Value = model.FDCFFloat;
            parameters[4].Value = model.FDMHBFloat;
            parameters[5].Value = model.FDMGPFloat;
            parameters[6].Value = model.FDMCWFloat;
            parameters[7].Value = model.FDSellCount;
            parameters[8].Value = model.FDPrice;
            parameters[9].Value = model.FDStartTime;
            parameters[10].Value = model.FDEndTime;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Insert(WE_Project.Model.FDConfig model)
        {
            return DAL.CommonBase.RunHashtable(Insert(model, new Hashtable()));
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(WE_Project.Model.FDConfig model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update FDConfig set ");

            strSql.Append(" FDName = @FDName , ");
            strSql.Append(" FDCloseRemark = @FDCloseRemark , ");
            strSql.Append(" FDState = @FDState , ");
            strSql.Append(" FDCFFloat = @FDCFFloat , ");
            strSql.Append(" FDMHBFloat = @FDMHBFloat , ");
            strSql.Append(" FDMGPFloat = @FDMGPFloat , ");
            strSql.Append(" FDMCWFloat = @FDMCWFloat , ");
            strSql.Append(" FDSellCount = @FDSellCount , ");
            strSql.Append(" FDPrice = @FDPrice , ");
            strSql.Append(" FDStartTime = @FDStartTime , ");
            strSql.Append(" FDEndTime = @FDEndTime  ");
            strSql.Append(" where FDName=@FDName  ");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
			            new SqlParameter("@FDName", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@FDCloseRemark", SqlDbType.VarChar,200) ,            
                        new SqlParameter("@FDState", SqlDbType.Bit,1) ,            
                        new SqlParameter("@FDCFFloat", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@FDMHBFloat", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@FDMGPFloat", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@FDMCWFloat", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@FDSellCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@FDPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@FDStartTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@FDEndTime", SqlDbType.DateTime)             
              
            };

            parameters[0].Value = model.FDName;
            parameters[1].Value = model.FDCloseRemark;
            parameters[2].Value = model.FDState;
            parameters[3].Value = model.FDCFFloat;
            parameters[4].Value = model.FDMHBFloat;
            parameters[5].Value = model.FDMGPFloat;
            parameters[6].Value = model.FDMCWFloat;
            parameters[7].Value = model.FDSellCount;
            parameters[8].Value = model.FDPrice;
            parameters[9].Value = model.FDStartTime;
            parameters[10].Value = model.FDEndTime;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(WE_Project.Model.FDConfig model)
        {
            return DAL.CommonBase.RunHashtable(Update(model, new Hashtable()));
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static Hashtable Delete(object obj, Hashtable MyHs)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from FDConfig ");
            strSql.AppendFormat(" where FDName in ({0})", obj);

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
            strSql.Append(" FROM FDConfig ");
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
            strSql.Append(" FROM FDConfig ");
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
            return DAL.CommonBase.GetTable("FDConfig", "FDName", "FDName asc,ID asc", strWhere, pageIndex, pageSize, out count);
        }


        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static Dictionary<string, WE_Project.Model.FDConfig> GetList(string strWhere)
        {
            Dictionary<string, WE_Project.Model.FDConfig> list = new Dictionary<string, WE_Project.Model.FDConfig>();

            DataTable table = GetTable(strWhere);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Model.FDConfig fd = TranEntity(table.Rows[i]);
                list.Add(fd.FDName, fd);
            }

            return list;
        }

        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<WE_Project.Model.FDConfig> GetList(int top, string strWhere)
        {
            List<WE_Project.Model.FDConfig> list = new List<WE_Project.Model.FDConfig>();

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
        public static List<WE_Project.Model.FDConfig> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<WE_Project.Model.FDConfig> list = new List<WE_Project.Model.FDConfig>();

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
        private static WE_Project.Model.FDConfig TranEntity(DataRow dr)
        {
            if (dr != null)
            {
                WE_Project.Model.FDConfig model = new WE_Project.Model.FDConfig();

                model.FDName = dr["FDName"].ToString();
                model.FDCloseRemark = dr["FDCloseRemark"].ToString();
                if (!string.IsNullOrEmpty(dr["FDState"].ToString()))
                {
                    model.FDState = bool.Parse(dr["FDState"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["FDCFFloat"].ToString()))
                {
                    model.FDCFFloat = decimal.Parse(dr["FDCFFloat"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["FDMHBFloat"].ToString()))
                {
                    model.FDMHBFloat = decimal.Parse(dr["FDMHBFloat"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["FDMGPFloat"].ToString()))
                {
                    model.FDMGPFloat = decimal.Parse(dr["FDMGPFloat"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["FDMCWFloat"].ToString()))
                {
                    model.FDMCWFloat = decimal.Parse(dr["FDMCWFloat"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["FDSellCount"].ToString()))
                {
                    model.FDSellCount = int.Parse(dr["FDSellCount"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["FDPrice"].ToString()))
                {
                    model.FDPrice = decimal.Parse(dr["FDPrice"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["FDStartTime"].ToString()))
                {
                    model.FDStartTime = DateTime.Parse(dr["FDStartTime"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["FDEndTime"].ToString()))
                {
                    model.FDEndTime = DateTime.Parse(dr["FDEndTime"].ToString());
                }
                model.ChaiFenCode = Convert.ToInt32(DAL.CommonBase.GetSingle("select isnull(max(ChaiFenCode),0) from FDSellList where SellFDName='" + model.FDName + "'"));

                return model;
            }
            else
            {
                return null;
            }
        }
    }
}
