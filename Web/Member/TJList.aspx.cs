using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.Member
{
    public partial class TJList : BasePage
    {
        protected override void SetPowerZone()
        {
            if (!TModel.Role.IsAdmin)
            {
                DivSearch.InnerHtml = "<input name='txtKey' id='mTJKey' value='" + TModel.MID + "' style='display:none;' />";
            }
        }
    }
}