using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.Mafull
{
    public partial class OfferHelpList : BasePage
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
                DivDelete.Visible = false;
                matchMui.Visible = false;
                matchSure.Visible = false;
            }
            if (TModel.Role.IsAdmin)
            {
                string res = BLL.MOfferHelp.GetSumCount("4");
                countSumSp.InnerHtml = "可匹配总数量：" + res.Split('*')[0] + "；可匹配总金额：" + res.Split('*')[1];
            }
            else
            {
                countSumSp.Visible = false;
                DivSearch.InnerHtml = "";
            }
        }
        protected override string btnAdd_Click()
        {
            if (TModel.Role.IsAdmin)
            {
                string tid = Request.QueryString["4"];
                string res = BLL.MOfferHelp.GetSumCount("4");
                return "可匹配总数量：" + res.Split('*')[0] + "；可匹配总金额：" + res.Split('*')[1];
            }
            else
                return "";
        }
    }
}