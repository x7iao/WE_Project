using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.SecurityCenter
{
    public partial class ModifyQuestion : BasePage
    {
        protected override void SetPowerZone()
        {
            BindDdlPwdQuestion();
        }
        protected void BindDdlPwdQuestion()
        {
            BLL.Sys_SecurityQuestion bll = new BLL.Sys_SecurityQuestion();
            string whereStr = " IsDeleted=0 and Status=1";
            IList<Model.Sys_SecurityQuestion> list = bll.GetList(whereStr);
            ddl_PwdQuestion.DataSource = list;
            ddl_PwdQuestion.DataTextField = "Question";
            ddl_PwdQuestion.DataValueField = "ID";
            ddl_PwdQuestion.DataBind();

            ddl_NewQuestion.DataSource = list;
            ddl_NewQuestion.DataTextField = "Question";
            ddl_NewQuestion.DataValueField = "ID";
            ddl_NewQuestion.DataBind();
        }

        protected override string btnModify_Click()
        {

            Model.Member model = TModel;
            bool flag = true;
            //找到该会员的密保问题及答案
            Model.Sys_SQ_Answer obj = null;
            BLL.Sys_SQ_Answer bll = new BLL.Sys_SQ_Answer();
            string whereStr = " IsDeleted=0 and Status=1 and MID=" + model.ID;
            IList<Model.Sys_SQ_Answer> list = bll.GetList(whereStr);
            if (list != null && list.Count > 0)
            {
                obj = list[0];
                if (obj.QId != long.Parse(Request.Form["ddl_PwdQuestion"]))
                {
                    flag = false;
                }
                if (obj.Answer != Request.Form["pwdAnswer"])
                {
                    flag = false;
                }
            }
            if (flag)
            {
                obj = list[0];
                obj.Answer = Request.Form["lbConfirm"];
                obj.LastUpdateBy = model.MID;
                obj.LastUpdateTime = DateTime.Now;
                obj.QId = long.Parse(Request.Form["ddl_NewQuestion"]);
                if (bll.Update(obj))
                    return "操作成功";
                else
                    return "操作失败";
            }
            else
                return "密保问题错误";
        }
    }
}