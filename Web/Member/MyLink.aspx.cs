using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommonBLL;

namespace WE_Project.Web.Member
{
    public partial class MyLink : BasePage
    {
        protected override void SetPowerZone()
        {
            txtTuiGuang.Value = HttpContext.Current.Request.Url.AbsoluteUri.Replace(HttpContext.Current.Request.Url.PathAndQuery, "/Index.aspx");
            //txtTuiGuang.Value = "http://www.fenglee.net/Index.aspx";
            //txtTuiGuang.Value = "http://" + WebModel.TXInfo + "/Regedit/Index.aspx";
            txtTuiGuang.Value = "http:" + HttpContext.Current.Request.Url.Authority.ToString() + "/Regedit/Index.aspx";
            txtTuiGuang.Value += "?mid=" + TModel.MID;
        }
    }
}