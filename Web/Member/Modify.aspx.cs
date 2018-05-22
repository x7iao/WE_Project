using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommonBLL;
using System.Collections;

namespace WE_Project.Web.Member
{
    public partial class Modify : BasePage
    {
        protected override void SetPowerZone()
        {
            if (!TModel.Role.IsAdmin)
            {
                //if (!string.IsNullOrEmpty(txtTel.Value))
                {
                    txtTel.Attributes.Add("readonly", "readonly");
                }
                //if (TModel.MState)
                //{
                //    txtMName.Attributes.Add("readonly", "readonly");
                //    txtWeChat.Attributes.Add("readonly", "readonly");
                //    txtAlipay.Attributes.Add("readonly", "readonly");
                //    txtBranch.Attributes.Add("readonly", "readonly");
                //    txtBankCardName.Attributes.Add("readonly", "readonly");
                //    txtBankNumber.Attributes.Add("readonly", "readonly");
                //    txtBank.Attributes.Add("readonly", "readonly");
                //}
            }
        }

        protected override void SetValue()
        {
            MemberModel = TModel;
        }

        public Model.Member MemberModel
        {
            get
            {
                Model.Member model = TModel;
                model.MName = Request.Form["txtMName"];
                model.Tel = Request.Form["txtTel"];
                model.Bank = Request.Form["txtBank"];
                model.Branch = Request.Form["txtBranch"];
                model.BankNumber = Request.Form["txtBankNumber"];
                model.BankCardName = Request.Form["txtBankCardName"];
                model.AliPay = Request.Form["txtAliPay"];
                model.MConfig.HLMoneyState =Request.Form["txtHLMoneyState"] == "1" ;
                model.QQ = Request.Form["hduploadPic1"];
                if (model.ZDStatus)
                {
                    model.ZDStatus = Request.Form["txtZDStatus"] == "1";
                }
                
                model.WeChat = Request.Form["txtWeChat"];
                return model;
            }
            set
            {
                if (value != null)
                {
                    txtMID.Value = value.MID;
                    txtBank.Value = value.Bank;
                    txtBankNumber.Value = value.BankNumber;
                    txtBranch.Value = value.Branch;
                    txtMName.Value = value.MName;
                    txtBankCardName.Value = value.BankCardName;
                    txtAlipay.Value = value.AliPay;
                    txtTel.Value = value.Tel;
                    txtWeChat.Value = value.WeChat;
                    hduploadPic1.Value = value.QQ;
                    txtHLMoneyState.Value = value.MConfig.HLMoneyState ? "1" : "0";
                    txtZDStatus.Value = value.ZDStatus ? "1" : "0";
                }
            }
        }

        /// <summary>
        /// 更新基本资料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override string btnModify_Click()
        {
            string error = "";
            if (string.IsNullOrEmpty(error))
            {
                if (Request.Form["txtBankNumber"].Trim() != null)
                {
                    List<Model.Member> list1 = BllModel.GetMemberEntityList("BankNumber='" + Request.Form["txtBankNumber"].Trim() + "' and MID <> '" + TModel.MID + "'");
                    if (list1.Count >0)
                    {
                        error += "该银行卡已绑定,请更换其它帐号";
                        return error;
                    }
                }
                //if (Request.Form["txtAliPay"].Trim() != null)
                //{
                //    List<Model.Member> list2 = BllModel.GetMemberEntityList("Alipay='" + Request.Form["txtAliPay"].Trim() + "' and MID <> '" + TModel.MID + "'");
                //    if (list2.Count > 0)
                //    {
                //        error += "该支付宝已绑定,请更换其它帐号";
                //        return error;
                //    }
                //}
                Model.Member m = BLL.Member.GetModelByMID(MemberModel.MID);
                if (!m.ZDStatus && MemberModel.ZDStatus)
                    return "防撞单关闭后不可再次开启";


                if (!BLL.Member.getCardNameCount(MemberModel))
                {
                   return "三代内不能有同名开户账号";
                }

                Hashtable hs = new Hashtable();
                BllModel.Update(MemberModel, hs);
                BLL.Member.UpdateConfigTran(MemberModel.MID, "HLMoneyState", MemberModel.MConfig.HLMoneyState.ToString(), null, true, System.Data.SqlDbType.Bit, hs) ;

                if (BLL.CommonBase.RunHashtable(hs))
                {
                    return "1";
                }
                return "操作失败";
            }
            return error;
        }

    }
}