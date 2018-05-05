<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MMMConfigScrambleEdit.aspx.cs"
    Inherits="WE_Project.Web.SysManage.MMMConfigScrambleEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <style type="text/css">
        
    </style>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td align="right">
                        抢单开放开关:
                    </td>
                    <td>
                        <select id="txtOpenSwitch" runat="server">
                            <option value="1">开</option>
                            <option value="0">关</option>
                        </select>
                    </td>
                    <td align="right">
                        抢单开放时间:
                    </td>
                    <td>
                        <input id="txtOpenTime" runat="server" class="normal_input" type="text" require-type="require"
                            require-msg="抢单开放时间" /><font color="red">*(00:00-23:59)</font>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        打款时间:
                    </td>
                    <td>
                        <input id="txtPayLimitTimes" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="打款时间" /><font color="red">*整数(分钟)</font>
                    </td>
                    <td align="right">
                        收款时间:
                    </td>
                    <td>
                        <input id="txtConfirmLimitTimes" runat="server" class="normal_input" type="text"
                            require-type="int" require-msg="收款时间" /><font color="red">*整数(分钟)</font>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        冻结时间:
                    </td>
                    <td>
                        <input id="txtFreezeTimes" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="冻结时间" /><font color="red">*整数(分钟)</font>
                    </td>
                    <td align="right">
                        没人抢消失时间:
                    </td>
                    <td>
                        <input id="txtDisappearTimes" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="没人抢消失时间" /><font color="red">*(整数)</font>
                    </td>
                </tr>
                <tr style="display: none">
                    <td align="right">
                        抢单获得利息天数:
                    </td>
                    <td>
                        <input id="txtScrambleLiXiDays" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="抢单获得利息天数" /><font color="red">*整数(天)</font>
                    </td>
                    <td align="right">
                        抢单交易完成奖金:
                    </td>
                    <td>
                        <input id="txtScrambleReward" runat="server" class="normal_input" type="text" require-type="decimal"
                            require-msg="抢单交易完成奖金" /><font color="red">*</font>
                    </td>
                </tr>
            </table>
            <table cellpadding="0" cellspacing="0">
                <tr style="height: 50px;">
                    <td>
                    </td>
                    <td>
                        <input class="normal_btnok" id="Button1" type="button" value="确定" onclick="checkOk();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $("#__VIEWSTATE").remove();
        })

        function checkOk() {
            ActionModel("/SysManage/MMMConfigScrambleEdit.aspx?Action=modify", $('#form1').serialize());
        }

        function checkClear() {
            ActionModel("/SysManage/MMMConfigScrambleEdit.aspx?Action=other", $('#form1').serialize());
        }
    </script>
</body>
</html>
