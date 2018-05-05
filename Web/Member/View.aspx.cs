using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.Member
{
    public partial class View : BasePage
    {
        protected Model.Member tjmodel;
        protected override void SetPowerZone()
        {
            //tjmodel = BLL.Member.ManageMember.GetModel(TModel.MTJ);
        }

        public string ChangeString(string str)
        {
            return str.Replace("会员", "");
        }
    }
}