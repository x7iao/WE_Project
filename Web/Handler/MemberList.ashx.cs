using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace WE_Project.Web.Handler
{
    /// <summary>
    /// MemberList 的摘要说明
    /// </summary>
    public class MemberList : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            if (!memberModel.Role.IsAdmin)
            {
                return;
            }
            base.ProcessRequest(context);
            string strWhere = "'1'='1'";
            string RoleCode = "";
            foreach (Model.Roles item in BLL.Roles.RolsList.Values.ToList().Where(emp => emp.VState && !emp.IsAdmin).ToList())
                RoleCode += "'" + item.RType + "',";
            RoleCode = RoleCode.Substring(0, RoleCode.Length - 1);
            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                strWhere += string.Format(" and ( MID='{0}' or MName='{0}') ", (context.Request["mKey"]));
            }
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                strWhere += string.Format(" and MType={0} ", (context.Request["tState"]));
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
            if (!string.IsNullOrEmpty(context.Request["JXType"]))
            {
                if (context.Request["JXType"] == "no")
                    strWhere += " and JXType is NULL ";
                else
                    strWhere += " and JXType='" + context.Request["JXType"] + "'";
            }
            if (!string.IsNullOrEmpty(context.Request["IsClose"]))
            {
                strWhere += " and IsClose='" + context.Request["IsClose"] + "' ";
            }
            if (!string.IsNullOrEmpty(context.Request["IsPPLeavel"]))
            {
                strWhere += " and  (select PPLeavel from MemberConfig where MID=Member.MID)='" + context.Request["IsPPLeavel"] + "' ";
            }
            if (!string.IsNullOrEmpty(context.Request["AgencyCode"]))
            {
                strWhere += " and AgencyCode='" + context.Request["AgencyCode"] + "' ";
            }
            if (!string.IsNullOrEmpty(context.Request["ddlPCode"]))
            {
                strWhere += " and (select PCode from MemberConfig where MID=Member.MID)='" + context.Request["ddlPCode"] + "' ";
            }
            if (!string.IsNullOrEmpty(context.Request["OnlyOnLine"]))
            {
                strWhere += " and mid in ('" + String.Join("','", BLL.Member.OnLineMember.ToArray()) + "') ";
            }

            int count;
            List<Model.Member> ListMember = BllModel.GetMemberEntityList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListMember.Count; i++)
            {
                sb.Append(ListMember[i].MID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                if (ListMember[i].Role.CanSH)
                {
                    sb.Append("<span style='color:red;'>" + ListMember[i].MID + "[" + (BLL.Member.IfOnLine(ListMember[i].MID) ? "<b style='color:#A8FF24;cursor:help;' onclick='OpenTask(\"" + ListMember[i].MID + "\");'>在线</b>" : "离线") + "]" + "</span>" + "~");
                }
                else
                {
                    sb.Append(ListMember[i].MID + "[" + (BLL.Member.IfOnLine(ListMember[i].MID) ? "<b style='color:#A8FF24;cursor:help;' onclick='OpenTask(\"" + ListMember[i].MID + "\");'>在线</b>" : "离线") + "]" + "~");
                }
                sb.Append(ListMember[i].MName + "~");
                sb.Append(ListMember[i].MAgencyType.MAgencyName + "~");
                //if (ListMember[i].MConfig.MHB - ListMember[i].MConfig.MHBFreeze < 0)
                //{
                //    sb.Append(ListMember[i].MConfig.MHB + "~");
                //}
                //else
                {
                    sb.Append(ListMember[i].MConfig.MHB + "~");
                }
                //sb.Append(ListMember[i].MConfig.MCW + "~");
                sb.Append(ListMember[i].MConfig.MJB + "~");
                sb.Append(ListMember[i].MConfig.MGP.ToString("F0") + "~");
                sb.Append(ListMember[i].MTJ + "~");
                sb.Append((ListMember[i].IsClose ? "已锁定" : "未锁定") + ListMember[i].Province + "~");
                sb.Append((ListMember[i].MConfig.PPLeavel == 0 ? "不优先" : "优先") + "~");
                sb.Append(ListMember[i].MCreateDate.ToString("yyyy-MM-dd HH:mm") + "~");
                if (ListMember[i].IsClose)
                {
                    sb.Append("限制登录");
                }
                else
                {
                    sb.Append("<a href='?LoggedInMID=" + ListMember[i].MID + "' target=\"_blank\">进入会员系统</a>");
                }
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };

            //var json = new { PageData = sb.ToString(), TotalCount = count };匿名类
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}