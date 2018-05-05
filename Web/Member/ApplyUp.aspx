<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyUp.aspx.cs" Inherits="WE_Project.Web.Member.ApplyUp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
   <style type="text/css">
   .conte{ width:500px}
   </style>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <table cellpadding="0" cellspacing="0">
                 <tr>
                    <td class="lefttdwidth" align="right">
                       申请条件:
                    </td>
                    <td width="35%">
                    <div class="conte">
                      <span id="spCondition" runat="server">
                      </span>
                      </div>
                    </td>
                </tr>

                   <tr>
                    <td class="lefttdwidth" align="right">
                       当前级别:
                    </td>
                    <td width="35%">
                    <%=sjmodel.MAgencyType.MAgencyName%>
                        <input id="hdmid" type="hidden" runat="server" />
                    </td>
                </tr>

             <tr>
                    <td class="lefttdwidth" align="right">
                       申请级别:
                    </td>
                    <td width="35%">
                    <%=MAgencyTypeColor%>
                    </td>
                </tr>
                <tr>
                    <td class="lefttdwidth" align="right">
                        会员 ID:
                    </td>
                    <td width="35%">
                        <input id="txtMID" runat="server" class="normal_input" type="text" maxlength="20" readonly="readonly" />
                    </td>
                </tr>
                <tr>
                  <td width="15%" align="right">
                        会员昵称:
                    </td>
                    <td width="35%">
                       <input id="txtMName" runat="server" class="normal_input" type="text" maxlength="20"  readonly="readonly"/>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2" class="sen_title">
                        <span id="showmessage" runat="server"></span>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2" class="sen_title">
                       <input class="normal_btnok" id="btnOK" type="button" runat="server" value="申请" onclick="checkChange();" />
                          <input class="normal_btnok" id="btnCancle" type="button" runat="server" value="取消申请" onclick="cancleChange();" />
                            <input   id="hidtype" type="hidden" runat="server"/>
                    </td>
                </tr>
               
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        //setup();
        function cancleChange() {
            verifypsd(function () {
                $.ajax({
                    type: 'post',
                    url: '/Member/ApplyUp.aspx?Action=MODIFY',
                    data: $('#form1').serialize(),
                    success: function (info) {
                        v5.alert(info, '1', 'true');
                        setTimeout(function () { v5.clearall(); }, 1000);
                        callhtml('Member/ApplyCenter.aspx?type=<%=type %>', $(".alert-danger").find("strong").text());
                    }
                });
            });
        }
        function checkChange() {
            var aptype = '<%=type %>';
            if ($('#txtMID').val().Trim() == "") {
                v5.error('股东ID不能为空', '1', 'true');
            } else if ($('#txtMName').val() == "") {
                v5.error('股东名称不能为空', '1', 'true');
            } else {
                if (aptype == "region") {
                    if ($('#txtQQGroup').val() == "") {
                        v5.error('QQ群不能为空', '1', 'true');
                        return false;
                    }
                    if ($('#txtQQ').val() == "") {
                        v5.error('QQ号码不能为空', '1', 'true');
                        return false;
                    }
                    if ($('#txtTel').val() == "") {
                        v5.error('手机号码不能为空', '1', 'true');
                        return false;
                    }
                }
                verifypsd(function () {
                    $.ajax({
                        type: 'post',
                        url: '/Member/ApplyCenter.aspx?Action=add',
                        data: $('#form1').serialize(),
                        success: function (info) {
                            v5.alert(info, '1', 'true');
                            setTimeout(function () { v5.clearall(); }, 1000);
                            callhtml('Member/ApplyUp.aspx?type=<%=type %>', $(".alert-danger").find("strong").text());
                        }
                    });
                });
            }
        }
    </script>
</body>
</html>
