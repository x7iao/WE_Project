using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.Payment.MoBao
{
    public partial class ShowResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            result.InnerHtml = Request.Form.ToString();
        }
    }
}