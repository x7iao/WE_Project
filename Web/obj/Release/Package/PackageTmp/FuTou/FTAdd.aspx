<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FTAdd.aspx.cs" Inherits="WE_Project.Web.FuTou.FTAdd" %>

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
                        <td width="20%" align="right">会员账号:
                        </td>
                        <td width="30%">
                            <%=TModel.MID %>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" align="right">
                            <%=WE_Project.BLL.Reward.List["MHB"].RewardName %>  :
                        </td>
                        <td width="30%">
                            <%=TModel.MConfig.MHB %>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" align="right">
                            <%=WE_Project.BLL.Reward.List["MJB"].RewardName %>  :
                        </td>
                        <td width="30%">
                            <%=TModel.MConfig.MJB %>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <span>使用钱包：</span>
                        </td>
                        <td>
                            <input value="MHB" checked="checked" type="radio" name="rdo" /><%=WE_Project.BLL.Reward.List["MHB"].RewardName %>
                            <input value="MJB" type="radio" name="rdo" /><%=WE_Project.BLL.Reward.List["MJB"].RewardName %>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <span>转入时间：</span>
                        </td>
                        <td>
                            
                                <%=remain2 %>
                         
                        </td>
                    </tr>
                    <tr>
                        <td width="20%" align="right">转入金额:
                        </td>
                        <td width="30%">
                            <input type="text" id="txtCount" name="txtCount" class="normal_input" />
                        </td>
                    </tr>
                    <tr style="height: 50px;">
                        <td></td>
                        <td align="left">
                            <input class="normal_btnok" id="btnOK" type="button" runat="server" value="转入" onclick="checkChange();" />
                        </td>
                    </tr>
                </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            if (!$("#txtCount").val().TryInt()) {
                v5.error('请输入正确的转入金额(整颗)', '1', 'true');
            }
            else {
                ActionModelBack("/FuTou/FTAdd.aspx?Action=add", $('#form1').serialize(), "FuTou/FTList.aspx",
                function () {
                    $("#btnOK").removeAttr("onclick");
                    $("#btnOK").val("请等待...");
                },"许愿台列表");
            }
        }
    </script>
</body>
</html>
