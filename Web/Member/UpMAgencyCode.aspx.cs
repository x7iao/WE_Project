using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.Member
{
    public partial class UpMAgencyCode : BasePage
    {

        protected override string btnAdd_Click()
        {
            //查询是否申请过了
            Model.MemberApply app = BLL.MemberApply.CheckHasApplyed(TModel.MID, 0, Request.Form["rdoupmagecy"]);
            if (app != null)
            {
                return "您已经申请过了，请等待管理员审核。";
            }

            Model.SHMoney shmoney = BLL.Configuration.Model.SHMoneyList[Request.Form["rdoupmagecy"]];
            //查看直推人数
            if (TModel.MConfig.TJCount < shmoney.TJCount || TModel.MConfig.YJCount < shmoney.TemaCount)
            {
                return "申请失败，要申请到" + shmoney.MAgencyName + ",必须达到推荐人数" + shmoney.TJCount + "，团队人数" + shmoney.TemaCount;
            }
            else
            {
                //查询推荐人数中有多少经理，高级经理，
                string sql = "select count(1) from Member WHERE MTJ='" + TModel.MID + "' AND AgencyCode='" + shmoney.TJAgency + "'";
                object objCount = BLL.CommonBase.GetSingle(sql);
                if (Convert.ToInt16(objCount) < shmoney.TJCount || TModel.MConfig.YJCount < shmoney.TemaCount)
                {
                    return "申请失败，您的推荐人数不足或团队人数不足";
                }
                else
                {
                    Model.MemberApply apply = new Model.MemberApply();
                    apply.ApplyTime = DateTime.Now;
                    apply.ApplyType = shmoney.MAgencyType;
                    apply.MID = TModel.MID;
                    apply.MTel = TModel.Tel;
                    apply.State = 0;
                    if (BLL.MemberApply.Insert(apply))
                    {
                        return "申请成功，请等待管理员审核。";
                    }
                }
            }
            return "申请失败";
        }
    }
}