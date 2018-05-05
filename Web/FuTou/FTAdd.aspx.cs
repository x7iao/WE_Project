using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.FuTou
{
    public partial class FTAdd : BasePage
    {
        public string remain = "";
        protected override void SetPowerZone()
        {
            //提供帮助 - 复投
            remain = (BLL.MOfferHelp.GetSumMoney(" SQMID = '" + TModel.MID + "' and PPState in (3,4) ") - BLL.BMember.GetSumMoney(TModel.MID)).ToFixedString();
        }

        private static object obj = new object();

        protected override string btnAdd_Click()
        {
            lock (obj)
            {
                string moneyStr = Request.Form["txtCount"];
                decimal money = 0;
                try
                {
                    money = Convert.ToDecimal(moneyStr);
                    if (money < 0)
                    {
                        return "复投金额必须大于0";
                    }
                }
                catch
                {
                    return "请输入正确的复投金额";
                }
                //剩余可复投钱数
                decimal remainMoney = BLL.MOfferHelp.GetSumMoney(" SQMID = '" + TModel.MID + "' and PPState in (3,4) ") - BLL.BMember.GetSumMoney(TModel.MID);
                if (remainMoney < money)
                {
                    return "您的复投金额已达到上限，请提供帮助完成后再复投";
                }

                if (BLL.ChangeMoney.EnoughChange(TModel.MID, money, "MHB"))
                {
                    Model.BMember model = new Model.BMember();
                    model.AMID = TModel.MID;
                    model.BMID = TModel.MID + DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    model.BMCreateDate = DateTime.Now;
                    model.BMDate = DateTime.MaxValue;
                    model.FHDays = 0;
                    model.YJMoney = 0;
                    model.YJCount = 0;
                    model.BOutMoney = 0;
                    model.BMState = false;
                    model.BCount = money;
                    if (BLL.BMember.Insert(model))
                    {
                        return "复投成功";
                    }
                    else
                    {
                        return "复投失败";
                    }
                }
                else
                {
                    return "您的" + BLL.Reward.List["MHB"].RewardName + "不足";
                }
            }
        }
    }
}