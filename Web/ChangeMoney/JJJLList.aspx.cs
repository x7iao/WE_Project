using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.ChangeMoney
{
    public partial class JJJLList : BasePage
    {
        protected string list = "";
        protected string titles = "";
        protected string date = "";
        protected override void SetPowerZone()
        {
            if (!TModel.Role.IsAdmin)
                DivSearch.InnerHtml = "";
            foreach (KeyValuePair<string, Model.Reward> item in BLL.Reward.List)
            {
                if (item.Value.NeedProcess)
                {
                    list += item.Value.RewardType + "|";
                    titles += item.Value.RewardName + "|";
                }
            }
            date = Request.QueryString["date"];

        }

        protected override void SetValue(string id)
        {
            txtKey.Value = id;
        }
    }
}