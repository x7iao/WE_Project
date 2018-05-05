using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Collections;
using System.Data;

namespace WE_Project.BLL
{
    //EPList
    public class EPList
    {
        public static WE_Project.Model.EPList GetModel(object obj)
        {
            return WE_Project.DAL.EPList.GetModel(obj);
        }

        public static Hashtable Insert(WE_Project.Model.EPList model, Hashtable MyHs)
        {
            return WE_Project.DAL.EPList.Insert(model, MyHs);
        }

        public static string Insert(WE_Project.Model.EPList model)
        {
            Model.Member member = DAL.Member.GetModel(model.SellMID);
            if (model.Money > member.MConfig.MJJ)
            {
                return "您当前的EP币余额不足";
            }
            if (DAL.EPList.Insert(model))
            {
                return "挂卖成功";
            }
            else
            {
                return "挂卖失败";
            }
        }

        public static Hashtable Update(WE_Project.Model.EPList model, Hashtable MyHs)
        {
            return WE_Project.DAL.EPList.Update(model, MyHs);
        }

        public static bool Update(WE_Project.Model.EPList model)
        {
            return WE_Project.DAL.EPList.Update(model);
        }

        public static Hashtable Delete(object obj, Hashtable MyHs)
        {
            return WE_Project.DAL.EPList.Delete(obj, MyHs);
        }

        public static bool Delete(object obj)
        {
            return WE_Project.DAL.EPList.Delete(obj);
        }

        public static DataTable GetTable(string strWhere)
        {
            return WE_Project.DAL.EPList.GetTable(strWhere);
        }

        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.EPList.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public static List<WE_Project.Model.EPList> GetList(string strWhere)
        {
            return WE_Project.DAL.EPList.GetList(strWhere);
        }
        public static List<WE_Project.Model.EPList> GetTopList(int top, string strWhere,string OrderBy)
        {
            return WE_Project.DAL.EPList.GetTopList(top, strWhere, OrderBy);
        }

        public static List<WE_Project.Model.EPList> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.EPList.GetList(strWhere, pageIndex, pageSize, out count);
        }

        # region add

        /// <summary>
        /// 买方点击购买
        /// </summary>
        public static string EPbuy(string epid, string userid)
        {
            string result = "";

            Model.EPList eplist = GetModel(epid);
            Model.Member mermber = DAL.Member.GetModel(userid);
            //if (mermber.MConfig.MJJ > eplist.Money)
            {
                eplist.SellState = 1;
                eplist.BuyMID = userid;
                eplist.BuyDate = DateTime.Now;
                Hashtable MyHs = new Hashtable();
                //DAL.MemberConfig.UpdateConfigTran(userid, "MHB", (-eplist.Money).ToString(), null, false, SqlDbType.Int, MyHs);
                Update(eplist, MyHs);
                if (DAL.CommonBase.RunHashtable(MyHs))
                {
                    result = "记录锁定成功，请联系卖方进行支付，请在三个小时之内确认付款或收款！";
                }
                else
                {
                    result = "购买失败";
                }
            }

            return result;
        }

        /// <summary>
        /// 买方取消购买
        /// </summary>
        public static string EPcancel(string epid)
        {
            string result = "";

            Model.EPList eplist = GetModel(epid);
            Hashtable MyHs = new Hashtable();
            //返还手续费
            DAL.MemberConfig.UpdateConfigTran(eplist.SellMID, "MHB", eplist.TakeOffMoney.ToString(), null, false, SqlDbType.Int, MyHs);
            eplist.SellState = 0;
            eplist.TakeOffMoney = 0;
            eplist.BuyMID = "";
            eplist.BuyDate = null;
            eplist.LastSellDate = null;
            eplist.LastBuyDate = null;
            Update(eplist, MyHs);

            if (DAL.CommonBase.RunHashtable(MyHs))
            {
                result = "取消成功";
            }
            else
            {
                result = "取消失败";
            }

            return result;
        }


        /// <summary>
        /// 买方确认付款
        /// </summary>
        public static string EPpay(string epid)
        {
            string result = "";
            Model.EPList eplist = GetModel(epid);
            eplist.SellState = 2;
            eplist.LastBuyDate = DateTime.Now;
            if (Update(eplist))
            {
                result = "确认付款成功";
            }
            else
            {
                result = "确认付款失败";
            }

            return result;
        }


        /// <summary>
        /// 卖方确认收款
        /// </summary>
        public static string EPsellLast(string epid)
        {
            string result = "";
            Model.EPList eplist = GetModel(epid);
            Hashtable MyHs = new Hashtable();
            DAL.MemberConfig.UpdateConfigTran(eplist.BuyMID, eplist.MoneyType, eplist.Money.ToString(), null, false, SqlDbType.Int, MyHs);
            eplist.SellState = 3;
            eplist.LastSellDate = DateTime.Now;
            Update(eplist, MyHs);
            if (DAL.CommonBase.RunHashtable(MyHs))
            {
                result = "确认收款成功";
            }
            else
            {
                result = "确认收款失败";
            }
            return result;
        }

        /// <summary>
        /// 卖方取消挂卖
        /// </summary>
        public static string EPDelete(string epid)
        {
            string result = "";
            Model.EPList eplist = GetModel(epid);
            Hashtable MyHs = new Hashtable();
            DAL.MemberConfig.UpdateConfigTran(eplist.SellMID, eplist.MoneyType, eplist.Money.ToString(), null, false, SqlDbType.Int, MyHs);
            Delete(epid, MyHs);
            if (DAL.CommonBase.RunHashtable(MyHs))
            {
                result = "取消成功";
            }
            else
            {
                result = "取消失败";
            }
            return result;
        }

        /// <summary>
        /// 卖方关闭交易
        /// </summary>
        public static string EPClose(string epid)
        {
            string result = "";
            Model.EPList eplist = GetModel(epid);
            Hashtable MyHs = new Hashtable();
            //连同手续费一起返还
            DAL.MemberConfig.UpdateConfigTran(eplist.SellMID, "MHB", (eplist.Money + BLL.EPConfig.EPConfigModel.EPTakeOffMoney).ToString(), null, false, SqlDbType.Int, MyHs);
            eplist.SellState = 4;
            eplist.LastSellDate = DateTime.Now;
            Update(eplist, MyHs);
            if (DAL.CommonBase.RunHashtable(MyHs))
            {
                result = "关闭成功";
            }
            else
            {
                result = "关闭失败";
            }
            return result;
        }

        public bool isTradeTime()
        {
            DateTime startTime = BLL.EPConfig.EPConfigModel.EPStartTime;//获取开始时间
            DateTime endTime = BLL.EPConfig.EPConfigModel.EPEndTime;//获取结束时间
            DateTime current = DateTime.Now;//当前时间
            //DateTime start = new DateTime(current.Year, current.Month, current.Day, startTime.Hour, startTime.Minute, startTime.Second);
            //DateTime end = new DateTime(current.Year, current.Month, current.Day, endTime.Hour, endTime.Minute, endTime.Second);

            //if (current >= start && current <= end)
            if ((DateTime.Now.TimeOfDay - BLL.EPConfig.EPConfigModel.EPStartTime.TimeOfDay).TotalSeconds > 0 && (DateTime.Now.TimeOfDay - BLL.EPConfig.EPConfigModel.EPEndTime.TimeOfDay).TotalSeconds < 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        # endregion
    }
}
