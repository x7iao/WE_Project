<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EPConfig.aspx.cs" Inherits="WE_Project.Web.EP.EPConfig" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>EP配置</title>
    <meta http-equiv="Content-Type" content="text/html;charset=utf-8" />
    <script type="text/javascript" charset="utf-8" src="/plugin/UEditor/editor_config.js"></script>
    <script type="text/javascript" charset="utf-8" src="/plugin/UEditor/editor_all.js"></script>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td align="right">
                        <span>EP交易状态：</span>
                    </td>
                    <td>
                        <select id="ddlEPState" runat="server">
                            <option value="True">开放交易</option>
                            <option value="False">关闭交易</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>交易时间：</span>
                    </td>
                    <td>
                        <input id="txtEPStartTime" runat="server" class="normal_input" type="text" />－<input
                            id="txtEPEndTime" runat="server" class="normal_input" type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>交易类型：</span>
                    </td>
                    <td>
                        <select id="ddlEPJYType" runat="server">
                            <option value="0">不限金额</option>
                            <option value="1">限额最低</option>
                            <option value="2">以下金额</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>最少交易金额：</span>
                    </td>
                    <td>
                        <input id="txtEPJYMinMoney" runat="server" class="normal_input" type="text" />
                        倍数：<input id="txtEPJYBaseMoney" runat="server" class="normal_input" type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>以下交易金额：</span>
                    </td>
                    <td>
                        <input id="txtEPMoneyStr" runat="server" class="normal_input" type="text" />,号隔开如：100,200,300
                    </td>
                </tr>
               
                <tr>
                    <td align="right">
                        <span>交易币种：</span>
                    </td>
                    <td>
                        <select id="ddlEPMoneyType" runat="server">
                            <option value="MHB">现金币</option>
                           
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>超时时长（分钟）：</span>
                    </td>
                    <td>
                        <input id="txtEPTimeOut" runat="server" class="normal_input" type="text" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>超时次数降星：</span>
                    </td>
                    <td>
                        <input id="txtEPTimeOutCount" runat="server" class="normal_input" type="text" />10次
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>超时次数降星个数：</span>
                    </td>
                    <td>
                        <input id="txtEPTimeOutJXCount" runat="server" class="normal_input" type="text" />1个星
                    </td>
                </tr>
                <tr style=" display:none">
                    <td align="right">
                        <span>限定EP交易级别：</span>
                    </td>
                    <td>
                        <input id="txtEPJYMAgencyTypeStr" runat="server" class="normal_input" type="text" />
                    </td>
                </tr>
                      <tr>
                    <td align="right">
                        <span>交易手续费：</span>
                    </td>
                    <td>
                        <input id="txtEPTakeOffMoney" runat="server" class="normal_input" type="text" />
                    </td>
                </tr>
                 <tr>
                    <td align="right">
                        <span>用户协议：</span>
                    </td>
                    <td>
                        <script id="editor" type="text/plain"><%=_content %></script>
                        <input name="hdEPProtocol" id="hdContent" type="hidden" />
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
        var ue = UE.getEditor('editor');
        function checkChange() {
            $('#hdContent').val(encodeURI(ue.getContent()));
            ActionModel("/EP/EPConfig.aspx?Action=modify", $('#form1').serialize());
        }
    </script>
</body>
</html>
