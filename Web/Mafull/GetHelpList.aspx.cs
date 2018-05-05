using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.Mafull
{
    public partial class GetHelpList : BasePage
    {
        protected string matchid = string.Empty;
        protected override void SetValue(string id)
        {
            matchid = id;
            if (TModel.Role.IsAdmin)
            {
                if (!string.IsNullOrEmpty(id))
                {
                    matchMui.Visible = false;
                    matchSure.Visible = true;
                }
            }
        }
        protected override void SetPowerZone()
        {
            if (!TModel.Role.IsAdmin)
            {
                matchMui.Visible = false;
                matchSure.Visible = false;
            }

            //if (TModel.Role.IsAdmin)
            //{
            //    string res = BLL.MGetHelp.GetSumCount("");
            //    //countSumSp.InnerHtml = "总数量：" + res.Split('*')[0] + "；总金额：" + res.Split('*')[1];
            //    countSumSp.InnerHtml = "总数量：" + res.Split('*')[1];
            //    decimal ress = BLL.MGetHelp.GetUnMatchSumMoney(" PPState <> 5 ");
            //    countSumSp.InnerHtml += "；未匹配总金额：" + ress.ToString("F0");
            //}
            //else
            //{
            //    countSumSp.Visible = false;
            //}

            if (!TModel.Role.IsAdmin)
            {
                DivSearch.InnerHtml = "";
            }
        }
        protected override string btnAdd_Click()
        {
            if (TModel.Role.IsAdmin)
            {
                string tid = Request.QueryString["tid"];
                string res = BLL.MGetHelp.GetSumCount(tid);
                return "总数量：" + res.Split('*')[0] + "；总金额：" + res.Split('*')[1];
            }
            else
                return "";
        }
    }
}