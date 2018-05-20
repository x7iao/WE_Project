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
    /// JJList 的摘要说明
    /// </summary>
    public class JJJLList : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            List<string> cTypeList = new List<string>();
            List<string> mTypeList = new List<string> { "MHB", "MJB", "MGP" };
            string strWhere = " and '1'='1' ";
            string TypeLength = "100";
            string countdate = "";
            string mKey = "";
            if (!string.IsNullOrEmpty(context.Request["typeList"]))
            {
                string types = context.Request["typeList"].Remove(context.Request["typeList"].Length - 1);
                cTypeList = new List<string>(types.Split('|'));
            }
            if (!string.IsNullOrEmpty(context.Request["txtKey"]))
            {
                mKey = context.Request["txtKey"];
            }
            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and changedate>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                strWhere += " and changedate<'" + context.Request["endDate"] + " 23:59:59' ";
            }
            if (!string.IsNullOrEmpty(context.Request["moneyType"]))
            {
                mTypeList = new List<string> { context.Request["moneyType"] };
            }
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                TypeLength = context.Request["tState"];
            }
            if (!string.IsNullOrEmpty(context.Request["countdate"]))
            {
                countdate = context.Request["countdate"];
            }

            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            if (!memberModel.Role.IsAdmin)
                mKey = memberModel.MID;

            if (!string.IsNullOrEmpty(mKey))
            {
                strWhere += " and tomid='" + mKey + "' ";
            }
            if (!string.IsNullOrEmpty(countdate))
            {
                strWhere += " and changedate>'" + context.Request["countdate"] + " 00:00:00'  and changedate<'" + context.Request["countdate"] + " 23:59:59'";
            }

            StringBuilder sqlstr = new StringBuilder("select tomid,");
            foreach (string CType in cTypeList)
            {
                sqlstr.AppendFormat("sum(case when changetype='{0}' then money else 0 end) as '{0}',", CType);
            }
            sqlstr.Append("sum(TakeOffMoney) as 'Take',");
            sqlstr.Append("sum(ReBuyMoney) as 'ReBuy',");
            sqlstr.Append("sum(MCWMoney) as 'MCW',");
            sqlstr.Append("sum(money) as 'HeJi',");
            sqlstr.Append("sum(money-TakeOffMoney-ReBuyMoney-MCWMoney) as 'JJ'");
            sqlstr.AppendFormat(",CONVERT(varchar(" + TypeLength + "), changedate, 23) as 'Date' from changemoney a where ");
            sqlstr.AppendFormat(" changetype in ('{0}') ", String.Join("','", cTypeList.ToArray()));
            sqlstr.Append(strWhere);
            sqlstr.Append("group by CONVERT(varchar(" + TypeLength + "), changedate, 23),tomid order by CONVERT(varchar(" + TypeLength + "), changedate, 23) desc");
            DataTable table = BLL.CommonBase.GetTable(sqlstr.ToString());

            StringBuilder sb = new StringBuilder();
            decimal[] heji = new decimal[cTypeList.Count + 4];
            for (int i = (pageIndex - 1) * pageSize; i < table.Rows.Count && i < pageSize * (pageIndex); i++)
            {
                int j = 0;
                Model.Member member = BllModel.GetModel(table.Rows[i]["ToMID"].ToString());
                sb.Append(i + 1 + "~");
                sb.Append(i + 1 + "~");
                //if (TModel.Role.IsAdmin)
                //{
                sb.Append("<a href=\"javascript:void(0);\" onclick=\"callhtml('ChangeMoney/JJJLList.aspx?id=" + member.MID + "');\">" + member.MID + "</a>~");
                //sb.Append(member.MName + "~");
                sb.Append(member.MAgencyType.MAgencyName + "~");
                //}
                for (; j < cTypeList.Count; j++)
                {
                    sb.Append(Math.Round(Convert.ToDecimal(table.Rows[i][cTypeList[j]]), 6) + "~");
                    heji[j] += Convert.ToDecimal(table.Rows[i][cTypeList[j]]);
                }
                //sb.Append(table.Rows[i]["MCW"] + "~");
                sb.Append(Math.Round(Convert.ToDecimal(table.Rows[i]["HeJi"]), 6) + "~");
                heji[j++] += Math.Round(Convert.ToDecimal(table.Rows[i]["HeJi"]), 6);
                //sb.Append(table.Rows[i]["ReBuy"] + "~");
                //heji[j++] += Convert.ToDecimal("-" + table.Rows[i]["ReBuy"]);
                //sb.Append(table.Rows[i]["Take"] + "~");
                heji[j++] += Math.Round(Convert.ToDecimal("-" + table.Rows[i]["Take"]), 6);
                //sb.Append(Math.Round(Convert.ToDecimal(table.Rows[i]["Take"]), 2) + "~");
                //sb.Append(Math.Round(Convert.ToDecimal(table.Rows[i]["JJ"]), 2) + "~");
                heji[j++] += Math.Round(Convert.ToDecimal(table.Rows[i]["JJ"]), 6);
                sb.Append(table.Rows[i]["Date"]);
                if (string.IsNullOrEmpty(countdate))
                {
                    sb.Append("&nbsp;<input type='button' class='btn btn-success' value='查看详细' onclick=\"callhtml('ChangeMoney/JJList.aspx?id=" + member.MID + "&date=" + table.Rows[i]["Date"] + "','奖金明细');\"/>");
                }
                sb.Append("≌");
            }
            //if (TModel.Role.IsAdmin)
            //    sb.Append("~~~合计~");
            //else
            //    sb.Append("~合计~");
            //foreach (decimal item in heji)
            //{
            //    sb.Append(item + "~");
            //}
            //sb.Append("≌");
            var info = new { PageData = Traditionalized(sb), TotalCount = table.Rows.Count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}