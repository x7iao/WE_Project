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
    public class MemberListB : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = "MState='1'";
            string mKey = "";
            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                mKey = context.Request["mKey"];
            }
            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and MDate>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                strWhere += " and MDate<'" + context.Request["endDate"] + " 23:59:59' ";
            }
            if (!TModel.Role.IsAdmin)
                mKey = TModel.MID;
            if (!string.IsNullOrEmpty(mKey))
                strWhere += string.Format(" and FMID='{0}' ", mKey);

            int count;
            List<Model.Member> ListMember = BllModel.GetMemberEntityList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListMember.Count; i++)
            {
                sb.Append(ListMember[i].MID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(ListMember[i].MID + "~");
                sb.Append(ListMember[i].MAgencyType.MAgencyName + "~");
                sb.Append(ListMember[i].SHMoney + "~");
                sb.Append(ListMember[i].MConfig.MJJ + "~");
                sb.Append(ListMember[i].MConfig.MJB + "~");
                sb.Append(ListMember[i].MConfig.MCW + "~");
                sb.Append((ListMember[i].IsClose ? "已锁定" : "未锁定") + "~");
                sb.Append((ListMember[i].IsClock ? "已冻结" : "未冻结") + "~");
                sb.Append(ListMember[i].MDate.ToString("yyyy-MM-dd HH:mm") + "~");
                sb.Append("<a href='" + HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.PathAndQuery, "/Default.aspx") + "?id=" + ListMember[i].MID + "'>进入系统</a>");
                sb.Append("≌");
            }
            var info = new { PageData = sb.ToString(), TotalCount = count };

            //var json = new { PageData = sb.ToString(), TotalCount = count };匿名类
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}