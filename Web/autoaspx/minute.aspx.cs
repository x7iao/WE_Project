using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.autoaspx
{
    public partial class minute : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["minute"]) || Request.QueryString["minute"] != "WE_Project")
                    return;
                //if (WE_Project.BLL.Configuration.Model.AutoDFH)
                {
                    try
                    {
                        WE_Project.BLL.MHelpMatch.MMMChangeDKMID();
                    }
                    catch (Exception ex)
                    {
                        BLL.Task.SendManage(BLL.Member.ManageMember.TModel, "分钟", ex.ToString());
                    }
                    try
                    {
                        //WE_Project.BLL.MHelpMatch.MMMChangeMTJDKMID();
                    }
                    catch (Exception ex)
                    {
                        BLL.Task.SendManage(BLL.Member.ManageMember.TModel, "分钟", ex.ToString());
                    }
                    try
                    {
                        WE_Project.BLL.MHelpMatch.MMMAutoGetMoney();
                    }
                    catch (Exception ex)
                    {
                        BLL.Task.SendManage(BLL.Member.ManageMember.TModel, "分钟", ex.ToString());
                    }

                   
                    try
                    {
                        //WE_Project.BLL.MHelpMatch.MMMChangeMTJDKMID();
                    }
                    catch (Exception ex)
                    {
                        BLL.Task.SendManage(BLL.Member.ManageMember.TModel, "分钟", ex.ToString());
                    }
                    try
                    {
                        BLL.MOfferHelp.outTimeDHLiXi();
                        BLL.Member.Weaken();
                        BLL.ChangeMoney.DJWDK();
                        BLL.ChangeMoney.PDXZ();
                    }
                    catch (Exception ex)
                    {
                        BLL.Task.SendManage(BLL.Member.ManageMember.TModel, "分钟", ex.ToString());
                    }
                   
                }
            }
        }
    }
}