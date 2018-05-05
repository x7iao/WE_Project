<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="WE_Project.Web.Admin.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta charset="utf-8" />
    <title>
        <%=WebModel.WebTitle %></title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link rel="shortcut icon" href="/admin/images/logo.ico" type="image/x-icon" />
    <link rel="stylesheet" type="text/css" href="/admin/css/style.css" />
    <link type="text/css" rel="stylesheet" href="/admin/pop/css/next_page_search.css" />
    <link rel="stylesheet" type="text/css" href="/admin/css/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="/admin/css/bootstrap-ie6.css" />
    <link rel="stylesheet" type="text/css" href="/admin/css/ie.css" />
    <link rel="stylesheet" type="text/css" href="/admin/css/common.css" />
    <link rel="stylesheet" type="text/css" href="/admin/pop/css/V5-UI.css" />
</head>
<body>
    <div class="container-fluid">
        <div class="row headermenu sidebar" id="sidebar-collapse">
            <div class="headermiddle">
                <div class="logo">
                    <img src="/Admin/images/logo.png" />
                </div>
                <ul id="menu_left">
                    <li class="adminbtn dropdown pull-right"><a href="javascript:void(0)" onclick="location.reload()"
                        class="dropdown-toggle">首页&nbsp;</a></li>
                    <%foreach (WE_Project.Model.RolePowers item in GetPowers("0"))
                      { %>
                    <li class="adminbtn dropdown pull-right"><a href="javascript:void(0)" class="dropdown-toggle"
                        data-toggle="dropdown">
                        <%=item.Content.CTitle %>&nbsp;<span class="sj">&nbsp;</span> </a>
                        <ul class="dropdown-menu ermenubg">
                            <%foreach (WE_Project.Model.RolePowers item2 in GetPowers(item.CID))
                              { %>
                            <li><a href="javascript:void(0)" onclick="callhtml('<%=item2.Content.CAddress %>','<%=item2.Content.CTitle %>');onclickmenu()">
                                <%=item2.Content.CTitle%></a></li>
                            <%} %>
                        </ul>
                    </li>
                    <%} %>
                </ul>
                <div class="righeader">
					 <li class="user user-menu" style="display: inline-block; float: left;"><a href="#"
                            class="dropdown-toggle">
                            <img src="/Admin/images/user2-160x160.jpg" class="user-image" alt="User Image" />
                            <span class="hidden-xs"><%=TModel.MID %></span> </a></li>
                    <li class="adminbtn dropdown pull-right"><a href="/SysManage/Out.aspx" class="dropdown-toggle">
                        安全退出&nbsp;</a> </li>
                </div>
            </div>
        </div>
        <div class="head">
            <div class="logo2">
                <img src="/admin/images/logo.png"></div>
            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#sidebar-collapse">
                <span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span><span
                    class="icon-bar"></span><span class="icon-bar"></span>
            </button>
        </div>
        <div id="maincontent">
            <div class="fmenu">
                <div class="row topmargin">
                    <ul class="kjpanel">
                        <li><a href="javascript:void(0)" onclick="callhtml('../ChangeMoney/JJList.aspx','奖金明细');">
                            <img src="/admin/images/qd.png" alt="" /><span>奖金明细</span></a></li>
                        <li><a href="javascript:void(0)" onclick="callhtml('../Mafull/OfferHelpList.aspx','提供帮助列表');">
                            <img src="/admin/images/kj.png" alt="" /><span>我的提供帮助</span></a></li>
                        <li><a href="javascript:void(0)" onclick="callhtml('../Mafull/GetHelpList.aspx','获得帮助列表');">
                            <img src="/admin/images/xnb.png" alt="" /><span>我的获得帮助</span></a></li>
                        <li><a href="javascript:void(0)" onclick="callhtml('../Member/TJList.aspx','我的推荐');">
                            <img src="/admin/images/market.png" alt="" /><span>我的推荐</span></a></li>
                        <li><a href="javascript:void(0)" onclick="callhtml('../Member/View.aspx','个人信息');">
                            <img src="/admin/images/page.png" alt="" /><span>个人信息</span></a></li>
                        <li><a href="javascript:void(0)" onclick="callhtml('../Member/Add.aspx','会员注册');">
                            <img src="/admin/images/zc.png" alt="" /><span>会员注册</span></a></li>
                    </ul>
                    <ul class="col-md-12">
                        <li><span>理财风险和收益并存，本着会员自愿知情的情况下投资，平台不参与投资者损益忘各位会员周知，但是平台会奔着长久的方向发展下去！</span></li>
                    </ul>
                    <div class="col-md-12" style=" display:none;">
                        <ul class="breadcrumb">
                            <li>
                                <input type="button" value="推广链接" class="input1" />
                            </li>
                            <li style="width: 70%">
                                <input type="text" class="input2" id="txtTuiGuang" runat="server" readonly="readonly" />
                            </li>
                            <li style="width: 10%">
                                <input class="input3" type="button" value="复制" data-clipboard-target="txtTuiGuang"
                                    id="fenxian" />
                            </li>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="row contentbody">
                <div class="content">
                    <div class="btnhelpput">
                        <div class="buyArea row">
                            <div id="put_help" class="ordin_button col-md-6">
                                <div>
                                    <span class="trantslate">
                                        <img src="/admin/images/bz.jpg" />提供帮助</span></div>
                            </div>
                            <div id="get_help" class="ordout_button col-md-6">
                                <div>
                                    <span class="trantslate">
                                        <img src="/admin/images/sh.jpg" />获得帮助</span></div>
                            </div>
                        </div>
                        <div class="row" style="margin-top: 10px;">
                            <div class="col-md-12">
                                <!--      提供帮助 Start       -->
                                <div class="widget tab1">
                                    <div class="widgetbody">
                                        <div class="form-group">
                                            <p class="apply-tips">
                                                请认真填写愿意提供帮助的数量</p>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-sm-3">
                                                剩余排单币:</label>
                                            <div class="col-sm-9">
                                                <%=TModel.MConfig.MGP.ToString("F0") %>
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-3">
                                                选择排单区域</label>
                                           
                                            <div class="col-sm-9">
                                                <select id="offerrdo" runat="server">
                                                    <option value="0">正常排单</option>
                                                    <option value="1">抢单区排单（不消耗排单币）</option>
                                                </select>
                                                ←选择排单区域
                                            </div>
                                        </div>

                                        <div class="form-group">
                                            <label class="col-sm-3">
                                                提供帮助金额:</label>
                                            <div class="col-sm-9">
                                                <input type="text" class="form-control" id="txtSQMoneyOff" />
                                            </div>
                                        </div>
                                        <div class="footer">
                                            <input class="btn_next btn-warning btn-sm btn btn-primary " value="提供帮助 " type="button"
                                                onclick="Offer_Help()" />
                                        </div>
                                    </div>
                                </div>
                                <!--      提供帮助 End         -->
                                <!--      获得帮助 Start       -->
                                <div class="widget tab2">
                                    <div class="widgetbody">
                                        <div class="form-group">
                                            <label class="col-sm-3">
                                                选择钱包</label>
                                           
                                            <div class="col-sm-9">
                                                <select id="rdo">
                                                    <option value="MHB">
                                                        <%=WE_Project.BLL.Reward.List["MHB"].RewardName %>(余额:<%=TModel.MConfig.MHB %>)</option>
                                                    <%--<option value="MCW">
                                                        <%=WE_Project.BLL.Reward.List["MCW"].RewardName%>(余额:<%=TModel.MConfig.MCW %>)</option>--%>
                                                    <option value="MJB">
                                                        <%=WE_Project.BLL.Reward.List["MJB"].RewardName%>(余额:<%=TModel.MConfig.MJB %>)</option>
                                                </select>
                                                ←选择钱包
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label class="col-sm-3">
                                                获得回报总额：<font style="color: red;">*</font></label>
                                            <div class="col-sm-9">
                                                <input type="text" class="form-control" id="txtSQMoneyGet" />
                                            </div>
                                        </div>
                                        <div class="footer">
                                            <input class="btn_next btn-warning btn-sm btn btn-primary " value="获得帮助" type="button"
                                                onclick="Get_Help()" />
                                        </div>
                                    </div>
                                </div>
                                <!--      获得帮助 End         -->
                            </div>
                            <div class="col-md-12 ">
                            </div>
                        </div>
                    </div>
                    <div class="jycontent">
                        <div class="mainleft">
                            <!--      提供帮助 Start       -->
                            <div class="widget greenn">
                                <div class="widgethead green">
                                    <h4 class="heading ">
                                        <b>$ 提供帮助</b>
                                    </h4>
                                </div>
                                <div class="widgetbody ">
                                    <div class="innertable ">
                                        <table id="offMatch" cellpadding="0 " cellpadding="0 " width="100% ">
                                            <thead>
                                                <tr>
                                                    <th>
                                                        编号
                                                    </th>
                                                    <th>
                                                        交易进度
                                                    </th>
                                                    <th>
                                                        交易时间
                                                    </th>
                                                    <th>
                                                        提供帮助会员
                                                    </th>
                                                    <th>
                                                        付款金额
                                                    </th>
                                                    <th>
                                                        获得帮助会员
                                                    </th>
                                                    <th>
                                                        操作
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <!--      提供帮助 End         -->
                            <!--      获得帮助 Start       -->
                            <div class="widget orangee">
                                <div class="widgethead orange">
                                    <h4 class="heading ">
                                        <b>$ 获得帮助</b>
                                    </h4>
                                </div>
                                <div class="widgetbody">
                                    <div class="innertable ">
                                        <table id="getMatch" width="100% ">
                                            <thead>
                                                <tr>
                                                    <th>
                                                        编号
                                                    </th>
                                                    <th>
                                                        交易进度
                                                    </th>
                                                    <th>
                                                        交易时间
                                                    </th>
                                                    <th>
                                                        提供帮助会员
                                                    </th>
                                                    <th>
                                                        付款金额
                                                    </th>
                                                    <th>
                                                        获得帮助会员
                                                    </th>
                                                    <th>
                                                        操作
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                            <!--      获得帮助 End         -->
                        </div>
                        <!--      右边列表 Start      -->
                        <div class="mianright">
                        </div>
                        <!--      右边列表 End        -->
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="/Admin/js/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="/Admin/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="/Admin/js/payfor.js" type="text/javascript"></script>
    <script src="/Admin/js/common.js" type="text/javascript"></script>
    <script type="text/javascript" src="/Admin/pop/js/layer/layer.min.js"></script>
    <script type="text/javascript" src="/Admin/pop/js/stack.js"></script>
    <script type="text/javascript" src="/Admin/pop/js/MyValide.js"></script>
    <script type="text/javascript" src="/plugin/ztree/js/jquery.ztree.core-3.5.js"></script>
    <script type="text/javascript" src="/plugin/ztree/ztreeScript.js"></script>
    <script type="text/javascript" src="/Admin/pop/js/javascript_main.js"></script>
    <script type="text/javascript" src="/Admin/pop/js/ajax.js"></script>
    <script type="text/javascript" src="/Admin/pop/js/javascript_pop.js"></script>
    <script type="text/javascript" src="/Admin/pop/js/V5-UI.js"></script>
    <script type="text/javascript" src="/Admin/pop/js/jquery.pagination.js" charset="gbk"></script>
    <script type="text/javascript" src="/plugin/UEditor/editor_config.js"></script>
    <script type="text/javascript" src="/plugin/UEditor/editor_all.js"></script>
    <script type="text/javascript" src="/plugin/jOrgChart/prettify.js"></script>
    <script type="text/javascript" src="/plugin/jOrgChart/jquery.jOrgChart.js"></script>
    <script type="text/javascript" src="/plugin/date/WdatePicker.js"></script>
    <script type="text/javascript" src="/plugin/ZeroClipboard/ZeroClipboard.js"></script>
    <script type="text/javascript" src="/plugin/kindeditor/kindeditor-min.js"></script>
    <script type="text/javascript" src="/Admin/js/LoadHelp.js"></script>
    <script type="text/javascript" src="/Mafull/chat/js/chat.js"></script>
    <script type="text/javascript">
        $(function () {
            $.ajaxSetup({ cache: false });
            var clip = new ZeroClipboard(document.getElementById("fenxian"), {
                moviePath: "/plugin/ZeroClipboard/ZeroClipboard.swf"
            });
            // 复制内容到剪贴板成功后的操作 
            clip.on('complete', function (client, args) {
                layer.alert('复制成功！', {
                    skin: 'layer-ext-moon',
                    btn: '确定'
                });
            });
            GetHelpList("1", ".jycontent #getMatch > tbody");
            GetHelpList("2", ".jycontent #offMatch > tbody");
            GetHelpList("3", ".jycontent .mianright");
        });

        function onclickmenu() {
            var className = document.getElementById("sidebar-collapse").className;
            if (className == "row headermenu sidebar collapse in") {
                $(".navbar-toggle").click();
            }
        }

        function rectClick() {
            layer.open({
                title: false,
                type: 2,
                content: ['test/iframe.html', '0'],
                area: ['380px', '160px'],
                btn: ['ok']
            });
        }

        KindEditor.ready(function (K) {
            window.KKKK = K;
        });
    </script>
    <%--<iframe id='frameFile' name='frameFile' style='display: none;'></iframe>--%>
</body>
</html>
