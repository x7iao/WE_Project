﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TJList.aspx.cs" Inherits="WE_Project.Web.Member.TJList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script type="text/javascript">
        //tState = 'true'
        tUrl = "/Handler/MemberTJList.ashx";
        SearchByCondition();
    </script>
</head>
<body>
    <div id="mempay">
        <div class="control">
            <%--<div class="select">
                <a href="javascript:void(0);" onclick="SearchByState('true',this);" class="btn btn-danger">已激活</a>
                <a href="javascript:void(0)" onclick="SearchByState('false',this);" class="btn btn-success">未激活</a>
            </div>--%>
            <div class="search" id="DivSearch" runat="server">
                <input type="button" value="查询" class="ssubmit" onclick="SearchByCondition()" />
                <input name="txtKey" id="mKey" value="请输入会员账号" onfocus="if (value =='请输入会员账号'){value =''}"
                    onblur="if (value ==''){value='请输入会员账号'}" type="text" class="sinput" />
                <input name="txtKey" id="mTJKey" value="请输入推荐会员账号" onfocus="if (value =='请输入推荐会员账号'){value =''}"
                    onblur="if (value ==''){value='请输入推荐会员账号'}" type="text" class="sinput" />
                <input name="txtKey" id="mBDKey" value="请输入接点会员账号" onfocus="if (value =='请输入接点会员账号'){value =''}"
                    onblur="if (value ==''){value='请输入接点会员账号'}" type="text" class="sinput" />
            </div>
            <div class="cheeckbox" style="float: right;">
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            <label>
                                合计推荐业绩：</label>
                        </td>
                        <td>
                            <%=TModel.MConfig.TJMoney %>
                        </td>
                    </tr>
                </table>
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
                        会员昵称
                    </th>
                    <th>
                        会员级别
                    </th>
                    <th>
                        投资金额
                    </th>
                    <th>
                        推荐人
                    </th>
                    <th>
                        推荐人数
                    </th>
                    <th>
                        推荐业绩
                    </th>
                    <th>
                        市场人数
                    </th>
                    <th>
                        市场业绩
                    </th>
                    <th>
                        奖金总计
                    </th>
                    <th>
                        净收益
                    </th>
                    <th>
                        注册日期
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
    <script>
        function JHMember(mid) {
            var relVal = RunAjaxGetKey('JHMember', mid);
            if (relVal == "1") {
                v5.alert('激活成功', '1', 'true');
                SearchByCondition();
            }
            else {
                v5.alert(relVal, '1', 'true');
            }
        }
    </script>
</body>
</html>
