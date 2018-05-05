<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BCenterAdd.aspx.cs" Inherits="WE_Project.Web.Member.BCenterAdd" %>


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
                <tr>
                    <td align="center" colspan="2" class="sen_title">
                        <span>注册股东</span>
                    </td>
                </tr>
                <tr>
                    <td width="25%" align="right">
                        股 东 ID:
                    </td>
                    <td width="35%">
                        <input id="txtMID" runat="server" class="normal_input" type="text" maxlength="20" readonly="readonly" />
                    </td>
                  
                </tr>
                <tr>
                  <td width="15%" align="right">
                        股东姓名:
                    </td>
                    <td width="35%">
                       <input id="txtMName" runat="server" class="normal_input" type="text" maxlength="20"  readonly="readonly"/>
                    </td>
                </tr>
               <tr>
                    <td align="center" colspan="4" class="sen_title">
                        <span>一次性充值5000元可申请报单中心</span>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2" class="sen_title">
                        <span id="showmessage" runat="server"></span>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2" class="sen_title">
                       <input class="normal_btnok" id="btnOK" type="button" runat="server" value="申请成为报单中心" onclick="checkChange();" />
                    </td>
                </tr>
               
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        //setup();
        function checkChange() {
            if ($('#txtMID').val().Trim() == "") {
                v5.error('股东ID不能为空', '1', 'true');
            } else if ($('#txtMName').val() == "") {
                v5.error('股东名称不能为空', '1', 'true');
           
            } else {
                $.ajax({
                    type: 'post',
                    url: '/Member/BCenterAdd.aspx?Action=add',
                    data: $('#form1').serialize(),
                    success: function (info) {
                        v5.alert(info, '1', 'true');
                        setTimeout(function () { v5.clearall(); }, 1000);
                    }
                });
            }
        }
    </script>
</body>
</html>
