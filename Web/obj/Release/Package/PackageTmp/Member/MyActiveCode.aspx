<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyActiveCode.aspx.cs" Inherits="WE_Project.Web.Member.MyActiveCode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tUrl = "/Handler/ActiveCodeList.ashx";
        tState = "";
        SearchByCondition();
    </script>
</head>
<body>
    <div id="mempay">
        <form id="form1">
        <div class="control">
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <input id="mKey" name="txtKey" placeholder="请输入会员账号" type="text" class="sinput" />
            </div>
            <%--<div class="pay" onclick="v5.show('ChangeMoney/PayHB.aspx','在线购买激活码','url',620,400)">
                在线购买激活码</div>--%>
            <div class="cheeckbox" style="width: auto;">
                <table cellpadding="0" cellspacing="0" style="width: 100%;">
                    <tr>
                        <td>
                            分发会员：<input id="txtMID" runat="server" class="normal_input" type="text" maxlength="20"
                                style="width: 100px" />&emsp;数量：<input id="txtCount" runat="server" class="normal_input"
                                    type="text" maxlength="20" style="width: 70px" />
                            <input class="normal_btnok btn btn-primary btn-sm" id="btnPublish" type="button" runat="server" value="发放"
                                onclick="publishChange();" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
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
                </div>
                <div class="pagebar">
                    <div id="Pagination">
                    </div>
                </div>
            </div>
        </div>
        </form>
    </div>
    <script type="text/javascript">

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
                    url: '/Member/MyActiveCode.aspx?Action=modify',
                    data: $('#form1').serialize(),
                    success: function (info) {
                        if (info == "1") {
                            v5.alert("分发成功", '1', 'true');
                            setTimeout(function () { v5.clearall(); }, 1000);
                        }
                        else {
                            v5.alert("分发失败，" + info, '1', 'true');
                        }
                    }
                });
            });
        }
    </script>
</body>
</html>
