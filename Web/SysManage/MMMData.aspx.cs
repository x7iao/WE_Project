using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WE_Project.Web.SysManage
{
    public partial class MMMData : BasePage
    {
        protected string pdtotalcount = "0";//排单总数
        protected string txtotalcount = "0";//提现总数
        protected string pddaymoney = "0";//日排单金额
        protected string txdaymoney = "0";//日提现金额
        protected string totalmembercount = "0";//平台总人数
        protected string daymembercount = "0";//日新增人数
        protected override void SetPowerZone()
        {
            
                pdtotalcount = BLL.CommonBase.GetSingle("select count(*) from mofferhelp where ppstate<>5;").ToString();
           

         
                txtotalcount = BLL.CommonBase.GetSingle("select count(*) from mgethelp where ppstate<>5;").ToString();
          
                pddaymoney = BLL.CommonBase.GetSingle("select  isnull(sum(sqmoney),0) from mofferhelp where ppstate<>5 and datediff(dd,sqdate,getdate())=0;").ToString();
          
                txdaymoney = BLL.CommonBase.GetSingle("select  isnull(sum(sqmoney),0) from mgethelp where ppstate<>5 and datediff(dd,sqdate,getdate())=0;").ToString();
          
                totalmembercount = BLL.CommonBase.GetSingle("select count(*) from member where mid<>'admin';").ToString();
          
                daymembercount = BLL.CommonBase.GetSingle("select count(*) from member where mid<>'admin' and datediff(dd,mcreatedate,getdate())=0; ").ToString();
           
        }
    }
}