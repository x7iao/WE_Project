using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.SessionState;
using Newtonsoft.Json;

namespace WE_Project.Web.Handler
{
    /// <summary>
    /// JJList 的摘要说明
    /// </summary>
    public class DayLiuShui : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string mKey = "";
            string strWhere = " '1'='1' ";
            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                mKey = context.Request["mKey"];
            }
            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and changedate>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                strWhere += " and changedate<'" + context.Request["endDate"] + " 23:59:59' ";
            }

            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            if (!memberModel.Role.IsAdmin)
                mKey = memberModel.MID;
            strWhere += string.Format(" and (FromMID='{0}' or ToMID='{0}') ", mKey);


            List<Model.ChangeMoney> ListChangeMoney = BllModel.GetChangeMoneyEntityList(strWhere + " order by ChangeDate desc");

            StringBuilder sb = new StringBuilder();
            for (int i = (pageIndex - 1) * pageSize; i < ListChangeMoney.Count && i < pageIndex * pageSize; i++)
            {
                Model.Member member = BllModel.GetModel(mKey);

                sb.Append(ListChangeMoney[i].CID + "~");
                sb.Append(i + 1 + "~");
                sb.Append(member.MID + "~");
                sb.Append(member.MName + "~");
                sb.Append((ListChangeMoney[i].FromMID == member.MID ? "<b style='color:red;'>支出</b>" : "<b style='blue'>收入</b>") + "~");
                sb.Append(ListChangeMoney[i].Money + "~");
                sb.Append((ListChangeMoney[i].CState ? "已生效" : "未生效") + "~");
                sb.Append(ListChangeMoney[i].ChangeTypeStr + "~");
                sb.Append(ListChangeMoney[i].ChangeDate.ToString("yyyy-MM-dd HH:mm"));
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = ListChangeMoney.Count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}