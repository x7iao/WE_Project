using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Text;
using Newtonsoft.Json;

namespace WE_Project.Web.Handler
{
    /// <summary>
    /// ZZBGMList 的摘要说明
    /// </summary>
    public class ZZBGMList : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string mkey = "";
            string strWhere = " '1'='1' ";
            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            strWhere += " and AMID='" + memberModel.MID + "'";

            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                mkey = context.Request["mKey"];
            }
            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and BMCreateDate>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                strWhere += " and BMCreateDate<'" + context.Request["endDate"] + " 23:59:59' ";
            }

 
            int count;
            List<Model.BMember> List = BLL.BMember.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < List.Count; i++)
            {
                sb.Append((i + 1) + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                //sb.Append(List[i].FromMID + "~");
                sb.Append(List[i].BCount + "~");
                //sb.Append(List[i].BuyPrice + "~");
                //sb.Append(List[i].BuyCount * List[i].BuyPrice + "~");
                sb.Append(List[i].BMCreateDate.ToString("yyyy-MM-dd HH:mm") + "~");
                //投资金额
                sb.Append(List[i].BMState ? "已成交~" : "未成交~");
                sb.Append(List[i].YJMoney );
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}