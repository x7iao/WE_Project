using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace WE_Project.Web.Mafull.Handler
{
    /// <summary>
    /// OfferHelpList 的摘要说明
    /// </summary>
    public class OfferHelpList : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = " PPState !=5 and HelpType < 50 ";
            string mkey = "";
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                string tState = context.Request["tState"];
                if (tState == "1")//等待匹配中
                    strWhere += " and PPState in (0,2) ";
                else if (tState == "2")//匹配成功
                    strWhere += " and PPState =1 ";
                else if (tState == "3")//交易完成，没有解冻的
                    strWhere += " and PPState =3 and DATEDIFF(mi,CompleteTime,getdate())< " + BLL.MMMConfig.Model.FreezeTimes;
                else if (tState == "4")//已经提取的，可以提取的
                    strWhere += " and PPState in (3,4) and DATEDIFF(mi,CompleteTime,getdate())> " + BLL.MMMConfig.Model.FreezeTimes;
                else if (tState == "5")//
                    strWhere += " and SQMID in (select MID from Member where IsClose<>'1') and PPState in (0,2) and DATEDIFF(mi,SQDate,getdate())> " + BLL.MMMConfig.Model.LineTimes;
            }
            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                mkey = context.Request["mKey"];
            }
            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and SQDate>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                strWhere += " and SQDate<'" + context.Request["endDate"] + " 23:59:59' ";
            }

            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            if (!memberModel.Role.IsAdmin)
            {
                mkey = memberModel.MID;
            }
            if (!string.IsNullOrEmpty(mkey))
            {
                strWhere += " and SQMID ='" + mkey + "' ";
            }

            strWhere += " and SQMID not in (select MID from Member where IsClock = 1 and IsClose = 1)";
            int count;
            List<Model.MOfferHelp> offerList = BLL.MOfferHelp.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < offerList.Count; i++)
            {
                sb.Append(offerList[i].Id + "~");
                sb.Append(offerList[i].SQMID + "~");
                sb.Append(offerList[i].SQCode + "~");
                sb.Append(offerList[i].SQDate.ToString("yyyy-MM-dd HH:mm") + "~");
                sb.Append(GetHelpState(offerList[i].PPState) + "~");
                sb.Append((offerList[i].HelpType==0?"正常排单":"抢单区排单") + "~");
                //sb.Append(offerList[i].TotalInterestDays + "~");
                sb.Append((offerList[i].SQMoney + "(" + offerList[i].SQMoney * 2000 + ")") + "~");
                sb.Append((offerList[i].MatchMoney + "(" + offerList[i].MatchMoney * 2000 + ")") + "~");
                sb.Append(offerList[i].TotalInterest + "~");
                //sb.Append((offerList[i].InterestState == 1 ? "正常" : "冻结") + "~");
                //sb.Append(offerList[i].TotalSincerity + "~");
                string op = string.Empty;
                //没交易完成
                if (offerList[i].PPState == 0 || offerList[i].PPState == 1 || offerList[i].PPState == 2)
                {
                    op = OfferTimeLeave(offerList[i], MMMOfferTimeType.LineTime, "排队倒计时:", "");
                }
                if (offerList[i].PPState == 3)
                {
                    op = OfferTimeLeave(offerList[i], MMMOfferTimeType.FreezeTime, "提款倒计时:", "");
                    if (string.IsNullOrEmpty(op))
                    {
                        op = "<input type='button' value='圆梦' class='btn btn-danger btn-sm' onclick=\"MatchGetMoney(" + offerList[i].Id + ",this)\" />";
                    }
                }
                if (offerList[i].PPState != 0)
                {
                    sb.Append("<input type='button' value='匹配详情' class='btn btn-info btn-sm' onclick=\"callhtml('../Mafull/MatchOfferList.aspx?id=" + offerList[i].Id + "','匹配列表')\" />");
                }
                if (TModel.Role.IsAdmin)
                {
                    if (offerList[i].PPState == 0)
                    {
                        sb.Append("<input type='button' value='取消申请' class='btn btn-info btn-sm' onclick=\"CancelOffer('" + offerList[i].Id + "')\" />");
                    }
                    //if (offerList[i].InterestState != 1)
                    //{
                    //    op = "<input type='button' value='解冻利息' class='btn btn-danger btn-sm' onclick=\"MatchGetLixiMoney(" + offerList[i].Id + ",this)\" />";
                    //}
                }
                sb.Append(op);
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}