using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace WE_Project.BLL
{
    //IPClick
    public  class IPClick
    {
        public static Model.IPClick GetModel(object obj)
        {
            return WE_Project.DAL.IPClick.GetModel(obj);
        }

        public static Hashtable Insert(Model.IPClick model, Hashtable MyHs)
        {
            return WE_Project.DAL.IPClick.Insert(model, MyHs);
        }

        public static bool Insert(Model.IPClick model)
        {
            return WE_Project.DAL.IPClick.Insert(model);
        }

        public static Hashtable Update(Model.IPClick model, Hashtable MyHs)
        {
            return WE_Project.DAL.IPClick.Update(model, MyHs);
        }

        public static bool Update(Model.IPClick model)
        {
            return WE_Project.DAL.IPClick.Update(model);
        }

        public static Hashtable Delete(object obj, Hashtable MyHs)
        {
            return WE_Project.DAL.IPClick.Delete(obj, MyHs);
        }

        public static bool Delete(object obj)
        {
            return WE_Project.DAL.IPClick.Delete(obj);
        }

        public static DataTable GetTable(string strWhere)
        {
            return WE_Project.DAL.IPClick.GetTable(strWhere);
        }

        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.IPClick.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public static List<Model.IPClick> GetList(string strWhere)
        {
            return WE_Project.DAL.IPClick.GetList(strWhere);
        }

        public static List<Model.IPClick> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.IPClick.GetList(strWhere, pageIndex, pageSize, out count);
        }
    }
}
