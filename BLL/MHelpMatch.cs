using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace WE_Project.BLL
{
    public class MHelpMatch
    {
        # region 通用业务

        public static Model.MHelpMatch GetModel(object obj)
        {
            return WE_Project.DAL.MHelpMatch.GetModel(obj);
        }

        public static Model.MHelpMatch GetModelByCode(object obj)
        {
            return WE_Project.DAL.MHelpMatch.GetModelByCode(obj);
        }

        public static Hashtable Insert(Model.MHelpMatch model, Hashtable MyHs)
        {
            return WE_Project.DAL.MHelpMatch.Insert(model, MyHs);
        }

        public static bool Insert(Model.MHelpMatch model)
        {
            return WE_Project.DAL.MHelpMatch.Insert(model);
        }

        public static Hashtable Update(Model.MHelpMatch model, Hashtable MyHs)
        {
            return WE_Project.DAL.MHelpMatch.Update(model, MyHs);
        }

        public static bool Update(Model.MHelpMatch model)
        {
            return WE_Project.DAL.MHelpMatch.Update(model);
        }

        public static Hashtable Delete(object obj, Hashtable MyHs)
        {
            return WE_Project.DAL.MHelpMatch.Delete(obj, MyHs);
        }

        public static bool Delete(object obj)
        {
            return WE_Project.DAL.MHelpMatch.Delete(obj);
        }

        public static DataTable GetTable(string strWhere)
        {
            return WE_Project.DAL.MHelpMatch.GetTable(strWhere);
        }

        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.MHelpMatch.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public static List<Model.MHelpMatch> GetList(string strWhere)
        {
            return WE_Project.DAL.MHelpMatch.GetList(strWhere);
        }

        public static List<Model.MHelpMatch> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.MHelpMatch.GetList(strWhere, pageIndex, pageSize, out count);
        }

        public static DataTable GetApplyInfo(int type)
        {
            if (type == 1)
            {
                DateTime now = DateTime.Now.AddMinutes(-BLL.MMMConfig.Model.LineTimes);
                //提供帮助 //查询出排队过15天的
                DataTable list = BLL.CommonBase.GetTable(@"select (t1.SQMoney-t1.MatchMoney) as SQMoney,t1.SQMoney as OrginSQMoney,PPState,SQMID,SQDate,SQCode,t1.Id from MOfferHelp t1 left join Member a on t1.SQMID=a.MID
 inner join MemberConfig b on a.MID=b.MID  where  MState='1' and IsClose<>'1' and PPState in (0,1,2) and SQDate <= '" + now.ToString("yyyy-MM-dd HH:mm:ss") + "' and (MatchMoney <> SQMoney or MatchMoney < MFLMoney) and HelpType = 0 ");
                return list;
            }
            else if (type == 2)
            {
                DateTime now = DateTime.Now.AddMinutes(-BLL.MMMConfig.Model.MHBRangeTimes);
                //提供帮助 //查询出排队过15天的
                DataTable list = BLL.CommonBase.GetTable(@"select (t1.SQMoney-t1.MatchMoney) as SQMoney,t1.SQMoney as OrginSQMoney,PPState,SQMID,SQDate,SQCode,t1.Id from MOfferHelp t1 left join Member a on t1.SQMID=a.MID
 inner join MemberConfig b on a.MID=b.MID  where  MState='1' and IsClose<>'1' and PPState in (0,1,2) and SQDate <= '" + now.ToString("yyyy-MM-dd HH:mm:ss") + "' and (MatchMoney <> SQMoney or MatchMoney < MFLMoney) and HelpType = 1 ");
                return list;
            }
            else
            {
                //获得帮助
                DataTable list = BLL.CommonBase.GetTable(@"select t1.SQMoney,SQMID,SQDate,SQCode,t1.Id,b.PPLeavel from MGetHelp t1 left join Member a on t1.SQMID=a.MID
 inner join MemberConfig b on a.MID=b.MID  where  MState='1' and IsClose<>'1' and PPState in (0,1,2) and  t1.SQMoney <>  t1.MatchMoney order by SQDate desc");
                return list;
            }
        }

        # endregion 通用业务

        # region 全部匹配

        /// <summary>
        /// 订单对订单匹配
        /// </summary>
        public static string Matching4(string offid, string getid)
        {
            lock (thisLock)
            {
                guilist.Clear();
                DateTime now = DateTime.Now.AddMinutes(-BLL.MMMConfig.Model.LineTimes);
                DateTime getnow = DateTime.Now.AddMinutes(-BLL.MMMConfig.Model.FreezeTimesOfOffer);
                //提供帮助的记录
                List<Model.MOfferHelp> offerlist = new List<Model.MOfferHelp>();
                offerlist = BLL.MOfferHelp.GetList(" PPState in (0,1,2) and HelpType = 0 and  SQMoney <> MatchMoney and SQDate <= '" + now.ToString("yyyy-MM-dd HH:mm:ss") + "' and [Id] in (" + offid + ") order by SQDate");
                //管理员记录
                List<Model.MGetHelp> getadminlist = new List<Model.MGetHelp>();
                //////交易中的不能匹配
                //getadminlist = BLL.MGetHelp.GetListJoinMember("t1.PPState in (0,2) and SQMID in (select MID from Member where MState='1' and IsClose<>'1' ) and t2.PPLeavel is not NULL and PPLeavel>0  order by t1.SQDate asc");
                List<Model.MGetHelp> getuserlist2 = new List<Model.MGetHelp>();
                getuserlist2 = BLL.MGetHelp.GetListJoinMember(" t1.PPState in (0,1,2)  and SQDate <= '" + getnow.ToString("yyyy-MM-dd HH:mm:ss") + "' and t1.SQMoney <> t1.MatchMoney and [id] in (" + getid + ") and (t2.PPLeavel is NULL or PPLeavel=0) order by t1.SQDate asc");

                return MatchProcess(offerlist, getuserlist2, getadminlist);
            }
        }

        /// <summary>
        /// 会员对会员匹配
        /// </summary>
        public static string Matching3(string offmid, string getmid)
        {
            lock (thisLock)
            {
                guilist.Clear();
                DateTime now = DateTime.Now.AddMinutes(-BLL.MMMConfig.Model.LineTimes);
                DateTime getnow = DateTime.Now.AddMinutes(-BLL.MMMConfig.Model.FreezeTimesOfOffer);
                //提供帮助的记录
                List<Model.MOfferHelp> offerlist = new List<Model.MOfferHelp>();
                offerlist = BLL.MOfferHelp.GetList("PPState in (0,1,2) and HelpType = 0 and SQDate <= '" + now.ToString("yyyy-MM-dd HH:mm:ss") + "' and SQMID in (select MID from Member where MState='1' and IsClose<>'1' and mid = '" + offmid + "' )  order by SQDate");
                //管理员记录
                List<Model.MGetHelp> getadminlist = new List<Model.MGetHelp>();
                //getadminlist = BLL.MGetHelp.GetListJoinMember("t1.PPState in (0,2) and SQMID in (select MID from Member where MState='1' and IsClose<>'1' ) and t2.PPLeavel is not NULL and PPLeavel>0  order by t1.SQDate asc");
                //会员记录
                List<Model.MGetHelp> getuserlist2 = new List<Model.MGetHelp>();
                getuserlist2 = BLL.MGetHelp.GetListJoinMember("t1.PPState in (0,1,2)  and SQDate <= '" + getnow.ToString("yyyy-MM-dd HH:mm:ss") + "' and SQMID in (select MID from Member where MState='1' and IsClose<>'1' and mid = '" + getmid + "' ) and (t2.PPLeavel is NULL or PPLeavel=0) order by t1.SQDate asc");

                return MatchProcess(offerlist, getuserlist2, getadminlist);
            }
        }

        /// <summary>
        /// 全部匹配
        /// </summary>
        public static string Matching2()
        {
            lock (thisLock)
            {
                guilist.Clear();
                DateTime now = DateTime.Now.AddMinutes(-BLL.MMMConfig.Model.LineTimes);
                DateTime getnow = DateTime.Now.AddMinutes(-BLL.MMMConfig.Model.FreezeTimesOfOffer);
                //提供帮助的记录
                List<Model.MOfferHelp> offerlist = new List<Model.MOfferHelp>();
                offerlist = BLL.MOfferHelp.GetListJoin("PPState in (0,1,2) and HelpType = 0 and SQDate <= '" + now.ToString("yyyy-MM-dd HH:mm:ss") + "' and SQMID in (select MID from Member where MState='1' and IsClose<>'1' ) order by SQDate,mc.EPXingCount desc");
                //管理员记录
                List<Model.MGetHelp> getadminlist = new List<Model.MGetHelp>();
                getadminlist = BLL.MGetHelp.GetListJoinMember("t1.PPState in (0,1,2)  and SQDate <= '" + getnow.ToString("yyyy-MM-dd HH:mm:ss") + "' and SQMID in (select MID from Member where MState='1' and IsClose<>'1' ) and t2.PPLeavel is not NULL and PPLeavel > 0  order by t1.SQDate asc,t2.EPXingCount desc");
                //会员记录
                List<Model.MGetHelp> getuserlist2 = new List<Model.MGetHelp>();
                getuserlist2 = BLL.MGetHelp.GetListJoinMember("t1.PPState in (0,1,2)  and SQDate <= '" + getnow.ToString("yyyy-MM-dd HH:mm:ss") + "' and SQMID in (select MID from Member where MState='1' and IsClose<>'1' ) and (t2.PPLeavel is NULL or PPLeavel = 0) order by t1.SQDate asc,t2.EPXingCount desc");

                return MatchProcess(offerlist, getuserlist2, getadminlist);
            }
        }

        # endregion 全部匹配

        # region 部分匹配

        /// <summary>
        /// 全部会员匹配部分
        /// </summary>
        public static string MatchingHelpPrev2()
        {
            lock (thisLock)
            {
                guilist.Clear();
                DateTime now = DateTime.Now.AddMinutes(-BLL.MMMConfig.Model.LineTimes);

                DateTime getnow = DateTime.Now.AddMinutes(-BLL.MMMConfig.Model.FreezeTimesOfOffer);

                //提供帮助的记录
                List<Model.MOfferHelp> offerlist = new List<Model.MOfferHelp>();
                //offerlist = BLL.MOfferHelp.GetList("PPState in (0,1,2)  and HelpType = 0  and MatchMoney < MFLMoney and SQMID in (select MID from Member where MState='1' and IsClose<>'1' ) order by SQDate");
                offerlist = BLL.MOfferHelp.GetListJoin("PPState in (0, 1, 2)  and HelpType = 0  and MatchMoney < MFLMoney and SQMID in (select MID from Member where MState = '1' and IsClose<> '1' ) order by SQDate,mc.EPXingCount desc");
                //管理员记录
                List<Model.MGetHelp> getadminlist = new List<Model.MGetHelp>();
                //getadminlist = BLL.MGetHelp.GetListJoinMember("t1.PPState in (0,1,2) and SQMID in (select MID from Member where MState='1' and IsClose<>'1' ) and t2.PPLeavel is not NULL and PPLeavel > 0  order by t1.SQDate asc");
                //会员记录
                List<Model.MGetHelp> getuserlist2 = new List<Model.MGetHelp>();
                getuserlist2 = BLL.MGetHelp.GetListJoinMember("t1.PPState in (0,1,2) and SQDate <= '" + getnow.ToString("yyyy-MM-dd HH:mm:ss") + "' and SQMID in (select MID from Member where MState='1' and IsClose<>'1' ) and (t2.PPLeavel is NULL or PPLeavel = 0) order by t1.SQDate asc,t2.EPXingCount desc");

                return MatchProcess2(offerlist, getuserlist2, getadminlist);
            }
        }

        /// <summary>
        /// 会员对会员匹配部分
        /// </summary>
        public static string MatchingHelpPrev3(string offmid, string getmid)
        {
            lock (thisLock)
            {
                guilist.Clear();
                DateTime now = DateTime.Now.AddMinutes(-BLL.MMMConfig.Model.LineTimes);
                DateTime getnow = DateTime.Now.AddMinutes(-BLL.MMMConfig.Model.FreezeTimesOfOffer);
                //提供帮助的记录
                List<Model.MOfferHelp> offerlist = new List<Model.MOfferHelp>();
                offerlist = BLL.MOfferHelp.GetList("PPState in (0,1,2) and HelpType = 0 and SQDate > '" + now.ToString("yyyy-MM-dd HH:mm:ss") + "' and MatchMoney < MFLMoney and SQMID in (select MID from Member where MState='1' and IsClose<>'1' and mid = '" + offmid + "' ) order by SQDate");
                //管理员记录
                List<Model.MGetHelp> getadminlist = new List<Model.MGetHelp>();
                //getadminlist = BLL.MGetHelp.GetListJoinMember("t1.PPState in (0,1,2) and SQMID in (select MID from Member where MState='1' and IsClose<>'1' ) and t2.PPLeavel is not NULL and PPLeavel > 0  order by t1.SQDate asc");
                //会员记录
                List<Model.MGetHelp> getuserlist2 = new List<Model.MGetHelp>();
                getuserlist2 = BLL.MGetHelp.GetListJoinMember("t1.PPState in (0,1,2) and SQDate <= '" + getnow.ToString("yyyy-MM-dd HH:mm:ss") + "' and SQMID in (select MID from Member where MState='1' and IsClose<>'1' and mid = '" + getmid + "'  ) and (t2.PPLeavel is NULL or PPLeavel = 0) order by t1.SQDate asc");

                return MatchProcess2(offerlist, getuserlist2, getadminlist);
            }
        }

        /// <summary>
        /// 会员对会员匹配部分
        /// </summary>
        public static string MatchingHelpPrev4(string offid, string getid)
        {
            lock (thisLock)
            {
                guilist.Clear();
                DateTime now = DateTime.Now.AddMinutes(-BLL.MMMConfig.Model.LineTimes);
                DateTime getnow = DateTime.Now.AddMinutes(-BLL.MMMConfig.Model.FreezeTimesOfOffer);
                //提供帮助的记录
                List<Model.MOfferHelp> offerlist = new List<Model.MOfferHelp>();
                offerlist = BLL.MOfferHelp.GetList("PPState in (0,1,2) and SQDate > '" + now.ToString("yyyy-MM-dd HH:mm:ss") + "' and MatchMoney < MFLMoney and [Id] in (" + offid + ") and SQMID in (select MID from Member where MState='1' and IsClose<>'1' ) order by SQDate");
                //管理员记录
                List<Model.MGetHelp> getadminlist = new List<Model.MGetHelp>();
                //getadminlist = BLL.MGetHelp.GetListJoinMember("t1.PPState in (0,1,2) and SQMID in (select MID from Member where MState='1' and IsClose<>'1' ) and t2.PPLeavel is not NULL and PPLeavel > 0  order by t1.SQDate asc");
                //会员记录
                List<Model.MGetHelp> getuserlist2 = new List<Model.MGetHelp>();
                getuserlist2 = BLL.MGetHelp.GetListJoinMember("t1.PPState in (0,1,2) and SQDate <= '" + getnow.ToString("yyyy-MM-dd HH:mm:ss") + "' and [Id] in (" + getid + ") and SQMID in (select MID from Member where MState='1' and IsClose<>'1' ) and (t2.PPLeavel is NULL or PPLeavel = 0) order by t1.SQDate asc");

                return MatchProcess2(offerlist, getuserlist2, getadminlist);
            }
        }

        # endregion 部分匹配

        # region 抢单匹配

        /// <summary>
        /// 订单对订单匹配
        /// </summary>
        public static string MatchingScramble4(string offid, string getid)
        {
            lock (thisLock)
            {
                guilist.Clear();
                DateTime now = DateTime.Now.AddMinutes(-BLL.MMMConfig.Model.LineTimes);

                //提供帮助的记录
                List<Model.MOfferHelp> offerlist = new List<Model.MOfferHelp>();
                offerlist = BLL.MOfferHelp.GetList(" PPState in (0,1,2) and  SQMoney <> MatchMoney and HelpType = 1 and [Id] in (" + offid + ") order by SQDate");
                //管理员记录
                List<Model.MGetHelp> getadminlist = new List<Model.MGetHelp>();
                //getadminlist = BLL.MGetHelp.GetListJoinMember("t1.PPState in (0,2) and SQMID in (select MID from Member where MState='1' and IsClose<>'1' ) and t2.PPLeavel is not NULL and PPLeavel>0  order by t1.SQDate asc");
                List<Model.MGetHelp> getuserlist2 = new List<Model.MGetHelp>();
                getuserlist2 = BLL.MGetHelp.GetListJoinMember(" t1.PPState in (0,1,2) and t1.SQMoney <> t1.MatchMoney and [id] in (" + getid + ") and (t2.PPLeavel is NULL or PPLeavel=0) order by t1.SQDate asc");

                return MatchProcess(offerlist, getuserlist2, getadminlist);
            }
        }

        /// <summary>
        /// 会员对会员匹配
        /// </summary>
        public static string MatchingScramble3(string offmid, string getmid)
        {
            lock (thisLock)
            {
                guilist.Clear();
                DateTime now = DateTime.Now.AddMinutes(-BLL.MMMConfig.Model.LineTimes);

                //提供帮助的记录
                List<Model.MOfferHelp> offerlist = new List<Model.MOfferHelp>();
                offerlist = BLL.MOfferHelp.GetList("PPState in (0,1,2) and HelpType = 0  and SQMID in (select MID from Member where MState='1' and IsClose<>'1' and mid = '" + offmid + "' )  order by SQDate");
                //管理员记录
                List<Model.MGetHelp> getadminlist = new List<Model.MGetHelp>();
                //getadminlist = BLL.MGetHelp.GetListJoinMember("t1.PPState in (0,2) and SQMID in (select MID from Member where MState='1' and IsClose<>'1' ) and t2.PPLeavel is not NULL and PPLeavel>0  order by t1.SQDate asc");
                //会员记录
                List<Model.MGetHelp> getuserlist2 = new List<Model.MGetHelp>();
                getuserlist2 = BLL.MGetHelp.GetListJoinMember("t1.PPState in (0,1,2) and SQMID in (select MID from Member where MState='1' and IsClose<>'1' and mid = '" + getmid + "' ) and (t2.PPLeavel is NULL or PPLeavel=0) order by t1.SQDate asc");

                return MatchProcess(offerlist, getuserlist2, getadminlist);
            }
        }

        /// <summary>
        /// 全部匹配
        /// </summary>
        public static string MatchingScramble2()
        {
            lock (thisLock)
            {
                guilist.Clear();
                DateTime now = DateTime.Now.AddMinutes(-BLL.MMMConfig.Model.LineTimes);

                //提供帮助的记录
                List<Model.MOfferHelp> offerlist = new List<Model.MOfferHelp>();
                offerlist = BLL.MOfferHelp.GetList("PPState in (0,1,2) and HelpType = 0 and SQMID in (select MID from Member where MState='1' and IsClose<>'1' ) order by SQDate");
                //管理员记录
                List<Model.MGetHelp> getadminlist = new List<Model.MGetHelp>();
                //getadminlist = BLL.MGetHelp.GetListJoinMember("t1.PPState in (0,1,2) and SQMID in (select MID from Member where MState='1' and IsClose<>'1' ) and t2.PPLeavel is not NULL and PPLeavel > 0  order by t1.SQDate asc");
                //会员记录
                List<Model.MGetHelp> getuserlist2 = new List<Model.MGetHelp>();
                getuserlist2 = BLL.MGetHelp.GetListJoinMember("t1.PPState in (0,1,2) and SQMID in (select MID from Member where MState='1' and IsClose<>'1' ) and (t2.PPLeavel is NULL or PPLeavel = 0) order by t1.SQDate asc");

                return MatchProcess(offerlist, getuserlist2, getadminlist);
            }
        }

        # endregion 抢单匹配

        # region 匹配

        /// <summary>
        /// 匹配全部
        /// </summary>
        /// <returns></returns>
        public static string MatchingHelp2()
        {
            //string result = MatchingScramble2();
            string result = MatchingHelpPrev2();
            result += Matching2();
            result += QDMatching2();
            if (result.Contains("操作成功") && !result.Contains("操作失败"))
            {
                return "操作成功";
            }
            else if (!result.Contains("操作成功") && result.Contains("操作失败"))
            {
                return "操作失败";
            }
            else if (result.Contains("操作成功") && result.Contains("操作失败"))
            {
                return "操作完成";
            }
            else
            {
                return "未匹配到任何订单";
            }
        }
        /// <summary>
        /// 抢单区匹配全部
        /// </summary>
        /// <returns></returns>
        private static string QDMatching2()
        {
            lock (thisLock)
            {
                guilist.Clear();
                DateTime now = DateTime.Now.AddMinutes(-BLL.MMMConfig.Model.MHBRangeTimes);
                DateTime getnow = DateTime.Now.AddMinutes(-BLL.MMMConfig.Model.FreezeTimesOfOffer);
                //提供帮助的记录
                List<Model.MOfferHelp> offerlist = new List<Model.MOfferHelp>();
                offerlist = BLL.MOfferHelp.GetList("PPState in (0,1,2) and HelpType = 1 and SQDate <= '" + now.ToString("yyyy-MM-dd HH:mm:ss") + "' and SQMID in (select MID from Member where MState='1' and IsClose<>'1' ) order by SQDate");
                //管理员记录
                List<Model.MGetHelp> getadminlist = new List<Model.MGetHelp>();
                getadminlist = BLL.MGetHelp.GetListJoinMember("t1.PPState in (0,1,2)  and SQDate <= '" + getnow.ToString("yyyy-MM-dd HH:mm:ss") + "' and SQMID in (select MID from Member where MState='1' and IsClose<>'1' ) and t2.PPLeavel is not NULL and PPLeavel > 0  order by t1.SQDate asc");
                //会员记录
                List<Model.MGetHelp> getuserlist2 = new List<Model.MGetHelp>();
                getuserlist2 = BLL.MGetHelp.GetListJoinMember("t1.PPState in (0,1,2)  and SQDate <= '" + getnow.ToString("yyyy-MM-dd HH:mm:ss") + "' and SQMID in (select MID from Member where MState='1' and IsClose<>'1' ) and (t2.PPLeavel is NULL or PPLeavel = 0) order by t1.SQDate asc");

                return MatchProcess(offerlist, getuserlist2, getadminlist);
            }
        }

        /// <summary>
        /// 帐号匹配
        /// </summary>
        /// <returns></returns>
        public static string MatchingHelp3(string offmid, string getmid)
        {
            //string result = MatchingScramble3(offmid, getmid);
            string result = MatchingHelpPrev3(offmid, getmid);
            result += Matching3(offmid, getmid);
            result += QDMatching3(offmid,getmid);
            if (result.Contains("操作成功") && !result.Contains("操作失败"))
            {
                return "操作成功";
            }
            else if (!result.Contains("操作成功") && result.Contains("操作失败"))
            {
                return "操作失败";
            }
            else if (result.Contains("操作成功") && result.Contains("操作失败"))
            {
                return "操作完成";
            }
            else
            {
                return "未匹配到任何订单";
            }
        }

        private static string QDMatching3(string offmid, string getmid)
        {
            lock (thisLock)
            {
                guilist.Clear();
                DateTime now = DateTime.Now.AddMinutes(-BLL.MMMConfig.Model.MHBRangeTimes);
                DateTime getnow = DateTime.Now.AddMinutes(-BLL.MMMConfig.Model.FreezeTimesOfOffer);
                //提供帮助的记录
                List<Model.MOfferHelp> offerlist = new List<Model.MOfferHelp>();
                offerlist = BLL.MOfferHelp.GetList("PPState in (0,1,2) and HelpType =1 and SQDate <= '" + now.ToString("yyyy-MM-dd HH:mm:ss") + "' and SQMID in (select MID from Member where MState='1' and IsClose<>'1' and mid = '" + offmid + "' )  order by SQDate");
                //管理员记录
                List<Model.MGetHelp> getadminlist = new List<Model.MGetHelp>();
                //getadminlist = BLL.MGetHelp.GetListJoinMember("t1.PPState in (0,2) and SQMID in (select MID from Member where MState='1' and IsClose<>'1' ) and t2.PPLeavel is not NULL and PPLeavel>0  order by t1.SQDate asc");
                //会员记录
                List<Model.MGetHelp> getuserlist2 = new List<Model.MGetHelp>();
                getuserlist2 = BLL.MGetHelp.GetListJoinMember("t1.PPState in (0,1,2)  and SQDate <= '" + getnow.ToString("yyyy-MM-dd HH:mm:ss") + "' and SQMID in (select MID from Member where MState='1' and IsClose<>'1' and mid = '" + getmid + "' ) and (t2.PPLeavel is NULL or PPLeavel=0) order by t1.SQDate asc");

                return MatchProcess(offerlist, getuserlist2, getadminlist);
            }
        }

        private static string QDMatching3()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 单号匹配
        /// </summary>
        /// <returns></returns>
        public static string MatchingHelp4(string offid, string getid)
        {
            string result = MatchingScramble4(offid, getid);
            result += MatchingHelpPrev4(offid, getid);
            result += Matching4(offid, getid);
            result += QDMatching4(offid, getid);
            if (result.Contains("操作成功") && !result.Contains("操作失败"))
            {
                return "操作成功";
            }
            else if (!result.Contains("操作成功") && result.Contains("操作失败"))
            {
                return "操作失败";
            }
            else if (result.Contains("操作成功") && result.Contains("操作失败"))
            {
                return "操作完成";
            }
            else
            {
                return "未匹配到任何订单";
            }
        }

        private static string QDMatching4(string offid, string getid)
        {
            lock (thisLock)
            {
                guilist.Clear();
                DateTime now = DateTime.Now.AddMinutes(-BLL.MMMConfig.Model.MHBRangeTimes);
                DateTime getnow = DateTime.Now.AddMinutes(-BLL.MMMConfig.Model.FreezeTimesOfOffer);
                //提供帮助的记录
                List<Model.MOfferHelp> offerlist = new List<Model.MOfferHelp>();
                offerlist = BLL.MOfferHelp.GetList(" PPState in (0,1,2) and HelpType = 1 and  SQMoney <> MatchMoney and SQDate <= '" + now.ToString("yyyy-MM-dd HH:mm:ss") + "' and [Id] in (" + offid + ") order by SQDate");
                //管理员记录
                List<Model.MGetHelp> getadminlist = new List<Model.MGetHelp>();
                //////交易中的不能匹配
                //getadminlist = BLL.MGetHelp.GetListJoinMember("t1.PPState in (0,2) and SQMID in (select MID from Member where MState='1' and IsClose<>'1' ) and t2.PPLeavel is not NULL and PPLeavel>0  order by t1.SQDate asc");
                List<Model.MGetHelp> getuserlist2 = new List<Model.MGetHelp>();
                getuserlist2 = BLL.MGetHelp.GetListJoinMember(" t1.PPState in (0,1,2)  and SQDate <= '" + getnow.ToString("yyyy-MM-dd HH:mm:ss") + "' and t1.SQMoney <> t1.MatchMoney and [id] in (" + getid + ") and (t2.PPLeavel is NULL or PPLeavel=0) order by t1.SQDate asc");

                return MatchProcess(offerlist, getuserlist2, getadminlist);
            }
        }

        # endregion 匹配

        # region 匹配过程

        /// <summary>
        /// 全部匹配匹配过程
        /// </summary>
        private static string MatchProcess(List<Model.MOfferHelp> offerlist, List<Model.MGetHelp> getlist, List<Model.MGetHelp> getadminlist)
        {
            List<Model.MHelpMatch> matchlist = new List<Model.MHelpMatch>();
            Dictionary<string, Model.MGetHelp> successget = new Dictionary<string, Model.MGetHelp>();
            Dictionary<string, Model.MOfferHelp> successoff = new Dictionary<string, Model.MOfferHelp>();

            //管理员匹配
            //优先匹配管理员,相等匹配,时间匹配
            EquelMatch(ref offerlist, ref successoff, ref getadminlist, ref successget, ref matchlist);
            TimeMatch(ref offerlist, ref successoff, ref getadminlist, ref successget, ref matchlist);
            getlist.InsertRange(0, getadminlist);

            List<Model.MGetHelp> getuserlist = new List<Model.MGetHelp>();

            for (int i = 0; i < getlist.Count && i < 100; i++)
            {
                getuserlist.Add(getlist[i]);
            }

            //会员匹配
            ////会员匹配,相等匹配,时间匹配
            EquelMatch(ref offerlist, ref successoff, ref getuserlist, ref successget, ref matchlist);
            TimeMatch(ref offerlist, ref successoff, ref getuserlist, ref successget, ref matchlist);

            //数据库执行
            Hashtable MyHs = new Hashtable();
            foreach (Model.MGetHelp mg in successget.Values)
            {
                BLL.MGetHelp.Update(mg, MyHs);
            }

            foreach (Model.MOfferHelp mo in successoff.Values)
            {
                BLL.MOfferHelp.Update(mo, MyHs);
            }
            if (!matchlist.Any())
            {
                return "未匹配到任何订单";
            }
            SendSMS(matchlist, MyHs);
            if (DAL.CommonBase.RunHashtable(MyHs))
            {
                return "操作成功";
            }
            return "操作失败";
        }

        /// <summary>
        /// 部分匹配匹配过程
        /// </summary>
        private static string MatchProcess2(List<Model.MOfferHelp> offerlist, List<Model.MGetHelp> getlist, List<Model.MGetHelp> getadminlist)
        {
            List<Model.MHelpMatch> matchlist = new List<Model.MHelpMatch>();
            Dictionary<string, Model.MGetHelp> successget = new Dictionary<string, Model.MGetHelp>();
            Dictionary<string, Model.MOfferHelp> successoff = new Dictionary<string, Model.MOfferHelp>();

            //管理员匹配
            //优先匹配管理员,相等匹配,时间匹配
            EquelMatch(ref offerlist, ref successoff, ref getadminlist, ref successget, ref matchlist);
            TimeMatch2(ref offerlist, ref successoff, ref getadminlist, ref successget, ref matchlist);
            getlist.InsertRange(0, getadminlist);

            List<Model.MGetHelp> getuserlist = new List<Model.MGetHelp>();

            for (int i = 0; i < getlist.Count && i < 100; i++)
            {
                getuserlist.Add(getlist[i]);
            }

            //会员匹配
            ////会员匹配,相等匹配,时间匹配
            EquelMatch(ref offerlist, ref successoff, ref getuserlist, ref successget, ref matchlist);
            TimeMatch2(ref offerlist, ref successoff, ref getuserlist, ref successget, ref matchlist);

            //数据库执行
            Hashtable MyHs = new Hashtable();
            foreach (Model.MGetHelp mg in successget.Values)
            {
                BLL.MGetHelp.Update(mg, MyHs);
            }

            foreach (Model.MOfferHelp mo in successoff.Values)
            {
                BLL.MOfferHelp.Update(mo, MyHs);
            }
            if (!matchlist.Any())
            {
                return "未匹配到任何订单";
            }
            SendSMS2(matchlist, MyHs);
            if (DAL.CommonBase.RunHashtable(MyHs))
            {
                return "操作成功";
            }
            return "操作失败";
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        private static Hashtable SendSMS2(List<Model.MHelpMatch> matchlist, Hashtable MyHs)
        {
            foreach (Model.MHelpMatch mh in matchlist)
            {
                Model.Member offMember = DAL.Member.GetModel(mh.OfferMID);
                Model.MOfferHelp offer = DAL.MOfferHelp.GetModel(mh.OfferId);
                Model.Member getMember = DAL.Member.GetModel(mh.GetMID);
                Model.MGetHelp get = DAL.MGetHelp.GetModel(mh.GetId);
                //提供帮助
                string Msg = "尊敬的会员您好！您订单号" + offer.SQCode + "提供帮助的订单已经匹配成功，请在规定时间内完成，感谢您的参与！祝您生活愉快！";
                Model.SMS model = new Model.SMS { SType = Model.SMSType.ZCYZ, Tel = offMember.Tel, SContent = Msg };
                string error = "";
                BLL.SMS.Insert(model, ref error);
                //获得帮助
                model.SContent = "尊敬的会员您好！您订单号" + get.SQCode + "得到帮助的订单已经匹配成功，请注意查看，感谢您的参与！祝您生活愉快！";
                model.Tel = getMember.Tel;
                BLL.SMS.Insert(model, ref error);
                BLL.MHelpMatch.Insert(mh, MyHs);
            }
            return MyHs;
        }

        /// <summary>
        /// 发送短信
        /// </summary>
        private static Hashtable SendSMS(List<Model.MHelpMatch> matchlist, Hashtable MyHs)
        {
            foreach (Model.MHelpMatch mh in matchlist)
            {
                Model.Member offMember = DAL.Member.GetModel(mh.OfferMID);
                Model.MOfferHelp offer = DAL.MOfferHelp.GetModel(mh.OfferId);
                Model.Member getMember = DAL.Member.GetModel(mh.GetMID);
                Model.MGetHelp get = DAL.MGetHelp.GetModel(mh.GetId);
                string Msg = "尊敬的会员您好！您订单号" + offer.SQCode + "提供帮助的订单已经匹配成功，请在规定时间内完成，感谢您的参与！祝您生活愉快！";
                Model.SMS model = new Model.SMS { SType = Model.SMSType.ZCYZ, Tel = offMember.Tel, SContent = Msg };
                string error = "";
                BLL.SMS.Insert(model, ref error);
                //获得帮助
                model.SContent = "尊敬的会员您好！您订单号" + get.SQCode + "得到帮助的订单已经匹配成功，请注意查看，感谢您的参与！祝您生活愉快！";
                model.Tel = getMember.Tel;
                BLL.SMS.Insert(model, ref error);
                BLL.MHelpMatch.Insert(mh, MyHs);
            }
            return MyHs;
        }

        /// <summary>
        /// 相等匹配
        /// </summary>
        /// <param name="offerlist"></param>
        /// <param name="getlist"></param>
        /// <param name="match"></param>
        /// <returns></returns>
        public static void EquelMatch(ref List<Model.MOfferHelp> offerlist, ref Dictionary<string, Model.MOfferHelp> successoff, ref List<Model.MGetHelp> getlist, ref Dictionary<string, Model.MGetHelp> successget, ref List<Model.MHelpMatch> match)
        {
            //List<Model.MGetHelp> getlistTemp = new List<Model.MGetHelp>();
            //getlistTemp.AddRange(getlist);

            //for (int i = 0; i < getlistTemp.Count; i++)
            //{
            //    Model.MOfferHelp off = EquelMatch(getlistTemp[i], ref offerlist, ref match);
            //    if (off != null)
            //    {
            //        if (successget.ContainsKey(getlistTemp[i].SQCode))
            //            successget[getlistTemp[i].SQCode] = getlistTemp[i];
            //        else
            //            successget.Add(getlistTemp[i].SQCode, getlistTemp[i]);
            //        getlist.Remove(getlistTemp[i]);

            //        if (successoff.ContainsKey(off.SQCode))
            //            successoff[off.SQCode] = off;
            //        else
            //            successoff.Add(off.SQCode, off);
            //        offerlist.Remove(off);
            //    }
            //}
        }

        public static Model.MOfferHelp EquelMatch(Model.MGetHelp get, ref List<Model.MOfferHelp> offerlist, ref List<Model.MHelpMatch> match)
        {
            //Model.MOfferHelp off = offerlist.Find(c => c.Money == get.Money && c.SQMID != get.SQMID);
            //if (off != null)
            //{
            //    Model.MHelpMatch objHelp = new Model.MHelpMatch();
            //    objHelp.GetId = get.Id;
            //    objHelp.GetMID = get.SQMID;
            //    objHelp.MatchCode = GetGuid();//订单匹配编号
            //    while (BLL.CommonBase.GetSingle("select MatchCode from MHelpMatch where MatchCode='" + objHelp.MatchCode + "'") != null)
            //    {
            //        objHelp.MatchCode = GetGuid();
            //    }
            //    objHelp.MatchMoney = get.Money;
            //    objHelp.MatchState = 1;
            //    objHelp.MatchTime = DateTime.Now;
            //    objHelp.OfferId = off.Id;
            //    objHelp.OfferMID = off.SQMID;

            //    match.Add(objHelp);

            //    decimal offmoney = off.Money;

            //    get.PPState = 1;
            //    get.MatchMoney += offmoney;
            //    off.PPState = 1;
            //    off.MatchMoney += offmoney;
            //    return off;
            //}
            return null;
        }
        /// <summary>
        /// 预付款匹配
        /// </summary>
        public static void TimeMatch2(ref List<Model.MOfferHelp> offerlist, ref Dictionary<string, Model.MOfferHelp> successoff, ref List<Model.MGetHelp> getlist, ref Dictionary<string, Model.MGetHelp> successget, ref List<Model.MHelpMatch> match)
        {
            for (int m = 0; m < getlist.Count; m++)
            {
                for (int i = 0; i < offerlist.Count; i++)
                {
                    if (getlist[m].SQMID == offerlist[i].SQMID)
                        continue;
                    if (offerlist[i].MFLMoney <= offerlist[i].MatchMoney)
                    {//预付款匹配完了
                        continue;
                    }
                    decimal matchmoney = getlist[m].Money > (offerlist[i].MFLMoney - offerlist[i].MatchMoney) ? (offerlist[i].MFLMoney - offerlist[i].MatchMoney) : getlist[m].Money;
                    if (matchmoney <= 0)
                    {
                        continue;
                    }
                    getlist[m].MatchMoney += matchmoney;
                    offerlist[i].MatchMoney += matchmoney;

                    //生成匹配记录match
                    Model.MHelpMatch objHelp = new Model.MHelpMatch();
                    objHelp.GetId = getlist[m].Id;
                    objHelp.GetMID = getlist[m].SQMID;
                    objHelp.MatchCode = GetGuid();//订单匹配编号
                    while (BLL.CommonBase.GetSingle("select MatchCode from MHelpMatch where MatchCode='" + objHelp.MatchCode + "'") != null)
                    {
                        objHelp.MatchCode = GetGuid();
                    }
                    objHelp.MatchMoney = matchmoney;
                    objHelp.MatchState = 1;
                    objHelp.MatchTime = DateTime.Now;
                    objHelp.OfferId = offerlist[i].Id;
                    objHelp.OfferMID = offerlist[i].SQMID;
                    objHelp.MatchType = 1;//预付款匹配

                    match.Add(objHelp);
                    if (successoff.ContainsKey(offerlist[i].SQCode))
                        successoff[offerlist[i].SQCode] = offerlist[i];
                    else
                        successoff.Add(offerlist[i].SQCode, offerlist[i]);
                    if (successget.ContainsKey(getlist[m].SQCode))
                        successget[getlist[m].SQCode] = getlist[m];
                    else
                        successget.Add(getlist[m].SQCode, getlist[m]);

                    offerlist[i].PPState = 2;
                    getlist[m].PPState = 2;

                    if (offerlist[i].MFLMoney - offerlist[i].MatchMoney == 0)
                    {
                        offerlist[i].PPState = 1;
                        offerlist.Remove(offerlist[i]);
                        i--;
                    }
                    if (getlist[m].Money == 0)
                    {
                        getlist[m].PPState = 1;
                        getlist.Remove(getlist[m]);
                        m--;
                        TimeMatch2(ref offerlist, ref successoff, ref getlist, ref successget, ref match);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// 全部匹配
        /// </summary>
        public static void TimeMatch(ref List<Model.MOfferHelp> offerlist, ref Dictionary<string, Model.MOfferHelp> successoff, ref List<Model.MGetHelp> getlist, ref Dictionary<string, Model.MGetHelp> successget, ref List<Model.MHelpMatch> match)
        {
            for (int m = 0; m < getlist.Count; m++)
            {
                for (int i = 0; i < offerlist.Count; i++)
                {
                    if (getlist[m].SQMID == offerlist[i].SQMID)
                    {
                        continue;
                    }
                    decimal matchmoney = getlist[m].Money > offerlist[i].Money ? offerlist[i].Money : getlist[m].Money;
                    if (matchmoney <= 0)
                    {
                        continue;
                    }
                    getlist[m].MatchMoney += matchmoney;
                    offerlist[i].MatchMoney += matchmoney;

                    //生成匹配记录match
                    Model.MHelpMatch objHelp = new Model.MHelpMatch();
                    objHelp.GetId = getlist[m].Id;
                    objHelp.GetMID = getlist[m].SQMID;
                    objHelp.MatchCode = GetGuid();//订单匹配编号
                    while (BLL.CommonBase.GetSingle("select MatchCode from MHelpMatch where MatchCode='" + objHelp.MatchCode + "'") != null)
                    {
                        objHelp.MatchCode = GetGuid();
                    }
                    objHelp.MatchMoney = matchmoney;
                    objHelp.MatchState = 1;
                    objHelp.MatchTime = DateTime.Now;
                    objHelp.OfferId = offerlist[i].Id;
                    objHelp.OfferMID = offerlist[i].SQMID;
                    if (offerlist[i].HelpType == 1)
                    {
                        objHelp.MatchType = 2;//抢单匹配
                    }
                    else
                    {
                        objHelp.MatchType = 0;//正常匹配
                    }

                    match.Add(objHelp);
                    if (successoff.ContainsKey(offerlist[i].SQCode))
                        successoff[offerlist[i].SQCode] = offerlist[i];
                    else
                        successoff.Add(offerlist[i].SQCode, offerlist[i]);
                    if (successget.ContainsKey(getlist[m].SQCode))
                        successget[getlist[m].SQCode] = getlist[m];
                    else
                        successget.Add(getlist[m].SQCode, getlist[m]);

                    offerlist[i].PPState = 2;
                    getlist[m].PPState = 2;

                    if (offerlist[i].Money == 0)
                    {
                        offerlist[i].PPState = 1;
                        offerlist.Remove(offerlist[i]);
                        i--;
                    }
                    if (getlist[m].Money == 0)
                    {
                        getlist[m].PPState = 1;
                        getlist.Remove(getlist[m]);
                        m--;
                        TimeMatch(ref offerlist, ref successoff, ref getlist, ref successget, ref match);
                        break;
                    }
                }
            }
        }

        public static List<string> guilist = new List<string>();
        protected static string GetGuid()
        {
            string guid = Guid.NewGuid().ToString().Replace("-", "").Replace(" ", "").ToUpper().Substring(0, 15);
            while (guilist.Contains(guid))
            {
                guid = Guid.NewGuid().ToString().Replace("-", "").Replace(" ", "").ToUpper().Substring(0, 15);
            }
            guilist.Add(guid);
            return guid;
        }

        public static bool MatchingTemp(DataRow[] matchLessOffers, decimal money, DataRow dr, Hashtable hs)
        {
            foreach (DataRow ml in matchLessOffers)
            {
                Model.MHelpMatch matchh = new Model.MHelpMatch();
                matchh.GetId = int.Parse(ml["Id"].ToString());
                matchh.GetMID = ml["SQMID"].ToString();
                matchh.MatchCode = Guid.NewGuid().ToString();//订单匹配编号
                matchh.MatchState = 1;
                matchh.MatchTime = DateTime.Now;
                matchh.OfferId = Convert.ToInt32(ml["Id"]);
                matchh.OfferMID = ml["SQMID"].ToString();
                matchh.MatchMoney = money;
                BLL.MHelpMatch.Insert(matchh, hs);
                //得到帮助的这条记录还剩余多少
                decimal plusMoney = Convert.ToDecimal(dr["SQMoney"]) - money;
            }
            return false;
        }

        # endregion 匹配过程

        # region 定时触发

        public static Object thisLock = new Object();

        /// <summary>
        /// 发放日利息
        /// </summary>
        /// <returns></returns>
        public static bool MMMLiXi()
        {
            lock (thisLock)
            {
                Hashtable MyHs = new Hashtable();
                //打款前打款后利息
                //                MyHs.Add(@"
                //                        --打款前利息
                //                        declare @lixi1 decimal(18,4);
                //                        --打款后利息
                //                        declare @lixi2 decimal(18,4);
                //                        --出局时间
                //                        declare @outTime int;
                //                        --时间基数
                //                        declare @lixiTimeBase int;
                //                        --一分钟
                //                        set @lixiTimeBase=1;
                //                        --冻结期内利息
                //                        set @lixi1=(select lixi1 from MMMConfig);
                //                        --冻结期外利息
                //                        set @lixi2=(select lixi2 from MMMConfig);
                //                        --出局时间
                //                        set @outTime=(select OutTimes/@lixiTimeBase from MMMConfig);
                //
                //                        --打款前利息
                //                        update MOfferHelp set TotalInterest=SQMoney*(@lixi1*(DATEDIFF(mi,sqdate,getdate())/@lixiTimeBase)),
                //                        TotalInterestDays=(DATEDIFF(mi,sqdate,getdate())/@lixiTimeBase)
                //                        --未完成
                //                        where PPState < 3 
                //                        --已发次数小于当日该发的次数
                //                        and TotalInterestDays < (DATEDIFF(mi,sqdate,getdate())/@lixiTimeBase)
                //                        --未出局
                //                        and (DATEDIFF(mi,sqdate,getdate())/@lixiTimeBase) <= @outTime;
                //
                //                        --打款后利息
                //                        update MOfferHelp set TotalInterest=SQMoney*(@lixi2*((DATEDIFF(mi,sqdate,getdate())/@lixiTimeBase)-(DATEDIFF(mi,SQDate,CompleteTime)/@lixiTimeBase))+@lixi1*(DATEDIFF(mi,SQDate,CompleteTime)/@lixiTimeBase)),
                //                        TotalInterestDays=(DATEDIFF(mi,sqdate,getdate())/@lixiTimeBase)
                //                        --完成未提款
                //                        where PPState = 3
                //                        --已发次数小于当日该发的次数
                //                        and TotalInterestDays < (DATEDIFF(mi,sqdate,getdate())/@lixiTimeBase)
                //                        --当日该发次数小于等于最大应发次数
                //                        and (DATEDIFF(mi,sqdate,getdate())/@lixiTimeBase) <= @outTime;
                //                    ", null);

                //MyHs.Add(@"
                //        --出局时间
                //        declare @outTime int;
                //        --时间基数
                //        declare @lixiTimeBase int;
                //        --一分钟
                //        set @lixiTimeBase=1;

                //        --出局时间
                //        set @outTime=(select OutTimes/@lixiTimeBase from MMMConfig);

                //        --打款前利息
                //        update MOfferHelp set TotalInterest=SQMoney*(dayInterest*(DATEDIFF(mi,sqdate,getdate())/@lixiTimeBase)),
                //        TotalInterestDays=(DATEDIFF(mi,sqdate,getdate())/@lixiTimeBase)
                //        --正常订单
                //        where HelpType = 0 
                //        --没有提现
                //        and PPState < 4
                //        --已发次数小于当日该发的次数
                //        and TotalInterestDays < (DATEDIFF(mi,sqdate,getdate())/@lixiTimeBase)
                //        --未出局
                //        and (DATEDIFF(mi,sqdate,getdate())/@lixiTimeBase) <= @outTime;
                //", null);

                MyHs.Add(@"
                       --出局时间
                        declare @outTime int;
                        --时间基数
                        declare @lixiTimeBase int;
                        --一分钟
                        set @lixiTimeBase=1440;
                        
                        --出局时间
                        set @outTime=(select OutTimes/@lixiTimeBase from MMMConfig);

                        --打款前利息
                        update MOfferHelp set TotalInterest=TotalInterest+SQMoney*dayInterest,
                        TotalInterestDays=TotalInterestDays+1
                        --正常订单
                        where HelpType = 0 
                        --没有提现
                        and PPState < 4
                        --已发次数小于该发次数
                        and TotalInterestDays < @lixiTimeBase;
                ", null);

                return BLL.CommonBase.RunHashtable(MyHs);
            }
        }

        /// <summary>
        /// 会员在规定的时间没有打款,账号锁定
        /// </summary>
        /// <returns></returns>
        public static bool MMMChangeDKMID()
        {
            lock (thisLock)
            {
                DataTable list = BLL.CommonBase.GetTable(@"
                                                        declare @PLT1 int;
                                                        declare @PLT2 int;
                                                        declare @PLT3 int;
                                                        set @PLT1 = (select PayLimitTimes from MMMConfig)
                                                        set @PLT2 = (select PayLimitTimesPre from MMMConfig)
                                                        set @PLT3 = (select PayLimitTimes from MMMConfigScramble)

                                                        select distinct OfferMID,OfferId 
                                                        from MHelpMatch 
                                                        where MatchState=1  and (
	                                                        (MatchType=0 and datediff(MI,MatchTime,getdate())>@PLT1)
                                                         or (MatchType=1 and datediff(MI,MatchTime,getdate())>@PLT2)
                                                         or (MatchType=2 and datediff(MI,MatchTime,getdate())>@PLT3)
                                                        )");
                List<string> matchlist = new List<string>();
                foreach (DataRow item in list.Rows)
                {
                    Hashtable MyHs = new Hashtable();
                    string OfferId = item["OfferId"].ToString();
                    if (matchlist.Contains(OfferId))
                        continue;
                    else
                        matchlist.Add(OfferId);

                    Model.MOfferHelp off = BLL.MOfferHelp.GetModel(OfferId);

                    if (off != null)
                    {
                        freezeMember(off, MyHs);
                        //扣推荐人钱
                        Model.Member offModel = DAL.Member.GetModel(off.SQMID);
                        if (offModel.MTJ != BLL.Member.ManageMember.TModel.MID)
                        {
                            BLL.ChangeMoney.HBChangeTran(off.SQMoney * BLL.MMMConfig.Model.LiXi1, offModel.MTJ, BLL.Member.ManageMember.TModel.MID, "TJKF", offModel, "MHB", "不打款扣推荐人" + BLL.MMMConfig.Model.LiXi1.ToPercent()+"；订单号："+off.SQCode, MyHs);
                        }
                    }
                    BLL.CommonBase.RunHashtable(MyHs);
                }
                return true;
            }
        }

        /// <summary>
        /// 冻结打款方帐号
        /// </summary>
        public static Hashtable freezeMember(Model.MOfferHelp off, Hashtable MyHs, string remark = "超时打款")
        {
            MyHs.Add("update member set IsClock='1',IsClose='1',Province='" + remark + "' where mid='" + off.SQMID + "'; select '" + Guid.NewGuid().ToString() + "';", null);
            Model.Member member = BLL.Member.GetModelByMID(off.SQMID);
            if (member.MTJ != BLL.Member.ManageMember.TModel.MID)
            {
                MyHs.Add("update mofferhelp set sqmid='"+ member.MTJ+"' where id=" + off.Id + "'; select '" + Guid.NewGuid().ToString() + "';", null);
                MyHs.Add("update MHelpMatch set OfferMID='"+ member.MTJ+ "',MatchTime=getdate() ,PicUrl3=PicUrl3+'["+DateTime.Now.ToString()+member.MID+"超时付款转给推荐人>"+member.MTJ+"付款]' where OfferId=" + off.Id+"'; select '" + Guid.NewGuid().ToString() + "';", null);
            }
            return MyHs;
            //List<Model.MHelpMatch> listOfferMatch = BLL.MHelpMatch.GetList("OfferId=" + off.Id);
            //foreach (Model.MHelpMatch match in listOfferMatch)
            //{
            //    if (match != null && match.MatchState < 3)
            //    {
            //        BLL.MHelpMatch.Delete(match.Id, MyHs);
            //        off.MatchMoney = off.MatchMoney - match.MatchMoney;

            //        Model.MGetHelp get = BLL.MGetHelp.GetModel(match.GetId);
            //        get.MatchMoney = get.MatchMoney - match.MatchMoney;
            //        if (get.MatchMoney == 0)
            //        {
            //            get.PPState = 0;
            //        }
            //        else if (get.Money > 0)
            //        {
            //            get.PPState = 2;
            //        }
            //        BLL.MGetHelp.Update(get, MyHs);

            //        MyHs.Add("update member set IsClock='1',IsClose='1',Province='" + remark + "' where mid='" + off.SQMID + "'; select '" + Guid.NewGuid().ToString() + "';", null);
            //    }
            //}
            //if (off.MatchMoney == 0)
            //{
            //    off.PPState = 0;
            //    off.DKState = 0;
            //    off.HelpType = 99;
            //    //MyHs.Add(" delete from MOfferHelp where SQCode = '" + off.SQCode + "' ", null);
            //}
            //else if (off.Money > 0)
            //{
            //    off.PPState = 2;
            //}
            //BLL.MOfferHelp.Update(off, MyHs);
            ////MyHs.Add("delete from MOfferHelp where PPState=0 and SQMID='" + off.SQMID + "'; select '" + Guid.NewGuid().ToString() + "';", null);
            //MyHs.Add("delete from  ChangeMoney  where CFileds2='" + off.SQCode + "'; select '" + Guid.NewGuid().ToString() + "';", null);
            //return MyHs;
        }

        /// <summary>
        /// 领导人在规定的时间没有打款，自动把打款信息变更为FC互助币大使
        /// </summary>
        /// <returns></returns>
        public static bool MMMChangeMTJDKMID()
        {
            //lock (thisLock)
            //{
            //    DataTable list = BLL.CommonBase.GetTable(@"select distinct OfferMID,OfferId from MHelpMatch t1 left join MMMConfig t2 on 1=1  where t1.MatchState=1 and ChangeCount=1 and datediff(MI,t1.MatchTime,getdate())>t2.TJPayTime");
            //    foreach (DataRow item in list.Rows)
            //    {
            //        Hashtable hs = new Hashtable();
            //        //string Id = item["Id"].ToString();
            //        string OfferId = item["OfferId"].ToString();
            //        string mid = item["OfferMID"].ToString();
            //        //int changeCount = int.Parse(item["ChangeCount"].ToString());
            //        //if (changeCount == 1)
            //        //{
            //        //找到马夫罗大师
            //        Model.Member vipMemer = new BLL.Member().GetMemberEntityList("IsClose=0 and MState=1 and RoleCode='VIP'").OrderBy(c => c.MConfig.MJB).FirstOrDefault();
            //        if (vipMemer != null)
            //        {
            //            List<Model.MHelpMatch> listOfferMatch = BLL.MHelpMatch.GetList("OfferId=" + OfferId);
            //            foreach (Model.MHelpMatch match in listOfferMatch)
            //            {
            //                if (match != null)
            //                {
            //                    match.ChangeVIPTime = match.MatchTime;
            //                    match.MatchTime = DateTime.Now;
            //                    match.ChangeCount = 2;
            //                    match.OfferMID = vipMemer.MID;
            //                    match.Remark = mid + "超过规定时间未付款,自动转移到您的名下，要求您付款";
            //                    BLL.MHelpMatch.Update(match);
            //                }
            //            }
            //            Model.MOfferHelp off = BLL.MOfferHelp.GetModel(OfferId);
            //            if (off != null)
            //            {
            //                off.SQMID = vipMemer.MID;
            //                off.Remark = mid + "超过规定时间未付款,自动转移到您的名下，要求您付款";
            //                BLL.MOfferHelp.Update(off, hs);
            //                //变更付款人，1-删除原有ChangeMoney记录，2-重新生成ChangeMoney
            //                string sql = "delete from  ChangeMoney  where CFileds2='" + off.SQCode + "'";
            //                BLL.CommonBase.RunSql(sql);
            //                //BLL.ChangeMoney.TJ(off.SQMoney, vipMemer, off, hs);//推荐奖
            //            }

            //            //BLL.ChangeMoney.KFMoneyChange(mid, BLL.Member.ManageMember.TModel.MID, BLL.MMMConfig.Model.TJKCMFL, "MJB", hs);
            //            //}

            //        }
            //        BLL.CommonBase.RunHashtable(hs);
            //    }
            return true;
            //}
        }

        /// <summary>
        /// 超过24小时自动收款
        /// </summary>
        /// <returns></returns>
        public static bool MMMAutoGetMoney()
        {
            lock (thisLock)
            {
                DataTable list = BLL.CommonBase.GetTable(@"
                                                        declare @CLT1 int;
                                                        declare @CLT2 int;
                                                        declare @CLT3 int;
                                                        set @CLT1 = (select ConfirmLimitTimes from MMMConfig)
                                                        set @CLT2 = (select ConfirmLimitTimesPre from MMMConfig)
                                                        set @CLT3 = (select ConfirmLimitTimes from MMMConfigScramble)
                                                        select * from MHelpMatch
                                                        where MatchState=2  and (
	                                                        (MatchType=0 and datediff(MI,PayTime,getdate())>@CLT1) 
                                                         or (MatchType=1 and datediff(MI,PayTime,getdate())>@CLT2)
                                                         or (MatchType=2 and datediff(MI,PayTime,getdate())>@CLT3)
                                                        )");
                foreach (DataRow item in list.Rows)
                {
                    Hashtable MyHs = new Hashtable();
                    string Id = item["Id"].ToString();
                    Model.MHelpMatch match = BLL.MHelpMatch.GetModel(Id);
                    if (match != null)
                    {
                        string result = BLL.MHelpMatch.GetMoney(match, "超时收款,冻结帐号,自动确认", MyHs);
                        if (string.IsNullOrEmpty(result))
                        {
                            MyHs.Add("update member set IsClock='1',IsClose='1',Province='超时收款' where mid='" + match.GetMID + "'; select '" + Guid.NewGuid().ToString() + "';", null);
                            Model.MGetHelp get = BLL.MGetHelp.GetModel(match.GetId);
                            //Model.Member getModel = BLL.Member.GetModelByMID(get.SQMID);
                            //BLL.ChangeMoney.HBChangeTran(get.SQMoney * BLL.MMMConfig.Model.GetTJKF, getModel.MTJ, BLL.Member.ManageMember.TModel.MID, "TJKF", getModel, "MHB", "不收款扣推荐人" + BLL.MMMConfig.Model.GetTJKF.ToPercent(), MyHs);
                            BLL.CommonBase.RunHashtable(MyHs);
                        }
                    }
                }
                return true;
            }
        }

        /// <summary>
        /// 确认收款
        /// </summary>
        public static string GetMoney(Model.MHelpMatch match, string pic, Hashtable MyHs)
        {
            if (match.MatchState == 3)
            {
                return "您已确认过收款，请不要重复确认收款";
            }

            match.MatchState = 3;
            match.ConfirmTime = DateTime.Now;
            match.PicUrl3 = pic;
            BLL.MHelpMatch.Update(match, MyHs);
            Model.MOfferHelp offer = BLL.MOfferHelp.GetModel(match.OfferId);

            //规定时间内打款
            //if ((match.PayTime.Value - match.MatchTime).TotalMinutes > BLL.MMMConfig.Model.MHBBase)
            {
                offer.SincerityState = 1;
                //offer.TotalSincerity += match.MatchMoney * BLL.MMMConfig.Model.HonestFloat;
            }

            //规定时间外收款
            //if ((match.PayTime.Value - match.MatchTime).TotalMinutes > BLL.MMMConfig.Model.HonestTimes)
            //{
            //    offer.SincerityState = 0;
            //}

            Model.Member offModel = null;
            offModel = BLL.Member.GetModelByMID(offer.SQMID);
            //提供帮助最后一个匹配项完了
            if (BLL.MHelpMatch.GetList("MatchState in(1,2) and MatchCode<>'" + match.MatchCode + "' and OfferId=" + match.OfferId).Count <= 0)
            {
                //订单存在并且未匹配为0
                if (offer != null && offer.Money == 0m)
                {
                    # region 更新基本数据

                    //交易完了
                    offer.DKState = 2;
                    offer.PPState = 3;
                    offer.CompleteTime = DateTime.Now;

                    //更新投资额度
                    BLL.Member.UpdateConfigTran(offer.SQMID, "SHMoney", offer.SQMoney.ToString(), null, false, SqlDbType.Decimal, MyHs);
                    
                    //增加投资额
                    offModel.MConfig.SHMoney += (int)offer.SQMoney;

                    //如果是抢单,直接给10天利息
                    //if (offer.HelpType == 1)
                    //{
                    //    offer.TotalInterest = offer.DayInterest * offer.SQMoney * BLL.MMMConfigScramble.Model.ScrambleLiXiDays;
                    //}

                    # endregion 更新基本数据

                    # region 发放奖励

                    //if (offer.SincerityState == 1)
                    //{
                    //    //计算诚信奖
                    //    offer.TotalSincerity = offer.SQMoney * BLL.MMMConfig.Model.HonestFloat;
                    //}

                    //更新团队业绩
                    BLL.ChangeMoney.YJMoneyTran(offer.SQMoney, offModel, offModel, MyHs);
                    BLL.ChangeMoney.TJMoneyTran(offer.SQMoney, offModel.MTJ, MyHs);


                    BLL.ChangeMoney.R_GL(offer, offModel, MyHs);
                    BLL.ChangeMoney.R_TJ(offer, offModel, MyHs);
                    ////返还激活码
                    //BLL.ChangeMoney.FHJHM(offer, offModel, MyHs);
                    ////抢单奖
                    //BLL.ChangeMoney.R_QDZF(offer, offModel, MyHs);

                    ////解冻推荐奖
                    //BLL.Member bll = new Member();
                    //List<Model.ChangeMoney> listChangeMoney2 = bll.GetChangeMoneyEntityList(" ChangeType in ('R_TJ') and CState=0 and ToMID = '" + offModel.MID + "' ");
                    ////解冻奖金
                    //BLL.ChangeMoney.JDChangeTran(listChangeMoney2, MyHs);

                    #endregion 发放奖励
                }
                else
                {
                    offer.PPState = 2;
                }
            }

            //发放管理奖//发放推荐奖
            //BLL.ChangeMoney.R_LD(match, offModel, MyHs);
            //BLL.ChangeMoney.R_TJ(match, offModel, MyHs);

            #region 完成一单就直接加利息

            //if (offer.HelpType == 0)//如果是正常排单
            //{
            //    int minute = (int)(DateTime.Now - match.MatchTime).TotalMinutes;
            //    if (minute >= BLL.MMMConfig.Model.MHBBase) //在24小时内付款  20%利息
            //    {
            //        offer.TotalInterest += (BLL.MMMConfig.Model.InterestPer * match.MatchMoney);
            //    }
            //    else//在12小时内付款小于2w的单30%利息，大于2W是25%
            //    {
            //        Model.ConfigDictionary diclxfloat = DAL.ConfigDictionary.GetConfigDictionary(Convert.ToInt32(offer.SQMoney), "OfferLX", "");
            //        if (diclxfloat != null)
            //        {
            //            offer.TotalInterest += match.MatchMoney * Convert.ToDecimal(diclxfloat.DValue);
            //        }
            //    }
            //}
            //else {//抢单区固定利息20%
            //    offer.TotalInterest += (BLL.MMMConfig.Model.MCWPrice * match.MatchMoney);
            //}

            #endregion

            int count = Convert.ToInt32(BLL.CommonBase.GetSingle("select COUNT(*) from MOfferHelp where SQMID='" + offer.SQMID + "' and SQCode!='" + offer.SQCode + "' and PPState<>5;"));
            if (count <= 0)
            {
                int addzc = BLL.MMMConfig.Model.HonestTimes;
                Model.Member mtj = BLL.Member.GetModelByMID( offModel.MTJ);
                if ((mtj.MConfig.EPXingCount + BLL.MMMConfig.Model.HonestTimes) > 100)
                {
                    addzc = 100 - mtj.MConfig.EPXingCount;
                }
                MyHs.Add("update MemberConfig set EPXingCount=EPXingCount+"+30+" where mid='"+mtj.MID+"';", null);
            }

            //更新提供帮助
            BLL.MOfferHelp.Update(offer, MyHs);

            //获得帮助最后一个匹配项完了
            if (BLL.MHelpMatch.GetList("MatchState in(1,2) and MatchCode<>'" + match.MatchCode + "' and GetId=" + match.GetId).Count <= 0)
            {
                Model.MGetHelp get = BLL.MGetHelp.GetModel(match.GetId);
                if (get != null && get.Money == 0)
                {
                    get.PPState = 3;
                    get.ConfirmState = 3;
                    get.ComfirmDate = DateTime.Now;
                    BLL.MGetHelp.Update(get, MyHs);
                }
            }

            return "";
        }

        # endregion 定时触发

        public static decimal GetSumMoney(string strWhere)
        {
            return DAL.MHelpMatch.GetSumMoney(strWhere);
        }
    }
}
