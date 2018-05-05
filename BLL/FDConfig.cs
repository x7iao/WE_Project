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
    //FDConfig
    public class FDConfig
    {
        public static Dictionary<string, Model.FDConfig> FDConfigModel
        {
            get
            {
                return DAL.FDConfig.FDConfigModel;
            }
            set
            {
                DAL.FDConfig.FDConfigModel = value;
            }
        }
        /// <summary>
        /// 清仓
        /// </summary>
        /// <param name="FDName"></param>
        /// <returns></returns>
        public static bool QingCang(string FDName)
        {
            Hashtable MyHs = new Hashtable();
            DataTable table = BLL.CommonBase.GetTable("select BuyMID,SUM(buycount*buyprice),MoneyType from FDBuyList where CFState='0' and BuyState=0 and BuyFDName='" + FDName + "' group by BuyMID,MoneyType");
            MyHs.Add("update FDBuyList set BuyState='1' where CFState='0' and BuyState=0 and BuyFDName='" + FDName + "'", null);
            foreach (DataRow dr in table.Rows)
            {
                BLL.ChangeMoney.HBChangeTran(Convert.ToDecimal(dr[1]), BLL.Member.ManageMember.TModel.MID, dr[0].ToString(), "QC", null, dr[2].ToString(), "", MyHs);
            }
            DataTable table2 = BLL.CommonBase.GetTable("select SellMID,SUM((SellTotalCount-SellCount)*SellPrice) from FDSellList where SellState<2 and SellFDName='" + FDName + "' group by SellMID");
            MyHs.Add("update FDSellList set SellState=3 where SellState<2 and SellFDName='" + FDName + "'", null);
            foreach (DataRow dr in table2.Rows)
            {
                BLL.ChangeMoney.HBChangeTran(Convert.ToDecimal(dr[1]), BLL.Member.ManageMember.TModel.MID, dr[0].ToString(), "QC", null, "MGP", "", MyHs);
            }
            return BLL.CommonBase.RunHashtable(MyHs);
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="FDName"></param>
        /// <returns></returns>
        public static bool Reset(string FDName)
        {
            Hashtable MyHs = new Hashtable();
            MyHs.Add("delete from FDBuyList where BuyFDName='" + FDName + "'", null);
            MyHs.Add("delete from FDSellList where SellFDName='" + FDName + "'", null);
            return BLL.CommonBase.RunHashtable(MyHs);
        }
        /// <summary>
        /// 拆分
        /// </summary>
        /// <param name="FDName"></param>
        /// <returns></returns>
        public static bool ChaiFen(string FDName)
        {
            Hashtable MyHs = new Hashtable();
            DataTable table = BLL.CommonBase.GetTable("select BuyID,BuyMID,BuyCount,BuyDate,BuyPrice from FDBuyList where CFState='0' and BuyState=0 and BuyFDName='" + FDName + "' order by BuyID");

            foreach (DataRow dr in table.Rows)
            {
                BLL.FDSellList.Insert(new Model.FDSellList
                {
                    BuyDate = Convert.ToDateTime(dr[3]),
                    BuyID = Convert.ToInt32(dr[0]),
                    LastSellDate = DateTime.MaxValue,
                    SellDate = DateTime.MaxValue,
                    SellFDName = FDName,
                    SellMID = dr[1].ToString(),
                    SellPrice = Convert.ToDecimal(dr[4]),
                    SellTotalCount = (int)(Convert.ToInt32(dr[2]) * BLL.FDConfig.FDConfigModel[FDName].FDCFFloat),
                    ChaiFenCode = BLL.FDConfig.FDConfigModel[FDName].ChaiFenCode + 1
                }, MyHs);
                string type = "";
                if (FDName == "A")
                {
                    type = "B";
                }
                else if (FDName == "B")
                {
                    type = "C";
                }
                else if (FDName == "C")
                {
                    type = "D";
                }
                else if (FDName == "D")
                {
                    type = "";
                }
                DAL.MemberConfig.UpdateConfigTran(dr[1].ToString(), "FDTrade", type, null, true, SqlDbType.VarChar, MyHs);
            }
            MyHs.Add("update FDBuyList set CFState='1' where CFState='0' and BuyState=0 and BuyFDName='" + FDName + "'", null);
            return BLL.CommonBase.RunHashtable(MyHs);
        }
        public static WE_Project.Model.FDConfig GetModel()
        {
            return WE_Project.DAL.FDConfig.GetModel();
        }

        public static Hashtable Insert(WE_Project.Model.FDConfig model, Hashtable MyHs)
        {
            return WE_Project.DAL.FDConfig.Insert(model, MyHs);
        }

        public static bool Insert(WE_Project.Model.FDConfig model)
        {
            return WE_Project.DAL.FDConfig.Insert(model);
        }

        public static Hashtable Update(WE_Project.Model.FDConfig model, Hashtable MyHs)
        {
            return WE_Project.DAL.FDConfig.Update(model, MyHs);
        }

        public static bool Update(WE_Project.Model.FDConfig model)
        {
            return WE_Project.DAL.FDConfig.Update(model);
        }

        public static Hashtable Delete(object obj, Hashtable MyHs)
        {
            return WE_Project.DAL.FDConfig.Delete(obj, MyHs);
        }

        public static bool Delete(object obj)
        {
            return WE_Project.DAL.FDConfig.Delete(obj);
        }

        public static DataTable GetTable(string strWhere)
        {
            return WE_Project.DAL.FDConfig.GetTable(strWhere);
        }

        public static DataTable GetTable(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.FDConfig.GetTable(strWhere, pageIndex, pageSize, out count);
        }

        public static Dictionary<string, WE_Project.Model.FDConfig> GetList(string strWhere)
        {
            return WE_Project.DAL.FDConfig.GetList(strWhere);
        }

        public static List<WE_Project.Model.FDConfig> GetList(string strWhere, int pageIndex, int pageSize, out int count)
        {
            return WE_Project.DAL.FDConfig.GetList(strWhere, pageIndex, pageSize, out count);
        }
    }
}
