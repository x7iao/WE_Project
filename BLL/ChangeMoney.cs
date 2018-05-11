using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;
using System.Reflection;

namespace WE_Project.BLL
{
    public class ChangeMoney
    {

        #region 与数据库存储相关

        /// <summary>
        /// 添加货币转移记录哈希表
        /// </summary>
        /// <returns></returns>
        public static Hashtable InsertTran(Model.ChangeMoney model, Hashtable MyHs)
        {
            return DAL.ChangeMoney.InsertTran(model, MyHs);
        }

        /// <summary>
        /// 得到转移对象
        /// </summary>
        /// <param name="CID"></param>
        /// <returns></returns>
        public static Model.ChangeMoney GetModel(int CID)
        {
            return DAL.ChangeMoney.GetModel(CID);
        }

        public static Model.ChangeMoney GetTopModel(string changetype, bool cstate, string MID)
        {
            return DAL.ChangeMoney.GetTopModel(changetype, cstate, MID);
        }

        /// <summary>
        /// 改变提现申请状态为已审核哈希表
        /// </summary>
        /// <param name="CID"></param>
        /// <returns></returns>
        public static Hashtable UpdataTran(Model.ChangeMoney model, Hashtable MyHs)
        {
            return DAL.ChangeMoney.UpdataTran(model, MyHs);
        }

        #endregion

        # region 获取统计数据方法

        /// <summary>
        /// 获得当前获取的奖金总额
        /// </summary>
        /// <param name="mid">会员帐号</param>
        /// <param name="type">奖金类型，默认为所有</param>
        /// <param name="day">哪一天(0:当天,1:昨天,2:前天...)</param>
        /// <returns></returns>
        public static decimal GetDayFHMoney(string mid, string type, int? day, string dateType = "DD")
        {
            return DAL.ChangeMoney.GetDayFHMoney(mid, type, day, dateType);
        }

        # endregion 获取统计数据方法

        #region 会员业务操作

        /// <summary>
        /// 申请提现
        /// </summary>
        /// <param name="money"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string TXChange(int money, Model.Member model)
        {
            if (!EnoughChange(model.MID, money, "MJB"))
                return "您的可用" + BLL.Reward.List["MJB"].RewardName + "不足";
            if (money < DAL.Configuration.TModel.TXMinMoney)
                return "最少提现金额" + DAL.Configuration.TModel.TXMinMoney;
            else if ((money - DAL.Configuration.TModel.TXMinMoney) % DAL.Configuration.TModel.TXBaseMoney != 0)
                return "提现金额应是" + DAL.Configuration.TModel.TXBaseMoney + "的倍数";

            if (DAL.CommonBase.RunHashtable(TXChangeTran(money, model, true)))
            {
                return "提交成功，请等待系统管理员审核！";
            }
            return "操作失败";
        }

        # region

        public static Hashtable JJChangeTran(decimal jjmoney, string changetype, string moneyType, Model.Member tmodel, Model.Member shmodel, string remarks, string cfileds, string cfileds2, Hashtable MyHs)
        {
            Model.ChangeMoney changemoney = new Model.ChangeMoney()
            {
                ChangeDate = DateTime.Now,
                ChangeType = changetype,
                CState = false,
                FromMID = BLL.Member.ManageMember.TModel.MID,
                ToMID = tmodel.MID,
                Money = jjmoney,
                MoneyType = moneyType,
                SHMID = shmodel.MID,
                CRemarks = remarks,
                CFileds = cfileds,
                CFileds2 = cfileds2,
                CompleteTime = DateTime.MaxValue,
            };

            //获取当月奖金总额
            decimal money = GetDayFHMoney(tmodel.MID, "'R_GL','R_TJ'", 0, "MM");
            if (money + changemoney.Money > tmodel.MAgencyType.DTopMoney)
            {
                changemoney.Money = tmodel.MAgencyType.DTopMoney - money;
                if (changemoney.Money <= 0)
                {
                    changemoney.Money = 0;
                    return MyHs;
                }
            }

            return InsertTran(changemoney, MyHs);
        }

        # endregion

        /// <summary>
        /// 申请提现哈希表
        /// </summary>
        /// <param name="money"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public static Hashtable TXChangeTran(int money, Model.Member model, bool ifSendMsg)
        {
            Model.ChangeMoney changemoney = new Model.ChangeMoney();
            changemoney.ChangeDate = DateTime.Now;
            changemoney.ChangeType = "TX";
            changemoney.FromMID = model.MID;
            changemoney.Money = money;
            changemoney.MoneyType = "MJB";
            changemoney.CState = false;
            changemoney.ToMID = BLL.Member.ManageMember.TModel.MID;
            string bankName = model.Bank;

            Model.BankModel ban = BLL.BankModel.GetList("mid='" + model.MID + "' and IsPrimary=1").FirstOrDefault();
            if (ban != null)
            {
                bankName = new CommonBLL.Sys_BankInfoBLL().GetModel(ban.Bank).Name;
            }
            //changemoney.CRemarks = model.Bank + "~" + model.Branch + "~" + model.BankCardName + "~" + model.BankNumber;
            //try
            //{
            //    bankName = new CommonBLL.Sys_BankInfoBLL().GetModel(model.Bank).Name;
            //}
            //catch
            //{

            //}
            changemoney.CRemarks = bankName + "~" + model.Branch + "~" + model.BankCardName + "~" + model.BankNumber;
            Hashtable MyHs = new Hashtable();
            TakeOffMoneyTran(changemoney, model, BLL.Member.ManageMember.TModel, null, MyHs);
            //DAL.Member.UpdateBankInfo(model, MyHs);

            if (ifSendMsg)
            {
                BLL.Task.SendManage(model, "001", "您好，会员:" + model.MID + "于当前时间" +
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "申请提现:" + money + ",实发金额:" + (changemoney.Money - changemoney.TakeOffMoney) +
                    "，请及时汇款，人民币为" + money + "，实发金额" + ((changemoney.Money - changemoney.TakeOffMoney)));
            }
            return InsertTran(changemoney, MyHs);
        }

        public static string EPChange(int money, Model.Member model)
        {
            if (!EnoughChange(model.MID, money, "MJJ"))
                return "您的可用" + BLL.Reward.List["MHB"].RewardName + "不足";
            if (money < DAL.Configuration.TModel.TXMinMoney)
                return "最少挂卖金额" + DAL.Configuration.TModel.TXMinMoney;
            else if ((money - DAL.Configuration.TModel.TXMinMoney) % DAL.Configuration.TModel.TXBaseMoney != 0)
                return "挂卖金额应是" + DAL.Configuration.TModel.TXBaseMoney + "的倍数";

            if (DAL.CommonBase.RunHashtable(EPChangeTran(money, model, true)))
            {
                return "提交成功！";
            }
            return "操作失败";
        }

        public static Hashtable EPChangeTran(int money, Model.Member model, bool ifSendMsg)
        {
            Model.ChangeMoney changemoney = new Model.ChangeMoney();
            changemoney.ChangeDate = DateTime.Now;
            changemoney.ChangeType = "EP";
            changemoney.FromMID = model.MID;
            changemoney.Money = money;
            changemoney.MoneyType = "MHB";
            changemoney.CState = false;
            changemoney.ToMID = "";

            Hashtable MyHs = new Hashtable();
            TakeOffMoneyTran(changemoney, model, BLL.Member.ManageMember.TModel, null, MyHs);
            DAL.Member.UpdateBankInfo(model, MyHs);

            if (ifSendMsg)
            {
                BLL.Task.SendManage(model, "001", "会员:" + model.MID + "于当前时间" +
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "申请挂卖:" + money);
            }
            return InsertTran(changemoney, MyHs);
        }

