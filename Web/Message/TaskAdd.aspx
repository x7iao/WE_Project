<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TaskAdd.aspx.cs" Inherits="WE_Project.Web.Message.TaskAdd"
    EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>发送信息</title>
    <link rel="stylesheet" href="/plugin/kindeditor/themes/default/default.css" />
    <script type="text/javascript" language="javascript">
        var K = window.KKKK;
        var uploadbutton = K.uploadbutton({
            button: K('#GatheringPic')[0],
            fieldName: 'imgFile',
            url: '/plugin/kindeditor/asp.net/upload_json.ashx?dir=image',
            afterUpload: function (data) {
                if (data.error === 0) {
                    var url = K.formatUrl(data.url, 'absolute');
                    K('#hduploadPic1').val(url);
                    K('#uploadLog').html("上传成功");
                    K("#imgPic").attr("src", url);
                } else {
                    $('#uploadLog').html(data.message);
                }
            },
            afterError: function (str) {
                alert('自定义错误信息: ' + str);
            }
        });
        uploadbutton.fileBox.change(function (e) {
            uploadbutton.submit();
        });
    </script>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1" name='form1' method="post" action="/Mafull/IbeaconHandler.ashx"
            target='frameFile' enctype="multipart/form-data">
            <input type="hidden" id="hidIndex" value="" />
            <table cellpadding="0" cellspacing="0">
                <%if (TModel.Role.IsAdmin)
                  { %>
                <tr>
                    <td width="25%" align="right">
                        会员账号：
                    </td>
                    <td width="75%" style="height: 40px;">
                        <select id="ddlAdmin" style="display: none;" runat="server" onclick="$('#txtMID').val($(this).val());">
                        </select>
                        <input id="txtMID" runat="server" style="width: 120px;" class="normal_input" name="txtMID"
                            type="text" />
                        <input id="hdMID" runat="server" type="hidden" />
                    </td>
                </tr>
                <%} %>
                <tr>
                    <td align="right">
                        留言类型
                    </td>
                    <td>
                        <select id="ddlTType" runat="server">
                            <option value="002">付款问题</option>
                            <option value="003">账号问题</option>
                            <option value="004">建议问题</option>
                            <option value="005">技术问题</option>
                            <option value="006">提现问题</option>
                            <option value="007">其他问题</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        留言内容：
                    </td>
                    <td>
                        <textarea id="txtMessage" runat="server" class="msg_input" type="text" maxlength="500"
                            style="width: 500px; height: 90px;"></textarea>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        附件上传：
                    </td>
                    <td>
                        <input type="button" id="GatheringPic" value="上传图片" />
                        <div id='uploadLog'>
                        </div>
                        <input type="hidden" id="hduploadPic1" name="hduploadPic1" />
                        <img id="imgPic" class='appImg' style='max-width: 700px;' />
                    </td>
                </tr>
                <tr style="height: 40px;">
                    <td align="right">
                        <input name="重置" type="reset" class="normal_btnok" value="重置" style="display: none;" />
                    </td>
                    <td>
                        <input class="normal_btnok" id="btnOK" type="button" runat="server" value="提交" onclick="checkChange();" />
                    </td>
                </tr>
            </table>
            <span class="remak">温馨提示：请详细填写您要反映的内容，平台客服人员会尽快处理和回复您提交的问题！</span>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            if ($('#txtMessage').val().Trim() == '') {
                v5.error('请输入信息内容', '1', 'true');
            } else {
                <%if(TModel.Role.IsAdmin){ %>
                ActionModelNoVer("/Message/TaskAdd.aspx?Action=add", $('#form1').serialize());
                <%} else {%>
                ActionModel("/Message/TaskAdd.aspx?Action=add", $('#form1').serialize());
                <%} %>
            }
        }
    </script>
</body>
</html>
