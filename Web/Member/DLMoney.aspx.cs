using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace WE_Project.Web.Member
{
    public partial class DLMoney : BasePage
    {
        protected string UpDFHMoney = "未领取";
        protected decimal DayFHMoney = 0;
        protected override void SetValue()
        {
            Model.ChangeMoney change2 = BLL.ChangeMoney.GetTopModel("DL", true, TModel.MID);
            if (change2 != null)
                UpDFHMoney = change2.ChangeDate.ToString("yyyy-MM-dd HH:mm:ss");


            //DayFHMoney = TModel.MAgencyType.DLMoney;
        }
        /// <summary>
        /// 分红
        /// </summary>
        /// <returns></returns>
        protected override string btnAdd_Click()
        {
            if (!TModel.IsClock && !TModel.Role.IsAdmin)
            {
                //if (BLL.Member.GetTypeSumJJ(TModel.MID, "DL", DateTime.Now) == 0)
                //{
                //    if (TModel.MAgencyType.DLMoney > 0)
                //    {
                //        if (BLL.ChangeMoney.DLMoneyChangeTran(TModel))
                //            return "恭喜您，成功领取今日的签到奖";
                //        else
                //            return "很遗憾，您的今日签到奖领取失败";
                //    }
                //    else
                //    {
                //        return "很遗憾，您的级别不能领取今日的签到奖";
                //    }
                //}
                //else
                    return "您已领取过今日的签到奖了";
            }
            else
            {
                return "您不符合领取条件";
            }
        }
    }
}