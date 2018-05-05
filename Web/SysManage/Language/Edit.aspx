<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="WE_Project.Web.Language.Edit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .waitTips
        {
            width: 100%;
            height: 100%;
            left: 0px;
            top: 0px;
            background-color: rgb(234, 234, 242);
            text-align: center;
            filter: alpha(Opacity=60);
            -moz-opacity: 0.6;
            opacity: 0.6;
            position:absolute;
        }
        .tabInput
        {
            width: 98%;
        }
        .thCenter
        {
            text-align: center;
        }
        .appendImg
        {
            width: 60px;
        }
        .AppTB tr
        {
            height: 30px;
        }
        .AppTB a, #TBSrcAtt a, #TBSqlAtt a
        {
            color: Blue;
        }
        .AttDiv
        {
            left: 480px; /*FF IE7*/
            top: 30%; /*FF IE7*/
            z-index: 1002;
            outline: 0px none;
            height: auto;
            width: 460px;
            margin-left: -150px !important; /*FF IE7 该值为本身宽的一半 */
            margin-top: -60px !important; /*FF IE7 该值为本身高的一半*/
            margin-top: 0px;
            position: fixed !important; /*FF IE7*/
            position: absolute; /*IE6*/
            background-color: rgb(37, 247, 191);
        }
        .ui-dialog-titlebar-close
        {
            float: right;
        }
        .AttBg
        {
            background-color: #FDFDFD;
            width: 100%;
            height: 100%;
            left: 0;
            top: 0; /*FF IE7*/
            filter: alpha(opacity=50); /*IE*/
            opacity: 0.5; /*FF*/
            z-index: 1;
            position: fixed !important; /*FF IE7*/
            position: absolute; /*IE6*/
        }
    </style>
    <link href="../Common/uploadify/uploadify.css" rel="stylesheet" type="text/css" />
    <script src="../Common/uploadify/migrate.js" type="text/javascript"></script>
    <script src="../Common/uploadify/jquery.uploadify.js" type="text/javascript"></script>
    <script type="text/javascript">
        function deleteFiles(fileName) {
            //alert(fileName);
            $.ajax({
                type: "Post",
                url: "/Common/DeleteUPFile.ashx?path=" + fileName,
                success: function (data) {
                    if (data == "1") {
                        v5.error('删除成功', '1', 'true');
                        $("#spFileInfo").html("");
                        $("#hidExcelPath").val("");
                    }
                    else if (data == "-1") {
                        v5.error('删除失败', '1', 'true');
                    }
                    else if (data == "0") {
                        v5.error('文件不存在', '1', 'true');
                    }
                    else if (data == "-2") {
                        v5.error('参数错误', '1', 'true');
                    }

                },
                error: function (err) {
                    alert(err);
                }
            });

        }
        function loadUploadify() {
            var list = "fileQueue2";
            $("#uploadify").uploadify({
                'swf': '/Common/uploadify/uploadify.swf',
                'uploader': '/Common/UploadExcel.ashx?t=xls', //相对路径的后端脚本，它将处理您上传的文件。绝对路径前缀或'/'或'http'的路径
                'folder': '../Attachment/',
                'cancelImg': '/Common/uploadify/uploadify-cancel.png',
                'script': 'UploadExcel.ashx',
                'queueID': list,
                'auto': false,
                'multi': false,
                'fileTypeDesc': 'Excel文件', //出现在上传对话框中的文件类型描述
                'fileTypeExts': '*.xls;*.xlsx',  //控制可上传文件的扩展名，启用本项时需同时声明fileDesc
                'buttonText': '选择文件',
                'onUploadSuccess': function (file, data, response) {
                    $("#hidExcelPath").val(data);
                    $("#spFileInfo").html("&emsp;" + file.name + "&emsp;<a  id='delFiles' style='cursor:pointer' onclick=deleteFiles('" + data + "')> 删除</a>");

                }
            });
        }

        function showUpload() {
            var attsType = $(this).attr("AttsType");
            $("#btnSaveAtts").attr("AttsType", attsType);
            $("#AttBg").show();
            $("#AttDiv").show();
            return false;
        }

        function saveatts() {
            jQuery('#uploadify').uploadify('upload', '*');
        }

        $(document).ready(function () {
            loadUploadify();

            //关闭上传附件窗口
            $("#btnCloseAtts").click(function () {
                $("#AttBg").hide();
                $("#AttDiv").hide();
            });

            $("#spForClose").click(function () {
                $("#AttBg").hide();
                $("#AttDiv").hide();
            });

        });  
    </script>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <input id="hidId" type="hidden" runat="server" />
            <input id="hidExcelPath" type="hidden" runat="server" />
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td width="15%" align="right">
                        <span>中文名称：</span>
                    </td>
                    <td width="35%">
                        <input id="txtZHName" runat="server" style="width: 40%" class="pay_input" type="text"
                            require-type="require" require-msg="中文名称" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>英文名称：</span>
                    </td>
                    <td>
                        <input id="txtENName" style="width: 40%" runat="server" require-type="require" class="pay_input"
                            require-msg="英文名称" type="text" />
                    </td>
                </tr>
             <%--   <tr>
                    <td align="right">
                        <span>排序：</span>
                    </td>
                    <td>
                        <input id="txtSort" maxlength="25" runat="server" require-type="int" class="pay_input"
                            require-msg="排序" type="text" />
                    </td>
                </tr>--%>
                <tr>
                    <td width="15%" align="right">
                        <span>是否启用：</span>
                    </td>
                    <td width="35%">
                        <input id="chkStatus" runat="server" type="checkbox" value="1" checked="checked" />
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <input class="normal_btnok" id="btnOK" type="button" runat="server" value="提交" onclick="checkChange();" />&emsp;&emsp;&emsp;
                
                        <input class="btn btn-info" id="btnImport" type="button" runat="server" value="上传文件"
                            onclick="showUpload()" />
                        <input class="btn btn-success" id="btnSubmit" type="button" runat="server" value="导入"
                            onclick="checkImport();" />
                        <span id="spFileInfo"></span>
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        <span>导入信息：</span>
                    </td>
                    <td width="35%">
                        <div id="divInfo" style="color: Red">
                        </div>
                    </td>
                </tr>
            </table>
            <div id="AttBg" class="AttBg" style="display: none; margin-top: 1%;">
            </div>
            <div id="AttDiv" class="ui-dialog ui-widget ui-widget-content ui-corner-all AttDiv"
                style="display: none;">
                <div class="ui-dialog-titlebar ui-widget-header ui-helper-clearfix" style="width: 100;
                    height: 50;">
                    <span class="ui-dialog-title" id="ui-dialog-title-alertDialog" style="visibility: visible;
                        -moz-user-select: none;">上传附件</span> <a href="javascript:void(0);" class="ui-dialog-titlebar-close ui-corner-all">
                            <span class="ui-icon ui-icon-closethick" id="spForClose">关闭</span> </a>
                </div>
                <div class="ui-dialog-content ui-widget-content" id="flash_uploader" style="max-height: 280px;">
                    <div id="people">
                        <input type="file" name="uploadify" id="uploadify" />
                        <div id="fileQueue2" style="max-height: 50px;">
                        </div>
                    </div>
                </div>
                <div class="ui-dialog-buttonpane ui-widget-content ui-helper-clearfix" style="padding: 0.3em 1em 0.5em">
                    <button type="button" id="btnSaveAtts" class="btn" onclick="saveatts()">
                        上传</button>
                    &nbsp;&nbsp;
                    <button type="button" id="btnCloseAtts" class="btn">
                        关闭</button>
                </div>
            </div>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            if (checkForm())
                ActionModelBackWithTitleWithNoVerify("/Language/Edit.aspx?Action=add", $('#form1').serialize(), "Language/List.aspx", null, '语言设置');
        }
        function checkImport() {
            if ($.trim($("#hidExcelPath").val()) == "") {
                v5.error('文件未上传成功，请重试', '1', 'true');
                return;
            }
            else {
                verifypsd(function () {
                    $("#finance").append("<div class='waitTips'><img  style='margin-top:15%' src='../images/loading.gif' /></div>");
                    $.ajax({
                        type: 'post',
                        url: '/Language/Edit.aspx?Action=modify',
                        data: $('#form1').serialize(),
                        success: function (info) {
                            $(".waitTips").remove();
                            $("#divInfo").html(info);
                        }
                    });
                });
            }
        }
    </script>
</body>
</html>
