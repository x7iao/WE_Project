using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.Member
{
    public partial class AddB : BasePage
    {

        private Model.Member ModelMember
        {
            get
            {
                Model.Member model = new Model.Member
                {
                    MID = BLL.Member.GetTestMID2(DateTime.Now.Millisecond),
                    MSH = BLL.Member.ManageMember.TModel.MID,
                    MTJ = TModel.MID,
                    MCreateDate = DateTime.Now,
                    MDate = DateTime.MaxValue,
                    AgencyCode = "003",
                    Email = TModel.Email,
                    FMID = TModel.MID,
                    MName = TModel.MName,
                    NumID = TModel.NumID,
                    Password = TModel.Password,
                    QQ = TModel.QQ,
                    RoleCode = TModel.RoleCode,
                    Salt = TModel.Salt,
                    SecPsd = TModel.SecPsd,
                    SHMoney = 1000,
                    Tel = TModel.Tel,
                    MBDIndex = 1,
                    MBD = TModel.MTJ,
                    Country = TModel.Country
                };
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
            Model.Member model = ModelMember;
            if (BLL.Member.Insert(model))
                return BLL.ChangeMoney.SHMember(TModel, model.MID);
            return "生成失败";
        }
    }
}