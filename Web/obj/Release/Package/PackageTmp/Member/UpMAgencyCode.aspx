<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpMAgencyCode.aspx.cs"
    Inherits="WE_Project.Web.Member.UpMAgencyCode" %>

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
                         我当前级别:
                    </td>
                    <td>
                     <%=TModel.MAgencyType.MAgencyName%>
                    </td>
                </tr>
                <tr>
                    <td style="width: 30%" align="right">
                        经理:领导奖无限代0.05%
                    </td>
                    <td>
                        直推会员18个，团队人数200人
                    </td>
                </tr>
                <tr style="display:none;">
                    <td style="width: 30%" align="right">
                        高级经理:动态封顶50万
                    </td>
                    <td>
                        直推经理2个，团队人数1500人
                    </td>
                </tr>
                <tr style="display:none;">
                    <td style="width: 30%" align="right">
                        董事:动态不封顶
                    </td>
                    <td>
                        直推高级经理2个
                    </td>
                </tr>
                <tr>
                <td style="width: 30%" align="right">
                       升级级别：
                    </td>
                    <td>
                        <input type="radio" id="rdojl" name="rdoupmagecy" checked="checked" value="003" />经理
                    </td>
                </tr>
                <tr>
                 <td style="width: 30%" align="right">
                      
                    </td>
                    <td >
                      <input class="normal_btnok" id="btnOK" type="button" runat="server" value="申请" onclick="checkChange();" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
        <script type="text/javascript">
            function checkChange() {
                verifypsd(function () {
                    $.ajax({
                        type: 'post',
                        url: '/Member/UpMAgencyCode.aspx?Action=ADD',
                        data: $('#form1').serialize(),
                        success: function (info) {
                            v5.alert(info, '4', 'true');
                            setTimeout(function () { v5.clearall(); }, 4000);
                        }
                    });
                });
            }
        </script>
</body>
</html>
