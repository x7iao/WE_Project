using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.SessionState;
using Newtonsoft.Json;

namespace WE_Project.Web.Handler
{
    /// <summary>
    /// MemberList 的摘要说明
    /// </summary>
    public class AccountsList : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = "'1'='1'";
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                strWhere += " and PCode='" + context.Request["tState"] + "' ";
            }
            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and AccountsDate>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                strWhere += " and AccountsDate<'" + context.Request["endDate"] + " 23:59:59' ";
            }
            if (!string.IsNullOrEmpty(context.Request["ddlIfAccount"]))
            {
                strWhere += " and IfAccount='" + context.Request["ddlIfAccount"] + "' ";
            }
            int count;
            List<Model.Accounts> List = BLL.Accounts.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < List.Count; i++)
            {
                sb.Append(List[i].ACode + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                if (List[i].PCode == "002")
                    sb.Append(List[i].ACode + "~");
                else
                {
                    if (List[i].PCode == "001" || List[i].PCode == "005")
                        sb.Append("<a href=\"javascript:void(0);\" onclick=\"callhtml('ChangeMoney/JJList.aspx?id=" + List[i].ARemark + "','"+List[i].PCodeStr+"');\">" + List[i].ACode + "</a>~");
                    else
                        sb.Append("<a href=\"javascript:void(0);\" onclick=\"callhtml('ChangeMoney/JJList.aspx?id=" + List[i].ACode + "','" + List[i].PCodeStr + "');\">" + List[i].ACode + "</a>~");
                }
                sb.Append(List[i].PCodeStr + "~");
                sb.Append(List[i].TotalFHMoney + "~");
                sb.Append(List[i].FHCount + "~");
                sb.Append(List[i].CreateDate.ToString("yyyy-MM-dd HH:mm:ss") + "~");
                sb.Append((!List[i].IfAccount ? "未结算" : List[i].AccountsDate.ToString("yyyy-MM-dd HH:mm:ss")) + "~");
                if (List[i].IfAccount)
                    sb.Append((List[i].IsAuto ? "自动" : "手动"));
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };

            //var json = new { PageData = sb.ToString(), TotalCount = count };匿名类
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}