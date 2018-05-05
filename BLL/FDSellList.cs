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
    //FDSellList
    public class FDSellList
    {
        public static WE_Project.Model.FDSellList GetModel(object obj)
        {
            return WE_Project.DAL.FDSellList.GetModel(obj);
        }

        public static Hashtable Insert(WE_Project.Model.FDSellList model, Hashtable MyHs)
        {
            return WE_Project.DAL.FDSellList.Insert(model, MyHs);
        }

        public static bool Insert(WE_Project.Model.FDSellList model)
        {
            return WE_Project.DAL.FDSellList.Insert(model);
        }

        public static Hashtable Update(WE_Project.Model.FDSellList model, Hashtable MyHs)
        {
            return WE_Project.DAL.FDSellList.Update(model, MyHs);
        }

        public static bool Update(WE_Project.Model.FDSellList model)
        {
            return WE_Project.DAL.FDSellList.Update(model);
        }

        public static Hashtable Delete(object obj, Hashtable MyHs)
        {
            return WE_Project.DAL.FDSellList.Delete(obj, MyHs);
        }

        public static bool Delete(object obj)
        {
            return WE_Project.DAL.FDSellList.Delete(obj);
        }

        public static DataTable GetTable(string strWhere)
        {
            return WE_Project.DAL.FDSellList.GetTable(strWhere);
        }

        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.FDSellList.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public static List<WE_Project.Model.FDSellList> GetList(string strWhere)
        {
            return WE_Project.DAL.FDSellList.GetList(strWhere);
        }
        public static List<WE_Project.Model.FDSellList> GetList(int top, string strWhere)
        {
            return WE_Project.DAL.FDSellList.GetList(top, strWhere);
        }

        public static List<WE_Project.Model.FDSellList> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.FDSellList.GetList(strWhere, pageIndex, pageSize, out count);
        }
    }
}
