using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace WE_Project.BLL
{
    public class Contents
    {
        public static List<Model.Contents> List
        {
            get
            {
                return DAL.Contents.List;
            }
            set
            {
                DAL.Contents.List = value;
            }
        }

        public static bool Insert(Model.Contents model)
        {
            return DAL.Contents.Insert(model);
        }

        public static bool Update(Model.Contents model)
        {
            return DAL.Contents.Update(model);
        }

        public static bool Delete(string idlist)
        {
            return DAL.Contents.Delete(idlist);
        }

        public static Model.Contents GetModel(string cid)
        {
            return DAL.Contents.GetModel(cid);
        }

        /// <summary>
        /// 得到权限资源实体列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static List<Model.Contents> GetList(string strWhere)
        {
            return DAL.Contents.GetList(strWhere);
        }
        public static List<Model.Contents> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.Contents.GetList(strWhere, pageIndex, pageSize, out count);
        }

        public static bool SaveOrUpdate(Model.Contents obj,bool isSave)
        {
            bool result = false;
            if (isSave) //需要插入的
            {
                result = DAL.Contents.Insert(obj);
            }
            else
            {
                //需要更新的
                result = DAL.Contents.Update(obj);
            }

            return result;
        }

        public static string GetNewCid(string cfid)
        {
            string result = "";
            string strSql = "select MAX(CID) from Contents where CFID='" + cfid + "'";
            if (cfid == "0")
            {
                strSql = "select MAX(CID) from Contents where CFID='0'";
            }
            object obj = DAL.CommonBase.GetSingle(strSql);
            if (obj != null)
            {
                string str = obj.ToString();
                if (!string.IsNullOrEmpty(str))
                {
                    string code = str.Substring(cfid.Length);
                    if (cfid == "0")
                        result = (int.Parse(code) + 1).ToString();
                    else
                        result = cfid + (int.Parse(code) + 1).ToString();
                }
                else
                {
                    result = cfid + "001";
                }
            }
            else
                result = cfid + "001";
            return result;
        }

    }
}
