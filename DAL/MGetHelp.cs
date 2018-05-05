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
    //MGetHelp
    public class MGetHelp
    {
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.MGetHelp GetModel(object Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select *  ");
            strSql.Append("  from MGetHelp ");
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
        public static Hashtable Insert(Model.MGetHelp model, Hashtable MyHs)
        {
            model.SQCode = Guid.NewGuid().ToString().Replace("-", "").Replace(" ", "").ToUpper().Substring(0, 15);
            //校验编号是否重复，重复的话重新生成
            while (CommonBase.GetSingle("select SQCode from MGetHelp where SQCode='" + model.SQCode + "'") != null)
            {
                model.SQCode = Guid.NewGuid().ToString().Replace("-", "").Replace(" ", "").ToUpper().Substring(0, 15);
            }
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into MGetHelp(");
            strSql.Append("SQMID,SQMoney,SQCode,SQDate,PPState,ConfirmState,MFLMoney,Remark,MatchMoney,HelpType,MoneyType,ComfirmDate");
            strSql.Append(") values (");
            strSql.Append("@SQMID,@SQMoney,@SQCode,@SQDate,@PPState,@ConfirmState,@MFLMoney,@Remark,@MatchMoney,@HelpType,@MoneyType,@ComfirmDate");
            strSql.Append(") ");
            strSql.AppendFormat(";select '{0}'", guid);
            SqlParameter[] parameters = {
			            new SqlParameter("@SQMID", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SQMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@SQCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SQDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@PPState", SqlDbType.Int,4) ,            
                        new SqlParameter("@ConfirmState", SqlDbType.Int,4) ,            
                        new SqlParameter("@MFLMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@MatchMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@HelpType", SqlDbType.Int,4)  ,            
                        new SqlParameter("@MoneyType", SqlDbType.VarChar,50),
                        new SqlParameter("@ComfirmDate", SqlDbType.DateTime)
              
            };

            parameters[0].Value = model.SQMID;
            parameters[1].Value = model.SQMoney;
            parameters[2].Value = model.SQCode;
            parameters[3].Value = model.SQDate;
            parameters[4].Value = model.PPState;
            parameters[5].Value = model.ConfirmState;
            parameters[6].Value = model.MFLMoney;
            parameters[7].Value = model.Remark;
            parameters[8].Value = model.MatchMoney;
            parameters[9].Value = model.HelpType;
            parameters[10].Value = model.MoneyType;
            parameters[11].Value = model.ComfirmDate;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Insert(Model.MGetHelp model)
        {
            return DAL.CommonBase.RunHashtable(Insert(model, new Hashtable()));
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(Model.MGetHelp model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update MGetHelp set ");

            strSql.Append(" SQMID = @SQMID , ");
            //strSql.Append(" SQMoney = @SQMoney , ");
            strSql.Append(" SQCode = @SQCode , ");
            strSql.Append(" SQDate = @SQDate , ");
            strSql.Append(" PPState = @PPState , ");
            strSql.Append(" ConfirmState = @ConfirmState , ");
            strSql.Append(" MFLMoney = @MFLMoney , ");
            strSql.Append(" MatchMoney = @MatchMoney , ");
            strSql.Append(" HelpType = @HelpType , ");
            strSql.Append(" MoneyType = @MoneyType , ");
            strSql.Append(" Remark = @Remark,  ");
            strSql.Append(" ComfirmDate = @ComfirmDate  ");
            strSql.Append(" where Id=@Id ");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
			            new SqlParameter("@Id", SqlDbType.Int,4) ,            
                        new SqlParameter("@SQMID", SqlDbType.VarChar,50) ,            
                        //new SqlParameter("@SQMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@SQCode", SqlDbType.VarChar,50) ,            
                        new SqlParameter("@SQDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@PPState", SqlDbType.Int,4) ,            
                        new SqlParameter("@ConfirmState", SqlDbType.Int,4) ,            
                        new SqlParameter("@MFLMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@Remark", SqlDbType.VarChar,500) ,            
                        new SqlParameter("@MatchMoney", SqlDbType.Decimal,9) ,            
                        new SqlParameter("@HelpType", SqlDbType.Int,4),            
                        new SqlParameter("@MoneyType", SqlDbType.VarChar,50),
                            new SqlParameter("@ComfirmDate", SqlDbType.DateTime)            
            };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.SQMID;
            //parameters[2].Value = model.SQMoney;
            parameters[2].Value = model.SQCode;
            parameters[3].Value = model.SQDate;
            parameters[4].Value = model.PPState;
            parameters[5].Value = model.ConfirmState;
            parameters[6].Value = model.MFLMoney;
            parameters[7].Value = model.Remark;
            parameters[8].Value = model.MatchMoney;
            parameters[9].Value = model.HelpType;
            parameters[10].Value = model.MoneyType;
            parameters[11].Value = model.ComfirmDate ;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(Model.MGetHelp model)
        {
            return DAL.CommonBase.RunHashtable(Update(model, new Hashtable()));
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static Hashtable Delete(object obj, Hashtable MyHs)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from MGetHelp ");
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
            strSql.Append(" FROM MGetHelp ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        public static DataTable GetTableJoinMember(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select t1.* ");
            strSql.Append(" FROM MGetHelp t1 left join MemberConfig t2 on t1.SQMID=t2.MID ");
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
            strSql.Append(" FROM MGetHelp ");
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
            return DAL.CommonBase.GetTable("MGetHelp", "Id", "Id desc", strWhere, pageIndex, pageSize, out count);
        }


        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<Model.MGetHelp> GetList(string strWhere)
        {
            List<Model.MGetHelp> list = new List<Model.MGetHelp>();

            DataTable table = GetTable(strWhere);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(TranEntity(table.Rows[i]));
            }

            return list;
        }
        public static List<Model.MGetHelp> GetListJoinMember(string strWhere)
        {
            List<Model.MGetHelp> list = new List<Model.MGetHelp>();

            DataTable table = GetTableJoinMember(strWhere);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(TranEntity(table.Rows[i]));
            }

            return list;
        }

        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<Model.MGetHelp> GetList(int top, string strWhere)
        {
            List<Model.MGetHelp> list = new List<Model.MGetHelp>();

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
        public static List<Model.MGetHelp> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.MGetHelp> list = new List<Model.MGetHelp>();

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
        private static Model.MGetHelp TranEntity(DataRow dr)
        {
            if (dr != null)
            {
                Model.MGetHelp model = new Model.MGetHelp();

                if (!string.IsNullOrEmpty(dr["Id"].ToString()))
                {
                    model.Id = int.Parse(dr["Id"].ToString());
                }
                model.SQMID = dr["SQMID"].ToString();
                if (!string.IsNullOrEmpty(dr["SQMoney"].ToString()))
                {
                    model.SQMoney = decimal.Parse(dr["SQMoney"].ToString());
                }
                model.SQCode = dr["SQCode"].ToString();
                if (!string.IsNullOrEmpty(dr["SQDate"].ToString()))
                {
                    model.SQDate = DateTime.Parse(dr["SQDate"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["PPState"].ToString()))
                {
                    model.PPState = int.Parse(dr["PPState"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["ConfirmState"].ToString()))
                {
                    model.ConfirmState = int.Parse(dr["ConfirmState"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["HelpType"].ToString()))
                {
                    model.HelpType = int.Parse(dr["HelpType"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["MFLMoney"].ToString()))
                {
                    model.MFLMoney = decimal.Parse(dr["MFLMoney"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["MatchMoney"].ToString()))
                {
                    model.MatchMoney = decimal.Parse(dr["MatchMoney"].ToString());
                }
                if (!string.IsNullOrEmpty(dr["MoneyType"].ToString()))
                {
                    model.MoneyType = dr["MoneyType"].ToString();
                }
                model.Remark = dr["Remark"].ToString();
                if (!string.IsNullOrEmpty(dr["ComfirmDate"].ToString()))
                {
                    model.ComfirmDate = DateTime.Parse(dr["ComfirmDate"].ToString());
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
            strSql.Append("select ISNULL(SUM(SQMoney),0) ");
            strSql.Append(" FROM MGetHelp ");
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
