using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Text;
using Newtonsoft.Json;
using CommonModel;
using System.Text.RegularExpressions;

namespace WE_Project.Web.Handler
{
    /// <summary>
    /// HKList 的摘要说明
    /// </summary>
    public class BankList : BaseHandler
    {
        public override void ProcessRequest(HttpContext context)
        {
            base.ProcessRequest(context);
            string mkey = "";
            string strWhere = " '1'='1' ";
            if (!string.IsNullOrEmpty(context.Request["startDate"]))
            {
                strWhere += " and BankCreateDate>'" + context.Request["startDate"] + " 00:00:00' ";
            }
            if (!string.IsNullOrEmpty(context.Request["endDate"]))
            {
                strWhere += " and BankCreateDate<'" + context.Request["endDate"] + " 23:59:59' ";
            }
            if (!string.IsNullOrEmpty(context.Request["mKey"]))
            {
                mkey = context.Request["mKey"];
            }
            Model.Member memberModel = (TModel == null ? BllModel.TModel : TModel);
            if (!memberModel.Role.IsAdmin)
                mkey = memberModel.MID;
            if (!string.IsNullOrEmpty(mkey))
            {
                strWhere += " and MID='" + mkey + "' ";
            }
            int count;
            List<Model.BankModel> List = BLL.BankModel.GetList(strWhere, pageIndex, pageSize, out count);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < List.Count; i++)
            {
                Model.Member member = BllModel.GetModel(List[i].MID);
                sb.Append(List[i].BankCode + "~");
                sb.Append((i + 1) + (pageIndex - 1) * pageSize + "~");
                if (TModel.Role.IsAdmin)
                {
                    sb.Append(member.MID + "~");
                    sb.Append(member.MName + "~");
                }
                sb.Append("<span>" + List[i].BankInfo.Name + "</span>~");
                sb.Append(List[i].Branch + "~");
                sb.Append(List[i].BankNumber + "~");
                sb.Append(List[i].BankCardName + "~");
                sb.Append(List[i].BankCreateDate.ToString("yyyy-MM-dd HH:mm"));
                //sb.Append((List[i].IsPrimary ? "是" : "否"));
                sb.Append("≌");
            }

            //string zhNames = "", enNames = "";
            //var list = CommonBLL.Sys_LanguageBLL.GetList("IsDeleted=0 and Status=1  order by LEN(ZHName) desc");
            //foreach (Sys_Language obj in list)
            //{
            //    zhNames += obj.ZHName + "*";
            //    enNames += obj.ENName + "*";
            //}
            //string[] zhs = zhNames.Split('*');
            //string[] ens = enNames.Split('*');
            //string cc = sb.ToString();
            //for (var i = 0; i < zhs.Length; i++)
            //{
            //    if (cc.IndexOf(zhs[i]) != -1)
            //    {
            //        if (!string.IsNullOrEmpty(zhs[i]) && !string.IsNullOrEmpty(ens[i]))
            //            cc = cc.Replace(zhs[i], ens[i]);
            //    }
            //}


            var info = new { PageData = Traditionalized(sb), TotalCount = count };
            //var info = new { PageData = sb.ToString(), TotalCount = count };
            context.Response.Write(JavaScriptConvert.SerializeObject(info));
        }
    }
}