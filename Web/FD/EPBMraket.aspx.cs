using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.FD
{
    public partial class EPBMraket : BasePage
    {
        protected int MyFDCount = 0;//我的富达币
        protected int AFDTotalSellCount = 0;//大盘总量
        protected int AFDSellCount = 0;//成交量

        protected override void SetPowerZone()
        {
            MyFDCount = Convert.ToInt32(BLL.CommonBase.GetSingle("select (select isnull(SUM(buycount),0) from FDBuyList where BuyMID='" + TModel.MID + "' and CFState=0 and BuyState=0 and BuyFDName='B')+" +
"(select ISNULL(sum(selltotalcount-sellcount),0) from FDSellList where SellMID='" + TModel.MID + "' and SellCount<2 and SellFDName='B')"));
            AFDTotalSellCount = Convert.ToInt32(BLL.CommonBase.GetSingle("select isnull(SUM(selltotalcount),0) from FDSellList where chaifencode=" + BLL.FDConfig.FDConfigModel["B"].ChaiFenCode + " and SellState<3 and SellFDName='B'"));
            AFDSellCount = Convert.ToInt32(BLL.CommonBase.GetSingle("select isnull(SUM(SellCount),0) from FDSellList where chaifencode=" + BLL.FDConfig.FDConfigModel["B"].ChaiFenCode + " and SellState<3 and SellFDName='B'"));
            //AFDSellCount = Convert.ToInt32(BLL.CommonBase.GetSingle("select isnull(SUM(buycount),0) from FDBuyList where CFState=0 and BuyState=0 and BuyFDName='B'"));
        }

        private Model.FDBuyList FDBuyMode
        {
            get
            {
                return new Model.FDBuyList
                {
                    BuyCount = Convert.ToInt32(Request.Form["txtJYCount"]),
                    BuyDate = DateTime.Now,
                    BuyFDName = "B",
                    BuyMID = TModel.MID,
                    BuyMoney = 0,
                    BuyPrice = BLL.FDConfig.FDConfigModel["B"].FDPrice,
                    MoneyType = "MGP"
                };
            }
        }

        protected override string btnAdd_Click()
        {
            try
            {
                if (Convert.ToInt32(Request.Form["txtJYCount"]) > 0)
                {
                    return BLL.FDBuyList.Insert(FDBuyMode);
                }
                else
                {
                    return "购买数量不正确";
                }
            }
            catch
            {
                return "参数有误";
            }
        }
    }
}