using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.Collections;
using System.Data;

namespace WE_Project.BLL
{
    //FDBuyList
    public class FDBuyList
    {
        public static WE_Project.Model.FDBuyList GetModel(object obj)
        {
            return WE_Project.DAL.FDBuyList.GetModel(obj);
        }

        public static Hashtable Insert(WE_Project.Model.FDBuyList model, Hashtable MyHs)
        {
            BLL.ChangeMoney.HBChangeTran(model.BuyMoney, model.BuyMID, BLL.Member.ManageMember.TModel.MID, "GM", null, "MGP", "", MyHs);
            return WE_Project.DAL.FDBuyList.Insert(model, MyHs);
        }

        public static string Insert(WE_Project.Model.FDBuyList model)
        {
            if (BLL.FDConfig.FDConfigModel[model.BuyFDName].ISOpen)
            {
                Model.Member member = DAL.Member.GetModel(model.BuyMID);
                if (member.RoleCode == "Notactive")
                {
                    return "体验会员不允许购买，请先升级再进行购买";
                }
                if (member.MConfig.FDTrade == model.BuyFDName)
                {
                    lock (BLL.FDConfig.FDConfigModel)
                    {
                        if (BLL.ChangeMoney.EnoughChange(model.BuyMID, model.BuyCount * model.BuyPrice, model.MoneyType))
                        {
                            List<Model.FDSellList> listsell = BLL.FDSellList.GetList("SellState<2 and SellFDName='" + model.BuyFDName + "' order by BuyDate");
                            int buycount = model.BuyCount;
                            Hashtable MyHs = new Hashtable();
                            foreach (Model.FDSellList item in listsell)
                            {
                                int sell = item.SellTotalCount - item.SellCount;
                                if (buycount >= sell)
                                {
                                    buycount -= sell;
                                    item.SellCount += sell;
                                    item.SellMoney += item.SellPrice * sell;
                                    item.SellState = 2;
                                    item.LastSellDate = DateTime.Now;
                                    item.SellDate = DateTime.Now;
                                    BLL.ChangeMoney.HBChangeTran(item.SellPrice * sell, BLL.Member.ManageMember.TModel.MID, item.SellMID, "FDYJ", null, "MHB", model.BuyFDName, MyHs);
                                    BLL.FDSellList.Update(item, MyHs);
                                }
                                else
                                {
                                    item.SellCount += buycount;
                                    item.SellMoney += buycount * item.SellPrice;
                                    item.SellState = 1;
                                    item.LastSellDate = DateTime.Now;
                                    item.SellDate = DateTime.Now;
                                    BLL.ChangeMoney.HBChangeTran(item.SellPrice * buycount, BLL.Member.ManageMember.TModel.MID, item.SellMID, "FDYJ", null, "MHB", model.BuyFDName, MyHs);
                                    BLL.FDSellList.Update(item, MyHs);
                                    buycount = 0;
                                    break;
                                }
                            }
                            if (buycount > 0 || listsell.Sum(emp => (emp.SellTotalCount - emp.SellCount)) == 0)
                            {
                                Model.FDConfig fdconfig = BLL.FDConfig.FDConfigModel[model.BuyFDName];
                                fdconfig.FDState = false;
                                BLL.FDConfig.Update(fdconfig, MyHs);
                                BLL.FDConfig.FDConfigModel = null;
                            }
                            model.BuyCount -= buycount;
                            if (model.BuyCount > 0)
                            {
                                model.BuyMoney = model.BuyCount * model.BuyPrice;
                                BLL.FDBuyList.Insert(model, MyHs);
                                if (BLL.CommonBase.RunHashtable(MyHs))
                                {
                                    if (buycount > 0)
                                        BLL.FDConfig.FDConfigModel = null;
                                    return "买入成功";
                                }
                                return "买入失败";
                            }
                        }
                        else
                        {
                            return "你的FD币不足!";
                        }
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(member.MConfig.FDTrade))
                    {
                        return "请先重置，再进行购买";
                    }
                    else
                    {
                        return "您当前只允许" + member.MConfig.FDTrade + "盘交易";
                    }
                }
            }
            return BLL.FDConfig.FDConfigModel[model.BuyFDName].FDCloseRemark;
            //return WE_Project.DAL.FDBuyList.Insert(model);
        }

        public static Hashtable Update(WE_Project.Model.FDBuyList model, Hashtable MyHs)
        {
            return WE_Project.DAL.FDBuyList.Update(model, MyHs);
        }

        public static bool Update(WE_Project.Model.FDBuyList model)
        {
            return WE_Project.DAL.FDBuyList.Update(model);
        }

        public static Hashtable Delete(object obj, Hashtable MyHs)
        {
            return WE_Project.DAL.FDBuyList.Delete(obj, MyHs);
        }

        public static bool Delete(object obj)
        {
            return WE_Project.DAL.FDBuyList.Delete(obj);
        }

        public static DataTable GetTable(string strWhere)
        {
            return WE_Project.DAL.FDBuyList.GetTable(strWhere);
        }

        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.FDBuyList.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public static List<WE_Project.Model.FDBuyList> GetList(string strWhere)
        {
            return WE_Project.DAL.FDBuyList.GetList(strWhere);
        }

        public static List<WE_Project.Model.FDBuyList> GetList(int top, string strWhere)
        {
            return WE_Project.DAL.FDBuyList.GetList(top, strWhere);
        }

        public static List<WE_Project.Model.FDBuyList> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.FDBuyList.GetList(strWhere, pageIndex, pageSize, out count);
        }
    }
}
