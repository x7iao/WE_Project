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
    //MHelpMatch
    public class MHelpMatch
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.MHelpMatch GetModel(object Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from MHelpMatch ");
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
        /// 得到一个对象实体
        /// </summary>
        public static Model.MHelpMatch GetModelByCode(object MatchCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from MHelpMatch ");
            strSql.Append(" where MatchCode=@MatchCode");
            SqlParameter[] parameters = {
					new SqlParameter("@MatchCode", SqlDbType.VarChar,50)
			};
            parameters[0].Value = MatchCode;


            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return TranEntity(ds.Tables[0].Rows[0]);
            else
                return null;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static Hashtable Insert(Model.MHelpMatch model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into MHelpMatch(");
            strSql.Append("Remark,OfferMID,GetMID,MatchCode,OfferId,GetId,MatchTime,PayTime,ConfirmTime,MatchState,PicUrl,MatchMoney,PicUrl1,PicUrl2,ChangeCount,ChangeMTJTime,ChangeVIPTime,PicUrl3,MatchType,OfferPJ,GetPJ");
            strSql.Append(") values (");
            strSql.Append("@Remark,@OfferMID,@GetMID,@MatchCode,@OfferId,@GetId,@MatchTime,@PayTime,@ConfirmTime,@MatchState,@PicUrl,@MatchMoney,@PicUrl1,@PicUrl2,@ChangeCount,@ChangeMTJTime,@ChangeVIPTime,@PicUrl3,@MatchType,@OfferPJ,@GetPJ");
            strSql.Append(") ");
            strSql.AppendFormat(";select '{0}'", guid);
            SqlParameter[] parameters = {
			            new SqlParameter("@Remark", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@OfferMID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GetMID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@MatchCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@OfferId", SqlDbType.Int,4) ,            
                        new SqlParameter("@GetId", SqlDbType.Int,4) ,            
                        new SqlParameter("@MatchTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@PayTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ConfirmTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@MatchState", SqlDbType.Int,4) ,            
                        new SqlParameter("@PicUrl", SqlDbType.VarChar,500) ,
                        new SqlParameter("@MatchMoney", SqlDbType.Decimal,9),
                        new SqlParameter("@PicUrl1", SqlDbType.VarChar,500) ,
                        new SqlParameter("@PicUrl2", SqlDbType.VarChar,500),
                        new SqlParameter("@ChangeCount", SqlDbType.Int,4) , 
                        new SqlParameter("@ChangeMTJTime", SqlDbType.DateTime) , 
                        new SqlParameter("@ChangeVIPTime", SqlDbType.DateTime) ,
                        new SqlParameter("@PicUrl3", SqlDbType.VarChar,500) ,
                        new SqlParameter("@MatchType", SqlDbType.Int,4),
                        new SqlParameter("@OfferPJ", SqlDbType.Int,4),
                        new SqlParameter("@GetPJ", SqlDbType.Int,4)
            };

            parameters[0].Value = model.Remark;
            parameters[1].Value = model.OfferMID;
            parameters[2].Value = model.GetMID;
            parameters[3].Value = model.MatchCode;
            parameters[4].Value = model.OfferId;
            parameters[5].Value = model.GetId;
            parameters[6].Value = model.MatchTime;
            parameters[7].Value = model.PayTime;
            parameters[8].Value = model.ConfirmTime;
            parameters[9].Value = model.MatchState;
            parameters[10].Value = model.PicUrl;
            parameters[11].Value = model.MatchMoney;
            parameters[12].Value = model.PicUrl1;
            parameters[13].Value = model.PicUrl2;
            parameters[14].Value = model.ChangeCount;
            parameters[15].Value = model.ChangeMTJTime;
            parameters[16].Value = model.ChangeVIPTime;
            parameters[17].Value = model.PicUrl3;
            parameters[18].Value = model.MatchType;

            parameters[19].Value = model.OfferPJ;
            parameters[20].Value = model.GetPJ;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Insert(Model.MHelpMatch model)
        {
            return DAL.CommonBase.RunHashtable(Insert(model, new Hashtable()));
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(Model.MHelpMatch model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update MHelpMatch set ");

            strSql.Append(" Remark = @Remark , ");
            strSql.Append(" OfferMID = @OfferMID , ");
            strSql.Append(" GetMID = @GetMID , ");
            strSql.Append(" MatchCode = @MatchCode , ");
            strSql.Append(" OfferId = @OfferId , ");
            strSql.Append(" GetId = @GetId , ");
            strSql.Append(" MatchTime = @MatchTime , ");
            strSql.Append(" PayTime = @PayTime , ");
            strSql.Append(" ConfirmTime = @ConfirmTime , ");
            strSql.Append(" MatchState = @MatchState , ");
            strSql.Append(" PicUrl = @PicUrl,  ");
            strSql.Append(" MatchMoney = @MatchMoney,  ");
            strSql.Append(" PicUrl1 = @PicUrl1,  ");
            strSql.Append(" PicUrl2 = @PicUrl2,  ");
            strSql.Append(" PicUrl3 = @PicUrl3,  ");
            strSql.Append(" ChangeCount = @ChangeCount,  ");
            strSql.Append(" ChangeMTJTime = @ChangeMTJTime,  ");
            strSql.Append(" MatchType = @MatchType,  ");
            strSql.Append(" ChangeVIPTime = @ChangeVIPTime,  ");
            strSql.Append(" OfferPJ = @OfferPJ,  ");
            strSql.Append(" GetPJ = @GetPJ  ");
            strSql.Append(" where Id=@Id ");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@OfferMID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@GetMID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@MatchCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@OfferId", SqlDbType.Int,4) ,            
                        new SqlParameter("@GetId", SqlDbType.Int,4) ,            
                        new SqlParameter("@MatchTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@PayTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@ConfirmTime", SqlDbType.DateTime) ,            
                        new SqlParameter("@MatchState", SqlDbType.Int,4) ,            
                        new SqlParameter("@PicUrl", SqlDbType.VarChar,500) ,
                        new SqlParameter("@MatchMoney", SqlDbType.Decimal,9),
                        new SqlParameter("@PicUrl1", SqlDbType.VarChar,500) ,
                        new SqlParameter("@PicUrl2", SqlDbType.VarChar,500),
                        new SqlParameter("@ChangeCount", SqlDbType.Int,4) , 
                        new SqlParameter("@ChangeMTJTime", SqlDbType.DateTime) , 
                        new SqlParameter("@ChangeVIPTime", SqlDbType.DateTime)  ,
                        new SqlParameter("@PicUrl3", SqlDbType.VarChar,500) ,
                        new SqlParameter("@MatchType", SqlDbType.Int,4) ,
                         new SqlParameter("@OfferPJ", SqlDbType.Int,4),
                        new SqlParameter("@GetPJ", SqlDbType.Int,4)
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.Remark;
            parameters[2].Value = model.OfferMID;
            parameters[3].Value = model.GetMID;
            parameters[4].Value = model.MatchCode;
            parameters[5].Value = model.OfferId;
            parameters[6].Value = model.GetId;
            parameters[7].Value = model.MatchTime;
            parameters[8].Value = model.PayTime;
            parameters[9].Value = model.ConfirmTime;
            parameters[10].Value = model.MatchState;
            parameters[11].Value = model.PicUrl;
            parameters[12].Value = model.MatchMoney;
            parameters[13].Value = model.PicUrl1;
            parameters[14].Value = model.PicUrl2;
            parameters[15].Value = model.ChangeCount;
            parameters[16].Value = model.ChangeMTJTime;
            parameters[17].Value = model.ChangeVIPTime;
            parameters[18].Value = model.PicUrl3;
            parameters[19].Value = model.MatchType;
            parameters[20].Value = model.OfferPJ;
            parameters[21].Value = model.GetPJ;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(Model.MHelpMatch model)
        {
            return DAL.CommonBase.RunHashtable(Update(model, new Hashtable()));
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static Hashtable Delete(object obj, Hashtable MyHs)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from MHelpMatch ");
            strSql.AppendFormat(" where Id in ({0})", obj);

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
            strSql.Append(" FROM MHelpMatch ");
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
            strSql.Append(" FROM MHelpMatch ");
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
            return DAL.CommonBase.GetTable("MHelpMatch", "Id", "Id desc", strWhere, pageIndex, pageSize, out count);
        }


        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<Model.MHelpMatch> GetList(string strWhere)
        {
            List<Model.MHelpMatch> list = new List<Model.MHelpMatch>();

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
        public static List<Model.MHelpMatch> GetList(int top, string strWhere)
        {
            List<Model.MHelpMatch> list = new List<Model.MHelpMatch>();

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
        public static List<Model.MHelpMatch> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.MHelpMatch> list = new List<Model.MHelpMatch>();

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
        private static Model.MHelpMatch TranEntity(DataRow dr)
        {
            if (dr != null)
            {
                Model.MHelpMatch model = new Model.MHelpMatch();

                if (!string.IsNullOrEmpty(dr["Id"].ToString()))
                {
                    model.Id = int.Parse(dr["Id"].ToString());
                }
                model.Remark = dr["Remark"].ToString();
                model.OfferMID = dr["OfferMID"].ToString();
                model.GetMID = dr["GetMID"].ToString();
                model.MatchCode = dr["MatchCode"].ToString();
                if (!string.IsNullOrEmpty(dr["OfferId"].ToString()))
                {
                    model.OfferId = int.Parse(dr["OfferId"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["GetId"].ToString()))
                {
                    model.GetId = int.Parse(dr["GetId"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["MatchTime"].ToString()))
                {
                    model.MatchTime = DateTime.Parse(dr["MatchTime"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["PayTime"].ToString()))
                {
                    model.PayTime = DateTime.Parse(dr["PayTime"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["ConfirmTime"].ToString()))
                {
                    model.ConfirmTime = DateTime.Parse(dr["ConfirmTime"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["MatchState"].ToString()))
                {
                    model.MatchState = int.Parse(dr["MatchState"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["MatchType"].ToString()))
                {
                    model.MatchType = int.Parse(dr["MatchType"].ToString());
                }
                model.PicUrl = dr["PicUrl"].ToString();
                model.PicUrl1 = dr["PicUrl1"].ToString();
                model.PicUrl2 = dr["PicUrl2"].ToString();
                model.PicUrl3 = dr["PicUrl3"].ToString();

                if (!string.IsNullOrEmpty(dr["MatchMoney"].ToString()))
                {
                    model.MatchMoney = decimal.Parse(dr["MatchMoney"].ToString());
                }

                if (!string.IsNullOrEmpty(dr["ChangeCount"].ToString()))
                {
                    model.ChangeCount = int.Parse(dr["ChangeCount"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["ChangeMTJTime"].ToString()))
                {
                    model.ChangeMTJTime = DateTime.Parse(dr["ChangeMTJTime"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["ChangeVIPTime"].ToString()))
                {
                    model.ChangeVIPTime = DateTime.Parse(dr["ChangeVIPTime"].ToString());
                }

                if (!string.IsNullOrEmpty(dr["OfferPJ"].ToString()))
                {
                    model.OfferPJ = int.Parse(dr["OfferPJ"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["GetPJ"].ToString()))
                {
                    model.GetPJ = int.Parse(dr["GetPJ"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        public static decimal GetSumMoney(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SUM(MatchMoney) ");
            strSql.Append(" FROM MHelpMatch ");
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
    }
}
