<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BankList.aspx.cs" Inherits="WE_Project.Web.SecurityCenter.BankList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tUrl = '/Handler/BankList.ashx';
        SearchByCondition();
        //convertLanguage();
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
          <%if (TModel.Role.IsAdmin)//只有管理员才有修改功能
              { %>
            <div class="pay" onclick="UpDateByID('../SecurityCenter/ModifyBankInfo.aspx?','修改银行卡',680,300)">
                &nbsp;修&nbsp;&nbsp;改&nbsp;</div>
                   <%} %>
          
            <div class="pay" onclick="v5.show('SecurityCenter/AddBankInfo.aspx','添加银行卡','url',680,300)">
                &nbsp;添&nbsp;&nbsp;加&nbsp;</div>
            
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <input name="txtKey" id="mKey" value="请输入会员账号" onfocus="if (value =='请输入会员账号'){value =''}"
                    onblur="if (value ==''){value='请输入会员账号'}" type="text" class="sinput" />
                <input type="text" name="txtKey" id="endDate" value="截止日期" onfocus="if (value =='截止日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({minDate:'#F{$dp.$D(\'startDate\')}'})" />
                <input type="text" name="txtKey" id="startDate" value="开始日期" onfocus="if (value =='开始日期'){value =''}"
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
                    <%if (TModel.Role.IsAdmin)
                      { %>
                    <th>
                        会员账号
                    </th>
                    <th>
                        会员昵称
                    </th>
                    <%} %>
                    <th>
                        开户银行
                    </th>
                    <th>
                        开户支行
                    </th>
                    <th>
                        卡号
                    </th>
                    <th>
                        开户姓名
                    </th>
                    <th>
                        创建日期
                    </th>
                   <%-- <th>
                        是否提现卡
                    </th>--%>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn" id="DivOp" runat="server">
                    <a href="javascript:void(0);" title="" onclick="RunAjaxByList('','DeleteBank',',');">
                        删除</a>
                </div>
                <div class="pagebar">
                    <div id="Pagination">
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
