using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace WE_Project.Web.FuTou.Handler
{
    /// <summary>
    /// FTList 的摘要说明
    /// </summary>
    public class FTList : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = " 1 = 1 ";

            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                if (context.Request["tState"] == "true")
                {
                    strWhere += " and BMState = 1 ";
                }
                else
                {
                    strWhere += " and BMState = 0 ";
                }
            }

            if (TModel.Role.Super)
            {
                if (!string.IsNullOrEmpty(context.Request["mKey"]))
                {
                    strWhere += string.Format(" and AMID='{0}' ", (context.Request["mKey"]));
                }
            }
            else
            {
                strWhere += string.Format(" and AMID='{0}' ", TModel.MID);
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
            List<Model.BMember> ListMember = BLL.BMember.GetMoneyEntityList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListMember.Count; i++)
            {
                sb.Append(ListMember[i].ID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(ListMember[i].AMID + "~");
                sb.Append(ListMember[i].BMCreateDate.ToString("yyyy-MM-dd HH:mm") + "~");
                sb.Append(ListMember[i].YJCount.ToFixedString() + "颗~");
                sb.Append(BLL.Reward.List[ListMember[i].BMBD].RewardName + "~");
                //sb.Append(ListMember[i].FHDays + "~");
                sb.Append(ListMember[i].BOutMoney.ToString("f0") + "~");
                //sb.Append(ListMember[i].BCount + "~");
                sb.Append(ListMember[i].YJMoney*100 + "%~");
                sb.Append((ListMember[i].YJMoney*ListMember[i].YJCount) + "颗~");
                sb.Append((ListMember[i].BMState ? "出局" : "未出局")+"~");
                if (ListMember[i].BMCreateDate.AddDays(Convert.ToInt32(ListMember[i].BOutMoney))<=DateTime.Now&& ListMember[i].AMID==TModel.MID&&!ListMember[i].BMState)
                {
                    sb.Append("<input type='button' value='我要提款' class='btn btn-danger btn-sm' onclick=\"GetTranMoney(" + ListMember[i].ID + ",this)\" />");
                }
                
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}