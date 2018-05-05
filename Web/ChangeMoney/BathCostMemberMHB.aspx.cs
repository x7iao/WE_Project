using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.ChangeMoney
{
    public partial class BathCostMemberMHB : BasePage
    {
        protected string AgencyListStr;
        protected override void SetPowerZone()
        {
            //foreach (Model.SHMoney item in BLL.Configuration.Model.SHMoneyList.Values.ToList())
            //    AgencyListStr += "<option value='" + item.MAgencyType + "'>" + item.MAgencyName + "</option>";
                AgencyListStr += "<option value='002'>正式会员</option>";
        }
    }
}