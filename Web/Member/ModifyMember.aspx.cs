using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace WE_Project.Web.Member
{
    public partial class ModifyMember : BasePage
    {
        protected Model.Member model;
        protected override void SetValue(string id)
        {
            BindDdlPwdQuestion(ddl_PwdQuestion);
            foreach (Model.Roles item in BLL.Roles.RolsList.Values.ToList().Where(emp => emp.VState).ToList())
                ddlMemberType.Items.Add(new ListItem(item.RName, item.RType));//角色

            //会员级别
            ddlSHMoney.DataSource = BLL.Configuration.Model.SHMoneyTable;
            ddlSHMoney.DataTextField = "MAgencyName";
            ddlSHMoney.DataValueField = "MAgencyType";
            ddlSHMoney.DataBind();

            string mid = HttpUtility.UrlDecode(Request["id"].Trim());
            model = BllModel.GetModel(mid);
            MemberModel = model;
        }

        public Model.Member MemberModel
        {
            get
            {
                Model.Member model = BllModel.GetModel(Request.Form["txtMID"].Trim());
                //model.Address = Request.Form["txtAddress"].Trim();
                model.Email = Request.Form["txtEmail"];
                model.MName = Request.Form["txtMName"].Trim();
                if (!string.IsNullOrEmpty(Request.Form["txtPassword"].Trim()))
                {
                    model.Password = Request.Form["txtPassword"].Trim();
                }
                if (!string.IsNullOrEmpty(Request.Form["txtSecPsd"].Trim()))
                {
                    model.SecPsd = Request.Form["txtSecPsd"].Trim();
                }
                model.AliPay = Request.Form["txtAliPay"];
                model.Province = Request.Form["txtProvince"];
                //model.City = Request.Form["ddlCity"].Trim();
                //model.Zone = Request.Form["ddlZone"].Trim();
                model.Tel = Request.Form["txtTel"].Trim();
                //model.MTJ = Request.Form["txtMTJ"].Trim();
                //model.MBD = Request.Form["txtMBD"].Trim();
                //model.MSH = Request.Form["txtMSH"].Trim();
                //model.MBDIndex = int.Parse(Request.Form["txtMBDIndex"].Trim() != "" ? Request.Form["txtMBDIndex"].Trim() : "0");
                model.RoleCode = Request.Form["ddlMemberType"];
                model.IsClose = Request.Form["chkIsClose"] == "on";
                model.IsClock = Request.Form["chkIsClose"] == "on";
                model.AgencyCode = Request.Form["ddlSHMoney"];
                //model.NumID = Request.Form["txtNumID"];
                //model.Province = Request.Form["hidProvince"];
                //model.QQ = Request.Form["txtQQ"];
                model.Bank = Request.Form["txtBank"];
                model.BankCardName = Request.Form["txtBankCardName"];
                model.BankNumber = Request.Form["txtBankNumber"];
                model.Branch = Request.Form["txtBranch"];
                if (!string.IsNullOrEmpty(Request.Form["txtPassword"].Trim()))
                {
                    model.Password = Request.Form["txtPassword"].Trim();
                    model.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(model.Password + model.Salt, "MD5").ToUpper();
                }
                if (!string.IsNullOrEmpty(Request.Form["txtSecPsd"].Trim()))
                {
                    model.SecPsd = Request.Form["txtSecPsd"].Trim();
                    model.SecPsd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(model.SecPsd + model.Salt, "MD5").ToUpper();
                }
                if (model.MConfig != null)
                {
                    model.MConfig.MJB = decimal.Parse(Request.Form["txtMJB"].Trim() != "" ? Request.Form["txtMJB"].Trim() : "0");
                    model.MConfig.MHB = decimal.Parse(Request.Form["txtMHB"].Trim() != "" ? Request.Form["txtMHB"].Trim() : "0");
                    //model.MConfig.MCW = decimal.Parse(Request.Form["txtMCW"].Trim() != "" ? Request.Form["txtMCW"].Trim() : "0");
                    model.MConfig.MGP = decimal.Parse(Request.Form["txtMGP"].Trim() != "" ? Request.Form["txtMGP"].Trim() : "0");
                    //model.MConfig.JJTypeList = Request.Form["txtJJTypeList"].Trim();
                    //model.MConfig.JTFHState = bool.Parse(Request.Form["ddlJTFHState"]);
                    //model.MConfig.DTFHState = bool.Parse(Request.Form["ddlDTFHState"]);
                    model.MConfig.TXStatus = Request.Form["cbkIsTX"] == "1";
                    model.MConfig.ZZStatus = Request.Form["chkIsZZ"] == "1";
                    model.MConfig.SHMoney = int.Parse(Request.Form["txtSHMoney"]);
                    model.MConfig.PPLeavel = int.Parse(Request.Form["txtPPLeavel"]);
                    //if (model.AgencyCode == "002")
                    //{
                    //    model.MConfig.NomalTotalThaw = decimal.Parse(Request.Form["txtTotalThaw"]);
                    //}
                    //else if (model.AgencyCode != "001")
                    //{
                    //    model.MConfig.VIPTotalThaw = decimal.Parse(Request.Form["txtTotalThaw"]);
                    //}
                }
                return model;
            }
            set
            {
                if (value != null)
                {
                    Model.Member mtjmodel = BLL.Member.ManageMember.GetModel(value.MTJ);
                    txtAliPay.Value = value.AliPay;
                    txtMID.Value = value.MID;
                    txtMName.Value = value.MName;
                    txtTel.Value = value.Tel;
                    txtMTJ.Value = value.MTJ;
                    ddlMemberType.Value = value.RoleCode.ToString();
                    chkIsClock.Checked = value.IsClock;
                    chkIsClose.Checked = value.IsClose;
                    ddlSHMoney.Value = value.AgencyCode.ToString();
                    txtAliPay.Value = value.AliPay.ToString();
                    txtBank.Value = value.Bank;
                    txtBankCardName.Value = value.BankCardName;
                    txtBankNumber.Value = value.BankNumber;
                    txtBranch.Value = value.Branch;
                    txtProvince.Value = value.Province;
                    if (value.MConfig != null)
                    {
                        txtMJB.Value = value.MConfig.MJB.ToString();
                        txtMHB.Value = value.MConfig.MHB.ToString();
                        txtMGP.Value = value.MConfig.MGP.ToString("F0");
                        //txtMCW.Value = value.MConfig.MCW.ToString();
                        txtSHMoney.Value = value.MConfig.SHMoney.ToString();
                        txtPPLeavel.Value = value.MConfig.PPLeavel.ToString();
                    }
                }
            }
        }
        protected void UpdateQuestion(string mid, Hashtable MyHas)
        {
            Model.Sys_SQ_Answer objAns = new BLL.Sys_SQ_Answer().GetList("MID=" + mid + " and IsDeleted=0").FirstOrDefault();
            if (objAns != null)
            {
                objAns.QId = long.Parse(Request.Form["ddl_PwdQuestion"]);
                objAns.Answer = Request.Form["pwdAnswer"];
                new BLL.Sys_SQ_Answer().Update(objAns, MyHas);
            }
            else
            {
                objAns = new Model.Sys_SQ_Answer();
                objAns.QId = long.Parse(Request.Form["ddl_PwdQuestion"]);
                objAns.Answer = Request.Form["pwdAnswer"];
                objAns.MID = long.Parse(mid);
                objAns.IsDeleted = false;
                objAns.CreatedBy = BLL.Member.ManageMember.TModel.MID;
                objAns.CreatedTime = DateTime.Now;
                objAns.Code = Guid.NewGuid().ToString();
                objAns.Status = 1;
                new BLL.Sys_SQ_Answer().Insert(objAns, MyHas);
            }
        }

        /// <summary>
        /// 更新基本资料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override string btnModify_Click()
        {
            Hashtable MyHs = new Hashtable();
            if (Request.Form["chkCloseAll"] == "on" || Request.Form["chkClockAll"] == "on")
            {
                List<Model.Member> list = BllModel.GetMemberEntityList("MID in (select mid from getTreeBuyMID('" + MemberModel.MID + "'))");
                foreach (Model.Member item in list)
                {
                    if (Request.Form["chkCloseAll"] == "on")
                    {
                        item.IsClose = MemberModel.IsClose;
                        item.IsClock = MemberModel.IsClock;
                    }
                    if (Request.Form["chkClockAll"] == "on")
                        item.IsClock = MemberModel.IsClock;
                    BllModel.Update(item, MyHs);
                }
            }

            BllModel.Update(MemberModel, MyHs);
            //更新会员的密保问题
            UpdateQuestion(MemberModel.ID.ToString(), MyHs);

            if (BLL.CommonBase.RunHashtable(MyHs))
            {
                return "操作成功";
            }
            return "操作失败";
        }

        protected override string btnOther_Click()
        {
            Hashtable MyHs = new Hashtable();
            MyHs.Add("delete from MOfferHelp where PPState = 0 and SQMID='" + MemberModel.MID + "'", null);
            MyHs.Add("update MHelpMatch set MatchTime=DATEADD(DD,-4,MatchTime) where OfferMID='" + MemberModel.MID + "'", null);
            if (BLL.CommonBase.RunHashtable(MyHs))
            {
                return "删除成功";
            }
            return "删除失败";
        }
    }
}