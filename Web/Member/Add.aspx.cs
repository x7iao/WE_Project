using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommonBLL;

namespace WE_Project.Web.Member
{
    public partial class Add : BasePage
    {
        protected override void SetPowerZone()
        {
            txtMTJ.Value = TModel.MID;
            spmtjName.InnerHtml = TModel.MName;
            if (!string.IsNullOrEmpty(Request.QueryString["mid"]))
            {
                if (string.IsNullOrEmpty(txtMTJ.Value))
                    txtMTJ.Value = Request.QueryString["mid"].Trim();
            }
            BindDdlPwdQuestion();
        }

        protected void BindDdlPwdQuestion()
        {
            BLL.Sys_SecurityQuestion BLL = new BLL.Sys_SecurityQuestion();
            string whereStr = " IsDeleted=0 and Status=1";
            IList<Model.Sys_SecurityQuestion> list = BLL.GetList(whereStr);
            ddlQuestion.DataSource = list;
            ddlQuestion.DataTextField = "Question";
            ddlQuestion.DataValueField = "ID";
            ddlQuestion.DataBind();
        }

        public Model.Member MemberMode
        {
            get
            {
                Model.Member model = new Model.Member();
                //model.Email = Request.Form["txtEmail"].Trim();
                model.MName = Request.Form["txtMName"].Trim();
                model.Password = Request.Form["txtPassword"].Trim();
                model.SecPsd = Request.Form["txtSecPsd"].Trim();
                model.Tel = Request.Form["txtTel"].Trim();
                model.MID = Request.Form["txtMID"].Trim();
                model.RoleCode = "Notactive";
                model.AgencyCode = "001";
                model.MAgencyType = BLL.Configuration.Model.SHMoneyList[model.AgencyCode];
                model.SHMoney = model.MAgencyType.Money;
                //model.NumID = Request.Form["txtNumID"].Trim();
                //model.WeChat = Request.Form["txtWeChat"].Trim();
                //model.AliPay = Request.Form["txtAliPay"].Trim();
                //model.Province = Request.Form["hidProvince"].Trim();
                //model.QQ = Request.Form["txtQQ"].Trim();
                model.IsClock = false;
                model.IsClose = false;
                model.MState = false;
                model.MTJ = Request.Form["txtMTJ"].Trim();
                //model.MBD = Request.Form["txtMBD"].Trim();
                model.MBD = model.MTJ;
                //model.GCount = int.Parse(Request.Form["txtGCount"]);
                if (string.IsNullOrEmpty(model.MBD))
                {
                    //model.MBD = BLL.Member.GetMBD(model.MTJ);
                    model.MBD = model.MTJ;
                }
                //model.MBDIndex = int.Parse(Request.Form["ddlMBDIndex"]);
                model.MSH = model.MTJ;
                //if (string.IsNullOrEmpty(model.MSH))
                //    model.MSH = BLL.Member.ManageMember.TModel.MID;
                model.MCreateDate = DateTime.Now;
                model.MDate = DateTime.MaxValue;
                model.Salt = new Random().Next(10000, 99999).ToString();
                model.Bank = Request.Form["txtBank"];
                model.BankCardName = Request.Form["txtBankCardName"];
                model.BankNumber = Request.Form["txtBankNumber"];
                model.Branch = Request.Form["txtBranch"];
                return model;
            }
        }
        private Model.BankModel BankInfo
        {
            get
            {
                Model.BankModel model = new Model.BankModel();
                model.Bank = Request.Form["txtBank"];
                model.BankCardName = Request.Form["txtBankCardName"];
                model.BankCreateDate = DateTime.Now;
                model.BankNumber = Request.Form["txtBankNumber"];
                model.Branch = Request.Form["txtBranch"];
                model.MID = Request.Form["txtMID"];
                model.IsPrimary = true;
                return model;
            }
        }

        /// <summary>
        /// 注册会员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override string btnAdd_Click()
        {
            string error = "";


            if (BLL.Configuration.Model.DFHXFCount==1)
            {
                //string code = BLL.SMS.GetSKeyBuyTel(Request.Form["txtTel"].Trim(), Model.SMSType.ZCYZ);
                //if ((string.IsNullOrEmpty(code) || code != Request.Form["txtTelCode"].Trim()))
                //{
                //    error += "手机验证码错误！";
                //    return error;
                //}
            }


            //List<Model.Member> list = BllModel.GetMemberEntityList("NumID='" + Request.Form["txtNumID"].Trim() + "'");
            //if (list.Count >= BLL.Configuration.Model.MaxBuyGCount)
            //{
            //    error += "该手机号注册的账号已达上限";
            //    return error;
            //}
           
            //if (Request.Form["txtBankNumber"].Trim() != null)
            //{
            //    List<Model.Member> list1 = BllModel.GetMemberEntityList("BankNumber='" + Request.Form["txtBankNumber"].Trim() + "'");
            //    if (list1.Count >= BLL.Configuration.Model.MaxBuyGCount)
            //    {
            //        error += "该银行卡已绑定,请更换其它帐号";
            //        return error;
            //    }
            //}
            //if (Request.Form["txtAliPay"].Trim() != null)
            //{
            //    List<Model.Member> list2 = BllModel.GetMemberEntityList("Alipay='" + Request.Form["txtAliPay"].Trim() + "'");
            //    if (list2.Count >= BLL.Configuration.Model.MaxBuyGCount)
            //    {
            //        error += "该支付宝已绑定,请更换其它帐号";
            //        return error;
            //    }
            //}

            int addcount= Convert.ToInt32(BLL.CommonBase.GetSingle("SELECT count(*) FROM Member WHERE DATEDIFF(DAY,MCreateDate,GETDATE())=0 AND RoleCode NOT IN('Manage');"));
            if (BLL.Configuration.Model.DayRegeditNumber <= addcount) 
            {
                error += "每天注册人数超出上限，请明天再来";
                return error;
            }

            if (!BLL.Member.getCardNameCount(MemberMode))
            {
                error += "每天注册人数超出上限，请明天再来";
                return error;
            }

            //if (Request.Form["txtNumID"].Trim() != null)
            //{
            //    List<Model.Member> list1 = BllModel.GetMemberEntityList("NumID='" + Request.Form["txtNumID"].Trim() + "'");
            //    if (list1.Count >= BLL.Configuration.Model.MaxBuyGCount)
            //    {
            //        error += "该身份证号码已绑定,请更换其它号码";
            //        return error;
            //    }
            //}

            //查看会员是否激活，没激活的不能推荐会员
            if (TModel.RoleCode == "Notactive")
            {
                error += "您的账号还未激活，不能注册新的会员！";
            }

            if (string.IsNullOrEmpty(error))
            {
                Model.Member model = BllModel.InsertAndReturnEntity(MemberMode, false, ref error);

                if (model != null)
                {
                    //Model.Sys_SQ_Answer objAnswer = new Model.Sys_SQ_Answer();
                    //objAnswer.MID = model.ID;
                    //objAnswer.QId = long.Parse(Request.Form["ddlQuestion"]);
                    //objAnswer.Answer = Request.Form["txtAnswer"];
                    //objAnswer.CreatedBy = model.MID;
                    //if (new BLL.Sys_SQ_Answer().Insert(objAnswer))
                    {
                        return "注册成功";
                    }
                }
                else
                {
                    return error;
                }
            }
            return error;
        }
    }
}