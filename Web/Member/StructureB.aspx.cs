using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.Member
{
    public partial class StructureB : BasePage
    {
        protected string MAgencyTypeColor;
        protected string JXTypeColor;
        protected string RoleColor;
        protected override void SetPowerZone()
        {
            foreach (Model.SHMoney item in BLL.Configuration.Model.SHMoneyList.Values)
                MAgencyTypeColor += "<td><label style='background: " + item.MColor + "'>" + item.MAgencyName + "</label></td>";
            foreach (Model.Roles item in BLL.Roles.RolsList.Values.ToList().Where(emp => emp.VState).ToList())
                RoleColor += "<td><label style='background: " + item.RColor + "'>" + item.RName + "</label></td>";

        }

        protected override void SetValue(string id)
        {
            if (!TModel.Role.IsAdmin)
                DivSearch.InnerHtml = "<input id='txtMid' value='" + id + "' type='text' style='display:none;'/> ";
            else
                txtMid.Value = id;
        }
    }
}