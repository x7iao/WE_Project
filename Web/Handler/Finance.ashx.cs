using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.SessionState;
using Newtonsoft.Json;
using System.Data;

namespace WE_Project.Web.Handler
{
    /// <summary>
    /// FHPlan 的摘要说明
    /// </summary>
    public class Finance : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string jjtype = "'";
            foreach (Model.Reward item in BLL.Reward.List.Values)
            {
                if (item.NeedProcess)
                    jjtype += item.RewardType + "','";
            }
            jjtype = jjtype.Substring(0, jjtype.LastIndexOf(",'"));

            string strWhere = " select " +
" isnull((select SUM(SHMoney) from MemberConfig where MID in (select ACode from Accounts where AccountsDate between CONVERT(varchar(100), a.ChangeDate, 23)+ ' 00:00:00' and CONVERT(varchar(100), a.ChangeDate, 23)+' 23:59:59')),0) as 'yj'," +
" isnull((select SUM(money) from ChangeMoney where ChangeDate between CONVERT(varchar(100), a.ChangeDate, 23)+ ' 00:00:00' and CONVERT(varchar(100), a.ChangeDate, 23)+' 23:59:59' and ChangeType in ('sj','sh')),0) as 'sj'," +
" isnull((select SUM(money) from ChangeMoney where ChangeDate between CONVERT(varchar(100), a.ChangeDate, 23)+ ' 00:00:00' and CONVERT(varchar(100), a.ChangeDate, 23)+' 23:59:59' and ChangeType in (" + jjtype + ")),0) as 'bc'," +
" isnull((select SUM(MCWMoney) from ChangeMoney where ChangeDate between CONVERT(varchar(100), a.ChangeDate, 23)+ ' 00:00:00' and CONVERT(varchar(100), a.ChangeDate, 23)+' 23:59:59' and ChangeType in (" + jjtype + ")),0) as 'cw'," +
" isnull((select SUM(ReBuyMoney) from ChangeMoney where ChangeDate between CONVERT(varchar(100), a.ChangeDate, 23)+ ' 00:00:00' and CONVERT(varchar(100), a.ChangeDate, 23)+' 23:59:59' and ChangeType in (" + jjtype + ")),0) as 'fx'," +
" isnull((select SUM(TakeOffMoney) from ChangeMoney where ChangeDate between CONVERT(varchar(100), a.ChangeDate, 23)+ ' 00:00:00' and CONVERT(varchar(100), a.ChangeDate, 23)+' 23:59:59' and ChangeType in (" + jjtype + ")),0) as 'ks'," +
" isnull((select SUM(money) from ChangeMoney where ChangeDate between CONVERT(varchar(100), a.ChangeDate, 23)+ ' 00:00:00' and CONVERT(varchar(100), a.ChangeDate, 23)+' 23:59:59' and ChangeType='cz'),0) as 'cz'," +
" isnull((select SUM(money) from ChangeMoney where ChangeDate between CONVERT(varchar(100), a.ChangeDate, 23)+ ' 00:00:00' and CONVERT(varchar(100), a.ChangeDate, 23)+' 23:59:59' and ChangeType='tx'),0) as 'tx'," +
" isnull((select SUM(money) from ChangeMoney where ChangeDate between CONVERT(varchar(100), a.ChangeDate, 23)+ ' 00:00:00' and CONVERT(varchar(100), a.ChangeDate, 23)+' 23:59:59' and ChangeType='gm' and MoneyType='MCW'),0) as 'jj'," +
" CONVERT(varchar(100), ChangeDate, 23) as 'date' from ChangeMoney a where '1'='1' ";

            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and changedate>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            else
            {
                strWhere += " and changedate>'" + DateTime.Now.ToShortDateString() + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                strWhere += " and changedate<'" + DateTime.Now.ToShortDateString() + " 23:59:59' ";
            }
            strWhere += " group by CONVERT(varchar(100), ChangeDate, 23) order by CONVERT(varchar(100), ChangeDate, 23) desc ";

            StringBuilder sb = new StringBuilder();
            DataTable table = BLL.CommonBase.GetTable(strWhere);

            int count = pageIndex * pageSize < table.Rows.Count ? pageIndex * pageSize : table.Rows.Count;
            for (int i = (pageIndex - 1) * pageSize; i < count; i++)
            {
                decimal ks = Convert.ToDecimal(table.Rows[i]["cw"]) + Convert.ToDecimal(table.Rows[i]["fx"]) + Convert.ToDecimal(table.Rows[i]["ks"]);
                sb.Append(i + "~");
                sb.Append((i + 1) + "~");
                sb.Append((Convert.ToDecimal(table.Rows[i]["sj"])) + "~");
                //sb.Append((Convert.ToDecimal(table.Rows[i]["jj"])) + "~");
                sb.Append(table.Rows[i]["cz"] + "~");
                sb.Append(table.Rows[i]["bc"] + "~");
                //sb.Append(table.Rows[i]["cw"] + "~");
                //sb.Append(table.Rows[i]["fx"] + "~");
                sb.Append(ks + "~");
                sb.Append(table.Rows[i]["tx"] + "~");
                if ((Convert.ToDecimal(table.Rows[i]["yj"]) + Convert.ToDecimal(table.Rows[i]["sj"])) > 0)
                    sb.AppendFormat("{0:N2}%~", (Convert.ToDecimal(table.Rows[i]["bc"]) - ks) / (Convert.ToDecimal(table.Rows[i]["jj"]) + Convert.ToDecimal(table.Rows[i]["sj"])) * 100);
                else
                    sb.Append("~");
                sb.Append(table.Rows[i]["date"]);
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = table.Rows.Count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}