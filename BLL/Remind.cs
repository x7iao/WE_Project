using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace WE_Project.BLL
{
    //Remind
    public class Remind
    {
        public static Model.Remind GetModel(object obj)
        {
            return WE_Project.DAL.Remind.GetModel(obj);
        }

        public static Hashtable Insert(Model.Remind model, Hashtable MyHs)
        {
            return WE_Project.DAL.Remind.Insert(model, MyHs);
        }

        public static bool Insert(Model.Remind model)
        {
            return WE_Project.DAL.Remind.Insert(model);
        }

        public static Hashtable Update(Model.Remind model, Hashtable MyHs)
        {
            return WE_Project.DAL.Remind.Update(model, MyHs);
        }

        public static bool Update(Model.Remind model)
        {
            return WE_Project.DAL.Remind.Update(model);
        }

        public static Hashtable Delete(object obj, Hashtable MyHs)
        {
            return WE_Project.DAL.Remind.Delete(obj, MyHs);
        }

        public static bool Delete(object obj)
        {
            return WE_Project.DAL.Remind.Delete(obj);
        }

        public static DataTable GetTable(string strWhere)
        {
            return WE_Project.DAL.Remind.GetTable(strWhere);
        }

        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.Remind.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public static List<Model.Remind> GetList(string strWhere)
        {
            return WE_Project.DAL.Remind.GetList(strWhere);
        }

        public static List<Model.Remind> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.Remind.GetList(strWhere, pageIndex, pageSize, out count);
        }
    }
}
