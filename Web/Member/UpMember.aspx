<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpMember.aspx.cs" Inherits="WE_Project.Web.Member.UpMember" %>

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
                    <td style="width: 30%" align="right">
                        会员账号:
                    </td>
                    <td id="memberMid">
                        <%=TModel.MID%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        会员昵称:
                    </td>
                    <td>
                        <%=TModel.MName%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        注册手机:
                    </td>
                    <td>
                        <%=TModel.Tel%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        注册时间:
                    </td>
                    <td>
                        <%=TModel.MCreateDate%>
                    </td>
                </tr>
                <%--<tr>
                    <td>
                        我的<%=WE_Project.BLL.Reward.List["MJB"].RewardName %>:
                    </td>
                    <td>
                        <%=TModel.MConfig.MJB %>
                    </td>
                </tr>
                <tr>
                    <td>
                        激活所需<%=WE_Project.BLL.Reward.List["MJB"].RewardName %>:
                    </td>
                    <td>
                        <%=WE_Project.BLL.MMMConfig.Model.ActiveCodePrice %>
                    </td>
                </tr>--%>
                <tr>
                    <td>
                        激活码：
                    </td>
                    <td>
                        <input type="text" id="txtActiveCode" runat="server" />
                    </td>
                </tr>
                <tr style="height: 50px;">
                    <td align="right">
                    </td>
                    <td align="left">
                        <input class="normal_btnok" id="btnOK" type="button" runat="server" value="提交" onclick="upAgency();" />&nbsp;
                        <%--<input type="button" class="btn btn-danger" onclick="returnList()" value="返回" />--%>
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function returnList() {
            callhtml('../Member/SHList.aspx', '激活账号');
        }
        function ActionModelAndRefreathPage(acturl, actdata, fun) {
            verifypsd(function () {
                $.ajax({
                    type: 'post',
                    url: acturl,
                    data: actdata,
                    success: function (info) {
                        v5.error(info, '2', 'true');
                        if (info.indexOf('恭喜您') >= 0) {
                            setTimeout(function () {
                                v5.clearall();
                                window.location.reload();
                            }, 2000);
                        }
                    }
                });
            }, fun);
        }

        function upAgency() {
            var roleCode = '<%=TModel.RoleCode %>';
            if (roleCode == "Notactive") {
                ActionModelAndRefreathPage("/Member/UpMember.aspx?Action=modify", $('#form1').serialize(), null);
            }
            else {
                v5.error('您已经激活', '2', 'true');
                window.location.reload();
            }

        }
    </script>
</body>
</html>
