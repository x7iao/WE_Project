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
    public class RolesList : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = " VState='1' ";
            pageSize = 200;
            List<Model.Roles> List = BLL.Roles.GetList(strWhere);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < List.Count; i++)
            {
                sb.Append(List[i].RType + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(List[i].RType + "~");
                sb.Append(List[i].RName + "~");
                sb.Append((List[i].IsAdmin ? "<span style='color:Red;'>是</span>" : "否") + "~");
                sb.Append((List[i].Super ? "<span style='color:Red;'>是</span>" : "否") + "~");
                sb.Append((List[i].CanSH ? "<span style='color:Red;'>是</span>" : "否") + "~");
                sb.Append((List[i].CanLogin ? "<span style='color:Red;'>是</span>" : "否") + "~");
                sb.Append((List[i].CMessage ? "<span style='color:Red;'>是</span>" : "否") + "~");
                sb.Append((List[i].RColor));
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = List.Count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}