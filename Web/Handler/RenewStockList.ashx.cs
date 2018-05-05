using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Newtonsoft.Json;

namespace WE_Project.Web.Handler
{
    /// <summary>
    /// RenewStockList 的摘要说明
    /// </summary>
    public class RenewStockList : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string mkey = "";
            string strWhere = " '1'='1' ";
           
            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            if (!memberModel.Role.IsAdmin)
                mkey = memberModel.MID;
            if (!string.IsNullOrEmpty(mkey))
            {
                strWhere += " and AMID='" + mkey + "' and BMstate=0 and FHDays>=" + (BLL.Configuration.Model.DFHOutCount - 1).ToString();
            }
            else
            {
                strWhere += " and BMstate=0 and FHDays>=" + (BLL.Configuration.Model.DFHOutCount - 1).ToString();
            }
            int count;
            List<Model.BMember> List = BLL.BMember.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < List.Count; i++)
            {
                sb.Append(List[i].ID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(List[i].AMID + "~");
                sb.Append(List[i].BMID + "~");
               sb.Append(List[i].YJCount + "~");
                sb.Append(List[i].BMCreateDate.ToString("yyyy-MM-dd HH:mm") + "~");
                sb.Append(List[i].FHDays + "~");
                sb.Append("<input type='button' value='续费' class='btn btn-danger' onclick='RenewStock(" + List[i].ID + ",this)'/>");
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}