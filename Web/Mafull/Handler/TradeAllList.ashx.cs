using System;
using System.Text;
using System.Web;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;

namespace WE_Project.Web.Mafull.Handler
{
    public class MMMModel
    {
        public string code;
        public DateTime time;
        public string mid;
        public int type;
        public decimal money;
        public int status;
    }

    /// <summary>
    /// TradeAllList 的摘要说明
    /// </summary>
    public class TradeAllList : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);

            string type = context.Request["type"];
            string result = "";

            if (type == "1")
            {
                result = tradingGet();
            }
            else if (type == "2")
            {
                result = tradingOff();
            }
            else if (type == "3")
            {
                result = helpList();
            }
            context.Response.Write(result);
        }

        # region 匹配列表

        private string tradingGet()
        {
            var listmatch = BLL.MHelpMatch.GetList(" GetMID='" + TModel.MID + "' and MatchState <> 3 ");
            StringBuilder strText = new StringBuilder();
            foreach (var match in listmatch)
            {
                strText.Append(CreateMatchHtml(match));
            }
            return strText.ToString();
        }

        private string tradingOff()
        {
            var listmatch = BLL.MHelpMatch.GetList(" OfferMID='" + TModel.MID + "' and MatchState <> 3 ");
            StringBuilder strText = new StringBuilder();
            foreach (var match in listmatch)
            {
                strText.Append(CreateMatchHtml(match));
            }
            return strText.ToString();
        }

        private string CreateMatchHtml(Model.MHelpMatch match)
        {
            StringBuilder strText = new StringBuilder();
            strText.AppendFormat("<tr>");
            strText.AppendFormat("<td>");
            strText.AppendFormat("<img src=\"/admin/images/check.png\" /><br/>");
            strText.AppendFormat("{0}", match.MatchCode);
            strText.AppendFormat("</td>");
            strText.AppendFormat("<td>");
            strText.AppendFormat("{0}", GetMatchState(match.MatchState, ""));
            strText.AppendFormat("</td>");
            strText.AppendFormat("<td>");
            strText.AppendFormat("配对时间{0}<br><b style=\"color: red\">{1}</b>", match.MatchTime.ToString("yyyy-MM-dd HH:mm:ss"), MatchTimeLeave(match, match.MatchState == 1 ? MMMMatchTimeType.PayLimitTime : MMMMatchTimeType.ConfirmLimitTime, match.MatchState == 1 ? "剩余打款时间:" : "剩余收款时间:", "已截止"));
            strText.AppendFormat("</td>");
            strText.AppendFormat("<td>");
            strText.AppendFormat("{0}", match.OfferMID);
            strText.AppendFormat("</td>");
            strText.AppendFormat("<td>");
            strText.AppendFormat("{0}", match.MatchMoney.ToString("F2"));
            strText.AppendFormat("</td>");
            strText.AppendFormat("<td>");
            strText.AppendFormat("{0}", match.GetMID);
            strText.AppendFormat("</td>");
            strText.AppendFormat("<td>");
            strText.AppendFormat("<button type=\"button\" class=\"liuyan\" onclick=\"chat('" + match.MatchCode + "')\">聊天</button>");
            strText.AppendFormat("<button type=\"button\" class=\"liuyan2\" onclick=\"callhtml('../Mafull/MatchView.aspx?id={0}','详细资料');onclickmenu();\">详细资料</button>", match.Id);
            strText.AppendFormat(GetStatus1(match));
            strText.AppendFormat("</td>");
            strText.AppendFormat("</tr>");
            return strText.ToString();
        }

        private string GetMMMModelStatus(string type)
        {
            if (type == "0")
            {
                return "等待匹配";
            }
            else if (type == "1" || type == "2")
            {
                return "<b style=\"color: #dfa601; text-decoration: underline\">匹配成功</b>";
            }
            else
            {
                return "申请被处理了";
            }
        }

        /// <summary>
        /// 获取状态
        /// </summary>
        private string GetStatus1(Model.MHelpMatch match)
        {
            StringBuilder strText = new StringBuilder();
            if (match.MatchState == 1 && match.OfferMID == TModel.MID)
            {//付钱
                strText.AppendFormat("<input type=\"button\" class=\"liuyan3\" value=\"去付款\" onclick=\"callhtml('../Mafull/PayMoney.aspx?id=" + match.Id + "','我要付款');\">");
            }
            else if (match.MatchState == 2 && match.GetMID == TModel.MID)
            {//收钱
                strText.AppendFormat("<input type=\"button\" class=\"liuyan3\" value=\"去收款\" onclick=\"callhtml('../Mafull/GetMoney.aspx?id=" + match.Id + "','确认收款');\">");
            }
            //else
            //{//查看
            //    strText.AppendFormat("<input type=\"button\" value=\"查看详情\" onclick=\"callhtml('../Mafull/MatchView.aspx?id=" + match.Id + "','匹配详情');\">");
            //}
            return strText.ToString();
        }

        /// <summary>
        /// 获取状态
        /// </summary>
        private string GetStatus(Model.MHelpMatch match)
        {
            StringBuilder strText = new StringBuilder();
            if (match.MatchState == 1 && match.OfferMID == TModel.MID)
            {//付钱
                strText.AppendFormat("<div class=\"money_btn\">");
                strText.AppendFormat("{0}", GetPayDirection(match));
                strText.AppendFormat("<input type=\"button\" value=\"去付款\" onclick=\"callhtml('../Mafull/PayMoney.aspx?id=" + match.Id + "','我要付款');\">");
            }
            else if (match.MatchState == 2 && match.GetMID == TModel.MID)
            {//收钱
                strText.AppendFormat("<div class=\"money_btn1\">");
                strText.AppendFormat("{0}", GetPayDirection(match));
                strText.AppendFormat("<input type=\"button\" value=\"去收款\" onclick=\"callhtml('../Mafull/GetMoney.aspx?id=" + match.Id + "','确认收款');\">");
            }
            else
            {//查看
                strText.AppendFormat("<div class=\"money_btn2\">");
                strText.AppendFormat("{0}", GetPayDirection(match));
                strText.AppendFormat("<input type=\"button\" value=\"查看详情\" onclick=\"callhtml('../Mafull/MatchView.aspx?id=" + match.Id + "','匹配详情');\">");
            }
            return strText.ToString();
        }

        /// <summary>
        /// 获取付款去向
        /// </summary>
        private string GetPayDirection(Model.MHelpMatch match)
        {
            StringBuilder strText = new StringBuilder();
            strText.AppendFormat("<span>{0}&nbsp;>&nbsp;{1}&nbsp;>&nbsp;{2}</span>", IsMySelf(match.OfferMID, TModel.MID), match.MatchMoney.ToString("F2"), IsMySelf(match.GetMID, TModel.MID));
            return strText.ToString();
        }

        /// <summary>
        /// 是否是本人
        /// </summary>
        private string IsMySelf(string MID, string MyMID)
        {
            if (MID == MyMID)
            {
                return "您";
            }
            else
            {
                return MID;
            }
        }

        /// <summary>
        /// 获取收款方信息
        /// </summary>
        private string GetBankModel(Model.MHelpMatch match)
        {
            StringBuilder strText = new StringBuilder();
            Model.Member member = BLL.Member.GetModelByMID(match.GetMID);
            if (member != null)
            {
                strText.AppendFormat("<label>开户银行：<span>{0}</span></label>", member.Bank);
                strText.AppendFormat("<label>开户名：<span>{0}</span></label>", member.BankCardName);
                strText.AppendFormat("<label>开户支行：<span>{0}</span></label>", member.Branch);
                strText.AppendFormat("<label>银行账号：<span>{0}</span></label>", member.BankNumber);
                strText.AppendFormat("<label>手机号码：<span>{0}</span></label>", member.Tel);
            }
            return strText.ToString();
        }

        /// <summary>
        /// 判断是获得帮助还是提供帮助
        /// </summary>
        private string GetClass(Model.MHelpMatch match)
        {
            if (match.GetMID == TModel.MID)
            {
                return "get";
            }
            else
            {
                return "put";
            }
        }

        # endregion 匹配列表

        # region 申请列表

        private string helpList()
        {
            DataTable table = BLL.CommonBase.GetTable(@"select * from (" +
                                           "select Id,SQCode,SQMID,SQMoney,MatchMoney,SQDate,PPState,'1' mtype from MOfferHelp where SQMID='" + TModel.MID + "' and PPState < 3 and HelpType in(0,1) " +
                                           " union " +
                                           "select Id,SQCode,SQMID,SQMoney,MatchMoney,SQDate,PPState,'2' mtype from MGetHelp where SQMID='" + TModel.MID + "' and PPState < 3 ) a order by SQDate desc");
            StringBuilder strText = new StringBuilder();
            foreach (DataRow row in table.Rows)
            {
                strText.AppendFormat("<div class=\"{0}\">", (row["mtype"].ToString() == "1" ? "ordin1_button" : "ordinn_button"));
                strText.AppendFormat("<div class=\"apply001\">");
                strText.AppendFormat("<img src=\"admin/images/strelka32.png\"/>");
                strText.AppendFormat("<div class=\"ord_title\">");
                strText.AppendFormat("<span>{0}：</span><br />", (row["mtype"].ToString() == "1" ? "提供帮助" : "获得帮助"));
                strText.AppendFormat("<span>{0}</span>", row["SQCode"]);
                strText.AppendFormat("</div>");
                strText.AppendFormat("</div>");
                strText.AppendFormat("<div class=\"ord_body_info\">");
                strText.AppendFormat("<span>参加者：</span><span>{0}</span><br />", row["SQMID"]);
                strText.AppendFormat("<span>金额：</span> <span>{0}</span><br />", row["SQMoney"]);
                strText.AppendFormat("<span>日期：</span> <span>{0}</span><br />", row["SQDate"]);
                strText.AppendFormat("<span>状态：</span> <span>{0}</span>", GetMMMModelStatus(row["PPState"].ToString()));
                strText.AppendFormat("</div>");
                strText.AppendFormat("</div>");
            }
            return strText.ToString();
        }

        # endregion 申请列表
    }
}