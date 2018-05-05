using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.Member
{
    public partial class BCenterAdd : BasePage
    {
        protected override void SetPowerZone()
        {

            txtMID.Value = TModel.MID;
            txtMName.Value = TModel.MName;

            if (TModel.RoleCode.ToUpper() == "VIP")
            {
                showmessage.InnerHtml = "您已经是报单中心，无需再次申请！";
                btnOK.Visible = false;
            }
            else
            {
                if (BLL.BCenter.GetList(string.Format(" MID='{0}' and Flag='0'", TModel.MID)).Count > 0)
                {
                    showmessage.InnerHtml = "您已经提出了报单中心申请，请等待管理员审批！";
                    btnOK.Visible = false;
                }
                else
                {
                    showmessage.InnerHtml = "您当前未申请过报单中心！";
                }
            }
        }


        /// <summary>
        /// 注册股东
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override string btnAdd_Click()
        {
            Model.BCenter model = new Model.BCenter();
            model.MID = TModel.MID;
            model.MName = TModel.MName;
            model.Des = "申请报单中心";
            model.AddDate = DateTime.Now;
            model.Flag = "0";
            if (BLL.BCenter.Insert(model))
            {
                BLL.Task.SendManage(TModel, "001", TModel.MName + "申请了报单中心!");//给管理员发消息
                return "申请成功";
            }
            return "您已申请过了";
        }
    }
}