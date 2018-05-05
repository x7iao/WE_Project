using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace WE_Project.Web.ChangeMoney
{
    public partial class DLMoney : BasePage
    {
        //protected string UpKTMoney = "未领取";
        protected string UpDFHMoney = "未领取";
        protected string UpFLMoney = "未领取";
        protected decimal DayFHMoney = 0;
        protected decimal DayKTMoney = 0;
        protected decimal DayFLMoney = 0;
        protected override void SetValue()
        {
            //Model.ChangeMoney change = BLL.ChangeMoney.GetTopModel("KT", true, BllModel.TModel.MID);
            //if (change != null)
            //    UpKTMoney = change.ChangeDate.ToString("yyyy-MM-dd HH:mm:ss");
            Model.ChangeMoney change2 = BLL.ChangeMoney.GetTopModel("DFH", true, BllModel.TModel.MID);
            if (change2 != null)
                UpDFHMoney = change2.ChangeDate.ToString("yyyy-MM-dd HH:mm:ss");

            //DayFHMoney = TModel.MAgencyType.Money * TModel.MAgencyType.DayFHFloat;
            //DayKTMoney = ((int)(BllModel.TModel.MConfig.TJMoney / BLL.Configuration.Model.KTBaseMoney)) * BLL.Configuration.Model.DayKTMoney;
            //DayFLMoney = BllModel.GetMemberAndConfigEntityList("FMID='" + BllModel.TModel.MID + "'").Where(emp => emp.MConfig.JTFHState).Count() * BLL.Configuration.Model.DayFLMoney;
        }
        /// <summary>
        /// 分红
        /// </summary>
        /// <returns></returns>
        protected override string btnAdd_Click()
        {
            if (!TModel.IsClock && !TModel.Role.IsAdmin && TModel.MState)
            {
                //if (TModel.MConfig.TotalDFHMoney < TModel.MAgencyType.DFHTopMoney)
                {
                    if (BLL.Member.GetTypeSumJJ(TModel.MID, "DFH", DateTime.Now) == 0)
                    {
                        decimal money = 0;//TModel.MAgencyType.Money * TModel.MAgencyType.DayFHFloat;
                        if (money > 0)
                        {
                            Hashtable hs = new Hashtable();
                            BLL.ChangeMoney.HBChangeTran(money, BLL.Member.ManageMember.TModel.MID, TModel.MID, "DFH", TModel, "MHB", "", hs);
                            if (BLL.CommonBase.RunHashtable(hs))
                                return "恭喜您，成功领取今日的日分红";
                            else
                                return "很遗憾，您的今日日分红领取失败";
                        }
                        else
                        {
                            return "很遗憾，您的级别不能领取今日的日分红";
                        }
                    }
                    else
                        return "您已领取过今日的日分红了";
                }
                //else
                //{
                //    return "您的日分经已经领取完了";
                //}
            }
            else
            {
                return "您未激活或被冻结等原因，不符合领取条件";
            }
        }

    }
}