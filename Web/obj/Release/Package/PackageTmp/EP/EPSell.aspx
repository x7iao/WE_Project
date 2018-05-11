<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EPSell.aspx.cs" Inherits="WE_Project.Web.EP.EPSell" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EP挂卖</title>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td width="30%" align="right">
                        信用等级:
                    </td>
                    <td>
                        <%=TModel.MConfig.EPXingJiStr%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        开户银行:
                    </td>
                    <td>
                        <%=BankInfo!=null? BankInfo.Name:""%>
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
                        开户姓名:
                    </td>
                    <td>
                        <%=TModel.BankCardName %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        开户帐号:
                    </td>
                    <td>
                        <%=TModel.BankNumber %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        当前持有现金币:
                    </td>
                    <td>
                        <%=TModel.MConfig.MHB - TModel.MConfig.MHBFreeze < 0 ? TModel.MConfig.MHB : TModel.MConfig.MJJ%>
                    </td>
                </tr>
                <tr style="display: none">
                    <td align="right">
                        交易量:
                    </td>
                    <%if (EPCONFIG.EPJYType == 0)
                      {
                    %>
                    <td>
                        不限金额交易
                    </td>
                    <%
                        }
                      else if (EPCONFIG.EPJYType == 1)
                      {
                    %>
                    <td>
                        最低限额为<%=EPCONFIG.EPJYMinMoney%>,且必须是<%=EPCONFIG.EPJYMinMoney * EPCONFIG.EPJYBaseMoney%>的倍数
                    </td>
                    <%
                        }
                      else if (EPCONFIG.EPJYType == 2)
                      {
                    %>
                    <td>
                        必须为以下金额:<%=EPCONFIG.EPMoneyStr%>
                    </td>
                    <%
                        }
                    %>
                </tr>
                <tr>
                    <td align="right">
                        用户协议:
                    </td>
                    <td>
                        <%=EPCONFIG.EPProtocol%>
                        <input type="checkbox" checked="checked" disabled="disabled" />
                        所有协议视为已同意本协议。
                    </td>
                </tr>
                <tr style="display: none">
                    <td align="right">
                        交易类型:
                    </td>
                    <td>
                        <select id="MoneyType">
                            <option value="MHB">EP</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        现金币:
                    </td>
                    <td>
                        <%=rdMoney%>
                        <input type="text" id="textNumber" name="textNumber" onkeyup="changeMJB()" style="display: none" />&emsp;
                    </td>
                </tr>
                <tr style="display: none">
                    <td align="right">
                        到账金额:
                    </td>
                    <td>
                        <input type="text" id="textCNY" readonly="readonly" />
                    </td>
                </tr>
                <tr style="display: none">
                    <td align="right">
                        <span>验证身份证号：</span>
                    </td>
                    <td>
                        <input name="txtNumID" id="txtNumID" class="normal_input" type="text" />
                    </td>
                </tr>
                <tr style="height: 50px;">
                    <td align="right">
                        <input name="重置" type="reset" class="normal_btnok" value="重置" style="display: none;" />
                    </td>
                    <td align="left">
                        <input class="normal_btnok" id="btnOK" type="button" runat="server" value="确认卖出"
                            onclick="checkChange();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            var chk = $("input[name='rdMoney']:checked").val();
            if(typeof(chk)=="undefined")
 {
                v5.error('请选择交易金额', '1', 'true');
  } else {
//                verifypsd(function () {
                    $.ajax({
                        type: 'post',
                        url: '/EP/EPSell.aspx?Action=add',
                        data: $('#form1').serialize(),
                        success: function (info) {
                            if (info == "1") {
                                v5.alert('挂卖成功', '2', 'true');
                                setTimeout(function () {
                                    v5.clearall();
                                    callhtml('../EP/EPSell.aspx', '我要卖出');
                                }, 1000);
                            }
                            else {
                                v5.alert(info, '2', 'true');
                            }
                        }
                    });
//                });
           }
        }
        function changeMJB() {
            var infloat = '<%=WE_Project.BLL.Configuration.Model.OutFloat %>';
            var money = parseInt($("#textNumber").val());
            //            $("#spMJB").html(money * infloat);
//            $("#textCNY").html(money * 6.3);
        }
    </script>
</body>
</html>
