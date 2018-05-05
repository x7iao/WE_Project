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
    public class SHMoney
    {
        /// <summary>
        /// 得到绑定列表
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, Model.SHMoney> GetSHMoneyList(DataTable table)
        {
            Dictionary<string, Model.SHMoney> SHMoneyList = new Dictionary<string, Model.SHMoney>();

            if (table == null)
                table = GetSHMoneyListDataTable();

            foreach (DataRow dr in table.Rows)
            {
                Model.SHMoney model = TranEntity(dr);
                SHMoneyList.Add(model.MAgencyType, model);
            }

            return SHMoneyList;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataTable GetTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM SHMoney ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<Model.SHMoney> GetList(string strWhere)
        {
            List<Model.SHMoney> list = new List<Model.SHMoney>();

            DataTable table = GetTable(strWhere);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(TranEntity(table.Rows[i]));
            }

            return list;
        }

        public static Dictionary<string, Model.SHMoney> GetSHMoneyList()
        {
            return GetSHMoneyList(GetSHMoneyListDataTable());
        }

        /// <summary>
        /// 得到绑定列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSHMoneyListDataTable()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *,Money + ' (' + MAgencyName + ')' as 'MoneyMAgencyName' ");
            strSql.Append(" FROM SHMoney order by MAgencyType ");
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 获取升级等级
        /// </summary>
        /// <param name="yjcount">团队人数</param>
        /// <param name="tjcount">推荐人数</param>
        public static Model.SHMoney GetSJShmoney(int yjcount, int tjcount, string curAgency = "")
        {
            string strwhere = " ";
            if (!string.IsNullOrEmpty(curAgency))
            {
                strwhere = string.Format(" and MAgencyType > '{0}' ", curAgency);
            }
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 *,Money + ' (' + MAgencyName + ')' as 'MoneyMAgencyName' ");
            strSql.AppendFormat(" FROM SHMoney where {0} >= TJCount and {1} >= TemaCount {2} order by MAgencyType desc ", tjcount, yjcount, strwhere);
            DataTable dt = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            if (dt != null && dt.Rows.Count > 0)
            {
                return TranEntity(dt.Rows[0]);
            }
            return null;
        }

        /// <summary>
        /// 转换数据实体
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private static Model.SHMoney TranEntity(DataRow dr)
        {
            if (dr != null)
            {
                Model.SHMoney model = new Model.SHMoney();

                model.MAgencyType = dr["MAgencyType"].ToString();
                model.MColor = dr["MColor"].ToString();
                if (!string.IsNullOrEmpty(dr["ViewLevel"].ToString()))
                {
                    model.ViewLevel = int.Parse(dr["ViewLevel"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["TJCount"].ToString()))
                {
                    model.TJCount = int.Parse(dr["TJCount"].ToString());
                }
                model.TJAgency = dr["TJAgency"].ToString();
                if (!string.IsNullOrEmpty(dr["TemaCount"].ToString()))
                {
                    model.TemaCount = int.Parse(dr["TemaCount"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["DTopMoney"].ToString()))
                {
                    model.DTopMoney = decimal.Parse(dr["DTopMoney"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["SQHelpCount"].ToString()))
                {
                    model.SQHelpCount = int.Parse(dr["SQHelpCount"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["XYLastMemberCount"].ToString()))
                {
                    model.XYLastMemberCount = int.Parse(dr["XYLastMemberCount"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["XFMouthMinHelpMoney"].ToString()))
                {
                    model.XFMouthMinHelpMoney = decimal.Parse(dr["XFMouthMinHelpMoney"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["XFMounthMoney"].ToString()))
                {
                    model.XFMounthMoney = decimal.Parse(dr["XFMounthMoney"].ToString());
                }
                model.MAgencyName = dr["MAgencyName"].ToString();
                if (!string.IsNullOrEmpty(dr["InitMaxTZ"].ToString()))
                {
                    model.InitMaxTZ = int.Parse(dr["InitMaxTZ"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["XYFloat"].ToString()))
                {
                    model.XYFloat = decimal.Parse(dr["XYFloat"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["Money"].ToString()))
                {
                    model.Money = int.Parse(dr["Money"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["BTFloat"].ToString()))
                {
                    model.BTFloat = decimal.Parse(dr["BTFloat"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["TJFloat"].ToString()))
                {
                    model.TJFloat = decimal.Parse(dr["TJFloat"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["TXFloat"].ToString()))
                {
                    model.TXFloat = decimal.Parse(dr["TXFloat"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["TakeOffFloat"].ToString()))
                {
                    model.TakeOffFloat = decimal.Parse(dr["TakeOffFloat"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["ReBuyFloat"].ToString()))
                {
                    model.ReBuyFloat = decimal.Parse(dr["ReBuyFloat"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["MCWFloat"].ToString()))
                {
                    model.MCWFloat = decimal.Parse(dr["MCWFloat"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 更新绑定奖励列表
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static Hashtable UpdateList(Dictionary<string, Model.SHMoney> list, Hashtable MyHs)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("delete from SHMoney;");
            foreach (Model.SHMoney item in list.Values)
            {
                Insert(item, MyHs);
            }
            MyHs.Add(sb.ToString(), null);
            return MyHs;
        }

        public static Hashtable Insert(Model.SHMoney model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into SHMoney(");
            strSql.Append("MAgencyType,MColor,ViewLevel,TJCount,TJAgency,TemaCount,DTopMoney,SQHelpCount,XYLastMemberCount,XFMouthMinHelpMoney,XFMounthMoney,MAgencyName,InitMaxTZ,XYFloat,Money,BTFloat,TJFloat,TXFloat,TakeOffFloat,ReBuyFloat,MCWFloat");
            strSql.Append(") values (");
            strSql.Append("@MAgencyType,@MColor,@ViewLevel,@TJCount,@TJAgency,@TemaCount,@DTopMoney,@SQHelpCount,@XYLastMemberCount,@XFMouthMinHelpMoney,@XFMounthMoney,@MAgencyName,@InitMaxTZ,@XYFloat,@Money,@BTFloat,@TJFloat,@TXFloat,@TakeOffFloat,@ReBuyFloat,@MCWFloat");
            strSql.Append(") ");
            strSql.AppendFormat(";select '{0}'", guid);
            SqlParameter[] parameters = {
			            new SqlParameter("@MAgencyType", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@MColor", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@ViewLevel", SqlDbType.Int,4) ,            
                        new SqlParameter("@TJCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@TJAgency", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@TemaCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@DTopMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@SQHelpCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@XYLastMemberCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@XFMouthMinHelpMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@XFMounthMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@MAgencyName", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@InitMaxTZ", SqlDbType.Int,4) ,            
                        new SqlParameter("@XYFloat", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Money", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@BTFloat", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TJFloat", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TXFloat", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TakeOffFloat", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@ReBuyFloat", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@MCWFloat", SqlDbType.Decimal,9)             
              
            };

            parameters[0].Value = model.MAgencyType;
            parameters[1].Value = model.MColor;
            parameters[2].Value = model.ViewLevel;
            parameters[3].Value = model.TJCount;
            parameters[4].Value = model.TJAgency;
            parameters[5].Value = model.TemaCount;
            parameters[6].Value = model.DTopMoney;
            parameters[7].Value = model.SQHelpCount;
            parameters[8].Value = model.XYLastMemberCount;
            parameters[9].Value = model.XFMouthMinHelpMoney;
            parameters[10].Value = model.XFMounthMoney;
            parameters[11].Value = model._MAgencyName;
            parameters[12].Value = model.InitMaxTZ;
            parameters[13].Value = model.XYFloat;
            parameters[14].Value = model.Money;
            parameters[15].Value = model.BTFloat;
            parameters[16].Value = model.TJFloat;
            parameters[17].Value = model.TXFloat;
            parameters[18].Value = model.TakeOffFloat;
            parameters[19].Value = model.ReBuyFloat;
            parameters[20].Value = model.MCWFloat;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }
    }
}
