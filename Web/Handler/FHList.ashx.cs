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
    /// FHList 的摘要说明
    /// </summary>
    public class FHList : BaseHandler
    {

        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string mkey = "";
            string strWhere = " '1'='1' ";

            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                mkey = context.Request["mKey"];
            }
            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and BMCreateDate>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                strWhere += " and BMCreateDate<'" + context.Request["endDate"] + " 23:59:59' ";
            }

            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            if (!memberModel.Role.IsAdmin)
                mkey = memberModel.MID;
            if (!string.IsNullOrEmpty(mkey))
            {
                strWhere += " and AMID='" + mkey + "' ";
            }
            int count;
            List<Model.BMember> List = BLL.BMember.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < List.Count; i++)
            {

                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                sb.Append(List[i].AMID + "~");
                sb.Append(List[i].BMID + "~");
                sb.Append(List[i].BMCreateDate.ToString("yyyy-MM-dd HH:mm") + "~");
                ////分红股编号
                //string fhCode = List[i].ID.ToString();
                //string tempBMID = List[i].BMID;
                //int code=0;
                //if (!string.IsNullOrEmpty(tempBMID))
                //{
                    
                //    fhCode = tempBMID.Split('_')[1];
                //     code= int.Parse(fhCode)+1;
                //}

                //sb.Append(code + "~");
                sb.Append(Math.Round(List[i].YJCount*BLL.Configuration.Model.DFHFloat*BLL.Configuration.Model.GPrice,2) + "~");
                sb.Append(List[i].FHDays+ "~");
                sb.Append(List[i].YJMoney + "~");
                sb.Append(List[i].BMState?"未出局":"已出局");
                sb.Append("≌");
            }
            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}