<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyMember.aspx.cs" Inherits="WE_Project.Web.Member.ModifyMember"
    EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <%--<script src="../SourceFiles/AcmeBlue/js/linkage.js" type="text/javascript"></script>--%>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td width="15%" align="right">
                        会员账号:
                    </td>
                    <td width="35%">
                        <input id="txtMID" runat="server" class="normal_input" type="text" readonly="readonly"
                            maxlength="20" />
                    </td>
                    <td width="15%" align="right">
                        会员昵称:
                    </td>
                    <td width="35%">
                        <input id="txtMName" runat="server" class="normal_input" type="text" maxlength="20" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        角色:
                    </td>
                    <td>
                        <select id="ddlMemberType" runat="server">
                        </select>
                    </td>
                    <td align="right">
                        会员级别:
                    </td>
                    <td>
                        <select id="ddlSHMoney" runat="server">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        手机号码:
                    </td>
                    <td>
                        <input id="txtTel" runat="server" class="normal_input" type="text" maxlength="15" />
                    </td>
                   <td align="right">
                        推荐人账号:
                    </td>
                    <td>
                        <input id="txtMTJ" runat="server" class="normal_input" type="text" maxlength="20"
                            readonly="readonly" />
                    </td>
                </tr>
                <tr style="display:none;">
                    
                    
                    <td align="right">
                        优先匹配:
                    </td>
                    <td>
                        <select id="txtPPLeavel" runat="server">
                            <option value="0">不优先</option>
                            <option value="1">优先</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        开户银行:
                    </td>
                    <td>
                        <input id="txtBank" runat="server" class="normal_input" type="text" />
                    </td>
                    <td align="right">
                        卡号:
                    </td>
                    <td>
                        <input id="txtBankNumber" runat="server" class="normal_input" type="text" maxlength="25" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        开户名:
                    </td>
                    <td>
                        <input id="txtBankCardName" runat="server" class="normal_input" type="text" maxlength="25" />
                    </td>
                    <td align="right">
                        开户支行:
                    </td>
                    <td>
                        <input id="txtBranch" runat="server" class="normal_input" type="text" maxlength="25" />
                    </td>
                </tr>
            
               
                <tr>
                    
                    <td align="right">
                        冻结状态:
                    </td>
                    <td>
                        <input id="chkIsClock" runat="server" type="checkbox" />冻结账号|<input id="chkClockAll"
                            runat="server" type="checkbox" style="display:none;" /><%--伞下同步--%>
                    </td>
                    <td align="right" style="display:none;">
                        累计投资:
                    </td>
                    <td style="display:none;">
                        <input id="txtSHMoney" runat="server" class="normal_input" type="text" maxlength="8"
                            readonly="readonly" />
                    </td>
                    <td align="right">
                        忠诚度:
                    </td>
                    <td>
                        <input id="txtEPXingCount" runat="server" class="normal_input" type="text" maxlength="50" />
                    </td>
                </tr>
                <tr>
                     <td align="right">
                        支付宝:
                    </td>
                    <td>
                        <input id="txtAliPay" runat="server" class="normal_input" type="text" maxlength="50" />
                    </td>
                     <td align="right">
                        微信:
                    </td>
                    <td>
                        <input id="txtWeChat" runat="server" class="normal_input" type="text" maxlength="50" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        锁定状态:
                    </td>
                    <td>
                        <input id="chkIsClose" runat="server" type="checkbox" />禁止登录|<input id="chkCloseAll"
                            runat="server" type="checkbox" style="display:none;"  /><%--伞下同步--%>
                    </td>
                    <td align="right">
                        锁定说明：
                    </td>
                    <td>
                        <input id="txtProvince" runat="server" class="normal_input" type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        登录密码:
                    </td>
                    <td>
                        <input id="txtPassword" runat="server" class="normal_input" type="text" maxlength="32" />
                    </td>
                    <td align="right">
                        交易密码:
                    </td>
                    <td>
                        <input id="txtSecPsd" runat="server" class="normal_input" type="text" maxlength="32" />
                    </td>
                </tr>
                <tr style="display:none;">
                    <td align="right">
                        密保问题:
                    </td>
                    <td>
                        <select id="ddl_PwdQuestion" width="175px" runat="server">
                        </select>
                    </td>
                    <td align="right">
                        密保问题答案:
                    </td>
                    <td>
                        <input id="pwdAnswer" runat="server" value="" class="normal_input" />
                    </td>
                </tr>
                <tr style="height: 50px;">
                    <td colspan="2" style="text-align: right;">
                        <input class="normal_btnok" id="Button1" type="button" runat="server" value="删除所有订单"
                            onclick="checkChange2();" />
                    </td>
                    <td colspan="2" align="left">
                        <input class="normal_btnok" id="btnOK" type="button" runat="server" value="提交" onclick="checkChange();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            if ($('#txtMName').val().Trim() == '') {
                v5.error('会员昵称不能为空', '1', 'true');
            } else if (RunAjaxGetKey('getMName', $('#txtMTJ').val()) == '') {
                v5.error('推荐人不存在', '1', 'true');
                //            } else if (RunAjaxGetKey('getMName', $('#txtMSH').val()) == '') {
                //                v5.error('报单中心不存在', '1', 'true');
            } else {
                ActionModel("/Member/ModifyMember.aspx?Action=Modify", $('#form1').serialize());
            }
        }
        function checkChange2() {
            ActionModel("/Member/ModifyMember.aspx?Action=other", $('#form1').serialize());
        }
    </script>
</body>
</html>
