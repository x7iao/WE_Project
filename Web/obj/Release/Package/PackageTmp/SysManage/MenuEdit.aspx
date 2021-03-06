﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuEdit.aspx.cs" Inherits="WE_Project.Web.SysManage.MenuEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <input id="hidId" type="hidden" runat="server" />
            <input id="hidCFID" type="hidden" runat="server" />
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td width="15%" align="right">
                        <span>父菜单：</span>
                    </td>
                    <td width="35%">
                        <select id="ddlCFID" runat="server">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        <span>菜单编号：</span>
                    </td>
                    <td width="35%">
                        <input id="txtCID" runat="server" class="pay_input" type="text" require-type="require"
                            require-msg="菜单编号" />
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        <span>菜单名称：</span>
                    </td>
                    <td width="35%">
                        <input id="txtName" runat="server" class="pay_input" type="text" require-type="require"
                            require-msg="菜单名称" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>链接地址：</span>
                    </td>
                    <td>
                        <input id="txtCAddress" style="width: 40%" runat="server" require-type="require"
                            class="pay_input" require-msg="链接地址" type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>菜单图标：</span>
                    </td>
                    <td>
                        <input id="txtCImage" style="width: 20%" runat="server" class="pay_input" type="text"
                            onclick="showIconChoice()" onchange="toSeeChange()" />
                        <i id="iMenuIcon" runat="server"></i>
                    </td>
                </tr>
                <tr style="display: none">
                    <td align="right" style="padding: 45px">
                        <span>快捷图标：</span>
                    </td>
                    <td>
                        <input id="txtBigPng" type="button" value="上传图片" class="btn btn-success" onclick="showUpload()" />
                        <img id="bigPngImg" class="innerImg" runat="server" />
                        <input type="hidden" id="hidPicUrl" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>排序：</span>
                    </td>
                    <td>
                        <input id="txtSort" maxlength="25" runat="server" require-type="int" class="pay_input"
                            require-msg="排序" type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>是否外部导航：</span>
                    </td>
                    <td>
                        <input id="chkIsOuterLink" runat="server" type="checkbox" value="1" />&emsp; <span>外链地址:</span>
                        <input id="txtOuterAddress" style="width: 30%" runat="server" class="pay_input" type="text" />
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        <span>是否快捷菜单：</span>
                    </td>
                    <td width="35%">
                        <input id="chkStatus" runat="server" type="checkbox" value="1" checked="checked" />
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        <span>权限设置：</span>
                    </td>
                    <td width="35%">
                        <asp:Repeater ID="rep_Role" runat="server">
                            <ItemTemplate>
                                <input name="chkAuth" type="checkbox" value="<%#Eval("RType") %>" <%#GetCheckedStatue(Eval("RType")) %> /><%#Eval("RName") %>
                            </ItemTemplate>
                        </asp:Repeater>
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
            <%--<div id="AttBg" class="AttBg" style="display: none; margin-top: 1%;">
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
            </div>--%>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function returnList() {
            callhtml('../SysManage/GrantPowers.aspx', '权限管理');
        }
        function checkChange() {
            if ($("#ddlCFID").val() == "0") {
                $("#txtCAddress").attr("require-type", "");
            }
            if (checkForm()) {
                if ($("#hidId").val() == "") {//添加的时候校验
                    if (!checkCIDIsUsed())
                        return;
                }
                //                $.ajax({
                //                    type: 'post',
                //                    url: '/SysManage/MenuEdit.aspx?Action=add',
                //                    data: $('#form1').serialize(),
                //                    success: function (info) {
                //                        v5.alert(info, '1', 'true');
                //                        setTimeout(function () { v5.clearall(); }, 1000);
                //                    }
                //                });
                ActionModelBackWithTitleWithNoVerify("/SysManage/MenuEdit.aspx?Action=add", $('#form1').serialize(), "SysManage/GrantPowers.aspx", null, '权限管理');
            }
        }
        function checkCIDIsUsed() {
            var cid = $.trim($("#txtCID").val());
            var result = GetAjaxString('CheckContentID', cid);
            if (result == "0") {
                v5.error('已存在该菜单编号，不可重复', '2', 'true');
                $("#txtCID").val('');
                return false;
            }
            return true;
        }
        function toSeeChange() {
            var classInput = $("#txtCImage").val();
            $("#iMenuIcon").attr("class", classInput);
            //            $("#iMenuIcon").addClass("fa").addClass(classInput);
        }
        function toSeeChangePng() {
            var bigPng = $("#txtBigPng").val();
            $("#bigPngImg").attr("src", "Admin/dist/img/png/" + bigPng);
        }

    </script>
</body>
</html>
