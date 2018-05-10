using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace WE_Project.BLL
{
    public class Member
    {
        public Model.Member TModel { get; set; }
        public static List<string> upmidlist = new List<string>();

        private static Member _ManageMember;
        public static Member ManageMember
        {
            get
            {
                if (_ManageMember == null || _ManageMember.TModel == null)
                {
                    _ManageMember = new Member();
                    _ManageMember.TModel = DAL.Member.ManageMember;
                }
                return _ManageMember;
            }
            set
            {
                _ManageMember = value;
            }
        }
        public static void AddOnLine(string mid)
        {
            DAL.Member.AddOnLine(mid);
        }

        public static bool IfOnLine(string mid)
        {
            return DAL.Member.IfOnLine(mid);
        }

        public static string GetOnlineInfo(string mid)
        {
            return "";
            //if (BLL.Member.IfOnLine(mid))
            //    return "<b style='color:#A8FF24;cursor:help;' title='我在线请对话' onclick='OpenTask(\"" + mid + "\");'><img src='SourceFiles/AcmeBlue/images/on.jpg'/></b>";
            //else
            //    return "<b style='cursor:help;' title='我不在线请留言' onclick='OpenTask(\"" + mid + "\");'><img src='SourceFiles/AcmeBlue/images/off.jpg'/></b>";
        }
        /// <summary>
        /// 衰减忠诚度
        /// </summary>
        /// <returns></returns>
        public static bool Weaken()
        {
            Hashtable MyHs = new Hashtable();
            MyHs.Add("update MemberConfig set EPXingCount=EPXingCount-1 where EPXingCount>0;", null);
            return BLL.CommonBase.RunHashtable(MyHs);
        }

        public static int OnLineCount
        {
            get
            {
                return DAL.Member._onLineMember.Where(emp => DAL.Member.IfOnLine(emp.Key)).Count();
            }
        }
        public static List<string> OnLineMember
        {
            get
            {
                return DAL.Member._onLineMember.Keys.Where(emp => IfOnLine(emp)).ToList();
            }
        }
        /// <summary>
        /// 更新会员资料
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Update(Model.Member model)
        {
            return DAL.Member.Update(model);
        }

        public Hashtable Update(Model.Member model, Hashtable MyHs)
        {
            return DAL.Member.Update(model, MyHs);
        }

        public bool MemberClose(Model.Member model)
        {
            return DAL.Member.MemberClose(model);
        }

        public string SHMemberByActiveCode(Model.SHMoney shmoney, string mid, Model.Member shmodel, Model.ActiveCode activeCode)
        {
            Hashtable MyHs = new Hashtable();
            Model.Member model = DAL.Member.GetModel(mid);
            string agencyCode = model.AgencyCode;
            if (model == null)
                return "升级会员不存在";
            if (string.IsNullOrEmpty(model.MTJ))
                return "请联系管理员设置您的推荐人";
            decimal sjmoney = 0;

            lock (DAL.Member.tempMemberList)
            {
                DAL.Member.tempMemberList.Clear();
                DAL.Member.tempMemberAdd(model);

                //查看激活码是否可用
                if (activeCode.UseState == 2 || activeCode.UseState == 4)
                {
                    return "激活码无效";
                }
                activeCode.UseMID = model.MID;
                activeCode.UseState = 2;
                activeCode.UseTime = DateTime.Now;
                BLL.ActiveCode.Update(activeCode, MyHs);
                //if (BLL.ChangeMoney.HBChangeTran(sjmoney, shmodel.MID, ManageMember.TModel.MID, "SH", model, "MJB", "报单", MyHs) > 0)
                {
                    model.MConfig.YJMoney += (int)sjmoney;
                    DAL.MemberConfig.UpdateConfigTran(model.MID, "YJMoney", sjmoney.ToString(), model, false, SqlDbType.Int, MyHs);

                    model.SHMoney += (int)sjmoney;
                    string PCode = "005";//升级
                    if (!model.MState)
                    {
                        PCode = "001";//激活升级
                        string error = Validation2(model);
                        if (!string.IsNullOrEmpty(error))
                        {
                            return error;
                        }
                        model.MConfig.YJCount += 1;
                        DAL.MemberConfig.UpdateConfigTran(model.MID, "YJCount", "1", model, false, SqlDbType.Int, MyHs);
                        model.MConfig.JTFHState = true;
                        DAL.MemberConfig.UpdateConfigTran(model.MID, "JTFHState", "1", model, true, SqlDbType.Bit, MyHs);
                        model.MConfig.DTFHState = true;
                        DAL.MemberConfig.UpdateConfigTran(model.MID, "DTFHState", "1", model, true, SqlDbType.Bit, MyHs);
                        model.MConfig.UpSumMoney += (int)sjmoney;
                        DAL.MemberConfig.UpdateConfigTran(model.MID, "UpSumMoney", sjmoney.ToString(), model, false, SqlDbType.Int, MyHs);

                        model.RoleCode = "Nomal";
                        model.Role = BLL.Roles.RolsList["Nomal"];
                        model.MDate = DateTime.Now;
                        model.MState = true;
                        ////增加分红包
                        //BLL.LuckyMoney.Add(model.MID, MyHs);
                        model.MSH = shmodel.MID;
                    }
                    if (shmoney != null)
                    {
                        // 二次升级的奖金按照升级之前的级别拿比例
                        model.AgencyCode = shmoney.MAgencyType;
                        model.MAgencyType = shmoney;
                    }
                    //if (!BLL.ChangeMoney.R_SJ(model, MyHs))
                    //{
                    DAL.Member.UpdateRole(model, MyHs);
                    //}
                    Model.Accounts account = new Model.Accounts()
                    {
                        AccountsDate = DateTime.MaxValue,
                        ACode = model.MID + "_" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                        CreateDate = DateTime.Now,
                        IfAccount = false,
                        IsAuto = true,
                        PCode = PCode,
                        TotalFHMoney = 0,
                        FHCount = 0,
                        ARemark = model.MID
                    };

                    BLL.Accounts.BDInsert(account, MyHs);

                    if (DAL.CommonBase.RunHashtable(MyHs))
                    {
                        DAL.Member.tempMemberList.Clear();//清空临时字典
                        Model.Member newmodel = DAL.Member.GetModel(mid);
                        //BLL.ChangeMoney.R_SJ(newmodel, newmodel);
                        ////升级
                        //if (newmodel.AgencyCode == "004")
                        //{
                        //BLL.ChangeMoney.R_SJ(newmodel);
                        //}
                        return "恭喜您激活成功，本次消耗" + sjmoney.ToString("F2");
                    }
                }
            }
            return "激活失败";
        }

        public string UpMAgencyType(Model.SHMoney shmoney, string mid, Model.Member shmodel, decimal appendMoney, Hashtable MyHs)
        {
            Model.Member model = DAL.Member.GetModel(mid);
            string agencyCode = model.AgencyCode;
            if (model == null)
                return "升会员不存在";
            if (string.IsNullOrEmpty(model.MTJ))
                return "请联系管理员设置您的推荐人";
            //int sjmoney = shmoney.Money - model.MAgencyType.Money;
            //这个地方修改，升级金额就是输入的追加投资的金额
            int sjmoney = int.Parse(decimal.Round(appendMoney, 0).ToString());
            lock (DAL.Member.tempMemberList)
            {
                if (!BLL.ChangeMoney.EnoughChange(shmodel.MID, sjmoney, "MJB"))
                {
                    return "您的" + BLL.Reward.List["MJB"].RewardName + "不足";
                }
                DAL.Member.tempMemberList.Clear();
                DAL.Member.tempMemberAdd(model);
                //if (BLL.ChangeMoney.HBChangeTran(sjmoney, shmodel.MID, ManageMember.TModel.MID, "SJ", model, "MJB", model.MAgencyType.MAgencyName + "->" + shmoney.MAgencyName, MyHs) >= 0)
                {
                    model.MConfig.YJMoney += sjmoney;
                    DAL.MemberConfig.UpdateConfigTran(model.MID, "YJMoney", sjmoney.ToString(), model, false, SqlDbType.Int, MyHs);
                    //DAL.MemberConfig.UpdateConfigTran(model.MTJ, "TJCount", "1", model, false, SqlDbType.Int, MyHs);
                    model.MConfig.UpSumMoney += sjmoney;
                    DAL.MemberConfig.UpdateConfigTran(model.MID, "UpSumMoney", sjmoney.ToString(), model, false, SqlDbType.Int, MyHs);
                    //model.SHMoney += sjmoney;
                    if (!model.MState)
                    {
                        string error = Validation2(model);
                        if (!string.IsNullOrEmpty(error))
                        {
                            return error;
                        }
                        model.MConfig.YJCount += 1;
                        DAL.MemberConfig.UpdateConfigTran(model.MID, "YJCount", "1", model, false, SqlDbType.Int, MyHs);
                        model.MConfig.JTFHState = true;
                        DAL.MemberConfig.UpdateConfigTran(model.MID, "JTFHState", "1", model, true, SqlDbType.Bit, MyHs);
                        model.MConfig.DTFHState = true;
                        DAL.MemberConfig.UpdateConfigTran(model.MID, "DTFHState", "1", model, true, SqlDbType.Bit, MyHs);

                        model.RoleCode = "Nomal";
                        model.Role = BLL.Roles.RolsList["Nomal"];
                        model.MDate = DateTime.Now;
                        model.MState = true;

                        //添加pop
                        //int growth = BLL.MMMConfig.Model.GrowthCount;
                        //Model.Member mtjmodel = DAL.Member.GetModel(model.MTJ);
                        //if (mtjmodel.MConfig.OfferQuota + growth > 60000)
                        //    growth = 60000 - Convert.ToInt32(mtjmodel.MConfig.OfferQuota);
                        //if (growth > 0)
                        //{
                        //    BLL.Member.UpdateConfigTran(model.MTJ, "OfferQuota", growth.ToString(), TModel, false, SqlDbType.Decimal, MyHs);
                        //}
                    }
                    // 二次升级的奖金按照升级之前的级别拿比例
                    model.AgencyCode = shmoney.MAgencyType;
                    model.MAgencyType = shmoney;

                    DAL.Member.UpdateRole(model, MyHs);
                    Model.Accounts account = new Model.Accounts()
                    {
                        AccountsDate = DateTime.MaxValue,
                        ACode = model.MID + "_" + DateTime.Now.ToString("yyyyMMddHHmmss"),
                        CreateDate = DateTime.Now,
                        IfAccount = false,
                        IsAuto = true,
                        PCode = "005",
                        TotalFHMoney = 0,
                        FHCount = 0,
                        ARemark = model.MID
                    };
                    BLL.Accounts.BDInsert(account, MyHs);

                    if (DAL.CommonBase.RunHashtable(MyHs))
                    {
                        DAL.Member.tempMemberList.Clear();//清空临时字典
                        BLL.ChangeMoney.R_SJ(mid);
                        //return "恭喜您成功升级至" + shmoney.MAgencyName + "，本次消耗" + sjmoney;
                        return "恭喜您激活成功";
                    }
                }
            }
            return "激活失败";
        }

        /// <summary>
        /// 配送股权
        /// </summary>
        /// <param name="member"></param>
        /// <param name="hs"></param>
        /// <returns></returns>
        public static Hashtable BMemberSend(Model.Member member, decimal stockCount, Hashtable hs)
        {
            Model.BMember bm = new Model.BMember();
            bm.AMember = member;
            bm.AMID = member.MID;
            bm.BIsClock = false;
            bm.BMCreateDate = DateTime.Now;
            bm.BMID = BLL.BMember.GetBMID(member);
            bm.BMState = true;
            bm.YJCount = stockCount;

            bm.YJMoney = 0;
            bm.BCount = stockCount * BLL.Configuration.Model.GPrice;
            bm.BMDate = DateTime.Now;
            bm.FHDays = 0;
            //每个商务股1000元，每天分红70元，分红满24天不再分红
            bm.BOutMoney = bm.BCount * BLL.Configuration.Model.DFHFloat * BLL.Configuration.Model.DFHOutCount;
            BLL.BMember.Insert(bm, hs);


            return hs;
        }


        public static bool TestMID(string mid)
        {
            return DAL.Member.TestMID(mid);
        }

        public static bool Insert(Model.Member model)
        {
            return DAL.Member.Insert(model);
        }


        /// <summary>
        /// 推荐人
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool Insert(Model.Member model, bool NeedEmail, ref string retStr)
        {
            if (model.AgencyCode == "001")
            {
                model.MState = false;
                model.RoleCode = BLL.Roles.RolsList["Notactive"].RType;
                model.MBDIndex = 1;
                model.MCreateDate = DateTime.Now;
                model.MDate = DateTime.MaxValue;
                model.MConfig = new Model.MemberConfig
                {
                    MID = model.MID,
                    JJTypeList = DAL.Reward.RewardStr,
                    DTFHState = true,
                    JTFHState = true,
                    TotalLDMoney = 0,
                    EPXingCount = 5
                };
                //if (model.MConfig.StockCount == 0)
                //{
                //    model.MConfig.StockCount = 1;
                //}
            }
            retStr = Validation(model);
            if (retStr != "")
                return false;
            string password = model.Password;
            string secpsd = model.SecPsd;
            if (string.IsNullOrEmpty(model.FMID))
            {
                model.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(model.Password + model.Salt, "MD5").ToUpper();
                model.SecPsd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(model.SecPsd + model.Salt, "MD5").ToUpper();
            }
            if (DAL.Member.Insert(model))
            {
                //Model.Member mtjmodel = DAL.Member.GetModel(model.MTJ);

                //retStr = "恭喜您注册成功，您的会员账号为：" + model.MID +
                //            "，一级密码是：" + password + "，二级密码是：" + secpsd + "！";
                //Model.SMS smsmodel = new Model.SMS { MID = model.MID, SContent = retStr, Email = model.Email, SType = Model.SMSType.QT };

                //BLL.Task.ManageSend(model, "尊敬的" + model.MID +
                //       "会员：恭喜成功注册，为了您的账户安全，请妥善保管您的密码，并且定期在[安全中心]修改密码，为了使您能够享受更多的服务，请及时购币激活账号，您的推荐人QQ号码：" + mtjmodel.QQ + "，手机号码：" + mtjmodel.Tel);

                //string emailerr = "";
                //if (NeedEmail)
                //    BLL.Email.Insert(smsmodel, ref emailerr);

                //emailerr = "恭喜您，会员账号" + model.MID + "成功注册为您伞下体验会员，请尽快协助新会员购币激活账号，谢谢合作！";
                //BLL.Task.ManageSend(mtjmodel, emailerr);
                //smsmodel = new Model.SMS { MID = mtjmodel.MID, SContent = emailerr, Email = mtjmodel.Email, SType = Model.SMSType.QT };
                //if (NeedEmail)
                //    BLL.Email.Insert(smsmodel, ref emailerr);
                return true;
            }
            return false;
        }

        /// <summary>
        /// 注册会员
        /// </summary>
        /// <param name="model"></param>
        /// <returns>返回注册成功之后的会员信息</returns>
        public Model.Member InsertAndReturnEntity(Model.Member model, bool NeedEmail, ref string retStr)
        {
            //是否可以注册

            if (string.IsNullOrEmpty(model.MID))
            {
                retStr = "会员帐号不能为空";
            }
            if (DAL.Member.GetModel(model.MID) != null)
            {
                retStr = "会员帐号已经存在";
            }
            Model.Member inserModel = null;
            if (model.AgencyCode == "001")
            {
                //model.MState = false;
                //自动生成会员账号 
                //model.MID = GetRandMemberMID("cx");

                //model.RoleCode = BLL.Roles.RolsList["Notactive"].RType;
                //model.MBDIndex = 0;
                model.MCreateDate = DateTime.Now;
                model.MDate = DateTime.MaxValue;
                model.MConfig = new Model.MemberConfig
                {
                    MID = model.MID,
                    JJTypeList = DAL.Reward.RewardStr,
                    DTFHState = true,
                    JTFHState = true,
                    TXStatus = true,
                    ZZStatus = true,
                    EPXingCount = 100,
                    TotalHLMoney = 0,
                    HLMoneyState = false,
                    PPLeavel = 0,
                    OfferQuota = 0,
                    SQCount = 0,
                    GLMoneyDate = DateTime.Now.AddDays(30)
                };
            }
            retStr = Validation(model);
            if (retStr != "")
                return inserModel;
            string password = model.Password;
            string secpsd = model.SecPsd;
            if (string.IsNullOrEmpty(model.FMID))
            {
                model.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(model.Password + model.Salt, "MD5").ToUpper();
                model.SecPsd = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(model.SecPsd + model.Salt, "MD5").ToUpper();
            }
            if (DAL.Member.Insert(model))
            {
                //Model.Member mtjmodel = DAL.Member.GetModel(model.MTJ);
                inserModel = DAL.Member.GetModel(model.MID);

                ////retStr = "恭喜您注册成功，您的会员账号为：" + model.MID +
                ////            "，一级密码是：" + password + "，二级密码是：" + secpsd + "！";
                //Model.SMS smsmodel = new Model.SMS { MID = model.MID, SContent = retStr, Email = model.Email, SType = Model.SMSType.QT };

                //BLL.Task.ManageSend(model, "尊敬的" + model.MID +
                //       "会员：恭喜成功注册，为了您的账户安全，请妥善保管您的密码，并且定期在[安全中心]修改密码，为了使您能够享受更多的服务，请及时购币激活账号，您的推荐人QQ号码：" + mtjmodel.QQ + "，手机号码：" + mtjmodel.Tel);

                //string emailerr = "";
                //if (NeedEmail)
                //    BLL.Email.Insert(smsmodel, ref emailerr);

                //emailerr = "恭喜您，会员账号" + model.MID + "成功注册为您伞下体验会员，请尽快协助新会员购币激活账号，谢谢合作！";
                //BLL.Task.ManageSend(mtjmodel, emailerr);
                //smsmodel = new Model.SMS { MID = mtjmodel.MID, SContent = emailerr, Email = mtjmodel.Email, SType = Model.SMSType.QT };
                //if (NeedEmail)
                //    BLL.Email.Insert(smsmodel, ref emailerr);
            }
            return inserModel;
        }

        /// <summary>
        /// 得到会员的累记提现申请总额
        /// </summary>
        /// <param name="Mid"></param>
        /// <returns></returns>
        public int GetAllTX()
        {
            return DAL.ChangeMoney.GetAllTx(TModel.MID);
        }

        /// <summary>
        /// 得到会员对象
        /// </summary>
        /// <param name="MID"></param>
        /// <returns></returns>
        public Model.Member GetModel(string MID)
        {
            return DAL.Member.GetModel(MID);
        }

        /// <summary>
        /// 得到会员对象
        /// </summary>
        /// <param name="MID"></param>
        /// <returns></returns>
        public static Model.Member GetModelByMID(string MID)
        {
            return DAL.Member.GetModel(MID);
        }

        public static bool IsPhoneExist(string tel)
        {
            return DAL.Member.IsPhoneExist(tel);
        }

        /// <summary>
        /// 得到个人信息
        /// </summary>
        /// <returns></returns>
        public Model.Member GetSelf()
        {
            if (TModel == null)
                return null;
            Model.Member model = DAL.Member.GetModel(TModel.MID);
            if (model != null && !model.Role.Super)
            {
                if (string.IsNullOrEmpty(model.TempThrPsd) || model.ThrPsd != model.TempThrPsd)
                {
                    if (!model.IsClose)
                    {
                        model.IsClose = true;
                        MemberClose(model);
                        string Msg = "会员：" + model.MID + "于当前时间[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]账号异常，已锁定，未冻结";
                        Model.SMS smsmodel = new Model.SMS { SType = Model.SMSType.ZCYZ, Tel = BLL.WebBase.Model.MonitorTel, SContent = Msg };
                        string error = "";
                        if (BLL.SMS.Insert(smsmodel, ref error))
                        {
                            Msg += "[已发送您手机]";
                        }
                        Task.SendManage(model, "001", Msg);

                    }
                    return null;
                }

            }
            return model;
        }
        #region 会员集合查询

        /// <summary>
        /// 得到会员实体列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<Model.Member> GetMemberEntityList(string strWhere)
        {
            return DAL.MemberCollection.GetMemberEntityList(strWhere);
        }

        public static List<Model.Member> GetMemberList(string strWhere)
        {
            return DAL.MemberCollection.GetMemberEntityList(strWhere);
        }

        /// <summary>
        /// 得到会员实体列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public List<Model.Member> GetMemberAndConfigEntityList(string strWhere)
        {
            return DAL.MemberCollection.GetMemberAndConfigEntityList(strWhere);
        }

        /// <summary>
        /// 得到分页会员信息实体列表
        /// </summary>
        /// <param name="strWhere">查询条件</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">页大小</param>
        /// <param name="count">out类型总计</param>
        /// <returns>返回会员List集合</returns>
        public List<Model.Member> GetMemberEntityList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.MemberCollection.GetMemberEntityList(strWhere, pageIndex, pageSize, out count);
        }

        #endregion


        #region 会员权限查询及验证


        /// <summary>
        /// 验证权限
        /// </summary>
        /// <returns></returns>
        public bool VerifyUrl(string url)
        {
            return BLL.Roles.VerifyUrl(TModel.RoleCode, url.ToUpper());
        }

        /// <summary>
        /// 得到权限资源实体列表
        /// </summary>
        /// <returns></returns>
        public static bool VerifyPower(System.Web.HttpContext context, BLL.Member model)
        {
            if (model != null && model is BLL.Member)
            {
                return BLL.Roles.VerifyPower(model.TModel, context.Request.Url.AbsolutePath.ToUpper());
            }
            return false;
        }

        public List<Model.Notice> GetNoticeEntityList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.Notice.GetNoticeEntityList(strWhere, pageIndex, pageSize, out count);
        }

        #endregion


        #region 会员奖金及附属信息查询

        /// <summary>
        /// 得到提现实体列表
        /// </summary>
        /// <returns></returns>
        public List<Model.ChangeMoney> GetChangeMoneyEntityList(string frommid, string tomid, string shmid, string state, List<string> TypeList, List<string> mType, int pageIndex, int pageSize, string strWhere, out int count)
        {
            return DAL.ChangeMoneyCollection.GetChangeMoneyEntityList(frommid, tomid, shmid, state, TypeList, mType, pageIndex, pageSize, strWhere, out count);
        }
        /// <summary>
        /// 奖金信息
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public Dictionary<string, decimal> GetJJInfo(string mid, List<string> ChangeTypeList, List<string> NeedTakeOff, string startDate, string endDate)
        {
            return DAL.ChangeMoney.GetJJInfo(mid, ChangeTypeList, NeedTakeOff, startDate, endDate);
        }
        /// <summary>
        /// 会员直绑定数
        /// </summary>
        /// <param name="MBD"></param>
        /// <returns></returns>
        public static int GetMBDCount(string MBD, bool MState)
        {
            return DAL.Member.GetBDCount(MBD, MState);
        }
        #endregion

        /// <summary>
        /// 服务中心
        /// </summary>
        /// <param name="shmid">待服务中心ID</param>
        /// <returns></returns>
        public string SHMember(string shmid)
        {
            return BLL.ChangeMoney.SHMember(TModel, shmid);
        }

        public static string GetTestMID()
        {
            Random rand = new Random();
            string mid = "" + rand.Next(10000000, 99999999).ToString();
            while (DAL.Member.TestMID(mid))
            {
                mid = "" + rand.Next(10000000, 99999999).ToString();
            }
            return mid;
        }
        public static string GetTestMID2(int i)
        {
            Random rand = new Random(i);
            string mid = "" + rand.Next(10000000, 99999999).ToString();
            while (DAL.Member.TestMID(mid))
            {
                mid = "" + rand.Next(10000000, 99999999).ToString();
            }
            return mid;
        }

        public List<Model.Task> GetTaskEntityList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.Task.GetTaskEntityList(strWhere, pageIndex, pageSize, out count);
        }

        public Model.Task GetReplyTask(int id)
        {
            return DAL.Task.GetReplyTask(id);
        }

        public string HideTask(string idlist)
        {
            if (DAL.Task.HideTask(idlist))
                return "操作成功";
            return "操作失败";
        }

        public string ShowTask(string idlist)
        {
            if (DAL.Task.ShowTask(idlist))
                return "操作成功";
            return "操作失败";
        }
        public string ReadTask(string idlist)
        {
            if (DAL.Task.ReadTask(idlist))
                return "操作成功";
            return "操作失败";
        }
        public string NoReadTask(string idlist)
        {
            if (DAL.Task.NoReadTask(idlist))
                return "操作成功";
            return "操作失败";
        }

        /// <summary>
        /// 服务中心提现
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public string ShTx(string cidList)
        {
            return ChangeMoney.ShTx(cidList);
        }

        /// <summary>
        /// 删除会员
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public string DeleteMember(string midList)
        {
            if (TModel.Role.IsAdmin)
                return DAL.Member.DeleteMember(midList);
            return "操作失败";
        }
        /// <summary>
        /// 删除会员
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public string DeleteMemberW(string midList)
        {
            return DAL.Member.DeleteMemberW(midList, this.TModel.MID);
        }

        /// <summary>
        /// 修改配置信息
        /// </summary>
        /// <param name="ConfigurationModel"></param>
        /// <returns></returns>
        public bool UpdateConfiguration(WE_Project.Model.Configuration ConfigurationModel)
        {
            return DAL.Configuration.Update(ConfigurationModel);
        }

        /// <summary>
        /// 初始化系统
        /// </summary>
        /// <returns></returns>
        public bool ReSetSys()
        {
            return DAL.Member.ReSetSys(TModel);
        }

        public string HideNotice(string IDList)
        {
            if (DAL.Notice.HideNotice(IDList))
                return "操作成功";
            return "操作失败";
        }

        public object ShowNotice(string IDList)
        {
            if (DAL.Notice.ShowNotice(IDList))
                return "操作成功";
            return "操作失败";
        }

        public object DeleteNotice(string IDList)
        {
            if (DAL.Notice.DeleteNotice(IDList))
                return "操作成功";
            return "操作失败";
        }

        //public string FH(Model.FHList fhModel, bool isInsert)
        //{
        //    DAL.Member.tempMemberList.Clear();
        //    lock (DAL.Member.tempMemberList)
        //    {
        //        return BLL.ChangeMoney.FHChangeTran(fhModel, isInsert);
        //    }
        //}
        public string DeleteChangeMoney(string cidlist)
        {
            if (DAL.ChangeMoney.Delete(cidlist))
                return "删除成功";
            return "删除失败";
        }

        public string DeleteTask(string idlist)
        {
            if (DAL.Task.DeleteTask(idlist))
                return "操作成功";
            return "操作失败";
        }

        public string SetVerify(string cidList, string mType)
        {
            if (DAL.Roles.SetVerify(cidList, mType))
            {
                DAL.Roles.RolsList = null;
                return "操作成功";
            }
            return "操作失败";
        }

        /// <summary>
        /// 自动排列
        /// </summary>
        /// <returns></returns>
        public static string GetMBD(string mtjmid)
        {
            return DAL.Member.GetMBD(mtjmid, BLL.Configuration.Model.BDCount);
        }

        public List<Model.BankModel> GetMyBankInfo()
        {
            return BLL.BankModel.GetList(string.Format(" MID='{0}' order by IsPrimary desc,BankCreateDate asc ", this.TModel.MID));
        }

        public string SHHKModel(string hkCodeStr)
        {
            string[] hkCodeList = hkCodeStr.Split(',');
            Hashtable MyHs = new Hashtable();
            Dictionary<Model.Member, decimal> midlist = new Dictionary<Model.Member, decimal>();
            foreach (string hkcode in hkCodeList)
            {
                Model.HKModel model = BLL.HKModel.GetModel(hkcode);
                if (model == null)
                    continue;
                if (!model.HKState)
                {
                    Model.Member member = DAL.Member.GetModel(model.MID);
                    model.HKState = true;
                    model.ConfirmTime = DateTime.Now;
                    if (model.HKType == 1)//如果是激活且未激活
                    {
                        //排单币
                        BLL.ChangeMoney.CZMoneyChange(BLL.Member.ManageMember.TModel.MID, model.MID, model.ValidMoney, "MGP", MyHs);
                    }
                    else
                    {
                        BuyActiveCode(model, MyHs);
                    }
                    BLL.HKModel.Update(model, MyHs);
                    midlist.Add(member, model.ValidMoney);
                }
            }
            if (!DAL.CommonBase.RunHashtable(MyHs))
            {
                return "操作失败";
            }
            foreach (KeyValuePair<Model.Member, decimal> mid in midlist)
            {
                //BLL.Task.SendManage(mid.Key, "001", "会员于当前时间向公司汇款人民币：" + mid.Value.ToString());
                BLL.Task.ManageSend(mid.Key, "尊敬的会员：" + mid.Key.MID + ",您的汇款记录已于当前时间" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "成功审核，请及时查看您的账户信息，如有疑问，请联系客服");
            }
            return "操作成功";
        }

        public Hashtable BuyActiveCode(Model.HKModel model, Hashtable MyHs)
        {
            for (int i = 0; i < model.ValidMoney; i++)
            {
                Model.ActiveCode Acode = new Model.ActiveCode();
                Acode.Code = GetGUID();
                Acode.CreateTime = DateTime.Now;
                Acode.UseState = 0;
                Acode.MID = model.MID;
                Acode.SwitchType = "第三方支付购买";
                if (BLL.CommonBase.GetSingle("select id from ActiveCode where Code='" + Acode.Code + "'") != null)
                {
                    Acode.Code = Guid.NewGuid().ToString().Replace("-", "").Replace(" ", "").ToUpper().Substring(0, 15);
                }
                BLL.ActiveCode.Insert(Acode, MyHs);
                BLL.ChangeMoney.InsertTran(new Model.ChangeMoney { FromMID = TModel.MID, ToMID = model.MID, CompleteTime = DateTime.Now, ChangeType = "Active", MoneyType = "Active", CRemarks = Acode.Code, ChangeDate = DateTime.Now, CState = true }, MyHs);
            }
            return MyHs;
        }

        private List<string> guidlist = new List<string>();
        private string GetGUID()
        {
            string guid = Guid.NewGuid().ToString().Replace("-", "").Replace(" ", "").ToUpper().Substring(0, 10);
            if (guidlist.Contains(guid))
                guid = GetGUID();
            return guid;
        }

        public bool SHPayHB(string code)
        {
            Model.HKModel model = BLL.HKModel.GetModel(code);
            if (model == null)
                return false;
            if (!model.HKState)
            {
                guidlist.Clear();
                Hashtable MyHs = new Hashtable();
                Model.Member member = DAL.Member.GetModel(model.MID);
                model.HKState = true;
                model.HKDate = DateTime.Now;
                if (model.HKType == 1)//如果是激活且未激活
                {
                    for (int i = 0; i < model.ValidMoney; i++)
                    {
                        Model.ActiveCode Acode = new Model.ActiveCode();
                        Acode.Code = GetGUID();
                        Acode.CreateTime = DateTime.Now;
                        Acode.UseState = 0;
                        Acode.MID = model.MID;
                        if (BLL.CommonBase.GetSingle("select id from ActiveCode where Code='" + Acode.Code + "'") != null)
                        {
                            Acode.Code = Guid.NewGuid().ToString().Replace("-", "").Replace(" ", "").ToUpper().Substring(0, 10);
                        }
                        BLL.ActiveCode.Insert(Acode, MyHs);
                        BLL.ChangeMoney.InsertTran(new Model.ChangeMoney { FromMID = TModel.MID, ToMID = model.MID, CompleteTime = DateTime.Now, ChangeType = "Active", MoneyType = "Active", CRemarks = Acode.Code, ChangeDate = DateTime.Now, CState = true }, MyHs);
                    }
                }
                BLL.HKModel.Update(model, MyHs);

                if (BLL.CommonBase.RunHashtable(MyHs))
                {
                    MyHs.Clear();
                    if (!member.MState)
                    {
                        List<Model.ActiveCode> codeList = BLL.ActiveCode.GetTopList("UseState=0 and MID='" + member.MID + "'", 1);
                        if (codeList.Count > 0)
                        {
                            codeList[0].UseMID = member.MID;
                            codeList[0].UseState = 2;
                            codeList[0].UseTime = DateTime.Now;
                            BLL.ActiveCode.Update(codeList[0], MyHs);
                            BLL.Member.ManageMember.UpMAgencyType(BLL.Configuration.Model.SHMoneyList["002"], member.MID, BLL.Member.ManageMember.TModel, 0, MyHs);
                            //BLL.CommonBase.RunHashtable(MyHs);
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        public string DeleteHKModel(string hkCodeStr)
        {
            hkCodeStr = hkCodeStr.Replace(",", "','"); ;
            Hashtable MyHs = new Hashtable();
            BLL.HKModel.Delete("'" + hkCodeStr + "'", MyHs);
            if (DAL.CommonBase.RunHashtable(MyHs))
                return "操作成功";
            return "操作失败";
        }


        public static string Validation(Model.Member shmodel)
        {
            if (DAL.Member.GetModel(shmodel.MID) != null)
            {
                return "已存在该ID会员";
            }
            string error = "";
            if (!DAL.CommonBase.TestSql(shmodel.MID, ref error) || shmodel.MID.Contains("-") || shmodel.MID.Contains("_"))
                return "会员ID不合法，请重新设置";
            Model.Member MTJ = DAL.Member.GetModel(shmodel.MTJ);
            //Model.Member MSH = DAL.Member.GetModel(shmodel.MSH);
            //Model.Member MBD = DAL.Member.GetModel(shmodel.MBD);

            if (MTJ == null || !MTJ.MState)
            {
                return "不存在该推荐人";
            }
            //if (MSH == null || !MSH.MState || !MSH.Role.CanSH)
            //{
            //    return "不存在该报单中心或其没有审核权限";
            //}
            //if (MBD == null)
            //{
            //    return "不存在该接点人";
            //}
            return "";
        }

        public static string Validation2(Model.Member shmodel)
        {

            if (shmodel.MState)
                return "该会员已经是正式会员了";

            Model.Member MTJ = DAL.Member.GetModel(shmodel.MTJ);
            //Model.Member MSH = DAL.Member.GetModel(shmodel.MSH);
            //Model.Member MBD = DAL.Member.GetModel(shmodel.MBD);

            if (MTJ == null || (!MTJ.MState && MTJ.AgencyCode != "001"))
            {
                return "不存在该推荐人";
            }
            //if (MSH == null || !MSH.MState || !MSH.Role.CanSH)
            //{
            //    return "不存在该报单中心或其没有审核权限";
            //}
            //while (MBD == null || !MBD.MState || MBD.AgencyCode == "001")
            //{
            //    MBD = DAL.Member.GetModel(MBD.MTJ);
            //}
            //if (shmodel.MBDIndex == 1)
            //{
            //    shmodel.MBD = BLL.Member.GetMBD2(MBD.MID);
            //}
            //else if (shmodel.MBDIndex == 2)
            //{
            //    string mbdtemp = BLL.Member.GetMBD(MBD.MID);
            //    if (mbdtemp != MBD.MID)
            //    {
            //        List<Model.Member> list = DAL.MemberCollection.GetMemberEntityList("MBD='" + MBD.MID + "' and MState='1' order by MBDIndex desc");
            //        shmodel.MBD = BLL.Member.GetMBD2(list[0].MID);
            //    }
            //    shmodel.MBDIndex = BLL.Member.GetMBDCount(shmodel.MBD, true) + 1;
            //}
            //else
            //{
            //shmodel.MBD = BLL.Member.GetMBD(MBD.MID);
            //shmodel.MBDIndex = BLL.Member.GetMBDCount(shmodel.MBD, true) + 1;
            //return "安置位置错误！";
            //}
            return "";
        }
        public static string GetMBD2(string mtjmid)
        {
            return DAL.Member.GetMBD2(mtjmid, 1);
        }

        public bool MemberHBClear()
        {
            return DAL.Member.MemberHBClear();
        }

        public bool MemberHBToJB()
        {
            return DAL.Member.MemberHBToJB();
        }

        public DataTable GetPowers(string strWhere, string mType)
        {
            return DAL.Roles.GetPowers(strWhere, mType);
        }

        public string GrantVerify(string cidList, string mType)
        {
            return DAL.Roles.GrantPowers(cidList, mType);
        }

        public static decimal GetTypeSumJJ(string mid, string type, DateTime day)
        {
            return DAL.Member.GetTypeSumJJ(mid, type, day);
        }

        public static string Accounts(string CodeList)
        {
            int success = 0, fail = 0;
            foreach (string str in CodeList.Split(','))
            {
                Model.Accounts account = DAL.Accounts.GetModel(str);
                if (!account.IfAccount)
                {
                    Hashtable MyHs = new Hashtable();
                    account.IsAuto = false;
                    BLL.Accounts.Update(account, MyHs);
                    if (BLL.CommonBase.RunHashtable(MyHs))
                    {
                        success++;
                    }
                    else
                    {
                        fail++;
                    }
                }
            }
            return "成功：" + success + ";失败：" + fail + ";";
        }

        public int GetLevelForView(string mid, bool viewType)
        {
            return DAL.Member.GetLevelForView(this.TModel, mid, viewType);
        }

        public List<Model.ChangeMoney> GetChangeMoneyEntityList(string StrWhere)
        {
            return DAL.ChangeMoneyCollection.GetChangeMoneyEntityList(StrWhere);
        }
        public List<Model.ChangeMoney> GetChangeMoneyEntityList(int top, string StrWhere)
        {
            return DAL.ChangeMoneyCollection.GetChangeMoneyEntityList(top, StrWhere);
        }

        public List<Model.ChangeMoney> GetTopChangeMoneyEntityList(int top, string StrWhere)
        {
            return DAL.ChangeMoneyCollection.GetTopChangeMoneyEntityList(top, StrWhere);
        }

        public Hashtable UpdateBankInfo(Model.Member model, Hashtable MyHs)
        {
            return DAL.Member.UpdateBankInfo(model, MyHs);
        }

        public string Recover(string mids)
        {
            string[] midlist = mids.Split(',');
            Hashtable MyHs = new Hashtable();
            foreach (string item in midlist)
            {
                Model.Member model = DAL.Member.GetModel(item);
                if (model != null && model.FMID == this.TModel.MID)
                {
                    model.Password = this.TModel.Password;
                    model.SecPsd = this.TModel.SecPsd;
                    model.Salt = this.TModel.Salt;
                    DAL.Member.Update(model, MyHs);
                }
            }
            if (BLL.CommonBase.RunHashtable(MyHs))
                return "恢复成功";
            return "恢复失败";
        }

        public static Hashtable UpdateConfigTran(string mid, string fieldName, string fieldValue, Model.Member shmodel, bool isEqual, SqlDbType dataType, Hashtable MyHs)
        {
            return DAL.MemberConfig.UpdateConfigTran(mid, fieldName, fieldValue, shmodel, isEqual, dataType, MyHs);
        }

        public static Hashtable UpdateTran(string mid, string fieldName, string fieldValue, Model.Member shmodel, bool isEqual, SqlDbType dataType, Hashtable MyHs)
        {
            return DAL.Member.UpdateTran(mid, fieldName, fieldValue, shmodel, isEqual, dataType, MyHs);
        }

        public static bool ChangeMemberRole(Model.Member model)
        {
            return DAL.Member.Update(model);
        }
        public static Hashtable ChangeMemberRole(Model.Member model, Hashtable hs)
        {
            return DAL.Member.Update(model, hs);
        }
        public static Hashtable ChangeMemberAgencyCode(Model.Member model, Hashtable hs)
        {
            return DAL.Member.Update(model, hs);
        }
        /// <summary>
        /// 得到区域总监编号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int GetRegionCount(Model.Member model)
        {
            return GetRegionHeaderList(model).Count + 1;
        }
        /// <summary>
        /// 得到某个会员区域总监列表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<Model.Member> GetRegionHeaderList(Model.Member model)
        {
            return GetRegionHeaderList(model.Province);
        }
        /// <summary>
        /// 得到某个省份的区域总监，参数为空则是查询所有区域总监
        /// </summary>
        /// <param name="Province"></param>
        /// <returns></returns>
        public static List<Model.Member> GetRegionHeaderList(string Province)
        {
            if (string.IsNullOrEmpty(Province))
            {
                return new BLL.Member().GetMemberEntityList(" MState=1 and IsClock=0 and IsClose=0 and MID in (select MID from MemberConfig where IsRegionalDirector=1)");
            }
            else
            {
                return new BLL.Member().GetMemberEntityList("Province='" + Province + "' and  MState=1 and IsClock=0 and IsClose=0 and MID in (select MID from MemberConfig where IsRegionalDirector=1)");
            }
        }

        public static DataTable GetRegionHeaderList2(string province, string mid)
        {
            string sql = "select t1.MID,t1.Province,t2.Region,t3.MQQGroup from Member t1 left join  MemberConfig t2 on t1.MID=t2.MID left join MemberApply t3 on t1.MID=t3.MID where t1.MState=1 and t1.IsClock=0 and t1.IsClose=0 and t3.ApplyType=1 and t3.State=2 and t1.MID in (select MID from MemberConfig where IsRegionalDirector=1)";
            if (!string.IsNullOrEmpty(province))
            {
                sql += " and t1.Province like '%" + province + "%'";
            }
            if (!string.IsNullOrEmpty(mid))
            {
                sql += " and t1.MID like '%" + mid + "%'";
            }
            return DAL.CommonBase.GetTable(sql);
        }

        public static string ResetFDTrade(string mid)
        {
            Model.Member member = DAL.Member.GetModel(mid);
            if (member.MConfig.MJJ < 20)
            {
                return "重置需扣除20EP币，您当前EP余额不足无法重置";
            }
            Hashtable MyHs = new Hashtable();
            DAL.MemberConfig.UpdateConfigTran(mid, "MHB", "-20", null, false, SqlDbType.Decimal, MyHs);
            DAL.MemberConfig.UpdateConfigTran(mid, "FDTrade", "A", null, false, SqlDbType.VarChar, MyHs);
            if (DAL.CommonBase.RunHashtable(MyHs))
            {
                return "重置成功";
            }
            else
            {
                return "重置失败";
            }
        }

        public string GetRandMemberMID(string strWhere, string midpara = "")
        {
            midpara = strWhere + new Random().Next(10000000, 99999999).ToString();
            if (!string.IsNullOrEmpty(midpara) && !IsExist(midpara))
            {
                GetRandMemberMID(strWhere);
            }
            return midpara;
        }

        //判断会员账号是否存在
        public bool IsExist(string mid)
        {
            string sql = "select Count(1) from Member where MID='" + mid + "'";
            object obj = DAL.CommonBase.GetSingle(sql);
            if (int.Parse(obj.ToString()) > 0)
            {
                return false;
            }
            else
                return true;
        }

        public static void DeleteMemberWhen24HourNoActive()
        {
            List<Model.Member> listMember = DAL.MemberCollection.GetMemberEntityList("AgencyCode='001' and RoleCode='Notactive' and MState=0 and datediff(HH,MCreateDate,GETDATE())>=24");
            if (listMember != null && listMember.Count > 0)
            {
                string deleteId = string.Empty;
                foreach (Model.Member mem in listMember)
                    deleteId += mem.MID + ",";
                DAL.Member.DeleteMember(deleteId);
            }
        }

        public static string CostMHB(string midList, string money)
        {
            Hashtable MyHs = new Hashtable();
            decimal mone = 0;
            bool m = decimal.TryParse(money, out mone);
            if (!m)
            {
                return "操作失败：您输入的金额不合规范。";
            }
            foreach (string mid in midList.Split(','))
            {
                if (!string.IsNullOrEmpty(mid))
                {
                    if (mone > 0)
                        BLL.ChangeMoney.CZMoneyChange(BLL.Member.ManageMember.TModel.MID, mid, decimal.Parse(money), "MHB", MyHs);
                    else
                        BLL.ChangeMoney.KFMoneyChange(mid, BLL.Member.ManageMember.TModel.MID, Math.Abs(decimal.Parse(money)), "MHB", MyHs);
                }
            }
            if (BLL.CommonBase.RunHashtable(MyHs))
            {
                return "操作成功";
            }
            else
            {
                return "操作失败";
            }
        }

        public string reCountYJCount()
        {
            string sql = "update Member set MBD=MTJ;update MemberConfig set YJCount=0,YJMoney=0";
            CommonBase.RunSql(sql);
            List<Model.Member> list = GetMemberEntityList("RoleCode<>'Notactive'");
            foreach (Model.Member model in list)
            {
                resetCount(model);
            }
            return "操作成功";
        }

        public void resetCount(Model.Member mem)
        {
            //找到上级会员（推荐关系）
            Model.Member MTJ = GetModel(mem.MTJ);
            if (MTJ != null)
            {
                string sql = "update MemberConfig set YJCount=YJCount+1,YJMoney=YJMoney+" + mem.SHMoney.ToString() + " where MID='" + MTJ.MID + "'";
                CommonBase.RunSql(sql);
                if (!MTJ.Role.IsAdmin)
                {
                    resetCount(MTJ);
                }
            }
        }

        public static int GetTJCount(string mid, string agencyCode)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select COUNT(*) from Member where MTJ = '" + mid + "' and AgencyCode >= '" + agencyCode + "' ");
            object obj = CommonBase.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return 0;
            }
        }

        public static int GetSumCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select COUNT(*) from Member ");
            if (!string.IsNullOrEmpty(strWhere))
            {
                strSql.AppendFormat(" where {0} ", strWhere);
            }
            object obj = CommonBase.GetSingle(strSql.ToString());
            if (obj != null)
            {
                return Convert.ToInt32(obj);
            }
            else
            {
                return 0;
            }
        }
    }
}
