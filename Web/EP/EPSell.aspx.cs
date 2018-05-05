using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;

namespace WE_Project.Web.EP
{
    public partial class EPSell : BasePage
    {
        protected Model.EPConfig EPCONFIG = new Model.EPConfig();
        protected CommonModel.Sys_BankInfo BankInfo = null;
        protected string rdMoney;
        protected override void SetValue()
        {
            EPCONFIG = BLL.EPConfig.EPConfigModel;
            Model.BankModel ban = BLL.BankModel.GetList("MID='" + TModel.MID + "' and IsPrimary=1").FirstOrDefault();
            if (ban != null)
                BankInfo = new CommonBLL.Sys_BankInfoBLL().GetModel(ban.Bank);
            //300的倍数
            for (int i = 1; i <= 10; i++)
            {
                rdMoney += "<input name='rdMoney' id='rdMoney" + i.ToString() + "' value='" + (i * 300).ToString() + "' type='radio' />" + (i * 300).ToString() + "&nbsp;";
            }


        }

        protected override string btnAdd_Click()
        {
            //验证身份证号
            //if (Request.Form["txtNumID"].Trim() != TModel.NumID)
            //{
            //    return "身份证号校验失败！";
            //}
            if (!BLL.EPConfig.EPConfigModel.EPState)
            {
                return "EP交易已关闭，不能再进行交易";
            }
            BLL.EPList epBll = new BLL.EPList();
            if (!epBll.isTradeTime())
            {
                return "当前不在交易时间内，不允许交易";
            }
            int money = 0;
            try
            {
                money = Convert.ToInt32(Request.Form["rdMoney"].Trim());
            }
            catch
            {
                return "交易金额必须为数字";
            }
            if (money < BLL.EPConfig.EPConfigModel.EPJYMinMoney)
            {
                return "交易金额必须大于" + BLL.EPConfig.EPConfigModel.EPJYMinMoney;
            }
            if (money % BLL.EPConfig.EPConfigModel.EPJYBaseMoney > 0)
            {
                return "交易金额必须是" + BLL.EPConfig.EPConfigModel.EPJYBaseMoney + "倍数";
            }
            if (money > TModel.MConfig.MJJ)
            {
                return "您的" + WE_Project.BLL.Reward.List["MHB"].RewardName + "余额不足";
            }

            if ((money + 15) > (TModel.MConfig.MHB - TModel.MConfig.MHBFreeze < 0 ? TModel.MConfig.MHB : TModel.MConfig.MJJ))
            {
                return "您的" + WE_Project.BLL.Reward.List["MHB"].RewardName + "余额不足，账号余额需至少" + (money + 15).ToString();
            }

            Hashtable hs = new Hashtable();
            Model.EPList eplist = new Model.EPList();
            eplist.SellState = 0;
            eplist.SellMID = TModel.MID;
            eplist.SellDate = DateTime.Now;
            eplist.MoneyType = "MJB";
            //扣除手续费
            eplist.Money = money;
            //扣除手续费
            //BLL.Member.UpdateConfigTran(eplist.BuyMID, "MHB", (-money * BLL.EPConfig.EPConfigModel.EPTakeOffMoney).ToString(), null, false, SqlDbType.Decimal, hs);
            eplist.TakeOffMoney = money * BLL.EPConfig.EPConfigModel.EPTakeOffMoney;
            BLL.EPList.Insert(eplist, hs);
            //挂卖减少钱数
            decimal costMoney = money + money * BLL.EPConfig.EPConfigModel.EPTakeOffMoney;
            BLL.Member.UpdateConfigTran(eplist.SellMID, "MHB", (-costMoney).ToString(), null, false, SqlDbType.Decimal, hs);

            if (BLL.CommonBase.RunHashtable(hs))
            {
                return "1";
            }
            return "挂卖失败，请重试";
        }
    }
}