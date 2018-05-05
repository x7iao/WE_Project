using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.Member
{
    public partial class ApplyCenter : BasePage
    {
        protected string type = "";

        protected override void SetPowerZone()
        {

            txtMID.Value = TModel.MID;
            txtMName.Value = TModel.MName;

            type = Request.QueryString["type"];
            if (!string.IsNullOrEmpty(type))
            {
                switch (type)
                {
                    case "vip":
                        hidtype.Value = "3";
                        spCondition.InnerHtml = BLL.WebSetInfo.Model.BTCenterCondition;
                        spTreatment.InnerHtml = BLL.WebSetInfo.Model.BTCenterTreatment;
                        if (TModel.RoleCode.ToUpper() == "VIP")
                        {
                            showmessage.InnerHtml = "您已经是报单中心，无需再次申请！";
                            btnOK.Visible = false;
                            btnCancle.Visible = false;
                        }
                        else if (CheckHasApplyed(TModel.MID, 1, "3") != null)//查看是否申请过
                        {
                            showmessage.InnerHtml = "您已经提出了报单中心申请，请等待管理员审批！";
                            btnOK.Visible = false;
                        }
                        else
                        {
                            showmessage.InnerHtml = "您当前未申请过报单中心！";
                            btnCancle.Visible = false;
                        }
                        break;
                    case "service":
                        //hidtype.Value = "2";
                        //spCondition.InnerHtml = BLL.WebSetInfo.Model.ServerCenterCondition;
                        //spTreatment.InnerHtml = BLL.WebSetInfo.Model.ServerCenterTreatment;
                        //if (false)//TModel.MConfig.IsServerCenter)
                        //{
                        //    showmessage.InnerHtml = "您已经是服务中心，无需再次申请！";
                        //    btnOK.Visible = false;
                        //    btnCancle.Visible = false;
                        //}
                        //else if (CheckHasApplyed(TModel.MID, 1, "2") != null)//查看是否申请过
                        //{
                        //    showmessage.InnerHtml = "您已经提出了服务中心申请，请等待管理员审批！";
                        //    btnOK.Visible = false;
                        //}
                        //else
                        //{
                        //    showmessage.InnerHtml = "您当前未申请过服务中心！";
                        //    btnCancle.Visible = false;
                        //}
                        break;
                    case "region":
                        spCondition.InnerHtml = BLL.WebSetInfo.Model.RegionalDirectorCondition;
                        spTreatment.InnerHtml = BLL.WebSetInfo.Model.RegionalDirectorTreatment;
                        hidtype.Value = "1";
                        txtProvince.Value = TModel.Province;
                        //if (TModel.MConfig.IsRegionalDirector)

                        //if (false)
                        //{
                        //    showmessage.InnerHtml = "您已经是区域总监，无需再次申请！";
                        //    btnCancle.Visible = false;
                        //    btnOK.Visible = false;
                        //}
                        //else if (CheckHasApplyed(TModel.MID, 1, "1") != null)//查看是否申请过
                        //{
                        //    showmessage.InnerHtml = "您已经提出了区域总监申请，请等待管理员审批！";
                        //    btnOK.Visible = false;
                        //    Model.MemberApply obj = CheckHasApplyed(TModel.MID, 1, "1");
                        //    txtQQ.Value = obj.MQQ;
                        //    txtQQGroup.Value = obj.MQQGroup;
                        //    txtTel.Value = obj.MTel;
                        //}
                        //else
                        //{
                        //    showmessage.InnerHtml = "您当前未申请过区域总监！";
                        //    btnCancle.Visible = false;
                        //}
                        break;
                }
            }

        }

        protected Model.MemberApply CheckHasApplyed(string mid, int status, string ApplyType)
        {
            return BLL.MemberApply.GetList(string.Format(" MID='{0}' and State={1} and ApplyType='{2}'", TModel.MID, status, ApplyType)).FirstOrDefault();
        }

        /// <summary>
        /// 注册股东
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override string btnAdd_Click()
        {
            Model.MemberApply model = new Model.MemberApply();
            model.MID = TModel.MID;
            model.MQQ = Request.Form["txtQQ"];
            model.ApplyTime = DateTime.Now;
            model.MQQGroup = Request.Form["txtQQGroup"];
            model.State = 1;
            model.MTel = Request.Form["txtTel"];
            model.ApplyType = Request.Form["hidtype"];
            if (model.ApplyType == "1")
            {
                if (int.Parse(TModel.MAgencyType.MAgencyType) < int.Parse("004"))
                {
                    return "您当前的级别不够申请资格，请先升级！";
                }
            }
            else if (model.ApplyType == "2" || model.ApplyType == "3")
            {
                if (int.Parse(TModel.MAgencyType.MAgencyType) < int.Parse("005"))
                {
                    return "您当前的级别不够申请资格，请先升级！";
                }
            }

            if (CheckHasApplyed(TModel.MID, model.State, model.ApplyType) != null)//查看是否申请过
            {
                return "您当前已经申请过，请等待管理员审核！";
            }
            if (BLL.MemberApply.Insert(model))
            {
                //BLL.Task.SendManage(TModel, "001", TModel.MName + "申请了报单中心!");//给管理员发消息
                return "申请成功";
            }
            return "您已申请过了";
        }

        protected override string btnModify_Click()
        {
            return BLL.MemberApply.DeleteApply(CheckHasApplyed(TModel.MID, 1, Request.Form["hidtype"]).Id.ToString());
        }
    }
}