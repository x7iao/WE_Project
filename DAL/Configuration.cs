using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DBUtility;
using System.Data.SqlClient;
using System.Collections;

namespace WE_Project.DAL
{
    public class Configuration
    {

        private static Model.Configuration _model;
        public static Model.Configuration TModel
        {
            get
            {
                if (_model == null)
                    _model = DAL.Configuration.GetConfiguration();
                return _model;
            }
            set
            {
                _model = value;
            }
        }
        /// <summary>
        /// <summary>
        /// 返回系统配置信息
        /// </summary>
        /// <returns></returns>
        private static Model.Configuration GetConfiguration()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Configuration");

            DataSet ds = DbHelperSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
                return TranEntity(ds.Tables[0].Rows[0]);
            return null;
        }

        private static Model.Configuration TranEntity(DataRow dr)
        {
            WE_Project.Model.Configuration model = new WE_Project.Model.Configuration();

            model.HaSh = new Hashtable();

            if (!string.IsNullOrEmpty(dr["YLMoney"].ToString()))
            {
                model.YLMoney = int.Parse(dr["YLMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["InFloat"].ToString()))
            {
                model.InFloat = decimal.Parse(dr["InFloat"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["OutFloat"].ToString()))
            {
                model.OutFloat = decimal.Parse(dr["OutFloat"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["MaxDPCount"].ToString()))
            {
                model.MaxDPCount = int.Parse(dr["MaxDPCount"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["DPTopFloat"].ToString()))
            {
                model.DPTopFloat = decimal.Parse(dr["DPTopFloat"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["BDCount"].ToString()))
            {
                model.BDCount = int.Parse(dr["BDCount"].ToString());
            }
            model.DefaultRole = dr["DefaultRole"].ToString();
            if (!string.IsNullOrEmpty(dr["DMHBPart"].ToString()))
            {
                model.DMHBPart = decimal.Parse(dr["DMHBPart"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["DMGPPart"].ToString()))
            {
                model.DMGPPart = decimal.Parse(dr["DMGPPart"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["JMHBPart"].ToString()))
            {
                model.JMHBPart = decimal.Parse(dr["JMHBPart"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["TXMinMoney"].ToString()))
            {
                model.TXMinMoney = int.Parse(dr["TXMinMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["JMGPPart"].ToString()))
            {
                model.JMGPPart = decimal.Parse(dr["JMGPPart"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["GPrice"].ToString()))
            {
                model.GPrice = decimal.Parse(dr["GPrice"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["DFHFloat"].ToString()))
            {
                model.DFHFloat = decimal.Parse(dr["DFHFloat"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["DFHTopMoney"].ToString()))
            {
                model.DFHTopMoney = decimal.Parse(dr["DFHTopMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["MinBuyGCount"].ToString()))
            {
                model.MinBuyGCount = int.Parse(dr["MinBuyGCount"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["GLMoney"].ToString()))
            {
                model.GLMoney = decimal.Parse(dr["GLMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["AutoDFH"].ToString()))
            {
                model.AutoDFH = bool.Parse(dr["AutoDFH"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["TXBaseMoney"].ToString()))
            {
                model.TXBaseMoney = int.Parse(dr["TXBaseMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["ZZMinMoney"].ToString()))
            {
                model.ZZMinMoney = int.Parse(dr["ZZMinMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["ZZBaseMoney"].ToString()))
            {
                model.ZZBaseMoney = int.Parse(dr["ZZBaseMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["DHMinMoney"].ToString()))
            {
                model.DHMinMoney = int.Parse(dr["DHMinMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["DHBaseMoney"].ToString()))
            {
                model.DHBaseMoney = int.Parse(dr["DHBaseMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["MaxBuyGCount"].ToString()))
            {
                model.MaxBuyGCount = int.Parse(dr["MaxBuyGCount"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["DFHXFCount"].ToString()))
            {
                model.DFHXFCount = int.Parse(dr["DFHXFCount"].ToString());
            }

            if (!string.IsNullOrEmpty(dr["DFHOutCount"].ToString()))
            {
                model.DFHOutCount = int.Parse(dr["DFHOutCount"].ToString());
            }
            if (dr["CanRegedit"] != null && dr["CanRegedit"].ToString() != "")
            {
                if ((dr["CanRegedit"].ToString() == "1") || (dr["CanRegedit"].ToString().ToLower() == "true"))
                {
                    model.CanRegedit = true;
                }
                else
                {
                    model.CanRegedit = false;
                }
            }
            if (dr["DayRegeditNumber"] != null && dr["DayRegeditNumber"].ToString() != "")
            {
                model.DayRegeditNumber = int.Parse(dr["DayRegeditNumber"].ToString());
            }
            if (dr["ShowOfferTotalMoney"] != null && dr["ShowOfferTotalMoney"].ToString() != "")
            {
                model.ShowOfferTotalMoney = decimal.Parse(dr["ShowOfferTotalMoney"].ToString());
            }
            if (dr["ShowGetTotalMoney"] != null && dr["ShowGetTotalMoney"].ToString() != "")
            {
                model.ShowGetTotalMoney = decimal.Parse(dr["ShowGetTotalMoney"].ToString());
            }
            if (dr["ShowTotalNumber"] != null && dr["ShowTotalNumber"].ToString() != "")
            {
                model.ShowTotalNumber = int.Parse(dr["ShowTotalNumber"].ToString());
            }

            model.ConfigDictionaryTable = DAL.ConfigDictionary.GetTable();
            model.ConfigDictionaryList = DAL.ConfigDictionary.GetDicList();
            model.ConfigDictionaryLists = DAL.ConfigDictionary.GetList();
            model.NConfigDictionaryTable = DAL.NConfigDictionary.GetTable();
            model.NConfigDictionaryList = DAL.NConfigDictionary.GetDicList();

            model.SHMoneyTable = DAL.SHMoney.GetSHMoneyListDataTable();
            model.SHMoneyList = DAL.SHMoney.GetSHMoneyList(model.SHMoneyTable);
            return model;
        }

        public static bool Update(Model.Configuration model)
        {
            if (model == null)
                return false;
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Configuration set ");

            strSql.Append(" YLMoney = @YLMoney , ");
            strSql.Append(" InFloat = @InFloat , ");
            strSql.Append(" OutFloat = @OutFloat , ");
            strSql.Append(" MaxDPCount = @MaxDPCount , ");
            strSql.Append(" DPTopFloat = @DPTopFloat , ");
            strSql.Append(" BDCount = @BDCount , ");
            strSql.Append(" DefaultRole = @DefaultRole , ");
            strSql.Append(" DMHBPart = @DMHBPart , ");
            strSql.Append(" DMGPPart = @DMGPPart , ");
            strSql.Append(" JMHBPart = @JMHBPart , ");
            strSql.Append(" TXMinMoney = @TXMinMoney , ");
            strSql.Append(" JMGPPart = @JMGPPart , ");
            strSql.Append(" GPrice = @GPrice , ");
            strSql.Append(" DFHFloat = @DFHFloat , ");
            strSql.Append(" DFHTopMoney = @DFHTopMoney , ");
            strSql.Append(" MinBuyGCount = @MinBuyGCount , ");
            strSql.Append(" GLMoney = @GLMoney , ");
            strSql.Append(" AutoDFH = @AutoDFH , ");
            strSql.Append(" TXBaseMoney = @TXBaseMoney , ");
            strSql.Append(" ZZMinMoney = @ZZMinMoney , ");
            strSql.Append(" ZZBaseMoney = @ZZBaseMoney , ");
            strSql.Append(" DHMinMoney = @DHMinMoney , ");
            strSql.Append(" DHBaseMoney = @DHBaseMoney , ");
            strSql.Append(" MaxBuyGCount = @MaxBuyGCount,  ");
            strSql.Append(" DFHXFCount = @DFHXFCount, ");
            strSql.Append(" DFHOutCount = @DFHOutCount,  ");
            strSql.Append("CanRegedit=@CanRegedit,");
            strSql.Append("DayRegeditNumber=@DayRegeditNumber,");
            strSql.Append("ShowOfferTotalMoney=@ShowOfferTotalMoney,");
            strSql.Append("ShowGetTotalMoney=@ShowGetTotalMoney,");
            strSql.Append("ShowTotalNumber=@ShowTotalNumber");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
			            new SqlParameter("@YLMoney", SqlDbType.Int,4) ,            
                        new SqlParameter("@InFloat", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@OutFloat", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@MaxDPCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@DPTopFloat", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@BDCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@DefaultRole", SqlDbType.VarChar,10) ,            
                        new SqlParameter("@DMHBPart", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@DMGPPart", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@JMHBPart", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TXMinMoney", SqlDbType.Int,4) ,            
                        new SqlParameter("@JMGPPart", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@GPrice", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@DFHFloat", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@DFHTopMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@MinBuyGCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@GLMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@AutoDFH", SqlDbType.Bit,1) ,            
                        new SqlParameter("@TXBaseMoney", SqlDbType.Int,4) ,            
                        new SqlParameter("@ZZMinMoney", SqlDbType.Int,4) ,            
                        new SqlParameter("@ZZBaseMoney", SqlDbType.Int,4) ,            
                        new SqlParameter("@DHMinMoney", SqlDbType.Int,4) ,            
                        new SqlParameter("@DHBaseMoney", SqlDbType.Int,4),
                        new SqlParameter("@MaxBuyGCount", SqlDbType.Int,4),
                        new SqlParameter("@DFHXFCount", SqlDbType.Int,4),
                        new SqlParameter("@DFHOutCount", SqlDbType.Int,4),
					    new SqlParameter("@CanRegedit", SqlDbType.Bit,1),
					    new SqlParameter("@DayRegeditNumber", SqlDbType.Int,4),
					    new SqlParameter("@ShowOfferTotalMoney", SqlDbType.Decimal,9),
					    new SqlParameter("@ShowGetTotalMoney", SqlDbType.Decimal,9),
					    new SqlParameter("@ShowTotalNumber", SqlDbType.Int,4)
            };

            parameters[0].Value = model.YLMoney;
            parameters[1].Value = model.InFloat;
            parameters[2].Value = model.OutFloat;
            parameters[3].Value = model.MaxDPCount;
            parameters[4].Value = model.DPTopFloat;
            parameters[5].Value = model.BDCount;
            parameters[6].Value = model.DefaultRole;
            parameters[7].Value = model.DMHBPart;
            parameters[8].Value = model.DMGPPart;
            parameters[9].Value = model.JMHBPart;
            parameters[10].Value = model.TXMinMoney;
            parameters[11].Value = model.JMGPPart;
            parameters[12].Value = model.GPrice;
            parameters[13].Value = model.DFHFloat;
            parameters[14].Value = model.DFHTopMoney;
            parameters[15].Value = model.MinBuyGCount;
            parameters[16].Value = model.GLMoney;
            parameters[17].Value = model.AutoDFH;
            parameters[18].Value = model.TXBaseMoney;
            parameters[19].Value = model.ZZMinMoney;
            parameters[20].Value = model.ZZBaseMoney;
            parameters[21].Value = model.DHMinMoney;
            parameters[22].Value = model.DHBaseMoney;
            parameters[23].Value = model.MaxBuyGCount;
            parameters[24].Value = model.DFHXFCount;
            parameters[25].Value = model.DFHOutCount;
            parameters[26].Value = model.CanRegedit;
            parameters[27].Value = model.DayRegeditNumber;
            parameters[28].Value = model.ShowOfferTotalMoney;
            parameters[29].Value = model.ShowGetTotalMoney;
            parameters[30].Value = model.ShowTotalNumber;

            Hashtable MyHs = new Hashtable();
            MyHs.Add(strSql.ToString(), parameters);

            DAL.SHMoney.UpdateList(model.SHMoneyList, MyHs);
            List<Model.ConfigDictionary> list = new List<Model.ConfigDictionary>();
            foreach (List<Model.ConfigDictionary> MyDe in DAL.Configuration.TModel.ConfigDictionaryList.Values)
            {
                list.AddRange(MyDe);
            }
            DAL.ConfigDictionary.UpdateList(list, MyHs);

            List<Model.NConfigDictionary> nlist = new List<Model.NConfigDictionary>();
            foreach (List<Model.NConfigDictionary> MyDe in DAL.Configuration.TModel.NConfigDictionaryList.Values)
            {
                nlist.AddRange(MyDe);
            }
            DAL.NConfigDictionary.UpdateList(nlist, MyHs);

            DAL.Configuration.TModel = null;
            return DAL.CommonBase.RunHashtable(MyHs);
        }

        public static Hashtable UpdateConfigurationCF(string fieldName, string fieldValue, bool isEqual, SqlDbType dataType, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            string guid = Guid.NewGuid().ToString();
            strSql.Append("update Configuration set ");
            if (isEqual)
            {
                if (dataType == SqlDbType.Int || dataType == SqlDbType.Decimal)
                    strSql.Append(string.Format("{0} = {1} ", fieldName, fieldValue));
                else
                    strSql.Append(string.Format("{0} = '{1}' ", fieldName, fieldValue));
            }
            else
            {
                if (dataType == SqlDbType.Int || dataType == SqlDbType.Decimal)
                    strSql.Append(string.Format("{0} = {0} + {1} ", fieldName, fieldValue));
                else
                    strSql.Append(string.Format("{0} = '{0}' + '{1}' ", fieldName, fieldValue));
            }


            MyHs.Add(strSql, null);

            return MyHs;
        }
        /// <summary>
        /// 【现金币】 转 【循环币】 是否开启
        /// </summary>
        /// <returns></returns>
        public static bool IsTranMoney(bool flag)
        {
            if (flag)
                return DbHelperSQL.ExecuteSql(string.Format("Update Configuration set IsTranMoney='{0}'", "1")) > 0;
            else
                return DbHelperSQL.ExecuteSql(string.Format("Update Configuration set IsTranMoney='{0}'", "0")) > 0;
        }

    }
}
