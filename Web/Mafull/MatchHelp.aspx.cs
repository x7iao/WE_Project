using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.Mafull
{
    public partial class MatchHelp : BasePage
    {
        protected override void SetPowerZone()
        {
            int offercount = 0;
            offercount=BLL.MHelpMatch.GetApplyInfo(1).Rows.Count;//找出正常排单个数
            offercount += BLL.MHelpMatch.GetApplyInfo(2).Rows.Count;//找出正常排单个数
            txtOfferCount.Value = offercount.ToString() ;
            txtGetCount.Value = BLL.MHelpMatch.GetApplyInfo(3).Rows.Count.ToString();
        }

        protected override string btnModify_Click()
        {
            if (!BLL.Configuration.Model.AutoDFH)
            {
                return BLL.MHelpMatch.MatchingHelp2();
            }
            else
            {
                return "操作失败，您以开启自动匹配";
            }
        }

        protected override string btnAdd_Click()
        {
            string offer = Request.Form["txtoffer"].Trim();
            string get = Request.Form["txtget"].Trim();
            if (string.IsNullOrEmpty(offer))
            {
                return "买入许愿果会员帐号不能为空";
            }
            else
            {
                if (BllModel.GetModel(offer) == null)
                {
                    return "买入许愿果会员帐号不存在";
                }
            }
            if (string.IsNullOrEmpty(get))
            {
                return "卖出许愿果会员帐号不能为空";
            }
            else
            {
                if (BllModel.GetModel(get) == null)
                {
                    return "卖出许愿果会员帐号不存在";
                }
            }
            return BLL.MHelpMatch.MatchingHelp3(offer, get);
        }
    }
}