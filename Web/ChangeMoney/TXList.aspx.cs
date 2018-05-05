using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.ChangeMoney
{
    public partial class TXList : BasePage
    {
        protected override void SetPowerZone()
        {
            if (!TModel.Role.IsAdmin)
            {
                DivSearch.InnerHtml = "";
                DivOperation.InnerHtml = "";
            }
        }
    }
}