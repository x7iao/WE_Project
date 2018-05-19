<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WE_Project.Web.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<!--[if IE 9 ]><html class="ie9"><![endif]-->
<head>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    <meta name="format-detection" content="telephone=no">
    <meta charset="UTF-8">
    <link rel="Shortcut Icon" href="/Admin/img/icon.ico">
    <meta name="description" content="Violate Responsive Admin Template">
    <meta name="keywords" content="Super Admin, Admin, Template, Bootstrap">

    <title><%=WebModel.WebTitle %></title>

    <!-- CSS -->
    <link href="/Admin/css/bootstrap.min.css" rel="stylesheet">
    <link href="/Admin/css/style.css" rel="stylesheet">
    <link href="/Admin/css/form.css" rel="stylesheet">
    <link href="/Admin/css/animate.css" rel="stylesheet">
    <link href="/Admin/css/generics.css" rel="stylesheet">


    <link href="/Admin/pop/css/V5-UI.css" rel="stylesheet" type="text/css" />
    <script src="/Admin/pop/js/jquery-1.8.3.min.js"></script>
    <script src="/Admin/pop/js/V5-UI.js" type="text/javascript"></script>
    <script src="/Admin/pop/js/uaredirect.js" type="text/javascript"></script>
    <%--<script type="text/javascript">        uaredirect("/tel/Login.aspx");</script>--%>
    <script type="text/javascript">
        function Login() {
            if ($("#txtname").val() == "") {
                v5.error('用户名不能为空', '1', 'true');
            } else if (pwd = $("#txtpwd").val() == "") {
                v5.error('密码不能为空', '1', 'true');
            } else {
                $.ajax({
                    type: "post",
                    url: "/Login.aspx?type=login",
                    data: {
                        txtname: $("#txtname").val(), txtpwd: $("#txtpwd").val(), checkCode: $("#checkCode").val(), href: window.location.href
                    },
                    async: true,
                    success: function (data) {
                        switch (data) {
                            case "1":
                                v5.error('用户名不存在', '1', 'true');
                                break;
                            case "2":
                                v5.error('密码不正确', '1', 'true');
                                break;
                            case "3":
                                v5.error('验证码错误', '1', 'true');
                                $("#imgcode").click();
                                break;
                            case "4":
                                v5.error('请先激活', '1', 'true');
                                break;
                            case "-1":
                                v5.error('限制登录', '1', 'true');
                                break;
                            case "0":
                                window.location.href = "/Default.aspx";
                                break;
                            default:
                                if (data)
                                    v5.error(data, '1', 'true');
                                break;
                        }
                    }
                })
            }
            return false;
        }
        function keyLogin() {
            if (event.keyCode == 13)   //回车键的键值为13   
                Login();
        }
    </script>
