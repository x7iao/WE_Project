<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewMember.aspx.cs" Inherits="WE_Project.Web.Member.ViewMember" %>

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
                        <%=model.MID%>
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        会员昵称:
                    </td>
                    <td width="35%">
                        <%=model.MName%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        会员级别:
                    </td>
                    <td>
                        <%=model.MAgencyType.MAgencyName%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        手机号码:
                    </td>
                    <td>
                        <%=model.Tel%>
                    </td>
                </tr>
                <%--<tr>
                    <td align="right">
                        推荐人账号:
                    </td>
                    <td>
                        <%=tjmodel.MID%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        推荐人姓名:
                    </td>
                    <td>
                        <%=tjmodel.MName%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        推荐人手机:
                    </td>
                    <td>
                        <%=tjmodel.Tel%>
                    </td>
                </tr>--%>
                <%--<tr>
                    <td align="right">
                        QQ号码:
                    </td>
                    <td>
                        <%=model.QQ%>
                    </td>
                </tr>--%>
                <tr>
                    <td align="right">
                        微信账号:
                    </td>
                    <td>
                        <%=model.WeChat %>
                    </td>
                </tr>
                <%--<tr>
                    <td align="right">
                        支付宝账号姓名:
                    </td>
                    <td>
                        <%=TModel.City %>
                    </td>
                </tr>--%>
                <tr>
                    <td align="right">
                        支付宝账号:
                    </td>
                    <td>
                        <%=model.AliPay%>
                    </td>
                </tr>
                <%--<tr>
                    <td align="right">
                        身份证号:
                    </td>
                    <td>
                        <%=TModel.NumID %>
                    </td>
                </tr>--%>
                <tr>
                    <td align="right">
                        开户银行:
                    </td>
                    <td>
                        <%=model.Bank%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        卡号:
                    </td>
                    <td>
                        <%=model.BankNumber%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        开户名:
                    </td>
                    <td>
                        <%=model.BankCardName%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        开户支行:
                    </td>
                    <td>
                        <%=model.Branch%>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</body>
</html>
