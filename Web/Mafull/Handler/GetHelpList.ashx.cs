using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Text;

namespace WE_Project.Web.Mafull.Handler
{
    /// <summary>
    /// GetHelpList 的摘要说明
    /// </summary>
    public class GetHelpList : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = " 1=1 and HelpType <> 99 ";
            string mkey = "";
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                string tState = context.Request["tState"];
                if (tState == "1")
                    strWhere += " and PPState in(0,2) ";
                else if (tState == "2")
                    strWhere += " and PPState =1";
                else if (tState == "3")
                    strWhere += " and PPState =3";
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
            List<Model.MGetHelp> EPList = BLL.MGetHelp.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < EPList.Count; i++)
            {
                sb.Append(EPList[i].Id + "~");
                sb.Append(EPList[i].SQMID + "~");
                sb.Append(EPList[i].SQCode + "~");
                sb.Append(EPList[i].SQDate.ToString("yyyy-MM-dd HH:mm") + "~");
                sb.Append(GetHelpState(EPList[i].PPState) + "~");
                sb.Append((EPList[i].SQMoney +"("+ EPList[i].SQMoney*2000+ ")")+ "~");
                sb.Append((EPList[i].MatchMoney + "(" + EPList[i].MatchMoney * 2000 + ")") + "~");
                sb.Append("<input type='button' value='查看明细' class='btn btn-info btn-sm' onclick=\"callhtml('../Mafull/MatchGetList.aspx?id=" + EPList[i].Id + "','查看明细')\" />");
                string op = string.Empty;
                //没交易完成
                if (EPList[i].PPState == 0)
                {
                    op = DateDiffStr(DateDiffType.MI, EPList[i].SQDate, BLL.MMMConfig.Model.FreezeTimesOfOffer, "排队倒计时:", "");
                }
                sb.Append(op);
                //if (TModel.Role.IsAdmin)
                //{
                //    if (EPList[i].PPState == 0)
                //    {
                //        sb.Append("<input type='button' value='取消申请' class='btn btn-info btn-sm' onclick=\"CancelHelp('" + EPList[i].Id + "')\" />");
                //    }
                //}
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}