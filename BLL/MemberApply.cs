using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace WE_Project.BLL
{
    //MemberApply
    public class MemberApply
    {
        public static Model.MemberApply GetModel(object obj)
        {
            return WE_Project.DAL.MemberApply.GetModel(obj);
        }

        public static Hashtable Insert(Model.MemberApply model, Hashtable MyHs)
        {
            return WE_Project.DAL.MemberApply.Insert(model, MyHs);
        }

        public static bool Insert(Model.MemberApply model)
        {
            return WE_Project.DAL.MemberApply.Insert(model);
        }

        public static Hashtable Update(Model.MemberApply model, Hashtable MyHs)
        {
            return WE_Project.DAL.MemberApply.Update(model, MyHs);
        }

        public static bool Update(Model.MemberApply model)
        {
            return WE_Project.DAL.MemberApply.Update(model);
        }

        public static Hashtable Delete(object obj, Hashtable MyHs)
        {
            return WE_Project.DAL.MemberApply.Delete(obj, MyHs);
        }

        public static bool Delete(object obj)
        {
            return WE_Project.DAL.MemberApply.Delete(obj);
        }

        public static string DeleteApply(string midlist)
        {
            return WE_Project.DAL.MemberApply.DeleteApply(midlist);
        }

        public static DataTable GetTable(string strWhere)
        {
            return WE_Project.DAL.MemberApply.GetTable(strWhere);
        }

        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.MemberApply.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public static List<Model.MemberApply> GetList(string strWhere)
        {
            return WE_Project.DAL.MemberApply.GetList(strWhere);
        }

        public static List<Model.MemberApply> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.MemberApply.GetList(strWhere, pageIndex, pageSize, out count);
        }

        public static Model.MemberApply CheckHasApplyed(string mid, int status, string ApplyType)
        {
            return BLL.MemberApply.GetList(string.Format(" MID='{0}' and State={1} and ApplyType='{2}'", mid, status, ApplyType)).FirstOrDefault();
        }

    }
}
