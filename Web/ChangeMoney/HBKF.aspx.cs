using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace WE_Project.Web.ChangeMoney
{
    public partial class HBKF : BasePage
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
                    string moneyType = "MHB";
                    if (Request.Form["RioHK"] == "MJB")
                        moneyType = "MJB";
                    if (Request.Form["RioHK"] == "MGP")
                        moneyType = "MGP";
                    //if (Request.Form["rdo"] == "MCW")
                    //    moneyType = "MCW";
                    //if (Request.Form["rdo"] == "MJBF")
                    //    moneyType = "MJBF";
                    if (Request.Form["RioHK"] == "TotalYFHMoney")
                        moneyType = "TotalYFHMoney";
                    if (BLL.ChangeMoney.EnoughChange(Request.Form["txtMID"], decimal.Parse(Request.Form["txtMHB"]), moneyType))
                    {
                        Hashtable MyHs = new Hashtable();
                        BLL.ChangeMoney.KFMoneyChange(Request.Form["txtMID"], BLL.Member.ManageMember.TModel.MID, decimal.Parse(Request.Form["txtMHB"]), moneyType, MyHs);
                        if (BLL.CommonBase.RunHashtable(MyHs))
                            return "成功";
                        return "失败";
                    }
                    else
                    {
                        return "该会员的账号余额不足!";
                    }
                }
                else
                {
                    return "扣费金额不能为空";
                }
            }
            return "您没有权限";
        }
    }
}