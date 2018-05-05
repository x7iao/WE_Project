using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.SysManage
{
    public partial class MMMConfigScrambleEdit : BasePage
    {
        protected override void SetPowerZone()
        {
            MMMScrambleModel = BLL.MMMConfigScramble.Model;
        }

        public Model.MMMConfigScramble MMMScrambleModel
        {
            get
            {
                Model.MMMConfigScramble model = BLL.MMMConfigScramble.Model;

                model.OpenSwitch = Request.Form["txtOpenSwitch"] == "1";
                model.OpenTime = Request.Form["txtOpenTime"];
                model.PayLimitTimes = int.Parse(Request.Form["txtPayLimitTimes"]);
                model.ConfirmLimitTimes = int.Parse(Request.Form["txtConfirmLimitTimes"]);
                model.FreezeTimes = int.Parse(Request.Form["txtFreezeTimes"]);
                model.ScrambleReward = decimal.Parse(Request.Form["txtScrambleReward"]);
                model.ScrambleLiXiDays = int.Parse(Request.Form["txtScrambleLiXiDays"]);
                model.DisappearTimes = int.Parse(Request.Form["txtDisappearTimes"]);

                return model;
            }
            set
            {
                if (value != null)
                {
                    txtOpenSwitch.Value = value.OpenSwitch ? "1" : "0";
                    txtOpenTime.Value = value.OpenTime;
                    txtPayLimitTimes.Value = value.PayLimitTimes.ToString();
                    txtConfirmLimitTimes.Value = value.ConfirmLimitTimes.ToString();
                    txtFreezeTimes.Value = value.FreezeTimes.ToString();
                    txtScrambleReward.Value = value.ScrambleReward.ToString();
                    txtScrambleLiXiDays.Value = value.ScrambleLiXiDays.ToString();
                    txtDisappearTimes.Value = value.DisappearTimes.ToString();
                }
            }
        }

        protected override string btnModify_Click()
        {
            if (BLL.MMMConfigScramble.Update(MMMScrambleModel))
            {
                return "操作成功";
            }
            else
                return "操作失败";
        }
    }
}