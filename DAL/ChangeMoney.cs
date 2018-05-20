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
    public class ChangeMoney
    {

        #region 奖金事务操作
        /// <summary>
        /// 插入实体
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Hashtable InsertTran(Model.ChangeMoney model, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ChangeMoney(");
            strSql.Append("FromMID,ToMID,Money,ChangeDate,ChangeType,MoneyType,CState,SHMID,TakeOffMoney,ReBuyMoney,MCWMoney,CRemarks,CFileds,CFileds2,CompleteTime,OrderState)");
            strSql.Append(" values (");
            strSql.Append("@FromMID,@ToMID,@Money,@ChangeDate,@ChangeType,@MoneyType,@CState,@SHMID,@TakeOffMoney,@ReBuyMoney,@MCWMoney,@CRemarks,@CFileds,@CFileds2,@CompleteTime,@OrderState)");
            SqlParameter[] parameters = {
					new SqlParameter("@FromMID", SqlDbType.VarChar,20),
					new SqlParameter("@ToMID", SqlDbType.VarChar,20),
					new SqlParameter("@Money", SqlDbType.Decimal,9),
					new SqlParameter("@ChangeDate", SqlDbType.DateTime),
					new SqlParameter("@ChangeType", SqlDbType.VarChar,10),
					new SqlParameter("@MoneyType", SqlDbType.VarChar,10),
					new SqlParameter("@SHMID", SqlDbType.VarChar,20),
					new SqlParameter("@CState", SqlDbType.Bit,1),
					new SqlParameter("@TakeOffMoney", SqlDbType.Decimal,9),
					new SqlParameter("@ReBuyMoney", SqlDbType.Decimal,9),
					new SqlParameter("@MCWMoney", SqlDbType.Decimal,9),
					new SqlParameter("@CRemarks", SqlDbType.VarChar,200),
					new SqlParameter("@CFileds", SqlDbType.VarChar,50),
					new SqlParameter("@CFileds2", SqlDbType.VarChar,50),
                    new SqlParameter("@CompleteTime", SqlDbType.DateTime),
					new SqlParameter("@OrderState", SqlDbType.Int,4)
                                        };
            parameters[0].Value = model.FromMID;
            parameters[1].Value = model.ToMID;
            parameters[2].Value = model.Money;
            parameters[3].Value = model.ChangeDate;
            parameters[4].Value = model.ChangeType;
            parameters[5].Value = model.MoneyType;
            parameters[6].Value = model.SHMID;
            parameters[7].Value = model.CState;
            parameters[8].Value = model.TakeOffMoney;
            parameters[9].Value = model.ReBuyMoney;
            parameters[10].Value = model.MCWMoney;
            parameters[11].Value = model.CRemarks;
            parameters[12].Value = model.CFileds;
            parameters[13].Value = model.CFileds2;
            parameters[14].Value = model.CompleteTime;
            parameters[15].Value = model.OrderState;

            MyHs.Add(strSql, parameters);
            return MyHs;
        }


        /// <summary>
        /// 转移货币事物哈希表
        /// </summary>
        /// <param name="fromid">来自会员账号</param>
        /// <param name="toid">去向会员账号</param>
        /// <param name="money">货币</param>
        /// <returns></returns>
        public static Hashtable TranChangeTran(string frommid, string tomid, decimal money, string moneytype, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            MyHs.Add(string.Format("Update MemberConfig set " + moneytype + "=" + moneytype + "-" + money + " where MID='" + frommid + "' and '{0}'='{0}'" + DAL.Member.UpdateThrPsd(frommid), guid), new SqlParameter[] { });
            MyHs.Add(string.Format("Update MemberConfig set " + moneytype + "=" + moneytype + "+" + money + " where MID='" + tomid + "' and '{0}'='{0}'" + DAL.Member.UpdateThrPsd(tomid), guid), new SqlParameter[] { });

            return MyHs;
        }

        /// <summary>
        /// 更新申请提现为已审核哈希表
        /// </summary>
        /// <param name="CID"></param>
        /// <returns></returns>
        public static Hashtable UpdataTran(Model.ChangeMoney changemoney, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ChangeMoney set ");
            strSql.Append("CState=@CState,");
            strSql.Append("TakeOffMoney=@TakeOffMoney,");
            strSql.Append("CRemarks=@CRemarks,");
            strSql.Append("ChangeDate=@ChangeDate,");
            strSql.Append("ToMID=@ToMID");
            strSql.Append(" where CID=@CID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CState", SqlDbType.Bit,1),
					new SqlParameter("@CID", SqlDbType.Int,4),
					new SqlParameter("@ToMID", SqlDbType.VarChar,20),
					new SqlParameter("@CRemarks", SqlDbType.VarChar,200),
					new SqlParameter("@ChangeDate", SqlDbType.DateTime,8),
					new SqlParameter("@TakeOffMoney", SqlDbType.Decimal,9)};
            parameters[0].Value = changemoney.CState;
            parameters[1].Value = changemoney.CID;
            parameters[2].Value = changemoney.ToMID;
            parameters[3].Value = changemoney.CRemarks;
            parameters[4].Value = changemoney.ChangeDate;
            parameters[5].Value = changemoney.TakeOffMoney;

            MyHs.Add(strSql, parameters);
            return MyHs;
        }

        public static Hashtable UpdataChangeMoneyTran(string cid, string fieldName, string fieldValue, bool isEqual, SqlDbType dataType, Hashtable MyHs)//Model.ChangeMoney changemoney,string fileds, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            string guid = Guid.NewGuid().ToString();
            strSql.Append("update ChangeMoney set ");
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
            strSql.Append(string.Format(" where CID={0} and '{1}'='{1}'", cid, guid));

            if (isEqual)
                MyHs.Add(strSql, "1");
            else
                MyHs.Add(strSql, null);
            return MyHs;
        }

        #endregion

        #region 实体查询
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.ChangeMoney GetModel(int CID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from ChangeMoney ");
            strSql.Append(" where CID=@CID");
            SqlParameter[] parameters = {
					new SqlParameter("@CID", SqlDbType.Int,4)};
            parameters[0].Value = CID;

            WE_Project.Model.ChangeMoney model = new WE_Project.Model.ChangeMoney();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return TranEntity(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public static Model.ChangeMoney GetTopModel(string changetype, bool cstate, string MID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from ChangeMoney ");
            strSql.Append(" where ChangeType=@ChangeType and CState=@CState and ToMID=@MID order by ChangeDate desc");
            SqlParameter[] parameters = {
					new SqlParameter("@ChangeType", SqlDbType.VarChar,10),
                    new SqlParameter("@CState",SqlDbType.Bit,1),
                    new SqlParameter("@MID",SqlDbType.VarChar,20)};
            parameters[0].Value = changetype;
            parameters[1].Value = cstate;
            parameters[2].Value = MID;

            WE_Project.Model.ChangeMoney model = new WE_Project.Model.ChangeMoney();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return TranEntity(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 转换数据实体
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static Model.ChangeMoney TranEntity(DataRow dr)
        {
            WE_Project.Model.ChangeMoney model = new WE_Project.Model.ChangeMoney();
            if (dr["CID"].ToString() != "")
            {
                model.CID = int.Parse(dr["CID"].ToString());
            }
            if (dr["FromMID"] != null)
            {
                model.FromMID = dr["FromMID"].ToString();
            }
            if (dr["ToMID"] != null)
            {
                model.ToMID = dr["ToMID"].ToString();
            }
            if (dr["SHMID"] != null)
            {
                model.SHMID = dr["SHMID"].ToString();
            }
            if (dr["Money"].ToString() != "")
            {
                model.Money = decimal.Parse(dr["Money"].ToString());
            }
            if (dr["ChangeDate"].ToString() != "")
            {
                model.ChangeDate = DateTime.Parse(dr["ChangeDate"].ToString());
            }
            if (dr["ChangeType"] != null)
            {
                model.ChangeType = dr["ChangeType"].ToString();
                if (DAL.Reward.List.ContainsKey(model.ChangeType))
                {
                    model.ChangeTypeStr = DAL.Reward.List[model.ChangeType].RewardName;
                }
                else if (model.ChangeType == "TJKF")
                {
                    model.ChangeTypeStr = "不打款扣费";
                }
                else
                {
                    model.ChangeTypeStr = "未知类型";
                }
            }
            if (dr["MoneyType"] != null)
            {
                model.MoneyType = dr["MoneyType"].ToString();
                if (DAL.Reward.List.ContainsKey(model.MoneyType))
                    model.MoneyTypeStr = DAL.Reward.List[model.MoneyType].RewardName;
                else
                    model.MoneyTypeStr = "未知类型";
            }
            if (dr["TakeOffMoney"].ToString() != "")
            {
                model.TakeOffMoney = decimal.Parse(dr["TakeOffMoney"].ToString());
            }
            if (dr["ReBuyMoney"].ToString() != "")
            {
                model.ReBuyMoney = decimal.Parse(dr["ReBuyMoney"].ToString());
            }
            if (dr["MCWMoney"].ToString() != "")
            {
                model.MCWMoney = decimal.Parse(dr["MCWMoney"].ToString());
            }
            if (dr["CState"].ToString() != "")
            {
                model.CState = bool.Parse(dr["CState"].ToString());
            }
            if (dr["CRemarks"] != null)
            {
                model.CRemarks = dr["CRemarks"].ToString();
            }
            if (dr["CFileds"] != null)
            {
                model.CFileds = dr["CFileds"].ToString();
            }
            if (dr["CFileds2"] != null)
            {
                model.CFileds2 = dr["CFileds2"].ToString();
            }
            if (dr["CompleteTime"] != null)
            {
                model.CompleteTime = Convert.ToDateTime(dr["CompleteTime"].ToString());
            }
            if (dr["OrderState"] != null)
            {
                model.OrderState = Convert.ToInt16(dr["OrderState"].ToString());
            }

            return model;
        }

        #endregion

        #region 会员奖金查询


        /// <summary>
        /// 得到会员业绩汇总
        /// </summary>
        /// <param name="mid">会员账号</param>
        /// <param name="ChangeType">统计奖金类型</param>
        /// <param name="NeedTakeOff">需要扣除费用的类型</param>
        /// <returns></returns>
        public static Dictionary<string, decimal> GetJJInfo(string mid, List<string> ChangeTypeList, List<string> NeedTakeOff, string startDate, string endDate)
        {
            string strWhere = "";
            if (!string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
                strWhere = string.Format(" and changedate between '{0} 00:00:00' and '{1} 23:59:59:997' ", startDate, endDate);
            Dictionary<string, decimal> JJinfo = new Dictionary<string, decimal>();
            StringBuilder sb = new StringBuilder();
            foreach (string item in ChangeTypeList)
            {
                sb.Append(string.Format("select '{1}', count(1),isnull(sum(Money),0) from ChangeMoney where ToMID='{0}' and ChangeType='{1}'  " + strWhere, mid, item));
                sb.Append(" union ");
            }
            if (NeedTakeOff.Count > 0)
            {
                sb.Append(string.Format("select 'TakeOff', count(1),isnull(sum(TakeOffMoney),0) from ChangeMoney where ToMID='{0}' and ChangeType in ('{1}')" + strWhere, mid, String.Join("','", NeedTakeOff.ToArray())));
                sb.Append(" union ");
                sb.Append(string.Format("select 'ReBuy', count(1),isnull(sum(ReBuyMoney),0) from ChangeMoney where ToMID='{0}' and ChangeType in ('{1}') " + strWhere, mid, String.Join("','", NeedTakeOff.ToArray())));
                sb.Append(" union ");
                sb.Append(string.Format("select 'MCW', count(1),isnull(sum(MCWMoney),0) from ChangeMoney where ToMID='{0}' and ChangeType in ('{1}')" + strWhere, mid, String.Join("','", NeedTakeOff.ToArray())));
            }

            DataTable table = DbHelperSQL.Query(sb.ToString()).Tables[0];

            foreach (DataRow dr in table.Rows)
            {
                JJinfo.Add(dr[0].ToString() + "Count", Convert.ToInt32(dr[1]));
                JJinfo.Add(dr[0].ToString() + "Money", Convert.ToDecimal(dr[2]));
            }

            return JJinfo;
        }

        /// <summary>
        /// 得到会员的累计未批准提现申请总额
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public static int GetAllTx(string mid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(Money) from ChangeMoney ");
            strSql.Append(" where FromMID=@FromMID and CState='0' and ChangeType='TX' ");
            SqlParameter[] parameters = {
					new SqlParameter("@FromMID", SqlDbType.VarChar,20)};
            parameters[0].Value = mid;

            WE_Project.Model.ChangeMoney model = new WE_Project.Model.ChangeMoney();
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
                return Convert.ToInt32(obj);
            return 0;
        }
        public static int GetAllEP(string mid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(Money) from ChangeMoney ");
            strSql.Append(" where FromMID=@FromMID and CState='0' and ChangeType='EP' ");
            SqlParameter[] parameters = {
					new SqlParameter("@FromMID", SqlDbType.VarChar,20)};
            parameters[0].Value = mid;

            WE_Project.Model.ChangeMoney model = new WE_Project.Model.ChangeMoney();
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
                return Convert.ToInt32(obj);
            return 0;
        }
        public static decimal GetTotalPYMoney(string mid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(Money) from ChangeMoney ");
            strSql.Append(" where ToMID=@ToMID and CState='1' and ChangeType='PY' ");
            SqlParameter[] parameters = {
					new SqlParameter("@ToMID", SqlDbType.VarChar,20)};
            parameters[0].Value = mid;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
                return Convert.ToDecimal(obj);
            return 0;
        }
        #endregion

        #region 其他操作


        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="CID"></param>
        /// <returns></returns>
        public static bool Delete(string cidList)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ChangeMoney ");
            strSql.Append(" where CID in (" + cidList + ")");

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 取到今天的提现次数
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public static int GetDayTXCount(string mid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ChangeMoney ");
            strSql.Append(" where FromMID=@FromMID and ChangeType='TX' and DATEDIFF(DAY,ChangeDate,GETDATE())=0 ");
            SqlParameter[] parameters = {
					new SqlParameter("@FromMID", SqlDbType.VarChar,20)};
            parameters[0].Value = mid;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
                return Convert.ToInt32(obj);
            return 0;
        }

        /// <summary>
        /// 得到个人的总计分红
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public static decimal GetTotalFHMoney(string mid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select SUM(Money) from ChangeMoney ");
            strSql.Append(" where ChangeType='DFH'  and ToMID=@ToMID and CState='1'");
            SqlParameter[] parameters = {
					new SqlParameter("@ToMID", SqlDbType.VarChar,20)};
            parameters[0].Value = mid;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
                return Convert.ToDecimal(obj);
            return 0;
        }
        #endregion

        /// <summary>
        /// 获取当天获得的钱数
        /// </summary>
        public static decimal GetDayFHMoney(string mid, string type, int? day, string dateType = "DD")
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(money) from ChangeMoney ");
            strSql.Append(" where ToMID=@ToMID ");
            if (!string.IsNullOrEmpty(type))
            {
                strSql.Append("  and ChangeType in (" + type + ") ");
            }
            else
            {
                strSql.Append("  and ChangeType in (" + DAL.Reward.AllRewardStr + ") ");
            }
            if (day != null)
            {
                strSql.Append(" and DATEDIFF(" + dateType + ",ChangeDate,GETDATE())=" + day.Value + " ");
            }
            SqlParameter[] parameters = {
					new SqlParameter("@ToMID", SqlDbType.VarChar,20)};
            parameters[0].Value = mid;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
                return Convert.ToDecimal(obj);
            return 0;
        }

        public static List<Model.ChangeMoney> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.ChangeMoney> list = new List<Model.ChangeMoney>();

            DataTable table = GetTable(strWhere, pageIndex, pageSize, out count);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(TranEntity(table.Rows[i]));
            }

            return list;
        }

        public static List<Model.ChangeMoney> GetList(string strWhere)
        {
            List<Model.ChangeMoney> list = new List<Model.ChangeMoney>();

            DataTable table = GetTable(strWhere);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(TranEntity(table.Rows[i]));
            }

            return list;
        }

        private static DataTable GetTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select * from ChangeMoney ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        private static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@TableName", SqlDbType.VarChar, 50),
                    new SqlParameter("@FieldList", SqlDbType.VarChar, 50),
                    new SqlParameter("@PrimaryKey", SqlDbType.VarChar, 50),
                    new SqlParameter("@Where", SqlDbType.VarChar, 500),
                    new SqlParameter("@Order", SqlDbType.VarChar, 50),
                    new SqlParameter("@SortType", SqlDbType.Int,4),
                    new SqlParameter("@RecorderCount", SqlDbType.Int,4),
                    new SqlParameter("@PageSize", SqlDbType.Int,4),
                    new SqlParameter("@PageIndex", SqlDbType.Int,4),
                    new SqlParameter("@TotalCount", SqlDbType.Int,4),
                    new SqlParameter("@TotalPageCount", SqlDbType.Int,4)};
            parameters[0].Value = "ChangeMoney";
            parameters[1].Value = "*";
            parameters[2].Value = "ChangeDate";
            parameters[3].Value = strWhere;
            parameters[4].Value = "ChangeDate desc";
            parameters[5].Value = 3;
            parameters[6].Value = 0;
            parameters[7].Value = pageSize;
            parameters[8].Value = pageIndex;
            parameters[9].Direction = ParameterDirection.InputOutput;
            parameters[10].Direction = ParameterDirection.InputOutput;
            DataSet ds = DbHelperSQL.RunProcedure("P_AspNetPage", parameters, "Table");
            DataTable table = ds.Tables[0];
            count = Convert.ToInt32(parameters[9].Value);
            return table;
        }

        public static int GetSJCount(string mid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ChangeMoney ");
            strSql.Append(" where FromMID=@FromMID and CState='1' and ChangeType='SJ' ");
            SqlParameter[] parameters = {
					new SqlParameter("@FromMID", SqlDbType.VarChar,20)};
            parameters[0].Value = mid;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj != null)
                return Convert.ToInt16(obj);
            return 0;
        }

        public static DataTable GetChangeTypeList(string mid, string changeType, string top)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + top + " * from ChangeMoney ");
            strSql.Append(" where ToMID=@ToMID and CState='1' and ChangeType=@ChangeType ");
            strSql.Append(" order by ChangeDate desc ");
            SqlParameter[] parameters = {
					new SqlParameter("@ToMID", SqlDbType.VarChar,20),
                    new SqlParameter("@ChangeType", SqlDbType.VarChar,20)
                                        };
            parameters[0].Value = mid;
            parameters[1].Value = changeType;

            DataSet obj = DbHelperSQL.Query(strSql.ToString(), parameters);
            return obj.Tables[0];
        }
    }
}