        /// <summary>
        /// 审核提现
        /// </summary>
        /// <param name="cid"></param>
        /// <returns></returns>
        public static string ShTx(string cidList)
        {
            List<string> idList = cidList.Split(',').ToList();
            int success = 0, fail = 0;
            //更新提现申请，货币转移，财务转移
            foreach (string cid in idList)
            {
                Hashtable MyHs = new Hashtable();
                Model.ChangeMoney changemoney = ChangeMoney.GetModel(int.Parse(cid));
                if (changemoney.CState)
                    continue;
                Model.Member FromMember = DAL.Member.GetModel(changemoney.FromMID);
                if (FromMember != null)
                {
                    changemoney.CState = true;
                    UpdataTran(changemoney, MyHs);
                    DAL.ChangeMoney.TranChangeTran(changemoney.FromMID, changemoney.ToMID, changemoney.Money, "MJB", MyHs);
                    FromMember.MConfig.TotalTXMoney += changemoney.Money;
                    DAL.MemberConfig.UpdateConfigTran(FromMember.MID, "TotalTXMoney", changemoney.Money.ToString(), FromMember, false, SqlDbType.Decimal, MyHs);
                    if (BLL.CommonBase.RunHashtable(MyHs))
                    {
                        //BLL.Task.ManageSend(FromMember, "您好，尊敬的会员:" + FromMember.MID + "，平台已与于当前时间" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") +
                        //    "审核您的提现申请" + "，实发金额$" + (changemoney.Money - changemoney.TakeOffMoney) + ",折合人民币￥" + (changemoney.Money - changemoney.TakeOffMoney) * BLL.Configuration.Model.OutFloat + ";，请注意查收");
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
        /// <summary>
        /// 服务中心
        /// </summary>
        /// <param name="model">支付中心/审核中心</param>
        /// <param name="shmid">待激活对象</param>
        /// <param name="shtype">审核方式[0正常，1回填]</param>
        /// <returns></returns>
        public static string SHMember(Model.Member model, string shmid)
        {
            //获取待激活对象

            Hashtable MyHs = new Hashtable();

            string retStr = "";
            Model.Member shmodel = DAL.Member.GetModel(shmid);
            retStr += BLL.Member.Validation2(shmodel);
            if (retStr != "")
                return retStr;

            lock (DAL.Member.tempMemberList)
            {
                DAL.Member.tempMemberList.Clear();//清空临时字典。

                if (!DAL.Member.tempMemberAdd(shmodel))
                    shmodel = DAL.Member.tempMemberList[shmodel.MID];

                Model.Accounts account = new Model.Accounts()
                {
                    AccountsDate = DateTime.MaxValue,
                    ACode = shmid,
                    CreateDate = DateTime.Now,
                    IfAccount = false,
                    IsAuto = true,
                    PCode = "001",
                    TotalFHMoney = 0,
                    FHCount = 0,
                    ARemark = shmid
                };
                //待激活的用户进入系统时候的金额
                shmodel.RoleCode = BLL.Configuration.Model.DefaultRole;
                shmodel.MDate = DateTime.Now;
                shmodel.MConfig = new Model.MemberConfig()
                {
                    MID = shmodel.MID,
                    YJCount = 1,
                    YJMoney = shmodel.SHMoney,
                    //UpSumMoney = shmodel.SHMoney,
                    JJTypeList = DAL.Reward.RewardStr,
                    JTFHState = true,
                    DTFHState = true
                };
                DAL.Member.tempMemberAdd(shmodel);
                if (model.Role.IsAdmin)
                {
                    HBChangeTran(shmodel.SHMoney, model.MID, "Activation", "SH", shmodel, "MHB", model.MID + "审核该会员", MyHs);//货币减少
                }
                else
                {
                    if (!EnoughChange(shmodel.FMID, shmodel.SHMoney, "MCW"))
                        return "您的复利币不足，不能激活会员";
                    HBChangeTran(shmodel.SHMoney, shmodel.FMID, BLL.Member.ManageMember.TModel.MID, "SH", shmodel, "MCW", model.MID + "审核该会员", MyHs);
                }
                BLL.Accounts.BDInsert(account, MyHs);

                shmodel.MState = true;
                shmodel.MDate = DateTime.Now;
                shmodel.IsNewMemberSH = true;
                shmodel.MConfig.SHMoney = shmodel.SHMoney;
                DAL.Member.Update(shmodel, MyHs);
                if (DAL.CommonBase.RunHashtable(MyHs))
                {
                    BLL.Task.ManageSend(shmodel, "恭喜您已成功激活成为正式会员");
                    return "操作成功";
                }
                DAL.Member.tempMemberList.Clear();//清空临时字典
                return "操作失败";
            }
        }

        /// <summary>
        /// 会员充值货币
        /// </summary>
        /// <param name="mid"></param>
        /// <param name="money"></param>
        /// <param name="mType"></param>
        /// <returns></returns>
        public static Hashtable CZMoneyChange(string frommid, string tomid, decimal money, string mType, Hashtable MyHs)
        {
            HBChangeTran(money, frommid, tomid, "CZ", null, mType, "", MyHs);
            return MyHs;
        }
        /// <summary>
        /// 会员扣费
        /// </summary>
        /// <param name="frommid"></param>
        /// <param name="tomid"></param>
        /// <param name="money"></param>
        /// <param name="mType"></param>
        /// <param name="MyHs"></param>
        /// <returns></returns>
        public static Hashtable KFMoneyChange(string frommid, string tomid, decimal money, string mType, Hashtable MyHs)
        {
            HBChangeTran(money, frommid, tomid, "KZ", null, mType, "", MyHs);
            return MyHs;
        }

        public static string GMMoneyChange(int money, string mid, string from, string to, Hashtable MyHs)
        {
            lock (DAL.Member.tempMemberList)
            {
                DAL.Member.tempMemberList.Clear();
                BLL.ChangeMoney.HBChangeTran(money, mid, BLL.Member.ManageMember.TModel.MID, "GM", null, from, BLL.Reward.List[to].RewardName, MyHs);
                BLL.ChangeMoney.HBChangeTran(money, BLL.Member.ManageMember.TModel.MID, mid, "GM", null, to, "", MyHs);

                if (BLL.CommonBase.RunHashtable(MyHs))
                    return "购买成功";
                return "购买失败";
            }
        }

        #endregion

        #region 公共货币及财务转移操作

        /// <summary>
        /// 转账货币
        /// </summary>
        /// <param name="money">货币数目</param>
        /// <param name="model">当前对象</param>
        /// <param name="tomid">目标对象</param>
        /// <returns></returns>
        public static string ZZMoneyChange(int money, string fromid, string tomid, string changetype, string moneyType)
        {
            if (!EnoughChange(fromid, money, moneyType))
                return "您的可用" + BLL.Reward.List[moneyType].RewardName + "不足";
            if (money < DAL.Configuration.TModel.ZZMinMoney)
                return "转账金额最小为" + DAL.Configuration.TModel.ZZMinMoney;
            else if ((money - DAL.Configuration.TModel.ZZMinMoney) % DAL.Configuration.TModel.ZZBaseMoney != 0)
                return "转账金额应是" + DAL.Configuration.TModel.ZZBaseMoney + "的倍数";


            Hashtable MyHs = new Hashtable();
            lock (DAL.Member.tempMemberList)
            {
                DAL.Member.tempMemberList.Clear();
                HBChangeTran(money, fromid, tomid, "ZZ", null, moneyType, "", MyHs);
            }

            if (DAL.CommonBase.RunHashtable(MyHs))
                return "1";
            return "操作失败";
        }

        /// <summary>
        /// 转移货币哈希表
        /// </summary>
        /// <param name="money">货币数目</param>
        /// <param name="model">当前对象</param>
        /// <param name="tomid">目标对象</param>
        /// <returns></returns>
        public static decimal HBChangeTran(decimal money, string frommid, string tomid, string changetype, Model.Member shmodel, string moneytype, string remark, Hashtable MyHs)
        {
            frommid = frommid.ToLower();
            tomid = tomid.ToLower();
            if (!DAL.Member.HasMemberConfigInDic(frommid))
            {
                Model.Member frommodel = DAL.Member.GetModel(frommid);
                DAL.Member.tempMemberAdd(frommodel);
            }
            if (!DAL.Member.HasMemberConfigInDic(tomid))
            {
                Model.Member tomodel = DAL.Member.GetModel(tomid);
                DAL.Member.tempMemberAdd(tomodel);
            }
            Model.ChangeMoney changemoney = new Model.ChangeMoney();
            changemoney.ChangeType = changetype;
            changemoney.ChangeDate = DateTime.Now;
            changemoney.FromMID = frommid;
            changemoney.MoneyType = moneytype;
            changemoney.Money = money;//交易金额
            changemoney.ToMID = tomid;
            changemoney.CompleteTime = DateTime.MaxValue;
            // if (changetype != "DFH")
            changemoney.CRemarks = remark;
            if (shmodel == null)
                changemoney.SHMID = "";
            else
                changemoney.SHMID = shmodel.MID;

            if (DAL.Member.tempMemberList[tomid].IsClock || DAL.Member.tempMemberList[tomid].IsClose)//如果被冻结。
            {
                return 0;
            }
            else
            {
                changemoney.CState = true;
                TakeOffMoneyTran(changemoney, DAL.Member.tempMemberList[frommid], DAL.Member.tempMemberList[tomid], shmodel, MyHs);
            }
            if (changemoney.Money >= 0.01m)
            {
                TranChangeTran(changemoney, MyHs);
                //if (changemoney.ChangeType == "CX" || changemoney.ChangeType == "QD")
                //    changemoney.TakeOffMoney = changemoney.Money;
                InsertTran(changemoney, MyHs);
            }
            return changemoney.Money;
        }

        /// <summary>
        /// 解冻操作操作
        /// </summary>
        /// <param name="money"></param>
        /// <param name="frommid"></param>
        /// <param name="tomid"></param>
        /// <param name="changetype"></param>
        /// <param name="shmodel"></param>
        /// <param name="moneytype"></param>
        /// <param name="remark"></param>
        /// <param name="MyHs"></param>
        /// <returns></returns>
        public static void JDChangeTran(List<Model.ChangeMoney> changemoneyList, Hashtable MyHs)
        {
            string fromMId = string.Empty, toMId = string.Empty;
            foreach (Model.ChangeMoney changemoney in changemoneyList)
            {
                fromMId = changemoney.FromMID;
                toMId = changemoney.ToMID;
                if (!DAL.Member.HasMemberConfigInDic(changemoney.FromMID))
                {
                    Model.Member frommodel = DAL.Member.GetModel(changemoney.FromMID);
                    DAL.Member.tempMemberAdd(frommodel);
                }
                if (!DAL.Member.HasMemberConfigInDic(changemoney.ToMID))
                {
                    Model.Member tomodel = DAL.Member.GetModel(changemoney.ToMID);
                    DAL.Member.tempMemberAdd(tomodel);
                }

                if (DAL.Member.tempMemberList[toMId].IsClock || DAL.Member.tempMemberList[toMId].IsClose)//如果被冻结。
                {
                    continue;
                }
                else
                {
                    //JDTakeOffMoneyTran(changemoney, DAL.Member.tempMemberList[toMId], MyHs);
                }

                if (!changemoney.CState && changemoney.Money > 0.01M)//已解冻的
                {
                    changemoney.CState = true;
                    changemoney.TakeOffMoney = changemoney.Money * DAL.Member.tempMemberList[toMId].MAgencyType.TakeOffFloat;
                    DAL.MemberConfig.UpdateConfigTran(changemoney.ToMID, "TotalMoney", changemoney.Money.ToString(), null, false, SqlDbType.Decimal, MyHs);
                    DAL.MemberConfig.UpdateConfigTran(changemoney.ToMID, "RealMoney", (changemoney.Money - changemoney.TakeOffMoney).ToString(), null, false, SqlDbType.Decimal, MyHs);
                    TranChangeTran(changemoney, MyHs);
                    BLL.ChangeMoney.UpdataTran(changemoney, MyHs);
                }
            }
        }

        /// <summary>
        /// 解冻重复消费
        /// </summary>
        /// <param name="changemoney"></param>
        private static bool JDTakeOffMoneyTran(Model.ChangeMoney changemoney, Model.Member ToModel, Hashtable MyHs)
        {
            if (DAL.Reward.List.Any(emp => emp.Value.NeedProcess && emp.Key == changemoney.ChangeType && emp.Value.RewardState))
            {
                if (!ToModel.MConfig.JJTypeList.Contains(changemoney.ChangeType.ToString()))
                {
                    return false;
                }
                if (!ToModel.MConfig.DTFHState)
                {
                    return false;
                }
                decimal jdmoney = changemoney.Money - changemoney.TakeOffMoney;

                //if (changemoney.ChangeType == "TJ")
                //{
                //    if (ToModel.MAgencyType.MAgencyType == "002") //普通会员
                //    {
                //        int totalSHMoney = ToModel.MConfig.SHMoney;
                //        if ((totalSHMoney - ToModel.MConfig.NomalTotalThaw) < jdmoney)
                //        {
                //            jdmoney = totalSHMoney - ToModel.MConfig.NomalTotalThaw;
                //        }
                //        ToModel.MConfig.NomalTotalThaw += jdmoney;
                //        DAL.MemberConfig.UpdateConfigTran(ToModel.MID, "NomalTotalThaw", jdmoney.ToString(), ToModel, false, SqlDbType.Decimal, MyHs);
                //    }
                //    else if (ToModel.MAgencyType.MAgencyType != "001")//经理级别以上的
                //    {
                //        ToModel.MConfig.VIPTotalThaw += jdmoney;
                //        DAL.MemberConfig.UpdateConfigTran(ToModel.MID, "VIPTotalThaw", jdmoney.ToString(), ToModel, false, SqlDbType.Decimal, MyHs);
                //    }
                //}
                //else if (changemoney.ChangeType == "LD" || changemoney.ChangeType == "XY")
                //{
                //    //领导奖需要再次冻结30天
                //    if (changemoney.ChangeType == "LD" && (DateTime.Now - changemoney.CompleteTime).TotalMinutes < MMMConfig.Model.GLLockDays)
                //    {
                //        jdmoney = 0;
                //    }
                //    else
                //    {
                //        if (ToModel.MAgencyType.MAgencyType == "002") //普通会员
                //        {
                //            int totalSHMoney = ToModel.MConfig.SHMoney;
                //            if ((totalSHMoney - ToModel.MConfig.NomalTotalThaw) < jdmoney)
                //            {
                //                jdmoney = totalSHMoney - ToModel.MConfig.NomalTotalThaw;
                //            }
                //            ToModel.MConfig.NomalTotalThaw += jdmoney;
                //            DAL.MemberConfig.UpdateConfigTran(ToModel.MID, "NomalTotalThaw", jdmoney.ToString(), ToModel, false, SqlDbType.Decimal, MyHs);
                //        }
                //        else if (ToModel.MAgencyType.MAgencyType != "001")//经理级别以上的
                //        {
                //            decimal totalSHMoney = ToModel.MAgencyType.DTopMoney;
                //            if ((totalSHMoney - ToModel.MConfig.VIPTotalThaw) < jdmoney)
                //            {
                //                jdmoney = totalSHMoney - ToModel.MConfig.VIPTotalThaw;
                //            }
                //            ToModel.MConfig.VIPTotalThaw += jdmoney;
                //            DAL.MemberConfig.UpdateConfigTran(ToModel.MID, "VIPTotalThaw", jdmoney.ToString(), ToModel, false, SqlDbType.Decimal, MyHs);
                //        }
                //    }
                //}
                //else
                //{
                //    return false;
                //}
                if (jdmoney <= 0)
                    return false;
                DAL.MemberConfig.UpdateConfigTran(ToModel.MID, "MJB", jdmoney.ToString(), ToModel, false, SqlDbType.Decimal, MyHs);
                changemoney.TakeOffMoney += jdmoney;
                if (changemoney.TakeOffMoney == changemoney.Money)
                    changemoney.CState = true;
                //DAL.ChangeMoney.UpdataChangeMoneyTran(changemoney.CID.ToString(), "TakeOffMoney", changemoney.Money.ToString(), false, SqlDbType.Decimal, MyHs);
                //DAL.MemberConfig.UpdateConfigTran(ToModel.MID, "TotalMoney", changemoney.Money.ToString(), ToModel, false, SqlDbType.Decimal, MyHs);
                //DAL.MemberConfig.UpdateConfigTran(ToModel.MID, "TakeOffMoney", changemoney.TakeOffMoney.ToString(), ToModel, false, SqlDbType.Decimal, MyHs);
            }
            return changemoney.CState;
        }

        #endregion

        #region 系统自动业务奖励


        /// <summary>
        /// 重复消费，封顶
        /// </summary>
        /// <param name="changemoney"></param>
        private static void TakeOffMoneyTran(Model.ChangeMoney changemoney, Model.Member FromModel, Model.Member ToModel, Model.Member shmodel, Hashtable MyHs)
        {
            if (DAL.Reward.List.Any(emp => emp.Value.NeedProcess && emp.Key == changemoney.ChangeType && emp.Value.RewardState))
            {
                if (!ToModel.MConfig.JJTypeList.Contains(changemoney.ChangeType.ToString()))
                {
                    changemoney.Money = 0;
                    return;
                }
                if (changemoney.ChangeType == "DFH")
                {
                    if (!ToModel.MConfig.JTFHState)
                    {
                        changemoney.Money = 0;
                        return;
                    }
                }
                else
                {
                    if (!ToModel.MConfig.DTFHState)
                    {
                        changemoney.Money = 0;
                        return;
                    }
                }
                //if (changemoney.ChangeType == "DFH")
                //{

                //}
                //else if (changemoney.ChangeType == "TK")
                //{
                //    //提款操作，就是把所有的奖金解冻


                //}
                //else if (changemoney.ChangeType == "LD")
                //{
                //    // 静态出局后不享受领导奖，复投后继续享受
                //    if (!ToModel.MConfig.JTFHState)
                //    {
                //        changemoney.Money = 0;
                //        return;
                //    }

                //    if (int.Parse(DAL.CommonBase.GetSingle("select count(1) from bmember where amid='" + ToModel.MID + "' and BMState='1' and BIsClock='0' and yjmoney<boutmoney").ToString()) == 0)
                //    {
                //        changemoney.Money = 0;
                //        return;
                //    }
                //    decimal dpmoney = DAL.Member.GetTypeSumJJ(ToModel.MID, "LD", DateTime.Now);

                //    //if (changemoney.Money + dpmoney >= ToModel.MAgencyType.LDTopMoney)
                //    //{
                //    //    changemoney.Money = ToModel.MAgencyType.LDTopMoney - dpmoney;
                //    //}
                //    if (changemoney.Money < 0)
                //    {
                //        changemoney.Money = 0;
                //        return;
                //    }

                //    changemoney.ReBuyMoney = changemoney.Money * BLL.Configuration.Model.DMGPPart;
                //    if (changemoney.ReBuyMoney >= 0.01m)
                //    {
                //        ToModel.MConfig.MGP += changemoney.ReBuyMoney;
                //        DAL.MemberConfig.UpdateConfigTran(ToModel.MID, "MGP", changemoney.ReBuyMoney.ToString(), shmodel, false, SqlDbType.Decimal, MyHs);
                //    }
                //    ////累计日领到奖
                //    DAL.MemberConfig.UpdateConfigTran(ToModel.MID, "TotalLDMoney", changemoney.Money.ToString(), shmodel, false, SqlDbType.Decimal, MyHs);
                //}
                //else if (changemoney.ChangeType == "TJ" || changemoney.ChangeType == "ZZB")
                //{
                //    changemoney.ReBuyMoney = changemoney.Money * BLL.Configuration.Model.DMGPPart;
                //    ToModel.MConfig.MGP += changemoney.ReBuyMoney;
                //    DAL.MemberConfig.UpdateConfigTran(ToModel.MID, "MGP", changemoney.ReBuyMoney.ToString(), shmodel, false, SqlDbType.Decimal, MyHs);
                //}
                //else
                //{
                //    //changemoney.ReBuyMoney = changemoney.Money * BLL.Configuration.Model.MCWPart;
                //    ToModel.MConfig.MCW += changemoney.ReBuyMoney;
                //    DAL.MemberConfig.UpdateConfigTran(ToModel.MID, "MCW", changemoney.ReBuyMoney.ToString(), shmodel, false, SqlDbType.Decimal, MyHs);
                //}

                DAL.MemberConfig.UpdateConfigTran(ToModel.MID, "TotalMoney", changemoney.Money.ToString(), shmodel, false, SqlDbType.Decimal, MyHs);
                DAL.MemberConfig.UpdateConfigTran(ToModel.MID, "RealMoney", (changemoney.Money - changemoney.TakeOffMoney - changemoney.ReBuyMoney - changemoney.MCWMoney).ToString(), shmodel, false, SqlDbType.Decimal, MyHs);
                DAL.MemberConfig.UpdateConfigTran(ToModel.MID, "TakeOffMoney", changemoney.TakeOffMoney.ToString(), shmodel, false, SqlDbType.Decimal, MyHs);
                DAL.MemberConfig.UpdateConfigTran(ToModel.MID, "ReBuyMoney", changemoney.ReBuyMoney.ToString(), shmodel, false, SqlDbType.Decimal, MyHs);


                if (BLL.Accounts.tempAccount != null && changemoney.Money > 0)
                {
                    if (BLL.Accounts.tempAccount.AccountMember.ContainsKey(ToModel.MID))
                        BLL.Accounts.tempAccount.AccountMember[ToModel.MID] = changemoney.Money;
                    else
                        BLL.Accounts.tempAccount.AccountMember.Add(ToModel.MID, changemoney.Money);
                }
            }
            else if (changemoney.ChangeType == "TX")
            {
                changemoney.TakeOffMoney = Math.Round(changemoney.Money * FromModel.MAgencyType.TXFloat, 2);
            }
        }
        /// <summary>
        /// 10%CT币交易将分配给上级十代： 
        /// </summary>
        /// <param name="money"></param>
        /// <param name="model"></param>
        /// <param name="shmodel"></param>
        /// <param name="level"></param>
        /// <param name="MyHs"></param>
        /// <returns></returns>
        private static Hashtable Parents10ChangeMoney(decimal money, Model.Member model, Model.Member shmodel, int level, Hashtable MyHs)
        {
            Model.Member bdmodel = DAL.Member.GetModel(model.MTJ);
            if (level < 6)
            {
                if (bdmodel != null && bdmodel.MID != bdmodel.MTJ)
                {
                    if (!bdmodel.Role.IsAdmin)
                    {
                        decimal flo = 0;
                        Model.ConfigDictionary dic = DAL.ConfigDictionary.GetConfigDictionary(level + 1, "GPJYMoney", bdmodel.MAgencyType.MAgencyType);
                        if (dic != null && !string.IsNullOrEmpty(dic.DValue))
                        {
                            flo = decimal.Parse(dic.DValue);
                            decimal btmoney = money * flo;
                            HBChangeTran(btmoney, BLL.Member.ManageMember.TModel.MID, bdmodel.MID, "CTChange", shmodel, "MHB", "", MyHs);
                        }
                    }
                    Parents10ChangeMoney(money, bdmodel, shmodel, level + 1, MyHs);
                }
            }
            return MyHs;
        }


        //public static Hashtable LDChangeTran(Model.Accounts model, Hashtable MyHs)
        //{
        //    Model.Member shmodel = new Model.Member { MID = model.ACode };
        //    //是否需要分开？？
        //    //发送领导奖
        //    List<Model.LDLevelInfo> ldList = BLL.LDLevelInfo.GetList("LevelActivateGCount>0");
        //    List<string> listMID = new List<string>();
        //    foreach (Model.LDLevelInfo info in ldList)
        //    {
        //        if (!listMID.Contains(info.LDMID))
        //        {
        //            listMID.Add(info.LDMID);
        //        }
        //    }
        //    foreach (string mid in listMID)
        //    {
        //        //筛选掉会员没有资格领取到的代数
        //        List<Model.LDLevelInfo> ld10List = ldList.Where(c => c.LDMID == mid).ToList();
        //        Model.Member mem = new BLL.Member().GetModel(mid);
        //        if (mem != null)
        //        {
        //            int TJCount = mem.MConfig.TJCount;
        //            //查看会员是否可以拿该代数
        //            Model.ConfigDictionary TJLDLevel = DAL.ConfigDictionary.GetConfigDictionary(TJCount, "TJLDLevel", "TJLDLevel");
        //            if (TJLDLevel != null && !string.IsNullOrEmpty(TJLDLevel.DValue))
        //            {
        //                int avliableLevel = int.Parse(TJLDLevel.DValue);
        //                //每股日分红
        //                decimal eachFHMoney = BLL.Configuration.Model.GPrice * BLL.Configuration.Model.DFHFloat;
        //                decimal totalLDMoney = ld10List.Where(c => c.LDLeavel <= avliableLevel).Sum(c => c.LevelActivateGCount * c.LDFloat * eachFHMoney);
        //                HBChangeTran(totalLDMoney, BLL.Member.ManageMember.TModel.MID, mid, "LD", shmodel, "MHB", "", MyHs);
        //            }
        //        }
        //    }
        //    return MyHs;
        //}


        /// <summary>
        /// 分红奖
        /// </summary>
        /// <param name="model">待审核会员</param>
        /// <param name="MyHs">SQL批处理</param>
        /// <returns></returns>
        public static Hashtable FHChangeTran(Model.Accounts model, Hashtable MyHs)
        {
            BLL.Accounts.tempAccount = model;
            if (model.PCode == "001" || model.PCode == "005")
            {
                //return MyHs;
                Model.Member shmodel = DAL.Member.GetModel(model.ARemark);
                if (DAL.Member.HasMemberConfigInDic(shmodel.MID))
                    shmodel = DAL.Member.tempMemberList[shmodel.MID];

                TJCountTran(shmodel, MyHs);
                YJCountTran(shmodel, shmodel, MyHs);
                return MyHs;
            }


            model.FHCount = model.AccountMember.Count;
            model.TotalFHMoney = model.AccountMember.Values.Sum();

            return MyHs;
        }


        /// <summary>
        /// 业绩更新(迭代)
        /// </summary>
        /// <param name="model">待审核会员（迭代的变量）</param>
        /// <param name="MyHs">SQL批处理</param>
        /// <param name="shmodel">待审核会员</param>
        /// <returns></returns>
        public static Hashtable YJCountTran(Model.Member model, Model.Member shmodel, Hashtable MyHs)
        {
            //获取待审核会员的接点人
            Model.Member tempmodel = DAL.Member.GetModel(model.MBD);

            if (tempmodel != null)
            {
                if (!DAL.Member.tempMemberAdd(tempmodel))
                    tempmodel = DAL.Member.tempMemberList[tempmodel.MID];

                int yjmoney = shmodel.SHMoney - shmodel.MConfig.SHMoney;
                tempmodel.MConfig.YJMoney += yjmoney;
                DAL.MemberConfig.UpdateConfigTran(tempmodel.MID, "YJMoney", yjmoney.ToString(), shmodel, false, SqlDbType.Int, MyHs);
                tempmodel.MConfig.UpSumMoney += yjmoney;
                DAL.MemberConfig.UpdateConfigTran(tempmodel.MID, "UpSumMoney", yjmoney.ToString(), shmodel, false, SqlDbType.Int, MyHs);

                tempmodel.MConfig.YJCount += 1;
                DAL.MemberConfig.UpdateConfigTran(tempmodel.MID, "YJCount", "1", shmodel, false, SqlDbType.Int, MyHs);

                if (!DAL.Member.tempMemberAdd(tempmodel))
                {
                    DAL.Member.tempMemberList[tempmodel.MID].MConfig.YJMoney = tempmodel.MConfig.YJMoney;
                    DAL.Member.tempMemberList[tempmodel.MID].MConfig.UpSumMoney = tempmodel.MConfig.UpSumMoney;
                    DAL.Member.tempMemberList[tempmodel.MID].MConfig.YJCount = tempmodel.MConfig.YJCount;
                }
            }
            if (tempmodel != null && tempmodel.MID != tempmodel.MBD)
            {
                YJCountTran(tempmodel, shmodel, MyHs);
            }
            return MyHs;
        }

        public static Hashtable YJMoneyTran(decimal money, Model.Member model, Model.Member shmodel, Hashtable MyHs)
        {
            if (model != null && model.MID != model.MBD)
            {
                model.MConfig.YJMoney += (int)money;
                DAL.MemberConfig.UpdateConfigTran(model.MID, "YJMoney", money.ToString(), shmodel, false, SqlDbType.Int, MyHs);
                Model.Member mBD = DAL.Member.GetModel(model.MBD);
                YJMoneyTran(money, mBD, shmodel, MyHs);
            }
            return MyHs;
        }

        public static Hashtable TJMoneyTran(decimal money, string mTJmid, Hashtable MyHs)
        {
            Model.Member mTJ = DAL.Member.GetModel(mTJmid);
            if (mTJ != null && mTJ.MID != mTJ.MTJ)
            {
                mTJ.MConfig.YJMoney += (int)money;
                DAL.MemberConfig.UpdateConfigTran(mTJ.MID, "TJMoney", money.ToString(), null, false, SqlDbType.Int, MyHs);
            }
            return MyHs;
        }

        /// <summary>
        /// 推荐更新
        /// </summary>
        /// <param name="shmodel">待审核会员</param>
        /// <param name="MyHs">SQL批处理</param>
        /// <returns></returns>
        public static Hashtable TJCountTran(Model.Member shmodel, Hashtable MyHs)
        {
            //获取推荐人的model
            Model.Member tjmodel = DAL.Member.GetModel(shmodel.MTJ);

            if (tjmodel != null)
            {
                if (!DAL.Member.tempMemberAdd(tjmodel))
                    tjmodel = DAL.Member.tempMemberList[tjmodel.MID];

                tjmodel.MConfig.TJCount += 1;
                DAL.MemberConfig.UpdateConfigTran(tjmodel.MID, "TJCount", "1", shmodel, false, SqlDbType.Int, MyHs);

                R_SJ(tjmodel.MID);

                if (!DAL.Member.tempMemberAdd(tjmodel))
                {
                    DAL.Member.tempMemberList[tjmodel.MID].MConfig.YJMoney = tjmodel.MConfig.YJMoney;
                    DAL.Member.tempMemberList[tjmodel.MID].MConfig.UpSumMoney = tjmodel.MConfig.UpSumMoney;
                    DAL.Member.tempMemberList[tjmodel.MID].MConfig.YJCount = tjmodel.MConfig.YJCount;
                }
            }
            return MyHs;
        }

        public static Hashtable TJMoneyTran(Model.Member shmodel, Model.MOfferHelp offer, Hashtable MyHs)
        {
            //获取推荐人的model
            Model.Member tjmodel = DAL.Member.GetModel(shmodel.MTJ);

            if (tjmodel != null)
            {
                if (!DAL.Member.tempMemberAdd(tjmodel))
                    tjmodel = DAL.Member.tempMemberList[tjmodel.MID];
                tjmodel.MConfig.TJMoney += Convert.ToInt32(offer.SQMoney);
                DAL.MemberConfig.UpdateConfigTran(tjmodel.MID, "TJMoney", Convert.ToInt32(offer.SQMoney).ToString(), shmodel, false, SqlDbType.Int, MyHs);
            }
            return MyHs;
        }


        /// <summary>
        /// 报单补贴奖哈希表,管理员不给予奖励
        /// </summary>
        /// <param name="shmodel">待审核会员</param>
        /// <param name="MyHs">SQL批处理</param>
        /// <returns></returns>
        public static Hashtable BTMoneyChangeTran(Model.Member shmodel, Hashtable MyHs)
        {
            Model.Member bdmodel = DAL.Member.GetModel(shmodel.MSH);
            if (bdmodel != null && !bdmodel.Role.IsAdmin && bdmodel.Role.CanSH)
            {
                decimal btmoney = (shmodel.SHMoney - shmodel.MConfig.SHMoney) * bdmodel.MAgencyType.BTFloat;
                HBChangeTran(btmoney, BLL.Member.ManageMember.TModel.MID, bdmodel.MID, "BT", shmodel, "MHB", "", MyHs);
            }
            return MyHs;
        }
        /// <summary>
        /// 反哺奖
        /// </summary>
        /// <param name="shmodel">待审核会员</param>
        /// <param name="MyHs">SQL批处理</param>
        /// <returns></returns>
        public static List<Model.Member> FPMoneyChangeTran(List<Model.Member> limember, List<Model.Member> liall, int count)
        {
            if (limember != null && limember.Count != 0)
            {
                if (count < 6)
                {
                    List<Model.Member> temp = new List<Model.Member>();
                    //temp = null;
                    foreach (Model.Member li in limember)
                    {
                        List<Model.Member> tjlist = DAL.MemberCollection.GetMemberEntityList(string.Format("MTJ='{0}' and AgencyCode<>'001' and MState='1'", li.MID));
                        foreach (Model.Member itemmember in tjlist)
                        {
                            temp.Add(itemmember);
                        }

                        liall.Add(li);
                    }

                    FPMoneyChangeTran(temp, liall, count + 1);

                }
            }
            return liall;
        }

        /// <summary>
        /// 推荐奖励
        /// </summary>
        /// <param name="shmodel">待审核会员</param>
        /// <param name="MyHs">SQL批处理</param>
        /// <returns></returns>
        public static Hashtable TJMoneyChangeTran(Model.Member model, Model.Member shmodel, Hashtable MyHs)
        {
            Model.Member tjmodel = DAL.Member.GetModel(model.MTJ);

            if (tjmodel != null && tjmodel.MID != tjmodel.MTJ)
            {
                decimal tjmoney = (shmodel.GCount * BLL.Configuration.Model.GPrice) * tjmodel.MAgencyType.TJFloat;
                HBChangeTran(tjmoney, BLL.Member.ManageMember.TModel.MID, tjmodel.MID, "TJ", shmodel, "MHB", model.MID + "购买" + shmodel.GCount + "股产生", MyHs);
            }
            return MyHs;
        }

        /// <summary>
        /// 领到奖
        /// </summary>
        /// <param name="model"></param>
        /// <param name="shmodel"></param>
        /// <param name="level"></param>
        /// <param name="MyHs"></param>
        /// <returns></returns>
        public static Hashtable LDCangeTran(Model.Member model, Model.Member shmodel, decimal money, int level, Hashtable MyHs)
        {
            Model.Member bdmodel = DAL.Member.GetModel(model.MTJ);
            if (level < 6)
            {
                if (bdmodel != null && bdmodel.MID != bdmodel.MTJ)
                {
                    if (!bdmodel.Role.IsAdmin)
                    {
                        decimal flo = 0;
                        Model.ConfigDictionary dic = DAL.ConfigDictionary.GetConfigDictionary(level + 1, "XYYJConfig", (level + 1).ToString());
                        if (dic != null && !string.IsNullOrEmpty(dic.DValue))
                        {
                            flo = decimal.Parse(dic.DValue);
                            decimal btmoney = money * flo;
                            HBChangeTran(btmoney, BLL.Member.ManageMember.TModel.MID, bdmodel.MID, "XYYJ", shmodel, "MHB", level.ToString() + "代会员" + model.MID + "富达币交易", MyHs);
                        }
                    }
                    LDCangeTran(bdmodel, shmodel, money, level + 1, MyHs);
                }
            }
            return MyHs;
        }
        /// <summary>
        /// 区域总监奖
        /// </summary>
        /// <param name="shmodel"></param>
        /// <param name="money"></param>
        /// <param name="MyHs"></param>
        /// <returns></returns>
        public static Hashtable ZJYJChangeTran(Model.Member shmodel, decimal money, Hashtable MyHs)
        {
            //找到该区域的n个区域总监
            if (money <= 0)
                return MyHs;
            IList<Model.Member> listMomber = BLL.Member.GetRegionHeaderList(shmodel);
            int count = listMomber.Count;
            if (count > 0)
            {
                //每份平分的money
                decimal splitMoney = money / count;
                foreach (Model.Member member in listMomber)
                {
                    HBChangeTran(splitMoney, BLL.Member.ManageMember.TModel.MID, member.MID, "ZJYJ", shmodel, "MHB", "该区域会员" + shmodel.MID + "富达交易", MyHs);
                }
            }
            return MyHs;
        }
        /// <summary>
        /// 服务中心奖
        /// </summary>
        /// <param name="shmodel"></param>
        /// <param name="money"></param>
        /// <param name="MyHs"></param>
        /// <returns></returns>
        public static Hashtable FWYJChangeTran(Model.Member shmodel, decimal money, Hashtable MyHs)
        {
            //找到该区域的n个服务中心
            if (money <= 0)
                return MyHs;
            IList<Model.Member> listMomber = new BLL.Member().GetMemberEntityList("MID in (select MID from MemberConfig WHERE IsServerCenter=1)");
            int count = listMomber.Count;
            if (count > 0)
            {
                //每份平分的money
                decimal splitMoney = money / count;
                foreach (Model.Member member in listMomber)
                {
                    HBChangeTran(splitMoney, BLL.Member.ManageMember.TModel.MID, member.MID, "FWYJ", shmodel, "MHB", "", MyHs);
                }
            }
            return MyHs;
        }
        /// <summary>
        /// 对碰奖/平衡奖
        /// </summary>
        /// <param name="model"></param>
        /// <param name="shmodel"></param>
        /// <param name="dpcount"></param>
        /// <param name="MyHs"></param>
        /// <returns></returns>
        private static Hashtable DPMoneyChangeTran(Model.Member model, Model.Member shmodel, decimal dptopmoney, int dpcount, Hashtable MyHs)
        {
            Model.Member bdmodel = DAL.Member.GetModel(model.MBD);
            if (bdmodel != null && bdmodel.MBD != bdmodel.MID && dptopmoney > 0)
            {
                if (!bdmodel.Role.IsAdmin)
                {
                    List<Model.Member> smodel = DAL.MemberCollection.GetMemberEntityList(string.Format("MBD='{0}' and AgencyCode<>'001' and MID<>'{1}' and MState='1'", bdmodel.MID, model.MID));
                    if (smodel.Count > 0)
                    {
                        if (DAL.Member.HasMemberConfigInDic(model.MID))
                            model = DAL.Member.tempMemberList[model.MID];
                        if (DAL.Member.HasMemberConfigInDic(smodel[0].MID))
                            smodel[0] = DAL.Member.tempMemberList[smodel[0].MID];
                        if (!DAL.Member.tempMemberAdd(bdmodel))
                            bdmodel = DAL.Member.tempMemberList[bdmodel.MID];

                        int dpmoney = smodel[0].MConfig.UpSumMoney > model.MConfig.UpSumMoney ? model.MConfig.UpSumMoney : smodel[0].MConfig.UpSumMoney;

                        if (dpmoney > 0 && dpcount <= 9999999)
                        {
                            dpcount += 1;
                            //decimal money = dpmoney * bdmodel.MAgencyType.DPFloat;
                            decimal money = 0;
                            if (dptopmoney < money)
                            {
                                money = dptopmoney;
                                dptopmoney = 0;
                            }
                            else
                            {
                                dptopmoney -= money;
                            }
                            decimal sjMoney = shmodel.SHMoney - shmodel.MConfig.SHMoney;
                            string remark = shmodel.MID + "升级" + sjMoney + "元所产生";
                            HBChangeTran(money, BLL.Member.ManageMember.TModel.MID, bdmodel.MID, "DP", shmodel, "MHB", remark, MyHs);
                        }

                        model.MConfig.UpSumMoney -= dpmoney;
                        smodel[0].MConfig.UpSumMoney -= dpmoney;

                        DAL.MemberConfig.UpdateConfigTran(model.MID, "UpSumMoney", (-dpmoney).ToString(), shmodel, false, SqlDbType.Int, MyHs);
                        DAL.MemberConfig.UpdateConfigTran(smodel[0].MID, "UpSumMoney", (-dpmoney).ToString(), shmodel, false, SqlDbType.Int, MyHs);


                    }
                }
                DPMoneyChangeTran(bdmodel, shmodel, dptopmoney, dpcount, MyHs);
            }
            return MyHs;
        }


        public static bool HBJLChangeTran(Model.Member model, decimal money, string type)
        {
            lock (DAL.Member.tempMemberList)
            {
                Hashtable MyHs = new Hashtable();
                HBChangeTran(money, BLL.Member.ManageMember.TModel.MID, model.MID, type, model, "MHB", "", MyHs);
                return BLL.CommonBase.RunHashtable(MyHs);
            }
        }

        #endregion

        #region 算法及数据处理

        /// <summary>
        /// 转移货币事务哈希表
        /// </summary>
        /// <returns></returns>
        public static Hashtable TranChangeTran(Model.ChangeMoney model, Hashtable MyHs)
        {
            if (model.CState)
            {
                if (model.ChangeType.ToUpper() == "TX")
                    return DAL.ChangeMoney.TranChangeTran(model.FromMID, model.ToMID, model.Money, model.MoneyType, MyHs);
                else
                    return DAL.ChangeMoney.TranChangeTran(model.FromMID, model.ToMID, model.Money - model.TakeOffMoney - model.ReBuyMoney - model.MCWMoney, model.MoneyType, MyHs);

            }
            return MyHs;
        }

        /// <summary>
        /// 判断是否可以转移货币
        /// </summary>
        /// <param name="model">来自会员对象</param>
        /// <param name="money">货币数目</param>
        /// <returns></returns>
        public static bool EnoughChange(string frommid, decimal money, string moneytype)
        {
            Model.Member model = DAL.Member.GetModel(frommid);

            if (model.Role.Super)
                return true;
            if (moneytype == "MHB")
                moneytype = "MJJ";
            PropertyInfo pinfo = typeof(Model.MemberConfig).GetProperty(moneytype);
            if (Convert.ToDecimal(pinfo.GetValue(model.MConfig, null)) >= money)
                return true;
            return false;
        }

        /// <summary>
        /// 取到今天的提现次数
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public static int GetDayTXCount(string mid)
        {
            return DAL.ChangeMoney.GetDayTXCount(mid);
        }
        /// <summary>
        /// 得到个人的总计分红
        /// </summary>
        /// <param name="mid"></param>
        /// <returns></returns>
        public static decimal GetTotalFHMoney(string mid)
        {

            return DAL.ChangeMoney.GetTotalFHMoney(mid);
        }
        #endregion

        public static List<Model.ChangeMoney> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.ChangeMoney.GetList(strWhere, pageIndex, pageSize, out count);
        }

        public static List<Model.ChangeMoney> GetList(string strWhere)
        {
            return DAL.ChangeMoney.GetList(strWhere);
        }

        public static DataTable GetChangeTypeList(string mid, string changeType, string top)
        {
            return DAL.ChangeMoney.GetChangeTypeList(mid, changeType, top);
        }

        //日解冻
        public static bool DayJD()
        {
            lock (BLL.MHelpMatch.thisLock)
            {
                Hashtable hs = new Hashtable();
                DAL.Member.tempMemberList.Clear();
                List<Model.ChangeMoney> listChangeMoney = DAL.ChangeMoneyCollection.GetChangeMoneyEntityList("ChangeType in('TJ','XY','LD') and (Money-TakeOffMoney)>0 and OrderState=1 and CState=0");
                BLL.ChangeMoney.JDChangeTran(listChangeMoney, hs);
                return DAL.CommonBase.RunHashtable(hs);
            }
        }

        /// <summary>
        /// 会员第一笔成功的，如果是第一笔就把会员购买激活码的60块钱返还到马夫罗账户
        /// </summary>
        /// <param name="mid"></param>
        /// <param name="hs"></param>
        public static void ReturnActiveCodeMoney(string mid, Hashtable hs)
        {
            decimal money = BLL.MMMConfig.Model.ActiveCodePrice;
            Model.ChangeMoney changemoney = new Model.ChangeMoney();
            changemoney.ChangeDate = DateTime.Now;
            changemoney.ChangeType = "RT";//返还
            changemoney.Money = money;
            changemoney.MoneyType = "MJB";
            changemoney.FromMID = BLL.Member.ManageMember.TModel.MID;
            changemoney.ToMID = mid;
            changemoney.CState = true;
            changemoney.CRemarks = "第一单完成返还购买激活码的价格";
            changemoney.CompleteTime = DateTime.Now;
            BLL.ChangeMoney.InsertTran(changemoney, hs);
            BLL.ChangeMoney.TranChangeTran(changemoney, hs);
        }

        # region zx_126

        /// <summary>
        /// 获取会员最小援助金额
        /// </summary>
        /// <returns></returns>
        public static decimal GetMinOfferMoney(Model.Member model)
        {
            var dic = DAL.ConfigDictionary.GetConfigDictionary(model.MConfig.TJCount, "OffHelp", "");
            if (dic != null)
            {
                return decimal.Parse(dic.DValue);
            }
            else
            {
                return BLL.Configuration.Model.TXMinMoney;
            }
        }

        ///// <summary>
        ///// 删除未激活会员
        ///// </summary>
        ///// <returns></returns>
        //public static bool DeleteNotactive()
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    string time = DateTime.Now.AddMinutes(-BLL.Configuration.Model.MaxBuyGCount).ToString("yyyy-MM-dd HH:mm:ss");//几分钟之前
        //    strSql.AppendFormat(" delete from MOfferHelp where SQMID in (select MID from Member where MState = 0 and MCreateDate <= '{0}' ); ", time);
        //    strSql.AppendFormat(" delete from Member  where MState = 0 and MCreateDate <= '{0}' ; ", time);
        //    object obj = BLL.CommonBase.GetSingle(strSql.ToString());
        //    if (obj == null)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        ///// <summary>
        ///// 推荐奖励
        ///// </summary>
        //public static Hashtable R_TJ(Model.Member member, Model.Member shMember, decimal money, int level, Hashtable MyHs)
        //{
        //    if (level <= BLL.Configuration.Model.ConfigDictionaryList["TJFloat"].Max(m => m.EndLevel))
        //    {
        //        Model.Member mtj = DAL.Member.GetModel(member.MTJ);
        //        //推荐人不为空，不是自己，不是管理员
        //        if (mtj != null && mtj.MID != member.MID && !mtj.Role.IsAdmin)
        //        {
        //            var dic = DAL.ConfigDictionary.GetConfigDictionary(level, "TJFloat", "");
        //            if (dic != null)
        //            {
        //                HBChangeTran(money * Convert.ToDecimal(dic.DValue), BLL.Member.ManageMember.TModel.MID, mtj.MID, "R_TJ", shMember, "MJB", level.ToString() + "代会员" + shMember.MID + "提供帮助" + money, MyHs);
        //            }
        //        }
        //    }
        //    return MyHs;
        //}

        ///// <summary>
        ///// 自动升级
        ///// </summary>
        //public static bool AutoSJ(Model.Member model, Model.MOfferHelp lastoffer)
        //{
        //    if (lastoffer == null && model.AgencyCode == "002")//没有上一单并且是S0等级
        //    {
        //        //升级
        //        Model.Member member = DAL.Member.GetModel(model.MID);
        //        member.AgencyCode = "003";
        //        //member.MAgencyType = DAL.SHMoney.GetSHMoneyList["003"];
        //        Hashtable MyHs = new Hashtable();
        //        DAL.Member.UpdateRole(member, MyHs);
        //        if (CommonBase.RunHashtable(MyHs))
        //        {
        //            return SJ(member);
        //        }
        //    }

        //    return true;
        //}

        //public static bool SJ(Model.Member model)
        //{
        //    Model.Member mTJ = DAL.Member.GetModel(model.MTJ);
        //    if (mTJ != null && mTJ.MID != mTJ.MTJ && !mTJ.Role.IsAdmin)
        //    {
        //        string agency = mTJ.AgencyCode;
        //        //获得可以升级的初步条件
        //        List<Model.SHMoney> shList = DAL.SHMoney.GetList("  TJCount <= " + mTJ.MConfig.TJCount + " and TemaCount <= " + mTJ.MConfig.YJCount + " and MAgencyType >= '" + model.AgencyCode + "' order by MAgencyType ");
        //        if (mTJ.MConfig.SHMoney > 0)
        //        {
        //            foreach (var item in shList)
        //            {
        //                if (BLL.Member.GetTJCount(mTJ.MID, item.TJAgency) >= item.TJCount)
        //                {
        //                    mTJ.AgencyCode = item.MAgencyType;
        //                    mTJ.MAgencyType = item;
        //                }
        //            }
        //            if (mTJ.AgencyCode != agency)
        //            {
        //                Hashtable MyHs = new Hashtable();
        //                DAL.Member.UpdateRole(mTJ, MyHs);
        //                if (CommonBase.RunHashtable(MyHs))
        //                {
        //                    return SJ(mTJ);
        //                }
        //            }
        //        }
        //    }
        //    return true;
        //}

        ///// <summary>
        ///// 管理奖
        ///// </summary>
        ///// <param name="money"></param>
        ///// <param name="member"></param>
        ///// <param name="shMember"></param>
        ///// <param name="level"></param>
        ///// <param name="MyHs"></param>
        ///// <returns></returns>
        //public static Hashtable R_GL(Model.MOfferHelp offer, Model.Member member, Model.Member shMember, int level, Hashtable MyHs)
        //{
        //    var configs = DAL.ConfigDictionary.GetDicList();
        //    int max = 0;
        //    int min = 0;
        //    try
        //    {
        //        max = configs.Where(m => m.Key == "GLFloat").Max(m => m.Value.Max(mm => mm.EndLevel));
        //        min = configs.Where(m => m.Key == "GLFloat").Min(m => m.Value.Min(mm => mm.StartLevel));
        //    }
        //    catch
        //    { }

        //    return R_GLDetial(offer, member, shMember, level, min, max, MyHs);
        //}

        ///// <summary>
        ///// 管理奖
        ///// </summary>
        //public static Hashtable R_GLDetial(Model.MOfferHelp offer, Model.Member member, Model.Member shMember, int level, int minLevel, int maxLevel, Hashtable MyHs)
        //{
        //    if (level <= maxLevel)
        //    {
        //        //获取推荐人
        //        Model.Member mTJ = DAL.Member.GetModel(member.MTJ);
        //        if (mTJ != null && mTJ.MTJ != mTJ.MID && !mTJ.Role.IsAdmin)
        //        {
        //            if (level >= minLevel)
        //            {
        //                Model.ConfigDictionary dic = DAL.ConfigDictionary.GetConfigDictionary(level, "GLFloat", mTJ.AgencyCode);
        //                if (dic != null)
        //                {
        //                    if (level == 1)
        //                    {
        //                        JJChangeTran(offer.SQMoney * Convert.ToDecimal(dic.DValue), "R_TJ", "MJB", mTJ, shMember, "", level.ToString(), offer.SQCode, MyHs);
        //                    }
        //                    else
        //                    {
        //                        JJChangeTran(offer.SQMoney * Convert.ToDecimal(dic.DValue), "R_GL", "MCW", mTJ, shMember, "", level.ToString(), offer.SQCode, MyHs);
        //                    }
        //                }
        //            }
        //            R_GLDetial(offer, mTJ, shMember, level + 1, minLevel, maxLevel, MyHs);
        //        }
        //    }
        //    return MyHs;
        //}

        # endregion zx_126

        # region zx_179

      

        ///// <summary>
        ///// 冻结提款后3天不排单的
        ///// </summary>
        ///// <returns></returns>
        //public static bool DJBPD()
        //{//未完成
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append(" select SQMID,MAX(SQDate) sqdt from MOfferHelp where PPState = 4 group by SQMID ");
        //    DataTable dt = CommonBase.GetTable(strSql.ToString());
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        if (row["SQMID"] != null)
        //        {
        //            DateTime time = Convert.ToDateTime(row["sqdt"]);
        //            var list = BLL.MOfferHelp.GetList(" SQDate > '" + time.ToString("yyyy-MM-dd HH:mm:ss") + "' and SQDate <= '" + time.AddMinutes(BLL.MMMConfig.Model.OfferHelpRangeCount).ToString("yyyy-MM-dd HH:mm:ss") + "' ");
        //            if (list == null || !list.Any())
        //            {
        //                Hashtable MyHs = new Hashtable();
        //                //冻结账户
        //                MyHs.Add("update member set IsClock='1',IsClose='1',Province='提款未排单' where mid='" + row["SQMID"].ToString() + "'; select '" + Guid.NewGuid().ToString() + "';", null);
        //                CommonBase.RunHashtable(MyHs);
        //            }
        //        }
        //    }
        //    return true;
        //}

        ///// <summary>
        ///// 解冻管理奖
        ///// </summary>
        //public static bool JDGLJ()
        //{
        //    Hashtable MyHs = new Hashtable();
        //    List<Model.ChangeMoney> listChangeMoney = DAL.ChangeMoneyCollection.GetChangeMoneyEntityList(" ChangeType in ('R_GL') and CState=0 and ChangeDate < '" + DateTime.Now.AddMinutes(-BLL.Configuration.Model.DFHOutCount) + "' ");
        //    //解冻奖金
        //    BLL.ChangeMoney.JDChangeTran(listChangeMoney, MyHs);
        //    return CommonBase.RunHashtable(MyHs);
        //}

        //public static bool SJ(Model.Member model)
        //{
        //    Model.Member mTJ = DAL.Member.GetModel(model.MTJ);
        //    if (mTJ != null && mTJ.MID != mTJ.MTJ && !mTJ.Role.IsAdmin)
        //    {
        //        string agency = mTJ.AgencyCode;
        //        //获得可以升级的初步条件
        //        List<Model.SHMoney> shList = DAL.SHMoney.GetList("  TJCount <= " + mTJ.MConfig.TJCount + " and TemaCount <= " + mTJ.MConfig.YJCount + " order by MAgencyType ");
        //        if (mTJ.MConfig.SHMoney > 0)
        //        {
        //            foreach (var item in shList)
        //            {
        //                //if (BLL.Member.GetTJCount(mTJ.MID, item.TJAgency) >= item.TJCount)
        //                {
        //                    mTJ.AgencyCode = item.MAgencyType;
        //                    mTJ.MAgencyType = item;
        //                }
        //            }
        //            if (mTJ.AgencyCode != agency)
        //            {
        //                Hashtable MyHs = new Hashtable();
        //                DAL.Member.UpdateRole(mTJ, MyHs);
        //                if (CommonBase.RunHashtable(MyHs))
        //                {
        //                    return SJ(mTJ);
        //                }
        //            }
        //        }
        //    }
        //    return true;
        //}

        ///// <summary>
        ///// 管理奖推荐奖
        ///// </summary>
        //public static Hashtable R_GL(Model.MOfferHelp offer, int level, Model.Member member, Hashtable MyHs)
        //{
        //    var configs = DAL.NConfigDictionary.GetDicList();
        //    int max = 0;
        //    int min = 0;
        //    try
        //    {
        //        max = configs.Where(m => m.Key == "GLFloat").Max(m => m.Value.Max(mm => mm.EndLevel));
        //        min = configs.Where(m => m.Key == "GLFloat").Min(m => m.Value.Min(mm => mm.StartLevel));
        //    }
        //    catch
        //    { }

        //    R_GLReward(offer, member, member, 1, max, min, MyHs);
        //    return MyHs;
        //}

        ///// <summary>
        ///// 管理奖发放流程     
        ///// </summary>
        //public static Hashtable R_GLReward(Model.MOfferHelp offer, Model.Member member, Model.Member shmodel, int level, int maxLevel, int minLevel, Hashtable MyHs)
        //{
        //    if (level <= maxLevel)
        //    {
        //        Model.Member bdmodel = DAL.Member.GetModel(member.MBD);
        //        if (bdmodel != null && bdmodel.MID != bdmodel.MBD)
        //        {
        //            if (level >= minLevel)
        //            {
        //                Model.NConfigDictionary dic = DAL.NConfigDictionary.GetConfigDictionary(level, bdmodel.MConfig.TJCount, "GLFloat", bdmodel.AgencyCode);
        //                if (dic != null)
        //                {
        //                    decimal money = BLL.MOfferHelp.GetSumMoney(" SQMID = '" + bdmodel.MID + "' and PPState in (0,1,2) ");
        //                    decimal remoney = Math.Min(offer.SQMoney, money) * Convert.ToDecimal(dic.DValue);
        //                    if (level == 1)
        //                    {//一代,推荐奖直接发放
        //                        HBChangeTran(remoney, BLL.Member.ManageMember.TModel.MID, bdmodel.MID, "R_TJ", shmodel, "MHB", offer.SQCode, MyHs);
        //                    }
        //                    else
        //                    {//二代以后,管理奖冻结
        //                        JJChangeTran(remoney, "R_GL", "MHB", bdmodel, shmodel, offer.SQCode, level.ToString(), "", MyHs);
        //                    }
        //                }
        //            }
        //            R_GLReward(offer, bdmodel, shmodel, level + 1, maxLevel, minLevel, MyHs);
        //        }
        //    }
        //    return MyHs;
        //}

        # endregion zx_179

        # region zx_182

        ///// <summary>
        ///// 管理奖
        ///// </summary>
        //public static Hashtable R_GL(Model.MOfferHelp offer, Model.Member member, Model.Member shmodel, Hashtable MyHs)
        //{
        //    Model.Member mBD = DAL.Member.GetModel(member.MBD);
        //    if (mBD != null && mBD.MID != mBD.MBD && !mBD.Role.IsAdmin)
        //    {
        //        HBChangeTran(offer.SQMoney * mBD.MAgencyType.TJFloat, BLL.Member.ManageMember.TModel.MID, mBD.MID, "R_GL", shmodel, "MHB", offer.SQCode, MyHs);
        //        R_GL(offer, mBD, shmodel, MyHs);
        //    }
        //    return MyHs;
        //}

        ///// <summary>
        ///// 管理奖推荐奖
        ///// </summary>
        //public static Hashtable R_TJ(Model.MOfferHelp offer, int level, Model.Member member, Hashtable MyHs)
        //{
        //    var configs = DAL.ConfigDictionary.GetDicList();
        //    int max = 0;
        //    int min = 0;
        //    try
        //    {
        //        max = configs.Where(m => m.Key == "TJFloat").Max(m => m.Value.Max(mm => mm.EndLevel));
        //        min = configs.Where(m => m.Key == "TJFloat").Min(m => m.Value.Min(mm => mm.StartLevel));
        //    }
        //    catch
        //    { }
        //    //会员的第几单
        //    int count = BLL.MOfferHelp.GetOfferCount(offer.SQMID);

        //    R_TJReward(offer, member, member, count, 1, max, min, MyHs);
        //    return MyHs;
        //}

        ///// <summary>
        ///// 管理奖发放流程
        ///// </summary>
        //public static Hashtable R_TJReward(Model.MOfferHelp offer, Model.Member member, Model.Member shmodel, int count, int level, int maxLevel, int minLevel, Hashtable MyHs)
        //{
        //    if (level <= maxLevel)
        //    {
        //        Model.Member bdmodel = DAL.Member.GetModel(member.MTJ);
        //        if (bdmodel != null && bdmodel.MID != bdmodel.MTJ)
        //        {
        //            if (level >= minLevel)
        //            {
        //                Model.ConfigDictionary dic = DAL.ConfigDictionary.GetConfigDictionary(level, "TJFloat", "");
        //                if (dic != null)
        //                {
        //                    decimal money = offer.SQMoney * Convert.ToDecimal(dic.DValue);
        //                    decimal tjMoney = BLL.MOfferHelp.GetMaxOfferMoney(bdmodel.MID);
        //                    if (count <= 2)
        //                    {
        //                        HBChangeTran(money, BLL.Member.ManageMember.TModel.MID, bdmodel.MID, "R_TJ", shmodel, "MHB", offer.SQCode, MyHs);
        //                    }
        //                    else
        //                    {
        //                        //是否比会员最大单大：是减半
        //                        if (tjMoney < offer.SQMoney)
        //                        {
        //                            money = money * (1 - BLL.MMMConfig.Model.LiXi2);
        //                        }
        //                        //没有排单不发
        //                        var off = BLL.MOfferHelp.GetLastMoffer(bdmodel.MID);
        //                        if (off != null)
        //                        {//有排单
        //                            if (off.PPState == 3 || off.PPState == 4)
        //                            {
        //                                //排单没完成，冻结
        //                                JJChangeTran(money, "R_TJ", "MHB", bdmodel, shmodel, offer.SQCode, level.ToString(), "", MyHs);
        //                            }
        //                            else
        //                            {//有完成的单直接发
        //                                HBChangeTran(money, BLL.Member.ManageMember.TModel.MID, bdmodel.MID, "R_TJ", shmodel, "MHB", offer.SQCode, MyHs);
        //                            }
        //                        }
        //                    }
        //                }
        //            }
        //            R_TJReward(offer, bdmodel, shmodel, level + 1, count, maxLevel, minLevel, MyHs);
        //        }
        //    }
        //    return MyHs;
        //}

        ///// <summary>
        ///// 签到奖
        ///// </summary>
        //public static string R_QD(Model.Member member)
        //{
        //    //获得钱数
        //    Model.MOfferHelp offer = BLL.MOfferHelp.GetQDOfferMoney(member.MID);
        //    if (offer != null)
        //    {
        //        var list = BLL.ChangeMoney.GetList(" CRemarks = '" + offer.SQCode + "' and DATEDIFF(DD,ChangeDate,GETDATE()) = 0 ");
        //        if (list == null || !list.Any())
        //        {
        //            if (CommonBase.RunHashtable(JJChangeTran(offer.SQMoney * BLL.MMMConfig.Model.LiXi1, "R_QD", "MHB", member, member, offer.SQCode, "", "", new Hashtable())))
        //            {
        //                return "签到奖领取成功,提款时发放";
        //            }
        //            return "签到奖领取失败";
        //        }
        //        else
        //        {
        //            return "您今日已领过签到奖";
        //        }
        //    }
        //    return "没有可领取签到奖";
        //}

        ///// <summary>
        ///// 抢单奖
        ///// </summary>
        ///// <param name="offer"></param>
        ///// <param name="member"></param>
        ///// <param name="MyHs"></param>
        ///// <returns></returns>
        //public static Hashtable R_QDZF(Model.MOfferHelp offer, Model.Member member, Hashtable MyHs)
        //{
        //    if (offer.HelpType == 1)
        //    {
        //        HBChangeTran(BLL.MMMConfigScramble.Model.ScrambleReward, BLL.Member.ManageMember.TModel.MID, member.MID, "R_QDZF", member, "MHB", offer.SQCode, MyHs);
        //    }
        //    return MyHs;
        //}

        ///// <summary>
        ///// 升级
        ///// </summary>
        //public static bool R_SJ(Model.Member member)
        //{
        //    Model.Member mTJ = DAL.Member.GetModel(member.MTJ);
        //    if (mTJ != null && !mTJ.Role.IsAdmin && mTJ.MID != mTJ.MTJ)
        //    {
        //        //获得可升级的等级
        //        var shMoney = DAL.SHMoney.GetSJShmoney(mTJ.MConfig.YJCount, mTJ.MConfig.TJCount, mTJ.AgencyCode);
        //        if (shMoney != null)
        //        {
        //            //升级
        //            mTJ.AgencyCode = shMoney.MAgencyType;
        //            mTJ.MAgencyType = shMoney;
        //            CommonBase.RunHashtable(DAL.Member.UpdateRole(mTJ, new Hashtable()));
        //        }
        //        R_SJ(mTJ);
        //    }

        //    return true;
        //}

        ///// <summary>
        ///// 返还激活码
        ///// </summary>
        //public static Hashtable FHJHM(Model.MOfferHelp offer, Model.Member member, Hashtable MyHs)
        //{
        //    //是否第一单
        //    if (BLL.MOfferHelp.GetOfferCount(offer.SQMID) == 0)
        //    {
        //        HBChangeTran(BLL.MMMConfig.Model.ActiveCodePrice, BLL.Member.ManageMember.TModel.MID, member.MID, "R_HZFH", member, "MHB", offer.SQCode, MyHs);
        //        //生成订单
        //        BLL.MGetHelp.GetHelp(member, "MHB", BLL.MMMConfig.Model.ActiveCodePrice, false);
        //    }

        //    return MyHs;
        //}

        ///// <summary>
        ///// 复投分红
        ///// </summary>
        //public static bool FTFH()
        //{
        //    List<Model.BMember> list = BLL.BMember.GetList(string.Format(" BMState = 0 and FHDays < {0} ", BLL.Configuration.Model.MinBuyGCount));
        //    Hashtable MyHs = new Hashtable();
        //    foreach (var model in list)
        //    {
        //        decimal money = model.BCount * BLL.Configuration.Model.JMGPPart;
        //        model.FHDays++;
        //        model.YJMoney += money; ;
        //        if (model.FHDays >= BLL.Configuration.Model.MinBuyGCount)
        //        {
        //            model.BMState = true;
        //        }
        //        BLL.BMember.Update(model, MyHs);
        //        HBChangeTran(money, BLL.Member.ManageMember.TModel.MID, model.AMID, "R_FTFH", null, "MCW", "", MyHs);
        //    }
        //    return CommonBase.RunHashtable(MyHs);
        //}

        # endregion zx_182

        # region zx_197

        ///// <summary>
        ///// 管理奖推荐奖
        ///// </summary>
        //public static Hashtable R_LD(Model.MOfferHelp offer, Model.Member member, Hashtable MyHs)
        //{
        //    var configs = DAL.ConfigDictionary.GetDicList();
        //    int max = 0;
        //    int min = 0;
        //    try
        //    {
        //        max = configs.Where(m => m.Key == "LDFloat").Max(m => m.Value.Max(mm => mm.EndLevel));
        //        min = configs.Where(m => m.Key == "LDFloat").Min(m => m.Value.Min(mm => mm.StartLevel));
        //    }
        //    catch
        //    { }
        //    //会员的第几单
        //    int count = BLL.MOfferHelp.GetOfferCount(offer.SQMID);

        //    R_LDReward(offer, member, member, count, 1, max, min, MyHs);
        //    return MyHs;
        //}

        ///// <summary>
        ///// 管理奖发放流程
        ///// </summary>
        //public static Hashtable R_LDReward(Model.MOfferHelp offer, Model.Member member, Model.Member shmodel, int count, int level, int maxLevel, int minLevel, Hashtable MyHs)
        //{
        //    if (level <= maxLevel)
        //    {
        //        Model.Member bdmodel = DAL.Member.GetModel(member.MTJ);
        //        if (bdmodel != null && bdmodel.MID != bdmodel.MTJ)
        //        {
        //            if (level >= minLevel)
        //            {
        //                Model.ConfigDictionary dic = DAL.ConfigDictionary.GetConfigDictionary(level, "LDFloat", bdmodel.AgencyCode);
        //                if (dic != null)
        //                {
        //                    decimal money = offer.SQMoney * Convert.ToDecimal(dic.DValue);
        //                    Model.MOfferHelp tjOffer = BLL.MOfferHelp.GetLastMoffer(bdmodel.MID);
        //                    money = Math.Min(offer.SQMoney, tjOffer.SQMoney);
        //                    if (level > 1)
        //                    {
        //                        JJChangeTran(money, "R_LD", "MCW", bdmodel, shmodel, offer.SQCode, level.ToString(), "", MyHs);
        //                    }
        //                    else
        //                    {
        //                        HBChangeTran(money, BLL.Member.ManageMember.TModel.MID, bdmodel.MID, "R_LD", shmodel, "MCW", offer.SQCode, MyHs);
        //                    }
        //                }
        //            }
        //            R_LDReward(offer, bdmodel, shmodel, level + 1, count, maxLevel, minLevel, MyHs);
        //        }
        //    }
        //    return MyHs;
        //}

        ///// <summary>
        ///// 升级
        ///// </summary>
        //public static bool R_SJ(string mid)
        //{
        //    Model.Member mTJ = DAL.Member.GetModel(mid);
        //    if (mTJ != null && !mTJ.Role.IsAdmin && mTJ.MID != mTJ.MTJ)
        //    {
        //        //获得可升级的等级
        //        if (mTJ.AgencyCode != "002")
        //        {
        //            var shMoney = DAL.SHMoney.GetSJShmoney(mTJ.MConfig.YJCount, mTJ.MConfig.TJCount, mTJ.AgencyCode);
        //            if (shMoney != null)
        //            {
        //                //升级
        //                mTJ.AgencyCode = shMoney.MAgencyType;
        //                mTJ.MAgencyType = shMoney;
        //                CommonBase.RunHashtable(DAL.Member.UpdateRole(mTJ, new Hashtable()));
        //            }
        //        }
        //        R_SJ(mTJ.MTJ);
        //    }
        //    return true;
        //}

        ///// <summary>
        ///// 激活后两天不排单的
        ///// </summary>
        ///// <returns></returns>
        //public static bool DJWDK()
        //{
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append(" update Member set IsClock = 1 , IsClose = 1 where IsClock = 0 and IsClose = 0 and RoleCode <> 'Manage' and MID in ( select * from Member where MID not in (select MID from Member where MID not in ( select SQMID from MOfferHelp where SQDate < '" + DateTime.Now.AddMinutes(-BLL.MMMConfig.Model.OfferHelpRangeTimes) + "' and PPState <> 5 ) ) ) ");
        //    CommonBase.GetSingle(strSql.ToString());
        //    return true;
        //}

        ///// <summary>
        ///// 冻结提款后3天不排单的
        ///// </summary>
        ///// <returns></returns>
        //public static bool DJBPD()
        //{//未完成
        //    StringBuilder strSql = new StringBuilder();
        //    strSql.Append(" select SQMID,MAX(SQDate) sqdt from MOfferHelp where PPState = 4 group by SQMID ");
        //    DataTable dt = CommonBase.GetTable(strSql.ToString());
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        if (row["SQMID"] != null)
        //        {
        //            DateTime time = Convert.ToDateTime(row["sqdt"]);
        //            var list = BLL.MOfferHelp.GetList(" SQDate > '" + time.ToString("yyyy-MM-dd HH:mm:ss") + "' and SQDate <= '" + time.AddMinutes(BLL.MMMConfig.Model.OfferHelpRangeCount).ToString("yyyy-MM-dd HH:mm:ss") + "' ");
        //            if (list == null || !list.Any())
        //            {
        //                Hashtable MyHs = new Hashtable();
        //                //冻结账户
        //                MyHs.Add("update member set IsClock='1',IsClose='1',Province='提款未排单' where mid='" + row["SQMID"].ToString() + "'; select '" + Guid.NewGuid().ToString() + "';", null);
        //                CommonBase.RunHashtable(MyHs);
        //            }
        //        }
        //    }
        //    return true;
        //}

        ///// <summary>
        ///// 解冻领导奖
        ///// </summary>
        //public static bool JDGLJ()
        //{
        //    Hashtable MyHs = new Hashtable();
        //    List<Model.ChangeMoney> listChangeMoney = DAL.ChangeMoneyCollection.GetChangeMoneyEntityList(" ChangeType in ('R_LD') and CState=0 and ChangeDate < '" + DateTime.Now.AddMinutes(-BLL.MMMConfig.Model.GLRewardFreezeTimes) + "' ");
        //    //解冻奖金
        //    BLL.ChangeMoney.JDChangeTran(listChangeMoney, MyHs);
        //    return CommonBase.RunHashtable(MyHs);
        //}

        ///// <summary>
        ///// 超时没人抢订单消失
        ///// </summary>
        //public static bool CSMOffer()
        //{
        //    Hashtable MyHs = new Hashtable();
        //    //冻结账户
        //    MyHs.Add(" update MOfferHelp set HelpType = 97 where HelpType = 98 and DATEADD(mi," + BLL.MMMConfigScramble.Model.DisappearTimes + ",SQDate) < GETDATE() ", null);
        //    return CommonBase.RunHashtable(MyHs);
        //}

        # endregion zx_197

        # region zx_202

        /// <summary>
        /// 推荐奖
        /// </summary>
        public static Hashtable R_TJ(Model.MOfferHelp off, Model.Member member, Hashtable MyHs)
        {
            Model.Member mTJ = DAL.Member.GetModel(member.MTJ);
            if (mTJ != null && mTJ.MID != mTJ.MTJ)
            {
                Model.MOfferHelp tjoff= BLL.MOfferHelp.GetList(" SQMID='"+mTJ.MID+"' and PPState in(0,1,2,3,4) order by SQDate desc;").FirstOrDefault() ;
                if (tjoff != null)
                {
                    decimal money = tjoff.SQMoney>off.SQMoney?off.SQMoney:tjoff.SQMoney;

                    HBChangeTran(money * mTJ.MAgencyType.TJFloat, BLL.Member.ManageMember.TModel.MID, mTJ.MID, "R_TJ", member, "MJB", off.SQCode, MyHs);
                }
            }
            return MyHs;
        }

        /// <summary>
        /// 管理奖推荐奖
        /// </summary>
        public static Hashtable R_GL(Model.MOfferHelp match, Model.Member member, Hashtable MyHs)
        {
            var configs = DAL.ConfigDictionary.GetDicList();
            int max = 0;
            int min = 0;
            try
            {
                max = configs.Where(m => m.Key == "GLFloat").Max(m => m.Value.Max(mm => mm.EndLevel));
                min = configs.Where(m => m.Key == "GLFloat").Min(m => m.Value.Min(mm => mm.StartLevel));
            }
            catch
            { }
            //会员的第几单
            //int count = BLL.MOfferHelp.GetOfferCount(offer.SQMID);
            int count = 0;

            R_LDReward(match, member, member, count, 1, max, min, MyHs);
            return MyHs;
        }

        /// <summary>
        /// 管理奖发放流程
        /// </summary>
        public static Hashtable R_LDReward(Model.MOfferHelp match, Model.Member member, Model.Member shmodel, int count, int level, int maxLevel, int minLevel, Hashtable MyHs)
        {
            if (level <= maxLevel)
            {
                Model.Member bdmodel = DAL.Member.GetModel(member.MTJ);
                if (bdmodel != null && bdmodel.MID != bdmodel.MTJ)
                {
                    if (level >= minLevel&&bdmodel.MConfig.EPXingCount>0)
                    {
                        Model.ConfigDictionary dic = DAL.ConfigDictionary.GetConfigDictionary(level, "GLFloat", "");

                        Model.ConfigDictionary diclevel = DAL.ConfigDictionary.GetConfigDictionary(1, "GLLevel", bdmodel.AgencyCode);//拿的层数
                        if (dic != null&&diclevel!=null)
                        {
                            //管理奖烧伤：伞下会员级别超过推荐人，只能拿到该会员本身的奖金，拿不到这个会员伞下管理奖金
                            int agmember = Convert.ToInt32(member.AgencyCode);
                            int tjagmember = Convert.ToInt32(bdmodel.AgencyCode);
                            bool isfj = true;
                            if (agmember > tjagmember && level > 1)
                            {
                                isfj = false;
                            }
                            if (Convert.ToInt32(diclevel.DValue) >= level&& isfj) //如果能拿层数大于等于当前层数就得奖
                            {
                                decimal money = match.SQMoney;
                                money = money * Convert.ToDecimal(dic.DValue);
                                //封顶
                                decimal lsmoney= Convert.ToDecimal( BLL.CommonBase.GetSingle("select ISNULL(SUM(MONEY),0) from ChangeMoney where ToMID='"+bdmodel.MID+"' and CState=1 and ChangeType='R_GL' AND DATEDIFF(DAY,ChangeDate,GETDATE())=0;"));
                                if ((lsmoney + money) > bdmodel.MAgencyType.DTopMoney)
                                {
                                    money = bdmodel.MAgencyType.DTopMoney - lsmoney;
                                    if (money < 0)
                                        money = 0;
                                }
                                HBChangeTran(money, BLL.Member.ManageMember.TModel.MID, bdmodel.MID, "R_GL", shmodel, "MJB", match.SQCode, MyHs);
                            }
                        }
                    }
                    R_LDReward(match, bdmodel, shmodel, count, level + 1, maxLevel, minLevel, MyHs);
                }
            }
            return MyHs;
        }

        /// <summary>
        /// 升级
        /// </summary>
        public static bool R_SJ(string mid)
        {
            Model.Member mTJ = DAL.Member.GetModel(mid);
            if (mTJ != null && !mTJ.Role.IsAdmin && mTJ.MID != mTJ.MTJ)
            {
                //获得可升级的等级

                Model.NConfigDictionary ncd= DAL.NConfigDictionary.GetConfigDictionary(0,"AutoSJ",mTJ.AgencyCode);
                //var shMoney = DAL.SHMoney.GetSJShmoney(mTJ.MConfig.YJCount, mTJ.MConfig.TJCount, mTJ.AgencyCode);
                if (ncd != null)
                {
                    int count= BLL.Member.GetTJCount(mTJ.MID,ncd.Remark);
                    if (count >= ncd.StartRec && count <= ncd.EndRec)
                    {
                        var shMoney = BLL.Configuration.Model.SHMoneyList[ncd.DValue];
                        //升级
                        mTJ.AgencyCode = shMoney.MAgencyType;
                        mTJ.MAgencyType = shMoney;
                        CommonBase.RunHashtable(DAL.Member.UpdateRole(mTJ, new Hashtable()));
                    }
                }
                R_SJ(mTJ.MTJ);
            }
            return true;
        }

        /// <summary>
        /// 激活后两天不排单的
        /// </summary>
        /// <returns></returns>
        public static bool DJWDK()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Member set IsClock = 1 , IsClose = 1,Province='超时未排单' where IsClock = 0 and IsClose = 0 and RoleCode = 'Nomal' and MCreateDate < '" + DateTime.Now.AddMinutes(-BLL.MMMConfig.Model.FreezeTimesOfRegister) + "' and MID not in (select SQMID from MOfferHelp where  PPState <> 5)");
            CommonBase.GetSingle(strSql.ToString());
            return true;
        }

        /// <summary>
        /// 冻结提款后3天不排单的
        /// </summary>
        /// <returns></returns>
        public static bool DJBPD()
        {//未完成
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" select SQMID,SQMoney,MAX(ComfirmDate) sqdt from MGetHelp where PPState in (3) and ConfirmState=3 and DATEDIFF(MI,ComfirmDate,GETDATE()) > "+ BLL.MMMConfig.Model.GLRewardFreezeTimes +"  group by SQMID,SQMoney; ");
            DataTable dt = CommonBase.GetTable(strSql.ToString());
            foreach (DataRow row in dt.Rows)
            {
                if (row["SQMID"] != null)
                {
                    DateTime time = Convert.ToDateTime(row["sqdt"]);
                    var list = BLL.MOfferHelp.GetList(" SQMID = '" + row["SQMID"] + "' and PPState <> 5 and SQDate > '" + time.ToString("yyyy-MM-dd HH:mm:ss") + "'; ");
                    var list2 = BLL.MOfferHelp.GetList(" SQMID = '" + row["SQMID"] + "' and PPState < 3 ; ");//查看是否有未完成的订单

                    if (list2.Count == 0) 
                    {
                        if (list == null || !list.Any())
                        {
                            BLL.CommonBase.RunSql("update Member set IsClock = 1 , IsClose = 1,Province='收款完成未排单' where IsClock = 0 and IsClose = 0 and RoleCode = 'Nomal' and MID='" + row["SQMID"] + "' ;");
                        }
                    }
                    
                }
            }
            return true;
        }

        /// <summary>
        /// 解冻领导奖
        /// </summary>
        public static bool JDGLJ()
        {
            Hashtable MyHs = new Hashtable();
            List<Model.ChangeMoney> listChangeMoney = DAL.ChangeMoneyCollection.GetChangeMoneyEntityList(" ChangeType in ('R_LD','R_TJ') and CState=0 and ChangeDate < '" + DateTime.Now.AddMinutes(-BLL.MMMConfig.Model.GLRewardFreezeTimes) + "' ");
            //解冻奖金
            BLL.ChangeMoney.JDChangeTran(listChangeMoney, MyHs);
            return CommonBase.RunHashtable(MyHs);
        }

        #endregion zx_202


       
    }
}