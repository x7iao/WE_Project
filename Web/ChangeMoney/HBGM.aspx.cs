using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace WE_Project.Web.ChangeMoney
{
    public partial class HBGM : BasePage
    {
        /// <summary>
        /// 货币购买
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override string btnAdd_Click()
        {
            if (TModel.Role.IsAdmin)
            {
                if (!string.IsNullOrEmpty(Request.Form["txtMHB"]))
                {
                    string MType = "MHB";
                    if (Request.Form["rdo"] == "MJB")
                        MType = "MJB";
                    if (Request.Form["rdo"] == "MGP")
                        MType = "MGP";
                    if (Request.Form["rdo"] == "MCW")
                        MType = "MCW";
                    if (Request.Form["rdo"] == "MJBF")
                        MType = "MJBF";
                    if (Request.Form["rdo"] == "TotalYFHMoney")
                        MType = "TotalYFHMoney";
                    if (BLL.ChangeMoney.EnoughChange(TModel.MID, int.Parse(Request.Form["txtMHB"]), MType))
                    {
                        Hashtable MyHs = new Hashtable();
                        BLL.ChangeMoney.CZMoneyChange(TModel.MID, Request.Form["txtMID"], int.Parse(Request.Form["txtMHB"]), MType, MyHs);
                        if (BLL.CommonBase.RunHashtable(MyHs))
                            return "成功";
                        return "失败";
                    }
                    else
                    {
                        return "您的账号余额不足!";
                    }
                }
                else
                {
                    return "充值金额不能为空";
                }
            }
            return "您没有权限";
        }



    }
}