using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.autoaspx
{
    public partial class day : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (string.IsNullOrEmpty(Request.QueryString["day"]) || Request.QueryString["day"] != "WE_Project")
                    return;
                //if (WE_Project.BLL.Configuration.Model.AutoDFH)
                {
                    string error = "";
                    //try
                    //{
                    //    if (WE_Project.BLL.MHelpMatch.MMMLiXi())
                    //    {
                    //        error += "利息发放成功！";
                    //    }
                    //    else
                    //    {
                    //        error += "利息发放失败！";
                    //    }
                    //}
                    //catch (Exception ex)
                    //{
                    //    BLL.Task.SendManage(BLL.Member.ManageMember.TModel, "每天", ex.ToString());
                    //}
                    //try
                    //{
                    //    if (BLL.ChangeMoney.FTFH())
                    //    {
                    //        error += "奖金解冻成功！";
                    //    }
                    //    else
                    //    {
                    //        error += "奖金解冻失败！";
                    //    }
                    //}
                    //catch (Exception ex)
                    //{
                    //    BLL.Task.SendManage(BLL.Member.ManageMember.TModel, "每天", ex.ToString());
                    //}

                    //Response.Write(error);
                }
            }
        }
    }
}