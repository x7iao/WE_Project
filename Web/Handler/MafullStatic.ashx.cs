using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Newtonsoft.Json;

namespace WE_Project.Web.Handler
{
    /// <summary>
    /// MafullStatic 的摘要说明
    /// </summary>
    public class MafullStatic : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string startTime = "2000-1-1 00:00:00";
            DateTime now = DateTime.Now.AddDays(1);
            string endTime = now.Year + "-" + now.Month + "-" + now.Day + " 23:59:59";
            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                startTime = context.Request["startDate"] + " 00:00:00";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                endTime = context.Request["endDate"] + " 23:59:59";
            }


            var offList = BLL.MOfferHelp.GetList(" SQDate >= '" + startTime + "' and SQDate <= '" + endTime + "' and PPState <> 5 and HelpType <> 99 ");
            var getList = BLL.MGetHelp.GetList(" SQDate >= '" + startTime + "' and SQDate <= '" + endTime + "' and PPState <> 5 and HelpType <> 99 ");
            var matchList = BLL.MHelpMatch.GetList(" MatchTime >= '" + startTime + "' and MatchTime <= '" + endTime + "' ");

            StringBuilder sb = new StringBuilder();
            sb.Append("~");
            //提供金钥匙总数
            sb.Append(offList.Sum(m => m.SQMoney) + "~");
            //获得金钥匙总数
            sb.Append(getList.Sum(m => m.SQMoney) + "~");
            //打款成功总数
            sb.Append(matchList.Where(m => m.MatchState >= 2).Sum(m => m.MatchMoney) + "~");
            //确认成功总数
            sb.Append(matchList.Where(m => m.MatchState >= 3).Sum(m => m.MatchMoney));
            sb.Append("≌");

            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));

        }
    }
}