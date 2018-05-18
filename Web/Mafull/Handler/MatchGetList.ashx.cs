using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Newtonsoft.Json;

namespace WE_Project.Web.Mafull.Handler
{
    /// <summary>
    /// MatchList 的摘要说明
    /// </summary>
    public class MatchGetList : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = " 1=1 ";
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                string tState = context.Request["tState"];
                if (tState == "1")
                    strWhere += " and MatchState =1 ";
                else if (tState == "2")
                    strWhere += " and MatchState=2 ";
                else if (tState == "3")
                    strWhere += " and MatchState =3 ";
                else if (tState == "4")
                    strWhere += " and MatchState =2 and LEN(PicUrl1)>0 ";
            }
            if (!string.IsNullOrEmpty(context.Request["matchid"]))
            {
                strWhere += " and GetId=" + context.Request["matchid"] + " ";
            }
            if (!string.IsNullOrEmpty(context.Request["MatchCode"]))
            {
                strWhere += " and MatchCode=" + context.Request["MatchCode"] + " ";
            }
            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and MatchTime>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                strWhere += " and MatchTime<'" + context.Request["endDate"] + " 23:59:59' ";
            }

            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            if (!memberModel.Role.IsAdmin)
            {
                strWhere += " and GetMID ='" + memberModel.MID + "' ";
            }
            int count;
            List<Model.MHelpMatch> match = BLL.MHelpMatch.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < match.Count; i++)
            {
                Model.Member offermodel = BLL.Member.ManageMember.GetModel(match[i].OfferMID);
                Model.Member getmodel = BLL.Member.ManageMember.GetModel(match[i].GetMID);
                sb.Append(match[i].Id + "~");
                sb.Append(match[i].MatchCode + "~");
                sb.Append((match[i].MatchMoney + "(" + match[i].MatchMoney * 2000 + ")") + "~");
                sb.Append(match[i].MatchTime.ToString("yyyy-MM-dd HH:mm") + "~");
                sb.Append(GetMatchState(match[i].MatchState, match[i].PicUrl1) + "~");
                sb.Append(match[i].OfferMID + "~");
                sb.Append(offermodel.MName + "~");
                if (match[i].MatchState == 1)
                {
                    sb.Append(MatchTimeLeave(match[i], MMMMatchTimeType.PayLimitTime, "打款倒计时", ""));
                    sb.Append("~");
                    //if (match[i].MatchType == 1)
                    //{
                    //    sb.Append("打款倒计时：" + LeaveTime(match[i].MatchTime, BLL.MMMConfig.Model.PayLimitTimesPre) + "~");
                    //}
                    //else if (match[i].MatchType == 2)
                    //{
                    //    sb.Append("打款倒计时：" + LeaveTime(match[i].MatchTime, BLL.MMMConfigScramble.Model.PayLimitTimes) + "~");
                    //}
                    //else
                    //{
                    //    sb.Append("打款倒计时：" + LeaveTime(match[i].MatchTime, BLL.MMMConfig.Model.PayLimitTimes) + "~");
                    //}
                }
                else
                {
                    sb.Append(((DateTime)match[i].PayTime).ToString("yyyy-MM-dd HH:mm") + "~");
                }
                //if (match[i].MatchState == 1)
                //    sb.Append("打款倒计时：" + LeaveTime(match[i].MatchTime, BLL.MMMConfig.Model.PayLimitTimes) + "~");
                //else
                //    sb.Append(((DateTime)match[i].PayTime).ToString("yyyy-MM-dd HH:mm") + "~");
                sb.Append(match[i].GetMID + "~");
                sb.Append(getmodel.MName + "~");
                if (match[i].MatchState == 2)
                {
                    sb.Append(MatchTimeLeave(match[i], MMMMatchTimeType.ConfirmLimitTime, "收款确认倒计时", ""));
                    sb.Append("~");
                    //if (match[i].MatchType == 1)
                    //{
                    //    sb.Append("收款确认倒计时：" + LeaveTime((DateTime)match[i].PayTime, BLL.MMMConfig.Model.ConfirmLimitTimesPre) + "~");
                    //}
                    //else if (match[i].MatchType == 2)
                    //{
                    //    sb.Append("收款确认倒计时：" + LeaveTime((DateTime)match[i].PayTime, BLL.MMMConfigScramble.Model.ConfirmLimitTimes) + "~");
                    //}
                    //else
                    //{
                    //    sb.Append("收款确认倒计时：" + LeaveTime((DateTime)match[i].PayTime, BLL.MMMConfig.Model.ConfirmLimitTimes) + "~");
                    //}
                }
                else if (match[i].MatchState == 1)
                {
                    sb.Append("-~");
                }
                else
                {
                    sb.Append(((DateTime)match[i].ConfirmTime).ToString("yyyy-MM-dd HH:mm") + "~");
                }
                //if (match[i].MatchState == 2)
                //    sb.Append("收款确认倒计时：" + LeaveTime((DateTime)match[i].PayTime, BLL.MMMConfig.Model.ConfirmLimitTimes) + "~");
                //else if (match[i].MatchState == 1)
                //    sb.Append("-~");
                //else
                //    sb.Append(((DateTime)match[i].ConfirmTime).ToString("yyyy-MM-dd HH:mm") + "~");

                //操作
                if (TModel.Role.IsAdmin)
                {
                    sb.Append("<input type='button' value='匹配详情' class='btn btn-info btn-sm' onclick=\"callhtml('../Mafull/MatchView.aspx?id=" + match[i].Id + "','匹配详细');\" />");
                }
                else
                {
                    if (match[i].MatchState == 2)
                    {
                        if (!string.IsNullOrEmpty(MatchTimeLeave(match[i], MMMMatchTimeType.ConfirmLimitTime)))
                        {
                            sb.Append("<input type='button' class='btn btn-info btn-sm' onclick=\"callhtml('../Mafull/GetMoney.aspx?id=" + match[i].Id.ToString() + "','确认收款');\" value='确认收款>>' />");
                        }
                        //if (match[i].MatchType == 1 && (DateTime.Now - match[i].PayTime.Value).TotalMinutes <= BLL.MMMConfig.Model.ConfirmLimitTimesPre)
                        //{
                        //    sb.Append("<input type='button' class='btn btn-info btn-sm' onclick=\"callhtml('../Mafull/GetMoney.aspx?id=" + match[i].Id.ToString() + "','确认收款');\" value='确认收款>>' />");
                        //}
                        //else if (match[i].MatchType == 2 && (DateTime.Now - match[i].PayTime.Value).TotalMinutes <= BLL.MMMConfigScramble.Model.ConfirmLimitTimes)
                        //{
                        //    sb.Append("<input type='button' class='btn btn-info btn-sm' onclick=\"callhtml('../Mafull/GetMoney.aspx?id=" + match[i].Id.ToString() + "','确认收款');\" value='确认收款>>' />");
                        //}
                        //else if (match[i].MatchType == 0 && (DateTime.Now - match[i].PayTime.Value).TotalMinutes <= BLL.MMMConfig.Model.ConfirmLimitTimes)
                        //{
                        //    sb.Append("<input type='button' class='btn btn-info btn-sm' onclick=\"callhtml('../Mafull/GetMoney.aspx?id=" + match[i].Id.ToString() + "','确认收款');\" value='确认收款>>' />");
                        //}
                        //sb.Append("<input type='button' class='btn btn-info btn-sm' onclick=\"callhtml('../Mafull/GetMoney.aspx?id=" + match[i].Id.ToString() + "','确认收款');\" value='确认收款>>' />");
                    }
                    else
                    {
                        sb.Append("<input type='button' class='btn btn-info btn-sm' onclick=\"callhtml('../Mafull/MatchView.aspx?id=" + match[i].Id.ToString() + "','订单详情');\" value='查看详细>>' />");
                    }
                }
                if (match[i].MatchState == 2)
                {
                    if (memberModel.Role.IsAdmin)
                    {
                        if (!string.IsNullOrEmpty(match[i].PicUrl1))
                        {
                            sb.Append("<input type='button' value='收款违规' class='btn btn-danger btn-sm' onclick=\"deleteMatchGet('" + match[i].Id + "')\" />");
                            sb.Append("<input type='button' value='打款违规' class='btn btn-danger btn-sm' onclick=\"deleteMatchOff('" + match[i].Id + "')\" />");
                        }
                    }
                }
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}