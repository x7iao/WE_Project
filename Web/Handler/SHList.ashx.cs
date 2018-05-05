using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Newtonsoft.Json;
using System.Web.SessionState;

namespace WE_Project.Web.Handler
{
    /// <summary>
    /// SHList 的摘要说明
    /// </summary>
    public class SHList : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string RoleCode = "";
            foreach (Model.Roles item in BLL.Roles.RolsList.Values.ToList().Where(emp => !emp.IsAdmin && emp.VState).ToList())
                RoleCode += "'" + item.RType + "',";
            RoleCode = RoleCode.Substring(0, RoleCode.Length - 1);
            string strWhere = "RoleCode in (" + RoleCode + ")";

            string sh = " and AgencyCode='001' ";
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                if (context.Request["tState"] == "true")
                    sh = " and AgencyCode<>'001' ";
            }
            if (!string.IsNullOrEmpty(context.Request["IsMHS"]))
            {
                strWhere += string.Format(" and ( MSH='{0}'", TModel.MID);
            }
            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                strWhere += string.Format(" and ( MID='{0}' or MName='{0}') ", (context.Request["mKey"]));
            }
            //if (!string.IsNullOrEmpty(context.Request["mSHKey"]))
            //{
            //    strWhere += string.Format(" and (MSH='{0}' or MTJ='{0}') ", (context.Request["mSHKey"]));
            //}
            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and MDate>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                strWhere += " and MDate<'" + context.Request["endDate"] + " 23:59:59' ";
            }

            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            if (!memberModel.Role.IsAdmin)
                strWhere += string.Format(" and MTJ='{0}' ", memberModel.MID);
            int count;
            List<Model.Member> ListMember = BllModel.GetMemberEntityList(strWhere + sh, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListMember.Count; i++)
            {
                sb.Append(ListMember[i].MID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(ListMember[i].MID + BLL.Member.GetOnlineInfo(ListMember[i].MID) + "~");
                sb.Append(ListMember[i].MName + "~");
                sb.Append(ListMember[i].Tel + "~");
                sb.Append(ListMember[i].MAgencyType.MAgencyName + "~");
                //if (ListMember[i].MConfig != null && ListMember[i].MConfig.JXType != null)
                //{
                //    sb.Append(ListMember[i].MConfig.JXType.JXName + "~");
                //}
                //else
                //{
                //    sb.Append("无称谓~");
                //}
                //sb.Append(ListMember[i].MBD + "~");
                sb.Append(ListMember[i].MTJ + "~");
                //sb.Append(ListMember[i].MSH + "~");
                sb.Append((ListMember[i].MState ? "已激活" : "未激活") + "~");
                sb.Append(ListMember[i].MDate.Year == DateTime.MaxValue.Year ? ListMember[i].MCreateDate.ToString("yyyy-MM-dd HH:mm") : ListMember[i].MDate.ToString("yyyy-MM-dd HH:mm"));
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}