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
    //MOfferHelp
    public class MOfferHelp
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.MOfferHelp GetModel(object Id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append("  from MOfferHelp ");
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
        public static Hashtable Insert(Model.MOfferHelp model, Hashtable MyHs)
        {
            ////计算利息
            //var dic = DAL.ConfigDictionary.GetConfigDictionary((int)model.SQMoney, "LiXi", "");
            //if (dic != null)
            //{
            //    model.DayInterest = Convert.ToDecimal(dic.DValue);
            //}
            model.SQCode = Guid.NewGuid().ToString().Replace("-", "").Replace(" ", "").ToUpper().Substring(0, 15);
            //校验编号是否重复，重复的话重新生成
            while (CommonBase.GetSingle("select SQCode from MOfferHelp where SQCode='" + model.SQCode + "'") != null)
            {
                model.SQCode = Guid.NewGuid().ToString().Replace("-", "").Replace(" ", "").ToUpper().Substring(0, 15);
            }

            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into MOfferHelp(");
            strSql.Append("TotalInterest,TotalInterestDays,TotalSincerity,TotalSincerityDays,SincerityState,InterestState,SQCode,SQMID,SQMoney,SQDate,PPState,DKState,MFLMoney,Remark,MatchMoney,dayInterest,HelpType,MoneyType");
            strSql.Append(") values (");
            strSql.Append("@TotalInterest,@TotalInterestDays,@TotalSincerity,@TotalSincerityDays,@SincerityState,@InterestState,@SQCode,@SQMID,@SQMoney,@SQDate,@PPState,@DKState,@MFLMoney,@Remark,@MatchMoney,@dayInterest,@HelpType,@MoneyType");
            strSql.Append(") ");
            strSql.AppendFormat(";select '{0}'", guid);
            SqlParameter[] parameters = {
			            new SqlParameter("@TotalInterest", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TotalInterestDays", SqlDbType.Int,4) ,            
                        new SqlParameter("@TotalSincerity", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TotalSincerityDays", SqlDbType.Int,4) ,            
                        new SqlParameter("@SincerityState", SqlDbType.Int,4) ,            
                        new SqlParameter("@InterestState", SqlDbType.Int,4) ,            
                        new SqlParameter("@SQCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SQMID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SQMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@SQDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@PPState", SqlDbType.Int,4) ,            
                        new SqlParameter("@DKState", SqlDbType.Int,4) ,            
                        new SqlParameter("@MFLMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,500),
                        new SqlParameter("@MatchMoney", SqlDbType.Decimal,9),
                        new SqlParameter("@dayInterest", SqlDbType.Decimal,9),
                        new SqlParameter("@HelpType", SqlDbType.Int,4),
                        new SqlParameter("@MoneyType", SqlDbType.VarChar,50)
            };

            parameters[0].Value = model.TotalInterest;
            parameters[1].Value = model.TotalInterestDays;
            parameters[2].Value = model.TotalSincerity;
            parameters[3].Value = model.TotalSincerityDays;
            parameters[4].Value = model.SincerityState;
            parameters[5].Value = model.InterestState;
            parameters[6].Value = model.SQCode;
            parameters[7].Value = model.SQMID;
            parameters[8].Value = model.SQMoney;
            parameters[9].Value = model.SQDate;
            parameters[10].Value = model.PPState;
            parameters[11].Value = model.DKState;
            parameters[12].Value = model.MFLMoney;
            parameters[13].Value = model.Remark;
            parameters[14].Value = model.MatchMoney;
            parameters[15].Value = model.DayInterest;
            parameters[16].Value = model.HelpType;
            parameters[17].Value = model.MoneyType;

            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Insert(Model.MOfferHelp model)
        {
            return DAL.CommonBase.RunHashtable(Insert(model, new Hashtable()));
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(Model.MOfferHelp model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update MOfferHelp set ");

            strSql.Append(" TotalInterest = @TotalInterest , ");
            strSql.Append(" TotalInterestDays = @TotalInterestDays , ");
            strSql.Append(" TotalSincerity = @TotalSincerity , ");
            strSql.Append(" TotalSincerityDays = @TotalSincerityDays , ");
            strSql.Append(" SincerityState = @SincerityState , ");
            strSql.Append(" InterestState = @InterestState , ");
            strSql.Append(" SQCode = @SQCode , ");
            strSql.Append(" SQMID = @SQMID , ");
            strSql.Append(" SQMoney = @SQMoney , ");
            strSql.Append(" SQDate = @SQDate , ");
            strSql.Append(" PPState = @PPState , ");
            strSql.Append(" DKState = @DKState , ");
            strSql.Append(" MFLMoney = @MFLMoney , ");
            strSql.Append(" Remark = @Remark,  ");
            strSql.Append(" MatchMoney = @MatchMoney,");
            strSql.Append(" dayInterest = @dayInterest,");
            strSql.Append(" HelpType = @HelpType,");
            strSql.Append(" MoneyType = @MoneyType,");
            strSql.Append(" CompleteTime = @CompleteTime ");
            strSql.Append(" where Id=@Id ");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@TotalInterest", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TotalInterestDays", SqlDbType.Int,4) ,            
                        new SqlParameter("@TotalSincerity", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@TotalSincerityDays", SqlDbType.Int,4) ,            
                        new SqlParameter("@SincerityState", SqlDbType.Int,4) ,            
                        new SqlParameter("@InterestState", SqlDbType.Int,4) ,            
                        new SqlParameter("@SQCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SQMID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SQMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@SQDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@PPState", SqlDbType.Int,4) ,            
                        new SqlParameter("@DKState", SqlDbType.Int,4) ,            
                        new SqlParameter("@MFLMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,500) ,
                        new SqlParameter("@MatchMoney", SqlDbType.Decimal,9),
                        new SqlParameter("@CompleteTime", SqlDbType.DateTime) ,
                        new SqlParameter("@dayInterest", SqlDbType.Decimal,9),
                        new SqlParameter("@HelpType", SqlDbType.Int,4),
                        new SqlParameter("@MoneyType", SqlDbType.VarChar,50)       
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.TotalInterest;
            parameters[2].Value = model.TotalInterestDays;
            parameters[3].Value = model.TotalSincerity;
            parameters[4].Value = model.TotalSincerityDays;
            parameters[5].Value = model.SincerityState;
            parameters[6].Value = model.InterestState;
            parameters[7].Value = model.SQCode;
            parameters[8].Value = model.SQMID;
            parameters[9].Value = model.SQMoney;
            parameters[10].Value = model.SQDate;
            parameters[11].Value = model.PPState;
            parameters[12].Value = model.DKState;
            parameters[13].Value = model.MFLMoney;
            parameters[14].Value = model.Remark;
            parameters[15].Value = model.MatchMoney;
            parameters[16].Value = model.CompleteTime;
            parameters[17].Value = model.DayInterest;
            parameters[18].Value = model.HelpType;
            parameters[19].Value = model.MoneyType;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(Model.MOfferHelp model)
        {
            return DAL.CommonBase.RunHashtable(Update(model, new Hashtable()));
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static Hashtable Delete(object obj, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from MOfferHelp ");
            strSql.AppendFormat(" where Id in ({0}) and PPState = 0 ", obj);

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
            strSql.Append(" FROM MOfferHelp ");
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
            strSql.Append(" FROM MOfferHelp ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        public static decimal GetSumMoney(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SUM(SQMoney) ");
            strSql.Append(" FROM MOfferHelp ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return Convert.ToDecimal(obj);
            }
            return 0;
        }

        public static int GetSumCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) ");
            strSql.Append(" FROM MOfferHelp ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            return 0;
        }

        public static decimal GetAllSumMoney(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SUM(SQMoney + TotalInterest + TotalSincerity) ");
            strSql.Append(" FROM MOfferHelp ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return Convert.ToDecimal(obj);
            }
            return 0;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.CommonBase.GetTable("MOfferHelp", "Id", "Id desc", strWhere, pageIndex, pageSize, out count);
        }

        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<Model.MOfferHelp> GetList(string strWhere)
        {
            List<Model.MOfferHelp> list = new List<Model.MOfferHelp>();

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
        public static List<Model.MOfferHelp> GetListJoin(string join)
        {
            List<Model.MOfferHelp> list = new List<Model.MOfferHelp>();

            DataTable table = DAL.CommonBase.GetTable("select * from MOfferHelp inner join MemberConfig mc on mc.MID=MOfferHelp.SQMID where " + join);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(TranEntity(table.Rows[i]));
            }

            return list;
        }

        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<Model.MOfferHelp> GetList(int top, string strWhere)
        {
            List<Model.MOfferHelp> list = new List<Model.MOfferHelp>();

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
        public static List<Model.MOfferHelp> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.MOfferHelp> list = new List<Model.MOfferHelp>();

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
        private static Model.MOfferHelp TranEntity(DataRow dr)
        {
            if (dr != null)
            {
                Model.MOfferHelp model = new Model.MOfferHelp();

                if (!string.IsNullOrEmpty(dr["Id"].ToString()))
                {
                    model.Id = int.Parse(dr["Id"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["TotalInterest"].ToString()))
                {
                    model.TotalInterest = decimal.Parse(dr["TotalInterest"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["TotalInterestDays"].ToString()))
                {
                    model.TotalInterestDays = int.Parse(dr["TotalInterestDays"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["TotalSincerity"].ToString()))
                {
                    model.TotalSincerity = decimal.Parse(dr["TotalSincerity"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["TotalSincerityDays"].ToString()))
                {
                    model.TotalSincerityDays = int.Parse(dr["TotalSincerityDays"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["SincerityState"].ToString()))
                {
                    model.SincerityState = int.Parse(dr["SincerityState"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["InterestState"].ToString()))
                {
                    model.InterestState = int.Parse(dr["InterestState"].ToString());
                }
                model.SQCode = dr["SQCode"].ToString();
                model.SQMID = dr["SQMID"].ToString();
                if (!string.IsNullOrEmpty(dr["SQMoney"].ToString()))
                {
                    model.SQMoney = decimal.Parse(dr["SQMoney"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["SQDate"].ToString()))
                {
                    model.SQDate = DateTime.Parse(dr["SQDate"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["PPState"].ToString()))
                {
                    model.PPState = int.Parse(dr["PPState"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["DKState"].ToString()))
                {
                    model.DKState = int.Parse(dr["DKState"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["MFLMoney"].ToString()))
                {
                    model.MFLMoney = decimal.Parse(dr["MFLMoney"].ToString());
                }
                model.Remark = dr["Remark"].ToString();
                if (!string.IsNullOrEmpty(dr["MatchMoney"].ToString()))
                {
                    model.MatchMoney = decimal.Parse(dr["MatchMoney"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["dayInterest"].ToString()))
                {
                    model.DayInterest = decimal.Parse(dr["dayInterest"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["CompleteTime"].ToString()))
                {
                    model.CompleteTime = DateTime.Parse(dr["CompleteTime"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["HelpType"].ToString()))
                {
                    model.HelpType = int.Parse(dr["HelpType"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["MoneyType"].ToString()))
                {
                    model.MoneyType = dr["MoneyType"].ToString();
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        public static decimal GetMaxOfferMoney(string mid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select ISNULL(MAX(SQMoney),0) ");
            strSql.Append(" FROM MOfferHelp ");
            strSql.Append(" where PPState > 2 and PPState <> 5 and SQMID = '" + mid + "' ");
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return Convert.ToDecimal(obj);
            }
            return 0;
        }

        public static Model.MOfferHelp GetQDOfferMoney(string mid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" select top 1 * from MOfferHelp where SQMID = '{0}' and HelpType = 0 and PPState < 4 and SincerityState = 1 and DATEDIFF(mi,SQDate,getdate()) < {1} ", mid, DAL.MMMConfig.TModel.FreezeTimes);

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return TranEntity(ds.Tables[0].Rows[0]);
            else
                return null;
        }

        public static Model.MOfferHelp GetLastQDOfferMoney(string mid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" select top 1 * from MOfferHelp where SQMID = '{0}' and HelpType = 0 and PPState < 3 ", mid);

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return TranEntity(ds.Tables[0].Rows[0]);
            else
                return null;
        }

        public static Model.MOfferHelp GetScrambleQDOfferMoney(string mid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" select top 1 * from MOfferHelp where SQMID = '{0}' and HelpType = 1 and PPState <= 3  and DATEDIFF(mi,SQDate,getdate()) < {1} ", mid, DAL.MMMConfigScramble.TModel.FreezeTimes);

            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return TranEntity(ds.Tables[0].Rows[0]);
            else
                return null;
        }
    }
}