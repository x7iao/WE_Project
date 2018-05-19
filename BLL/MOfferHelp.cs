using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace WE_Project.BLL
{
    public class MOfferHelp
    {
        public static Model.MOfferHelp GetModel(object obj)
        {
            return WE_Project.DAL.MOfferHelp.GetModel(obj);
        }

        public static Hashtable Insert(Model.MOfferHelp model, Hashtable MyHs)
        {
            return WE_Project.DAL.MOfferHelp.Insert(model, MyHs);
        }

        public static bool Insert(Model.MOfferHelp model)
        {
            return WE_Project.DAL.MOfferHelp.Insert(model);
        }

        public static Hashtable Update(Model.MOfferHelp model, Hashtable MyHs)
        {
            return WE_Project.DAL.MOfferHelp.Update(model, MyHs);
        }

        public static bool Update(Model.MOfferHelp model)
        {
            return WE_Project.DAL.MOfferHelp.Update(model);
        }

        public static Hashtable Delete(object obj, Hashtable MyHs)
        {
            return WE_Project.DAL.MOfferHelp.Delete(obj, MyHs);
        }

        public static string Delete(object obj)
        {
            if (WE_Project.DAL.MOfferHelp.Delete(obj))
            {
                return "删除成功";
            }
            else
            {
                return "删除失败";
            }
        }
        /// <summary>
        /// 超时转换利息
        /// </summary>
        /// <returns></returns>
        public static bool outTimeDHLiXi()
        {
            List<Model.MOfferHelp> olist = BLL.MOfferHelp.GetList(" PPState=3 and DATEADD(MI," + BLL.MMMConfig.Model.OutTimes + ",CompleteTime)<GETDATE()  ");
            foreach (var offer in olist)
            {
                Hashtable MyHs = new Hashtable();

                //查看是否已转入马夫罗
                if (offer.PPState == 4)
                {
                    continue;
                }
                //if (offer.SQMID == TModel.MID)
                {
                    //更新该买入许愿果的匹配记录
                    decimal changeMoney = offer.SQMoney;
                    //if (offer.InterestState == 1)
                    {
                        changeMoney += offer.TotalInterest;
                        BLL.ChangeMoney.HBChangeTran(changeMoney, BLL.Member.ManageMember.TModel.MID, offer.SQMID, "TGBZ", BLL.Member.ManageMember.TModel, "MHB", "买入许愿果(" + offer.SQCode + ")本金加利息超时自动进入" + BLL.Reward.List["MJB"].RewardName, MyHs);
                    }

                    offer.PPState = 4;
                    offer.InterestState = 2;
                    offer.SincerityState = 2;
                    BLL.MOfferHelp.Update(offer, MyHs);
                    BLL.CommonBase.RunHashtable(MyHs);
                }
            }
            return true;
        }

        public static DataTable GetTable(string strWhere)
        {
            return WE_Project.DAL.MOfferHelp.GetTable(strWhere);
        }

        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.MOfferHelp.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public static List<Model.MOfferHelp> GetList(string strWhere)
        {
            return WE_Project.DAL.MOfferHelp.GetList(strWhere);
        }

        /// <summary>
        /// 连表查询时使用
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static List<Model.MOfferHelp> GetListJoin(string strWhere)
        {
            return WE_Project.DAL.MOfferHelp.GetListJoin(strWhere);
        }

        public static List<Model.MOfferHelp> GetList(int top, string strWhere)
        {
            return WE_Project.DAL.MOfferHelp.GetList(top, strWhere);
        }

        public static List<Model.MOfferHelp> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.MOfferHelp.GetList(strWhere, pageIndex, pageSize, out count);
        }

        public static string GetSumCount(string type)
        {
            string sql = "select COUNT(1),ISNULL(SUM(SQMoney),0) from MOfferHelp ";
            switch (type)
            {
                case "": sql = "select COUNT(1),ISNULL(SUM(SQMoney),0) from MOfferHelp "; break;
                case "1": sql = "select COUNT(1),ISNULL(SUM(SQMoney),0) from MOfferHelp  where PPState in (0,2)"; break;
                case "2": sql = "select COUNT(1),ISNULL(SUM(SQMoney),0) from MOfferHelp where PPState=1"; break;
                case "3": sql = "select COUNT(1),ISNULL(SUM(SQMoney),0) from MOfferHelp  where PPState=1"; break;
                case "4": sql = "select COUNT(1),ISNULL(SUM(SQMoney),0) from MOfferHelp  where  SQMID in (select MID from Member where IsClose<>'1') and PPState in (0,2) and DATEDIFF(mi,SQDate,getdate())> " + BLL.MMMConfig.Model.LineTimes; break;
            }
            DataTable list = BLL.CommonBase.GetTable(sql);
            return list.Rows[0][0] + "*" + list.Rows[0][1];
        }

        public static decimal GetSumMoney(string strWhere)
        {
            return DAL.MOfferHelp.GetSumMoney(strWhere);
        }

        public static int GetSumCountByStr(string strWhere)
        {
            return DAL.MOfferHelp.GetSumCount(strWhere);
        }

        public static decimal GetAllSumMoney(string strWhere)
        {
            return DAL.MOfferHelp.GetAllSumMoney(strWhere);
        }

        public static int GetOfferCount(string mid)
        {
            var list = GetList(" SQMID = '" + mid + "' and PPState in (3,4) ");
            if (list != null && list.Any())
            {
                return list.Count;
            }
            return 0;
        }

        /// <summary>
        /// 获取该单的上一单
        /// </summary>
        /// <param name="offer"></param>
        /// <returns></returns>
        public static Model.MOfferHelp GetLastMoffer(Model.MOfferHelp offer)
        {
            var list = GetList(" [ID] < " + offer.Id + " and SQMID = '" + offer.SQMID + "' and PPState <> 5 order by [ID] desc ");

            return list.FirstOrDefault();
        }

        /// <summary>
        /// 获取最新的一单
        /// </summary>
        public static Model.MOfferHelp GetLastMofferHelp(string mid, int helptype)
        {
            var list = GetList(" SQMID = '" + mid + "' and PPState <> 5 and helptype=" + helptype + " order by [ID] desc ");

            return list.FirstOrDefault();
        }
        /// <summary>
        /// 获取最新的一单
        /// </summary>
        public static Model.MOfferHelp GetLastMoffer(string mid)
        {
            var list = GetList(" SQMID = '" + mid + "' and PPState <> 5 order by [ID] desc ");

            return list.FirstOrDefault();
        }


        public static decimal GetMaxOfferMoney(string mid)
        {
            return WE_Project.DAL.MOfferHelp.GetMaxOfferMoney(mid);
        }

        public static Model.MOfferHelp GetQDOfferMoney(string mid)
        {
            return DAL.MOfferHelp.GetQDOfferMoney(mid);
        }

        public static Model.MOfferHelp GetLastQDOfferMoney(string mid)
        {
            return DAL.MOfferHelp.GetLastQDOfferMoney(mid);
        }

        public static Model.MOfferHelp GetScrambleQDOfferMoney(string mid)
        {
            return DAL.MOfferHelp.GetScrambleQDOfferMoney(mid);
        }

        /// <summary>
        /// 买入许愿果
        /// </summary>
        public static string GetHelp(Model.Member member, decimal sqMoney, int helptype, Hashtable MyHs)
        {
            if (!member.MState)
            {
                return "1*您的账号未激活，请先激活账号！";
            }

            if (member.Role.IsAdmin)
            {
                return "1*不可申请";
            }

            //买入许愿果开关
            if (!BLL.MMMConfig.Model.OfferHelpSwitch || !SystemTimeRange.TimeIsClose(BLL.MMMConfig.Model.OfferHelpTimes, DateTime.Now))
            {
                return "1*当前时间不能申请";
            }

            Model.MOfferHelp off = BLL.MOfferHelp.GetLastQDOfferMoney(member.MID);
            if (off != null)
            {
                return "1*您有未完成的订单";
            }


            //if (BLL.MOfferHelp.GetSumCountByStr(string.Format(" SQDate >= '{0}' and SQMID = '" + member.MID + "' and PPState <> 5 and HelpType = 0 ", DateTime.Now.AddMinutes(-(int)BLL.MMMConfig.Model.OfferHelpRangeTimes))) > BLL.MMMConfig.Model.OfferHelpRangeCount)
            //{
            //    return "1*您已申请过," + BLL.MMMConfig.Model.OfferHelpRangeTimes + "分钟内只能申请" + BLL.MMMConfig.Model.OfferHelpRangeCount + "次";
            //}
            //decimal maxOfferMoney = BLL.MMMConfig.Model.OfferHelpMax;
            //decimal minOfferMoney = BLL.MMMConfig.Model.OfferHelpMin;
            //var dic = DAL.ConfigDictionary.GetConfigDictionary(member.MConfig.TJCount, "OfferTop", "");
            //if (dic != null)
            //{
            //    maxOfferMoney = Convert.ToDecimal(dic.DValue);
            //}

            //得到最高能排单金额
            //var dictj = DAL.ConfigDictionary.GetConfigDictionary(member.MConfig.TJCount, "OfferTopTJ", "");
            //var dicyj = DAL.ConfigDictionary.GetConfigDictionary(member.MConfig.TJCount, "OfferTopYJ", "");
            //decimal dicmoney = Convert.ToDecimal(dictj.DValue) >Convert.ToDecimal(dicyj.DValue) ? Convert.ToDecimal(dicyj.DValue) :Convert.ToDecimal(dictj.DValue);//取小

            //if (sqMoney != 2000 && sqMoney != 5000 && sqMoney != 10000 && sqMoney != 20000)
            //    return "1*买入许愿果金额应为2000,5000,10000或20000";

            decimal maxOfferMoney = WE_Project.BLL.MMMConfig.Model.OfferHelpMax;


            decimal minOfferMoney = WE_Project.BLL.MMMConfig.Model.OfferHelpMin;
            if (helptype == 1)
            {
                //日抢单额度
                decimal dayqdmoney = Convert.ToDecimal(BLL.CommonBase.GetSingle("select ISNULL(SUM(sqmoney),0) from MOfferHelp where DATEDIFF(DAY,SQDate,GETDATE())=0 and HelpType=1;"));
                if (dayqdmoney + sqMoney > BLL.MMMConfig.Model.GetTJKF)
                {
                    return "1*超出日抢单额度，还能抢单" + (BLL.MMMConfig.Model.GetTJKF - dayqdmoney);
                }


                minOfferMoney = 1;
                if (member.MCreateDate.AddMinutes(BLL.MMMConfig.Model.MHBBase) > DateTime.Now)
                {
                    return "1*新注册会员不能参与抢单";
                }

                int sqcount = Convert.ToInt32(BLL.CommonBase.GetSingle(" select count(*) from MOfferHelp where HelpType=1 and SQMID='" + member.MID + "' and DATEDIFF(MONTH,SQDate,GETDATE())=0; "));
                if (sqcount > 0)
                {
                    return "1*每月只能抢一单";
                }
            }
            else
            {
                Model.MOfferHelp lastmo = BLL.MOfferHelp.GetLastMofferHelp(member.MID, 0);
                if (lastmo != null)
                {
                    if (lastmo.SQDate.AddMinutes(BLL.MMMConfig.Model.GLRewardFreezeTimes) > DateTime.Now)
                    {
                        return "1*正常排单两单间隔时间为" + BLL.MMMConfig.Model.GLRewardFreezeTimes + "分钟，请等待";
                    }
                }
            }
            if (sqMoney % BLL.MMMConfig.Model.OfferHelpBase != 0)
            {
                return "1*买入许愿果金额应为" + BLL.MMMConfig.Model.OfferHelpBase + "的倍数";
            }
            else
            {
                //最大金额，最小金额
                if (sqMoney >= minOfferMoney && sqMoney <= maxOfferMoney)
                {
                    decimal dayoff = BLL.MOfferHelp.GetSumMoney(" DATEDIFF(DAY,SQDate,GETDATE())=0 and PPState!=5; ");
                    if ((dayoff + sqMoney) >= BLL.MMMConfig.Model.MOfferNeedMCW)
                    {
                        return "1*超出每天排单排单金额限制，还能排单" + (BLL.MMMConfig.Model.MOfferNeedMCW - dayoff);
                    }


                    //获取上一单金额
                    Model.MOfferHelp lastoffer = BLL.MOfferHelp.GetLastMoffer(member.MID);
                    //有并且金额大于一定比例
                    if (lastoffer == null || sqMoney >= lastoffer.SQMoney)
                    {
                        //获取所需排单币
                        decimal mcwdic = sqMoney * BLL.MMMConfig.Model.OfferTJKF * 2000;

                        if (BLL.ChangeMoney.EnoughChange(member.MID, mcwdic, "MGP"))
                        {
                            Model.MOfferHelp offer = new Model.MOfferHelp();
                            offer.DKState = 0;
                            offer.PPState = 0;
                            offer.SQDate = DateTime.Now;
                            offer.SQMID = member.MID;
                            offer.SQMoney = sqMoney;
                            //offer.DayInterest = 0;
                            if (member.MConfig.EPXingCount <= 0)
                            {
                                offer.DayInterest = BLL.MMMConfig.Model.MCWPrice;
                            }
                            else {
                                offer.DayInterest = BLL.MMMConfig.Model.InterestPer;//订单利息(插入数据库前获取)
                            }
                            offer.TotalInterest = 0;
                            offer.TotalInterestDays = 0;
                            offer.TotalSincerity = 0;
                            offer.TotalSincerityDays = 0;
                            offer.SincerityState = 0;
                            offer.TotalSincerity = 0;
                            offer.InterestState = 1;
                            offer.MatchMoney = 0;
                            offer.MFLMoney = offer.SQMoney * BLL.MMMConfig.Model.NoLineTimesMoneyFloat;
                            //offer.MFLMoney = 0;
                            offer.HelpType = helptype;
                            //Hashtable MyHs = new Hashtable();
                            BLL.MOfferHelp.Insert(offer, MyHs);
                            BLL.Member.UpdateConfigTran(member.MID, "SQCount", "1", member, false, System.Data.SqlDbType.Int, MyHs);

                            BLL.ChangeMoney.HBChangeTran(mcwdic, member.MID, BLL.Member.ManageMember.TModel.MID, "TGBH", member, "MGP", "买入许愿果需" + mcwdic + BLL.Reward.List["MGP"].RewardName, MyHs);

                            //BLL.ChangeMoney.R_GL(offer, TModel, TModel, 1, MyHs);
                            return "1*0";
                        }
                        else
                        {
                            return "1*您的" + BLL.Reward.List["MGP"].RewardName + "不足";
                        }
                    }
                    else
                    {
                        return "1*提交申请失败：申请金额应该不小于上一单(" + lastoffer.SQMoney + ")的" + BLL.MMMConfig.Model.LastProportion.ToPercent() + "(" + lastoffer.SQMoney * BLL.MMMConfig.Model.LastProportion + ")";
                    }
                }
                else
                {
                    return "1*提交申请失败：申请金额应该为：" + minOfferMoney + "-" + maxOfferMoney;
                }
            }
        }

        /// <summary>
        /// 买入许愿果
        /// </summary>
        public static string GetHelp(Model.Member member, decimal sqMoney, int helptype)
        {
            Hashtable MyHs = new Hashtable();
            string result = GetHelp(member, sqMoney, helptype, MyHs);
            if (result == "1*0")
            {
                if (BLL.CommonBase.RunHashtable(MyHs))
                {
                    return "1*0";
                }
                else
                {
                    return "1*提交申请失败";
                }
            }
            else
            {
                return result;
            }
        }

    }
}
