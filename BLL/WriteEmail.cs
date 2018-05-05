using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace WE_Project.BLL
{
    //WriteEmail
    public class WriteEmail
    {
        public static Model.WriteEmail GetModel(object obj)
        {
            return WE_Project.DAL.WriteEmail.GetModel(obj);
        }

        public static Hashtable Insert(Model.WriteEmail model, Hashtable MyHs)
        {
            return WE_Project.DAL.WriteEmail.Insert(model, MyHs);
        }

        public static bool Insert(Model.WriteEmail model)
        {
            return WE_Project.DAL.WriteEmail.Insert(model);
        }

        public static Hashtable Update(Model.WriteEmail model, Hashtable MyHs)
        {
            return WE_Project.DAL.WriteEmail.Update(model, MyHs);
        }

        public static bool Update(Model.WriteEmail model)
        {
            return WE_Project.DAL.WriteEmail.Update(model);
        }

        public static Hashtable Delete(object obj, Hashtable MyHs)
        {
            return WE_Project.DAL.WriteEmail.Delete(obj, MyHs);
        }

        public static bool Delete(object obj)
        {
            return WE_Project.DAL.WriteEmail.Delete(obj);
        }

        public static DataTable GetTable(string strWhere)
        {
            return WE_Project.DAL.WriteEmail.GetTable(strWhere);
        }

        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.WriteEmail.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public static List<Model.WriteEmail> GetList(string strWhere)
        {
            return WE_Project.DAL.WriteEmail.GetList(strWhere);
        }
        public static List<Model.WriteEmail> GetList(int top, string strWhere)
        {
            return WE_Project.DAL.WriteEmail.GetList(top, strWhere);
        }

        public static List<Model.WriteEmail> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.WriteEmail.GetList(strWhere, pageIndex, pageSize, out count);
        }
    }
}