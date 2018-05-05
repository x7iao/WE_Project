using System.Collections;
using System.Collections.Generic;
using System.Data;

namespace WE_Project.BLL
{
    //MMMConfig
    public class MMMConfig
    {
        public static Model.MMMConfig Model
        {
            get
            {
                return DAL.MMMConfig.TModel;
            }
            set
            {
                DAL.MMMConfig.TModel = value;
            }
        }

        public static Model.MMMConfig GetModel()
        {
            return WE_Project.DAL.MMMConfig.GetModel();
        }

        public static Hashtable Insert(Model.MMMConfig model, Hashtable MyHs)
        {
            return WE_Project.DAL.MMMConfig.Insert(model, MyHs);
        }

        public static bool Insert(Model.MMMConfig model)
        {
            return WE_Project.DAL.MMMConfig.Insert(model);
        }

        public static Hashtable Update(Model.MMMConfig model, Hashtable MyHs)
        {
            return WE_Project.DAL.MMMConfig.Update(model, MyHs);
        }

        public static bool Update(Model.MMMConfig model)
        {
            return WE_Project.DAL.MMMConfig.Update(model);
        }

        public static Hashtable Delete(object obj, Hashtable MyHs)
        {
            return WE_Project.DAL.MMMConfig.Delete(obj, MyHs);
        }

        public static bool Delete(object obj)
        {
            return WE_Project.DAL.MMMConfig.Delete(obj);
        }

        public static DataTable GetTable(string strWhere)
        {
            return WE_Project.DAL.MMMConfig.GetTable(strWhere);
        }

        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.MMMConfig.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public static List<Model.MMMConfig> GetList(string strWhere)
        {
            return WE_Project.DAL.MMMConfig.GetList(strWhere);
        }

        public static List<Model.MMMConfig> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.MMMConfig.GetList(strWhere, pageIndex, pageSize, out count);
        }

        public static bool ResetMMM(Model.Member model)
        {
            return DAL.MMMConfig.ResetMMM(model);
        }
    }
}
