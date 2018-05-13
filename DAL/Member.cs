using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DBUtility;
using System.Collections;

namespace WE_Project.DAL
{
    public class Member
    {

        private static Model.Member _ManageMember;
        public static Model.Member ManageMember
        {
            get
            {
                if (_ManageMember == null)
                    _ManageMember = DAL.Member.GetManageModel();
                return _ManageMember;
            }
            set
            {
                _ManageMember = value;
            }
        }
        public static string GetMBD2(string mtjmid, int bdcount)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@mtj",SqlDbType.VarChar,20),
                new SqlParameter("@mbdcount",SqlDbType.Int,4)
            };
            para[0].Value = mtjmid;
            para[1].Value = bdcount;
            //return DbHelperSQL.ProcGetSingleProc("GetAutoMbdByMtj", para).ToString();//从上到下从左到右
            return DbHelperSQL.ProcGetSingleProc("GetAutoMbdByMtj2", para).ToString();//从上到下从左到右
            //return DbHelperSQL.ProcGetSingleProc("GetAutoMbdByMtjToMin", para).ToString();//小区业绩排
            //return DbHelperSQL.ProcGetSingleProc("GetAutoMbdByMtjToLR", para).ToString();//最左或最右
        }

        #region 临时字典
        //临时存储会员业绩相关数据
        public static Dictionary<string, Model.Member> tempMemberList = new Dictionary<string, Model.Member>();
        public static Dictionary<string, DateTime> _onLineMember = new Dictionary<string, DateTime>();

        /// <summary>
        /// 该MID是否存在字典中
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public static bool HasMemberConfigInDic(string mid)
        {
            if (tempMemberList.ContainsKey(mid))
                return true;
            return false;
        }

        public static void AddOnLine(string mid)
        {
            if (_onLineMember.ContainsKey(mid))
                _onLineMember[mid] = DateTime.Now;
            else
                _onLineMember.Add(mid, DateTime.Now);
        }

        public static bool IfOnLine(string mid)
        {
            if (_onLineMember.ContainsKey(mid) && (DateTime.Now - _onLineMember[mid]).TotalSeconds <= 60)
                return true;
            return false;
        }

        /// <summary>
        /// 临时字典增加,增加成功，TRUE，否则FALSE
        /// </summary>
        /// <param name="mid"></param>
        /// <param name="model"></param>
        /// <returns>增加成功，TRUE，否则FALSE</returns>
        public static bool tempMemberAdd(Model.Member model)
        {
            if (!DAL.Member.HasMemberConfigInDic(model.MID))
            {
                DAL.Member.tempMemberList.Add(model.MID, model);
                return true;
            }
            return false;
        }

        #endregion

        #region 会员信息增删改

        /// <summary>
        /// 插入会员
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool Insert(Model.Member model)
        {
            string guid = Guid.NewGuid().ToString();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into Member(");
            strSql.Append("MID,FMID,MName,Country,Province,City,Zone,Tel,Email,Address,Bank,Branch,BankNumber,BankCardName,Password,SecPsd,MTJ,MSH,MBD,MBDIndex,MCreateDate,MDate,MState,IsClose,IsClock,RoleCode,AgencyCode,Salt,ThrPsd,SHMoney,NumID,QQ,GCount,ActiveCode,WeChat,Alipay,ZDStatus)");
            strSql.Append(" values (");
            strSql.Append("@MID,@FMID,@MName,@Country,@Province,@City,@Zone,@Tel,@Email,@Address,@Bank,@Branch,@BankNumber,@BankCardName,@Password,@SecPsd,@MTJ,@MSH,@MBD,@MBDIndex,@MCreateDate,@MDate,@MState,@IsClose,@IsClock,@RoleCode,@AgencyCode,@Salt,@ThrPsd,@SHMoney,@NumID,@QQ,@GCount,@ActiveCode,@WeChat,@Alipay,@ZDStatus)");
            strSql.AppendFormat(";select '{0}'", guid).Append(UpdateThrPsd(model.MID));
            SqlParameter[] parameters = {
					new SqlParameter("@MID", SqlDbType.VarChar,20),
					new SqlParameter("@FMID", SqlDbType.VarChar,20),
					new SqlParameter("@MName", SqlDbType.NVarChar,50),
					new SqlParameter("@Country", SqlDbType.NVarChar,50),
					new SqlParameter("@Province", SqlDbType.NVarChar,50),
					new SqlParameter("@City", SqlDbType.NVarChar,50),
					new SqlParameter("@Zone", SqlDbType.NVarChar,50),
					new SqlParameter("@Tel", SqlDbType.VarChar,20),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,100),
					new SqlParameter("@Bank", SqlDbType.NVarChar,50),
					new SqlParameter("@Branch", SqlDbType.NVarChar,50),
					new SqlParameter("@BankNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@BankCardName", SqlDbType.NVarChar,50),
					new SqlParameter("@Password", SqlDbType.VarChar,32),
					new SqlParameter("@SecPsd", SqlDbType.VarChar,32),
					new SqlParameter("@MTJ", SqlDbType.VarChar,20),
					new SqlParameter("@MSH", SqlDbType.VarChar,20),
					new SqlParameter("@MBD", SqlDbType.VarChar,20),
					new SqlParameter("@MBDIndex", SqlDbType.Int,4),
					new SqlParameter("@MCreateDate", SqlDbType.DateTime),
					new SqlParameter("@MDate", SqlDbType.DateTime),
					new SqlParameter("@MState", SqlDbType.Bit,1),
					new SqlParameter("@IsClose", SqlDbType.Bit,1),
					new SqlParameter("@IsClock", SqlDbType.Bit,1),
					new SqlParameter("@RoleCode", SqlDbType.VarChar,10),
					new SqlParameter("@AgencyCode", SqlDbType.VarChar,10),
					new SqlParameter("@Salt", SqlDbType.VarChar,10),
					new SqlParameter("@ThrPsd", SqlDbType.VarChar,50),
					new SqlParameter("@SHMoney", SqlDbType.Int,4),
					new SqlParameter("@NumID", SqlDbType.NVarChar,50),
					new SqlParameter("@QQ", SqlDbType.VarChar,20),
					new SqlParameter("@GCount", SqlDbType.Int,4),
					new SqlParameter("@ActiveCode", SqlDbType.VarChar,20),
					new SqlParameter("@WeChat", SqlDbType.NVarChar,50),
					new SqlParameter("@Alipay", SqlDbType.NVarChar,50),new SqlParameter("@ZDStatus", SqlDbType.Bit,1)};
            parameters[0].Value = model.MID;
            parameters[1].Value = model.FMID;
            parameters[2].Value = model.MName;
            parameters[3].Value = model.Country;
            parameters[4].Value = model.Province;
            parameters[5].Value = model.City;
            parameters[6].Value = model.Zone;
            parameters[7].Value = model.Tel;
            parameters[8].Value = model.Email;
            parameters[9].Value = model.Address;
            parameters[10].Value = model.Bank;
            parameters[11].Value = model.Branch;
            parameters[12].Value = model.BankNumber;
            parameters[13].Value = model.BankCardName;
            parameters[14].Value = model.Password;
            parameters[15].Value = model.SecPsd;
            parameters[16].Value = model.MTJ;
            parameters[17].Value = model.MSH;
            parameters[18].Value = model.MBD;
            parameters[19].Value = model.MBDIndex;
            parameters[20].Value = model.MCreateDate;
            parameters[21].Value = model.MDate;
            parameters[22].Value = model.MState;
            parameters[23].Value = model.IsClose;
            parameters[24].Value = model.IsClock;
            parameters[25].Value = model.RoleCode;
            parameters[26].Value = model.AgencyCode;
            parameters[27].Value = model.Salt;
            parameters[28].Value = model.ThrPsd;
            parameters[29].Value = model.SHMoney;
            parameters[30].Value = model.NumID;
            parameters[31].Value = model.QQ;
            parameters[32].Value = model.GCount;
            parameters[33].Value = model.ActiveCode;
            parameters[34].Value = model.WeChat;
            parameters[35].Value = model.AliPay;
            parameters[36].Value = model.ZDStatus;

            Hashtable MyHs = new Hashtable();
            MyHs.Add(strSql, parameters);
            if (model.MConfig != null)
                MemberConfig.Insert(model.MConfig, MyHs);
            return DAL.CommonBase.RunHashtable(MyHs);
        }

        public static bool Update(Model.Member model)
        {
            lock (DAL.Member.tempMemberList)
            {
                DAL.Member.tempMemberList.Clear();
                Hashtable MyHs = new Hashtable();
                Update(model, MyHs);
                return DAL.CommonBase.RunHashtable(MyHs);
            }
        }

        /// <summary>
        /// 修改会员资料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Hashtable Update(Model.Member model, Hashtable MyHs)
        {
            if (model == null)
                return MyHs;
            string guid = Guid.NewGuid().ToString();

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Member set ");
            strSql.Append("FMID=@FMID,");
            strSql.Append("MName=@MName,");
            strSql.Append("Country=@Country,");
            strSql.Append("Province=@Province,");
            strSql.Append("City=@City,");
            strSql.Append("Zone=@Zone,");
            strSql.Append("Tel=@Tel,");
            strSql.Append("Email=@Email,");
            strSql.Append("Address=@Address,");
            strSql.Append("Bank=@Bank,");
            strSql.Append("Branch=@Branch,");
            strSql.Append("BankNumber=@BankNumber,");
            strSql.Append("BankCardName=@BankCardName,");
            strSql.Append("Password=@Password,");
            strSql.Append("SecPsd=@SecPsd,");
            strSql.Append("MTJ=@MTJ,");
            strSql.Append("MSH=@MSH,");
            strSql.Append("MBD=@MBD,");
            strSql.Append("MBDIndex=@MBDIndex,");
            strSql.Append("MCreateDate=@MCreateDate,");
            strSql.Append("MDate=@MDate,");
            strSql.Append("MState=@MState,");
            strSql.Append("IsClose=@IsClose,");
            strSql.Append("IsClock=@IsClock,");
            strSql.Append("RoleCode=@RoleCode,");
            strSql.Append("AgencyCode=@AgencyCode,");
            strSql.Append("Salt=@Salt,");
            strSql.Append("ThrPsd=@ThrPsd,");
            strSql.Append("SHMoney=@SHMoney,");
            strSql.Append("NumID=@NumID,");
            strSql.Append("QQ=@QQ,");
            strSql.Append("GCount=@GCount,");
            strSql.Append("ActiveCode=@ActiveCode,");
            strSql.Append("WeChat=@WeChat,");
            strSql.Append("Alipay=@Alipay,");
            strSql.Append("ZDStatus=@ZDStatus");
            strSql.Append(" where MID=@MID");
            strSql.AppendFormat(" ;select '{0}'", guid).Append(UpdateThrPsd(model.MID));
            SqlParameter[] parameters = {
					new SqlParameter("@FMID", SqlDbType.VarChar,20),
					new SqlParameter("@MName", SqlDbType.NVarChar,50),
					new SqlParameter("@Country", SqlDbType.NVarChar,50),
					new SqlParameter("@Province", SqlDbType.NVarChar,50),
					new SqlParameter("@City", SqlDbType.NVarChar,50),
					new SqlParameter("@Zone", SqlDbType.NVarChar,50),
					new SqlParameter("@Tel", SqlDbType.VarChar,20),
					new SqlParameter("@Email", SqlDbType.VarChar,50),
					new SqlParameter("@Address", SqlDbType.NVarChar,100),
					new SqlParameter("@Bank", SqlDbType.NVarChar,50),
					new SqlParameter("@Branch", SqlDbType.NVarChar,50),
					new SqlParameter("@BankNumber", SqlDbType.NVarChar,50),
					new SqlParameter("@BankCardName", SqlDbType.NVarChar,50),
					new SqlParameter("@Password", SqlDbType.VarChar,32),
					new SqlParameter("@SecPsd", SqlDbType.VarChar,32),
					new SqlParameter("@MTJ", SqlDbType.VarChar,20),
					new SqlParameter("@MSH", SqlDbType.VarChar,20),
					new SqlParameter("@MBD", SqlDbType.VarChar,20),
					new SqlParameter("@MBDIndex", SqlDbType.Int,4),
					new SqlParameter("@MCreateDate", SqlDbType.DateTime),
					new SqlParameter("@MDate", SqlDbType.DateTime),
					new SqlParameter("@MState", SqlDbType.Bit,1),
					new SqlParameter("@IsClose", SqlDbType.Bit,1),
					new SqlParameter("@IsClock", SqlDbType.Bit,1),
					new SqlParameter("@RoleCode", SqlDbType.VarChar,10),
					new SqlParameter("@AgencyCode", SqlDbType.VarChar,10),
					new SqlParameter("@Salt", SqlDbType.VarChar,10),
					new SqlParameter("@ThrPsd", SqlDbType.VarChar,50),
					new SqlParameter("@SHMoney", SqlDbType.Int,4),
					new SqlParameter("@NumID", SqlDbType.NVarChar,50),
					new SqlParameter("@QQ", SqlDbType.VarChar,20),
					new SqlParameter("@GCount", SqlDbType.Int,4),
					new SqlParameter("@ActiveCode", SqlDbType.VarChar,20),
					new SqlParameter("@WeChat", SqlDbType.NVarChar,50),
					new SqlParameter("@Alipay", SqlDbType.NVarChar,50),
                    new SqlParameter("@ZDStatus", SqlDbType.Bit,1),
                    new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@MID", SqlDbType.VarChar,20)};
            parameters[0].Value = model.FMID;
            parameters[1].Value = model.MName;
            parameters[2].Value = model.Country;
            parameters[3].Value = model.Province;
            parameters[4].Value = model.City;
            parameters[5].Value = model.Zone;
            parameters[6].Value = model.Tel;
            parameters[7].Value = model.Email;
            parameters[8].Value = model.Address;
            parameters[9].Value = model.Bank;
            parameters[10].Value = model.Branch;
            parameters[11].Value = model.BankNumber;
            parameters[12].Value = model.BankCardName;
            parameters[13].Value = model.Password;
            parameters[14].Value = model.SecPsd;
            parameters[15].Value = model.MTJ;
            parameters[16].Value = model.MSH;
            parameters[17].Value = model.MBD;
            parameters[18].Value = model.MBDIndex;
            parameters[19].Value = model.MCreateDate;
            parameters[20].Value = model.MDate;
            parameters[21].Value = model.MState;
            parameters[22].Value = model.IsClose;
            parameters[23].Value = model.IsClock;
            parameters[24].Value = model.RoleCode;
            parameters[25].Value = model.AgencyCode;
            parameters[26].Value = model.Salt;
            parameters[27].Value = model.ThrPsd;
            parameters[28].Value = model.SHMoney;
            parameters[29].Value = model.NumID;
            parameters[30].Value = model.QQ;
            parameters[31].Value = model.GCount;
            parameters[32].Value = model.ActiveCode;
            parameters[33].Value = model.WeChat;
            parameters[34].Value = model.AliPay;
            parameters[35].Value = model.ZDStatus;
            parameters[36].Value = model.ID;
            parameters[37].Value = model.MID;

            MyHs.Add(strSql.ToString(), parameters);
            //if (DAL.MemberConfig.GetModel(model.MID, model) != null)
            //    MemberConfig.Update(model.MConfig, MyHs);
            //else if (model.IsNewMemberSH)
            //    MemberConfig.Insert(model.MConfig, MyHs);
            return MyHs;
        }

        /// <summary>
        /// 修改会员资料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Hashtable UpdateBankInfo(Model.Member model, Hashtable MyHs)
        {
            if (model == null)
                return MyHs;
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Member set ");
            strSql.Append("Bank=@Bank,");
            strSql.Append("Branch=@Branch,");
            strSql.Append("BankNumber=@BankNumber,");
            strSql.Append("BankCardName=@BankCardName");
            strSql.Append(" where MID=@MID " + UpdateThrPsd(model.MID));
            SqlParameter[] parameters = {
					new SqlParameter("@Bank", SqlDbType.VarChar,50),
					new SqlParameter("@Branch", SqlDbType.VarChar,50),
					new SqlParameter("@BankNumber", SqlDbType.VarChar,30),
					new SqlParameter("@BankCardName", SqlDbType.VarChar,20),
					new SqlParameter("@MID", SqlDbType.VarChar,20)};
            parameters[0].Value = model.Bank;
            parameters[1].Value = model.Branch;
            parameters[2].Value = model.BankNumber;
            parameters[3].Value = model.BankCardName;
            parameters[4].Value = model.MID;

            MyHs.Add(strSql.ToString(), parameters);
            DAL.Member.ManageMember = null;
            return MyHs;
        }

        public static Hashtable UpdateRole(Model.Member model, Hashtable MyHs)
        {
            MyHs.Add(string.Format("update member set RoleCode='{0}',AgencyCode='{1}',MDate='{2}',SHMoney={3},MBD='{4}',MBDIndex={5},MState='{7}' where MID='{6}'" + UpdateThrPsd(model.MID), model.RoleCode, model.AgencyCode, model.MDate, model.SHMoney, model.MBD, model.MBDIndex, model.MID, model.MState), null);
            return MyHs;
        }

        /// <summary>
        /// 删除会员
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public static string DeleteMember(string midList)
        {
            string[] mids = midList.Split(',');
            Hashtable MyHs = new Hashtable();
            int count = mids.Length;
            int successcount = 0;
            foreach (string mid in mids)
            {
                if (string.IsNullOrEmpty(mid))
                    continue;
                lock (DAL.Member.tempMemberList)
                {
                    //DAL.Member.tempMemberList.Clear();
                    //Model.Member model = DAL.Member.GetModel(mid);
                    //List<Model.ChangeMoney> ChangeMoneyList = ChangeMoneyCollection.GetChangeMoneyEntityList(string.Format("SHMID='{0}'", mid));
                    //List<Model.MConfigChange> MConfigChangeList = MConfigChange.GetMConfigChangeEntityList(string.Format("SHMID='{0}'", mid));
                    //DAL.Member.tempMemberList.Clear();//清空临时字典
                    //string guid = Guid.NewGuid().ToString();
                    //foreach (Model.ChangeMoney item in ChangeMoneyList)
                    //{
                    //    if (item.CState)
                    //    {
                    //        DAL.ChangeMoney.TranChangeTran(item.ToMID, item.FromMID, item.Money - item.TakeOffMoney, item.MoneyType, MyHs);
                    //    }
                    //}
                    //foreach (Model.MConfigChange item in MConfigChangeList)
                    //{
                    //    guid = Guid.NewGuid().ToString();
                    //    if (item.IsValue)
                    //    {
                    //        MyHs.Add(string.Format("update MemberConfig set {0} = '{1}' where MID = '{2}' " + " and '" + guid + "'='" + guid + "'", item.ConfigName, item.ConfigValue, item.MID), null);
                    //    }
                    //    else
                    //    {
                    //        MyHs.Add(string.Format("update MemberConfig set {0} ={0}- {1} where MID = '{2}' " + " and '" + guid + "'='" + guid + "'", item.ConfigName, item.ConfigValue, item.MID), null);
                    //    }
                    //}
                    MyHs.Add(string.Format("delete from ChangeMoney where SHMID='{0}'", mid), null);
                    MyHs.Add(string.Format("delete from Member where MID='{0}'", mid), null);
                    MyHs.Add(string.Format("delete from MemberConfig where MID='{0}'", mid), null);
                    MyHs.Add(string.Format("delete from MConfigChange where SHMID='{0}'", mid), null);

                    if (CommonBase.RunHashtable(MyHs))
                    {
                        DAL.Member.tempMemberList.Clear();//清空临时字典
                        successcount++;
                    }
                }
            }
            DAL.Member.tempMemberList.Clear();//清空临时字典
            return string.Format("成功:{0},失败{1}", successcount, count - successcount);
        }

        /// <summary>
        /// 删除会员
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public static string DeleteMemberW(string midList, string tjmid)
        {
            string[] mids = midList.Split(',');
            Hashtable MyHs = new Hashtable();
            int count = mids.Length;
            foreach (string mid in mids)
            {
                Model.Member model = DAL.Member.GetModel(mid);
                if (DAL.Member.GetModel(tjmid).Role.IsAdmin)
                    MyHs.Add("delete from member where mid='" + model.MID + "'; delete from memberconfig where mid ='" + model.MID + "';", null);
                else if (model.MTJ == tjmid && model.AgencyCode == "001")
                    MyHs.Add("delete from member where mid='" + model.MID + "'; delete from memberconfig where mid ='" + model.MID + "';", null);
            }
            if (CommonBase.RunHashtable(MyHs))
            {
                return "操作成功";
            }
            return "操作失败";
        }

        #endregion

        #region 会员信息查询

        /// <summary>
        /// 得到会员对象
        /// </summary>
        /// <param name="MID"></param>
        /// <returns></returns>
        public static Model.Member GetModel(string MID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 *," + Model.Member.MD5 + " as 'TempThrPsd' from Member");
            strSql.Append(" where MID=@MID ");
            SqlParameter[] parameters = {
					new SqlParameter("@MID", SqlDbType.VarChar,20)};
            parameters[0].Value = MID;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count > 0)
                return TranEntity(ds.Tables[0].Rows[0]);
            return null;
        }

        /// <summary>
        /// 得到管理员对象
        /// </summary>
        /// <returns></returns>
        public static Model.Member GetManageModel()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from Member");
            strSql.Append(" where RoleCode in (select RType from Roles where Super='1') order by ID");

            DataSet ds = DbHelperSQL.Query(strSql.ToString());

            if (ds.Tables[0].Rows.Count > 0)
                return TranEntity(ds.Tables[0].Rows[0]);
            return null;
        }
        /// <summary>
        /// 得到直接接点人数
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public static int GetBDCount(string mid, bool mstate)
        {
            return Convert.ToInt32(DbHelperSQL.GetSingle(string.Format("select count(1) from Member where MBD='{0}' and MID<>'{0}' and MState='{1}' and AgencyCode<>'001'", mid, mstate)));
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 转换数据实体
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public static Model.Member TranEntity(DataRow row)
        {
            Model.Member model = new Model.Member();
            if (row["ID"].ToString() != "")
            {
                model.ID = int.Parse(row["ID"].ToString());
            }
            if (row[1].ToString() != "")
            {
                model.MID = row[1].ToString().ToLower();
            }
            if (row["FMID"].ToString() != "")
            {
                model.FMID = row["FMID"].ToString();
            }
            if (row["MName"] != null)
            {
                model.MName = row["MName"].ToString();
            }
            if (row["Province"] != null)
            {
                model.Province = row["Province"].ToString();
            }
            if (row["City"] != null)
            {
                model.City = row["City"].ToString();
            }
            if (row["Zone"] != null)
            {
                model.Zone = row["Zone"].ToString();
            }
            if (row["Tel"] != null)
            {
                model.Tel = row["Tel"].ToString();
            }
            if (row["Email"] != null)
            {
                model.Email = row["Email"].ToString();
            }
            if (row["Address"] != null)
            {
                model.Address = row["Address"].ToString();
            }
            if (row["Bank"] != null)
            {
                model.Bank = row["Bank"].ToString();
            }
            if (row["Branch"] != null)
            {
                model.Branch = row["Branch"].ToString();
            }
            if (row["BankNumber"] != null)
            {
                model.BankNumber = row["BankNumber"].ToString();
            }
            if (row["BankCardName"] != null)
            {
                model.BankCardName = row["BankCardName"].ToString();
            }
            if (row["Password"] != null)
            {
                model.Password = row["Password"].ToString();
            }
            if (row["SecPsd"] != null)
            {
                model.SecPsd = row["SecPsd"].ToString();
            }
            if (row["QQ"] != null)
            {
                model.QQ = row["QQ"].ToString();
            }
            if (row["ThrPsd"] != null)
            {
                model.ThrPsd = row["ThrPsd"].ToString();
            }
            if (row.Table.Columns.Contains("TempThrPsd"))
            {
                model.TempThrPsd = row["TempThrPsd"].ToString();
            }
            if (row["MTJ"] != null)
            {
                model.MTJ = row["MTJ"].ToString().ToLower();
            }
            if (row["MSH"] != null)
            {
                model.MSH = row["MSH"].ToString().ToLower();
            }
            if (row["MBD"] != null)
            {
                model.MBD = row["MBD"].ToString().ToLower();
            }
            if (row["MBDIndex"].ToString() != "")
            {
                model.MBDIndex = int.Parse(row["MBDIndex"].ToString());
            }
            if (row["MCreateDate"].ToString() != "")
            {
                model.MCreateDate = DateTime.Parse(row["MCreateDate"].ToString());
            }
            if (row["MDate"].ToString() != "")
            {
                model.MDate = DateTime.Parse(row["MDate"].ToString());
            }
            if (row["MState"].ToString() != "")
            {
                model.MState = bool.Parse(row["MState"].ToString());
            }
            if (row["IsClose"].ToString() != "")
            {
                model.IsClose = bool.Parse(row["IsClose"].ToString());
            }
            if (row["IsClock"].ToString() != "")
            {
                model.IsClock = bool.Parse(row["IsClock"].ToString());
            }
            if (row["ZDStatus"].ToString() != "")
            {
                model.ZDStatus = bool.Parse(row["ZDStatus"].ToString());
            }
            if (row["RoleCode"].ToString() != "")
            {
                model.RoleCode = row["RoleCode"].ToString();
                model.Role = DAL.Roles.RolsList[model.RoleCode];
            }
            if (row["AgencyCode"].ToString() != "")
            {
                model.AgencyCode = row["AgencyCode"].ToString();
                if (!string.IsNullOrEmpty(model.AgencyCode) && DAL.Configuration.TModel.SHMoneyList.ContainsKey(model.AgencyCode))
                    model.MAgencyType = DAL.Configuration.TModel.SHMoneyList[model.AgencyCode];
            }
            if (row["Salt"].ToString() != "")
            {
                model.Salt = row["Salt"].ToString();
            }
            if (row["SHMoney"].ToString() != "")
            {
                model.SHMoney = int.Parse(row["SHMoney"].ToString());
            }
            if (row["GCount"].ToString() != "")
            {
                model.GCount = int.Parse(row["GCount"].ToString());
            }
            model.ActiveCode = row["ActiveCode"].ToString();
            model.AliPay = row["AliPay"].ToString();
            model.WeChat = row["WeChat"].ToString();
            model.NumID = row["NumID"].ToString();
            model.Country = row["Country"].ToString();
            if (row.Table.TableName == "MemberAndConfig")
                model.MConfig = DAL.MemberConfig.TranEntity(row, model);
            else
                model.MConfig = DAL.MemberConfig.GetModel(model.MID, model);

            return model;
        }

        #endregion

        #region 其他方法
        /// <summary>
        /// 初始化系统
        /// </summary>
        /// <param name="AgencyCode"></param>
        /// <returns></returns>
        public static bool ReSetSys(Model.Member model)
        {
            if (model.Role.Super)
            {
                StringBuilder strSql = new StringBuilder();
                strSql.Append("delete from ChangeMoney;");
                strSql.Append("delete from Member where RoleCode not in ('Activation','Manage');");
                strSql.Append("update Member set MCreateDate=GETDATE(),MDate=GETDATE();" + UpdateThrPsd(""));
                strSql.Append("delete from MemberConfig;");
                strSql.Append("insert into memberconfig(mid,EPTimeOutCount,EPXingCount)values('" + DAL.Member.ManageMember.MID + "',0,5);");
                strSql.Append("delete from BMember;");
                strSql.Append("delete from Message;");
                strSql.Append("delete from Notice;");
                strSql.Append("delete from Task;");
                strSql.Append("delete from MConfigChange;");
                strSql.Append("delete from BankModel where MID<>'admin';");
                strSql.Append("delete from HKModel;");
                strSql.Append("delete from Accounts;");
                strSql.Append("delete from [SMS];");
                strSql.Append("delete from [EPJX];");
                strSql.Append("delete from [EPList];");
                strSql.Append("delete from [FDBuyList];");
                strSql.Append("delete from [FDSellList];");
                strSql.Append("delete from [MemberApply];");
                strSql.Append("delete from [IPClick];");
                strSql.Append("delete from [MOfferHelp];");
                strSql.Append("delete from [MHelpMatch];");
                strSql.Append("delete from [MGetHelp];");
                strSql.Append("delete from [ActiveCode];");
                strSql.Append("delete from [BuyActiveCode];");
                strSql.Append("delete from [Remind];");
                strSql.Append("delete from [WriteEmail];");
                strSql.Append("delete from [BCenter];");
                strSql.Append("delete from [MemberBonus];");
                strSql.Append("delete from [Sys_SQ_Answer] where MID<>" + DAL.Member._ManageMember.ID);
                DAL.Configuration.TModel = null;
                return DbHelperSQL.ExecuteSql(strSql.ToString()) > 0;
            }
            return false;
        }

        #endregion

        public static Hashtable UpdateTran(string mid, string fieldName, string fieldValue, Model.Member shmodel, bool isEqual, SqlDbType dataType, Hashtable MyHs)
        {
            StringBuilder strSql = new StringBuilder();
            string guid = Guid.NewGuid().ToString();
            strSql.Append("update Member set ");
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
            strSql.Append(string.Format(" where MID='{0}' and '{1}'='{1}'", mid, guid));

            if (isEqual)
                MyHs.Add(strSql, "1");
            else
                MyHs.Add(strSql, null);
            return MyHs;
        }

        public static bool TestMID(string mid)
        {
            return Convert.ToInt32(DbHelperSQL.GetSingle("select count(1) from Member where MID='" + mid + "'")) > 0;
        }

        public static string UpdateThrPsd(string mid)
        {
            string strWhere = Model.Member.UpThrPsd;
            if (!string.IsNullOrEmpty(mid))
                strWhere += " where mid ='" + mid + "'";
            return strWhere;
        }

        public static string GetMBD(string mtjmid, int bdcount)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@mtj",SqlDbType.VarChar,20),
                new SqlParameter("@mbdcount",SqlDbType.Int,4)
            };
            para[0].Value = mtjmid;
            para[1].Value = bdcount;
            return DbHelperSQL.ProcGetSingleProc("GetAutoMbdByMtj", para).ToString();//从上到下从左到右
            //return DbHelperSQL.ProcGetSingleProc("GetAutoMbdByMtjToMin", para).ToString();//小区业绩排
            //return DbHelperSQL.ProcGetSingleProc("GetAutoMbdByMtjToLR", para).ToString();//最左或最右
        }

        public static bool MemberHBClear()
        {
            lock (DAL.Member.tempMemberList)
            {
                DAL.Member.tempMemberList.Clear();
                return DbHelperSQL.ExecuteSql("Update MemberConfig set MJB=0,MHB=0,MGP=0,MCW=0" + UpdateThrPsd("") + ";") > 0;
            }
        }

        public static bool MemberHBToJB()
        {
            lock (DAL.Member.tempMemberList)
            {
                DAL.Member.tempMemberList.Clear();
                return DbHelperSQL.ExecuteSql("Update Member set MJB=MHB,MHB=0" + UpdateThrPsd("")) > 0;
            }
        }

        public static decimal GetTypeSumJJ(string mid, string type, DateTime day)
        {
            return Convert.ToDecimal(DbHelperSQL.GetSingle(string.Format("select sum(Money) from changemoney where tomid='{0}' and CState='1' and changedate between '{1} 00:00:00' and '{1} 23:59:59' and changetype in ('{2}') ", mid, day.ToString("yyyy-MM-dd"), type)));
        }

        public static bool MemberClose(Model.Member model)
        {
            return DbHelperSQL.ExecuteSql(string.Format("Update Member set IsClose='{0}' where MID='{1}'", model.IsClose, model.MID)) > 0;
        }

        public static int GetLevelForView(Model.Member model, string viewMid, bool viewType)
        {
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter("@mid",SqlDbType.VarChar,20),
                new SqlParameter("@viewmid",SqlDbType.VarChar,10),
                new SqlParameter("@viewtype",SqlDbType.Bit,1)
            };
            para[0].Value = model.MID;
            para[1].Value = viewMid;
            para[2].Value = viewType;
            return Convert.ToInt32(DbHelperSQL.ProcGetSingleProc("GetLevelForView", para));
        }

        /// <summary>
        /// 手机号是否存在
        /// </summary>
        /// <param name="tel"></param>
        /// <returns></returns>
        public static bool IsPhoneExist(string tel)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat(" select count(*) from member where tel = '{0}' ", tel);
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return Convert.ToInt32(obj) > 0;
            }
            return false;
        }
    }
}
