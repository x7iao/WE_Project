using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace WE_Project.BLL
{
    public class BuyActiveCode
    {
        public static Model.BuyActiveCode GetModel(object obj)
        {
            return WE_Project.DAL.BuyActiveCode.GetModel(obj);
        }

        public static Hashtable Insert(Model.BuyActiveCode model, Hashtable MyHs)
        {
            return WE_Project.DAL.BuyActiveCode.Insert(model, MyHs);
        }

        public static bool Insert(Model.BuyActiveCode model)
        {
            return WE_Project.DAL.BuyActiveCode.Insert(model);
        }

        public static Hashtable Update(Model.BuyActiveCode model, Hashtable MyHs)
        {
            return WE_Project.DAL.BuyActiveCode.Update(model, MyHs);
        }

        public static bool Update(Model.BuyActiveCode model)
        {
            return WE_Project.DAL.BuyActiveCode.Update(model);
        }

        public static Hashtable Delete(object obj, Hashtable MyHs)
        {
            return WE_Project.DAL.BuyActiveCode.Delete(obj, MyHs);
        }

        public static bool Delete(object obj)
        {
            return WE_Project.DAL.BuyActiveCode.Delete(obj);
        }

        public static DataTable GetTable(string strWhere)
        {
            return WE_Project.DAL.BuyActiveCode.GetTable(strWhere);
        }

        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.BuyActiveCode.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public static List<Model.BuyActiveCode> GetList(string strWhere)
        {
            return WE_Project.DAL.BuyActiveCode.GetList(strWhere);
        }

        public static List<Model.BuyActiveCode> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.BuyActiveCode.GetList(strWhere, pageIndex, pageSize, out count);
        }
    }
}
