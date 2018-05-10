using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Collections;

namespace WE_Project.Web.SysManage
{
    public partial class Configuration : BasePage
    {
        protected override void SetPowerZone()
        {
            ConfigurationModel = BLL.Configuration.Model;
        }

        public Model.Configuration ConfigurationModel
        {
            get
            {
                Model.Configuration model = BLL.Configuration.Model;

                model.YLMoney = int.Parse(Request.Form["txtYLMoney"]);
                //model.DefaultRole = Request.Form["ddlDefaultRole"];
                //model.MaxDPCount = int.Parse(Request.Form["txtMaxDPCount"]);
                model.OutFloat = decimal.Parse(Request.Form["txtOutFloat"]);
                model.InFloat = decimal.Parse(Request.Form["txtInFloat"]);
                model.DHBaseMoney = int.Parse(Request.Form["txtDHBaseMoney"]);
                model.DHMinMoney = int.Parse(Request.Form["txtDHMinMoney"]);
                model.TXBaseMoney = int.Parse(Request.Form["txtTXBaseMoney"]);
                model.TXMinMoney = int.Parse(Request.Form["txtTXMinMoney"]);
                model.ZZBaseMoney = int.Parse(Request.Form["txtZZBaseMoney"]);
                model.ZZMinMoney = int.Parse(Request.Form["txtZZMinMoney"]);

                model.GPrice = decimal.Parse(Request.Form["txtGPrice"]);
                model.DFHFloat = decimal.Parse(Request.Form["txtDFHFloat"]);
                model.DFHTopMoney = decimal.Parse(Request.Form["txtDFHTopMoney"]);
                model.DMHBPart = decimal.Parse(Request.Form["txtDMHBPart"]);
                model.DMGPPart = decimal.Parse(Request.Form["txtDMGPPart"]);
                model.JMHBPart = decimal.Parse(Request.Form["txtJMHBPart"]);
                model.JMGPPart = decimal.Parse(Request.Form["txtJMGPPart"]);
                model.MinBuyGCount = int.Parse(Request.Form["txtMinBuyGCount"]);
                model.GLMoney = decimal.Parse(Request.Form["txtGLMoney"]);
                model.AutoDFH = Request.Form["ddlAutoDFH"] == "1";
                model.MaxBuyGCount = int.Parse(Request.Form["txtMaxBuyGCount"]);
                model.DFHXFCount = int.Parse(Request.Form["txtDFHXFCount"]);
                model.DFHOutCount = int.Parse(Request.Form["txtDFHOutCount"]);
                model.CanRegedit = Request.Form["txtCanRegedit"] == "1";
                model.DayRegeditNumber = int.Parse(Request.Form["txtDayRegeditNumber"]);
                model.ShowTotalNumber = int.Parse(Request.Form["txtShowTotalNumber"]);
                model.ShowOfferTotalMoney = decimal.Parse(Request.Form["txtShowOfferTotalMoney"]);
                model.ShowGetTotalMoney = decimal.Parse(Request.Form["txtShowGetTotalMoney"]);

                model.SHMoneyList = GetSHMoneyList();
                model.ConfigDictionaryList = GetConfigDictionaryList();
                model.NConfigDictionaryList = GetNConfigDictionaryList();
                model = BLL.Configuration.Model;
                return model;
            }
            set
            {
                if (value != null)
                {
                    txtYLMoney.Value = value.YLMoney.ToString();
                    //txtMaxDPCount.Value = value.MaxDPCount.ToString();
                    txtInFloat.Value = value.InFloat.ToString();
                    txtOutFloat.Value = value.OutFloat.ToString();
                    txtDHBaseMoney.Value = value.DHBaseMoney.ToString();
                    txtDHMinMoney.Value = value.DHMinMoney.ToString();
                    txtTXBaseMoney.Value = value.TXBaseMoney.ToString();
                    txtTXMinMoney.Value = value.TXMinMoney.ToString();
                    txtZZBaseMoney.Value = value.ZZBaseMoney.ToString();
                    txtZZMinMoney.Value = value.ZZMinMoney.ToString();
                    txtGPrice.Value = value.GPrice.ToString();
                    txtDFHFloat.Value = value.DFHFloat.ToString();
                    txtDFHTopMoney.Value = value.DFHTopMoney.ToString();
                    txtDMHBPart.Value = value.DMHBPart.ToString();
                    txtDMGPPart.Value = value.DMGPPart.ToString();
                    txtJMHBPart.Value = value.JMHBPart.ToString();
                    txtJMGPPart.Value = value.JMGPPart.ToString();
                    txtMinBuyGCount.Value = value.MinBuyGCount.ToString();
                    txtGLMoney.Value = value.GLMoney.ToString();
                    ddlAutoDFH.Value = value.AutoDFH ? "1" : "0";
                    txtMaxBuyGCount.Value = value.MaxBuyGCount.ToString();
                    txtDFHXFCount.Value = value.DFHXFCount.ToString();
                    txtDFHOutCount.Value = value.DFHOutCount.ToString();
                    txtCanRegedit.Value = value.CanRegedit ? "1" : "0";
                    txtDayRegeditNumber.Value = value.DayRegeditNumber.ToString();
                    txtShowTotalNumber.Value = value.ShowTotalNumber.ToString();
                    txtShowOfferTotalMoney.Value = value.ShowOfferTotalMoney.ToString();
                    txtShowGetTotalMoney.Value = value.ShowGetTotalMoney.ToString();

                    GridView1.DataSource = value.SHMoneyTable;
                    GridView1.DataBind();
                    GridView2.DataSource = value.ConfigDictionaryTable;
                    GridView2.DataBind();
                    GridView4.DataSource = value.NConfigDictionaryTable;
                    GridView4.DataBind();
                    //List<Model.Roles> list = BLL.Roles.RolsList.Values.ToList().Where(emp => emp.VState).ToList();
                    //for (int i = 0; i < list.Count; i++)
                    //{
                    //    ddlDefaultRole.Items.Add(new ListItem(list[i].RName, list[i].RType));
                    //    if (BLL.Configuration.Model.DefaultRole == list[i].RType)
                    //        ddlDefaultRole.SelectedIndex = i;
                    //}
                }
            }
        }

