<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="View.aspx.cs" Inherits="WE_Project.Web.Member.View" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td width="15%" align="right">
                        会员账号:
                    </td>
                    <td width="35%">
                        <%=TModel.MID %>
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        会员昵称:
                    </td>
                    <td width="35%">
                        <%=TModel.MName %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        会员级别:
                    </td>
                    <td>
                        <%=TModel.MAgencyType.MAgencyName %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        手机号码:
                    </td>
                    <td>
                        <%=TModel.Tel %>
                    </td>
                </tr>
              <%--  <tr>
                    <td align="right">
                        微信帐号:
                    </td>
                    <td>
                        <%=TModel.WeChat %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        支付宝账号:
                    </td>
                    <td>
                        <%=TModel.AliPay %>
                    </td>
                </tr>--%>
                <tr>
                    <td align="right">
                        开户银行:
                    </td>
                    <td>
                        <%=TModel.Bank %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        开户支行:
                    </td>
                    <td>
                        <%=TModel.Branch %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        卡号:
                    </td>
                    <td>
                        <%=TModel.BankNumber %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        开户名:
                    </td>
                    <td>
                        <%=TModel.BankCardName %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        注册日期:
                    </td>
                    <td>
                        <%=TModel.MCreateDate.ToString("yyyy-MM-dd HH:mm") %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        激活日期:
                    </td>
                    <td>
                        <%=TModel.MState?TModel.MDate.ToString("yyyy-MM-dd HH:mm"):"未激活" %>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <b>账号信息</b>
                    </td>
                </tr>
                <%if (TModel.MConfig != null)
                  { %>
                <tr>
                    <td align="right">
                        累计投资:
                    </td>
                    <td>
                        <%=TModel.MConfig.SHMoney%>
                    </td>
                </tr>
                <tr style="font-size: 16px; color: #55AA66;">
                    <td align="right">
                        <%=WE_Project.BLL.Reward.List["MHB"].RewardName%>:
                    </td>
                    <td>
                        <%=TModel.MConfig.MHB.ToString("F2") %>
                    </td>
                </tr>
                <tr style="font-size: 16px; color: #55AA66;">
                    <td align="right">
                        <%=WE_Project.BLL.Reward.List["MJB"].RewardName%>:
                    </td>
                    <td>
                        <%=TModel.MConfig.MJB.ToString("F2")%>
                    </td>
                </tr>
                <tr style="font-size: 16px; color: #55AA66;">
                    <td align="right">
                        <%=WE_Project.BLL.Reward.List["MCW"].RewardName%>:
                    </td>
                    <td>
                        <%=TModel.MConfig.MCW.ToString("F2")%>
                    </td>
                </tr>
                <tr style="font-size: 16px; color: #55AA66;">
                    <td align="right">
                        <%=WE_Project.BLL.Reward.List["MGP"].RewardName%>:
                    </td>
                    <td>
                        <%=TModel.MConfig.MGP.ToString("F2")%>
                    </td>
                </tr>
                 <tr style="font-size: 16px; color: #55AA66;">
                    <td align="right">
                        <%=WE_Project.BLL.Reward.List["MJBF"].RewardName%>:
                    </td>
                    <td>
                        <%=TModel.MConfig.MJBF.ToString("F2")%>
                    </td>
                </tr>   <tr style="font-size: 16px; color: #55AA66;">
                    <td align="right">
                        <%=WE_Project.BLL.Reward.List["TotalYFHMoney"].RewardName%>:
                    </td>
                    <td>
                        <%=TModel.MConfig.TotalYFHMoney.ToString("F2")%>
                    </td>
                </tr>
                <%} %>
            </table>
        </div>
    </div>
</body>
</html>
