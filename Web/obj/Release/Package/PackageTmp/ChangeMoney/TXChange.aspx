<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TXChange.aspx.cs" Inherits="WE_Project.Web.ChangeMoney.TXChange"
    EnableEventValidation="false" %>

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
                    <td width="15%" align="right">
                        <span>会员ID：</span>
                    </td>
                    <td width="35%">
                        <b id="bMID">
                            <%=TModel.MID %></b>
                    </td>
                </tr>
                <tr>
                    <td width="15%" align="right">
                        <span>会员昵称：</span>
                    </td>
                    <td width="35%">
                        <%=TModel.MName %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>可提现FC互助币：</span>
                    </td>
                    <td class="tdAvalibleMoney">
                        <%=TModel.MConfig.MJB %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>提现金额：</span>
                    </td>
                    <td>
                        <input name="txtMHB" id="txtMHB" maxlength="6" class="normal_input" type="text" onchange="setReceiveMoney()" />
                       <span  style=" color:Red; display:none"> 1= <%=Math.Round(WE_Project.BLL.Configuration.Model.OutFloat, 1)%>&emsp; 手续费
                        <%=Math.Round(TModel.MAgencyType.TXFloat * 100,0)%>%</span>
                    </td>
                </tr>
                <tr style=" display:none">
                    <td align="right">
                        <span>到账金额：</span>
                    </td>
                    <td class="tdAvalibleMoney" id="receiveMoney">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>开户银行：</span>
                    </td>
                    <td>
                        <%=GetBankModel(TModel.MID) != null ? GetBankModel(TModel.MID).BankInfo.Name : "<span style='color:red'>请先设置提现银行卡</span>"%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>开户姓名：</span>
                    </td>
                    <td>
                        <%=TModel.BankCardName %>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>开户支行：</span>
                    </td>
                    <td>
                        <%=TModel.Branch%>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>银行卡号：</span>
                    </td>
                    <td>
                        <b id="bcardNum">
                            <%=TModel.BankNumber %></b>
                    </td>
                </tr>
                <tr  style="display: none">
                    <td align="right">
                        <span>验证身份证号：</span>
                    </td>
                    <td>
                        <input name="txtNumID" id="txtNumID" class="normal_input" type="text" />
                    </td>
                </tr>
              <%--  <tr>
                    <td align="right">
                    </td>
                    <td>
                        验证密保问题
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        密保问题:
                    </td>
                    <td>
                        <select id="ddl_PwdQuestion" width="175px" runat="server">
                        </select>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        密保问题答案:
                    </td>
                    <td>
                        <input type="hidden" runat="server" id="hidQuesId" />
                        <input id="pwdAnswer" class="normal_input" runat="server" type="text" /><font color="red">*</font>
                    </td>
                </tr>--%>
                <tr>
                    <td>
                        <input name="重置" type="reset" class="pay_reset" value="重置" style="display: none;" />
                    </td>
                    <td>
                        <input class="normal_btnok" id="Button1" type="button" runat="server" value="提交"
                            onclick="checkChange();" />
                        <div id="divTips" runat="server" style="color: Red">
                            您的账号暂不能提现，请联系管理员！</div>
                    </td>
                </tr>
            </table>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function setReceiveMoney() { 

           var mhb=$("#txtMHB").val();
            var outFloat=<%=WE_Project.BLL.Configuration.Model.OutFloat %>;
            var shouxu=mhb*outFloat*<%=TModel.MAgencyType.TXFloat %>;
         
//            $("#receiveMoney").html((mhb*outFloat-shouxu)+"&emsp;手续费"+shouxu);
              $("#receiveMoney").html((mhb*outFloat-shouxu));
        }
        function checkChange() {
            if ($('#txtMHB').val().Trim() == "") {
                v5.error('提现金额不能为空', '1', 'true');
            } else if (!$('#txtMHB').val().TryInt()) {
                v5.error('提现金额应该为整数', '1', 'true');
            } else if ($('#bcardNum').html().Trim() == "") {
                v5.error('请先在[信息管理]－[银行卡管理]中添加提现银行卡', '1', 'true');
            }
//            else if ($('#pwdAnswer').val().Trim() == '') {
//                v5.error('密保问题不能为空', '1', 'true');
//            }
             else  
            {
                 var avalibleMoney=$(".tdAvalibleMoney").text().Trim().TryFloat();
                 var txMoney = $('#txtMHB').val().Trim().TryInt();
                 if (parseFloat($('#txtMHB').val().Trim()) > parseFloat($(".tdAvalibleMoney").text().Trim()))
                 {
                       v5.error('可用奖金不足', '1', 'true');
                 }
                 else {
                       ActionModel("/ChangeMoney/TXChange.aspx?Action=Add", $('#form1').serialize());
                   }
            } 
            
        }
    </script>
</body>
</html>
