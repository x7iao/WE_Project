<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetSplit.aspx.cs" Inherits="WE_Project.Web.Mafull.GetSplit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tUrl = "/Mafull/Handler/GetSplit.ashx";
        SearchByCondition();
        function GetSplit(id) {
            verifypsd(function () {
                var txtvalue = $("#txtSplit_" + id).val();
                var relVal = RunAjaxGetKey('GetSplit', txtvalue + "~" + id);
                if (relVal == "1") {
                    v5.alert('拆分成功', '1', 'true');
                    SearchByCondition();
                }
                else {
                    v5.alert(relVal, '1', 'true');
                }
            });
        }
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <input type="text" name="txtKey" id="mKey" placeholder="会员帐号" class="daycash_input"
                    style="width: 120px;" />
                <input type="text" name="txtKey" id="startDate" placeholder="开始日期" onfocus="if (value =='开始日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({maxDate:'#F{$dp.$D(\'endDate\')}'})" />
                <input type="text" name="txtKey" id="endDate" placeholder="截止日期" onfocus="if (value =='截止日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({minDate:'#F{$dp.$D(\'startDate\')}'})" /></div>
        </div>
        <div class="ui_table">
            <table cellpadding="0" cellspacing="0" id="Result" class="tabcolor">
                <tr>
                    <th width="80px">
                        全选
                    </th>
                    <th>
                        会员帐号
                    </th>
                    <th>
                        订单编号
                    </th>
                    <th>
                        申请时间
                    </th>
                    <th>
                        申请金额
                    </th>
                    <th>
                        操作
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pagebar">
                    <div id="Pagination">
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
