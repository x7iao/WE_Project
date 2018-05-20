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
    public class JJList : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            List<string> cTypeList = new List<string>();
            List<string> mTypeList = new List<string> { "MHB", "MJB", "MGP", "MCW", "CTB", "CTD" };
            string mKey = "", shmKey = "", cState = "";
            string strWhere = " '1'='1' ";
            if (!string.IsNullOrEmpty(context.Request["typeList"]))
            {
                string types = context.Request["typeList"].Remove(context.Request["typeList"].Length - 1);
                cTypeList = new List<string>(types.Split('|'));
                cTypeList.Add("TJKF");
            }
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
            if (!string.IsNullOrEmpty(cState))
            {
                strWhere += " and ChangeType ='" + cState + "' ";
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

            if (!string.IsNullOrEmpty(context.Request["countdate"]))
            {
                strWhere += " and changedate>'" + context.Request["countdate"] + " 00:00:00'  and changedate<'" + context.Request["countdate"] + " 23:59:59'";
            }

            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            if (!memberModel.Role.IsAdmin)
            {
                mKey = memberModel.MID;
                //cState = "true";
            }
            int count;
            string toMID = mKey;
            string fromMID = BLL.Member.ManageMember.TModel.MID;
            if (cState == "TJKF")
            {
                toMID = BLL.Member.ManageMember.TModel.MID;
                fromMID = mKey;
            }
            List<Model.ChangeMoney> ListChangeMoney = BllModel.GetChangeMoneyEntityList(fromMID, toMID, shmKey, cState, cTypeList, mTypeList, pageIndex, pageSize, strWhere, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListChangeMoney.Count; i++)
            {
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

                if (ListChangeMoney[i].ChangeType == "TJKF")
                {
                    if (TModel.Role.IsAdmin)
                    {
                        Model.Member member = BllModel.GetModel(ListChangeMoney[i].FromMID);
                        sb.Append(member.MID + "~");
                        sb.Append(member.MAgencyType.MAgencyName + "~");
                    }
                    sb.Append("-" + Math.Round(ListChangeMoney[i].Money, 2) + "~");
                }
                else
                {
                    if (TModel.Role.IsAdmin)
                    {
                        Model.Member member = BllModel.GetModel(ListChangeMoney[i].ToMID);
                        sb.Append(member.MID + "~");
                        sb.Append(member.MAgencyType.MAgencyName + "~");
                    }
                    sb.Append(Math.Round(ListChangeMoney[i].Money, 6) + "~");
                }
                //sb.Append(Math.Round(ListChangeMoney[i].TakeOffMoney, 2) + "~");
                //sb.Append(ListChangeMoney[i].TakeOffMoney+ "~");
                //sb.Append(ListChangeMoney[i].MCWMoney + "~");
                //sb.Append(ListChangeMoney[i].ReBuyMoney+ "~");
                //sb.Append(ListChangeMoney[i].ReBuyMoney + "~");
                sb.Append(ListChangeMoney[i].ChangeTypeStr + "~");
                string JJsource = (!string.IsNullOrEmpty(ListChangeMoney[i].CRemarks)) ? ListChangeMoney[i].CRemarks + "~" : ListChangeMoney[i].SHMID + "~";
                sb.Append(JJsource);
                sb.Append((ListChangeMoney[i].CState ? "已生效" : "未生效") + "~");
                sb.Append(ListChangeMoney[i].ChangeDate.ToString("yyyy-MM-dd HH:mm"));
                if (!ListChangeMoney[i].CState)
                {
                    //sb.Append(RemainLeaveTime(ListChangeMoney[i].ChangeDate, BLL.Configuration.Model.DFHOutCount));
                    string button = "<input onclick=\"TQJJ(" + ListChangeMoney[i].CID + ")\" class=\"btn btn-success\" value=\"提取奖金\" type=\"button\">";
                    //if (ListChangeMoney[i].ToMID != TModel.MID)
                    //{
                    //    button = "<span style=\"color:red;\">等待提取</span>";
                    //}
                    sb.Append(DateDiffStr(DateDiffType.MI, ListChangeMoney[i].ChangeDate, BLL.MMMConfig.Model.GLRewardFreezeTimes, "倒计时:", button));
                }
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}