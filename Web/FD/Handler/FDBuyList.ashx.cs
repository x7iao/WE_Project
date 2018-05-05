using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Text;
using Newtonsoft.Json;

namespace WE_Project.Web.FD.Handler
{
    /// <summary>
    /// EPBuy 的摘要说明
    /// </summary>
    public class FDBuyList : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = " '1'='1' ";
            string mKey = "";
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                strWhere += " and BuyFDName='" + context.Request["tState"] + "' ";
            }
            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                mKey = context.Request["mKey"];
            }
            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and BuyDate>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                strWhere += " and BuyDate<'" + context.Request["endDate"] + " 23:59:59' ";
            }
            if (!TModel.Role.IsAdmin)
            {
                mKey = TModel.MID;
            }
            if (!string.IsNullOrEmpty(mKey))
            {
                strWhere += " and BuyMID='" + mKey + "' ";
            }
            int count;
            List<Model.FDBuyList> FDBuyList = BLL.FDBuyList.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < FDBuyList.Count; i++)
            {
                sb.Append(FDBuyList[i].BuyID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(FDBuyList[i].BuyMID + "~");
                sb.Append(FDBuyList[i].BuyCount + "~");
                sb.Append(FDBuyList[i].BuyPrice + "~");
                sb.Append(FDBuyList[i].BuyMoney + "~");
                sb.Append(WE_Project.BLL.Reward.List[FDBuyList[i].MoneyType].RewardName + "~");
                sb.Append((FDBuyList[i].CFState ? "已拆分" : "未拆分") + "~");
                sb.Append(FDBuyList[i].BuyFDName + "盘~");
                sb.Append(FDBuyList[i].BuyStateStr + "~");
                sb.Append(FDBuyList[i].BuyDate.ToString("yyyy-MM-dd HH:mm"));
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}