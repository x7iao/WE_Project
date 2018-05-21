<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NoticeModify.aspx.cs" Inherits="WE_Project.Web.Message.NoticeModify"
    ValidateRequest="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>修改公告</title>
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
    <%--<script type="text/javascript" charset="utf-8" src="/plugin/UEditor/editor_config.js"></script>
    <script type="text/javascript" charset="utf-8" src="/plugin/UEditor/editor_all.js"></script>--%>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td width="15%" align="right">
                        标题<input runat="server" id="lbID" name="lbID" type="hidden" />
                    </td>
                    <td width="75%" style="height: 40px;">
                        <input id="txtNTitle" class="normal_input" runat="server" style="width: 50%;" />
                        <%--<input type="checkbox" id="chkFixed" runat="server" checked="checked" />首页显示--%>
                        <input name="hdchkFixed" id="hdchkFixed" type="hidden" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        内容
                    </td>
                    <td style="padding: 15px;">
                        <%--<script id="editor" type="text/plain"><%=txtNContent %></script>--%>
                        <%--<input name="hdContent" id="hdContent" type="hidden" />--%>
                         <textarea id="hdContent" runat="server" style="display: none;"></textarea>
                            <input type="hidden" name="title" />
                            <input type="hidden" name="content" />

                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                    </td>
                    <td width="75%" align="left">
                        <input type="reset" class="normal_btnok" value="重 置" style="float: left;" />&nbsp;
                        <input type="button" class="normal_btnok" value="发 布" style="float: left;" onclick="checkChange();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        var layedit;
        layui.use('layedit', function () {
            layedit = layui.layedit
            , $ = layui.jquery;
            //构建一个默认的编辑器
            var index = layedit.build('hdContent');

            //编辑器外部操作
            var active = {
                content: function () {
                    alert(layedit.getContent(index)); //获取编辑器内容
                }
              , text: function () {
                  alert(layedit.getText(index)); //获取编辑器纯文本内容
              }
              , selection: function () {
                  alert(layedit.getSelection(index));
              }
            };

            $('.site-demo-layedit').on('click', function () {
                var type = $(this).data('type');
                active[type] ? active[type].call(this) : '';
            });

            //自定义工具栏
            layedit.build('hdContent', {
                tool: ['face', 'link', 'unlink', '|', 'left', 'center', 'right']
              , height: 100
            })
        });

        function checkChange() {
            if ($('#txtNTitle').val() == '') {
                v5.error('标题不能为空', '1', 'ture');
            } else if ($("#hdContent") == '') {
                v5.error('内容不能为空', '1', 'ture');
            } else {
                //                $('#hdchkFixed').val(document.getElementById('chkFixed').checked);
                //$('#hdContent').val(encodeURI(ue.getContent()));
                ActionModel("/Message/NoticeModify.aspx?Action=Modify", { title: $("#txtNTitle").val(), content: layedit.getContent(2), lbID: $("#lbID").val() });
            }
        }
    </script>
</body>
</html>
