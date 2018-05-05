using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Newtonsoft.Json;

namespace WE_Project.Web.Handler
{
    /// <summary>
    /// ReChargeList 的摘要说明
    /// </summary>
    public class ReChargeList : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string mkey = "";
            string strWhere = " '1'='1' ";
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                strWhere += " and HKType=" + context.Request["tState"] ;
            }

            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            if (!memberModel.Role.IsAdmin)
                mkey = memberModel.MID;
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
                //sb.Append(List[i].MID + "~");
                sb.Append(List[i].FromBank + "~");
                sb.Append(List[i].RealMoney + "~");
               sb.Append(List[i].BankName + "~");
                 sb.Append(List[i].Remark + "~");
                
               
                sb.Append(List[i].HKDate.ToString("yyyy-MM-dd HH:mm") + "~");
                sb.Append((List[i].HKState ? "已审核" : "未审核") + "~");
                sb.Append(List[i].ConfirmTime != null ? Convert.ToDateTime(List[i].ConfirmTime).ToString("yyyy-MM-dd HH:mm") : "");
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}