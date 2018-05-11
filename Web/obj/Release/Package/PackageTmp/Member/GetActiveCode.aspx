<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetActiveCode.aspx.cs"
    Inherits="WE_Project.Web.Member.GetActiveCode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <%-- <script src="/SourceFiles/AcmeBlue/js/linkage.js" type="text/javascript"></script>--%>
    <title></title>
    <style type="text/css">
        td span
        {
            color: Red;
        }
    </style>
    <script type="text/javascript">
        tUrl = "/Handler/ActiveCodeList.ashx";
        tState = "";
        SearchByCondition();
    </script>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td width="30%" align="right">
                        激活码数量:
                        <input id="txtCodeNum" runat="server" class="normal_input" type="text" maxlength="20"
                            style="width: 90px" reqiure-type="int" require-msg="激活码数量" />
                        <input class="normal_btnok" id="btnOK" type="button" runat="server" value="创建" onclick="checkChange();" />
                    </td>
                    <td>
                        分发会员：<input id="txtMID" runat="server" class="normal_input" type="text" maxlength="20"
                            style="width: 100px" />&emsp;数量：<input id="txtCount" runat="server" class="normal_input"
                                type="text" maxlength="20" style="width: 70px" />
                        <input class="normal_btnok" id="btnPublish" type="button" runat="server" value="发放"
                            onclick="publishChange();" /><input class="normal_btnok" id="Button1" type="button"
                                runat="server" value="回扣" onclick="publishChange2();" />
                    </td>
                </tr>
            </table>
            <div class="ui_table">
                <table cellpadding="0" cellspacing="0" id="Result" class="tabcolor">
                    <tr>
                        <th width="80px">
                            全选
                        </th>
                        <th>
                            激活码
                        </th>
                        <th>
                            激活码状态
                        </th>
                        <th>
                            分发会员
                        </th>
                        <th>
                            使用会员
                        </th>
                        <th>
                            使用时间
                        </th>
                    </tr>
                </table>
                <div class="ui_table_control">
                    <em style="vertical-align: middle;">
                        <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                    <div class="pn">
                        <span id="DivOperation" runat="server"></span><a href="javascript:void(0);" class="btnDeleteIcon"
                            title="锁定" onclick="RunAjaxByList('','LockActiveCode',',');">锁定</a>
                    </div>
                    <div class="pagebar">
                        <div id="Pagination">
                        </div>
                    </div>
                </div>
            </div>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            if (checkForm()) {
                verifypsd(function () {
                    $.ajax({
                        type: 'post',
                        url: '/Member/GetActiveCode.aspx?Action=add',
                        data: $('#form1').serialize(),
                        success: function (info) {
                            if (info == "1") {
                                v5.alert("生成成功", '1', 'true');
                                setTimeout(function () { v5.clearall(); callhtml('../Member/GetActiveCode.aspx', '创建激活码'); }, 1000);
                            }
                            else {
                                v5.alert("生成失败，请重试", '1', 'true');
                            }
                        }
                    });
                });
            }
        }

        function publishChange() {
            var value = $.trim($("#txtCount").val());
            var MID = $.trim($("#txtMID").val());
            if (MID == '') {
                v5.error('分发会员不能为空', '1', 'true');
                return false;
            }
            if (!(/(^\d+$)/.test(value)) || value < 0) {
                v5.error('分发数量只能输入正整数', '1', 'true');
                return false;
            }
            verifypsd(function () {
                $.ajax({
                    type: 'post',
                    url: '/Member/GetActiveCode.aspx?Action=modify',
                    data: $('#form1').serialize(),
                    success: function (info) {
                        if (info == "1") {
                            v5.alert("分发成功", '1', 'true');
                            setTimeout(function () { v5.clearall(); callhtml('../Member/GetActiveCode.aspx', '创建激活码'); }, 1000);
                        }
                        else {
                            v5.alert("分发失败，" + info, '1', 'true');
                        }
                    }
                });
            });
        }

        function publishChange2() {
            var value = $.trim($("#txtCount").val());
            var MID = $.trim($("#txtMID").val());
            if (MID == '') {
                v5.error('分发会员不能为空', '1', 'true');
                return false;
            }
            if (!(/(^\d+$)/.test(value)) || value < 0) {
                v5.error('分发数量只能输入正整数', '1', 'true');
                return false;
            }
            verifypsd(function () {
                $.ajax({
                    type: 'post',
                    url: '/Member/GetActiveCode.aspx?Action=other',
                    data: $('#form1').serialize(),
                    success: function (info) {
                        if (info == "1") {
                            v5.alert("回扣成功", '1', 'true');
                            setTimeout(function () { v5.clearall(); callhtml('../Member/GetActiveCode.aspx', '创建激活码'); }, 1000);
                        }
                        else {
                            v5.alert("回扣失败，" + info, '1', 'true');
                        }
                    }
                });
            });
        }
    </script>
</body>
</html>
