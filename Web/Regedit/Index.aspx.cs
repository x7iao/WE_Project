using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CommonBLL;

namespace WE_Project.Web.Regedit
{
    public partial class Index : System.Web.UI.Page
    {
        protected Model.WebSetInfo WebModel = BLL.WebSetInfo.Model;
        protected void Page_Load(object sender, EventArgs e)
        {
            IList<Model.Sys_SecurityQuestion> list = new BLL.Sys_SecurityQuestion().GetList("IsDeleted=0 and Status=1");
            ddlQuestion.DataSource = list;
            ddlQuestion.DataValueField = "Id";
            ddlQuestion.DataTextField = "Question";
            ddlQuestion.DataBind();
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["mid"]))
                {
                    txtMTJ.Value = Request.QueryString["mid"];
                    txtMTJ.Style.Add("readonly", "readonly");
                }
            }
        }

        public Model.Member MemberMode
        {
            get
            {
                Model.Member model = new Model.Member();
                model.MID = Request.Form["txtMID"].Trim();
                model.MName = Request.Form["txtMName"].Trim();
                model.Password = Request.Form["txtPwd1"].Trim();
                model.SecPsd = Request.Form["txtSecPwd1"].Trim();
                model.Tel = Request.Form["txtTel"].Trim();
                model.MID = Request.Form["txtMID"].Trim();
                model.Address = "推广注册";
                model.RoleCode = "Notactive";
                model.AgencyCode = "001";
                model.MAgencyType = BLL.Configuration.Model.SHMoneyList[model.AgencyCode];
                model.IsClock = false;
                model.IsClose = false;
                model.MState = false;
                model.MTJ = Request.Form["txtMTJ"].Trim();
                model.MBD = model.MTJ;
                //model.NumID = Request.Form["txtNumID"];
                //if (string.IsNullOrEmpty(model.MBD))
                //{
                //    model.MBD = model.MTJ;
                //}
                model.MSH = model.MTJ;
                //model.MSH = BLL.Member.ManageMember.TModel.MID;
                model.MCreateDate = DateTime.Now;
                model.MDate = DateTime.MaxValue;
                model.Salt = new Random().Next(10000, 99999).ToString();
                //if (Request.Form["txtEmail"] != null)
                //    model.Email = Request.Form["txtEmail"].Trim();
                model.Bank = Request.Form["txtBank"];
                model.BankCardName = Request.Form["txtBankCardName"];
                model.BankNumber = Request.Form["txtBankNumber"];
                model.Branch = Request.Form["txtBranch"];
                model.NumID = Request.Form["txtNumID"];
                model.WeChat = Request.Form["txtWeChat"];
                model.AliPay = Request.Form["txtAliPay"];
                //model.QQ = Request.Form["txtQQ"];
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

        protected void btnOK_Click(object sender, EventArgs e)
        {
            string error = "";
            string code = BLL.SMS.GetSKeyBuyTel(Request.Form["txtTel"].Trim(), Model.SMSType.ZCYZ);
            if ((string.IsNullOrEmpty(code) || code != Request.Form["txtTelCode"].Trim()))
            {
                error = "手机验证码错误";
                Response.Write("<script>alert('" + error + "');</script>");
            }
            else
            {
                Model.Member mtjmodel = BLL.Member.ManageMember.GetModel(MemberMode.MTJ);

                if (mtjmodel == null)
                {
                    error = "不存在该推荐人！";
                    Response.Write("<script>alert('" + error + "');</script>");
                }
                else
                {
                    List<Model.Member> list = BLL.Member.GetMemberList("Tel='" + Request.Form["txtTel"].Trim() + "'");
                    if (list.Count >= BLL.Configuration.Model.MaxBuyGCount)
                    {
                        error = "该手机号码已被注册！";
                        Response.Write("<script>alert('" + error + "');</script>");
                    }
                    else
                    {
                        if (Request.Form["txtBankNumber"].Trim() != null)
                        {
                            List<Model.Member> list1 = BLL.Member.GetMemberList("BankNumber='" + Request.Form["txtBankNumber"].Trim() + "'");
                            if (list1.Count >= BLL.Configuration.Model.MaxBuyGCount)
                            {
                                error = "该银行卡已绑定,请更换其它帐号";
                                Response.Write("<script>alert('" + error + "');</script>");
                            }
                        }
                        else
                        {
                            //if (Request.Form["txtAliPay"].Trim() != null)
                            //{
                            //    List<Model.Member> list2 = BLL.Member.GetMemberList("Alipay='" + Request.Form["txtAliPay"].Trim() + "'");
                            //    if (list2.Count >= BLL.Configuration.Model.MaxBuyGCount)
                            //    {
                            //        error = "该支付宝已绑定,请更换其它帐号";
                            //        Response.Write("<script>alert('" + error + "');</script>");
                            //    }
                            //}
                            //else
                            {
                                //查看会员是否激活，没激活的不能推荐会员
                                if (mtjmodel.RoleCode == "Notactive" || !mtjmodel.MState)
                                {
                                    error += "您填写的推荐人账号还未激活，暂不能作为推荐人，请填写其他推荐人账号或通知推荐人激活账号！";
                                    Response.Write("<script>alert('" + error + "');</script>");
                                }
                                else
                                {
                                    Model.Member model = WE_Project.BLL.Member.ManageMember.InsertAndReturnEntity(MemberMode, false, ref error);
                                    if (model != null)
                                    {
                                        //Model.Sys_SQ_Answer objAnswer = new Model.Sys_SQ_Answer();
                                        //objAnswer.MID = model.ID;
                                        //objAnswer.QId = long.Parse(Request.Form["ddlQuestion"]);
                                        //objAnswer.Answer = Request.Form["txtAnswer"];
                                        //objAnswer.CreatedBy = model.MID;
                                        //if (new BLL.Sys_SQ_Answer().Insert(objAnswer))
                                        {
                                            Response.Redirect("redirect.htm", false);
                                        }
                                    }
                                    else
                                    {
                                        Response.Write("<script>alert('" + error + "');</script>");
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}