using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Text;
namespace WE_Project.Web.Mafull.Handler
{
    /// <summary>
    /// TradeList 的摘要说明
    /// </summary>
    public class TradeList : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);

            string type = context.Request["type"];
            string result = "";

            if (type == "1")
            {
                result = trading();
            }
            else if (type == "2")
            {
                result = selled();
            }
            else if (type == "3")
            {
                result = buy();
            }
            context.Response.Write(result);
        }

        private string trading()
        {
            var offerList = BLL.MOfferHelp.GetList(" SQMID = '" + TModel.MID + "'and PPState < 3 and PPState <> 0 and HelpType <> 99 order by SQDate desc ");
            var getList = BLL.MGetHelp.GetList(" SQMID = '" + TModel.MID + "'and PPState < 3 and PPState <> 0 and HelpType <> 99 order by SQDate desc  ");
            StringBuilder strText = new StringBuilder();
            foreach (var model in offerList)
            {
                strText.Append(create_xlTab(model));
            }
            foreach (var model in getList)
            {
                strText.Append(create_xlTab(model));
            }
            return strText.ToString();
        }

        private string buy()
        {
            var offerList = BLL.MOfferHelp.GetList(" SQMID = '" + TModel.MID + "' and PPState <> 5 and PPState <> 0 and HelpType <> 99 order by SQDate desc ");
            //var offerList = BLL.MOfferHelp.GetList(" SQMID = '" + TModel.MID + "' ");
            StringBuilder strText = new StringBuilder();
            foreach (var model in offerList)
            {
                strText.Append(create_xlTab(model));
            }

            return strText.ToString();
        }

        private string selled()
        {
            var getList = BLL.MGetHelp.GetList(" SQMID = '" + TModel.MID + "' and PPState <> 5 and PPState <> 0 and HelpType <> 99 order by SQDate desc ");
            StringBuilder strText = new StringBuilder();
            foreach (var model in getList)
            {
                strText.Append(create_xlTab(model));
            }

            return strText.ToString();
        }

        private string create_xlTab(Model.MGetHelp get)
        {
            StringBuilder strText = new StringBuilder();
            strText.AppendFormat("<ul class=\"xlTab\">");
            strText.AppendFormat("<li class=\"parent\"><a href=\"javascript:void(0)\" class=\"iconmenu\">");
            strText.AppendFormat("<th>");
            strText.AppendFormat("时间日期：{0}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;订单总额:{1}元", get.SQDate.ToString("yyyy-MM-dd HH:mm:ss"), (get.SQMoney).ToString("F0"));
            strText.AppendFormat("</th>");
            strText.AppendFormat("</a>");
            strText.AppendFormat("<ul class=\"children collapse\">");
            # region 匹配记录
            var matchList = BLL.MHelpMatch.GetList(" GetId = " + get.Id + "  ");
            foreach (var model in matchList)
            {
                Model.Member member = BLL.Member.GetModelByMID(model.OfferMID);
                Model.Member Tmember = BLL.Member.GetModelByMID(model.GetMID);
                strText.AppendFormat("<li>");
                strText.AppendFormat("<table class=\"tab_table\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">");
                strText.AppendFormat("<thead class=\"tabcolor table table-bordered table-hover\"><tr><th>交易类型</th><th>会员姓名</th><th>匹配金额</th><th>当前状态</th><th>订单编号</th><th>对方信息</th></tr></thead>");
                strText.AppendFormat("<tbody><tr>");
                strText.AppendFormat("<td>{0}</td>", "得到帮助");
                strText.AppendFormat("<td>{0}</td>", Tmember.MName);
                strText.AppendFormat("<td>{0}</td>", (model.MatchMoney).ToString("F2"));
                strText.AppendFormat("<td><font>{0}</font></td>", GetStatus(model));
                strText.AppendFormat("<td>{0}</td>", model.MatchCode);
                strText.AppendFormat("<td><a href=\"javascript:void(0)\" onclick=\"v5.show('/Member/ViewMember.aspx?id={0}','打款人信息','url',360,240)\">打款人信息</td>", member.MID);
                strText.AppendFormat("</tr></tbody>");
                strText.AppendFormat("</table>");
                strText.Append(GetProgressBar(model));
            }
            strText.AppendFormat("</div></div></li>");
            # endregion
            strText.AppendFormat("</ul></li></ul>");
            return strText.ToString();
        }

        private string GetgetOperate(Model.MHelpMatch model)
        {
            StringBuilder sb = new StringBuilder();
            if (TModel.Role.IsAdmin)
                sb.Append("<input type='button' value='匹配详情' class='btn btn-info btn-sm' onclick=\"callhtml('../Mafull/MatchView.aspx?id=" + model.Id + "','匹配详细');\" />");
            else
            {
                if (model.MatchState == 2)
                {
                    sb.Append("<input type='button' class='btn btn-info btn-sm' onclick=\"callhtml('../Mafull/GetMoney.aspx?id=" + model.Id.ToString() + "','确认收款');\" value='确认收款>>' />");
                }
                else
                {
                    sb.Append("<input type='button' class='btn btn-info btn-sm' onclick=\"callhtml('../Mafull/MatchView.aspx?id=" + model.Id.ToString() + "','订单详情');\" value='查看详细>>' />");
                }
            }
            if (model.MatchState == 2)
            {
                if (TModel.Role.IsAdmin)
                {
                    if (string.IsNullOrEmpty(model.PicUrl1))
                        sb.Append("<input type='button' value='确认收款' class='btn btn-danger btn-sm' onclick=\"callhtml('../Mafull/GetMoney.aspx?id=" + model.Id + "','确认收款');\" />");
                    else
                        sb.Append("<input type='button' value='批准删除' class='btn btn-danger btn-sm' onclick=\"deleteMatch('" + model.Id + "')\" />");
                }
            }
            return sb.ToString();
        }

        private string GetStatus(Model.MHelpMatch model)
        {
            if (model.MatchState == 1)
            {
                return MatchTimeLeave(model, MMMMatchTimeType.PayLimitTime, "", "超时未付款");
            }
            else if (model.MatchState == 2)
            {
                return MatchTimeLeave(model, MMMMatchTimeType.ConfirmLimitTime, "", "超时未确认");
            }
            else if (model.MatchState == 3)
            {
                return "已完成";
            }
            else if (model.MatchState == 4)
            {
                return "已完成";
            }
            return "";
        }

        private string create_xlTab(Model.MOfferHelp offer)
        {
            StringBuilder strText = new StringBuilder();
            strText.AppendFormat("<ul class=\"xlTab\">");
            strText.AppendFormat("<li class=\"parent\"><a href=\"javascript:void(0)\" class=\"iconmenu\">");
            strText.AppendFormat("<th>");
            strText.AppendFormat("时间日期：{0}&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;订单总额:{1}元", offer.SQDate.ToString("yyyy-MM-dd HH:mm:ss"), (offer.SQMoney).ToString("F0"));
            strText.AppendFormat("</th>");
            strText.AppendFormat("</a>");
            strText.AppendFormat("<ul class=\"children collapse\">");
            # region 匹配记录
            var matchList = BLL.MHelpMatch.GetList(" OfferId = " + offer.Id + "  ");
            foreach (var model in matchList)
            {
                Model.Member member = BLL.Member.GetModelByMID(model.GetMID);
                Model.Member Fmember = BLL.Member.GetModelByMID(model.OfferMID);
                strText.AppendFormat("<li>");
                strText.AppendFormat("<table class=\"tab_table\" cellpadding=\"0\" cellspacing=\"0\" width=\"100%\">");
                strText.AppendFormat("<thead><tr><th>交易类型</th><th>会员姓名</th><th>匹配金额</th><th>当前状态</th><th>订单编号</th><th>对方信息</th></tr></thead>");
                strText.AppendFormat("<tbody><tr>");
                strText.AppendFormat("<td>{0}</td>", "买入许愿果");
                strText.AppendFormat("<td>{0}</td>", Fmember.MName);
                strText.AppendFormat("<td>{0}</td>", (model.MatchMoney).ToString("F2"));
                strText.AppendFormat("<td><font>{0}</font></td>", GetStatus(model));
                strText.AppendFormat("<td>{0}</td>", model.MatchCode);
                strText.AppendFormat("<td><a href=\"javascript:void(0)\" onclick=\"v5.show('/Member/ViewMember.aspx?id={0}','收款人信息','url',360,240)\">收款人信息</td>", member.MID);
                strText.AppendFormat("</tr></tbody>");
                strText.AppendFormat("</table>");
                strText.Append(GetProgressBar(model));
            }
            strText.AppendFormat("</div></div></li>");
            # endregion
            strText.AppendFormat("</ul></li></ul>");
            return strText.ToString();
        }

        private string GetofferOperate(Model.MHelpMatch model)
        {
            StringBuilder sb = new StringBuilder();
            if (TModel.Role.IsAdmin)
                sb.Append("<input type='button' value='匹配详情' class='btn btn-info btn-sm' onclick=\"callhtml('../Mafull/MatchView.aspx?id=" + model.Id + "','匹配详情');\" />");
            else
            {
                if (model.MatchState == 1)
                {
                    sb.Append("<input type='button' class='btn btn-info btn-sm' onclick=\"callhtml('../Mafull/PayMoney.aspx?id=" + model.Id.ToString() + "','订单付款');\" value='去付款>>'/>");
                }
                else
                {
                    sb.Append("<input type='button' class='btn btn-info btn-sm' onclick=\"callhtml('../Mafull/MatchView.aspx?id=" + model.Id.ToString() + "','订单详情');\" value='查看详细>>'/>");
                }
            }
            if (model.MatchState == 2)
            {
                if (TModel.Role.IsAdmin)
                {
                    sb.Append("<input type='button' value='删除' class='btn btn-danger btn-sm' onclick=\"deleteMatch('" + model.Id + "')\" />");
                }
            }

            return sb.ToString();
        }

        private string GetProgressBar(Model.MHelpMatch model)
        {
            StringBuilder strText = new StringBuilder();
            strText.AppendFormat("<div class=\"jd\"><span>交易进度</span>");
            strText.AppendFormat("<div class=\"silbar\">");
            if (model.MatchState == 1)
            {
                strText.AppendFormat("<label>");
                strText.AppendFormat("<b class=\"b1\">匹配成功</b></label>");
                strText.AppendFormat("<label>");
                if (model.OfferMID == TModel.MID)//买入许愿果
                {
                    if (!string.IsNullOrEmpty(MatchTimeLeave(model, MMMMatchTimeType.PayLimitTime, "", "")))
                    {
                        strText.AppendFormat("<b class=\"b2\"><a href=\"javascript:void(0)\" onclick=\"callhtml('../Mafull/PayMoney.aspx?id=" + model.Id.ToString() + "','订单付款');\">请及时打款</a></b></label>");
                    }
                    else
                    {
                        strText.AppendFormat("<b class=\"b2\"><a href=\"javascript:void(0)\">请及时打款</a></b></label>");
                    }
                }
                else
                {
                    strText.AppendFormat("<b class=\"b2\">等待对方付款</b></label>");
                }
                strText.AppendFormat("<label>");
                if (model.OfferMID == TModel.MID)
                {
                    strText.AppendFormat("<b class=\"b3\">等待收款人确认</b></label>");
                }
                else
                {
                    strText.AppendFormat("<b class=\"b3\">请及时确认</b></label>");
                }
                strText.AppendFormat("<label>");
                strText.AppendFormat("<b class=\"b4\">订单完成</b></label>");
            }
            else if (model.MatchState == 2)
            {
                strText.AppendFormat("<label>");
                strText.AppendFormat("<b class=\"b1\">匹配成功</b></label>");
                strText.AppendFormat("<label>");
                if (model.OfferMID == TModel.MID)//买入许愿果
                {
                    strText.AppendFormat("<b class=\"b22\">请及时打款</b></label>");
                }
                else
                {
                    strText.AppendFormat("<b class=\"b22\">等待对方付款</b></label>");
                }
                strText.AppendFormat("<label>");
                if (model.GetMID == TModel.MID)//买入许愿果
                {
                    if (!string.IsNullOrEmpty(MatchTimeLeave(model, MMMMatchTimeType.ConfirmLimitTime, "", "")))
                    {
                        strText.AppendFormat("<b class=\"b33\"><a href=\"javascript:void(0)\" onclick=\"callhtml('../Mafull/GetMoney.aspx?id=" + model.Id.ToString() + "','确认收款');\">请及时确认</a></b></label>");
                    }
                    else
                    {
                        strText.AppendFormat("<b class=\"b33\"><a href=\"javascript:void(0)\">请及时确认</a></b></label>");
                    }
                }
                else
                {
                    strText.AppendFormat("<b class=\"b33\">等待收款人确认</b></label>");
                }
                strText.AppendFormat("<label>");
                strText.AppendFormat("<b class=\"b4\">订单完成</b></label>");
            }
            else if (model.MatchState == 3 || model.MatchState == 4)
            {
                strText.AppendFormat("<label>");
                strText.AppendFormat("<b class=\"b1\">匹配成功</b></label>");
                strText.AppendFormat("<label>");
                if (model.OfferMID == TModel.MID)//买入许愿果
                {
                    strText.AppendFormat("<b class=\"b22\">请及时打款</b></label>");
                }
                else
                {
                    strText.AppendFormat("<b class=\"b22\">等待对方付款</b></label>");
                }
                strText.AppendFormat("<label>");
                if (model.OfferMID == TModel.MID)
                {
                    strText.AppendFormat("<b class=\"b333\">等待收款人确认</b></label>");
                }
                else
                {
                    strText.AppendFormat("<b class=\"b333\">请及时确认</b></label>");
                }
                strText.AppendFormat("<label>");
                strText.AppendFormat("<b class=\"b44\"><a href=\"javascript:void(0)\" onclick=\"callhtml('../Mafull/MatchView.aspx?id=" + model.Id.ToString() + "','查看详情');\">订单完成</a></b></label>");
            }
            strText.Append("</div>");
            return strText.ToString();
        }
    }
}