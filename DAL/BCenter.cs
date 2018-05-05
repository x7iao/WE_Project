using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using DBUtility;

namespace WE_Project.DAL
{
    public class BCenter
    {
        public static Hashtable Insert(Model.BCenter model, Hashtable MyHs)
        {
            StringBuilder sb = new StringBuilder("insert into BCenter (MID,MName,Des,AddDate,Flag) ");
            sb.Append("values");
            sb.Append("(@MID,@MName,@Des,@AddDate,@Flag)");
            SqlParameter[] parameters = {
			        new SqlParameter("@MID",SqlDbType.VarChar,20),
                    new SqlParameter("@MName",SqlDbType.VarChar,10),
                    new SqlParameter("@Des",SqlDbType.VarChar,50),
                    new SqlParameter("@AddDate",SqlDbType.DateTime,8),
                    new SqlParameter("@Flag",SqlDbType.VarChar,10)
                    };
            parameters[0].Value = model.MID;
            parameters[1].Value = model.MName;
            parameters[2].Value = model.Des;
            parameters[3].Value = model.AddDate;
            parameters[4].Value = model.Flag;
            
            MyHs.Add(sb.ToString(), parameters);
            return MyHs;
        }

        public static List<Model.BCenter> GetList(string strWhere)
        {
            StringBuilder sb = new StringBuilder("select * from BCenter ");
            if (!string.IsNullOrEmpty(strWhere))
                sb.AppendFormat("where " + strWhere);
            List<Model.BCenter> list = new List<Model.BCenter>();
            DataTable table = table = DbHelperSQL.Query(sb.ToString()).Tables[0];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(TranEntity(table.Rows[i]));
            }

            return list;
        }
        private static Model.BCenter TranEntity(DataRow dr)
        {
            Model.BCenter model = new Model.BCenter();
            if (!string.IsNullOrEmpty(dr["MID"].ToString()))
            {
                model.MID = dr["MID"].ToString();
            }
            if (!string.IsNullOrEmpty(dr["MName"].ToString()))
            {
                model.MName = dr["MName"].ToString();
            }
            if (!string.IsNullOrEmpty(dr["Des"].ToString()))
            {
                model.Des = dr["Des"].ToString();
            }
            if (!string.IsNullOrEmpty(dr["AddDate"].ToString()))
            {
                model.AddDate = DateTime.Parse(dr["AddDate"].ToString());
            }
          
            if (!string.IsNullOrEmpty(dr["Flag"].ToString()))
            {
                model.Flag = dr["Flag"].ToString();
            }
            return model;
        }

        /// <summary>
        /// 得到分页会员信息实体列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="count">out类型总计</param>
        /// <returns>返回会员List集合</returns>
        public static List<Model.BCenter> GetBCenterEntityList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.BCenter> BCenterList = new List<Model.BCenter>();

            DataTable table = GetTable(strWhere, pageIndex, pageSize, out count);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                BCenterList.Add(DAL.BCenter.TranEntity(table.Rows[i]));
            }

            return BCenterList;
        }
        /// <summary>
        /// 得到分页会员信息数据
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="count">out类型总计</param>
        /// <returns>返回DataTable</returns>
        private static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return CommonBase.GetTable("BCenter", "MID", "AddDate asc,MID asc", strWhere, pageIndex, pageSize, out count);
        }

        public static bool SHBCenter(string mid)
        {
            return DbHelperSQL.ExecuteSql(string.Format("Update BCenter set Flag='{0}' where MID='{1}'", "1", mid)) > 0;

        }
        public static string DeleteBCenter(string midlist)
        {
            string[] arr=midlist.Split(',');
            int succ = 0;
            int erro=0;
            foreach (string mid in arr)
            {
                if (DbHelperSQL.ExecuteSql(string.Format("delete from BCenter where Flag='{0}' and  MID='{1}'", "0", mid)) > 0)
                {
                    succ++;
                }
                else
                {
                    erro++;
                }
            }
            return "成功："+succ.ToString()+" , 失败："+erro.ToString();
        }
    }
}
