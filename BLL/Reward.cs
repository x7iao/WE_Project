using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WE_Project.BLL
{
    public class Reward
    {
        public static Dictionary<string, Model.Reward> List
        {
            get
            {
                return DAL.Reward.List;
            }
            set
            {
                DAL.Reward.List = value;
            }
        }

        public static string RewardStr
        {
            get
            {
                return DAL.Reward.RewardStr;
            }
        }
    }
}
