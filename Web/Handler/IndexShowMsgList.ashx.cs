using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Newtonsoft.Json;

namespace WE_Project.Web.Handler
{
    /// <summary>
    /// IndexShowMsgList 的摘要说明
    /// </summary>
    public class IndexShowMsgList : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = " '1'='1' ";
            //if (!string.IsNullOrEmpty(context.Request["GParentCode"]))
            //{
            //    strWhere += " and GParentCode ='" + context.Request["GParentCode"] + "' ";
            //}
            //if (!string.IsNullOrEmpty(context.Request["mKey"]))
            //{
            //    strWhere += " and (GoodsCode like '%" + context.Request["mKey"] + "%' or GParentName like '%" + context.Request["mKey"] + "%') ";
            //}
            int count;
            List<Model.WriteEmail> List = BLL.WriteEmail.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < List.Count; i++)
            {
                sb.Append(List[i].Id + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                //sb.Append(List[i].GParentName + "~");
                sb.Append(List[i].PublishTime.ToShortDateString() + "~");
                sb.Append(List[i].WriteContent);
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}