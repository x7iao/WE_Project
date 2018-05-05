using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Newtonsoft.Json;

namespace WE_Project.Web.Handler
{
    /// <summary>
    /// RemindMsgList 的摘要说明
    /// </summary>
    public class RemindMsgList : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = "'1'='1'";

            //if (!string.IsNullOrEmpty(context.Request["nTitle"]))
            //{
            //    strWhere += " and NTitle like '%" + HttpUtility.UrlDecode(context.Request["nTitle"]) + "%'";
            //}
            int count;
            List<Model.Remind> ListNotice = BLL.Remind.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListNotice.Count; i++)
            {
                sb.Append(ListNotice[i].Id + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(ListNotice[i].RTypeName + "~");
                sb.Append(ListNotice[i].RemindMsg + "~");
                sb.Append((ListNotice[i].State == 1 ? "可用" : "不可用") );
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };

            //var json = new { PageData = sb.ToString(), TotalCount = count };匿名类
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}