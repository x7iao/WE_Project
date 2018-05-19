<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EPDMraket.aspx.cs" Inherits="WE_Project.Web.FD.EPDMraket" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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
                                    <span>大盘总量：<%=AFDTotalSellCount %></span>&nbsp;&nbsp; <span>交易总量：<%=AFDSellCount%></span>&nbsp;&nbsp;
                                    <span>成交比：<%=AFDTotalSellCount > 0 ? Math.Round(Convert.ToDecimal((decimal)AFDSellCount / AFDTotalSellCount), 2) * 100 : 0%>%</span>
                                </td>
                            </tr>
                            <tr>
                                <td width="40%" align="right">
                                    <span>会员账号:</span>
                                </td>
                                <td>
                                    <%=TModel.MID %>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>我的富达币:</span>
                                </td>
                                <td>
                                    <%=MyFDCount %>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>富达币价格:</span>
                                </td>
                                <td>
                                    <%=WE_Project.BLL.FDConfig.FDConfigModel["D"].FDPrice %>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>我的FD币:</span>
                                </td>
                                <td>
                                    <%=TModel.MConfig.MGP %>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>大盘交易时间:</span>
                                </td>
                                <td>
                                    <%=WE_Project.BLL.FDConfig.FDConfigModel["D"].FDStartTime.ToString("HH:mm") + "~" + WE_Project.BLL.FDConfig.FDConfigModel["D"].FDEndTime.ToString("HH:mm")%>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <span>大盘交易状态:</span>
                                </td>
                                <td>
                                    <%=WE_Project.BLL.FDConfig.FDConfigModel["D"].ISOpen ? "正常交易" : ("停止交易：" + WE_Project.BLL.FDConfig.FDConfigModel["D"].FDCloseRemark)%>
                                </td>
                            </tr>
                            <tr>
                                <%if (TModel.RoleCode == "Notactive")
                                  {
                                %>
                                <td>
                                </td>
                                <td>
                                    <span style="color: Red;">体验会员不允许进行富达币交易，请先升级后再购买</span>
                                </td>
                                <%}
                                  else
                                  { 
                                %>
                                <td align="right">
                                    本次交易数量：<input id="txtJYCount" runat="server" style="width: 80px;" class="normal_input"
                                        type="text" maxlength="6" />
                                </td>
                                <td>
                                    <input id="Button1" class="btn btn-success" type="button" runat="server" value="确定买入"
                                        onclick="checkChange();" />
                                </td>
                                <%
                                  }
                                %>
                            </tr>
                        </table>
                        </form>
                    </div>
                    <div class="col-sm-6">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h3 class="panel-title">
                                    最近一周D盘交易情况</h3>
                            </div>
                            <div class="panel-body">
                                <div id="bar-1" style="height: 200px; width: 100%;">
                                </div>
                                <br />
                                <a href="#" id="bar-1-randomize" class="btn btn-primary btn-small">Refresh</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-sm-6">
                        <div class="alert alert-danger" style="margin-bottom: 0px;">
                            <strong>最近50位D盘销售记录</strong></div>
                        <table cellpadding="0" cellspacing="0" class="tabcolor" style="margin-bottom: 0px">
                            <tr>
                                <th style="width: 10%">
                                    序号
                                </th>
                                <th style="width: 20%">
                                    会员账号
                                </th>
                                <th style="width: 20%">
                                    销售数量
                                </th>
                                <th style="width: 20%">
                                    销售金额
                                </th>
                                <th style="width: 30%">
                                    销售日期
                                </th>
                            </tr>
                        </table>
                        <marquee class="marquee" scrollamount="5" direction="up">
                        <table cellpadding="0" cellspacing="0" class="tabcolor">
                        <%int i = 1; foreach (WE_Project.Model.FDSellList item in WE_Project.BLL.FDSellList.GetList(50, "SellState<3 and SellMID<>'admin' and SellFDName='D' order by LastSellDate"))
                          { %>
                            <tr>
                                <td style="width: 10%">
                                    <%=i++ %>
                                </td>
                                <td style="width: 20%">
                                    <%=item.SellMID %>
                                </td>
                                <td style="width: 20%">
                                    <%=item.SellCount %>
                                </td>
                                <td style="width: 20%">
                                    <%=item.SellMoney %>
                                </td>
                                <td style="width: 30%">
                                    <%=item.LastSellDate.ToString("yyyy-MM-dd HH:mm") %>
                                </td>
                            </tr><%} %>
                            </table>
                        </marquee>
                    </div>
                    <div class="col-sm-6">
                        <div class="alert alert-danger" style="margin-bottom: 0px;">
                            <strong>最近50位D盘购买记录</strong></div>
                        <table cellpadding="0" cellspacing="0" class="tabcolor" style="margin-bottom: 0px">
                            <tr>
                                <th style="width: 10%">
                                    序号
                                </th>
                                <th style="width: 20%">
                                    会员账号
                                </th>
                                <th style="width: 20%">
                                    买入数量
                                </th>
                                <th style="width: 20%">
                                    买入金额
                                </th>
                                <th style="width: 30%">
                                    买入日期
                                </th>
                            </tr>
                        </table>
                        <marquee class="marquee" scrollamount="5" direction="up">
                        <table cellpadding="0" cellspacing="0" class="tabcolor">
                            <%int k = 1; foreach (WE_Project.Model.FDBuyList item in WE_Project.BLL.FDBuyList.GetList(50, "BuyState=0 and BuyMID<>'admin' and BuyFDName='D' order by BuyDate"))
                              { %>
                            <tr>
                                <td style="width: 10%">
                                    <%=k++ %>
                                </td>
                                <td style="width: 20%">
                                    <%=item.BuyMID %>
                                </td>
                                <td style="width: 20%">
                                    <%=item.BuyCount %>
                                </td>
                                <td style="width: 20%">
                                    <%=item.BuyMoney %>
                                </td>
                                <td style="width: 30%">
                                    <%=item.BuyDate.ToString("yyyy-MM-dd HH:mm") %>
                                </td>
                            </tr><%} %></table>
                        </marquee>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            ActionModel("/FD/EPDMraket.aspx?Action=Add", $('#form1').serialize(), "FD/EPDMraket.aspx");
        }
    </script>
    <script src="/FD/js/globalize.min.js"></script>
    <script src="/FD/js/dx.chartjs.js"></script>
    <script type="text/javascript">

        function getchart() {
            $.ajax({
                type: "POST",
                url: "/FD/Handler/chartMorris.ashx?type=week&fd=D",
                success: function (data) {
                    if (data != "非法操作") {
                        var dataJson = eval("(" + data + ")");
                        $("#bar-1").dxChart({
                            dataSource: dataJson,

                            series: {
                                argumentField: "day",
                                valueField: "sales",
                                name: "D盘",
                                type: "bar",
                                color: '#f7aa47'
                            }
                        });
                    }
                }
            });
        }
        getchart();

        $("#bar-1-randomize").on('click', function (ev) {
            ev.preventDefault();

            getchart();
        });
    </script>
</body>
</html>
