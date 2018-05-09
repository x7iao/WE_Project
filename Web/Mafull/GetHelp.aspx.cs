using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace WE_Project.Web.Mafull
{
    public partial class GetHelp : BasePage
    {
        protected string isNoBank = string.Empty;
        protected override void SetPowerZone()
        {
            //mflmoney = 0;
            //List<Model.MOfferHelp> list = BLL.MOfferHelp.GetList("SQMID='" + TModel.MID + "' and PPState=3");
            //foreach (Model.MOfferHelp offer in list)
            //{
            //    if ((DateTime.Now - (DateTime)offer.CompleteTime).TotalMinutes >= BLL.MMMConfig.Model.MatchingHour)
            //    {
            //        mflmoney += offer.SQMoney + offer.TotalInterest + offer.TotalSincerity;
            //    }
            //}
            //var list= BLL.BankModel.GetList("MID='" + TModel.MID + "'");
            //if (list.Count <= 0)
            //    isNoBank = "<tr><td>请在[信息管理]—[银行卡管理]中添加到账银行卡信息。</td></tr>";
            //repBankList.DataSource = list;
            //repBankList.DataBind();
        }

        protected string GetBankName(object bank)
        {
            return new CommonBLL.Sys_BankInfoBLL().GetModel(bank).Name; ;
        }

        /// <summary>
        /// 货币购买
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override string btnAdd_Click()
        {
            int sqMoney = int.Parse(Request.Form["txtSQMoneyGet"]);
            string MoneyType = "MHB";
            if (Request.Form["rdo"] == "MHB")
            {
                MoneyType = "MHB";
            }
            else if (Request.Form["rdo"] == "MJB")
            {
                MoneyType = "MJB";
            }
            else if (Request.Form["rdo"] == "MCW")
            {
                MoneyType = "MCW";
            }

            return BLL.MGetHelp.GetHelp(TModel, MoneyType, sqMoney);
        }
    }
}