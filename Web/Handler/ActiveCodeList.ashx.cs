using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Newtonsoft.Json;

namespace WE_Project.Web.Handler
{
    /// <summary>
    /// ActiveCodeList 的摘要说明
    /// </summary>
    public class ActiveCodeList : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string strWhere = " '1'='1' ";
            string mkey = "";

            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                mkey = context.Request["mKey"];
            }

            if (!TModel.Role.IsAdmin)
                mkey += TModel.MID;
            if (!string.IsNullOrEmpty(mkey))
                strWhere += " and MID='" + mkey + "' ";

            int count;
            List<Model.ActiveCode> List = BLL.ActiveCode.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < List.Count; i++)
            {
                sb.Append(List[i].Id + "~");
                sb.Append(List[i].Code + "~");
                switch (List[i].UseState)
                {
                    case 0:
                    case 1:
                        sb.Append("未使用~"); break;
                    case 2:
                        sb.Append("已使用~"); break;
                    case 4:
                        sb.Append("已限制不可用~"); break;
                }
                sb.Append(List[i].MID + "~");
                sb.Append(List[i].UseMID + "~");
                sb.Append(List[i].UseTime != null ? Convert.ToDateTime(List[i].UseTime).ToString("yyyy-MM-dd HH:mm") : "");
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}