using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using Newtonsoft.Json;

namespace WE_Project.Web.Handler
{
    /// <summary>
    /// RegionList 的摘要说明
    /// </summary>
    public class RegionList : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {

            base.ProcessRequest(context);
            string strWhere = "'1'='1'";
            strWhere += " and MID in (select MID from MemberConfig where IsRegionalDirector=1)";
            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                strWhere += string.Format(" and ( MID='{0}' or MName='{0}') ", (context.Request["mKey"]));
            }

            int count;
            List<Model.Member> ListMember = BllModel.GetMemberEntityList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < ListMember.Count; i++)
            {
                sb.Append(ListMember[i].MID + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                //sb.Append(ListMember[i].Province+ListMember[i].MConfig.Region.ToString() + "区~");
                sb.Append(ListMember[i].MID + "~");
                sb.Append(ListMember[i].MName + "~");
                sb.Append(ListMember[i].MAgencyType.MAgencyName + "~");
                Model.MemberApply obj = GetMemberApply(ListMember[i].MID, 2, 1);
                if (obj != null)
                {
                    sb.Append(obj.MQQ + "~");
                    sb.Append(obj.MQQGroup + "~");
                    sb.Append(obj.MTel + "~");
                    sb.Append(obj.ApplyTime.ToString("yyyy-MM-dd HH:mm") + "~");
                    sb.Append(Convert.ToDateTime(obj.ConfirmTime).ToString("yyyy-MM-dd HH:mm"));
                }
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };

            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }

        protected Model.MemberApply  GetMemberApply(string mid,int state,int applyTypes)
        {
             return BLL.MemberApply.GetList(string.Format(" MID='{0}' and State={1} and ApplyType={2}", mid, state, applyTypes)).FirstOrDefault();
        }
    }
}