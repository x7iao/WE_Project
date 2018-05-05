<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayHB.aspx.cs" Inherits="WE_Project.Web.ChangeMoney.PayHB" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        #finance table tr
        {
            vertical-align: middle;
            text-align: center;
            height: 50px;
        }
        #finance table tr td
        {
            padding: 0px;
            vertical-align: middle;
        }
    </style>
    <script type="text/javascript">
        function checkJe() {
            if ($('#txtValidMoney').val().Trim() == "") {
                v5.error('购买激活码数量不能为空', '1', 'true');
                return false;
            } else if (!$('#txtValidMoney').val().TryInt()) {
                v5.error('购买激活码数量错误', '1', 'true');
                return false;
            } else {
                return true;
            }
        }
    </script>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1" method="post" target="_search" onsubmit="return checkJe();" action="Payment/MoBao/Payment.aspx">
            <span class="remak" style="font-size: 18px;">温馨提示：请在新打开的页面中完成支付，请输入购买激活码数量，未激活账号会自动扣除一个激活码
                。<br />
                一个激活码是60元。</span>
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td style="text-align: right; font-size: 24px;">
                        购买激活码数量：
                    </td>
                    <td colspan="3" style="padding-left: 20px;">
                        <input id="txtValidMoney" runat="server" class="normal_input" type="text" value="" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <input name="yh" type="radio" value="CCB">
                        <img src="/Payment/banks/jianshe.gif">
                    </td>
                    <td>
                        <input name="yh" type="radio" value="ABC">
                        <img src="/Payment/banks/nongye.gif">
                    </td>
                    <td>
                        <input name="yh" type="radio" value="ICBC" checked="checked">
                        <img src="/Payment/banks/gongshang.gif">
                    </td>
                    <td>
                        <input name="yh" type="radio" value="CMB">
                        <img src="/Payment/banks/zhaohang.gif">
                    </td>
                </tr>
                <tr>
                    <td>
                        <input name="yh" type="radio" value="COMM">
                        <img src="/Payment/banks/jiaotong.gif">
                    </td>
                    <td>
                        <input name="yh" type="radio" value="PSBC">
                        <img src="/Payment/banks/youzheng.gif">
                    </td>
                    <td>
                        <input name="yh" type="radio" value="BOC">
                        <img src="/Payment/banks/zhongguo.gif">
                    </td>
                    <td>
                        <input name="yh" type="radio" value="CEB">
                        <img src="/Payment/banks/guangda.gif">
                    </td>
                </tr>
                <tr>
                    <td>
                        <input name="yh" type="radio" value="CNCB">
                        <img src="/Payment/banks/zhongxin.gif">
                    </td>
                    <td>
                        <input name="yh" type="radio" value="CGB">
                        <img src="/Payment/banks/guangfa.gif">
                    </td>
                    <td>
                        <input name="yh" type="radio" value="SPDB">
                        <img src="/Payment/banks/shangpufa.gif">
                    </td>
                    <td>
                        <input name="yh" type="radio" value="PAB">
                        <img src="/Payment/banks/pingan.gif">
                    </td>
                </tr>
                <tr>
                    <td>
                        <input name="yh" type="radio" value="HXB">
                        <img src="/Payment/banks/huaxia.gif">
                    </td>
                    <td>
                        <input name="yh" type="radio" value="CIB">
                        <img src="/Payment/banks/cib.gif">
                    </td>
                    <td>
                        <input name="yh" type="radio" value="CMBC">
                        <img src="/Payment/banks/minsheng.gif">
                    </td>
                    <td>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center" style="padding-left: 20px;">
                        <input type="submit" name="Submit" value="确定" id="Submit2" class="normal_btnok" />
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
</body>
</html>
