﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.Mafull
{
    public partial class JTAccont2 : BasePage
    {
        protected override void SetValue()
        {
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
            if (WE_Project.BLL.MHelpMatch.MMMChangeDKMID() && WE_Project.BLL.MHelpMatch.MMMAutoGetMoney())
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
            if ( BLL.ChangeMoney.DJBPD())
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
            if (BLL.ChangeMoney.JDGLJ())
            {
                return "操作成功";
            }
            else
            {
                return "操作失败";
            }
        }
    }
}