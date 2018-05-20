<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JTAccont.aspx.cs" Inherits="WE_Project.Web.Mafull.JTAccont" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
                <table cellpadding="0" cellspacing="0">
                    <tr style="height: 50px;">
                        <td align="right"></td>
                        <td align="left">
                            <input class="normal_btnok" id="btnOK" type="button" runat="server" value="发放利息" onclick="checkChange();" />
                        </td>
                    </tr>
                    <tr style="height: 50px;">
                        <td align="right"></td>
                        <td align="left">
                            <input class="normal_btnok" id="Button1" type="button" runat="server" value="超时转换利息到许愿池/衰减忠诚/激活排单冻结" onclick="checkChange1();" />
                        </td>
                    </tr>
                    <tr style="height: 50px;">
                        <td align="right"></td>
                        <td align="left"></td>
                    </tr>
                    <tr style="height: 50px;">
                        <td align="right">手动分红：
                        </td>
                        <td align="left">
                            <select id="FHType" name="FHType" runat="server">
                                <option value="5">排单5</option>
                                <option value="10">排单10</option>
                                <option value="30">排单30</option>
                            </select>
                        </td>
                    </tr>
                     <tr style="height: 50px;">
                        <td align="right">未分红单数：
                        </td>
                        <td align="left">
                            排单5：<%=count5 %><br />
                            排单10：<%=count10 %><br />
                            排单30：<%=count30 %><br />
                            实际分红单数按数据库实时查询为准
                        </td>
                    </tr>
                     <tr style="height: 50px;">
                        <td align="right">分红颗数：
                        </td>
                        <td align="left">
                           <input type="text" runat="server" id="fhmoney"  class="input-sm form-control mask-date" />
                        </td>
                    </tr>
                    <tr style="height: 50px;">
                        <td align="right"></td>
                        <td align="left">
                            <input class="normal_btnok" id="Button3" type="button" runat="server" value="分红" onclick="checkChange2();" />
                        </td>
                    </tr>
                </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function getTotalFHMoney(obj) {
            $("#txtTotalFHMoney").val(parseInt($(obj).val()) * parseInt($("#hdTotalMoney").val()));
        }
        function checkChange() {
            ActionModel("/Mafull/JTAccont.aspx?Action=add", $('#form1').serialize());
        }
        function checkChange1() {
            ActionModel("/Mafull/JTAccont.aspx?Action=modify", $('#form1').serialize());
        }
        function checkChange2() {
            ActionModel("/Mafull/JTAccont.aspx?Action=Other", $('#form1').serialize());
        }
    </script>
</body>
</html>
