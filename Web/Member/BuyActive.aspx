<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuyActive.aspx.cs" Inherits="WE_Project.Web.Member.BuyActive" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        function changeform() {
            $('#uploadLog').html('开始上传中....');
            $('#form1').submit();
        }
        function uploadSuccess(msg) {
            if (msg.split('|').length > 1) {
                $('#hduploadPic1').val(msg.split('|')[1]);
                $('#uploadLog').html(msg.split('|')[0]);
            } else {
                $('#uploadLog').html(msg);
            }
        }
      
    </script>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1" name='form1' method="post" action="/Mafull/IbeaconHandler.ashx"
            target='frameFile' enctype="multipart/form-data">
            <input id="hidId" type="hidden" runat="server" />
            <input id="hidCFID" type="hidden" runat="server" />
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td width="15%" align="right">
                        <span>支付宝账号：</span>
                    </td>
                    <td width="35%">
                        <%=WebModel.HKInfo %><span style="color: Red; font-size: 18px;">《支付宝转账时请备注会员账号，谢谢合作》</span>
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        <span>激活码价格：</span>
                    </td>
                    <td width="35%">
                        <span id="Span1">60元/个</span>
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        <span>购买数量：</span>
                    </td>
                    <td width="35%">
                        <input type="text" id="txtCount" runat="server" value="1" maxlength="4" require-type="int"
                            require-msg="购买数量" />
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        <span>备注留言：</span>
                    </td>
                    <td width="35%">
                        <textarea id="txtRemark" runat="server" style="width: 500px"></textarea>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="padding: 45px">
                        <span>上传附件：</span>
                    </td>
                    <td>
                        <input type='file' id='fileUp' name='fileUp' onchange="changeform();" />
                        <div id='uploadLog'>
                        </div>
                        <input type="hidden" id="hduploadPic1" name="hduploadPic1" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <input class="normal_btnok" id="btnOK" type="button" runat="server" value="提交" onclick="checkChange();" />&nbsp;
                        <input class="btn btn-danger" id="Button1" type="button" runat="server" value="返回"
                            onclick="returnList();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">

        function checkChange() {
            if (checkForm()) {
                $.ajax({
                    type: 'post',
                    url: '/Member/BuyActive.aspx?Action=add',
                    data: $('#form1').serialize(),
                    success: function (info) {
                        if (info == "1") {
                            v5.alert('提交申请成功，请等待后台审核', '1', 'true');
                            setTimeout(function () { v5.clearall(); }, 1000);
                        }
                        else {
                            v5.alert(info, '1', 'true');
                            setTimeout(function () { v5.clearall(); }, 1000);
                        }
                    }
                });
            }
        }
    </script>
</body>
</html>
