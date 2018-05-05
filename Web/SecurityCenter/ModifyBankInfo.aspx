<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyBankInfo.aspx.cs"
    Inherits="WE_Project.Web.SecurityCenter.ModifyBankInfo" %>

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
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td width="15%" align="right">
                        <span>会员账号：</span>
                    </td>
                    <td width="35%">
                        <input id="txtMID" runat="server" class="pay_input" type="text" />
                    </td>
                </tr>
                <tr style="display: none;">
                    <td width="15%" align="right">
                        <span>是否提现：</span>
                    </td>
                    <td width="35%">
                        <input id="chkIsPrimary" runat="server" type="checkbox" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>开户银行：</span>
                    </td>
                    <td>
                        <select id="txtBank" runat="server">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>开户支行：</span>
                    </td>
                    <td>
                        <input id="txtBranch" maxlength="25" runat="server" require-type="require" class="pay_input"
                            type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>开户姓名：</span>
                    </td>
                    <td>
                        <input id="txtBankCardName" maxlength="10" runat="server" require-type="require"
                            class="pay_input" type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>卡号：</span>
                    </td>
                    <td>
                        <input id="txtBankNumber" maxlength="30" runat="server" require-type="require" class="pay_input"
                            type="text" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <input class="normal_btnok" id="btnOK" type="button" runat="server" value="提交" onclick="checkChange();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            if ($('#txtBank').val().Trim() == "") {
                v5.error('开户银行不能为空', '1', 'true');
            } else if (RunAjaxGetKey('getMName', $('#txtMID').val()) == '') {
                v5.error('银行卡会员账号不存在', '1', 'true');
            } else if ($('#txtBankNumber').val().Trim() == '') {
                v5.error('卡号不能为空', '1', 'true');
            } else if ($('#txtBankCardName').val().Trim() == '') {
                v5.error('开户姓名不能为空', '1', 'true');
            } else {
                if (checkForm())
                    ActionModelBackWithTitle("/SecurityCenter/ModifyBankInfo.aspx?Action=Modify", $('#form1').serialize(), "SecurityCenter/BankList.aspx", null, '银行卡管理');
            }
        }
    </script>
</body>
</html>
