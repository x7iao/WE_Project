using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.autoaspx
{
    public partial class hour : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["hour"]) || Request.QueryString["hour"] != "WE_Project")
                    return;

                string strdate = BLL.MMMConfig.Model.MacthTimesRange;
                string[] strlist = strdate.Split('-');
                DateTime statedt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd ") + strlist[0]);
                DateTime enddt = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd ") + strlist[1]);
                DateTime dqdate = DateTime.Now;
                if (dqdate >= statedt && dqdate <= enddt)
                {
                    if (WE_Project.BLL.MMMConfig.Model.MacthSwitch)
                    {
                        try
                        {
                            Response.Write(WE_Project.BLL.MHelpMatch.MatchingHelp2());
                        }
                        catch (Exception ex)
                        {
                            BLL.Task.SendManage(BLL.Member.ManageMember.TModel, "小时", ex.ToString());
                        }
                    }
                }
            }
        }
    }
}