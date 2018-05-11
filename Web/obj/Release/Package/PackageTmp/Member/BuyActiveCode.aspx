<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuyActiveCode.aspx.cs"
    Inherits="WE_Project.Web.Member.BuyActiveCode" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <div id="mempay">
        <div id="finance">
            <form id="form1">
            <span class="remak">温馨提示：请选择您要充值的类型，确认后并向公司收款账号汇款，等待公司财务审核通过后，生效 </span>
            <div>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="right">
                            <span>会员账号：</span>
                        </td>
                        <td>
                            <%=TModel.MID %>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <span>姓名：</span>
                        </td>
                        <td>
                            <input id="txtBankName" maxlength="10" class="normal_input" runat="server" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <span>汇款日期：</span>
                        </td>
                        <td>
                            <input id="txtHKDate" maxlength="9" class="normal_input" runat="server" type="text"
                                onclick="WdatePicker({dateFmt:'yyyy-MM-dd HH:mm',maxDate:'%y-%M-%d'})" readonly="readonly" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <span>金额：</span>
                        </td>
                        <td>
                            <input id="txtValidMoney" runat="server" class="normal_input" type="text" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <span>购买方式：</span>
                        </td>
                        <td>
                            <input id="Radio1" type="radio" value="1" name="RioHK" checked="checked" />排单币
                            <input id="Radio2" type="radio" value="2" name="RioHK" />激活码
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <span>备注：</span>
                        </td>
                        <td>
                            <input id="txtRemark" runat="server" class="normal_input" type="text" maxlength="100" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            <input class="normal_btnok" id="btnOK" type="button" runat="server" value="提交" onclick="checkChange();" />
                        </td>
                    </tr>
                </table>
            </div>
            <span class="remak">
                <%=WebModel.HKInfo %></span>
            </form>
        </div>
    </div>
    <script type="text/javascript">
        function setValidMoney(realobj, validobj) {
            $(validobj).val($(realobj).val() *<%=WE_Project.BLL.Configuration.Model.InFloat %>);
        }
        function checkChange() {
            if ($('#txtHKDate').val().Trim() == "") {
                v5.error('汇款日期不能为空', '1', 'true');
            } else if ($('#txtBankName').val().Trim() == '') {
                v5.error('汇款人姓名不能为空', '1', 'true');
            } else {
                ActionModel("/Member/BuyActiveCode.aspx?Action=add", $('#form1').serialize());
            }
        }
    </script>
</body>
</html>
