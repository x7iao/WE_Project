using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace WE_Project.Web.ChangeMoney
{
    public partial class HBKC : BasePage
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
                    string txtMHB = Request.Form["txtMHB"];
                    int kcMoney=int.Parse(Request.Form["txtMHB"]);

                    if (BLL.ChangeMoney.EnoughChange(TModel.MID, kcMoney, MType))
                    {
                        Hashtable MyHs = new Hashtable();
                        BLL.ChangeMoney.KFMoneyChange(TModel.MID, Request.Form["txtMID"], -kcMoney, MType, MyHs);
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