using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DBUtility;

namespace WE_Project.DAL
{
    //MMMConfig
    public class MMMConfig
    {
        private static Model.MMMConfig _model;
        public static Model.MMMConfig TModel
        {
            get
            {
                if (_model == null)
                    _model = DAL.MMMConfig.GetModel();
                return _model;
            }
            set
            {
                _model = value;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.MMMConfig GetModel()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append("  from MMMConfig ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return TranEntity(ds.Tables[0].Rows[0]);
            else
                return null;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static Hashtable Insert(Model.MMMConfig model, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into MMMConfig(");
            strSql.Append("ActiveCodePrice,MCWPrice,MOfferNeedMCW,OfferHelpMin,OfferHelpMax,OfferHelpBase,OfferHelpRangeTimes,OfferHelpRangeCount,OfferHelpNeedComplete,OfferHelpDayTotalMoney,OfferHelpTimes,OfferHelpSwitch,GetHelpMin,GetHelpMax,GetHelpBase,GetHelpRangeTimes,GetHelpRangeCount,GetHelpNeedComplete,GetHelpDayTotalMoney,GetHelpTimes,GetHelpSwitch,LineTimes,FreezeTimes,OutTimes,InterestPer,LiXi1,LiXi2,PayLimitTimes,ConfirmLimitTimes,OfferHelpFloat,GetHelpFloat,NoLineTimesMoneyFloat,HonestTimes,HonestFloat,PayLimitTimesPre,ConfirmLimitTimesPre,LastProportion,OfferTJKF,GetTJKF,ReleasePer,ReleaseConditionCount,GLRewardFreezeTimes,MacthTimesRange,MacthSwitch,MHBBase,MHBRangeTimes,MCWBase,MCWRangeTimes,MJBBase,MJBRangeTimes,FreezeTimesOfRegister,FreezeTimesOfOffer)");
            strSql.Append(" values (");
            strSql.Append("@ActiveCodePrice,@MCWPrice,@MOfferNeedMCW,@OfferHelpMin,@OfferHelpMax,@OfferHelpBase,@OfferHelpRangeTimes,@OfferHelpRangeCount,@OfferHelpNeedComplete,@OfferHelpDayTotalMoney,@OfferHelpTimes,@OfferHelpSwitch,@GetHelpMin,@GetHelpMax,@GetHelpBase,@GetHelpRangeTimes,@GetHelpRangeCount,@GetHelpNeedComplete,@GetHelpDayTotalMoney,@GetHelpTimes,@GetHelpSwitch,@LineTimes,@FreezeTimes,@OutTimes,@InterestPer,@LiXi1,@LiXi2,@PayLimitTimes,@ConfirmLimitTimes,@OfferHelpFloat,@GetHelpFloat,@NoLineTimesMoneyFloat,@HonestTimes,@HonestFloat,@PayLimitTimesPre,@ConfirmLimitTimesPre,@LastProportion,@OfferTJKF,@GetTJKF,@ReleasePer,@ReleaseConditionCount,@GLRewardFreezeTimes,@MacthTimesRange,@MacthSwitch,@MHBBase,@MHBRangeTimes,@MCWBase,@MCWRangeTimes,@MJBBase,@MJBRangeTimes,@FreezeTimesOfRegister,@FreezeTimesOfOffer)");
            SqlParameter[] parameters = {
					new SqlParameter("@ActiveCodePrice", SqlDbType.Decimal,9),
					new SqlParameter("@MCWPrice", SqlDbType.Decimal,9),
					new SqlParameter("@MOfferNeedMCW", SqlDbType.Decimal,9),
					new SqlParameter("@OfferHelpMin", SqlDbType.Decimal,9),
					new SqlParameter("@OfferHelpMax", SqlDbType.Decimal,9),
					new SqlParameter("@OfferHelpBase", SqlDbType.Decimal,9),
					new SqlParameter("@OfferHelpRangeTimes", SqlDbType.Int,4),
					new SqlParameter("@OfferHelpRangeCount", SqlDbType.Int,4),
					new SqlParameter("@OfferHelpNeedComplete", SqlDbType.Bit,1),
					new SqlParameter("@OfferHelpDayTotalMoney", SqlDbType.Decimal,9),
					new SqlParameter("@OfferHelpTimes", SqlDbType.VarChar,100),
					new SqlParameter("@OfferHelpSwitch", SqlDbType.Bit,1),
					new SqlParameter("@GetHelpMin", SqlDbType.Decimal,9),
					new SqlParameter("@GetHelpMax", SqlDbType.Decimal,9),
					new SqlParameter("@GetHelpBase", SqlDbType.Decimal,9),
					new SqlParameter("@GetHelpRangeTimes", SqlDbType.Int,4),
					new SqlParameter("@GetHelpRangeCount", SqlDbType.Int,4),
					new SqlParameter("@GetHelpNeedComplete", SqlDbType.Bit,1),
					new SqlParameter("@GetHelpDayTotalMoney", SqlDbType.Decimal,9),
					new SqlParameter("@GetHelpTimes", SqlDbType.VarChar,100),
					new SqlParameter("@GetHelpSwitch", SqlDbType.Bit,1),
					new SqlParameter("@LineTimes", SqlDbType.Int,4),
					new SqlParameter("@FreezeTimes", SqlDbType.Int,4),
					new SqlParameter("@OutTimes", SqlDbType.Int,4),
					new SqlParameter("@InterestPer", SqlDbType.Decimal,9),
					new SqlParameter("@LiXi1", SqlDbType.Decimal,9),
					new SqlParameter("@LiXi2", SqlDbType.Decimal,9),
					new SqlParameter("@PayLimitTimes", SqlDbType.Int,4),
					new SqlParameter("@ConfirmLimitTimes", SqlDbType.Int,4),
					new SqlParameter("@OfferHelpFloat", SqlDbType.Decimal,9),
					new SqlParameter("@GetHelpFloat", SqlDbType.Decimal,9),
					new SqlParameter("@NoLineTimesMoneyFloat", SqlDbType.Decimal,9),
					new SqlParameter("@HonestTimes", SqlDbType.Int,4),
					new SqlParameter("@HonestFloat", SqlDbType.Decimal,9),
					new SqlParameter("@PayLimitTimesPre", SqlDbType.Int,4),
					new SqlParameter("@ConfirmLimitTimesPre", SqlDbType.Int,4),
					new SqlParameter("@LastProportion", SqlDbType.Decimal,9),
					new SqlParameter("@OfferTJKF", SqlDbType.Decimal,9),
					new SqlParameter("@GetTJKF", SqlDbType.Decimal,9),
					new SqlParameter("@ReleasePer", SqlDbType.Decimal,9),
					new SqlParameter("@ReleaseConditionCount", SqlDbType.Int,4),
					new SqlParameter("@GLRewardFreezeTimes", SqlDbType.Int,4),
					new SqlParameter("@MacthTimesRange", SqlDbType.VarChar,100),
					new SqlParameter("@MacthSwitch", SqlDbType.Bit,1),
					new SqlParameter("@MHBBase", SqlDbType.Int,4),
					new SqlParameter("@MHBRangeTimes", SqlDbType.Int,4),
					new SqlParameter("@MCWBase", SqlDbType.Int,4),
					new SqlParameter("@MCWRangeTimes", SqlDbType.Int,4),
					new SqlParameter("@MJBBase", SqlDbType.Int,4),
					new SqlParameter("@MJBRangeTimes", SqlDbType.Int,4),
					new SqlParameter("@FreezeTimesOfRegister", SqlDbType.Int,4),
					new SqlParameter("@FreezeTimesOfOffer", SqlDbType.Int,4)};
            parameters[0].Value = model.ActiveCodePrice;
            parameters[1].Value = model.MCWPrice;
            parameters[2].Value = model.MOfferNeedMCW;
            parameters[3].Value = model.OfferHelpMin;
            parameters[4].Value = model.OfferHelpMax;
            parameters[5].Value = model.OfferHelpBase;
            parameters[6].Value = model.OfferHelpRangeTimes;
            parameters[7].Value = model.OfferHelpRangeCount;
            parameters[8].Value = model.OfferHelpNeedComplete;
            parameters[9].Value = model.OfferHelpDayTotalMoney;
            parameters[10].Value = model.OfferHelpTimes;
            parameters[11].Value = model.OfferHelpSwitch;
            parameters[12].Value = model.GetHelpMin;
            parameters[13].Value = model.GetHelpMax;
            parameters[14].Value = model.GetHelpBase;
            parameters[15].Value = model.GetHelpRangeTimes;
            parameters[16].Value = model.GetHelpRangeCount;
            parameters[17].Value = model.GetHelpNeedComplete;
            parameters[18].Value = model.GetHelpDayTotalMoney;
            parameters[19].Value = model.GetHelpTimes;
            parameters[20].Value = model.GetHelpSwitch;
            parameters[21].Value = model.LineTimes;
            parameters[22].Value = model.FreezeTimes;
            parameters[23].Value = model.OutTimes;
            parameters[24].Value = model.InterestPer;
            parameters[25].Value = model.LiXi1;
            parameters[26].Value = model.LiXi2;
            parameters[27].Value = model.PayLimitTimes;
            parameters[28].Value = model.ConfirmLimitTimes;
            parameters[29].Value = model.OfferHelpFloat;
            parameters[30].Value = model.GetHelpFloat;
            parameters[31].Value = model.NoLineTimesMoneyFloat;
            parameters[32].Value = model.HonestTimes;
            parameters[33].Value = model.HonestFloat;
            parameters[34].Value = model.PayLimitTimesPre;
            parameters[35].Value = model.ConfirmLimitTimesPre;
            parameters[36].Value = model.LastProportion;
            parameters[37].Value = model.OfferTJKF;
            parameters[38].Value = model.GetTJKF;
            parameters[39].Value = model.ReleasePer;
            parameters[40].Value = model.ReleaseConditionCount;
            parameters[41].Value = model.GLRewardFreezeTimes;
            parameters[42].Value = model.MacthTimesRange;
            parameters[43].Value = model.MacthSwitch;
            parameters[44].Value = model.MHBBase;
            parameters[45].Value = model.MHBRangeTimes;
            parameters[46].Value = model.MCWBase;
            parameters[47].Value = model.MCWRangeTimes;
            parameters[48].Value = model.MJBBase;
            parameters[49].Value = model.MJBRangeTimes;
            parameters[50].Value = model.FreezeTimesOfRegister;
            parameters[51].Value = model.FreezeTimesOfOffer;

            string guid = Guid.NewGuid().ToString();
            strSql.AppendFormat(";select '{0}'", guid);
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Insert(Model.MMMConfig model)
        {
            return DAL.CommonBase.RunHashtable(Insert(model, new Hashtable()));
        }

        public static bool ResetMMM(Model.Member model)
        {
            if (model.Role.Super)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from MHelpMatch;");
                strSql.Append("delete from [MOfferHelp];");
                strSql.Append("delete from [MGetHelp];");
                //strSql.Append("delete from [ActiveCode];");
                strSql.Append("delete from [RegistInfo];");
                DAL.MMMConfig.TModel = null;
                return DbHelperSQL.ExecuteSql(strSql.ToString()) > 0;
            }
            return false;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(Model.MMMConfig model, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update MMMConfig set ");
            strSql.Append("ActiveCodePrice=@ActiveCodePrice,");
            strSql.Append("MCWPrice=@MCWPrice,");
            strSql.Append("MOfferNeedMCW=@MOfferNeedMCW,");
            strSql.Append("OfferHelpMin=@OfferHelpMin,");
            strSql.Append("OfferHelpMax=@OfferHelpMax,");
            strSql.Append("OfferHelpBase=@OfferHelpBase,");
            strSql.Append("OfferHelpRangeTimes=@OfferHelpRangeTimes,");
            strSql.Append("OfferHelpRangeCount=@OfferHelpRangeCount,");
            strSql.Append("OfferHelpNeedComplete=@OfferHelpNeedComplete,");
            strSql.Append("OfferHelpDayTotalMoney=@OfferHelpDayTotalMoney,");
            strSql.Append("OfferHelpTimes=@OfferHelpTimes,");
            strSql.Append("OfferHelpSwitch=@OfferHelpSwitch,");
            strSql.Append("GetHelpMin=@GetHelpMin,");
            strSql.Append("GetHelpMax=@GetHelpMax,");
            strSql.Append("GetHelpBase=@GetHelpBase,");
            strSql.Append("GetHelpRangeTimes=@GetHelpRangeTimes,");
            strSql.Append("GetHelpRangeCount=@GetHelpRangeCount,");
            strSql.Append("GetHelpNeedComplete=@GetHelpNeedComplete,");
            strSql.Append("GetHelpDayTotalMoney=@GetHelpDayTotalMoney,");
            strSql.Append("GetHelpTimes=@GetHelpTimes,");
            strSql.Append("GetHelpSwitch=@GetHelpSwitch,");
            strSql.Append("LineTimes=@LineTimes,");
            strSql.Append("FreezeTimes=@FreezeTimes,");
            strSql.Append("OutTimes=@OutTimes,");
            strSql.Append("InterestPer=@InterestPer,");
            strSql.Append("LiXi1=@LiXi1,");
            strSql.Append("LiXi2=@LiXi2,");
            strSql.Append("PayLimitTimes=@PayLimitTimes,");
            strSql.Append("ConfirmLimitTimes=@ConfirmLimitTimes,");
            strSql.Append("OfferHelpFloat=@OfferHelpFloat,");
            strSql.Append("GetHelpFloat=@GetHelpFloat,");
            strSql.Append("NoLineTimesMoneyFloat=@NoLineTimesMoneyFloat,");
            strSql.Append("HonestTimes=@HonestTimes,");
            strSql.Append("HonestFloat=@HonestFloat,");
            strSql.Append("PayLimitTimesPre=@PayLimitTimesPre,");
            strSql.Append("ConfirmLimitTimesPre=@ConfirmLimitTimesPre,");
            strSql.Append("LastProportion=@LastProportion,");
            strSql.Append("OfferTJKF=@OfferTJKF,");
            strSql.Append("GetTJKF=@GetTJKF,");
            strSql.Append("ReleasePer=@ReleasePer,");
            strSql.Append("ReleaseConditionCount=@ReleaseConditionCount,");
            strSql.Append("GLRewardFreezeTimes=@GLRewardFreezeTimes,");
            strSql.Append("MacthTimesRange=@MacthTimesRange,");
            strSql.Append("MacthSwitch=@MacthSwitch,");
            strSql.Append("MHBBase=@MHBBase,");
            strSql.Append("MHBRangeTimes=@MHBRangeTimes,");
            strSql.Append("MCWBase=@MCWBase,");
            strSql.Append("MCWRangeTimes=@MCWRangeTimes,");
            strSql.Append("MJBBase=@MJBBase,");
            strSql.Append("MJBRangeTimes=@MJBRangeTimes,");
            strSql.Append("FreezeTimesOfRegister=@FreezeTimesOfRegister,");
            strSql.Append("FreezeTimesOfOffer=@FreezeTimesOfOffer");

            SqlParameter[] parameters = {
					new SqlParameter("@ActiveCodePrice", SqlDbType.Decimal,9),
					new SqlParameter("@MCWPrice", SqlDbType.Decimal,9),
					new SqlParameter("@MOfferNeedMCW", SqlDbType.Decimal,9),
					new SqlParameter("@OfferHelpMin", SqlDbType.Decimal,9),
					new SqlParameter("@OfferHelpMax", SqlDbType.Decimal,9),
					new SqlParameter("@OfferHelpBase", SqlDbType.Decimal,9),
                    new SqlParameter("@OfferHelpRangeTimes", SqlDbType.Int,4),
					new SqlParameter("@OfferHelpRangeCount", SqlDbType.Int,4),
					new SqlParameter("@OfferHelpNeedComplete", SqlDbType.Bit,1),
					new SqlParameter("@OfferHelpDayTotalMoney", SqlDbType.Decimal,9),
					new SqlParameter("@OfferHelpTimes", SqlDbType.VarChar,100),
					new SqlParameter("@OfferHelpSwitch", SqlDbType.Bit,1),
					new SqlParameter("@GetHelpMin", SqlDbType.Decimal,9),
					new SqlParameter("@GetHelpMax", SqlDbType.Decimal,9),
					new SqlParameter("@GetHelpBase", SqlDbType.Decimal,9),
                    new SqlParameter("@GetHelpRangeTimes", SqlDbType.Int,4),
					new SqlParameter("@GetHelpRangeCount", SqlDbType.Int,4),
					new SqlParameter("@GetHelpNeedComplete", SqlDbType.Bit,1),
					new SqlParameter("@GetHelpDayTotalMoney", SqlDbType.Decimal,9),
					new SqlParameter("@GetHelpTimes", SqlDbType.VarChar,100),
					new SqlParameter("@GetHelpSwitch", SqlDbType.Bit,1),
					new SqlParameter("@LineTimes", SqlDbType.Int,4),
					new SqlParameter("@FreezeTimes", SqlDbType.Int,4),
					new SqlParameter("@OutTimes", SqlDbType.Int,4),
					new SqlParameter("@InterestPer", SqlDbType.Decimal,9),
					new SqlParameter("@LiXi1", SqlDbType.Decimal,9),
					new SqlParameter("@LiXi2", SqlDbType.Decimal,9),
					new SqlParameter("@PayLimitTimes", SqlDbType.Int,4),
					new SqlParameter("@ConfirmLimitTimes", SqlDbType.Int,4),
					new SqlParameter("@OfferHelpFloat", SqlDbType.Decimal,9),
					new SqlParameter("@GetHelpFloat", SqlDbType.Decimal,9),
					new SqlParameter("@NoLineTimesMoneyFloat", SqlDbType.Decimal,9),
					new SqlParameter("@HonestTimes", SqlDbType.Int,4),
					new SqlParameter("@HonestFloat", SqlDbType.Decimal,9),
					new SqlParameter("@PayLimitTimesPre", SqlDbType.Int,4),
					new SqlParameter("@ConfirmLimitTimesPre", SqlDbType.Int,4),
					new SqlParameter("@LastProportion", SqlDbType.Decimal,9),
					new SqlParameter("@OfferTJKF", SqlDbType.Decimal,9),
					new SqlParameter("@GetTJKF", SqlDbType.Decimal,9),
					new SqlParameter("@ReleasePer", SqlDbType.Decimal,9),
					new SqlParameter("@ReleaseConditionCount", SqlDbType.Int,4),
					new SqlParameter("@GLRewardFreezeTimes", SqlDbType.Int,4),
					new SqlParameter("@MacthTimesRange", SqlDbType.VarChar,100),
					new SqlParameter("@MacthSwitch", SqlDbType.Bit,1),
					new SqlParameter("@MHBBase", SqlDbType.Int,4),
					new SqlParameter("@MHBRangeTimes", SqlDbType.Int,4),
					new SqlParameter("@MCWBase", SqlDbType.Int,4),
					new SqlParameter("@MCWRangeTimes", SqlDbType.Int,4),
					new SqlParameter("@MJBBase", SqlDbType.Int,4),
					new SqlParameter("@MJBRangeTimes", SqlDbType.Int,4),
					new SqlParameter("@FreezeTimesOfRegister", SqlDbType.Int,4),
					new SqlParameter("@FreezeTimesOfOffer", SqlDbType.Int,4)};
            parameters[0].Value = model.ActiveCodePrice;
            parameters[1].Value = model.MCWPrice;
            parameters[2].Value = model.MOfferNeedMCW;
            parameters[3].Value = model.OfferHelpMin;
            parameters[4].Value = model.OfferHelpMax;
            parameters[5].Value = model.OfferHelpBase;
            parameters[6].Value = model.OfferHelpRangeTimes;
            parameters[7].Value = model.OfferHelpRangeCount;
            parameters[8].Value = model.OfferHelpNeedComplete;
            parameters[9].Value = model.OfferHelpDayTotalMoney;
            parameters[10].Value = model.OfferHelpTimes;
            parameters[11].Value = model.OfferHelpSwitch;
            parameters[12].Value = model.GetHelpMin;
            parameters[13].Value = model.GetHelpMax;
            parameters[14].Value = model.GetHelpBase;
            parameters[15].Value = model.GetHelpRangeTimes;
            parameters[16].Value = model.GetHelpRangeCount;
            parameters[17].Value = model.GetHelpNeedComplete;
            parameters[18].Value = model.GetHelpDayTotalMoney;
            parameters[19].Value = model.GetHelpTimes;
            parameters[20].Value = model.GetHelpSwitch;
            parameters[21].Value = model.LineTimes;
            parameters[22].Value = model.FreezeTimes;
            parameters[23].Value = model.OutTimes;
            parameters[24].Value = model.InterestPer;
            parameters[25].Value = model.LiXi1;
            parameters[26].Value = model.LiXi2;
            parameters[27].Value = model.PayLimitTimes;
            parameters[28].Value = model.ConfirmLimitTimes;
            parameters[29].Value = model.OfferHelpFloat;
            parameters[30].Value = model.GetHelpFloat;
            parameters[31].Value = model.NoLineTimesMoneyFloat;
            parameters[32].Value = model.HonestTimes;
            parameters[33].Value = model.HonestFloat;
            parameters[34].Value = model.PayLimitTimesPre;
            parameters[35].Value = model.ConfirmLimitTimesPre;
            parameters[36].Value = model.LastProportion;
            parameters[37].Value = model.OfferTJKF;
            parameters[38].Value = model.GetTJKF;
            parameters[39].Value = model.ReleasePer;
            parameters[40].Value = model.ReleaseConditionCount;
            parameters[41].Value = model.GLRewardFreezeTimes;
            parameters[42].Value = model.MacthTimesRange;
            parameters[43].Value = model.MacthSwitch;
            parameters[44].Value = model.MHBBase;
            parameters[45].Value = model.MHBRangeTimes;
            parameters[46].Value = model.MCWBase;
            parameters[47].Value = model.MCWRangeTimes;
            parameters[48].Value = model.MJBBase;
            parameters[49].Value = model.MJBRangeTimes;
            parameters[50].Value = model.FreezeTimesOfRegister;
            parameters[51].Value = model.FreezeTimesOfOffer;

            string guid = Guid.NewGuid().ToString();
            strSql.AppendFormat(" ;select '{0}'", guid);
            MyHs.Add(strSql.ToString(), parameters);
            DAL.MMMConfig.TModel = null;
            return MyHs;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(Model.MMMConfig model)
        {
            return DAL.CommonBase.RunHashtable(Update(model, new Hashtable()));
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static Hashtable Delete(object obj, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from MMMConfig ");
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
            strSql.Append(" FROM MMMConfig ");
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
            strSql.Append(" FROM MMMConfig ");
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
            return DAL.CommonBase.GetTable("MMMConfig", "", " ", strWhere, pageIndex, pageSize, out count);
        }


        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<Model.MMMConfig> GetList(string strWhere)
        {
            List<Model.MMMConfig> list = new List<Model.MMMConfig>();

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
        public static List<Model.MMMConfig> GetList(int top, string strWhere)
        {
            List<Model.MMMConfig> list = new List<Model.MMMConfig>();
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
        public static List<Model.MMMConfig> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.MMMConfig> list = new List<Model.MMMConfig>();

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
        private static Model.MMMConfig TranEntity(DataRow row)
        {
            if (row != null)
            {
                Model.MMMConfig model = new Model.MMMConfig();

                if (row["ActiveCodePrice"] != null && row["ActiveCodePrice"].ToString() != "")
                {
                    model.ActiveCodePrice = decimal.Parse(row["ActiveCodePrice"].ToString());
                }
                if (row["MCWPrice"] != null && row["MCWPrice"].ToString() != "")
                {
                    model.MCWPrice = decimal.Parse(row["MCWPrice"].ToString());
                }
                if (row["MOfferNeedMCW"] != null && row["MOfferNeedMCW"].ToString() != "")
                {
                    model.MOfferNeedMCW = decimal.Parse(row["MOfferNeedMCW"].ToString());
                }
                if (row["OfferHelpMin"] != null && row["OfferHelpMin"].ToString() != "")
                {
                    model.OfferHelpMin = decimal.Parse(row["OfferHelpMin"].ToString());
                }
                if (row["OfferHelpMax"] != null && row["OfferHelpMax"].ToString() != "")
                {
                    model.OfferHelpMax = decimal.Parse(row["OfferHelpMax"].ToString());
                }
                if (row["OfferHelpBase"] != null && row["OfferHelpBase"].ToString() != "")
                {
                    model.OfferHelpBase = decimal.Parse(row["OfferHelpBase"].ToString());
                }
                if (row["OfferHelpRangeTimes"] != null && row["OfferHelpRangeTimes"].ToString() != "")
                {
                    model.OfferHelpRangeTimes = int.Parse(row["OfferHelpRangeTimes"].ToString());
                }
                if (row["OfferHelpRangeCount"] != null && row["OfferHelpRangeCount"].ToString() != "")
                {
                    model.OfferHelpRangeCount = int.Parse(row["OfferHelpRangeCount"].ToString());
                }
                if (row["OfferHelpNeedComplete"] != null && row["OfferHelpNeedComplete"].ToString() != "")
                {
                    if ((row["OfferHelpNeedComplete"].ToString() == "1") || (row["OfferHelpNeedComplete"].ToString().ToLower() == "true"))
                    {
                        model.OfferHelpNeedComplete = true;
                    }
                    else
                    {
                        model.OfferHelpNeedComplete = false;
                    }
                }
                if (row["OfferHelpDayTotalMoney"] != null && row["OfferHelpDayTotalMoney"].ToString() != "")
                {
                    model.OfferHelpDayTotalMoney = decimal.Parse(row["OfferHelpDayTotalMoney"].ToString());
                }
                if (row["OfferHelpTimes"] != null)
                {
                    model.OfferHelpTimes = row["OfferHelpTimes"].ToString();
                }
                if (row["OfferHelpSwitch"] != null && row["OfferHelpSwitch"].ToString() != "")
                {
                    if ((row["OfferHelpSwitch"].ToString() == "1") || (row["OfferHelpSwitch"].ToString().ToLower() == "true"))
                    {
                        model.OfferHelpSwitch = true;
                    }
                    else
                    {
                        model.OfferHelpSwitch = false;
                    }
                }
                if (row["GetHelpMin"] != null && row["GetHelpMin"].ToString() != "")
                {
                    model.GetHelpMin = decimal.Parse(row["GetHelpMin"].ToString());
                }
                if (row["GetHelpMax"] != null && row["GetHelpMax"].ToString() != "")
                {
                    model.GetHelpMax = decimal.Parse(row["GetHelpMax"].ToString());
                }
                if (row["GetHelpBase"] != null && row["GetHelpBase"].ToString() != "")
                {
                    model.GetHelpBase = decimal.Parse(row["GetHelpBase"].ToString());
                }
                if (row["GetHelpRangeTimes"] != null && row["GetHelpRangeTimes"].ToString() != "")
                {
                    model.GetHelpRangeTimes = int.Parse(row["GetHelpRangeTimes"].ToString());
                }
                if (row["GetHelpRangeCount"] != null && row["GetHelpRangeCount"].ToString() != "")
                {
                    model.GetHelpRangeCount = int.Parse(row["GetHelpRangeCount"].ToString());
                }
                if (row["GetHelpNeedComplete"] != null && row["GetHelpNeedComplete"].ToString() != "")
                {
                    if ((row["GetHelpNeedComplete"].ToString() == "1") || (row["GetHelpNeedComplete"].ToString().ToLower() == "true"))
                    {
                        model.GetHelpNeedComplete = true;
                    }
                    else
                    {
                        model.GetHelpNeedComplete = false;
                    }
                }
                if (row["GetHelpDayTotalMoney"] != null && row["GetHelpDayTotalMoney"].ToString() != "")
                {
                    model.GetHelpDayTotalMoney = decimal.Parse(row["GetHelpDayTotalMoney"].ToString());
                }
                if (row["GetHelpTimes"] != null)
                {
                    model.GetHelpTimes = row["GetHelpTimes"].ToString();
                }
                if (row["GetHelpSwitch"] != null && row["GetHelpSwitch"].ToString() != "")
                {
                    if ((row["GetHelpSwitch"].ToString() == "1") || (row["GetHelpSwitch"].ToString().ToLower() == "true"))
                    {
                        model.GetHelpSwitch = true;
                    }
                    else
                    {
                        model.GetHelpSwitch = false;
                    }
                }
                if (row["LineTimes"] != null && row["LineTimes"].ToString() != "")
                {
                    model.LineTimes = int.Parse(row["LineTimes"].ToString());
                }
                if (row["FreezeTimes"] != null && row["FreezeTimes"].ToString() != "")
                {
                    model.FreezeTimes = int.Parse(row["FreezeTimes"].ToString());
                }
                if (row["OutTimes"] != null && row["OutTimes"].ToString() != "")
                {
                    model.OutTimes = int.Parse(row["OutTimes"].ToString());
                }
                if (row["InterestPer"] != null && row["InterestPer"].ToString() != "")
                {
                    model.InterestPer = decimal.Parse(row["InterestPer"].ToString());
                }
                if (row["LiXi1"] != null && row["LiXi1"].ToString() != "")
                {
                    model.LiXi1 = decimal.Parse(row["LiXi1"].ToString());
                }
                if (row["LiXi2"] != null && row["LiXi2"].ToString() != "")
                {
                    model.LiXi2 = decimal.Parse(row["LiXi2"].ToString());
                }
                if (row["PayLimitTimes"] != null && row["PayLimitTimes"].ToString() != "")
                {
                    model.PayLimitTimes = int.Parse(row["PayLimitTimes"].ToString());
                }
                if (row["ConfirmLimitTimes"] != null && row["ConfirmLimitTimes"].ToString() != "")
                {
                    model.ConfirmLimitTimes = int.Parse(row["ConfirmLimitTimes"].ToString());
                }
                if (row["OfferHelpFloat"] != null && row["OfferHelpFloat"].ToString() != "")
                {
                    model.OfferHelpFloat = decimal.Parse(row["OfferHelpFloat"].ToString());
                }
                if (row["GetHelpFloat"] != null && row["GetHelpFloat"].ToString() != "")
                {
                    model.GetHelpFloat = decimal.Parse(row["GetHelpFloat"].ToString());
                }
                if (row["NoLineTimesMoneyFloat"] != null && row["NoLineTimesMoneyFloat"].ToString() != "")
                {
                    model.NoLineTimesMoneyFloat = decimal.Parse(row["NoLineTimesMoneyFloat"].ToString());
                }
                if (row["HonestTimes"] != null && row["HonestTimes"].ToString() != "")
                {
                    model.HonestTimes = int.Parse(row["HonestTimes"].ToString());
                }
                if (row["HonestFloat"] != null && row["HonestFloat"].ToString() != "")
                {
                    model.HonestFloat = decimal.Parse(row["HonestFloat"].ToString());
                }
                if (row["PayLimitTimesPre"] != null && row["PayLimitTimesPre"].ToString() != "")
                {
                    model.PayLimitTimesPre = int.Parse(row["PayLimitTimesPre"].ToString());
                }
                if (row["ConfirmLimitTimesPre"] != null && row["ConfirmLimitTimesPre"].ToString() != "")
                {
                    model.ConfirmLimitTimesPre = int.Parse(row["ConfirmLimitTimesPre"].ToString());
                }
                if (row["LastProportion"] != null && row["LastProportion"].ToString() != "")
                {
                    model.LastProportion = decimal.Parse(row["LastProportion"].ToString());
                }
                if (row["OfferTJKF"] != null && row["OfferTJKF"].ToString() != "")
                {
                    model.OfferTJKF = decimal.Parse(row["OfferTJKF"].ToString());
                }
                if (row["GetTJKF"] != null && row["GetTJKF"].ToString() != "")
                {
                    model.GetTJKF = decimal.Parse(row["GetTJKF"].ToString());
                }
                if (row["ReleasePer"] != null && row["ReleasePer"].ToString() != "")
                {
                    model.ReleasePer = decimal.Parse(row["ReleasePer"].ToString());
                }
                if (row["ReleaseConditionCount"] != null && row["ReleaseConditionCount"].ToString() != "")
                {
                    model.ReleaseConditionCount = int.Parse(row["ReleaseConditionCount"].ToString());
                }
                if (row["GLRewardFreezeTimes"] != null && row["GLRewardFreezeTimes"].ToString() != "")
                {
                    model.GLRewardFreezeTimes = int.Parse(row["GLRewardFreezeTimes"].ToString());
                }
                if (row["MacthTimesRange"] != null)
                {
                    model.MacthTimesRange = row["MacthTimesRange"].ToString();
                }
                if (row["MacthSwitch"] != null && row["MacthSwitch"].ToString() != "")
                {
                    if ((row["MacthSwitch"].ToString() == "1") || (row["MacthSwitch"].ToString().ToLower() == "true"))
                    {
                        model.MacthSwitch = true;
                    }
                    else
                    {
                        model.MacthSwitch = false;
                    }
                }
                if (row["MHBBase"] != null && row["MHBBase"].ToString() != "")
                {
                    model.MHBBase = int.Parse(row["MHBBase"].ToString());
                }
                if (row["MHBRangeTimes"] != null && row["MHBRangeTimes"].ToString() != "")
                {
                    model.MHBRangeTimes = int.Parse(row["MHBRangeTimes"].ToString());
                }
                if (row["MCWBase"] != null && row["MCWBase"].ToString() != "")
                {
                    model.MCWBase = int.Parse(row["MCWBase"].ToString());
                }
                if (row["MCWRangeTimes"] != null && row["MCWRangeTimes"].ToString() != "")
                {
                    model.MCWRangeTimes = int.Parse(row["MCWRangeTimes"].ToString());
                }
                if (row["MJBBase"] != null && row["MJBBase"].ToString() != "")
                {
                    model.MJBBase = int.Parse(row["MJBBase"].ToString());
                }
                if (row["MJBRangeTimes"] != null && row["MJBRangeTimes"].ToString() != "")
                {
                    model.MJBRangeTimes = int.Parse(row["MJBRangeTimes"].ToString());
                }
                if (row["FreezeTimesOfRegister"] != null && row["FreezeTimesOfRegister"].ToString() != "")
                {
                    model.FreezeTimesOfRegister = int.Parse(row["FreezeTimesOfRegister"].ToString());
                }
                if (row["FreezeTimesOfOffer"] != null && row["FreezeTimesOfOffer"].ToString() != "")
                {
                    model.FreezeTimesOfOffer = int.Parse(row["FreezeTimesOfOffer"].ToString());
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
