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
    public class HTSJList : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            List<string> typeList = new List<string>() { "SJ" };
            List<string> mType = new List<string> { "MJB" };
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

            int count;
            List<Model.ChangeMoney> ListChangeMoney = BllModel.GetChangeMoneyEntityList(mKey, BLL.Member.ManageMember.TModel.MID, "", "true", typeList, mType, pageIndex, pageSize, strWhere, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListChangeMoney.Count; i++)
            {
                Model.Member member = BllModel.GetModel(ListChangeMoney[i].FromMID);
                sb.Append(ListChangeMoney[i].CID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(member.MID + "~");
                sb.Append(member.MName + "~");
                sb.Append(member.Tel + "~");
                sb.Append(member.MAgencyType.MAgencyName + "~");
                sb.Append(ListChangeMoney[i].CRemarks + "~");
                sb.Append((ListChangeMoney[i].CState ? "已生效" : "未生效") + "~");
                sb.Append(ListChangeMoney[i].ChangeDate.ToString("yyyy-MM-dd HH:mm"));
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}