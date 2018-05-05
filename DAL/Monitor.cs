using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DBUtility;

namespace WE_Project.DAL
{
    public class Monitor
    {
        public static Model.Monitor GetMonitor()
        {
            StringBuilder strSql = new StringBuilder();
            string RoleCode = "";
            string jjtype = "'";
            foreach (Model.Reward item in DAL.Reward.List.Values)
            {
                if (item.NeedProcess)
                    jjtype += item.RewardType + "','";
            }
            jjtype = jjtype.Substring(0, jjtype.LastIndexOf(",'"));
            foreach (Model.Roles item in DAL.Roles.RolsList.Values.ToList().Where(emp => !emp.IsAdmin && emp.VState).ToList())
                RoleCode += "'" + item.RType + "',";
            RoleCode = RoleCode.Substring(0, RoleCode.Length - 1);
            strSql.Append(" select ");
            strSql.Append(" isnull((select SUM(shmoney) from MemberConfig),0) as Field1, ");
            strSql.Append(" isnull((select SUM(money) from ChangeMoney where MoneyType='mhb' and ChangeType in (" + jjtype + ")),0) as Field2, ");
            strSql.Append(" isnull((select SUM(shmoney) from MemberConfig)-(select SUM(money) from ChangeMoney where MoneyType='mhb' and ChangeType in (" + jjtype + ")),0) as Field3, ");//未拨出
            strSql.Append(" isnull((select SUM(money) from ChangeMoney where ChangeType='tx' and MoneyType='mhb' and CState='1'),0) as Field4, ");
            strSql.Append(" isnull((select SUM(money) from ChangeMoney where ChangeType='cz'),0) as Field10, ");
            strSql.Append(" isnull((select SUM(money) from ChangeMoney where ChangeType='gm' and MoneyType='MCW'),0) as Field11, ");
            strSql.Append(" isnull((select SUM(MHB) from MemberConfig where mid in (select mid from member where RoleCode in (" + RoleCode + "))),0) as Field5, ");
            strSql.Append(" isnull((select SUM(TakeOffMoney+MCWMoney+ReBuyMoney) from ChangeMoney where MoneyType='mhb' and ChangeType in (" + jjtype + ")),0) as Field6, ");
            strSql.Append(" isnull((select Count(1) from Member where MState='1' and RoleCode in (" + RoleCode + ")),0) as Field7 ");

            DataSet ds = DbHelperSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
                return TranEntity(ds.Tables[0].Rows[0], RoleCode);
            return null;
        }

        private static Model.Monitor TranEntity(DataRow dr, string RoleCode)
        {
            Model.Monitor model = new Model.Monitor();

            if (dr["Field1"] != null)
                model.Field1 = dr["Field1"].ToString();
            if (dr["Field2"] != null)
                model.Field2 = dr["Field2"].ToString();
            if (dr["Field3"] != null)
                model.Field3 = dr["Field3"].ToString();
            if (dr["Field4"] != null)
                model.Field4 = dr["Field4"].ToString();
            if (dr["Field5"] != null)
                model.Field5 = dr["Field5"].ToString();
            if (dr["Field6"] != null)
                model.Field6 = dr["Field6"].ToString();
            if (dr["Field7"] != null)
                model.Field7 = dr["Field7"].ToString();
            if (dr["Field10"] != null)
                model.Field10 = dr["Field10"].ToString();
            if (dr["Field11"] != null)
                model.Field11 = dr["Field11"].ToString();
            model.Field8 = GetMemberTypeCount(RoleCode);
            if (Convert.ToDecimal(model.Field1) + Convert.ToDecimal(model.Field10) > 0)
                model.Field9 = string.Format("{0:N2}%", ((Convert.ToDecimal(model.Field2) - Convert.ToDecimal(model.Field6)) / (Convert.ToDecimal(model.Field1) + Convert.ToDecimal(model.Field11))) * 100);
            else
                model.Field9 = "";
            return model;
        }

        public static string GetMemberTypeCount(string RoleCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select Count(1) MCount,AgencyCode from Member where RoleCode in (" + RoleCode + ") Group By AgencyCode order by AgencyCode");
            DataTable table = DbHelperSQL.Query(strSql.ToString()).Tables[0];
            strSql = new StringBuilder();
            foreach (DataRow dr in table.Rows)
            {
                strSql.Append(DAL.Configuration.TModel.SHMoneyList[dr["AgencyCode"].ToString()].MAgencyName + ":" + dr["MCount"].ToString() + "</br>");
            }
            return strSql.ToString();
        }
    }
}
