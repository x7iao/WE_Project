using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.PrizePool
{
    public partial class DTFHMemberList : BasePage
    {
        protected string RoleListStr;
        protected string AgencyListStr;
        protected override void SetPowerZone()
        {
            foreach (Model.Roles item in BLL.Roles.RolsList.Values.ToList().Where(emp => emp.VState).ToList())
                RoleListStr += "<option value='" + item.RType + "'>" + item.RName + "</option>";
            foreach (Model.SHMoney item in BLL.Configuration.Model.SHMoneyList.Values.ToList())
                AgencyListStr += "<option value='" + item.MAgencyType + "'>" + item.MAgencyName + "</option>";
        }
    }
}