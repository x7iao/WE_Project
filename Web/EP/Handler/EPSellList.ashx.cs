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
    /// EPBuy 的摘要说明
    /// </summary>
    public class EPSellList : BaseHandler
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
                strWhere += " and SellMID = '" + TModel.MID + "'";
            }
            int count;
            List<Model.EPList> EPList = BLL.EPList.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < EPList.Count; i++)
            {
                Model.Member member = BllModel.GetModel(EPList[i].SellMID);
                sb.Append(EPList[i].EPID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(Math.Round(EPList[i].Money, 2)+EPList[i].TakeOffMoney + "~");

                sb.Append(WE_Project.BLL.Reward.List[EPList[i].MoneyType].RewardName + "~");
                sb.Append(Math.Round(EPList[i].Money * BLL.Configuration.Model.OutFloat, 2) + "~");
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


                sb.Append(EPList[i].SellDate + "~");
                sb.Append(EPList[i].BuyMID + "~");
                sb.Append(EPList[i].BuyDate + "~");
                if (EPList[i].SellState == 0)
                {
                    sb.Append("<a href='javascript:void(0)' onclick=\"RunAjaxByList11('false','EPDelete','" + EPList[i].EPID + "')\">[取消]</a>");
                }
                else if (EPList[i].SellState == 1)
                {
                    sb.Append("等待买家付款");
                }
                else if (EPList[i].SellState == 2)
                {
                    //sb.Append("<a href='javascript:void(0)' onclick=\"RunAjaxByList11('false','EPsellLast','" + EPList[i].EPID + "')\">[确认收款]</a>|<a href='javascript:void(0)' onclick=\"RunAjaxByList11('false','EPClose','" + EPList[i].EPID + "')\">[关闭交易]</a>");
                    sb.Append("<a href='javascript:void(0)' onclick=\"RunAjaxByList11('false','EPsellLast','" + EPList[i].EPID + "')\">[确认收款]</a>");
                }
                else if (EPList[i].SellState == 3)
                {
                    sb.Append("已完成");
                }
                else if (EPList[i].SellState == 4)
                {
                    sb.Append("已关闭");
                }
                sb.Append("≌");
                sb.Append("@");
                //数量
                sb.Append("8");
                sb.Append("@");
                //内容(买家信息)
                var buyModel = BLL.Member.GetModelByMID(EPList[i].BuyMID);
                if (buyModel != null)
                {
                    sb.AppendFormat("信用等级:" + buyModel.MConfig.EPXingJiStr);
                    sb.AppendFormat("<br />提现方式:" + buyModel.Bank);
                    sb.AppendFormat("<br />开户支行:" + buyModel.Branch);
                    sb.AppendFormat("<br />开户姓名:" + buyModel.BankCardName);
                    sb.AppendFormat("<br />开户帐号:" + buyModel.BankNumber);
                    sb.AppendFormat("<br />手机号码:" + buyModel.Tel);
                    sb.AppendFormat("<br />QQ:" + buyModel.QQ);
                }
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}