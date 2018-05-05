<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddRoles.aspx.cs" Inherits="WE_Project.Web.SysManage.AddRoles" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td width="20%" align="right">
                        角色编码:
                    </td>
                    <td width="30%">
                        <input id="txtRType" runat="server" class="normal_input" type="text" />
                    </td>
                    <td width="20%" align="right">
                        角色名称:
                    </td>
                    <td width="30%">
                        <input id="txtRName" runat="server" class="normal_input" type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        管理员权限:
                    </td>
                    <td>
                        <select id="ddlIsAdmin" runat="server">
                            <option value="false">否</option>
                            <option value="true">是</option>
                        </select>
                    </td>
                    <td align="right">
                        超级管理员:
                    </td>
                    <td>
                        <select id="ddlSuper" disabled="disabled" runat="server">
                            <option value="false">否</option>
                            <option value="true">是</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        激活权限:
                    </td>
                    <td>
                        <select id="ddlCanSH" runat="server">
                            <option value="false">否</option>
                            <option value="true">是</option>
                        </select>
                    </td>
                    <td align="right">
                        登录权限:
                    </td>
                    <td>
                        <select id="ddlCanLogin" runat="server">
                            <option value="false">否</option>
                            <option value="true">是</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        留言处理:
                    </td>
                    <td>
                        <select id="ddlCMessage" runat="server">
                            <option value="false">否</option>
                            <option value="true">是</option>
                        </select>
                    </td>
                    <td align="right">
                        颜色:
                    </td>
                    <td>
                        <input id="txtRColor" runat="server" class="normal_input" type="text" />例:#442898
                    </td>
                </tr>
                <tr style="height: 50px;">
                    <td colspan="2" align="right">
                        <input name="重置" type="reset" class="normal_btnok" value="重置" style="display:none;" />
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
            if ($('#txtRType').val().Trim() == "") {
                v5.error('角色编码不能为空', '1', 'true');
            } else if ($('#txtRName').val().Trim() == '') {
                v5.error('角色名称不能为空', '1', 'true');
            } else if ($('#txtRColor').val().Trim() == '') {
                v5.error('颜色不能为空', '1', 'true');
            } else {
                ActionModel("/SysManage/AddRoles.aspx?Action=add", $('#form1').serialize());
            }
        }
    </script>
</body>
</html>
