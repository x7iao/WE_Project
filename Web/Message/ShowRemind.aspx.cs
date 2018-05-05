using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.Message
{
    public partial class ShowRemind : BasePage
    {
        public Model.Remind model;
        protected override void SetValue(string id)
        {
            model = BLL.Remind.GetModel(id);
        }
    }
}