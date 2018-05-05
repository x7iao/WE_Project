using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Newtonsoft.Json;
using System.Web.SessionState;

namespace WE_Project.Web.Handler
{
    /// <summary>
    /// BCenterList 的摘要说明
    /// </summary>
    public class BCenterList : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            bool isAlready = false; //是否是查询已审核
            string strWhere = " MID<>''";
            string sh = " and State=1";
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                if (context.Request["tState"] == "true")
                {
                    sh = " and State=1";
                    isAlready = true;
                }
                else if (context.Request["tState"] == "false")
                    sh = " and State=0";
            }
            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                strWhere += string.Format(" and ( MID='{0}') ", (context.Request["mKey"]));
            }

            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and ApplyTime>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                strWhere += " and ApplyTime<'" + context.Request["endDate"] + " 23:59:59' ";
            }

            int count;
            List<Model.MemberApply> ListMember = BLL.MemberApply.GetList(strWhere + sh, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListMember.Count; i++)
            {
                Model.Member model = BllModel.GetModel(ListMember[i].MID);
                if (model != null)
                {
                    sb.Append(ListMember[i].Id + "~");
                    sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                    sb.Append(ListMember[i].MID + BLL.Member.GetOnlineInfo(ListMember[i].MID) + "~");
                    sb.Append(model.MName + "~");
                    sb.Append(model.MConfig.MJB + "~");
                    sb.Append(model.MConfig.TJCount + "~");
                    sb.Append((model.IsClose ? "已锁定" : "未锁定") + "~");
                    sb.Append(model.MDate.ToString("yyyy-MM-dd HH:mm") + "~");
                    string applytype = "", State = "";
                    applytype = BLL.Configuration.Model.SHMoneyList[ListMember[i].ApplyType].MAgencyName;
                    sb.Append(applytype + "~");

                    sb.Append("<span class='appleState'>" + State + "</span>~");
                    sb.Append(ListMember[i].ApplyTime.ToString("yyyy-MM-dd HH:mm") + "~");
                    sb.Append((ListMember[i].ConfirmTime != null ? Convert.ToDateTime(ListMember[i].ConfirmTime).ToString("yyyy-MM-dd HH:mm") : "") + "~");
                    if (isAlready)
                    {
                        //sb.Append("<input type='button' value='取消' class='btn btn-sm btn-danger' onclick=cancleApply(this," + ListMember[i].ApplyType + ",'" + model.MID + "'," + ListMember[i].Id + ")  />");
                    }
                    else
                    {
                        sb.Append("<input type='button' value='审核' class='btn btn-sm btn-danger' onclick=dealApply(this,1,'" + model.MID + "'," + ListMember[i].Id + ")  />");
                    }
                    sb.Append("≌");
                }
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}