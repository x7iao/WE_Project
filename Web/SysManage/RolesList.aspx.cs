using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.SysManage
{
    public partial class RolesList : BasePage
    {
        protected override void SetPowerZone()
        {
            if (!TModel.Role.Super)
                DivDelete.InnerHtml = "";
        }
    }
}