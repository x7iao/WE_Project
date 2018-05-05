using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Newtonsoft.Json;

namespace WE_Project.Web.Mafull.Handler
{
    /// <summary>
    /// GetSplit 的摘要说明
    /// </summary>
    public class GetSplit : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = " 1=1 and HelpType = 0 and PPState = 0 and ConfirmState = 0 ";
            string mkey = "";
            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                mkey = context.Request["mKey"];
            }
            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and SQDate>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                strWhere += " and SQDate<'" + context.Request["endDate"] + " 23:59:59' ";
            }

            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            if (!memberModel.Role.IsAdmin)
            {
                mkey = memberModel.MID;
            }
            if (!string.IsNullOrEmpty(mkey))
            {
                strWhere += " and SQMID ='" + mkey + "' ";
            }
            strWhere += " and SQMID not in (select MID from Member where IsClock = 1 and IsClose = 1)";
            int count;
            List<Model.MGetHelp> EPList = BLL.MGetHelp.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < EPList.Count; i++)
            {
                sb.Append(EPList[i].Id + "~");
                sb.Append(EPList[i].SQMID + "~");
                sb.Append(EPList[i].SQCode + "~");
                sb.Append(EPList[i].SQDate.ToString("yyyy-MM-dd HH:mm") + "~");
                sb.Append(EPList[i].SQMoney + "~");
                sb.Append("<input type='text' id='txtSplit_" + EPList[i].Id + "' ><input type='button' value='确定拆分' class='btn btn-info btn-sm' onclick=\"GetSplit('" + EPList[i].Id + "')\" />");
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}