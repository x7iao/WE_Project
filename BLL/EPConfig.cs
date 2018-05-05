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
    //EPConfig
    public class EPConfig
    {
        public static Model.EPConfig EPConfigModel
        {
            get
            {
                return DAL.EPConfig.EPConfigModel;
            }
            set
            {
                DAL.EPConfig.EPConfigModel = value;
            }
        }
        public static WE_Project.Model.EPConfig GetModel()
        {
            return WE_Project.DAL.EPConfig.GetModel();
        }

        public static Hashtable Insert(WE_Project.Model.EPConfig model, Hashtable MyHs)
        {
            return WE_Project.DAL.EPConfig.Insert(model, MyHs);
        }

        public static bool Insert(WE_Project.Model.EPConfig model)
        {
            return WE_Project.DAL.EPConfig.Insert(model);
        }

        public static Hashtable Update(WE_Project.Model.EPConfig model, Hashtable MyHs)
        {
            return WE_Project.DAL.EPConfig.Update(model, MyHs);
        }

        public static bool Update(WE_Project.Model.EPConfig model)
        {
            return WE_Project.DAL.EPConfig.Update(model);
        }

        public static Hashtable Delete(object obj, Hashtable MyHs)
        {
            return WE_Project.DAL.EPConfig.Delete(obj, MyHs);
        }

        public static bool Delete(object obj)
        {
            return WE_Project.DAL.EPConfig.Delete(obj);
        }

        public static DataTable GetTable(string strWhere)
        {
            return WE_Project.DAL.EPConfig.GetTable(strWhere);
        }

        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.EPConfig.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public static List<WE_Project.Model.EPConfig> GetList(string strWhere)
        {
            return WE_Project.DAL.EPConfig.GetList(strWhere);
        }

        public static List<WE_Project.Model.EPConfig> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.EPConfig.GetList(strWhere, pageIndex, pageSize, out count);
        }
    }
}
