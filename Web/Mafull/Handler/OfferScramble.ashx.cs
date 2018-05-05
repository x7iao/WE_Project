using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace WE_Project.Web.Mafull.Handler
{
    /// <summary>
    /// OfferScramble 的摘要说明
    /// </summary>
    public class OfferScramble : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = " HelpType = 1 ";
            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and SQDate>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                strWhere += " and SQDate<'" + context.Request["endDate"] + " 23:59:59' ";
            }

            int count;
            List<Model.MOfferHelp> offerList = BLL.MOfferHelp.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < offerList.Count; i++)
            {
                sb.Append(offerList[i].Id + "~");
                //sb.Append(offerList[i].SQMID + "~");
                sb.Append(offerList[i].SQCode + "~");
                sb.Append(offerList[i].SQDate.ToString("yyyy-MM-dd HH:mm") + "~");
                sb.Append(offerList[i].SQMoney + "~");
                sb.Append("<input type='button' value='我要抢单' class='btn btn-info btn-sm' onclick=\"OfferScramble('" + offerList[i].Id + "')\" />");
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}