using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Text;
using Newtonsoft.Json;

namespace WE_Project.Web.EP.Handler
{
    /// <summary>
    /// TimeOutList 的摘要说明
    /// </summary>
    public class TimeOutList : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = " 1=1 ";
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                string[] fanwei = context.Request["tState"].Split('-');
                if (fanwei.Length > 1)
                {
                    strWhere += " and Money between " + fanwei[0] + " and " + fanwei[1] + " ";
                }
                else
                {
                    strWhere += " and Money>" + fanwei[0] + " ";
                }
            }
            if (TModel.MID == "admin")
            {
                if (!string.IsNullOrEmpty(context.Request["mKey"]))
                {
                    strWhere += " and EPJXMID='" + context.Request["mKey"] + "' ";
                }
            }
            else
            {
                strWhere += " and EPJXMID='" + TModel.MID + "' ";
            }
            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and EPJXTime>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                strWhere += " and EPJXTime<'" + context.Request["endDate"] + " 23:59:59' ";
            }
            int count;
            List<Model.EPJX> EPList = BLL.EPJX.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < EPList.Count; i++)
            {
                sb.Append(EPList[i].JXID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(EPList[i].EPJXMID + "~");
                sb.Append(EPList[i].EPJXTime + "~");
                sb.Append(EPList[i].EPJXRemark);
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}