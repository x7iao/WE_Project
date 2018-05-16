using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.Mafull
{
    public partial class JTAccont : BasePage
    {
        string count5 = "0";
        string count10 = "0";
        string count30 = "0";
        protected override void SetValue()
        {

            count5 = BLL.CommonBase.GetSingle("select count(*) from mofferhelp where sqmoney in(5) and moneytype is null and ppstate in(3,4) ").ToString();
            count10 = BLL.CommonBase.GetSingle("select count(*) from mofferhelp where sqmoney in(10) and moneytype is null and ppstate in(3,4) ").ToString();
            count30 = BLL.CommonBase.GetSingle("select count(*) from mofferhelp where sqmoney in(30) and moneytype is null and ppstate in(3,4) ").ToString();
            //获取本次结算信息
            //string[] Fhinfo = BLL.Accounts.GetFHInfo("003", "").Split(',');

            //txtMemberCount.Value = Fhinfo[3];
            //txtTotalMoney.Value = Fhinfo[0];
            //txtDayLineLnterest.Value = Fhinfo[1];
            //txtHonestyLiXi.Value = Fhinfo[2];

            ////日利息
            //txtDayLineLnterestPercent.Value = BLL.MMMConfig.Model.DayLineLnterest.ToString();
            //txtHonestyLiXiPercent.Value = BLL.MMMConfig.Model.HonestyLiXi.ToString();

        }


        protected override string btnAdd_Click()
        {
            if (BLL.MHelpMatch.MMMLiXi())
            {
                return "操作成功";
            }
            else
            {
                return "操作失败";
            }
        }

        protected override string btnModify_Click()
        {
            if (BLL.MOfferHelp.outTimeDHLiXi()&&BLL.Member.Weaken()&&BLL.ChangeMoney.DJWDK()&&BLL.ChangeMoney.TranDayFH())
            {
                return "操作成功";
            }
            else
            {
                return "操作失败";
            }
        }

        protected override string btnOther_Click()
        {
            int type = 0;
            decimal money = 0;
            try
            {
                type = Convert.ToInt32(Request.Form["FHType"]);
                money = Convert.ToDecimal(Request.Form["fhmoney"]);
            }
            catch (Exception e)
            {
                return "操作失败";
            }
            if (type != 5 && type != 10 && type != 30)
                return "分红类型错误";

          return   BLL.ChangeMoney.R_OptionFH(type,money);
            
        }

    }
}