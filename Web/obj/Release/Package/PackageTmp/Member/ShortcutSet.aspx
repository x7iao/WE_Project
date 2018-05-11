<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShortcutSet.aspx.cs" Inherits="WE_Project.Web.Member.ShortcutSet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="/SourceFiles/AcmeBlue/js/linkage.js" type="text/javascript"></script>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td width="15%" align="right">
                        角色:
                    </td>
                    <td width="35%">
                        <select id="ddlMemberType" runat="server">
                            <option value=""></option>
                        </select>
                        <input type="hidden" runat="server" id="hdMIDList" />
                    </td>
                    <td width="15%" align="right">
                        申请级:
                    </td>
                    <td width="35%">
                        <select id="ddlSHMoney" runat="server">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        手机号码:
                    </td>
                    <td>
                        <input id="txtTel" runat="server" class="normal_input" type="text" maxlength="11" />
                    </td>
                    <td align="right">
                        电子邮箱:
                    </td>
                    <td>
                        <input id="txtEmail" runat="server" class="normal_input" type="text" maxlength="50" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        推 荐 人:
                    </td>
                    <td>
                        <input id="txtMTJ" runat="server" class="normal_input" type="text" maxlength="20" />
                    </td>
                    <td align="right">
                        报单中心:
                    </td>
                    <td>
                        <input id="txtMSH" runat="server" class="normal_input" type="text" maxlength="15" />默认公司
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        省市县区:
                    </td>
                    <td>
                        <select id="ddlProvince" runat="server">
                        </select>
                        <select id="ddlCity" runat="server">
                        </select>
                        <select id="ddlZone" runat="server">
                        </select>
                    </td>
                    <td align="right">
                        QQ号码:
                    </td>
                    <td>
                        <input id="txtAddress" runat="server" class="normal_input" type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        锁定状态:
                    </td>
                    <td>
                        <select id="ddlIsClose" runat="server">
                            <option value=""></option>
                            <option value="true">锁定</option>
                            <option value="false">解锁</option>
                        </select>
                    </td>
                    <td align="right">
                        冻结状态:
                    </td>
                    <td>
                        <select id="ddlIsClock" runat="server">
                            <option value=""></option>
                            <option value="true">冻结</option>
                            <option value="false">解冻</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        奖金类型:
                    </td>
                    <td colspan="3">
                        <input id="txtJJTypeList" runat="server" style="width: 500px;" class="normal_input"
                            type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        登录密码:
                    </td>
                    <td>
                        <input id="txtPassword" runat="server" value="" class="normal_input" type="text"
                            maxlength="32" />
                    </td>
                    <td align="right">
                        二级密码:
                    </td>
                    <td>
                        <input id="txtSecPsd" runat="server" value="" class="normal_input" type="text" maxlength="32" />
                    </td>
                </tr>
                <tr style="height: 50px;">
                    <td colspan="2" align="right">
                        <input name="重置" type="reset" class="normal_btnok" value="重置" style="display: none;" />
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
        setup();
        function checkChange() {
            if ($('#txtMTJ').val().Trim() != '' && RunAjaxGetKey('getMName', $('#txtMTJ').val()) == '') {
                v5.error('不存在推荐会员', '1', 'true');
            } else if ($('#txtMSH').val().Trim() != '' && RunAjaxGetKey('getMName', $('#txtMSH').val()) == '') {
                v5.error('不存在报单会员', '1', 'true');
            } else {
                ActionModel("/Member/ShortcutSet.aspx?Action=modify", $('#form1').serialize());
            }
        }
    </script>
</body>
</html>
