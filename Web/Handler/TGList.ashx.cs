using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Newtonsoft.Json;

namespace WE_Project.Web.Handler
{
    /// <summary>
    /// FDSendList 的摘要说明
    /// </summary>
    public class TGList : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            List<string> cTypeList = new List<string>();
            List<string> mTypeList = new List<string> { "MHB" };
            string mKey = "", shmKey = "", cState = "";
            string strWhere = " '1'='1' ";

            string types = "TG";
            cTypeList = new List<string>(types.Split('|'));

            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                mKey = context.Request["mKey"];
            }
            //if (!string.IsNullOrEmpty(context.Request["tState"]))
            //{
            //    cState = context.Request["tState"];
            //}
            if (!string.IsNullOrEmpty(context.Request["txtKey"]))
            {
                shmKey = context.Request["txtKey"];
            }
            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and changedate>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                strWhere += " and changedate<'" + context.Request["endDate"] + " 23:59:59' ";
            }
            if (!string.IsNullOrEmpty(context.Request["moneyType"]))
            {
                mTypeList = new List<string> { context.Request["moneyType"] };
            }

            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            if (!memberModel.Role.IsAdmin)
            {
                mKey = memberModel.MID;
                cState = "true";
            }
            int count;
            List<Model.ChangeMoney> ListChangeMoney = BllModel.GetChangeMoneyEntityList(BLL.Member.ManageMember.TModel.MID, mKey, shmKey, cState, cTypeList, mTypeList, pageIndex, pageSize, strWhere, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListChangeMoney.Count; i++)
            {
                Model.Member member = BllModel.GetModel(ListChangeMoney[i].ToMID);
                sb.Append(ListChangeMoney[i].CID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(member.MID + "~");
                sb.Append(ListChangeMoney[i].ChangeDate.ToString("yyyy-MM-dd HH:mm") + "~");
                sb.Append(ListChangeMoney[i].Money + "~");
                sb.Append((ListChangeMoney[i].CState ? "已生效" : "未生效") + "~");
                sb.Append(ListChangeMoney[i].CRemarks);
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}