</head>
<body id="skin-blur-violate" onkeydown="keyLogin();">
    <section id="login" style="text-align: center;">
            <header>
                <h1>WE</h1>
                <p>任何使用本网站系统的用户均应仔细阅读本声明，用户可选择不使用本网站系统，用户使用本网站系统的行为将被视为对本声明全部内容的认可。详情请阅读<a href="JavaScript:xieyi()" style="color:#ffd800;">WE阅读协议</a>！</p>


                 <div class="clearfix"></div>
            <div style="">
            <!-- Login -->
            <%--<form class="box tile animated active" id="box-login">--%>
                <h2 class="m-t-0 m-b-15">登陆</h2>
                <input type="text" class="login-control m-b-10" style="width:300px; " name="txtname" id="txtname" placeholder="Username"><br />
                <input type="password" class="login-control"  style="width:300px;" name="txtpwd" id="txtpwd" placeholder="Password"><br />
                <input type="test" class="login-control"  style="width:228px; margin-top:8px;"  name="checkCode" id="checkCode" placeholder="验证码" >
                 <img src="/CheckCode.aspx" onclick="this.src='../CheckCode.aspx?'+Math.random()" width="66px;" height="28px;">
                <br />
               <%-- <div class="checkbox m-b-20">
                    <label>
                        <input type="checkbox">
                        Remember Me
                    </label>
                </div>--%>
                <button class="btn btn-sm m-r-5" type="button"  onclick="Login()" style="margin-top:5px;">登陆</button>
                
                <small>
                    <a  href="/Regedit/Index.aspx?mid=admin">没有账号？注册</a> &nbsp;&nbsp;&nbsp;&nbsp;
                    <a data-switch="box-reset" href="/SecurityCenter/Findpwd.aspx">忘记密码?</a>
                </small>
           <%-- </form>--%>
            </div>
            </header><script src="/plugin/layer/layer.js"></script>
        <script>
            function xieyi() {
                layer.open({
                    type: 1
            , title: false //不显示标题栏
            , closeBtn: true
            , area: '80%;'
            , shade: 0.8
            , id: 'LAY_layuipro' //设定一个id，防止重复弹出
            , btnAlign: 'c'
            , moveType: 1 //拖拽模式，0或者1
            , content: '<div style="padding: 20px; line-height: 22px; background-color: #393D49; color: #fff; font-weight: 300; overflow:scroll;  height:600px;">   WE社区会员协议<br/>特别提示：“WE社区”在此特别提醒您（会员）在注册成为会员之前，请认真阅读本《会员协议》（以下简称“协议”），确保您充分理解本协议中各条款。请您审慎阅读并选择接受或不接受本协议。除非您接受本协议所有条款，否则您无权注册、登录或使用本协议所涉服务。您的注册、登录、使用等行为将视为对本协议的接受，并同意接受本协议各项条款的约束。本协议约定WE社区与会员之间关于“WE社区”平台服务（以下简称“服务”）的权利义务。“会员”是指注册、登录、使用本服务的个人。本协议可由WE社区随时更新，更新后的协议条款一旦公布即代替原来的协议条款，恕不再另行通知，会员可在本网站查阅最新版协议条款。在WE社区修改协议条款后，如果会员不接受修改后的条款，请立即停止使用WE社区提供的服务，会员继续使用WE社区提供的服务将被视为接受修改后的协议。<br/>一、帐号注册<br/>1、会员在使用本服务前需要注册一个“WE社区”帐号。“WE社区”帐号应当使用手机号码绑定注册，请会员使用尚未与“WE社区”帐号绑定的手机号码，以及未被WE社区根据本协议封禁的手机号码注册“WE社区”帐号。WE社区可以根据会员需求对帐号注册和绑定的方式进行变更，而无须事先通知会员。<br/>2、鉴于“WE社区”帐号的绑定注册方式，您同意WE社区在注册时将使用您提供的手机号码或自动提取您的手机号码及自动提取您的手机设备识别码等信息用于注册。<br/>3、申请注册成为会员, 应向平台方提供准确的个人资料, 如个人资料有任何变动, 应及时向平台客服告知并更新。一经注册成功, 成为WE社区会员将得到一个账户及用户名。每个会员应当对其账户及名称进行的所有交易和事件承担全部责任。<br/>4、本服务的具体内容由WE社区根据实际情况提供，WE社区可以对其提供的服务予以变更，且WE社区提供的服务内容可能随时变更；会员将会收到WE社区关于服务变更的通知。<br/>二、会员个人信息保护<br/>1、会员在注册帐号或使用本服务的过程中，可能需要填写或提交一些必要的个人信息。如会员提交的信息不完整或不符合法律法规的规定，则会员可能无法使用本服务或在使用本服务的过程中受到限制。<br/>2、WE社区未经会员同意不向任何第三方公开、透露会员个人隐私信息。<br/>3、会员同意WE社区可在以下事项中使用会员的信息：<br/>(1) WE社区向会员及时发送重要公告；<br/>(2) WE社区内部进行计算、数据分析等，以改进WE社区的服务和与会员之间的沟通；<br/>(3) 依本协议约定，WE社区管理、审查会员信息及进行处理措施；<br/>(4) 适用法律法规规定的其他事项。<br/>除上述事项外，如未取得会员事先同意，WE社区不会将会员个人隐私信息使用于任何其他用途。<br/>三、内容规范<br/>1、会员同意并保证不得利用平台从事侵害他人权益或违法行为, 违反者应负由之产生的一切法律责任。上述行为包括但不限于:<br/>            (1) 违反诚实信用原则进行不正当竞争, 扰乱平台正常秩序的行为;<br/>(2) 发布涉嫌侵犯他人名誉权、隐私权、知识产权或其它合法权益的及其他涉嫌违法或违反本协议信息的行为;<br/>(3) 对平台上的任何数据作商业性利用, 包括但不限于在未经事先书面同意的情况下, 以复制、传播等任何方式使用平台展示资料的行为;<br/>(4) 冒用他人名义注册平台服务的行为;<br/>(5) 提供赌博资讯或以任何方式引诱他人参与赌博的行为;<br/>(6) 涉嫌洗钱等行为;<br/>(7) 其他平台有正当理由认为不适当之行为。<br/>2、会员资格冻结与终止平台有权基于自身合理判断, 冻结或终止向会员提供本协议项下的全部或部分服务,并无需对会员或任何第三方承担任何责任。前述情形包括但不限于:<br/>(1) 平台合理地认为会员所提供的资料不具有真实性、有效性或完整性;<br/>(2) 平台合理地认为会员已经违反本协议中规定的各类规则及精神;<br/>(3) 第三人冒用或盗用会员的用户名及密码, 或其他任何未经会员合法授权的情形;<br/>(4) 平台基于安全等原因, 根据其合理判断的其他情形。会员资格的冻结或终止不代表会员责任的终止, 会员仍应对其使用平台服务期间的行为承担可能的违约或损害赔偿责任, 同时平台仍可保有会员的相关信息。<br/>四、责任范围及限制<br/>1、会员了解并认可,任何通过平台进行的活动并不能避免以下风险的产生,平台不能也没有义务为如下风险负责:<br/>(1) 宏观经济风险: 因宏观经济形势变化可能引起的异常波动风险;<br/>(2) 政策风险: 因有关法律、法规及相关政策、规则发生变化可能引起的异常波动风险;<br/>(3) 违约风险: 其他活动方无力或无意愿按时足额履约风险;<br/>(4) 信息风险: 平台不能也无义务对各方发布的信息进行控制, 对该等信息, 平台不承担任何形式的证明、鉴定服务。<br/>(5) 因不可抗力因素导致的风险。<br/>以上条款并不能揭示会员通过平台进行活动的全部风险。会员在做出是否接受平台服务前, 应全面了解相关服务内容, 谨慎决策, 并自行承担全部风险。<br/>2、不可抗力及其他免责事由<br/>(1)会员理解并确认，在使用本服务的过程中，可能会遇到不可抗力等风险因素，使本服务发生中断。不可抗力是指不能预见、不能克服并不能避免且对一方或双方造成重大影响的客观事件，包括但不限于自然灾害如洪水、地震、瘟疫流行和风暴等以及社会事件如战争、动乱、政府行为等。出现上述情况时，WE社区将努力在第一时间与相关单位配合，及时进行修复，但是由此给会员或第三方造成的损失，WE社区及合作单位在法律允许的范围内免责。<br/>(2)会员理解并确认，本服务存在因不可抗力、计算机病毒或黑客攻击、系统不稳定、会员所在位置、会员关机以及其他任何技术、互联网络、通信线路原因等造成的服务中断或不能满足会员要求的风险，因此导致的会员或第三方任何损失，WE社区不承担任何责任。<br/>(3)会员理解并确认，在使用本服务过程中存在来自任何他人的包括误导性的、欺骗性的、威胁性的、诽谤性的、令人反感的或非法的信息，或侵犯他人权利的匿名或冒名的信息，以及伴随该等信息的行为，因此导致的会员或第三方的任何损失，WE社区不承担任何责任。<br/>(4)会员理解并确认，WE社区需要定期或不定期地对“WE社区”平台或相关的设备进行检修或者维护，如因此类情况而造成服务在合理时间内的中断，WE社区无需为此承担任何责任，但WE社区应事先进行通告。<br/>(5)WE社区依据法律法规、本协议约定获得处理违法违规或违约内容的权利，该权利不构成WE社区的义务或承诺，WE社区不能保证及时发现违法违规或违约行为或进行相应处理。<br/>(6)会员免责<br/>因会员自身的原因导致的任何损失或责任, 由会员自行负责平台不承担责任。该等情形包括但不限于:<br/>① 会员未按照本协议或平台不时公布的任何规则进行操作导致的任何损失或责任;<br/>② 因会员使用的第三方支付的原因导致的损失或责任, 包括会员使用未经认证的银行卡或使用非会员本人的银行卡或使用信用卡, 会员的银行卡被冻结、挂失等导致的任何损失或责任;<br/>③ 会员向平台发送的指令信息不明确、或存在歧义、不完整等导致的任何损失或责任;<br/>④ 因会员的决策失误、操作不当、遗忘或泄露密码、密码被他人破解、会员使用的计算机系统被第三方侵入、会员委托他人管理账号时他人恶意或不当操作而造成的损失;<br/>⑤ 其他因会员的原因导致的任何损失或责任。<br/>八、其他<br/>1、WE社区郑重提醒会员注意本协议中免除WE社区责任和限制会员权利的条款，请会员仔细阅读，自主考虑风险。<br/>2、本协议的效力、解释及纠纷的解决，适用于中华人民共和国法律。若会员和WE社区之间发生任何纠纷或争议，应友好协商解决。<br/>3、本协议的任何条款无论因何种原因无效或不具可执行性，其余条款仍有效，对双方具有约束力。<br/>4、由于互联网高速发展，您与WE社区签署的本协议列明的条款可能并不能完整罗列并覆盖您与WE社区所有权利与义务，现有的约定也不能保证完全符合未来发展的需求。因此，WE社区隐私权政策、WE社区平台行为规范等均为本协议的补充协议，与本协议不可分割且具有同等法律效力。如您使用WE社区平台服务，视为您同意上述补充协议。<br/></div>'
            , success: function (layero) {
                var btn = layero.find('.layui-layer-btn');
                btn.find('.layui-layer-btn0').attr({
                    href: 'http://www.layui.com/'
                  , target: '_blank'
                });
            }
                });
            }

        </script>
           
           
            
        </section>

    <!-- Javascript Libraries -->
    <!-- jQuery -->
    <script src="/Admin/js/jquery.min.js"></script>
    <!-- jQuery Library -->

    <!-- Bootstrap -->
    <script src="/Admin/js/bootstrap.min.js"></script>

    <!--  Form Related -->
    <script src="/Admin/js/icheck.js"></script>
    <!-- Custom Checkbox + Radio -->

    <!-- All JS functions -->
    <script src="/Admin/js/functions.js"></script>
</body>
</html>
