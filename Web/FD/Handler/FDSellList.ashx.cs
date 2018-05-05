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
    public class FDSellList : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = " '1'='1' ";
            string mKey = "";
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                strWhere += " and SellFDName='" + context.Request["tState"] + "' ";
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
                strWhere += " and SellMID='" + mKey + "' ";
            }
            int count;
            List<Model.FDSellList> FDSellList = BLL.FDSellList.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < FDSellList.Count; i++)
            {
                Model.FDBuyList model = BLL.FDBuyList.GetModel(FDSellList[i].BuyID);
                if (model == null)
                    model = new Model.FDBuyList { BuyCount = 0 };
                sb.Append(FDSellList[i].SellID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(FDSellList[i].SellMID + "~");
                sb.Append(model.BuyCount + "~");
                sb.Append(FDSellList[i].SellTotalCount + "~");
                sb.Append(FDSellList[i].SellPrice + "~");
                sb.Append(FDSellList[i].SellCount + "~");
                sb.Append(FDSellList[i].SellMoney + "~");
                sb.Append(FDSellList[i].SellFDName + "盘~");
                sb.Append(FDSellList[i].BuyDate.ToString("yyyy-MM-dd HH:mm") + "~");
                sb.Append(FDSellList[i].LastSellDate.ToString("yyyy-MM-dd HH:mm"));
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}