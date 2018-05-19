using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using DBUtility;

namespace WE_Project.DAL
{
    public class MemberConfig
    {
        /// <summary>
        /// 更新会员参数值
        /// </summary>
        /// <param name="mid">会员账号</param>
        /// <param name="ConfigValue">参数值</param>
        /// <param name="ConfigName">参数名称</param>
        /// <param name="MyHs"></param>
        /// <returns></returns>
        public static Hashtable UpdateConfigTran(string mid, string fieldName, string fieldValue, Model.Member shmodel, bool isEqual, SqlDbType dataType, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            string guid = Guid.NewGuid().ToString();
            strSql.Append("update MemberConfig set ");
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
            strSql.Append(string.Format(" where MID='{0}' and '{1}'='{1}'", mid, guid));

            if (isEqual)
                MyHs.Add(strSql, "1");
            else
                MyHs.Add(strSql, null);
            return MyHs;
        }
        /// <summary>
        /// 得到配置信息
        /// </summary>
        /// <param name="MID"></param>
        /// <param name="mhb"></param>
        /// <returns></returns>
        public static Model.MemberConfig GetModel(string MID, Model.Member member)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from MemberConfig");
            strSql.Append(" where MID=@MID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MID", SqlDbType.VarChar,20)};
            parameters[0].Value = MID;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
                return TranEntity(ds.Tables[0].Rows[0], member);
            return null;
        }

        public static Hashtable Insert(Model.MemberConfig model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into MemberConfig(");
            strSql.Append("MID,TakeOffMoney,ReBuyMoney,TotalTXMoney,JJTypeList,MHB,MJB,MCW,MGP,DTFHState,JTFHState,SHMoney,TotalDFHMoney,TotalZFHMoney,TotalYFHMoney,StockCount,TotalFHCount,TXStatus,ZZStatus,YJCount,EPTimeOutCount,EPXingCount,FDTrade,TJLDLevel,ReadNoticeID,GLMoneyDate,GLMoney,YJMoney,TJCount,TJMoney,UpSumMoney,TotalMoney,RealMoney,TotalLDMoney,OfferQuota,SQCount,TotalHLMoney,HLMoneyState,PPLeavel,NomalTotalThaw,VIPTotalThaw,MJBF");
            strSql.Append(") values (");
            strSql.Append("@MID,@TakeOffMoney,@ReBuyMoney,@TotalTXMoney,@JJTypeList,@MHB,@MJB,@MCW,@MGP,@DTFHState,@JTFHState,@SHMoney,@TotalDFHMoney,@TotalZFHMoney,@TotalYFHMoney,@StockCount,@TotalFHCount,@TXStatus,@ZZStatus,@YJCount,@EPTimeOutCount,@EPXingCount,@FDTrade,@TJLDLevel,@ReadNoticeID,@GLMoneyDate,@GLMoney,@YJMoney,@TJCount,@TJMoney,@UpSumMoney,@TotalMoney,@RealMoney,@TotalLDMoney,@OfferQuota,@SQCount,@TotalHLMoney,@HLMoneyState,@PPLeavel,@NomalTotalThaw,@VIPTotalThaw,@MJBF");
            strSql.Append(") ");
            strSql.AppendFormat(";select '{0}'", guid);
            SqlParameter[] parameters = {
			            new SqlParameter("@MID", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@TakeOffMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@ReBuyMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TotalTXMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@JJTypeList", SqlDbType.VarChar,300) ,            
                        new SqlParameter("@MHB", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@MJB", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@MCW", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@MGP", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@DTFHState", SqlDbType.Bit,1) ,            
                        new SqlParameter("@JTFHState", SqlDbType.Bit,1) ,            
                        new SqlParameter("@SHMoney", SqlDbType.Decimal,9) ,
                        new SqlParameter("@TotalDFHMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TotalZFHMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TotalYFHMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@StockCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@TotalFHCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@TXStatus", SqlDbType.Bit,1) ,            
                        new SqlParameter("@ZZStatus", SqlDbType.Bit,1) ,            
                        new SqlParameter("@YJCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@EPTimeOutCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@EPXingCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@FDTrade", SqlDbType.VarChar,30) ,            
                        new SqlParameter("@TJLDLevel", SqlDbType.Int,4) ,            
                        new SqlParameter("@ReadNoticeID", SqlDbType.Int,4) ,            
                        new SqlParameter("@GLMoneyDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@GLMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@YJMoney", SqlDbType.Decimal,9) ,
                        new SqlParameter("@TJCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@TJMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@UpSumMoney", SqlDbType.Int,4) ,            
                        new SqlParameter("@TotalMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@RealMoney", SqlDbType.Decimal,9),
                        new SqlParameter("@TotalLDMoney", SqlDbType.Decimal,9),
                        new SqlParameter("@OfferQuota", SqlDbType.Decimal,9),
                        new SqlParameter("@SQCount", SqlDbType.Int,4) ,
                        new SqlParameter("@TotalHLMoney", SqlDbType.Decimal,9),
                        new SqlParameter("@HLMoneyState", SqlDbType.Bit,1) ,
                        new SqlParameter("@PPLeavel", SqlDbType.Int,4),
                        new SqlParameter("@NomalTotalThaw", SqlDbType.Decimal,9) ,
                        new SqlParameter("@VIPTotalThaw", SqlDbType.Decimal,9),
                        new SqlParameter("@MJBF", SqlDbType.Decimal,9)
            };

            parameters[0].Value = model.MID;
            parameters[1].Value = model.TakeOffMoney;
            parameters[2].Value = model.ReBuyMoney;
            parameters[3].Value = model.TotalTXMoney;
            parameters[4].Value = model.JJTypeList;
            parameters[5].Value = model.MHB;
            parameters[6].Value = model.MJB;
            parameters[7].Value = model.MCW;
            parameters[8].Value = model.MGP;
            parameters[9].Value = model.DTFHState;
            parameters[10].Value = model.JTFHState;
            parameters[11].Value = model.SHMoney;
            parameters[12].Value = model.TotalDFHMoney;
            parameters[13].Value = model.TotalZFHMoney;
            parameters[14].Value = model.TotalYFHMoney;
            parameters[15].Value = model.StockCount;
            parameters[16].Value = model.TotalFHCount;
            parameters[17].Value = model.TXStatus;
            parameters[18].Value = model.ZZStatus;
            parameters[19].Value = model.YJCount;
            parameters[20].Value = model.EPTimeOutCount;
            parameters[21].Value = model.EPXingCount;
            parameters[22].Value = model.FDTrade;
            parameters[23].Value = model.TJLDLevel;
            parameters[24].Value = model.ReadNoticeID;
            parameters[25].Value = model.GLMoneyDate;
            parameters[26].Value = model.GLMoney;
            parameters[27].Value = model.YJMoney;
            parameters[28].Value = model.TJCount;
            parameters[29].Value = model.TJMoney;
            parameters[30].Value = model.UpSumMoney;
            parameters[31].Value = model.TotalMoney;
            parameters[32].Value = model.RealMoney;
            parameters[33].Value = model.TotalLDMoney;
            parameters[34].Value = model.OfferQuota;
            parameters[35].Value = model.SQCount;
            parameters[36].Value = model.TotalHLMoney;
            parameters[37].Value = model.HLMoneyState;
            parameters[38].Value = model.PPLeavel;
            parameters[39].Value = model.NomalTotalThaw;
            parameters[40].Value = model.VIPTotalThaw;
            parameters[41].Value = model.MJBF;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }
        public static Hashtable Update(Model.MemberConfig model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update MemberConfig set ");
            strSql.Append(" MID = @MID , ");
            strSql.Append(" TakeOffMoney = @TakeOffMoney , ");
            strSql.Append(" ReBuyMoney = @ReBuyMoney , ");
            strSql.Append(" TotalTXMoney = @TotalTXMoney , ");
            strSql.Append(" JJTypeList = @JJTypeList , ");
            strSql.Append(" MHB = @MHB , ");
            strSql.Append(" MJB = @MJB , ");
            strSql.Append(" MCW = @MCW , ");
            strSql.Append(" MGP = @MGP , ");
            strSql.Append(" DTFHState = @DTFHState , ");
            strSql.Append(" JTFHState = @JTFHState , ");
            strSql.Append(" SHMoney = @SHMoney , ");
            strSql.Append(" TotalDFHMoney = @TotalDFHMoney , ");
            strSql.Append(" TotalZFHMoney = @TotalZFHMoney , ");
            strSql.Append(" TotalYFHMoney = @TotalYFHMoney , ");
            strSql.Append(" StockCount = @StockCount , ");
            strSql.Append(" TotalFHCount = @TotalFHCount , ");
            strSql.Append(" TXStatus = @TXStatus , ");
            strSql.Append(" ZZStatus = @ZZStatus , ");
            strSql.Append(" YJCount = @YJCount , ");
            strSql.Append(" EPTimeOutCount = @EPTimeOutCount , ");
            strSql.Append(" EPXingCount = @EPXingCount , ");
            strSql.Append(" FDTrade = @FDTrade , ");
            strSql.Append(" TJLDLevel = @TJLDLevel , ");
            strSql.Append(" ReadNoticeID = @ReadNoticeID , ");
            strSql.Append(" GLMoneyDate = @GLMoneyDate , ");
            strSql.Append(" GLMoney = @GLMoney , ");
            strSql.Append(" YJMoney = @YJMoney , ");
            strSql.Append(" TJCount = @TJCount , ");
            strSql.Append(" TJMoney = @TJMoney , ");
            strSql.Append(" UpSumMoney = @UpSumMoney , ");
            strSql.Append(" TotalMoney = @TotalMoney , ");
            strSql.Append(" RealMoney = @RealMoney,  ");
            strSql.Append(" TotalLDMoney = @TotalLDMoney , ");
            strSql.Append(" OfferQuota = @OfferQuota, ");
            strSql.Append(" SQCount = @SQCount,  ");
            strSql.Append(" TotalHLMoney = @TotalHLMoney, ");
            strSql.Append(" HLMoneyState = @HLMoneyState,  ");
            strSql.Append(" PPLeavel = @PPLeavel , ");
            strSql.Append(" NomalTotalThaw = @NomalTotalThaw,  ");
            strSql.Append(" MJBF = @MJBF,  ");
            strSql.Append(" VIPTotalThaw = @VIPTotalThaw  ");
            strSql.Append(" where MID=@MID  ");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
			            new SqlParameter("@MID", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@TakeOffMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@ReBuyMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TotalTXMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@JJTypeList", SqlDbType.VarChar,300) ,            
                        new SqlParameter("@MHB", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@MJB", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@MCW", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@MGP", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@DTFHState", SqlDbType.Bit,1) ,            
                        new SqlParameter("@JTFHState", SqlDbType.Bit,1) ,            
                        new SqlParameter("@SHMoney",  SqlDbType.Decimal,9) ,
                        new SqlParameter("@TotalDFHMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TotalZFHMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TotalYFHMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@StockCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@TotalFHCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@TXStatus", SqlDbType.Bit,1) ,            
                        new SqlParameter("@ZZStatus", SqlDbType.Bit,1) ,            
                        new SqlParameter("@YJCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@EPTimeOutCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@EPXingCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@FDTrade", SqlDbType.VarChar,30) ,            
                        new SqlParameter("@TJLDLevel", SqlDbType.Int,4) ,            
                        new SqlParameter("@ReadNoticeID", SqlDbType.Int,4) ,            
                        new SqlParameter("@GLMoneyDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@GLMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@YJMoney",  SqlDbType.Decimal,9) ,
                        new SqlParameter("@TJCount", SqlDbType.Int,4) ,            
                        new SqlParameter("@TJMoney", SqlDbType.Decimal,9) ,
                        new SqlParameter("@UpSumMoney", SqlDbType.Int,4) ,            
                        new SqlParameter("@TotalMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@RealMoney", SqlDbType.Decimal,9) ,
                        new SqlParameter("@TotalLDMoney", SqlDbType.Decimal,9),
                        new SqlParameter("@OfferQuota", SqlDbType.Decimal,9),
                        new SqlParameter("@SQCount", SqlDbType.Int,4) ,
                        new SqlParameter("@TotalHLMoney", SqlDbType.Decimal,9),
                        new SqlParameter("@HLMoneyState", SqlDbType.Bit,1) ,
                        new SqlParameter("@PPLeavel", SqlDbType.Int,4),
                        new SqlParameter("@NomalTotalThaw", SqlDbType.Decimal,9) ,
                        new SqlParameter("@VIPTotalThaw", SqlDbType.Decimal,9),
                        new SqlParameter("@MJBF", SqlDbType.Decimal,9)
            };

            parameters[0].Value = model.MID;
            parameters[1].Value = model.TakeOffMoney;
            parameters[2].Value = model.ReBuyMoney;
            parameters[3].Value = model.TotalTXMoney;
            parameters[4].Value = model.JJTypeList;
            parameters[5].Value = model.MHB;
            parameters[6].Value = model.MJB;
            parameters[7].Value = model.MCW;
            parameters[8].Value = model.MGP;
            parameters[9].Value = model.DTFHState;
            parameters[10].Value = model.JTFHState;
            parameters[11].Value = model.SHMoney;
            parameters[12].Value = model.TotalDFHMoney;
            parameters[13].Value = model.TotalZFHMoney;
            parameters[14].Value = model.TotalYFHMoney;
            parameters[15].Value = model.StockCount;
            parameters[16].Value = model.TotalFHCount;
            parameters[17].Value = model.TXStatus;
            parameters[18].Value = model.ZZStatus;
            parameters[19].Value = model.YJCount;
            parameters[20].Value = model.EPTimeOutCount;
            parameters[21].Value = model.EPXingCount;
            parameters[22].Value = model.FDTrade;
            parameters[23].Value = model.TJLDLevel;
            parameters[24].Value = model.ReadNoticeID;
            parameters[25].Value = DateTime.Now;
            parameters[26].Value = model.GLMoney;
            parameters[27].Value = model.YJMoney;
            parameters[28].Value = model.TJCount;
            parameters[29].Value = model.TJMoney;
            parameters[30].Value = model.UpSumMoney;
            parameters[31].Value = model.TotalMoney;
            parameters[32].Value = model.RealMoney;
            parameters[33].Value = model.TotalLDMoney;
            parameters[34].Value = model.OfferQuota;
            parameters[35].Value = model.SQCount;
            parameters[36].Value = model.TotalHLMoney;
            parameters[37].Value = model.HLMoneyState;
            parameters[38].Value = model.PPLeavel;
            parameters[39].Value = model.NomalTotalThaw;
            parameters[40].Value = model.VIPTotalThaw;
            parameters[41].Value = model.MJBF;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 实体转换
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="mhb"></param>
        /// <returns></returns>
        public static Model.MemberConfig TranEntity(DataRow dr, Model.Member member)
        {
            Model.MemberConfig model = new Model.MemberConfig();

            model.MID = dr["MID"].ToString();
            if (member != null)
                model.Member = member;
            else
                model.Member = DAL.Member.GetModel(model.MID);
            if (!string.IsNullOrEmpty(dr["TakeOffMoney"].ToString()))
            {
                model.TakeOffMoney = decimal.Parse(dr["TakeOffMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["ReBuyMoney"].ToString()))
            {
                model.ReBuyMoney = decimal.Parse(dr["ReBuyMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["OfferQuota"].ToString()))
            {
                model.OfferQuota = decimal.Parse(dr["OfferQuota"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["SQCount"].ToString()))
            {
                model.SQCount = int.Parse(dr["SQCount"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["TotalTXMoney"].ToString()))
            {
                model.TotalTXMoney = decimal.Parse(dr["TotalTXMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["TotalHLMoney"].ToString()))
            {
                model.TotalHLMoney = decimal.Parse(dr["TotalHLMoney"].ToString());
            }
            model.JJTypeList = dr["JJTypeList"].ToString();
            if (!string.IsNullOrEmpty(dr["MHB"].ToString()))
            {
                model.MHB = decimal.Parse(dr["MHB"].ToString());
                //update by zhuxy 暂时没有冻结资金
                //model.MHBFreeze =model.Member.MAgencyType.GLMoney + DAL.Configuration.TModel.YLMoney + DAL.ChangeMoney.GetAllTx(model.MID);
                //model.MHBFreeze = model.Member.MAgencyType.GLMoney + DAL.Configuration.TModel.YLMoney + DAL.ChangeMoney.GetAllTx(model.MID);
                //if (model.Member.MState)
                //{
                //    model.MHBFreeze += +DAL.Configuration.TModel.GLMoney;
                //    DateTime time = member.MDate;
                //    while ((time = time.AddMonths(1)) < DateTime.Now)
                //    {
                //        model.MHBFreeze += DAL.Configuration.TModel.GLMoney;
                //    }
                //}
                model.MJJ = model.MHB - model.MHBFreeze;
                if (model.MJJ < 0)
                    model.MJJ = 0;
            }
            if (!string.IsNullOrEmpty(dr["MJB"].ToString()))
            {
                model.MJB = decimal.Parse(dr["MJB"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["MJBF"].ToString()))
            {
                model.MJBF = decimal.Parse(dr["MJBF"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["MCW"].ToString()))
            {
                //model.MCW = decimal.Parse(DAL.MGP_BuyRecord.CountTotalMCW(model.MID));
                model.MCW = decimal.Parse(dr["MCW"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["MGP"].ToString()))
            {
                model.MGP = decimal.Parse(dr["MGP"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["DTFHState"].ToString()))
            {
                model.DTFHState = bool.Parse(dr["DTFHState"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["JTFHState"].ToString()))
            {
                model.JTFHState = bool.Parse(dr["JTFHState"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["HLMoneyState"].ToString()))
            {
                model.HLMoneyState = bool.Parse(dr["HLMoneyState"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["SHMoney"].ToString()))
            {
                model.SHMoney = decimal.Parse(dr["SHMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["YJCount"].ToString()))
            {
                model.YJCount = int.Parse(dr["YJCount"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["YJMoney"].ToString()))
            {
                model.YJMoney = decimal.Parse(dr["YJMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["TJCount"].ToString()))
            {
                model.TJCount = int.Parse(dr["TJCount"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["TJMoney"].ToString()))
            {
                model.TJMoney = decimal.Parse(dr["TJMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["UpSumMoney"].ToString()))
            {
                model.UpSumMoney = int.Parse(dr["UpSumMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["TotalMoney"].ToString()))
            {
                model.TotalMoney = decimal.Parse(dr["TotalMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["RealMoney"].ToString()))
            {
                model.RealMoney = decimal.Parse(dr["RealMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["TotalDFHMoney"].ToString()))
            {
                model.TotalDFHMoney = decimal.Parse(dr["TotalDFHMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["TotalZFHMoney"].ToString()))
            {
                model.TotalZFHMoney = decimal.Parse(dr["TotalZFHMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["TotalYFHMoney"].ToString()))
            {
                model.TotalYFHMoney = decimal.Parse(dr["TotalYFHMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["StockCount"].ToString()))
            {
                model.StockCount = int.Parse(dr["StockCount"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["TotalFHCount"].ToString()))
            {
                model.TotalFHCount = int.Parse(dr["TotalFHCount"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["TXStatus"].ToString()))
            {
                model.TXStatus = bool.Parse(dr["TXStatus"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["ZZStatus"].ToString()))
            {
                model.ZZStatus = bool.Parse(dr["ZZStatus"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["ReadNoticeID"].ToString()))
            {
                model.ReadNoticeID = int.Parse(dr["ReadNoticeID"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["TJLDLevel"].ToString()))
            {
                model.TJLDLevel = int.Parse(dr["TJLDLevel"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["GLMoneyDate"].ToString()))
            {
                model.GLMoneyDate = DateTime.Parse(dr["GLMoneyDate"].ToString());
            }
            if (dr["EPTimeOutCount"] != null && dr["EPTimeOutCount"].ToString() != "")
            {
                model.EPTimeOutCount = int.Parse(dr["EPTimeOutCount"].ToString());
            }
            if (dr["EPXingCount"] != null && dr["EPXingCount"].ToString() != "")
            {
                model.EPXingCount = int.Parse(dr["EPXingCount"].ToString());
            }
            if (dr["FDTrade"] != null && dr["FDTrade"].ToString() != "")
            {
                model.FDTrade = dr["FDTrade"].ToString();
            }
            if (!string.IsNullOrEmpty(dr["GLMoney"].ToString()))
            {
                model.GLMoney = decimal.Parse(dr["GLMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["TotalLDMoney"].ToString()))
            {
                model.TotalLDMoney = decimal.Parse(dr["TotalLDMoney"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["PPLeavel"].ToString()))
            {
                model.PPLeavel = int.Parse(dr["PPLeavel"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["VIPTotalThaw"].ToString()))
            {
                model.VIPTotalThaw = decimal.Parse(dr["VIPTotalThaw"].ToString());
            }
            if (!string.IsNullOrEmpty(dr["NomalTotalThaw"].ToString()))
            {
                model.NomalTotalThaw = decimal.Parse(dr["NomalTotalThaw"].ToString());
            }
            return model;
        }
    }
}
