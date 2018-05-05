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
                    if (Request.Form["txtMID"] == "MHB")
                    {
                        moneyType = "MHB";
                    }
                    else if (Request.Form["txtMID"] == "MCW")
                    {
                        moneyType = "MCW";
                    }
                    else if (Request.Form["txtMID"] == "MJB")
                    {
                        moneyType = "MJB";
                    }
                    //else if (Request.Form["txtMID"] == "MGP")
                    //{
                    //    moneyType = "MGP";
                    //}
                    if (BLL.ChangeMoney.EnoughChange(Request.Form["txtMID"], int.Parse(Request.Form["txtMHB"]), moneyType))
                    {
                        Hashtable MyHs = new Hashtable();
                        BLL.ChangeMoney.KFMoneyChange(Request.Form["txtMID"], BLL.Member.ManageMember.TModel.MID, int.Parse(Request.Form["txtMHB"]), moneyType, MyHs);
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