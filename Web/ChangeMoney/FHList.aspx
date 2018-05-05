<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FHList.aspx.cs" Inherits="WE_Project.Web.ChangeMoney.FHList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tState = 'false';
        tUrl = '/Handler/FHList.ashx';
        SearchByCondition();
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
        
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <input name="txtKey" id="mKey" placeholder="请输入会员账号"  
                    type="text" class="sinput" />
                <input type="text" name="txtKey" id="endDate" placeholder="截止日期" onfocus="if (value =='截止日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({minDate:'#F{$dp.$D(\'startDate\')}'})" />
                <input type="text" name="txtKey" id="startDate" placeholder="开始日期" onfocus="if (value =='开始日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({maxDate:'#F{$dp.$D(\'endDate\')}'})" /></div>
             
        </div>
        <div class="ui_table">
            <table cellpadding="0" cellspacing="0" id="Result" class="tabcolor">
                <tr>
                  
                    <th>
                        序号
                    </th>
                       <th>
                        会员账号
                    </th>
                        <th>
                        编号
                    </th>
                    <th>
                        买入时间
                    </th>
                    <th>
                         日分红
                    </th>
                    <th>
                        分红次数
                    </th>
                    <th>
                        累计分红
                    </th>
                       <th>
                        状态
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