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
    //EPJX
    public class EPJX
    {
        public static WE_Project.Model.EPJX GetModel(object obj)
        {
            return WE_Project.DAL.EPJX.GetModel(obj);
        }

        public static Hashtable Insert(WE_Project.Model.EPJX model, Hashtable MyHs)
        {
            return WE_Project.DAL.EPJX.Insert(model, MyHs);
        }

        public static bool Insert(WE_Project.Model.EPJX model)
        {
            return WE_Project.DAL.EPJX.Insert(model);
        }

        public static Hashtable Update(WE_Project.Model.EPJX model, Hashtable MyHs)
        {
            return WE_Project.DAL.EPJX.Update(model, MyHs);
        }

        public static bool Update(WE_Project.Model.EPJX model)
        {
            return WE_Project.DAL.EPJX.Update(model);
        }

        public static Hashtable Delete(object obj, Hashtable MyHs)
        {
            return WE_Project.DAL.EPJX.Delete(obj, MyHs);
        }

        public static bool Delete(object obj)
        {
            return WE_Project.DAL.EPJX.Delete(obj);
        }

        public static DataTable GetTable(string strWhere)
        {
            return WE_Project.DAL.EPJX.GetTable(strWhere);
        }

        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.EPJX.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public static List<WE_Project.Model.EPJX> GetList(string strWhere)
        {
            return WE_Project.DAL.EPJX.GetList(strWhere);
        }

        public static List<WE_Project.Model.EPJX> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.EPJX.GetList(strWhere, pageIndex, pageSize, out count);
        }

        /// <summary>
        /// 检查超时
        /// </summary>
        /// <returns></returns>
        public bool CheckedTimeOut()
        {
            int time = BLL.EPConfig.EPConfigModel.EPTimeOut;
            List<Model.EPList> list = BLL.EPList.GetList(" SellState = 1");
            foreach (var model in list)
            {
                if (IfTimeOut(model.BuyDate.Value, DateTime.Now, time))
                {
                    //超时
                    BLL.EPList.EPcancel(model.EPID.ToString());
                    //清楚
                    DdeductionStar(model.BuyMID);
                }
            }
            List<Model.EPList> list1 = BLL.EPList.GetList(" SellState = 2");
            foreach (var model in list1)
            {
                if (IfTimeOut(model.BuyDate.Value, DateTime.Now, time))
                {
                    //超时
                    BLL.EPList.EPcancel(model.EPID.ToString());
                    //清楚
                    DdeductionStar(model.SellMID);
                }
            }

            return false;
        }

        private void DdeductionStar(string mid)
        {
            int toCount = BLL.EPConfig.EPConfigModel.EPTimeOutCount;
            int jxcount = BLL.EPConfig.EPConfigModel.EPTimeOutJXCount;
            Model.Member member = DAL.Member.GetModel(mid);
            member.MConfig.EPTimeOutCount++;
            Model.EPJX epjx = new Model.EPJX();
            epjx.EPJXMID = mid;
            epjx.EPJXTime = DateTime.Now;
            epjx.EPJXRemark = "您于" + epjx.EPJXTime + "超时交易，累计一次超时记录，请下次注意。";
            if (member.MConfig.EPTimeOutCount == toCount)
            {
                epjx.EPJXRemark = "您于" + epjx.EPJXTime + "累计超时交易" + toCount + "次，系统扣除您" + jxcount + "颗星。";
                member.MConfig.EPXingCount = member.MConfig.EPXingCount - jxcount;
                if (member.MConfig.EPXingCount < 0)
                {
                    member.MConfig.EPXingCount = 0;
                }
            }
            BLL.EPJX.Insert(epjx);
        }

        private bool IfTimeOut(DateTime start, DateTime end, int time)
        {
            DateTime startTemp = DateTime.Now;
            DateTime endtemp = startTemp.AddMinutes(time);
            TimeSpan tsTemp = endtemp - startTemp;//标准
            TimeSpan ts = end - start;//真实时间
            if (ts.Ticks > tsTemp.Ticks)
            {
                return true;
            }

            return false;
        }
    }
}
