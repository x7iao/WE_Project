<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FDConfig.aspx.cs" Inherits="WE_Project.Web.FD.FDConfig" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>富达配置</title>
</head>
<body>
    <div>
        <div id="mempay">
            <div id="finance">
                <div class="row">
                    <div class="col-sm-6">
                        <form id="form1">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="2" align="center">
                                    <span>A盘交易配置</span>
                                </td>
                            </tr>
                            <tr>
                                <td width="40%" align="right">
                                    <span>拆分倍数:</span>
                                </td>
                                <td>
                                    <input id="txtFDCFFloatA" runat="server" class="normal_input" type="text" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>价格:</span>
                                </td>
                                <td>
                                    <input id="txtFDPriceA" runat="server" class="normal_input" type="text" maxlength="6" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>发行量:</span>
                                </td>
                                <td>
                                    <input id="txtFDSellCountA" runat="server" class="normal_input" type="text" maxlength="6" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>EP币拨入:</span>
                                </td>
                                <td>
                                    <input id="txtFDMHBFloatA" runat="server" class="normal_input" type="text" maxlength="6" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>FD币拨入:</span>
                                </td>
                                <td>
                                    <input id="txtFDMGPFloatA" runat="server" class="normal_input" type="text" maxlength="6" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>购物币拨入:</span>
                                </td>
                                <td>
                                    <input id="txtFDMCWFloatA" runat="server" class="normal_input" type="text" maxlength="6" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>开盘时间:</span>
                                </td>
                                <td>
                                    <input id="txtFDStartTimeA" runat="server" class="normal_input" type="text" maxlength="6" />9:00
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>关盘时间:</span>
                                </td>
                                <td>
                                    <input id="txtFDEndTimeA" runat="server" class="normal_input" type="text" maxlength="6" />23:00
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>关盘提示:</span>
                                </td>
                                <td>
                                    <input id="txtFDCloseRemarkA" runat="server" class="normal_input" type="text" maxlength="6" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>交易状态:</span>
                                </td>
                                <td>
                                    <select id="ddlFDStateA" runat="server">
                                        <option value="True">正常交易</option>
                                        <option value="False">关闭交易</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <input id="txtZFCountA" runat="server" style="width:80px;" class="normal_input" type="text" maxlength="6" />
                                    <input class="btn btn-purple" type="button" runat="server" value="发行/增发" onclick="zengfafd('form1');" />
                                </td>
                                <td>
                                    <input class="btn btn-success" type="button" runat="server" value="保存" onclick="checkChange('form1');" />
                                    <input class="btn btn-success" type="button" runat="server" value="拆分" onclick="caifenfd('form1');" />
                                    <input class="btn btn-success" type="button" runat="server" value="清仓" onclick="qingcangfd('form1');" />
                                    <input class="btn btn-success" type="button" runat="server" value="初始化" onclick="resetfd('form1');" />
                                </td>
                            </tr>
                        </table>
                        </form>
                    </div>
                    <div class="col-sm-6">
                        <form id="form2">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="2" align="center">
                                    <span>B盘交易配置</span>
                                </td>
                            </tr>
                            <tr>
                                <td width="40%" align="right">
                                    <span>拆分倍数:</span>
                                </td>
                                <td>
                                    <input id="txtFDCFFloatB" runat="server" class="normal_input" type="text" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>价格:</span>
                                </td>
                                <td>
                                    <input id="txtFDPriceB" runat="server" class="normal_input" type="text" maxlength="6" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>发行量:</span>
                                </td>
                                <td>
                                    <input id="txtFDSellCountB" runat="server" class="normal_input" type="text" maxlength="6" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>EP币拨入:</span>
                                </td>
                                <td>
                                    <input id="txtFDMHBFloatB" runat="server" class="normal_input" type="text" maxlength="6" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>FD币拨入:</span>
                                </td>
                                <td>
                                    <input id="txtFDMGPFloatB" runat="server" class="normal_input" type="text" maxlength="6" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>购物币拨入:</span>
                                </td>
                                <td>
                                    <input id="txtFDMCWFloatB" runat="server" class="normal_input" type="text" maxlength="6" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>开盘时间:</span>
                                </td>
                                <td>
                                    <input id="txtFDStartTimeB" runat="server" class="normal_input" type="text" maxlength="6" />9:00
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>关盘时间:</span>
                                </td>
                                <td>
                                    <input id="txtFDEndTimeB" runat="server" class="normal_input" type="text" maxlength="6" />23:00
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>关盘提示:</span>
                                </td>
                                <td>
                                    <input id="txtFDCloseRemarkB" runat="server" class="normal_input" type="text" maxlength="6" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>交易状态:</span>
                                </td>
                                <td>
                                    <select id="ddlFDStateB" runat="server">
                                        <option value="True">正常交易</option>
                                        <option value="False">关闭交易</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <input id="txtZFCountB" runat="server" style="width:80px;" class="normal_input" type="text" maxlength="6" />
                                    <input class="btn btn-purple" type="button" runat="server" value="发行/增发" onclick="zengfafd('form2');" />
                                </td>
                                <td>
                                    <input class="btn btn-success" type="button" runat="server" value="保存" onclick="checkChange('form2');" />
                                    <input class="btn btn-success" type="button" runat="server" value="拆分" onclick="caifenfd('form2');" />
                                    <input class="btn btn-success" type="button" runat="server" value="清仓" onclick="qingcangfd('form2');" />
                                    <input class="btn btn-success" type="button" runat="server" value="初始化" onclick="resetfd('form2');" />
                                </td>
                            </tr>
                        </table>
                        </form>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6">
                        <form id="form3">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="2" align="center">
                                    <span>C盘交易配置</span>
                                </td>
                            </tr>
                            <tr>
                                <td width="40%" align="right">
                                    <span>拆分倍数:</span>
                                </td>
                                <td>
                                    <input id="txtFDCFFloatC" runat="server" class="normal_input" type="text" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>价格:</span>
                                </td>
                                <td>
                                    <input id="txtFDPriceC" runat="server" class="normal_input" type="text" maxlength="6" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>发行量:</span>
                                </td>
                                <td>
                                    <input id="txtFDSellCountC" runat="server" class="normal_input" type="text" maxlength="6" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>EP币拨入:</span>
                                </td>
                                <td>
                                    <input id="txtFDMHBFloatC" runat="server" class="normal_input" type="text" maxlength="6" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>FD币拨入:</span>
                                </td>
                                <td>
                                    <input id="txtFDMGPFloatC" runat="server" class="normal_input" type="text" maxlength="6" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>购物币拨入:</span>
                                </td>
                                <td>
                                    <input id="txtFDMCWFloatC" runat="server" class="normal_input" type="text" maxlength="6" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>开盘时间:</span>
                                </td>
                                <td>
                                    <input id="txtFDStartTimeC" runat="server" class="normal_input" type="text" maxlength="6" />9:00
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>关盘时间:</span>
                                </td>
                                <td>
                                    <input id="txtFDEndTimeC" runat="server" class="normal_input" type="text" maxlength="6" />23:00
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>关盘提示:</span>
                                </td>
                                <td>
                                    <input id="txtFDCloseRemarkC" runat="server" class="normal_input" type="text" maxlength="6" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>交易状态:</span>
                                </td>
                                <td>
                                    <select id="ddlFDStateC" runat="server">
                                        <option value="True">正常交易</option>
                                        <option value="False">关闭交易</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <input id="txtZFCountC" runat="server" style="width:80px;" class="normal_input" type="text" maxlength="6" />
                                    <input class="btn btn-purple" type="button" runat="server" value="发行/增发" onclick="zengfafd('form3');" />
                                </td>
                                <td>
                                    <input class="btn btn-success" type="button" runat="server" value="保存" onclick="checkChange('form3');" />
                                    <input class="btn btn-success" type="button" runat="server" value="拆分" onclick="caifenfd('form3');" />
                                    <input class="btn btn-success" type="button" runat="server" value="清仓" onclick="qingcangfd('form3');" />
                                    <input class="btn btn-success" type="button" runat="server" value="初始化" onclick="resetfd('form3');" />
                                </td>
                            </tr>
                        </table>
                        </form>
                    </div>
                    <div class="col-sm-6">
                        <form id="form4">
                        <table cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="2" align="center">
                                    <span>D盘交易配置</span>
                                </td>
                            </tr>
                            <tr>
                                <td width="40%" align="right">
                                    <span>拆分倍数:</span>
                                </td>
                                <td>
                                    <input id="txtFDCFFloatD" runat="server" class="normal_input" type="text" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>价格:</span>
                                </td>
                                <td>
                                    <input id="txtFDPriceD" runat="server" class="normal_input" type="text" maxlength="6" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>发行量:</span>
                                </td>
                                <td>
                                    <input id="txtFDSellCountD" runat="server" class="normal_input" type="text" maxlength="6" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>EP币拨入:</span>
                                </td>
                                <td>
                                    <input id="txtFDMHBFloatD" runat="server" class="normal_input" type="text" maxlength="6" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>FD币拨入:</span>
                                </td>
                                <td>
                                    <input id="txtFDMGPFloatD" runat="server" class="normal_input" type="text" maxlength="6" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>购物币拨入:</span>
                                </td>
                                <td>
                                    <input id="txtFDMCWFloatD" runat="server" class="normal_input" type="text" maxlength="6" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>开盘时间:</span>
                                </td>
                                <td>
                                    <input id="txtFDStartTimeD" runat="server" class="normal_input" type="text" maxlength="6" />9:00
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>关盘时间:</span>
                                </td>
                                <td>
                                    <input id="txtFDEndTimeD" runat="server" class="normal_input" type="text" maxlength="6" />23:00
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>关盘提示:</span>
                                </td>
                                <td>
                                    <input id="txtFDCloseRemarkD" runat="server" class="normal_input" type="text" maxlength="6" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>交易状态:</span>
                                </td>
                                <td>
                                    <select id="ddlFDStateD" runat="server">
                                        <option value="True">正常交易</option>
                                        <option value="False">关闭交易</option>
                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <input id="txtZFCountD" runat="server" style="width:80px;" class="normal_input" type="text" maxlength="6" />
                                    <input class="btn btn-purple" type="button" runat="server" value="发行/增发" onclick="zengfafd('form4');" />
                                </td>
                                <td>
                                    <input class="btn btn-success" type="button" runat="server" value="保存" onclick="checkChange('form4');" />
                                    <input class="btn btn-success" type="button" runat="server" value="拆分" onclick="caifenfd('form4');" />
                                    <input class="btn btn-success" type="button" runat="server" value="清仓" onclick="qingcangfd('form4');" />
                                    <input class="btn btn-success" type="button" runat="server" value="初始化" onclick="resetfd('form4');" />
                                </td>
                            </tr>
                        </table>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange(formobj) {
            ActionModel("/FD/FDConfig.aspx?Action=Modify&formid=" + formobj, $('#' + formobj).serialize());
        }
        function caifenfd(formobj) {
            ActionModel("/FD/FDConfig.aspx?Action=Other&formid=" + formobj, $('#' + formobj).serialize());
        }
        function qingcangfd(formobj) {
            ActionModel("/FD/FDConfig.aspx?Action=Add&type=qc&formid=" + formobj, $('#' + formobj).serialize());
        }
        function zengfafd(formobj) {
            ActionModel("/FD/FDConfig.aspx?Action=Add&type=zf&formid=" + formobj, $('#' + formobj).serialize());
        }
        function resetfd(formobj) {
            ActionModel("/FD/FDConfig.aspx?Action=Add&type=csh&formid=" + formobj, $('#' + formobj).serialize());
        }
    </script>
</body>
</html>
