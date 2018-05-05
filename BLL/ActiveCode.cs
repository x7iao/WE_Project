using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace WE_Project.BLL
{
    //ActiveCode
    public class ActiveCode
    {
        public static Model.ActiveCode GetModel(object obj)
        {
            return WE_Project.DAL.ActiveCode.GetModel(obj);
        }

        public static Hashtable Insert(Model.ActiveCode model, Hashtable MyHs)
        {
            return WE_Project.DAL.ActiveCode.Insert(model, MyHs);
        }

        public static bool Insert(Model.ActiveCode model)
        {
            return WE_Project.DAL.ActiveCode.Insert(model);
        }

        public static Hashtable Update(Model.ActiveCode model, Hashtable MyHs)
        {
            return WE_Project.DAL.ActiveCode.Update(model, MyHs);
        }

        public static bool Update(Model.ActiveCode model)
        {
            return WE_Project.DAL.ActiveCode.Update(model);
        }

        public static Hashtable Delete(object obj, Hashtable MyHs)
        {
            return WE_Project.DAL.ActiveCode.Delete(obj, MyHs);
        }

        public static bool Delete(object obj)
        {
            return WE_Project.DAL.ActiveCode.Delete(obj);
        }
        public static Hashtable LockActiveCode(object obj, Hashtable MyHs)
        {
            return WE_Project.DAL.ActiveCode.LockActiveCode(obj, MyHs);
        }

        public static DataTable GetTable(string strWhere)
        {
            return WE_Project.DAL.ActiveCode.GetTable(strWhere);
        }

        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.ActiveCode.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public static List<Model.ActiveCode> GetList(string strWhere)
        {
            return WE_Project.DAL.ActiveCode.GetList(strWhere);
        }
        public static List<Model.ActiveCode> GetTopList(string strWhere, int top)
        {
            return WE_Project.DAL.ActiveCode.GetTopList(strWhere, top);
        }

        public static List<Model.ActiveCode> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.ActiveCode.GetList(strWhere, pageIndex, pageSize, out count);
        }

        private static object obj = new object();

        public static string BuyActiveCode(Model.Member member, Model.Member sellModel, int count)
        {
            lock (obj)
            {
                Hashtable MyHs = new Hashtable();
                List<Model.ActiveCode> codeList = BLL.ActiveCode.GetTopList("UseState=0 and MID='" + sellModel.MID + "'", count);
                decimal money = BLL.MMMConfig.Model.ActiveCodePrice * count;
                if (!BLL.ChangeMoney.EnoughChange(member.MID, money, "MJB"))
                {
                    return "当前互助币不足，无法购买";
                }
                if (codeList.Count >= count)
                {
                    foreach (Model.ActiveCode ac in codeList)
                    {
                        ac.MID = member.MID;
                        ac.SwitchType = "购买";
                        BLL.ActiveCode.Update(ac, MyHs);
                        //BLL.ChangeMoney.InsertTran(new Model.ChangeMoney { FromMID = sellModel.MID, ToMID = member.MID, CompleteTime = DateTime.Now, ChangeType = "BuyActive", MoneyType = "MJB", CRemarks = ac.Code, ChangeDate = DateTime.Now, CState = true }, MyHs);
                        BLL.ChangeMoney.HBChangeTran(money, member.MID, sellModel.MID, "BuyActive", null, "MJB", "购买激活码", MyHs);
                    }
                    if (BLL.CommonBase.RunHashtable(MyHs))
                    {
                        return "购买成功";
                    }
                    else
                    {
                        return "购买失败";
                    }
                }
                else
                {
                    return "当前激活码数量不足";
                }
            }
        }
    }
}
