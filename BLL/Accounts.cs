using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace WE_Project.BLL
{
    public class Accounts
    {
        public static Model.Accounts tempAccount { get; set; }
        public static Hashtable BDInsert(Model.Accounts model, Hashtable MyHs)
        {
            BLL.ChangeMoney.FHChangeTran(model, MyHs);
            model.IfAccount = true;
            model.AccountsDate = DateTime.Now;
            DAL.Accounts.Insert(model, MyHs);
            return MyHs;
        }

        public static bool AutoFH()
        {
            Model.Accounts model = new Model.Accounts();
            model.CreateDate = DateTime.Now;
            model.IsAuto = true;
            model.PCode = "003";
            if (BLL.Configuration.Model.AutoDFH)
            {
                return BLL.Accounts.Insert(model);
            }
            return false;
        }

        public static bool Insert(Model.Accounts model)
        {
            lock (DAL.Member.tempMemberList)
            {
                DAL.Member.tempMemberList.Clear();
                Hashtable MyHs = new Hashtable();
                BLL.ChangeMoney.FHChangeTran(model, MyHs);
                if (model.TotalFHMoney > 0)
                {
                    model.IfAccount = true;
                    model.AccountsDate = DateTime.Now;
                    DAL.Accounts.Insert(model, MyHs);
                }
                //这个地方需要在每日分红的时候对分红股进行分红，主要是对BMember表进行操作，对每次投资进行分红
                //TranFHGMoney(model.AccountMember,MyHs);
                return DAL.CommonBase.RunHashtable(MyHs);
            }
        }


        public static Hashtable Insert(Model.Accounts model, Hashtable MyHs)
        {
            lock (DAL.Member.tempMemberList)
            {
                DAL.Member.tempMemberList.Clear();
                BLL.ChangeMoney.FHChangeTran(model, MyHs);
                if (model.TotalFHMoney > 0)
                {
                    model.IfAccount = true;
                    model.AccountsDate = DateTime.Now;
                    DAL.Accounts.Insert(model, MyHs);
                }
                return MyHs;
            }
           
        }

        public static Hashtable Update(Model.Accounts model, Hashtable MyHs)
        {
            if (!model.IfAccount)
            {
                lock (DAL.Member.tempMemberList)
                {
                    DAL.Member.tempMemberList.Clear();
                    BLL.ChangeMoney.FHChangeTran(model, MyHs);
                    model.IfAccount = true;
                    model.AccountsDate = DateTime.Now;
                }
            }
            DAL.Accounts.Update(model, MyHs);
            return MyHs;
        }
        public static bool Update(Model.Accounts model)
        {
            Hashtable MyHs = new Hashtable();
            DAL.Accounts.Update(model, MyHs);
            return DAL.CommonBase.RunHashtable(MyHs);
        }
        public static bool Delete(string CodeList)
        {
            return DAL.Accounts.Delete("'" + CodeList + "'");
        }
        public static Hashtable Delete(string lzTypeCodeList, Hashtable MyHs)
        {
            DAL.Accounts.Delete(lzTypeCodeList, MyHs);
            return MyHs;
        }
        public static List<Model.Accounts> GetList(string strWhere)
        {
            return DAL.Accounts.GetList(strWhere);
        }
        public static List<Model.Accounts> GetList(int top, string strWhere)
        {
            return DAL.Accounts.GetList(top, strWhere);
        }

        public static List<Model.Accounts> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return DAL.Accounts.GetList(strWhere, pageIndex, pageSize, out count);
        }
        public static Model.Accounts GetModel(string typeCode)
        {
            return DAL.Accounts.GetModel(typeCode);
        }

        public static Model.Accounts GetTopModel(string pCode, string remark)
        {
            return DAL.Accounts.GetTopModel(pCode, remark);
        }

        public static string GetFHInfo(string pCode, string remark)
        {
            return DAL.Accounts.GetFHInfo(pCode, remark);
        }
    }
}