        private Dictionary<string, Model.SHMoney> GetSHMoneyList()
        {
            Dictionary<string, Model.SHMoney> SHMoneyList = new Dictionary<string, Model.SHMoney>();

            StringBuilder sb = new StringBuilder();
            int jishuqi = 0;
            foreach (string key in Request.Form.Keys)
            {
                if (key.Contains("GridView1"))
                {
                    jishuqi++;
                    sb.Append(Request.Form[key]);
                    if (jishuqi %5 != 0)
                        sb.Append("|");
                    else
                        sb.Append("≌");
                }
            }
            string[] rows = sb.ToString().Split('≌');

            foreach (string row in rows)
            {
                if (string.IsNullOrEmpty(row))
                    continue;
                string[] cols = row.Split('|');
                SHMoneyList.Add(cols[0],
                new Model.SHMoney()
                {
                    MAgencyType = cols[0],
                    _MAgencyName = cols[1],
                    //TJCount = string.IsNullOrEmpty(cols[2]) ? 0 : int.Parse(cols[2]),
                    ////TJAgency = cols[3],
                    //TemaCount = string.IsNullOrEmpty(cols[3]) ? 0 : int.Parse(cols[3]),
                    TJFloat = decimal.Parse(cols[2]),
                    //TakeOffFloat = decimal.Parse(cols[5]),
                    //XFMouthMinHelpMoney = decimal.Parse(cols[4]),
                    //XFMounthMoney = decimal.Parse(cols[5]),
                    DTopMoney = decimal.Parse(cols[3]),
                    MColor = cols[4],
                    ViewLevel = 99999
                });
            }
            return SHMoneyList;
        }

        private Dictionary<string, List<Model.ConfigDictionary>> GetConfigDictionaryList()
        {
            List<Model.ConfigDictionary> ConfigDictionaryList = new List<Model.ConfigDictionary>();
            StringBuilder sb = new StringBuilder();
            int jishuqi = 0;
            foreach (string key in Request.Form.Keys)
            {
                if (key.Contains("GridView2"))
                {
                    jishuqi++;
                    sb.Append(Request.Form[key]);
                    if (jishuqi % 6 != 0)
                        sb.Append("|");
                    else
                        sb.Append("≌");
                }
            }
            string[] rows = sb.ToString().Split('≌');

            foreach (string row in rows)
            {
                if (string.IsNullOrEmpty(row))
                    continue;
                string[] cols = row.Split('|');
                ConfigDictionaryList.Add(
                new Model.ConfigDictionary()
                {
                    DType = cols[0],
                    Remark = cols[1],
                    StartLevel = int.Parse(cols[2]),
                    EndLevel = int.Parse(cols[3]),
                    DValue = cols[4],
                    DKey = cols[5]
                });
            }
            Dictionary<string, List<Model.ConfigDictionary>> list = new Dictionary<string, List<Model.ConfigDictionary>>();
            foreach (Model.ConfigDictionary item in ConfigDictionaryList)
            {
                if (list.Keys.Contains(item.DType))
                    list[item.DType].Add(item);
                else
                    list.Add(item.DType, new List<Model.ConfigDictionary>() { item });
            }

            //对LDLevelInfo表进行修改

            return list;
        }

