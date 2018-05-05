using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.Member
{
    public partial class BCenterList : BasePage
    {
        protected override void SetPowerZone()
        {
            if (!TModel.Role.IsAdmin)
                DivSearch.InnerHtml = "";
            if (!TModel.Role.Super)
                DivOperation.InnerHtml = "";

        }
    }
}