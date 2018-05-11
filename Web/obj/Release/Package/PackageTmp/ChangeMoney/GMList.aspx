<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GMList.aspx.cs" Inherits="WE_Project.Web.ChangeMoney.GMList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        tUrl = '/Handler/GMList.ashx';
        SearchByCondition();
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control" id="DivSearch" runat="server">
      <%--   <div class="pay" onclick="v5.show('ChangeMoney/HBKC.aspx','会员扣费','url',360,240)">
                会员扣费</div>--%>
            <div class="pay" onclick="v5.show('ChangeMoney/HBGM.aspx','会员充值','url',360,240)">
                会员充值</div>
            <div class="pay" onclick="v5.show('ChangeMoney/HBJL.aspx','奖金发放','url',360,240)">
                奖励会员</div>
            <div class="search">
                <input type="button" value="查询" class="ssubmit btn btn-success" onclick="SearchByCondition()" />
                <input name="txtKey" id="mKey" placeholder="请输入会员账号"   type="text" class="sinput" />
                <input type="text" name="txtKey" id="endDate" placeholder="截止日期" onfocus="if (value =='截止日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({minDate:'#F{$dp.$D(\'startDate\')}'})" />
                <input type="text" name="txtKey" id="startDate" placeholder="开始日期" onfocus="if (value =='开始日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({maxDate:'#F{$dp.$D(\'endDate\')}'})" /></div>
        </div>
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
                        会员账号
                    </th>
                    <th>
                        会员昵称
                    </th>
                    <th>
                        充值金额
                    </th>
                    <th>
                        是否生效
                    </th>
                    <th>
                        充值钱包
                    </th>
                    <th>
                        日期
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
               <%-- <div class="pn" id="DivDelete" runat="server">
                    <a href="javascript:void(0);" title="" onclick="RunAjaxByList('','DeleteChangeMoney',',');">
                        删除</a>
                </div>--%>
                <div class="pagebar">
                    <div id="Pagination">
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
