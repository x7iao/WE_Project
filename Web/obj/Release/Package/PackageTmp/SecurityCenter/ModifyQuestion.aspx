<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModifyQuestion.aspx.cs" Inherits="WE_Project.Web.SecurityCenter.ModifyQuestion" %>

<html>
<head>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td align="right">
                        新密保问题:
                    </td>
                    <td>
                      <select id="ddl_NewQuestion" width="175px" runat="server">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        密保问题答案:
                    </td>
                    <td>
                        <input id="lbConfirm" class="normal_input" runat="server" type="text" /><font
                            color="red">*</font>
                    </td>
                </tr>
                  <tr>
                    <td  align="right" >
                    </td>
                       <td >
                    验证密保问题 
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        密保问题:
                    </td>
                    <td>
                         <select id="ddl_PwdQuestion" width="175px" runat="server">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        密保问题答案:
                    </td>
                    <td>
                        <input id="pwdAnswer" class="normal_input" runat="server" type="text" /><font
                            color="red">*</font>
                    </td>
                </tr>
                 
                <tr style="height: 50px;">
                    <td align="right">
                        <input name="重置" type="reset" class="normal_btnok" value="重置" style="display: none;" />
                    </td>
                    <td align="left">
                        <input class="normal_btnok" id="btnOK" type="button" value="提交" onclick="checkChange();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            if ($('#lbConfirm').val()== '') {
                v5.error('新密保问题答案不能为空', '1', 'true');
            }
            else if ($('#pwdAnswer').val() == '') {
                v5.error('验证密保问题答案不能为空', '1', 'true');
            }
            else {
                ActionModel("/SecurityCenter/ModifyQuestion.aspx?Action=modify", $('#form1').serialize());
            }
        }
    
    </script>
</body>
</html>
