using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace WE_Project.Web.Mafull.Handler
{
    /// <summary>
    /// OfferPutScramble 的摘要说明
    /// </summary>
    public class OfferPutScramble : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = " HelpType = 0 ";
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

            int count;
            List<Model.MOfferHelp> offerList = BLL.MOfferHelp.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < offerList.Count; i++)
            {
                sb.Append(offerList[i].Id + "~");
                sb.Append(offerList[i].SQMID + "~");
                sb.Append(offerList[i].SQCode + "~");
                sb.Append(offerList[i].SQDate.ToString("yyyy-MM-dd HH:mm") + "~");
                sb.Append(offerList[i].SQMoney + "~");
                sb.Append("<input type='button' value='放入抢单列表' class='btn btn-info btn-sm' onclick=\"OfferPutScramble('" + offerList[i].Id + "')\" />");
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}