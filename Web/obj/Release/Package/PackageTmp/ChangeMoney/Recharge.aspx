<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recharge.aspx.cs" Inherits="WE_Project.Web.ChangeMoney.Recharge" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
      <script type="text/javascript">
          tUrl = "/Handler/ReChargeList.ashx";
          tState = "<%=hktypeflag %>";
          SearchByCondition();
          $(function () {
              if (tState == "1") {
                  //财付通充值
                  $("#chargeName").html("fdasia@188.com&emsp;收款姓名：邹方俊。");
              }
              else if (tState == "2") {
                  //支付宝充值
                  $("#chargeName").html("fdasia@188.com&emsp;收款姓名：邹方俊。");
              }
              else if (tState == "3") {
                  //网银充值
                  $("#chargeName").html("6236681480002673741;&emsp;收款姓名：邹方俊。&emsp;收款银行：中国建设银行");
              }
          })
        
    </script>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <table cellpadding="0" cellspacing="0">
              <tr>
                    <td width="35%" align="left" colspan="2">
                        <span id="spTitle" runat="server">财付通充值</span>
                        <input type="hidden" id="hkType" runat="server" />
                    </td>
                     
                </tr>
                <tr>
                    <td width="35%" align="right">
                 公司<span  id="spReceiveName" runat="server">财付通</span>收款账号 
                    </td>
                    <td>
                   <span id="chargeName" runat="server"></span>
                    </td>
                </tr>
                 <tr>
                    <td width="35%" align="right">
              
                    </td>
                    <td>
                     充值成功后，公司审核后，您的电子币数量才会增加
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>汇出<span  id="spReceiveName2" runat="server">财付通</span>账号:</span>
                    </td>
                    <td>
                        <input name="txtFrom" id="txtFrom" class="normal_input" type="text" maxlength="20" />
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span>充值金额：</span>
                    </td>
                    <td>
                         <input name="txtMoney" id="txtMoney" class="normal_input" type="text" maxlength="20" />
                    </td>
                </tr>

                  <tr>
                    <td align="right">
                        <span>汇出<span   id="spReceiveName3" runat="server">财付通</span>姓名:</span>
                    </td>
                    <td>
                        <input name="txtFromName" id="txtFromName" class="normal_input" type="text" maxlength="20" />
                    </td>
                </tr>
                  <tr>
                    <td align="right">
                        <span>汇款时间:</span>
                    </td>
                    <td>
                        <input name="txtTime" id="txtTime" class="normal_input" type="text" maxlength="20"  onfocus="WdatePicker()" />
                    </td>
                </tr>

                   <tr>
                    <td align="right">
                        <span>充值留言:</span><br />
                        (请备注您的会员账号)
                    </td>
                    <td>
                        <input name="txtRemark" id="txtRemark" class="normal_input" type="text"  />
                    </td>
                </tr>

                <tr>
                    <td>
                    </td>
                    <td>
                        <input class="btn btn-success" id="btnOK" type="button" runat="server" value="提交"  onclick="checkChange();" />
                    </td>
                </tr>
            </table>
               <div class="ui_table">
            <table cellpadding="0" cellspacing="0" id="Result" class="tabcolor">
                <tr>
                    <th width="80px">
                        全选
                    </th>
                    <th>
                        序号
                    </th>
                    <th>
                        汇出账号
                    </th>
                    <th>
                        充值金额
                    </th>
                    <th>
                        汇出姓名
                    </th>
                    <th>
                        留言内容
                    </th>
                    <th>
                      汇款时间
                    </th>
                      <th>
                       状态
                    </th>
                    <th>
                       审核时间
                    </th>
                   
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                  
                </div>
                <div class="pagebar">
                    <div id="Pagination">
                    </div>
                </div>
            </div>
        </div>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function checkChange() {
            if ($('#txtMoney').val().Trim() == "") {
                v5.error('汇款金额不能为空', '1', 'true');
                return;
            }
            else {
                var reg1 = /^\d+$/;
                if (!reg1.test(parseInt($('#txtMoney').val()))) {
                    v5.error('充值金额应该为正数', '1', 'true');
                    return;
                }
            } if (RunAjaxGetKey('getMName', $('#txtRemark').val()) == '') {
                v5.error('不存在该会员', '1', 'true');
                return;
            }
            ActionModel("/ChangeMoney/Recharge.aspx?Action=add", $('#form1').serialize());
        }
    </script>
</body>
</html>
