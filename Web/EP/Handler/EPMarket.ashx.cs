using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Text;
using Newtonsoft.Json;

namespace WE_Project.Web.EP.Handler
{
    /// <summary>
    /// EPMarket 的摘要说明
    /// </summary>
    public class EPMarket : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = " 1=1 ";
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                strWhere += " and SellState = " + context.Request["tState"] + " ";
            }
            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                strWhere += " and SellMID='" + context.Request["mKey"] + "' ";
            }
            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and SellDate>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                strWhere += " and SellDate<'" + context.Request["endDate"] + " 23:59:59' ";
            }
            if (TModel.MID != "admin")
            {
                strWhere += " and BuyMID = '" + TModel.MID + "'";
            }
            int count;
            List<Model.EPList> EPList = BLL.EPList.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < EPList.Count; i++)
            {
                Model.Member member = BllModel.GetModel(EPList[i].SellMID);
                sb.Append(EPList[i].EPID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append("EP" + "~");
                sb.Append(Math.Round(EPList[i].Money, 2) + "~");
                sb.Append(Math.Round(EPList[i].Money * BLL.Configuration.Model.OutFloat, 2) + "~");
                sb.Append(EPList[i].SellDate + "~");
                sb.Append(EPList[i].SellMID + "~");
                sb.Append(member.MConfig.EPXingJiStr + "~");

                //卖家银行信息
                string bank = member.Bank, bankBranch = member.Branch, bankNum = member.BankNumber, bankName = member.BankCardName;
                Model.BankModel ban = BLL.BankModel.GetList("MID='" + member.MID + "' and IsPrimary=1").FirstOrDefault();
                if (ban != null)
                {
                    bank = new CommonBLL.Sys_BankInfoBLL().GetModel(ban.Bank).Name;
                    bankBranch = ban.Branch;
                    bankNum = ban.BankNumber;
                    bankName = ban.BankCardName;
                }
                sb.Append(bank + "~");
                sb.Append(bankBranch + "~");
                sb.Append(bankNum + "~");
                sb.Append(bankName + "~");
                //end

                sb.Append(EPList[i].BuyDate + "~");
                if (EPList[i].SellState == 1)
                {
                    sb.Append("<a href='javascript:void(0)' onclick=\"RunAjaxByList11('false','EPpay','" + EPList[i].EPID + "')\">[确认付款]</a>    <a href='javascript:void(0)' onclick=\"RunAjaxByList11('false','EPcancel','" + EPList[i].EPID + "')\">[取消]</a>");
                }
                else if (EPList[i].SellState == 3)
                {
                    sb.Append("已完成");
                }
                else if (EPList[i].SellState == 4)
                {
                    sb.Append("已关闭");
                }
                else
                {
                    sb.Append("等待卖家确认");
                }
                sb.Append("≌");
                sb.Append("@");
                //数量
                sb.Append("8");
                sb.Append("@");
                //内容(买家信息)
                var buyModel = BLL.Member.GetModelByMID(EPList[i].SellMID);
                if (buyModel != null)
                {
                    sb.AppendFormat("信用等级:" + buyModel.MConfig.EPXingJiStr);

                    string lbBank = "", lbBankCardName = "", lbBankNumber = "", lbBranch = "";
                    IList<Model.BankModel> list = BLL.BankModel.GetList("MID='" + buyModel.MID + "' and IsPrimary=1");
                    if (list != null && list.Count > 0)
                    {
                        Model.BankModel bankModel = list[0];
                        if (bankModel != null)
                        {
                            lbBank = new CommonBLL.Sys_BankInfoBLL().GetModel(bankModel.Bank).Name;
                            lbBankCardName = bankModel.BankCardName;
                            lbBankNumber = bankModel.BankNumber;
                            lbBranch = bankModel.Branch;
                        }
                    }
                    sb.AppendFormat("<br />姓名:" + lbBankCardName);
                    sb.AppendFormat("<br />账号:" + lbBankNumber);
                    sb.AppendFormat("<br />开户银行:" + lbBank);
                    sb.AppendFormat("<br />开户支行:" + lbBranch);

                }
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}