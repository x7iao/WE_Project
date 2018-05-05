<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="IndexShowMsg.aspx.cs" Inherits="WE_Project.Web.Message.IndexShowMsg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
              <input id="hidId" type="hidden" runat="server"  />
            <table cellpadding="0" cellspacing="0">
                  <tr>
                    <td align="right">
                        发布时间
                    </td>
                    <td style="padding: 15px;">
                        <input   id="txtPubTime" type="text" runat="server"  onclick="WdatePicker()"  />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        内容
                    </td>
                    <td style="padding: 15px;">
                         <textarea id="txtContent" runat="server" style="width:600px;height:120px">
                         
                         </textarea>
                    </td>
                </tr>
                <tr style="height: 40px;">
                    <td width="15%" align="right">
                     
                    </td>
                    <td width="75%" align="left">
                   
                        <input type="button" class="normal_btnok" value="发 布"  onclick="checkChange();" /> &emsp;
                           <input type="reset" class="normal_btnok" onclick="retyurnList()" value="返 回"  />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function retyurnList() {
            callhtml('../Message/IndexShowMsgList.aspx', '官网轮播');
        }
        function checkChange() {
            if ($('#txtPubTime').val() == '') {
                v5.error('发布时间不能为空', '1', 'true');
            } else if ($('#txtContent').val() == '') {
                v5.error('内容不能为空', '1', 'true');
            } else {
                ActionModel("/Message/IndexShowMsg.aspx?Action=Add", $('#form1').serialize());
            }
        }
    </script>
</body>
</html>
