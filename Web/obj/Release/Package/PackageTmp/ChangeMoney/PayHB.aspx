<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayHB.aspx.cs" Inherits="WE_Project.Web.ChangeMoney.PayHB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        #finance table tr {
            vertical-align: middle;
            text-align: center;
            height: 50px;
        }

            #finance table tr td {
                padding: 0px;
                vertical-align: middle;
            }

        .bank table tr td img {
            width: 154px;
        }

        .recharge {
            background: #FD6F0D;
            background: rgba(253, 111, 13, 0.35);
            padding: 20px 0px;
            color: white;
            font-size: 24px;
            text-align: center;
            margin: 20px 0px;
        }

            .recharge b {
                margin: 0px 20px;
            }

        .sel {
            display: inline-block;
        }
    </style>
    <script type="text/javascript">
        $(function () {
            $(":radio").click(function () {
                if ($(this).val() == '4') {
                    callhtml('ChangeMoney/HKChangeFlow.aspx', '银行汇款');
                }
            });
        });

        function checkJe() {
            if ($('#txtValidMoney').val().Trim() == "") {
                v5.error('充值金额不能为空', '1', 'true');
                return false;
            } else {
                return true;
            }
        }

        function Redirect() {
            if ($('#txtValidMoney').val().Trim() == "") {
                v5.error('充值金额不能为空', '1', 'true');
            } else {
                var ss = $("input:radio:checked").val();

                document.forms[0].action = "Payment/KaiLT/post.aspx";

                document.forms[0].submit();
            }
        }
    </script>
</head>

<body>
    <div id="mempay">
        <div id="finance" class="bank">
            <%--<input type="hidden" id="bankauto"  runat="server" />--%>
            <form id="form1" method="get" target="_blank" action="Payment/KaiLT/post.aspx">
                <input type="hidden" id="tmid" name="tmid" runat="server" />
                <span class="remak">温馨提示：请在新打开的页面中完成支付</span>
                <div class="recharge">
                    <b>请选择支付方式</b>

                </div>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td style="text-align: right; font-size: 24px;">
                            <span style="font-size: 2rem;">充值类型：</span>
                        </td>
                        <td colspan="3" style="padding-left: 20px; text-align: left;">
                            <input type="radio" value="yh" name="paytype" checked="checked">网银支付
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right; font-size: 24px;">
                            <span style="font-size: 2rem;">充值金额：</span>
                        </td>
                        <td colspan="3" style="padding-left: 20px; text-align: left;">
                            <input id="txtValidMoney" name="txtValidMoney" class="normal_input" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input name="yh" type="radio" value="ccb">
                            <img src="../Payment/banks/jianshe.gif">
                        </td>
                        <td>
                            <input name="yh" type="radio" value="abc">
                            <img src="../Payment/banks/nongye.gif">
                        </td>
                        <td>
                            <input name="yh" type="radio" value="icbc" checked="checked">
                            <img src="../Payment/banks/gongshang.gif">
                        </td>
                        <td>
                            <input name="yh" type="radio" value="cmb">
                            <img src="../Payment/banks/zhaohang.gif">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input name="yh" type="radio" value="comm">
                            <img src="../Payment/banks/jiaotong.gif">
                        </td>
                        <td>
                            <input name="yh" type="radio" value="psbc">
                            <img src="../Payment/banks/youzheng.gif">
                        </td>
                        <td>
                            <input name="yh" type="radio" value="boc">
                            <img src="../Payment/banks/zhongguo.gif">
                        </td>
                        <td>
                            <input name="yh" type="radio" value="ceb">
                            <img src="../Payment/banks/guangda.gif">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input name="yh" type="radio" value="citic">
                            <img src="../Payment/banks/zhongxin.gif">
                        </td>
                        <td>
                            <input name="yh" type="radio" value="cgb">
                            <img src="../Payment/banks/guangfa.gif">
                        </td>
                        <td>
                            <input name="yh" type="radio" value="spdb">
                            <img src="../Payment/banks/shangpufa.gif">
                        </td>
                        <td>
                            <input name="yh" type="radio" value="bob">
                            <img src="../Payment/banks/beijing.gif">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <input name="yh" type="radio" value="hxb">
                            <img src="../Payment/banks/huaxia.gif">
                        </td>
                        <td>
                            <input name="yh" type="radio" value="cib">
                            <img src="../Payment/banks/cib.gif">
                        </td>
                        <td>
                            <input name="yh" type="radio" value="cmbc">
                            <img src="../Payment/banks/minsheng.gif">
                        </td>
                        <td>
                            <input name="yh" type="radio" value="pingan">
                            <img src="../Payment/banks/pingan.gif">
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                        <td colspan="3" align="center" style="padding-left: 20px; text-align: left;">
                            <input type="button" name="Submit" value="确定" id="Submit2" class="normal_btnok" onclick="Redirect()" />
                        </td>
                    </tr>
                </table>
            </form>
        </div>
    </div>
</body>
</html>

