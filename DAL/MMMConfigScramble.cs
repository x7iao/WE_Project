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
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using DBUtility;
namespace WE_Project.DAL
{
    /// <summary>
    /// 数据访问类:MMMConfigScrambleScramble
    /// </summary>
    public partial class MMMConfigScramble
    {
        public MMMConfigScramble()
        { }

        private static Model.MMMConfigScramble _model;
        public static Model.MMMConfigScramble TModel
        {
            get
            {
                if (_model == null)
                    _model = DAL.MMMConfigScramble.GetModel();
                return _model;
            }
            set
            {
                _model = value;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static Model.MMMConfigScramble GetModel()
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append("  from MMMConfigScramble ");
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), null);

            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return TranEntity(ds.Tables[0].Rows[0]);
            else
                return null;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static Hashtable Insert(Model.MMMConfigScramble model, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into MMMConfigScramble(");
            strSql.Append("PayLimitTimes,ConfirmLimitTimes,OpenTime,OpenSwitch,FreezeTimes,ScrambleReward,ScrambleLiXiDays,DisappearTimes)");
            strSql.Append(" values (");
            strSql.Append("@PayLimitTimes,@ConfirmLimitTimes,@OpenTime,@OpenSwitch,@FreezeTimes,@ScrambleReward,@ScrambleLiXiDays,@DisappearTimes)");
            SqlParameter[] parameters = {
					new SqlParameter("@PayLimitTimes", SqlDbType.Int,4),
					new SqlParameter("@ConfirmLimitTimes", SqlDbType.Int,4),
					new SqlParameter("@OpenTime", SqlDbType.VarChar,100),
					new SqlParameter("@OpenSwitch", SqlDbType.Bit,1),
					new SqlParameter("@FreezeTimes", SqlDbType.Int,4),
					new SqlParameter("@ScrambleReward", SqlDbType.Decimal,9),
					new SqlParameter("@ScrambleLiXiDays", SqlDbType.Int,4),
					new SqlParameter("@DisappearTimes", SqlDbType.Int,4)};
            parameters[0].Value = model.PayLimitTimes;
            parameters[1].Value = model.ConfirmLimitTimes;
            parameters[2].Value = model.OpenTime;
            parameters[3].Value = model.OpenSwitch;
            parameters[4].Value = model.FreezeTimes;
            parameters[5].Value = model.ScrambleReward;
            parameters[6].Value = model.ScrambleLiXiDays;
            parameters[7].Value = model.DisappearTimes;

            string guid = Guid.NewGuid().ToString();
            strSql.AppendFormat(";select '{0}'", guid);
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static bool Insert(Model.MMMConfigScramble model)
        {
            return DAL.CommonBase.RunHashtable(Insert(model, new Hashtable()));
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(Model.MMMConfigScramble model, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update MMMConfigScramble set ");
            strSql.Append("PayLimitTimes=@PayLimitTimes,");
            strSql.Append("ConfirmLimitTimes=@ConfirmLimitTimes,");
            strSql.Append("OpenTime=@OpenTime,");
            strSql.Append("OpenSwitch=@OpenSwitch,");
            strSql.Append("FreezeTimes=@FreezeTimes,");
            strSql.Append("ScrambleReward=@ScrambleReward,");
            strSql.Append("ScrambleLiXiDays=@ScrambleLiXiDays,");
            strSql.Append("DisappearTimes=@DisappearTimes");
            SqlParameter[] parameters = {
					new SqlParameter("@PayLimitTimes", SqlDbType.Int,4),
					new SqlParameter("@ConfirmLimitTimes", SqlDbType.Int,4),
					new SqlParameter("@OpenTime", SqlDbType.VarChar,100),
					new SqlParameter("@OpenSwitch", SqlDbType.Bit,1),
					new SqlParameter("@FreezeTimes", SqlDbType.Int,4),
					new SqlParameter("@ScrambleReward", SqlDbType.Decimal,9),
					new SqlParameter("@ScrambleLiXiDays", SqlDbType.Int,4),
					new SqlParameter("@DisappearTimes", SqlDbType.Int,4)};
            parameters[0].Value = model.PayLimitTimes;
            parameters[1].Value = model.ConfirmLimitTimes;
            parameters[2].Value = model.OpenTime;
            parameters[3].Value = model.OpenSwitch;
            parameters[4].Value = model.FreezeTimes;
            parameters[5].Value = model.ScrambleReward;
            parameters[6].Value = model.ScrambleLiXiDays;
            parameters[7].Value = model.DisappearTimes;

            string guid = Guid.NewGuid().ToString();
            strSql.AppendFormat(" ;select '{0}'", guid);
            MyHs.Add(strSql.ToString(), parameters);
            DAL.MMMConfigScramble.TModel = null;
            return MyHs;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool Update(Model.MMMConfigScramble model)
        {
            return DAL.CommonBase.RunHashtable(Update(model, new Hashtable()));
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static Hashtable Delete(object obj, Hashtable MyHs)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from MMMConfigScramble ");
            strSql.AppendFormat(" where  in ({0})", obj);

            MyHs.Add(strSql.ToString(), null);
            return MyHs;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static bool Delete(object obj)
        {
            return DAL.CommonBase.RunHashtable(Delete(obj, new Hashtable()));
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataTable GetTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM MMMConfigScramble ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }


        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataTable GetTable(int top, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + top + " * ");
            strSql.Append(" FROM MMMConfigScramble ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.CommonBase.GetTable("MMMConfigScramble", "", " ", strWhere, pageIndex, pageSize, out count);
        }


        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<Model.MMMConfigScramble> GetList(string strWhere)
        {
            List<Model.MMMConfigScramble> list = new List<Model.MMMConfigScramble>();

            DataTable table = GetTable(strWhere);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(TranEntity(table.Rows[i]));
            }

            return list;
        }

        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<Model.MMMConfigScramble> GetList(int top, string strWhere)
        {
            List<Model.MMMConfigScramble> list = new List<Model.MMMConfigScramble>();

            DataTable table = GetTable(top, strWhere);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(TranEntity(table.Rows[i]));
            }

            return list;
        }

        /// <summary>
        /// 获得实体列表
        /// </summary>
        public static List<Model.MMMConfigScramble> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<Model.MMMConfigScramble> list = new List<Model.MMMConfigScramble>();

            DataTable table = GetTable(strWhere, pageIndex, pageSize, out count);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(TranEntity(table.Rows[i]));
            }

            return list;
        }

        /// <summary>
        ///  实体转换
        /// <summary>
        private static Model.MMMConfigScramble TranEntity(DataRow row)
        {
            if (row != null)
            {
                Model.MMMConfigScramble model = new Model.MMMConfigScramble();

                if (row["PayLimitTimes"] != null && row["PayLimitTimes"].ToString() != "")
                {
                    model.PayLimitTimes = int.Parse(row["PayLimitTimes"].ToString());
                }
                if (row["ConfirmLimitTimes"] != null && row["ConfirmLimitTimes"].ToString() != "")
                {
                    model.ConfirmLimitTimes = int.Parse(row["ConfirmLimitTimes"].ToString());
                }
                if (row["OpenTime"] != null)
                {
                    model.OpenTime = row["OpenTime"].ToString();
                }
                if (row["OpenSwitch"] != null && row["OpenSwitch"].ToString() != "")
                {
                    if ((row["OpenSwitch"].ToString() == "1") || (row["OpenSwitch"].ToString().ToLower() == "true"))
                    {
                        model.OpenSwitch = true;
                    }
                    else
                    {
                        model.OpenSwitch = false;
                    }
                }
                if (row["FreezeTimes"] != null && row["FreezeTimes"].ToString() != "")
                {
                    model.FreezeTimes = int.Parse(row["FreezeTimes"].ToString());
                }
                if (row["ScrambleReward"] != null && row["ScrambleReward"].ToString() != "")
                {
                    model.ScrambleReward = decimal.Parse(row["ScrambleReward"].ToString());
                }
                if (row["ScrambleLiXiDays"] != null && row["ScrambleLiXiDays"].ToString() != "")
                {
                    model.ScrambleLiXiDays = int.Parse(row["ScrambleLiXiDays"].ToString());
                }
                if (row["DisappearTimes"] != null && row["DisappearTimes"].ToString() != "")
                {
                    model.DisappearTimes = int.Parse(row["DisappearTimes"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }
    }
}