        private Dictionary<string, List<Model.NConfigDictionary>> GetNConfigDictionaryList()
        {
            List<Model.NConfigDictionary> ConfigDictionaryList = new List<Model.NConfigDictionary>();
            StringBuilder sb = new StringBuilder();
            int jishuqi = 0;
            foreach (string key in Request.Form.Keys)
            {
                if (key.Contains("GridView4"))
                {
                    jishuqi++;
                    sb.Append(Request.Form[key]);
                    if (jishuqi % 8 != 0)
                        sb.Append("|");
                    else
                        sb.Append("≌");
                }
            }
            string[] rows = sb.ToString().Split('≌');

            foreach (string row in rows)
            {
                if (string.IsNullOrEmpty(row))
                    continue;
                string[] cols = row.Split('|');
                ConfigDictionaryList.Add(
                new Model.NConfigDictionary()
                {
                    NDTpye = cols[0],
                    StartLevel = int.Parse(cols[1]),
                    EndLevel = int.Parse(cols[2]),
                    Remark = cols[3],
                    StartRec = int.Parse(cols[4]),
                    EndRec = int.Parse(cols[5]),
                    DValue = cols[6],
                    DKey = cols[7],
                });
            }
            Dictionary<string, List<Model.NConfigDictionary>> list = new Dictionary<string, List<Model.NConfigDictionary>>();
            foreach (Model.NConfigDictionary item in ConfigDictionaryList)
            {
                if (list.Keys.Contains(item.NDTpye))
                    list[item.NDTpye].Add(item);
                else
                    list.Add(item.NDTpye, new List<Model.NConfigDictionary>() { item });
            }
            return list;
        }

        protected void UpdateLDLevelInfo()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected override string btnModify_Click()
        {
            //对LDLevelInfo表进行操作
            if (BllModel.UpdateConfiguration(ConfigurationModel))
            {
                Hashtable hs = new Hashtable();
                //var list = BLL.Configuration.Model.ConfigDictionaryList["LDMoney"];
                //foreach (Model.ConfigDictionary dict in list)
                //{
                //    int starLevel = dict.StartLevel;
                //    int endLevel = dict.EndLevel;
                //    for (int i = starLevel; i <= endLevel; i++)
                //    {
                //        BLL.LDLevelInfo.UpdateLDLevelInfo(dict.DValue, i.ToString(), hs);
                //    }
                //}
                BLL.CommonBase.RunHashtable(hs);
                return "操作成功";
            }
            else
                return "操作失败";
        }

        protected override string btnOther_Click()
        {
            if (BllModel.ReSetSys())
            {
                return "操作成功";
            }
            else
                return "操作失败";
        }

        protected override string btnAdd_Click()
        {
            if (Request.QueryString["type"] == "1")
            {
                if (BllModel.MemberHBClear())
                    return "操作成功";
                return "操作失败";
            }
            else if (Request.QueryString["type"] == "2")
            {
                if (BllModel.MemberHBToJB())
                    return "操作成功";
                return "操作失败";
            }
            else
                return "参数异常";
        }
        /// <summary>
        /// 【现金币】 转 【循环币】 是否开启
        /// </summary>
        /// <returns></returns>
        protected string btnTranMoney_Click()
        {
            if (Request.QueryString["type"] == "1")
            {
                //这里需要换上自己的方法
                if (BLL.Configuration.IsTranMoney(true))
                    return "操作成功";
                return "操作失败";
            }
            else if (Request.QueryString["type"] == "2")
            {
                if (BLL.Configuration.IsTranMoney(false))
                    return "操作成功";
                return "操作失败";
            }
            else
                return "参数异常";
        }
        /// <summary>
        /// 在 GridView 控件中的某个行被绑定到一个数据记录时发生。此事件通常用于在某个行被绑定到数据时修改该行的内容。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
        }
    }
}