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
    /// HKList 的摘要说明
    /// </summary>
    public class HKList : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string mkey = "";
            string strWhere = " '1'='1' ";
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                strWhere += " and HKState='" + context.Request["tState"] + "' ";
            }
            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                mkey = context.Request["mKey"];
            }
            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and HKDate>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                strWhere += " and HKDate<'" + context.Request["endDate"] + " 23:59:59' ";
            }
            if (!string.IsNullOrEmpty(context.Request["hkType"]))
            {
                strWhere += " and HKType='" + context.Request["hkType"] + "' ";
            }
            if (!string.IsNullOrEmpty(context.Request["IsAuto"]))
            {
                strWhere += " and IsAuto='" + context.Request["IsAuto"] + "' ";
            }
            if (!TModel.Role.IsAdmin)
                mkey = TModel.MID;
            if (!string.IsNullOrEmpty(mkey))
            {
                strWhere += " and MID='" + mkey + "' ";
            }
            int count;
            List<Model.HKModel> List = BLL.HKModel.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < List.Count; i++)
            {
                Model.Member member = BllModel.GetModel(List[i].MID);
                sb.Append(List[i].HKCode + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                //sb.Append(List[i].HKCode + "~");
                sb.Append(List[i].MID + "~");
                sb.Append(Math.Round(List[i].RealMoney, 2) + "~");
                sb.Append((List[i].HKType == 1 ? BLL.Reward.List["MGP"].RewardName : BLL.Reward.List["TotalYFHMoney"].RewardName) + "~");
                //if (member != null)
                //    sb.Append(member.MName + "~");
                //else
                //    sb.Append("不存在该会员" + "~");
                //sb.Append(List[i].HKTypeStr + "~");
                //sb.Append(List[i].FromBank + "~");
                //sb.Append(List[i].BankName + "~");
                sb.Append(Math.Round(List[i].ValidMoney, 0) + "~");
                //sb.Append(List[i].Remark + "~");
                sb.Append(List[i].HKDate.ToString("yyyy-MM-dd HH:mm") + "~");
                sb.Append((List[i].HKState ? "已生效" : "未生效") + "~");
                sb.Append(List[i].Remark);
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}