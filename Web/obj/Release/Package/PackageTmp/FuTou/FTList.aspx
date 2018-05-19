<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FTList.aspx.cs" Inherits="WE_Project.Web.FuTou.FTList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tUrl = "/FuTou/Handler/FTList.ashx";
        tState = "";
        SearchByCondition();

        function GetTranMoney(id, obj) {
            var relVal = RunAjaxGetKey('GetTranMoney', id);
            if (relVal == "1") {
                v5.alert('提款成功', '1', 'true');
                SearchByCondition();
            }
            else {
                v5.alert(relVal, '1', 'true');
            }
        }
    </script>
   
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="select">
                <a href="javascript:void(0);" onclick="SearchByState('',this);" class="btn btn-danger">
                    全部</a><a href="javascript:void(0);" onclick="SearchByState('false',this);" class="btn btn-success">
                        未出局</a><a href="javascript:void(0)" onclick="SearchByState('true',this);" class="btn btn-success">已出局</a></div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <input name="txtKey" id="mKey" value="请输入会员账号" onfocus="if (value =='请输入会员账号'){value =''}"
                    onblur="if (value ==''){value='请输入会员账号'}" type="text" class="sinput" />
                <input type="text" name="txtKey" id="endDate" value="截止日期" onfocus="if (value =='截止日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({minDate:'#F{$dp.$D(\'startDate\')}'})" />
                <input type="text" name="txtKey" id="startDate" value="开始日期" onfocus="if (value =='开始日期'){value =''}"
                    class="daycash_input" style="width: 120px;" onclick="WdatePicker({maxDate:'#F{$dp.$D(\'endDate\')}'})" />
            </div>
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
                        购买时间
                    </th>
                    <th>
                        购买数量
                    </th>  <th>
                        投资方式
                    </th>
                    <th>
                        已分红次数
                    </th>
                    <th>
                        分红总次数
                    </th>
                    <th>
                        分红比例
                    </th>
                    <th>
                        已得分红收益
                    </th>
                    <th>
                        是否有效
                    </th>
                    <th>
                        操作
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
    </div>
</body>
</html>
