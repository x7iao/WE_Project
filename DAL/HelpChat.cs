/**  版本信息模板在安装目录下，可自行修改。
* HelpChat.cs
*
* 功 能： N/A
* 类 名： HelpChat
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/4/18 11:01:37   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using DBUtility;//Please add references
namespace WE_Project.DAL
{
    /// <summary>
    /// 数据访问类:HelpChat
    /// </summary>
    public partial class HelpChat
    {
        public HelpChat()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ID", "HelpChat");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from HelpChat");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(WE_Project.Model.HelpChat model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into HelpChat(");
            strSql.Append("MatchCode,SendMID,SendName,TContent,SendTime,SendType,SendImages)");
            strSql.Append(" values (");
            strSql.Append("@MatchCode,@SendMID,@SendName,@TContent,@SendTime,@SendType,@SendImages)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@MatchCode", SqlDbType.VarChar,50),
					new SqlParameter("@SendMID", SqlDbType.VarChar,20),
					new SqlParameter("@SendName", SqlDbType.NVarChar,10),
					new SqlParameter("@TContent", SqlDbType.NVarChar,500),
					new SqlParameter("@SendTime", SqlDbType.DateTime),
					new SqlParameter("@SendType", SqlDbType.Int,4),
					new SqlParameter("@SendImages", SqlDbType.Text)};
            parameters[0].Value = model.MatchCode;
            parameters[1].Value = model.SendMID;
            parameters[2].Value = model.SendName;
            parameters[3].Value = model.TContent;
            parameters[4].Value = model.SendTime;
            parameters[5].Value = model.SendType;
            parameters[6].Value = model.SendImages;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(WE_Project.Model.HelpChat model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update HelpChat set ");
            strSql.Append("MatchCode=@MatchCode,");
            strSql.Append("SendMID=@SendMID,");
            strSql.Append("SendName=@SendName,");
            strSql.Append("TContent=@TContent,");
            strSql.Append("SendTime=@SendTime,");
            strSql.Append("SendType=@SendType,");
            strSql.Append("SendImages=@SendImages");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@MatchCode", SqlDbType.VarChar,50),
					new SqlParameter("@SendMID", SqlDbType.VarChar,20),
					new SqlParameter("@SendName", SqlDbType.NVarChar,10),
					new SqlParameter("@TContent", SqlDbType.NVarChar,500),
					new SqlParameter("@SendTime", SqlDbType.DateTime),
					new SqlParameter("@SendType", SqlDbType.Int,4),
					new SqlParameter("@SendImages", SqlDbType.Text),
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = model.MatchCode;
            parameters[1].Value = model.SendMID;
            parameters[2].Value = model.SendName;
            parameters[3].Value = model.TContent;
            parameters[4].Value = model.SendTime;
            parameters[5].Value = model.SendType;
            parameters[6].Value = model.SendImages;
            parameters[7].Value = model.ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from HelpChat ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string IDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from HelpChat ");
            strSql.Append(" where ID in (" + IDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WE_Project.Model.HelpChat GetModel(int ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,MatchCode,SendMID,SendName,TContent,SendTime,SendType,SendImages from HelpChat ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)
			};
            parameters[0].Value = ID;

            WE_Project.Model.HelpChat model = new WE_Project.Model.HelpChat();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public WE_Project.Model.HelpChat DataRowToModel(DataRow row)
        {
            WE_Project.Model.HelpChat model = new WE_Project.Model.HelpChat();
            if (row != null)
            {
                if (row["ID"] != null && row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                if (row["MatchCode"] != null)
                {
                    model.MatchCode = row["MatchCode"].ToString();
                }
                if (row["SendMID"] != null)
                {
                    model.SendMID = row["SendMID"].ToString();
                }
                if (row["SendName"] != null)
                {
                    model.SendName = row["SendName"].ToString();
                }
                if (row["TContent"] != null)
                {
                    model.TContent = row["TContent"].ToString();
                }
                if (row["SendTime"] != null && row["SendTime"].ToString() != "")
                {
                    model.SendTime = DateTime.Parse(row["SendTime"].ToString());
                }
                if (row["SendType"] != null && row["SendType"].ToString() != "")
                {
                    model.SendType = int.Parse(row["SendType"].ToString());
                }
                if (row["SendImages"] != null)
                {
                    model.SendImages = row["SendImages"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,MatchCode,SendMID,SendName,TContent,SendTime,SendType,SendImages ");
            strSql.Append(" FROM HelpChat ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" ID,MatchCode,SendMID,SendName,TContent,SendTime,SendType,SendImages ");
            strSql.Append(" FROM HelpChat ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM HelpChat ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.ID desc");
            }
            strSql.Append(")AS Row, T.*  from HelpChat T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(int PageSize,int PageIndex,string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "HelpChat";
            parameters[1].Value = "ID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;	
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
        }*/

        #endregion  BasicMethod
        #region  ExtensionMethod

        #endregion  ExtensionMethod
    }
}

