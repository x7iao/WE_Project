using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Newtonsoft.Json;
using System.Text;


namespace WE_Project.Web.Handler
{
    /// <summary>
    /// SYBDetail 的摘要说明
    /// </summary>
    public class SYBDetail : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            List<string> cTypeList = new List<string>();
            List<string> mTypeList = new List<string> { "MHB", "MJB", "MGP", "MCW" };
            string mKey = "", shmKey = "", cState = "";
            string strWhere = " '1'='1' ";
            //if (!string.IsNullOrEmpty(context.Request["typeList"]))
            //{
            //    string types = context.Request["typeList"].Remove(context.Request["typeList"].Length - 1);
            //}
            cTypeList = new List<string> { "SYB" };
            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                mKey = context.Request["mKey"];
            }
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                cState = context.Request["tState"];
            }
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
                //if (shmid != ListChangeMoney[i].SHMID)
                //{
                //    shmid = ListChangeMoney[i].SHMID;
                //    if (i != 0)
                //    {
                //        sb.Append("~~~~~~~~~≌");
                //    }
                //}
                sb.Append(ListChangeMoney[i].CID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                if (TModel.Role.IsAdmin)
                {
                    sb.Append(member.MID + "~");
                    sb.Append(member.MAgencyType.MAgencyName + "~");
                }
                if (ListChangeMoney[i].ChangeType == "ZZB")
                    sb.Append(ListChangeMoney[i].Money + "(手续费" + ListChangeMoney[i].TakeOffMoney.ToString() + ")" + "~");
                else
                    sb.Append(ListChangeMoney[i].Money + "~");
                //sb.Append(ListChangeMoney[i].TakeOffMoney+ "~");
                //sb.Append(ListChangeMoney[i].MCWMoney + "~");
                //sb.Append(ListChangeMoney[i].ReBuyMoney+ "~");
                //sb.Append(ListChangeMoney[i].ReBuyMoney + "~");
                sb.Append(ListChangeMoney[i].ChangeTypeStr + "~");
                string JJsource = (ListChangeMoney[i].ChangeType == "DFH" || ListChangeMoney[i].ChangeType == "PY" || ListChangeMoney[i].ChangeType == "TJ" || ListChangeMoney[i].ChangeType == "DP") ? ListChangeMoney[i].CRemarks + "~" : ListChangeMoney[i].SHMID + "~";
                sb.Append(JJsource);
                sb.Append((ListChangeMoney[i].CState ? "已生效" : "未生效") + "~");
                sb.Append(ListChangeMoney[i].ChangeDate.ToString("yyyy-MM-dd HH:mm"));
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}