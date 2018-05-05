using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace WE_Project.BLL
{
    public class Configuration
    {
        public static Model.Configuration Model
        {
            get
            {
                return DAL.Configuration.TModel;
            }
            set
            {
                DAL.Configuration.TModel = value;
            }
        }

        public static Dictionary<string, int> CodeTime
        {
            get
            {
                Dictionary<string, int> dic = new Dictionary<string, int>();
                foreach (string str in ConfigurationManager.AppSettings["CodeTime"].Split(';'))
                {
                    if (!string.IsNullOrEmpty(str))
                        dic.Add(str.Split(':')[0], int.Parse(str.Split(':')[1]));
                }
                return dic;
            }
        }
        /// <summary>
        /// 设置【现金币】 转 【循环币】 是否开启
        /// </summary>
        /// <returns></returns>
        public static bool IsTranMoney(bool flag)
        {
            return DAL.Configuration.IsTranMoney(flag);
        }

        public static decimal GetIPClickMoney(Model.Member member)
        {
            decimal money = 0;
            //Model.ConfigDictionary dic = DAL.ConfigDictionary.GetConfigDictionary(member.MConfig.DayTotalIPClick, "TGConfig", member.MAgencyType.MAgencyType);
            //if (dic != null && !string.IsNullOrEmpty(dic.DValue))
            //{
            //    money = decimal.Parse(dic.DValue);
            //}
            return money;
        }
        public static Model.ConfigDictionary GetConfigDictionary(int level, string DTYpe, string DKey)
        {
            return DAL.ConfigDictionary.GetConfigDictionary(level, DTYpe, DKey);
        }
        
    }
}
