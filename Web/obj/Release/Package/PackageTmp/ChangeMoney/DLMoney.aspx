<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DLMoney.aspx.cs" Inherits="WE_Project.Web.ChangeMoney.DLMoney" %>

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
                      <td  align="center" colspan="2">
                        <span>每日领取奖金</span>
                    </td>
                </tr>
                <tr>
                      <td width="15%" align="right" >
                        &nbsp;日分红:
                    </td>
                   <td width="35%">
                        &nbsp;<%=DayFHMoney%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        &nbsp;上次领奖日期:
                    </td>
                    <td>
                        &nbsp;<%=UpDFHMoney%>
                    </td>
                </tr>
                <tr style="height: 50px;">
                    <td align="center" colspan="2">
                        <input class="normal_btnok" id="btnOK" type="button" value="领取日分红" onclick="checkChange();" />
                    </td>
                </tr>
                
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            ActionModel("/ChangeMoney/DLMoney.aspx?Action=add", $('#form1').serialize());
        }
      
    </script>
</body>
</html>
