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
    public class DTFHMemberList : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = "Member.MID in (select distinct AMID from BMember) ";
            string RoleCode = "";
            foreach (Model.Roles item in BLL.Roles.RolsList.Values.ToList().Where(emp => emp.VState).ToList())
                RoleCode += "'" + item.RType + "',";
            RoleCode = RoleCode.Substring(0, RoleCode.Length - 1);
            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                strWhere += string.Format(" and ( Member.MID='{0}' or MName='{0}') ", (context.Request["mKey"]));
            }
            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and MDate>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                strWhere += " and MDate<'" + context.Request["endDate"] + " 23:59:59' ";
            }
            if (!string.IsNullOrEmpty(context.Request["RoleCode"]))
            {
                strWhere += " and RoleCode in ('" + context.Request["RoleCode"] + "') ";
            }
            else
            {
                strWhere += " and RoleCode in (" + RoleCode + ") ";
            }
            if (!string.IsNullOrEmpty(context.Request["AgencyCode"]))
            {
                strWhere += " and AgencyCode='" + context.Request["AgencyCode"] + "' ";
            }

            List<Model.Member> ListMember = BllModel.GetMemberAndConfigEntityList(strWhere);

            StringBuilder sb = new StringBuilder();
            for (int i = (pageIndex - 1) * pageSize; i < ListMember.Count && i < pageIndex * pageSize; i++)
            {
                sb.Append(ListMember[i].MID + "~");
                sb.Append(i + 1 + "~");
                sb.Append(ListMember[i].MID + BLL.Member.GetOnlineInfo(ListMember[i].MID) + "~");
                sb.Append(ListMember[i].MName + "~");
                sb.Append(ListMember[i].MAgencyType.MAgencyName + "~");
                sb.Append(ListMember[i].SHMoney + "~");
                sb.Append(ListMember[i].MConfig.MGP + "~");
                List<Model.BMember> list = BLL.BMember.GetList("AMID='" + ListMember[i].MID + "'");
                sb.Append(list.Count + "~");
                //sb.Append(list.Where(emp => emp.BIsClock == true || emp.YJMoney >= BLL.Configuration.Model.JJBTopMoney).Count() + "~");
                //sb.Append(list.Where(emp => emp.BIsClock == false && emp.YJMoney < BLL.Configuration.Model.JJBTopMoney).Count() + "~");
                sb.Append(list.Where(emp => emp.BIsClock == true).Count() + "~");
                sb.Append(list.Where(emp => emp.BIsClock == false).Count() + "~");
                sb.Append(list.Sum(emp => emp.YJMoney) + "~");
                sb.Append(ListMember[i].MDate.ToString("yyyy-MM-dd HH:mm"));
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = ListMember.Count };

            //var json = new { PageData = sb.ToString(), TotalCount = count };匿名类
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}