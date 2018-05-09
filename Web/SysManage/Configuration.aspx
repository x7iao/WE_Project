<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Configuration.aspx.cs"
    Inherits="WE_Project.Web.SysManage.Configuration" EnableEventValidation="false" EnableViewState="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <style type="text/css">
        .hideCont
        {
            display: none;
        }
        #GridView1 th
        {
            color: #000000;
        }
    </style>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1" class="contentForm" runat="server">
            <table cellpadding="0" cellspacing="0">
                <tr style="display: none">
                    <td width="20%" align="right">
                        激活费用:
                    </td>
                    <td>
                        <input id="txtYLMoney" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="激活费用" /><font color="red">*正整数</font>
                    </td>
                    <td width="20%" align="right">
                        未激活删号时间:
                    </td>
                    <td>
                    </td>
                </tr>
                <tr style="display: none;">
                    <td align="right">
                        入账汇率:
                    </td>
                    <td>
                        <input id="txtInFloat" runat="server" class="normal_input" type="text" require-type="decimal"
                            require-msg="入账汇率" />
                    </td>
                    <td align="right">
                        出账汇率:
                    </td>
                    <td>
                        <input id="txtOutFloat" runat="server" class="normal_input" type="text" require-type="decimal"
                            require-msg="出账汇率" /><font color="red"></font>
                    </td>
                </tr>
                <tr style="display: none">
                    <td align="right">
                        申请援助最小金额:
                    </td>
                    <td>
                        <input id="txtTXMinMoney" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="申请援助最小金额" /><font color="red">*正整数</font>
                    </td>
                    <td align="right">
                        申请援助最大金额:
                    </td>
                    <td>
                        <input id="txtTXBaseMoney" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="申请援助最大金额" /><font color="red">*正整数</font>
                    </td>
                </tr>
                <tr style="display: none">
                    <td align="right">
                        每日取款次数:
                    </td>
                    <td>
                        <input id="txtGPrice" runat="server" class="normal_input" type="text" require-type="decimal"
                            require-msg="每日取款次数" /><font color="red">*小数</font>
                    </td>
                    <td align="right">
                        每次取款最大金额:
                    </td>
                    <td>
                        <input id="txtDFHFloat" runat="server" class="normal_input" type="text" require-type="decimal"
                            require-msg="每次取款金额" /><font color="red">*小数</font>
                    </td>
                </tr>
                <tr style="display: none">
                    <td align="right">
                        注册送币:
                    </td>
                    <td>
                        <input id="txtDFHTopMoney" runat="server" class="normal_input" type="text" require-type="decimal"
                            require-msg="商务股封顶出局" />
                    </td>
                    <td align="right">
                        动态奖金现金币拨入:
                    </td>
                    <td>
                        <input id="txtDMHBPart" runat="server" class="normal_input" type="text" require-type="decimal"
                            require-msg="动态奖金现金币拨入" /><font color="red">*小数</font>
                    </td>
                </tr>
                <tr style="display: none">
                    <td align="right">
                        注册送互助币:
                    </td>
                    <td>
                        <input id="txtDMGPPart" runat="server" class="normal_input" type="text" require-type="decimal"
                            require-msg="注册送币" /><font color="red">*小数</font>
                    </td>
                    <td align="right">
                        赠送直推人数:
                    </td>
                    <td>
                        <input id="txtJMHBPart" runat="server" class="normal_input" type="text" require-type="decimal"
                            require-msg="赠送直推" /><font color="red">*小数</font>
                    </td>
                </tr>
                <tr style="display: none">
                    <td align="right">
                        月管理费:
                    </td>
                    <td>
                        <input id="txtGLMoney" runat="server" class="normal_input" type="text" require-type="decimal"
                            require-msg="月管理费" /><font color="red">*小数</font>
                    </td>
                    <td align="right">
                        最多持股数量:
                    </td>
                    <td>
                        管理奖冻结时间：
                    </td>
                    <td>
                        <input id="txtDFHOutCount" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="管理奖冻结时间" /><font color="red">*分钟</font>
                    </td>
                </tr>
                <tr style="display: none">
                    <td align="right">
                        自动匹配开关：
                    </td>
                    <td>
                        <select id="ddlAutoDFH" runat="server">
                            <option value="1">开</option>
                            <option value="0">关</option>
                        </select>
                    </td>
                   
                </tr>
                <tr style="display: none">
                    <td>
                        复投生产时间：
                    </td>
                    <td>
                        <input id="txtMinBuyGCount" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="转账倍数" /><font color="red">*整数(天)</font>
                    </td>
                    <td>
                        复投单次发放比例：
                    </td>
                    <td>
                        <input id="txtJMGPPart" runat="server" class="normal_input" type="text" require-type="decimal"
                            require-msg="复投单次发放比例" /><font color="red">*</font>
                    </td>
                </tr>
                <tr>
                    <td>
                        是否开启注册：
                    </td>
                    <td>
                        <select id="txtCanRegedit" runat="server">
                            <option value="1">开启</option>
                            <option value="0">关闭</option>
                        </select>
                    </td>
                    <td>
                        每天注册人数：
                    </td>
                    <td>
                        <input id="txtDayRegeditNumber" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="每天注册人数" /><font color="red">*</font>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        最少转换金额:
                    </td>
                    <td>
                        <input id="txtDHMinMoney" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="最少转换金额" /><font color="red">*正整数</font>
                    </td>
                    <td align="right">
                        转换倍数:
                    </td>
                    <td>
                        <input id="txtDHBaseMoney" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="转换倍数" /><font color="red">*正整数</font>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        最少转账金额：
                    </td>
                    <td>
                        <input id="txtZZMinMoney" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="最少转账金额" /><font color="red">*正整数</font>
                    </td>
                    <td align="right">
                        转账倍数：
                    </td>
                    <td>
                        <input id="txtZZBaseMoney" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="转账倍数" /><font color="red">*正整数</font>
                    </td>
                </tr>
                <tr>
                    <td>
                        身份证注册帐号数量：
                    </td>
                    <td>
                        <input id="txtMaxBuyGCount" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="身份证注册帐号数量" /><font color="red">*</font>
                    </td>
                    <td align="right">
                        开启短信注册：
                    </td>
                    <td>
                        <select id="txtDFHXFCount" runat="server">
                            <option value="1">是</option>
                            <option value="0">否</option>
                        </select>
                    </td>
                </tr>
                <tr style="display: none">
                    <td align="right">
                        显示系统会员总量：
                    </td>
                    <td>
                        <input id="txtShowTotalNumber" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="显示系统会员总量" /><font color="red">*正整数</font>
                    </td>
                    <td align="right">
                        显示提供帮助总金额：
                    </td>
                    <td>
                        <input id="txtShowOfferTotalMoney" runat="server" class="normal_input" type="text"
                            require-type="decimal" require-msg="显示提供帮助总金额" /><font color="red">*</font>
                    </td>
                    <td align="right">
                        显示获得帮助总金额：
                    </td>
                    <td>
                        <input id="txtShowGetTotalMoney" runat="server" class="normal_input" type="text"
                            require-type="decimal" require-msg="显示获得帮助总金额" /><font color="red">*</font>
                    </td>
                </tr>
            </table>
            <div style="width: 100%;">
                <asp:GridView ID="GridView1" OnRowDataBound="GridView1_RowDataBound" runat="server"
                    AutoGenerateColumns="False" AllowSorting="True">
                    <Columns>
                        <asp:TemplateField HeaderText="等级代码">
                            <ItemTemplate>
                                <asp:TextBox Width="80%" ID="txtMAgencyType" runat="server" Text='<%#Eval("MAgencyType") %>'
                                    require-type="require" require-msg="等级代码" ReadOnly="true"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="等级名称">
                            <ItemTemplate>
                                <asp:TextBox Width="80%" ID="txtMAgencyName" runat="server" Text='<%#Eval("MAgencyName") %>'
                                    require-type="require" require-msg="代理级别" />
                            </ItemTemplate>
                        </asp:TemplateField>
                      <%--  <asp:TemplateField HeaderText="推荐人数">
                            <ItemTemplate>
                                <asp:TextBox Width="80%" ID="txtTJCount" runat="server" Text='<%#Bind("TJCount") %>'
                                    require-type="int" require-msg="推荐人数" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="团队人数">
                            <ItemTemplate>
                                <asp:TextBox Width="80%" ID="txtTemaCount" runat="server" Text='<%#Bind("TemaCount") %>'
                                    require-type="int" require-msg="团队人数" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="推荐奖比例">
                            <ItemTemplate>
                                <asp:TextBox Width="80%" ID="txtTJFloat" runat="server" Text='<%#Bind("TJFloat") %>'
                                    require-type="decimal" require-msg="推荐奖比例" />
                            </ItemTemplate>
                        </asp:TemplateField>
                      <%--  <asp:TemplateField HeaderText="奖金手续费">
                            <ItemTemplate>
                                <asp:TextBox Width="80%" ID="txtTakeOffFloat" runat="server" Text='<%#Bind("TakeOffFloat") %>'
                                    require-type="require" require-msg="奖金手续费" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <%--<asp:TemplateField HeaderText="提供帮助最小金额">
                            <ItemTemplate>
                                <asp:TextBox Width="80%" ID="txtXFMouthMinHelpMoney" runat="server" Text='<%#Bind("XFMouthMinHelpMoney") %>'
                                    require-type="decimal" require-msg="提供帮助最小金额" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="提供帮助最大金额">
                            <ItemTemplate>
                                <asp:TextBox Width="80%" ID="txtXFMounthMoney" runat="server" Text='<%#Bind("XFMounthMoney") %>'
                                    require-type="decimal" require-msg="提供帮助最大金额" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                       <%-- <asp:TemplateField HeaderText="管理奖月封顶">
                            <ItemTemplate>
                                <asp:TextBox Width="80%" ID="txtDTopMoney" runat="server" Text='<%#Bind("DTopMoney") %>'
                                    require-type="decimal" require-msg="管理奖月封顶" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                        <asp:TemplateField HeaderText="颜色代码">
                            <ItemTemplate>
                                <asp:TextBox Width="80%" ID="txtMColor" runat="server" Text='<%#Bind("MColor") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <br />
            <div>
                <asp:GridView ID="GridView2" OnRowDataBound="GridView1_RowDataBound" runat="server"
                    AutoGenerateColumns="False" AllowSorting="True">
                    <Columns>
                        <asp:TemplateField HeaderText="参数编码">
                            <ControlStyle Width="80%" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtDType" runat="server" Text='<%#Eval("DType") %>' ReadOnly="true"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="说明">
                            <ControlStyle Width="80%" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtRemark" runat="server" Text='<%#Eval("Remark") %>' ></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="最小代数">
                            <ControlStyle Width="80%" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtStartLevel" runat="server" Text='<%#Eval("StartLevel") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="最大代数">
                            <ControlStyle Width="80%" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtEndLevel" runat="server" Text='<%#Eval("EndLevel") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="提成">
                            <ControlStyle Width="80%" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtDValue" runat="server" Text='<%#Bind("DValue") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="等级代码">
                            <ControlStyle Width="80%" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtDKey" runat="server" Text='<%#Bind("DKey") %>' ReadOnly="true" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <br />
            <br />
            <div>
                <asp:GridView ID="GridView4" OnRowDataBound="GridView1_RowDataBound" runat="server"
                    AutoGenerateColumns="False" AllowSorting="True">
                    <Columns>
                        <asp:TemplateField HeaderText="参数编码">
                            <ControlStyle Width="80%" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtNDType" runat="server" Text='<%#Eval("NDTpye") %>' ReadOnly="true"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                     
                        <asp:TemplateField HeaderText="最小代数">
                            <ControlStyle Width="80%" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtNStartLevel" runat="server" Text='<%#Eval("StartLevel") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="最大代数">
                            <ControlStyle Width="80%" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtNEndLevel" runat="server" Text='<%#Eval("EndLevel") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                           <asp:TemplateField HeaderText="所需会员等级">
                            <ControlStyle Width="110px" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtNRemark" runat="server" Text='<%#Eval("Remark") %>'></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="所需会员人数起">
                            <ControlStyle Width="80%" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtNDStartRec" runat="server" Text='<%#Bind("StartRec") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="所需会员人数止">
                            <ControlStyle Width="80%" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtNDEndRec" runat="server" Text='<%#Bind("EndRec") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="升级级别">
                            <ControlStyle Width="80%" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtNDValue" runat="server" Text='<%#Bind("DValue") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="当前级别">
                            <ControlStyle Width="80%" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtDKey" runat="server" Text='<%#Bind("DKey") %>' ReadOnly="true" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <table cellpadding="0" cellspacing="0">
                <tr style="height: 50px;">
                    <td>
                        <input class="normal_btnok" id="Button1" type="button" value="确定" onclick="checkOk();" />
                    </td>
                    <td>
                        <input class="normal_btnok" id="Button2" type="button" value="初始化" onclick="checkClear();" />
                    </td>
                    <td>
                        <input class="normal_btnok" id="Button3" type="button" value="奖金清零" onclick="checkMHB('1');" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        $(function () {
            $("#__VIEWSTATE").remove();
        })
        function checkOk() {
            if (checkForm())
                ActionModel("/SysManage/Configuration.aspx?Action=modify", $('#form1').serialize());
        }

        function checkClear() {
            ActionModel("/SysManage/Configuration.aspx?Action=other", $('#form1').serialize());
        }

        function checkMHB(obj) {
            ActionModel("/SysManage/Configuration.aspx?Action=Add&Type=" + obj, $('#form1').serialize());
        }

        $(function () {
            $("#moneyTran").click(function () {
                var state = $(this).attr("checked");
                var toUrl = "/SysManage/Configuration.aspx?Action=TRANMONEY&Type=";
                if (typeof (state) != "undefined" && state == "checked")
                    toUrl += "1";
                else
                    toUrl += "2";
                ActionModel(toUrl, $('#form1').serialize());
            });

        });
 
    </script>
</body>
</html>
