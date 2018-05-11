<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="chat.aspx.cs" Inherits="WE_Project.Web.Mafull.chat.chat" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8">
    <title>聊天</title>
    <link rel="stylesheet" type="text/css" href="/Mafull/chat/css/bootstrap.min.css">
    <link rel="stylesheet" type="text/css" href="/Mafull/chat/css/style.css">
    <script src="/Admin/js/jquery-1.9.1.min.js" type="text/javascript"></script>
</head>
<body style="overflow: hidden">
    <div class="chat_dialog">
        <div class="chat_left" style="width: 75%; float: left; border-right: solid 2px rgb(179, 121, 0);
            border-bottom: solid 2px rgb(179, 121, 0);">
            <div style="height: 312px; width: 100%; padding: 10px; overflow-y: auto; margin-bottom: 10px;">
                <div class="chat_view">
                    <h3>
                        订单:
                        <%=code %></h3>
                    <input id="ccode" type="hidden" value="<%=code %>" />
                    <h4>
                        您可以跟该订单的参与者聊天</h4>
                    <div style="color: red; font-style: italic; font-weight: bold;">
                        <br />
                        警告！
                        <br />
                        <br />
                        您不要用允许作退款的转移系统，例如PayPal或Scrill！您收到资金后，发件人有权收回汇款而这笔钱将退还！诈骗者通常使用此选项！当心！
                    </div>
                    <div class="chat_Z">
                        <%
                            foreach (var model in chatList)
                            {
                        %>
                        <div class="chat_content">
                            <div class="msg_row">
                                <%=model.SendName %><span title="online" class="user_online">&nbsp;</span>
                                <br />
                                <%=model.SendTime.ToString("dd.MM.yyyy HH:mm") %>
                                <br />
                                <%=model.SendTypeStr %>
                            </div>
                            <div class="msg">
                                <%=model.TContent %>
                                <div style="padding-top: 10px; padding-bottom: 10px">
                                    <%
                                        foreach (string url in model.SendImages.Split('&'))
                                        {
                                            if (!string.IsNullOrEmpty(url))
                                            {
                                    %>
                                    <a target="_blank" href="<%=url %>">
                                        <img style="max-width: 100px; max-height: 100px; margin-right: 20px; margin-bottom: 20px;
                                            float: left;" src="<%=url %>"></a>
                                    <%
                                        }
                                        }
                                    %>
                                </div>
                            </div>
                        </div>
                        <%
                            }
                        %>
                    </div>
                </div>
            </div>
            <div class="panel layout-panel layout-panel-south">
                <div style="height: 178px; width: 100%; padding-left: 10px;">
                    <textarea id="msg_reply" style="height: 130px; width: 100%; padding-left: 10px;"></textarea>
                    <br />
                    <a id="chat_reply_save" href="javascript:void(0)" class="easyui-linkbutton l-btn save"
                        onclick="chatReplySave(); return false;" style="padding-left: 30px; background: url(/Mafull/chat/images/filesave.png) 12px center no-repeat #fddb67;
                        float: right">发送</a>
                </div>
            </div>
        </div>
        <form id="form1" method="post" action="/Mafull/IbeaconHandler.ashx" target='frameFile'
        enctype="multipart/form-data">
        <div class="chat_right" style="width: 25%; float: right;">
            <input type="hidden" id="imgs" />
            <div class="chat_files">
                <input type='file' id='fileUp' name='fileUp' onchange="changeform();" style="display: none" />
                <button type="button" onclick="changeform1();">
                    选择文件</button>
                <div id='uploadLog'>
                </div>
                <input type="hidden" id="hduploadPic1" runat="server" name="hduploadPic1" />
            </div>
            <div class="chat_imgs">
                <ul class="qq-upload-list">
                </ul>
            </div>
        </div>
        </form>
    </div>
    <script type="text/javascript">
        function chatReplySave() {
            var content = $("#msg_reply").val();
            var ccode = $("#ccode").val();
            var imgs = $("#imgs").val();
            if (content != "") {
                $.ajax({
                    type: 'post',
                    cache: false,
                    url: '/Mafull/chat/chat.aspx?Action=add',
                    data: { content: content, ccode: ccode, imgs: imgs },
                    success: function (info) {
                        if (info[0] == "1") {
                            $(".chat_Z").append(info.substring(1));
                            $("#msg_reply").val("");
                            $("#imgs").val("");
                            $(".qq-upload-list").html("");
                        }
                    }
                });
            }
        }
        function changeform1() {
            $("#fileUp").click();
        }
        function changeform() {
            $('#form1').submit();
        }
        function uploadSuccess(msg) {
            if (msg.split('|').length > 1) {//成功
                $('#hduploadPic1').val(msg.split('|')[1]);
                //                $('#uploadLog').html(msg.split('|')[0]);
                $("#imgs").val($("#imgs").val() + "&" + msg.split('|')[1]);
                addimgs(msg.split('|')[1]);
            } else {
                $('#uploadLog').html(msg);
            }
        }
        function addimgs(url) {
            var html = "<li class=\"qq-upload-success\"><img width=\"100\" height=\"100\" src=\"" + url + "\" ><br /><span class=\"qq-upload-file\">image/jpeg</span><br><span class=\"qq-upload-delete\"><a href=\"javascript:void(0)\" onclick=\"deleteimgs(this,'" + url + "')\">删除</a></span></li>";
            $(".qq-upload-list").append(html);
        }
        function deleteimgs(obj, url) {
            $("#imgs").val($("#imgs").val().replace(url, ""));
        }
    </script>
    <iframe id='frameFile' name='frameFile' style='display: none;'></iframe>
</body>
</html>
