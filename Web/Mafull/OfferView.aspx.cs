using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.Mafull
{
    public partial class OfferView : BasePage
    {
        protected Model.MHelpMatch match;
        protected Model.MOfferHelp offer;
        protected List<Model.MHelpMatch> list;
        protected override void SetPowerZone()
        {

        }
        protected override void SetValue(string id)
        {
            offer = BLL.MOfferHelp.GetModel(id);
            if (offer.PPState == 1 || offer.PPState == 2)
            {
                list = BLL.MHelpMatch.GetList("OfferId="+offer.Id);
            }
        }
    }
}