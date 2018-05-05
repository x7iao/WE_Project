<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BusinessCenter.aspx.cs" Inherits="WE_Project.Web.Member.BusinessCenter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        tUrl = "/Handler/SHList.ashx";
        tState = "false";
        SearchByCondition();
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <div class="select">
                <a href="javascript:void(0);" onclick="SearchByState('false',this);" class="btn btn-danger">未升级</a><a
                    href="javascript:void(0)" onclick="SearchByState('true',this);" class="btn btn-success">已升级</a></div>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <input name="txtKey" id="mKey" placeholder="请输入会员账号"  type="text" class="sinput" />
                <input name="txtKey" id="mSHKey" placeholder="请输入报单中心"  type="text" class="sinput" />
                <input id="txtMid" type="hidden" runat="server" />
                <input type="text" name="txtKey" id="endDate" placeholder="截止日期"   class="daycash_input" style="width: 120px;" onclick="WdatePicker({minDate:'#F{$dp.$D(\'startDate\')}'})" />
                <input type="text" name="txtKey" id="startDate" placeholder="开始日期"   class="daycash_input" style="width: 120px;" onclick="WdatePicker({maxDate:'#F{$dp.$D(\'endDate\')}'})" />
            </div>
            <div class="pay" onclick="UpDateByID('Member/UpMAgencyType.aspx?','升级会员',820,530)">
                升级会员</div>
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
                        手机号码
                    </th>
                    <th>
                        会员级别
                    </th>
                    <th>
                        报单费
                    </th>
                    <th>
                        推荐人
                    </th>
                    <th>
                        是否审核
                    </th>
                    <th>
                        日期
                    </th>
                </tr>
            </table>
            <div class="ui_table_control">
                <em style="vertical-align: middle;">
                    <input type="checkbox" id="chkAll" onclick="SelectChk(this);" /></em>
                <div class="pn">
                    <span id="DivOperation" runat="server"><a href="javascript:void(0);"
                            title="删除" onclick="RunAjaxByList('false','DeleteMemberW',',');">删除</a></span>
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
