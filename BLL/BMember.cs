using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace WE_Project.BLL
{
    public class BMember
    {
        private static object obj = new Random().Next(1, 100);
        public static WE_Project.Model.BMember GetModel(string obj)
        {
            return WE_Project.DAL.BMember.GetModel(obj);
        }
        public static WE_Project.Model.BMember GetModelByID(object obj)
        {
            return WE_Project.DAL.BMember.GetModelByID(obj);
        }

        public static System.Collections.Hashtable Insert(WE_Project.Model.BMember model, System.Collections.Hashtable MyHs)
        {

            return WE_Project.DAL.BMember.Insert(model, MyHs);
        }

        public static bool Insert(WE_Project.Model.BMember model)
        {
            //lock (obj)
            {
                Hashtable MyHs = new Hashtable();
                Insert(model, MyHs);
                BLL.ChangeMoney.HBChangeTran(model.BCount, model.AMID, BLL.Member.ManageMember.TModel.MID, "FT", null, "MHB", "", MyHs);
                if (BLL.CommonBase.RunHashtable(MyHs))
                    return true;
                return false;
            }
        }

        private static string GetBMBD(string mid, int count)
        {
            return DAL.BMember.GetBMBD(mid, count);
        }

        public static System.Collections.Hashtable Update(WE_Project.Model.BMember model, System.Collections.Hashtable MyHs)
        {
            return WE_Project.DAL.BMember.Update(model, MyHs);
        }

        public static bool Update(WE_Project.Model.BMember model)
        {
            return WE_Project.DAL.BMember.Update(model);
        }

        public static System.Collections.Hashtable Delete(object obj, System.Collections.Hashtable MyHs)
        {
            return WE_Project.DAL.BMember.Delete(obj, MyHs);
        }

        public static bool Delete(object obj)
        {
            return WE_Project.DAL.BMember.Delete(obj);
        }

        public static System.Data.DataTable GetTable(string strWhere)
        {
            return WE_Project.DAL.BMember.GetTable(strWhere);
        }

        public static System.Data.DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.BMember.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public static List<WE_Project.Model.BMember> GetList(string strWhere)
        {
            return WE_Project.DAL.BMember.GetList(strWhere);
        }
        public static List<WE_Project.Model.BMember> GetList(int top, string strWhere)
        {
            return WE_Project.DAL.BMember.GetList(top, strWhere);
        }

        public static List<WE_Project.Model.BMember> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.BMember.GetList(strWhere, pageIndex, pageSize, out count, "BMID DESC");
        }

        public static string GetBMID(Model.Member model)
        {
            return WE_Project.DAL.BMember.GetBMID(model);
        }
        public static DataTable GetIndexCharData(string beginDate, string endDate)
        {
            return WE_Project.DAL.BMember.GetIndexCharData(beginDate, endDate);
        }

        /// <summary>
        /// 得到分页会员信息实体列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="count">out类型总计</param>
        /// <returns>返回会员List集合</returns>
        public static List<Model.BMember> GetMoneyEntityList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.BMember> LuckyMoneyList = new List<Model.BMember>();

            DataTable table = DAL.BMember.GetTable(strWhere, pageIndex, pageSize, out count);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                LuckyMoneyList.Add(DAL.BMember.DataRowToModel(table.Rows[i]));
            }

            return LuckyMoneyList;
        }

        public static decimal GetSumMoney(string mid)
        {
            return DAL.BMember.GetSumMoney(mid, "BCount");
        }
    }
}
