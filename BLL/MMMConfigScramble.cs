/**  版本信息模板在安装目录下，可自行修改。
* MMMConfigScrambleScramble.cs
*
* 功 能： N/A
* 类 名： MMMConfigScrambleScramble
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/22 17:06:43   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System.Collections;
using System.Collections.Generic;
using System.Data;
namespace WE_Project.BLL
{
    /// <summary>
    /// MMMConfigScrambleScramble
    /// </summary>
    public partial class MMMConfigScramble
    {
        public static Model.MMMConfigScramble Model
        {
            get
            {
                return DAL.MMMConfigScramble.TModel;
            }
            set
            {
                DAL.MMMConfigScramble.TModel = value;
            }
        }

        public static Model.MMMConfigScramble GetModel()
        {
            return WE_Project.DAL.MMMConfigScramble.GetModel();
        }

        public static Hashtable Insert(Model.MMMConfigScramble model, Hashtable MyHs)
        {
            return WE_Project.DAL.MMMConfigScramble.Insert(model, MyHs);
        }

        public static bool Insert(Model.MMMConfigScramble model)
        {
            return WE_Project.DAL.MMMConfigScramble.Insert(model);
        }

        public static Hashtable Update(Model.MMMConfigScramble model, Hashtable MyHs)
        {
            return WE_Project.DAL.MMMConfigScramble.Update(model, MyHs);
        }

        public static bool Update(Model.MMMConfigScramble model)
        {
            return WE_Project.DAL.MMMConfigScramble.Update(model);
        }

        public static Hashtable Delete(object obj, Hashtable MyHs)
        {
            return WE_Project.DAL.MMMConfigScramble.Delete(obj, MyHs);
        }

        public static bool Delete(object obj)
        {
            return WE_Project.DAL.MMMConfigScramble.Delete(obj);
        }

        public static DataTable GetTable(string strWhere)
        {
            return WE_Project.DAL.MMMConfigScramble.GetTable(strWhere);
        }

        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.MMMConfigScramble.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public static List<Model.MMMConfigScramble> GetList(string strWhere)
        {
            return WE_Project.DAL.MMMConfigScramble.GetList(strWhere);
        }

        public static List<Model.MMMConfigScramble> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.MMMConfigScramble.GetList(strWhere, pageIndex, pageSize, out count);
        }
    }
}

