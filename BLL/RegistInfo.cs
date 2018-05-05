using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace WE_Project.BLL
{
    //RegistInfo
    public class RegistInfo
    {
        public static Model.RegistInfo GetModel(object obj)
        {
            return WE_Project.DAL.RegistInfo.GetModel(obj);
        }

        public static Hashtable Insert(Model.RegistInfo model, Hashtable MyHs)
        {
            return WE_Project.DAL.RegistInfo.Insert(model, MyHs);
        }

        public static bool Insert(Model.RegistInfo model)
        {
            return WE_Project.DAL.RegistInfo.Insert(model);
        }

        public static Hashtable Update(Model.RegistInfo model, Hashtable MyHs)
        {
            return WE_Project.DAL.RegistInfo.Update(model, MyHs);
        }

        public static bool Update(Model.RegistInfo model)
        {
            return WE_Project.DAL.RegistInfo.Update(model);
        }

        public static Hashtable Delete(object obj, Hashtable MyHs)
        {
            return WE_Project.DAL.RegistInfo.Delete(obj, MyHs);
        }

        public static bool Delete(object obj)
        {
            return WE_Project.DAL.RegistInfo.Delete(obj);
        }

        public static DataTable GetTable(string strWhere)
        {
            return WE_Project.DAL.RegistInfo.GetTable(strWhere);
        }

        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.RegistInfo.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public static List<Model.RegistInfo> GetList(string strWhere)
        {
            return WE_Project.DAL.RegistInfo.GetList(strWhere);
        }

        public static List<Model.RegistInfo> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.RegistInfo.GetList(strWhere, pageIndex, pageSize, out count);
        }
    }
}
