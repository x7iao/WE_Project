<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpMAgencyType.aspx.cs"
    Inherits="WE_Project.Web.Member.UpMAgencyType" EnableEventValidation="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
                    <td>
                        <%=sjmodel.MID%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        会员昵称:
                    </td>
                    <td>
                        <%=sjmodel.MName%>
                    </td>
                </tr>
               <tr>
                    <td align="right">
                        当前级别:
                    </td>
                    <td style=" font-weight: bold; color: Red;">
                        <%=sjmodel.MAgencyType.MAgencyName%>
                        <input id="hdmid" type="hidden" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        电子币:
                    </td>
                    <td>
                        <%=TModel.MConfig.MJB %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        会员级别:
                    </td>
                    <td>
                        <table style="width: 700px;">
                            <tr>
                                <%=MAgencyTypeColor%>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        升级该级别及其费用:
                    </td>
                    <td>
                        <%=MyMAgencyTypeRdo%>
                    </td>
                </tr>
                      <tr style=" display:none">
                    <td  align="right" >
                       
                    </td>
                       <td >
                      验证密保问题 
                    </td>
                </tr>
                   <tr style=" display:none">
                    <td align="right">
                        密保问题:
                    </td>
                    <td>
                         <select id="ddl_PwdQuestion" width="175px" runat="server">
                        </select>
                    </td>
                </tr>
                   <tr style=" display:none">
                    <td align="right">
                        密保问题答案:
                    </td>
                    <td>
                        <input type="hidden" runat="server" id="hidQuesId" />
                        <input id="pwdAnswer" class="normal_input" runat="server" type="text" /><font
                            color="red">*</font>
                    </td>
                </tr>
                <tr style="height: 50px;">
                    <td align="right">
                        <input name="重置" type="reset" class="normal_btnok" value="重置" style="display: none;" />
                    </td>
                    <td align="left">
                        <input class="normal_btnok" id="btnOK" type="button" runat="server" value="提交" onclick="checkChange();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function ActionModelAndRefreathPage(acturl, actdata, fun) {
            verifypsd(function () {
                $.ajax({
                    type: 'post',
                    url: acturl,
                    data: actdata,
                    success: function (info) {
                        v5.error(info, '2', 'true');
                        if (info.indexOf('*') <= 0) {
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
                ActionModelAndRefreathPage("/Member/UpMAgencyType.aspx?Action=modify", $('#form1').serialize(), null);
            }
            else {
                ActionModelBackWithTitle("/Member/UpMAgencyType.aspx?Action=modify", $('#form1').serialize(), "<%=url %>",
                function () {
                    $("#btnOK").removeAttr("onclick");
                    $("#btnOK").val("请等待...");
                }, '升级管理');
            }

        }
        function checkChange() {
            if (checkForm()) {
                v5.confirm("是否确定激活此会员ID？", upAgency);
            }
        }
        function checkAgency() {
            if (checkForm()) {
                var shMoney = $("#txtAgencyMoney").val();
                //判断投资额只能是10的倍数
                if (parseInt(shMoney) % 10 != 0) {
                    v5.error("投资额只能是10的倍数！", "2", "true");
                    $("#txtAgencyMoney").val('');
                    return;
                }
                //判断投资金额是否大于系统配置的最大投资金额
                var maxUpMAgency = '<%=maxUpMAgency %>';
                var result = GetAjaxString('checkAgency', shMoney + "&mid=" + $("#hdmid").val().Trim());
                if (result != '') {
                    if (result == "0") {
                        v5.error("最大升级金额不能超过！" + maxUpMAgency, "1", "true");
                        $("#txtAgencyMoney").val('');
                        return;
                    }
                    $("#spInfo").html(result.split('*')[0]);
                    $("#AgencyTypeList").val(result.split('*')[1]);
                }
                else {
                    v5.error("未查询到对应的级别！", "1", "true");
                }
            }

        }
    </script>
</body>
</html>
