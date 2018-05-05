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
    /// TXList 的摘要说明
    /// </summary>
    public class ActiveCodeList2 : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string type = "";
            string mkey = "";
            string strWhere = " '1'='1' ";
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                type = context.Request["tState"];
            }
            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                mkey = context.Request["mKey"];
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
                mkey = memberModel.MID;
            int count = 0;
            StringBuilder sb = new StringBuilder();
            List<Model.ChangeMoney> ListChangeMoney;
            if (type == "zc")
            {
                ListChangeMoney = BllModel.GetChangeMoneyEntityList(mkey, "", "", "", new List<string> { "Active" }, new List<string> { "Active" }, pageIndex, pageSize, strWhere, out count);

                for (int i = 0; i < ListChangeMoney.Count; i++)
                {
                    Model.Member member = BllModel.GetModel(ListChangeMoney[i].ToMID);
                    Model.Member member2 = BllModel.GetModel(ListChangeMoney[i].FromMID);
                    sb.Append(ListChangeMoney[i].CID + "~");
                    sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                    sb.Append(ListChangeMoney[i].FromMID + "~");
                    sb.Append(member2.MName + "~");
                    sb.Append(ListChangeMoney[i].ToMID + "~");
                    sb.Append(member.MName + "~");
                    sb.Append(ListChangeMoney[i].ChangeDate.ToString("yyyy-MM-dd HH:mm") + "~");
                    sb.Append(ListChangeMoney[i].CRemarks);
                    sb.Append("≌");
                }
            }
            else if (type == "zr")
            {
                ListChangeMoney = BllModel.GetChangeMoneyEntityList("", mkey, "", "", new List<string> { "Active" }, new List<string> { "Active" }, pageIndex, pageSize, strWhere, out count);

                for (int i = 0; i < ListChangeMoney.Count; i++)
                {
                    Model.Member member = BllModel.GetModel(ListChangeMoney[i].FromMID);
                    Model.Member member2 = BllModel.GetModel(ListChangeMoney[i].ToMID);
                    sb.Append(ListChangeMoney[i].CID + "~");
                    sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                    sb.Append(ListChangeMoney[i].ToMID + "~");
                    sb.Append(member2.MName + "~");
                    sb.Append(ListChangeMoney[i].FromMID + "~");
                    sb.Append(member.MName + "~");
                    sb.Append(ListChangeMoney[i].ChangeDate.ToString("yyyy-MM-dd HH:mm") + "~");
                    sb.Append(ListChangeMoney[i].CRemarks);
                    sb.Append("≌");
                }
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}