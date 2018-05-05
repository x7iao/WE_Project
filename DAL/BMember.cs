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
    public class BMember
    {
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static Hashtable Insert(WE_Project.Model.BMember model, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            string guid = Guid.NewGuid().ToString();
            strSql.Append("insert into BMember(");
            strSql.Append("AMID,BMID,BMBD,BMCreateDate,BMDate,BMState,BIsClock,YJCount,YJMoney,BCount,BOutMoney,FHDays");
            strSql.Append(") values (");
            strSql.Append("@AMID,@BMID,@BMBD,@BMCreateDate,@BMDate,@BMState,@BIsClock,@YJCount,@YJMoney,@BCount,@BOutMoney,@FHDays");
            strSql.Append(") ");
            strSql.AppendFormat("; select '{0}'", guid);

            SqlParameter[] parameters = {
                        new SqlParameter("@AMID", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@BMID", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@BMBD", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@BMCreateDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@BMDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@BMState", SqlDbType.Bit,1) ,            
                        new SqlParameter("@BIsClock", SqlDbType.Bit,1) ,            
                        new SqlParameter("@YJCount", SqlDbType.Decimal) ,            
                        new SqlParameter("@YJMoney", SqlDbType.Decimal) ,            
                        new SqlParameter("@BCount", SqlDbType.Decimal),
                        new SqlParameter("@BOutMoney", SqlDbType.Decimal),
                        new SqlParameter("@FHDays", SqlDbType.Int,4)
            };

            parameters[0].Value = model.AMID;
            parameters[1].Value = model.BMID;
            parameters[2].Value = model.BMBD;
            parameters[3].Value = model.BMCreateDate;
            parameters[4].Value = model.BMDate;
            parameters[5].Value = model.BMState;
            parameters[6].Value = model.BIsClock;
            parameters[7].Value = model.YJCount;
            parameters[8].Value = model.YJMoney;
            parameters[9].Value = model.BCount;
            parameters[10].Value = model.BOutMoney;
            parameters[11].Value = model.FHDays;
            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }


        public static bool Insert(WE_Project.Model.BMember model)
        {
            return DAL.CommonBase.RunHashtable(Insert(model, new System.Collections.Hashtable()));
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static Hashtable Update(WE_Project.Model.BMember model, Hashtable MyHs)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update BMember set ");

            strSql.Append(" AMID = @AMID , ");
            strSql.Append(" BMID = @BMID , ");
            strSql.Append(" BMBD = @BMBD , ");
            strSql.Append(" BMCreateDate = @BMCreateDate , ");
            strSql.Append(" BMDate = @BMDate , ");
            strSql.Append(" BMState = @BMState , ");
            strSql.Append(" YJCount = @YJCount , ");
            strSql.Append(" YJMoney = @YJMoney , ");
            strSql.Append(" BCount = @BCount , ");
            strSql.Append(" BIsClock = @BIsClock , ");
            strSql.Append(" BOutMoney = @BOutMoney,  ");
            strSql.Append(" FHDays = @FHDays  ");
            strSql.Append(" where BMID=@BMID");
            strSql.AppendFormat(" ;select '{0}'", guid);

            SqlParameter[] parameters = {
                        new SqlParameter("@AMID", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@BMID", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@BMBD", SqlDbType.VarChar,20) ,            
                        new SqlParameter("@BMCreateDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@BMDate", SqlDbType.DateTime) ,            
                        new SqlParameter("@BMState", SqlDbType.Bit,1) ,            
                        new SqlParameter("@YJCount", SqlDbType.Decimal) ,            
                        new SqlParameter("@YJMoney", SqlDbType.Decimal) ,            
                        new SqlParameter("@BCount", SqlDbType.Decimal) ,            
                        new SqlParameter("@BIsClock", SqlDbType.Bit,1) ,
                        new SqlParameter("@BOutMoney", SqlDbType.Decimal),
                        new SqlParameter("@FHDays", SqlDbType.Int,4)
            };

            parameters[0].Value = model.AMID;
            parameters[1].Value = model.BMID;
            parameters[2].Value = model.BMBD;
            parameters[3].Value = model.BMCreateDate;
            parameters[4].Value = model.BMDate;
            parameters[5].Value = model.BMState;
            parameters[6].Value = model.YJCount;
            parameters[7].Value = model.YJMoney;
            parameters[8].Value = model.BCount;
            parameters[9].Value = model.BIsClock;
            parameters[10].Value = model.BOutMoney;
            parameters[11].Value = model.FHDays;

            MyHs.Add(strSql.ToString(), parameters);
            return MyHs;
        }

        public static bool Update(WE_Project.Model.BMember model)
        {
            return DAL.CommonBase.RunHashtable(Update(model, new System.Collections.Hashtable()));
        }

        /// <summary>
        /// 更新会员参数值
        /// </summary>
        /// <param name="mid">会员账号</param>
        /// <param name="ConfigValue">参数值</param>
        /// <param name="ConfigName">参数名称</param>
        /// <param name="MyHs"></param>
        /// <returns></returns>
        public static Hashtable UpdateConfigTran(string mid, string fieldName, string fieldValue, Model.BMember shmodel, bool isEqual, SqlDbType dataType, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            string guid = Guid.NewGuid().ToString();
            strSql.Append("update BMember set ");
            if (isEqual)
            {
                if (dataType == SqlDbType.Int || dataType == SqlDbType.Decimal)
                    strSql.Append(string.Format("{0} = {1} ", fieldName, fieldValue));
                else
                    strSql.Append(string.Format("{0} = '{1}' ", fieldName, fieldValue));
            }
            else
            {
                if (dataType == SqlDbType.Int || dataType == SqlDbType.Decimal)
                    strSql.Append(string.Format("{0} = {0} + {1} ", fieldName, fieldValue));
                else
                    strSql.Append(string.Format("{0} = '{0}' + '{1}' ", fieldName, fieldValue));
            }
            strSql.Append(string.Format(" where BMID='{0}' and '{1}'='{1}'", mid, guid));

            MyHs.Add(strSql, null);
            if (shmodel != null)
            {
                if (isEqual)
                {
                    object obj = DbHelperSQL.GetSingle(string.Format("select {0} from BMember where BMID='{1}'", fieldName, mid));
                    if (obj != null)
                    {
                        fieldValue = obj.ToString();
                    }
                }
                Model.MConfigChange mchange = new Model.MConfigChange
                {
                    ChangeDate = DateTime.Now,
                    ConfigName = fieldName,
                    ConfigValue = fieldValue.ToString(),
                    DataType = dataType,
                    IsValue = isEqual,
                    MID = mid,
                    SHMID = shmodel.BMID
                };
                DAL.MConfigChange.Add(mchange, MyHs);

            }
            return MyHs;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public static Hashtable Delete(object obj, Hashtable MyHs)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from BMember ");
            strSql.AppendFormat(" where BMID in ({0})", obj);

            MyHs.Add(strSql.ToString(), null);
            return MyHs;
        }

        public static bool Delete(object obj)
        {
            return DAL.CommonBase.RunHashtable(Delete(obj, new System.Collections.Hashtable()));
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static WE_Project.Model.BMember GetModel(string BMID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select BMember.*,MemberConfig.TJCount  ");
            strSql.Append("  from BMember inner join MemberConfig on BMember.AMID=MemberConfig.MID ");
            strSql.Append(" where BMID=@BMID");
            SqlParameter[] parameters = {
					new SqlParameter("@BMID", SqlDbType.VarChar,20)};
            parameters[0].Value = BMID;


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

        public static WE_Project.Model.BMember GetModelByID(object ID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append("  from BMember ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;
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
        public static int GetCountModel(DateTime day)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select Count(1)  ");
            strSql.AppendFormat("  from BMember where BMDate between '{0} 00:00:01' and '{0} 23:59:59'", day.ToShortDateString());


            //DataSet ds = DbHelperSQL.Query(strSql.ToString());

            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString()));
        }

        public static WE_Project.Model.BMember DataRowToModel(DataRow row)
        {
            if (row != null)
            {
                WE_Project.Model.BMember model = new WE_Project.Model.BMember();
                if (row["ID"].ToString() != "")
                {
                    model.ID = int.Parse(row["ID"].ToString());
                }
                model.AMID = row["AMID"].ToString();
                model.BMID = row["BMID"].ToString();
                model.BMBD = row["BMBD"].ToString();
                if (row["BMCreateDate"].ToString() != "")
                {
                    model.BMCreateDate = DateTime.Parse(row["BMCreateDate"].ToString());
                }
                if (row["BMDate"].ToString() != "")
                {
                    model.BMDate = DateTime.Parse(row["BMDate"].ToString());
                }
                if (row["BMState"].ToString() != "")
                {
                    model.BMState = bool.Parse(row["BMState"].ToString());
                }
                if (row["BIsClock"].ToString() != "")
                {
                    model.BIsClock = bool.Parse(row["BIsClock"].ToString());
                }
                if (row["YJCount"].ToString() != "")
                {
                    model.YJCount = decimal.Parse(row["YJCount"].ToString());
                }
                if (row["YJMoney"].ToString() != "")
                {
                    model.YJMoney = decimal.Parse(row["YJMoney"].ToString());
                }
                if (row["BCount"].ToString() != "")
                {
                    model.BCount = decimal.Parse(row["BCount"].ToString());
                }
                if (row["BOutMoney"].ToString() != "")
                {
                    model.BOutMoney = decimal.Parse(row["BOutMoney"].ToString());
                }
                if (row["FHDays"].ToString() != "")
                {
                    model.FHDays = int.Parse(row["FHDays"].ToString());
                }

                return model;
            }
            else
            {
                return null;
            }
        }

        public static System.Data.DataTable GetTable(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM BMember ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        public static System.Data.DataTable GetTable(int top, string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top " + top + " * ");
            strSql.Append(" FROM BMember ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString()).Tables[0];
        }

        public static System.Data.DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return CommonBase.GetTable("BMember", "BMID", "ID asc,BMID asc", strWhere, pageIndex, pageSize, out count);
        }

        public static System.Data.DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count, string orderBy)
        {
            return CommonBase.GetTable("BMember", "BMID", orderBy, strWhere, pageIndex, pageSize, out count);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public static List<WE_Project.Model.BMember> GetList(string strWhere)
        {
            List<WE_Project.Model.BMember> list = new List<WE_Project.Model.BMember>();

            DataTable table = GetTable(strWhere);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(DataRowToModel(table.Rows[i]));
            }

            return list;
        }
        public static List<WE_Project.Model.BMember> GetList(int top, string strWhere)
        {
            List<WE_Project.Model.BMember> list = new List<WE_Project.Model.BMember>();

            DataTable table = GetTable(top, strWhere);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(DataRowToModel(table.Rows[i]));
            }

            return list;
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static List<WE_Project.Model.BMember> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            List<WE_Project.Model.BMember> list = new List<WE_Project.Model.BMember>();

            DataTable table = GetTable(strWhere, pageIndex, pageSize, out count);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(DataRowToModel(table.Rows[i]));
            }

            return list;
        }
        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public static List<WE_Project.Model.BMember> GetList(string strWhere, int pageIndex, int pageSize, out int count, string orderBy)
        {
            List<WE_Project.Model.BMember> list = new List<WE_Project.Model.BMember>();

            DataTable table = GetTable(strWhere, pageIndex, pageSize, out count, orderBy);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                list.Add(DataRowToModel(table.Rows[i]));
            }

            return list;
        }

        /// <summary>
        /// 生成BMID账号
        /// </summary>
        /// <param name="MID"></param>
        /// <returns></returns>
        public static string GetBMID(Model.Member model)
        {
            int bmidcount = Convert.ToInt32(DbHelperSQL.GetSingle(string.Format("select count(1) from BMember where AMID='{0}'", model.MID))) + model.BMemberList.Count;
            while (DAL.BMember.GetModel(model.MID + "_" + bmidcount.ToString()) != null)
            {
                bmidcount += 1;
            }
            return model.MID + "_" + bmidcount.ToString();
        }

        public static string GetBMBD(string mid, int count)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@bdmid",SqlDbType.VarChar,20),
                new SqlParameter("@bdcount",SqlDbType.Int,4)
            };
            para[0].Value = mid;
            para[1].Value = count;
            //return DbHelperSQL.ProcGetSingleProc("GetAutoMbdByMtj", para).ToString();//从上到下从左到右
            //return DbHelperSQL.ProcGetSingleProc("GetAutoMbdByMtjToMin", para).ToString();//小区排
            //return DbHelperSQL.ProcGetSingleProc("GetAutoMbdByMtjToLR", para).ToString();//最左或最右
            return DbHelperSQL.ProcGetSingleProc("GetAutoMbdByMBD2", para).ToString();//公排
        }
        public static DataTable GetIndexCharData(string beginDate, string endDate)
        {
            string outFloat = "1";
            string sql = " select sum(YJCount/" + outFloat + ") as Sumcount,CONVERT(varchar(100), BMDate, 102) as ConfirmDate from BMember where DATEDIFF(Day,BMDate,'" + beginDate + "')<=0 and DATEDIFF(Day,BMDate, '" + endDate + "')>=0  group by CONVERT(varchar(100),  BMDate, 102) order by ConfirmDate ";
            return DbHelperSQL.Query(sql).Tables[0];//
        }

        public static decimal GetSumMoney(string mid, string filed)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" select isnull(sum({0}),0) from BMember ", filed);
            strSql.AppendFormat(" where AMID = '{0}' ", mid);

            return Convert.ToDecimal(DbHelperSQL.GetSingle(strSql.ToString()));
        }
    }
}
