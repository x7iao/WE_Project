using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace WE_Project.Web.Mafull
{
    public partial class OfferHelp : BasePage
    {

        protected override void SetPowerZone()
        {
        }

        /// <summary>
        /// 货币购买
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override string btnAdd_Click()
        {
            int sqMoney = int.Parse(Request.Form["txtSQMoneyOff"]);
            int helptype = 0;
            if (int.Parse(Request.Form["offerrdo"]) == 1)
            {
                helptype = 1;
            }
            return BLL.MOfferHelp.GetHelp(TModel, sqMoney, helptype);
        }
    }
}