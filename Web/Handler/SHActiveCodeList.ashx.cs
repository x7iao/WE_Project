using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.Text;

namespace WE_Project.Web.Handler
{
    /// <summary>
    /// SHActiveCodeList 的摘要说明
    /// </summary>
    public class SHActiveCodeList : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = "1=1  ";
            if (!string.IsNullOrEmpty(context.Request["tState"]))
            {
                if (context.Request["tState"] == "true")
                    strWhere += " and State=1";
                else if (context.Request["tState"] == "false")
                    strWhere += " and State=0";
            }
            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                strWhere += string.Format(" and ( ToMID='{0}') ", (context.Request["mKey"]));
            }
            if (!TModel.Role.IsAdmin)
            {
                return;
            }
            int count;
            List<Model.BuyActiveCode> ListMember = BLL.BuyActiveCode.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListMember.Count; i++)
            {
                sb.Append(ListMember[i].Id + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(ListMember[i].FromMID + "~");
                sb.Append(ListMember[i].CodeCount + "~");
                sb.Append(ListMember[i].PayTime.ToString("yyyy-MM-dd HH:mm") + "~");
                sb.Append((ListMember[i].ConfirmTime != null ? Convert.ToDateTime(ListMember[i].ConfirmTime).ToString("yyyy-MM-dd HH:mm") : "") + "~");
                sb.Append("<img src='" + ListMember[i].PicUrl + "' style='max-width:100px;' onclick=v5.show2('" + ListMember[i].PicUrl + "','" + ListMember[i].Remark + "',800,600)  />" + "~");
                sb.Append("<input type='button' value='详细' class='btn btn-sm btn-danger' onclick=callhtml('../Member/SHActiveCodeDetail.aspx?id=" + ListMember[i].Id + "','申请详细')  />");
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}