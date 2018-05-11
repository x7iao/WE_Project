﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="WE_Project.Web.Member.Modify"
    EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <input id="hdBankCode" type="hidden" runat="server" />
            <div style="margin-left: 20%; color: red; font-size: 15px; display: none">
                请完善您的提现银行账号信息,激活后不能修改。
            </div>
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td width="15%" align="right">
                        会员账号:
                    </td>
                    <td width="35%">
                        <input id="txtMID" runat="server" class="normal_input" type="text" readonly="readonly" />
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        会员昵称:
                    </td>
                    <td width="35%">
                        <input id="txtMName" runat="server" class="normal_input" type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        手机号码:
                    </td>
                    <td>
                        <input id="txtTel" runat="server" class="normal_input" type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        支付宝账号:
                    </td>
                    <td>
                        <input id="txtAlipay" runat="server" class="normal_input" type="text" /><font style="color: Red"></font>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        微信账号:
                    </td>
                    <td>
                        <input id="txtWeChat" runat="server" class="normal_input" type="text" /><font style="color: Red"></font>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        开户银行:
                    </td>
                    <td>
                        <input id="txtBank" runat="server" class="normal_input" type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        开户支行:
                    </td>
                    <td>
                        <input id="txtBranch" runat="server" class="normal_input" type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        开户姓名:
                    </td>
                    <td>
                        <input id="txtBankCardName" runat="server" class="normal_input" type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        银行卡号:
                    </td>
                    <td>
                        <input id="txtBankNumber" runat="server" class="normal_input" type="text" />
                    </td>
                </tr>
                <tr style="height: 50px;">
                    <td align="right">
                        <input name="重置" type="reset" class="normal_btnok" value="重置" style="display: none;" />
                    </td>
                    <td align="left">
                        <input class="normal_btnok" id="btnOK" type="button" runat="server" value="提交" onclick="checkChange();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            if ($('#txtMName').val() == "") {
                v5.error('您的会员昵称不能为空', '1', 'true');
            } else if (!$('#txtTel').val().TryTel()) {
                v5.error('手机号码格式不正确', '1', 'true');
            } else if ( $('#txtWeChat').val() == "") {
                v5.error('微信账号不能为空', '1', 'true');
            } else if ($('#txtAlipay').val() == "") {
                v5.error('支付宝账号不能为空', '1', 'true');
            } else if ($('#txtBankNumber').val() == "") {
                v5.error('银行卡号不能为空', '1', 'true');
            } else if ($('#txtBankCardName').val() == "") {
                v5.error('开户姓名不能为空', '1', 'true');
            } else if ($('#txtBranch').val() == "") {
                v5.error('开户支行不能为空', '1', 'true');
            } else {
                verifypsd(function () {
                    $.ajax({
                        type: 'post',
                        url: '/Member/Modify.aspx?Action=modify',
                        data: $('#form1').serialize(),
                        success: function (info) {
                            if (info == "1") {
                                v5.alert('修改成功', '2', 'true');
                                setTimeout(function () {
                                    v5.clearall();
                                }, 1000);
                            }
                            else {
                                v5.alert(info, '2', 'true');
                            }
                        }
                    });
                });
            }
        }
    </script>
</body>
</html>
