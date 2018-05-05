using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Text;
using Newtonsoft.Json;

namespace WE_Project.Web.Handler
{
    /// <summary>
    /// SYBList 的摘要说明
    /// </summary>
    public class SYBList : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = " '1'='1' ";
            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            strWhere += " and ChangeType='TZSYB'  and ToMID='" + memberModel.MID + "'";
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                if (Convert.ToBoolean(context.Request["tState"]))
                    strWhere += " and SHMID='" + memberModel.MID + "'";
                else
                    strWhere += " and SHMID='" + BLL.Member.ManageMember.TModel.MID + "'";
            }


            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and ChangeDate>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                strWhere += " and ChangeDate<'" + context.Request["endDate"] + " 23:59:59' ";
            }


            int count;
            List<Model.ChangeMoney> List = BLL.ChangeMoney.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < List.Count; i++)
            {
                sb.Append((i + 1) + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                //sb.Append(List[i].FromMID + "~");
                sb.Append(List[i].Money + "~");
                //sb.Append(List[i].BuyPrice + "~");
                //sb.Append(List[i].BuyCount * List[i].BuyPrice + "~");
                sb.Append(List[i].ChangeDate.ToString("yyyy-MM-dd HH:mm") + "~");
                //投资金额
                sb.Append(List[i].CState ? "已成交~" : "未成交~");
                sb.Append(List[i].SHMID == TModel.MID ? "转入" : "转出");
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}