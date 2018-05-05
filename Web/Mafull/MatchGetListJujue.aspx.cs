using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.Mafull
{
    public partial class MatchGetListJujue : BasePage
    {
        protected string matchid = string.Empty;
        protected override void SetValue(string id)
        {
            matchid = id;
            //matchid.Value = id;
        }
        protected override void SetPowerZone()
        {
            if (TModel.Role.IsAdmin)
            {
                DivSearch.InnerHtml = "";
            }
        }
    }
}