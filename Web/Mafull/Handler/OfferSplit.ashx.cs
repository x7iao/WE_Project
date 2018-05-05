using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Newtonsoft.Json;

namespace WE_Project.Web.Mafull.Handler
{
    /// <summary>
    /// OfferSplit 的摘要说明
    /// </summary>
    public class OfferSplit : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = " HelpType = 0 and PPState = 0 and DKState = 0 ";
            string mkey = "";
            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and SQDate>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                strWhere += " and SQDate<'" + context.Request["endDate"] + " 23:59:59' ";
            }
            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                mkey = context.Request["mKey"];
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
            List<Model.MOfferHelp> offerList = BLL.MOfferHelp.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < offerList.Count; i++)
            {
                sb.Append(offerList[i].Id + "~");
                sb.Append(offerList[i].SQMID + "~");//会员帐号
                sb.Append(offerList[i].SQCode + "~");//编号
                sb.Append(offerList[i].SQDate.ToString("yyyy-MM-dd HH:mm") + "~");
                sb.Append(offerList[i].SQMoney + "~");
                sb.Append("<input type='text' id='txtSplit_" + offerList[i].Id + "' ><input type='button' value='确定拆分' class='btn btn-info btn-sm' onclick=\"OfferSplit('" + offerList[i].Id + "')\" />");
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}