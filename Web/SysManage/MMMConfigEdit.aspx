<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MMMConfigEdit.aspx.cs"
    Inherits="WE_Project.Web.SysManage.MMMConfigEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <style type="text/css">
        
    </style>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td align="right">
                        汇率:
                    </td>
                    <td>
                        <input id="txtReleasePer" runat="server" class="normal_input" type="text" require-type="decimal"
                            require-msg="汇率" /><font color="red">*</font>
                    </td>
                     <td align="right">
                        预付款匹配比例:
                    </td>
                    <td>
                        <input id="txtNoLineTimesMoneyFloat" runat="server" class="normal_input" type="text"
                            require-type="decimal" require-msg="预付款匹配比例" /><font color="red">*</font>
                    </td>
                </tr>
                  <tr>
                    <td align="right">
                        买入许愿果支付定金比例[手续费]:
                    </td>
                    <td>
                        <input id="txtOfferTJKF" runat="server" class="normal_input" type="text" require-type="decimal"
                            require-msg="买入许愿果支付定金比例[手续费]" /><font color="red">*</font>
                    </td>
                      <td align="right">
                        首单支付预付款赠送推荐人忠诚点数:
                    </td>
                    <td>
                        <input id="txtHonestTimes" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="首单支付预付款赠送推荐人忠诚点数" /><font color="red">*整数</font>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        买入许愿果最小金额:
                    </td>
                    <td>
                        <input id="txtOfferHelpMin" runat="server" class="normal_input" type="text" require-type="decimal"
                            require-msg="买入许愿果最小金额" /><font color="red">*</font>
                    </td>
                    <td align="right">
                        卖出许愿果最小金额:
                    </td>
                    <td>
                        <input id="txtGetHelpMin" runat="server" class="normal_input" type="text" require-type="decimal"
                            require-msg="卖出许愿果最小金额" /><font color="red">*</font>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        买入许愿果最大金额:
                    </td>
                    <td>
                        <input id="txtOfferHelpMax" runat="server" class="normal_input" type="text" require-type="decimal"
                            require-msg="买入许愿果最大金额" /><font color="red">*</font>
                    </td>
                    <td align="right">
                        卖出许愿果最大金额:
                    </td>
                    <td>
                        <input id="txtGetHelpMax" runat="server" class="normal_input" type="text" require-type="decimal"
                            require-msg="卖出许愿果最大金额" /><font color="red">*</font>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        买入许愿果倍数:
                    </td>
                    <td>
                        <input id="txtOfferHelpBase" runat="server" class="normal_input" type="text" require-type="decimal"
                            require-msg="买入许愿果倍数" /><font color="red">*整数</font>
                    </td>
                    <td align="right">
                        卖出许愿果倍数:
                    </td>
                    <td>
                        <input id="txtGetHelpBase" runat="server" class="normal_input" type="text" require-type="decimal"
                            require-msg="卖出许愿果倍数" /><font color="red">*整数</font>
                    </td>
                </tr>
                <tr >
                    <td align="right">
                        许愿池提现额度比例【不超本身钱包倍数】:
                    </td>
                    <td>
                        <input id="txtOfferHelpDayTotalMoney" runat="server" class="normal_input" type="text"
                            require-type="decimal" require-msg="许愿池提现额度比例" /><font color="red">*</font>
                    </td>
                    <td align="right">
                        许愿池提现倍数:
                    </td>
                    <td>
                        <input id="txtGetHelpDayTotalMoney" runat="server" class="normal_input" type="text"
                            require-type="decimal" require-msg="许愿池提现倍数" /><font color="red">*</font>
                    </td>
                </tr>
                <tr style="display:none;">
                    <td align="right">
                        买入许愿果排单限制时间跨度:
                    </td>
                    <td>
                        <input id="txtOfferHelpRangeTimes" runat="server" class="normal_input" type="text"
                            require-type="int" require-msg="买入许愿果排单限制时间跨度" /><font color="red">*整数(分钟)</font>
                    </td>
                    <td align="right">
                        卖出许愿果排单限制时间跨度:
                    </td>
                    <td>
                        <input id="txtGetHelpRangeTimes" runat="server" class="normal_input" type="text"
                            require-type="int" require-msg="卖出许愿果排单限制时间跨度" /><font color="red">*整数(分钟)</font>
                    </td>
                </tr>
                <tr  style="display:none;">
                    <td align="right">
                        买入许愿果时间限制内最多排单数:
                    </td>
                    <td>
                        <input id="txtOfferHelpRangeCount" runat="server" class="normal_input" type="text"
                            require-type="int" require-msg="买入许愿果时间限制内最多排单数" /><font color="red">*整数</font>
                    </td>
                    <td align="right">
                        卖出许愿果时间限制内最多排单数:
                    </td>
                    <td>
                        <input id="txtGetHelpRangeCount" runat="server" class="normal_input" type="text"
                            require-type="int" require-msg="卖出许愿果时间限制内最多排单数" /><font color="red">*整数</font>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        买入许愿果时间范围:
                    </td>
                    <td>
                        <input id="txtOfferHelpTimes" runat="server" class="normal_input" type="text" require-type="require"
                            require-msg="买入许愿果时间范围" /><font color="red">*(00:00-23:59)</font>
                    </td>
                    <td align="right">
                        卖出许愿果时间范围:
                    </td>
                    <td>
                        <input id="txtGetHelpTimes" runat="server" class="normal_input" type="text" require-type="require"
                            require-msg="卖出许愿果时间范围" /><font color="red">*(00:00-23:59)</font>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        买入许愿果开关:
                    </td>
                    <td>
                        <select id="txtOfferHelpSwitch" runat="server">
                            <option value="1">开启</option>
                            <option value="0">关闭</option>
                        </select>
                    </td>
                    <td align="right">
                        卖出许愿果开关:
                    </td>
                    <td>
                        <select id="txtGetHelpSwitch" runat="server">
                            <option value="1">开启</option>
                            <option value="0">关闭</option>
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        利息比例:
                    </td>
                    <td>
                        <input id="txtInterestPer" runat="server" class="normal_input" type="text" require-type="decimal"
                            require-msg="利息比例" /><font color="red">*</font>
                    </td>
                    <td align="right">
                      忠诚度为0时利息比例:
                    </td>
                    <td>
                        <input id="txtMCWPrice" runat="server" class="normal_input" type="text" require-type="decimal"
                            require-msg="忠诚度为0时利息比例" /><font color="red">*</font>
                    </td>
                   
                </tr>
                <tr style=" display:none;">
                    <td align="right" style="display: none">
                        买入许愿果不小于上一单的比例:
                    </td>
                    <td style="display: none">
                        <input id="txtLastProportion" runat="server" class="normal_input" type="text" require-type="decimal"
                            require-msg="买入许愿果不小于上一单的比例" /><font color="red">*</font>
                    </td>
                    <td align="right">
                        激活码价格:
                    </td>
                    <td>
                        <input id="txtActiveCodePrice" runat="server" class="normal_input" type="text" require-type="decimal"
                            require-msg="激活码价格" /><font color="red">*</font>
                    </td>
                    
                </tr>
                <tr>
                    <td align="right">
                        冻结期:
                    </td>
                    <td>
                        <input id="txtFreezeTimes" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="冻结期" /><font color="red">*整数(分钟)</font>
                    </td>
                     

                    <td align="right" >
                        收益期:
                    </td>
                    <td>
                        <input id="txtOutTimes" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="收益期" /><font color="red">*整数(分钟)</font>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        打款时间:
                    </td>
                    <td>
                        <input id="txtPayLimitTimes" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="打款时间" /><font color="red">*整数(分钟)</font>
                    </td>
                    <td align="right">
                        收款时间:
                    </td>
                    <td>
                        <input id="txtConfirmLimitTimes" runat="server" class="normal_input" type="text"
                            require-type="int" require-msg="收款时间" /><font color="red">*整数(分钟)</font>
                    </td>
                </tr>
                <tr>
                  <td align="right">
                        买入许愿果排队期:
                    </td>
                    <td>
                        <input id="txtLineTimes" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="排队期" /><font color="red">*整数(分钟)</font>
                    </td>

                    <td align="right">
                        卖出许愿果排队期:
                    </td>
                    <td>
                        <input id="txtFreezeTimesOfOffer" runat="server" class="normal_input" type="text"
                            require-type="int" require-msg="卖出许愿果排队期" /><font color="red">*分钟</font>
                    </td>
                </tr>
                <tr>
                     <td align="right">
                        每天排单总金额:
                    </td>
                    <td>
                        <input id="txtMOfferNeedMCW" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="每天排单总金额" /><font color="red">*</font>
                    </td>

                   
                    
                </tr>
                <tr>
                    <td align="right">
                        自动匹配开关:
                    </td>
                    <td>
                        <select id="txtMacthSwitch" runat="server">
                            <option value="1">开启</option>
                            <option value="0">关闭</option>
                        </select>
                    </td>
                    <td align="right">
                        匹配时间范围:
                    </td>
                    <td>
                        <input id="txtMacthTimesRange" runat="server" class="normal_input" type="text" require-type="require"
                            require-msg="匹配时间范围" /><font color="red">*(00:00-23:59)</font>
                    </td>
                </tr>

                <tr>
                     <td align="right">
                        激活不排单冻结[分钟]:
                    </td>
                    <td>
                        <input id="txtFreezeTimesOfRegister" runat="server" class="normal_input" type="text"
                            require-type="int" require-msg="激活不排单冻结[分钟]" /><font color="red">*分钟</font>
                    </td>
                    <td align="right">
                        注册N天内不参加抢单:
                    </td>
                    <td>
                        <input id="txtMHBBase" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="注册N天内不参加抢单" /><font color="red">*整数(分钟)</font>
                    </td>
                </tr>
                <tr style="display:none;">
                   <td align="right">
                        动态奖金提现额度比例:
                    </td>
                    <td>
                        <input id="txtGetHelpFloat" runat="server" class="normal_input" type="text" require-type="decimal"
                            require-msg="动态奖金提现额度比例" /><font color="red">*</font>
                    </td>
                    <td align="right">
                        抢单区买入许愿果排单期:
                    </td>
                    <td>
                        <input id="txtMHBRangeTimes" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="抢单区买入许愿果排单期" /><font color="red">*整数(分钟)</font>
                    </td>
                </tr>

              
                <tr>
                     <td align="right">
                        强制排单最小时间【两单间隔时间】:
                    </td>
                    <td>
                        <input id="txtGLRewardFreezeTimes" runat="server" class="normal_input" type="text"
                            require-type="int" require-msg="强制排单最小时间【两单间隔时间】" /><font color="red">*整数(分钟)</font>
                    </td>
                    <td align="right">
                        强制排单最大时间【超出冻结】:
                    </td>
                    <td>
                        <input id="txtReleaseConditionCount" runat="server" class="normal_input" type="text"
                            require-type="int" require-msg="强制排单最大时间【超出冻结】" /><font color="red">*整数(分钟)</font>
                    </td>
                </tr>
                <%--<tr>
                    <td align="right">
                        打款前利息:
                    </td>
                    <td>
                        <input id="txtLiXi1" runat="server" class="normal_input" type="text" require-type="decimal"
                            require-msg="打款时间" /><font color="red">*</font>
                    </td>
                    <td align="right">
                        打款后利息:
                    </td>
                    <td>
                        <input id="txtLiXi2" runat="server" class="normal_input" type="text" require-type="decimal"
                            require-msg="收款时间" /><font color="red">*</font>
                    </td>
                </tr>--%>
                <tr>
                    <td align="right">
                        不打款扣除推荐人许愿果:
                    </td>
                    <td>
                        <input id="txtLiXi1" runat="server" class="normal_input" type="text" require-type="decimal"
                            require-msg="不打款扣除推荐人许愿果" /><font color="red">*</font>
                    </td>
                   <td align="right">
                        日抢单额度:
                    </td>
                    <td>
                        <input id="txtGetTJKF" runat="server" class="normal_input" type="text" require-type="decimal"
                            require-msg="日抢单额度" /><font color="red">*</font>
                    </td>
                </tr>
             
                <tr style="display: none">
                     <td align="right">
                        奖金烧伤比例:
                    </td>
                    <td>
                        <input id="txtLiXi2" runat="server" class="normal_input" type="text" require-type="decimal"
                            require-msg="奖金烧伤比例" /><font color="red">*</font>
                    </td>

                    
                </tr>
                <tr style="display: none">
                  
                    <td align="right">
                        诚信奖比例:
                    </td>
                    <td>
                        <input id="txtHonestFloat" runat="server" class="normal_input" type="text" require-type="decimal"
                            require-msg="诚信奖比例" /><font color="red">*</font>
                    </td>
                </tr>
                <tr style="display: none">
                    <td align="right">
                        预付款打款时间:
                    </td>
                    <td>
                        <input id="txtPayLimitTimesPre" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="预付款打款时间" /><font color="red">*整数(分钟)</font>
                    </td>
                    <td align="right">
                        预付款收款时间:
                    </td>
                    <td>
                        <input id="txtConfirmLimitTimesPre" runat="server" class="normal_input" type="text"
                            require-type="int" require-msg="预付款收款时间" /><font color="red">*整数(分钟)</font>
                    </td>
                </tr>
                <%--<tr style="display: none">
                    <td align="right">
                        互助钱包提现倍数:
                    </td>
                    <td>
                        <input id="txtMHBBase" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="互助钱包提现倍数" /><font color="red">*(整数)</font>
                    </td>
                    <td align="right">
                        互助钱包提现间隔:
                    </td>
                    <td>
                        <input id="txtMHBRangeTimes" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="互助钱包提现间隔" /><font color="red">*(整数)</font>
                    </td>
                </tr>
                <tr style="display: none">
                    <td align="right">
                        回馈钱包提现倍数:
                    </td>
                    <td>
                        <input id="txtMCWBase" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="回馈钱包提现倍数" /><font color="red">*(整数)</font>
                    </td>
                    <td align="right">
                        回馈钱包提现间隔:
                    </td>
                    <td>
                        <input id="txtMCWRangeTimes" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="回馈钱包提现间隔" /><font color="red">*(整数)</font>
                    </td>
                </tr>
                <tr style="display: none">
                    <td align="right">
                        爱心钱包提现倍数:
                    </td>
                    <td>
                        <input id="txtMJBBase" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="爱心钱包提现倍数" /><font color="red">*(整数)</font>
                    </td>
                    <td align="right">
                        爱心钱包提现间隔:
                    </td>
                    <td>
                        <input id="txtMJBRangeTimes" runat="server" class="normal_input" type="text" require-type="int"
                            require-msg="爱心钱包提现间隔" /><font color="red">*(整数)</font>
                    </td>
                </tr>--%>
                <tr style="display: none">
                    
                  
                </tr>
            </table>
            <table cellpadding="0" cellspacing="0">
                <tr style="height: 50px;">
                    <td>
                    </td>
                    <td>
                        <input class="normal_btnok" id="Button1" type="button" value="确定" onclick="checkOk();" />&emsp;
                        <input class="normal_btnok" id="Button2" type="button" value="初始化" onclick="checkClear();" />
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
            //if (checkForm()) {

            ActionModel("/SysManage/MMMConfigEdit.aspx?Action=modify", $('#form1').serialize());
            //}
        }

        function checkClear() {
            ActionModel("/SysManage/MMMConfigEdit.aspx?Action=other", $('#form1').serialize());
        }
         
    </script>
</body>
</html>
