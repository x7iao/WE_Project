using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.Member
{
    public partial class ViewMember : BasePage
    {
        protected Model.Member model;
        protected Model.Member tjmodel;
        protected override void SetPowerZone()
        {
        }

        protected override void SetValue(string id)
        {
            model = BLL.Member.ManageMember.GetModel(id);
            //tjmodel = BLL.Member.ManageMember.GetModel(model.MTJ);
        }

        public string ChangeString(string str)
        {
            return str.Replace("会员", "");
        }
    }
}