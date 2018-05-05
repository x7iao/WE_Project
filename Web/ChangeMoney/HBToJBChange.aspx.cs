using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace WE_Project.Web.ChangeMoney
{
    public partial class HBToJBChange : BasePage
    {

        /// <summary>
        /// 货币转移
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override string btnAdd_Click()
        {
            //验证身份证号
            //if (Request.Form["txtNumID"].Trim() != TModel.NumID)
            //{
            //    return "身份证号校验失败！";
            //}


            Dictionary<string, List<string>> MoneyType = new Dictionary<string, List<string>>();
            MoneyType.Add("MHB", new List<string> { "MGP" });
            MoneyType.Add("MJB", new List<string> { "MGP" });
            //if (BLL.Configuration.Model.IsTranMoney)
            //{
            //    MoneyType["MHB"].Add("MGP");
            //}
            Model.Member model = TModel;
            if (model.IsClock)
                return "您已被冻结账号";
            if (!string.IsNullOrEmpty(Request.Form["txtMHB"]))
            {
                int money = int.Parse(Request.Form["txtMHB"]);
                if (money > 0)
                {
                    string from = Request.Form["ddlFrom"];
                    string to = Request.Form["ddlTo"];
                    if (MoneyType.ContainsKey(from) && MoneyType[from].Contains(to))
                    {
                        if (money < BLL.Configuration.Model.ZZMinMoney)
                            return "转换金额最小为" + BLL.Configuration.Model.ZZMinMoney;
                        else if ((money - BLL.Configuration.Model.ZZMinMoney) % BLL.Configuration.Model.ZZBaseMoney != 0)
                            return "转换金额应是" + BLL.Configuration.Model.ZZBaseMoney + "的倍数";

                        Hashtable MyHs = new Hashtable();
                        if (BLL.ChangeMoney.EnoughChange(model.MID, money, from))
                        {
                            BLL.ChangeMoney.HBChangeTran(money, TModel.MID, BLL.Member.ManageMember.TModel.MID, "DH", null, from, BLL.Reward.List[to].RewardName, MyHs);
                            BLL.ChangeMoney.HBChangeTran(money, BLL.Member.ManageMember.TModel.MID, TModel.MID, "DH", null, to, "", MyHs);
                            if (BLL.CommonBase.RunHashtable(MyHs))
                                return "1";
                            return "货币转换失败";
                        }
                        else
                        {
                            return "您的" + BLL.Reward.List[from].RewardName + "不足";
                        }
                    }
                    else
                    {
                        return "禁止该类型账号转换！";
                    }
                }
                else
                {
                    return "参数异常";
                }
            }
            else
            {
                return "参数异常";
            }
        }
    }
}