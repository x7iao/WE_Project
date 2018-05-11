<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EnterVerifypsd.aspx.cs"
    Inherits="WE_Project.Web.SecurityCenter.EnterVerifypsd" %>

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
                    <td width="15%" align="right">
                        请输入二级密码:
                    </td>
                    <td width="35%">
                        <input id="txtVerifypsd" class="normal_input" type="text" />
                    </td>
                </tr>
                <tr style="height: 50px;">
                    <td align="right">
                        
                    </td>
                    <td align="left">
                      <input class="normal_btnok" id="Button1" type="button" value="确定" onclick="checkChange();" /> &emsp; <input class="btn btn-inverse" id="btnOK" type="button" value="取消" onclick="checkChange();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            if ($('#txtVerifypsd').val().Trim() == '') {
                v5.error('二级密码不能为空', '1', 'true');
            } else {
                if (GetAjaxString('Verify', $('#txtVerifypsd').val().Trim()) == "pass") {
                    //v5.alert('验证通过', 1, 'true');
                    //ActionModel("/SysManage/Configuration.aspx?Action=modify", $('#form1').serialize());
                }
                else {
                    v5.alert('验证未通过', 1, 'true');
                }
            }
        }
    </script>
</body>
</html>
