$(function() {
    erMenu();
});
function erMenu() {
    $(".menuLi").mouseover(function() {
        $(this).find(".menu").show();
    });
    $(".menuLi").mouseleave(function() {
        $(this).find(".menu").hide();
    });
}

function sdsdsd(obj)
{
	$(obj).find('.pack').toggle();
	}

//$(function() {
//    $('.status_btn').toggle(function() {
//        $(this).find('.pack').show();
//    },
//    function() {
//        $(this).find('.pack').hide();
//    });
//});
$(document).ready(function() {
    $("#green").mouseover(function() {
        $(this).find(".bt-active").show()

    });
    $("#green").mouseleave(function() {
        $(this).find(".bt-active").hide();
    });
});
function rectClick() {
    layer.open({
        title: '按申请的详细信息',
        type: 2,
        content: ['test/page.html', '0'],
        area: ['800px', '500px'],
        btn: ['ok'],

    });
}

function putClick() {
    layer.open({
        title: '按申请的详细信息',
        type: 2,
        content: ['test/get_help.html'],
        area: ['800px', '500px'],
        btn: ['ok'],

    });
}
function left_rectClick() {
    layer.open({
        title: '按订单的详细信息',
        type: 2,
        content: ['test/order_decribe.html'],
        area: ['800px', '500px'],
        btn: ['ok'],

    });
}
function chat() {
    layer.open({
        title: '聊天',
        type: 2,
        content: ['test/chat.html'],
        area: ['800px', '620px'],
        btn: ['关闭'],

    });
}
function Login() {
    var index = layer.load(0, {
        shade: false
    }); //0代表加载的风格，支持0-2
}
function rectdelete() {
    layer.confirm('申请Z34724663433和所有相关的账户及交易将被永久删除。你真的想吗？', {
        icon: 5,
        title: '确认',
        area: ['300px', ''],
        btn: ['ok', '取消']
    },
    function(index) {
        //do something
        layer.close(index);
    });
};
function get_help_btn() {
    layer.confirm('test/sellMafuluo.html', {
        btn: ['下一步', '取消'],
        title: ['卖出马夫罗的申请', 'background:url(../3M_20160416/icon/filesave.png) no-repeat left center;padding-left:20px; margin-left:10px;color:#fff'],
        type: 2,
        area: ['920px', '260px']
    },
    function() {
        layer.open({
            type: 2,
            area: ['920px', '260px'],
            content: 'test/sellMafuluo_next.html',
            btn: ['<<返回', '取消', '下一步'],
            yes: function(index, layero) {},
            cancel: function(index) {},
            btn3: function(index, layero) {
                layer.open({
                    title: '得到帮助',
                    type: 2,
                    area: ['920px', '430px'],
                    content: 'test/get_help_thrid.html',
                    btn: ['<<返回', '取消', '下一步'],
                    yes: function(index, layero) {},
                    cancel: function(index) {},
                    btn3: function(index, layero) {
                        layer.open({
                            title: '得到帮助',
                            type: 2,
                            area: ['920px', '430px'],
                            content: 'test/get_help_fourth.html',
                            btn: ['<<返回', '取消', '下一步'],
                            yes: function(index, layero) {

},
                            cancel: function(index) {

},
                            btn3: function(index, layero) {
                                layer.alert('你的申请添加成功了。等待处理。', {
                                    icon: 0,
                                    title: '注意',
                                    skin: 'layer-ext-moon',
                                    btn: 'ok',
                                    yes: function(index, layero) {
                                        layer.closeAll();
                                    }
                                })
                            }
                        });
                    }
                });
            }
        });

    });
}
function put_help_btn() {
    layer.confirm('test/put_help_btn.html', {
        btn: ['下一页', '取消'],
        //按钮
        title: ['添加申请', 'background:url(../3M_20160416/icon/filesave.png) no-repeat left center;padding-left:20px; margin-left:10px;color:#fff'],
        type: 2,
        area: ['600px', ''],
        skin: 'layer-ext-moon'
    },
    function(index) {
        var checkbox = document.getElementById('layui-layer-iframe' + index).contentWindow.document.getElementById("chkCheck");
        if (checkbox.checked == true) {
            //			layer.close(index);
            var index = layer.open({
                type: 2,
                title: ['添加申请', 'background:url(../3M_20160416/icon/filesave.png) no-repeat left center;padding-left:20px; margin-left:10px;color:#fff'],
                shadeClose: true,
                shade: 0.8,
                area: ['600px', '500px'],
                content: 'test/add_apply.html',
                //iframe的url
                btn: ['<<返回', '取消', '下一步'],
                cancel: function(index, layero) { //或者使用btn1
                },
                cancel: function(index) { //或者使用btn2
                    //按钮【按钮二】的回调
                },
                btn3: function(index, layero) {

                    var result = layer.getChildFrame('body', index);
                    var selected = result.find('#radios [name="radio"]:checked').size();
                    if (selected != 0) {
                        var index2 = layer.open({

                            title: ['添加申请', 'background:url(../3M_20160416/icon/filesave.png) no-repeat left center;padding-left:20px; margin-left:10px;color:#fff'],
                            type: 2,
                            content: ['test/add_apply_next.html'],
                            area: ['600px', '500px'],
                            btn: ['<<返回', '取消', '下一步'],
                            cancel: function(index, layero) { //或者使用btn1
                                //按钮【按钮一】的回调
                            },
                            cancel: function(index) { //或者使用btn2
                                //按钮【按钮二】的回调
                            },
                            btn3: function(index, layero) {
                                //								var index2Body = layer.getChildFrame('body',index2);
                                //								index2body.find('');
                                layer.open({
                                    title: ['添加申请', 'background:url(../3M_20160416/icon/filesave.png) no-repeat left center;padding-left:20px; margin-left:10px;color:black'],
                                    type: 2,
                                    content: ['test/add_apply_third.html'],
                                    area: ['600px', '500px'],
                                    btn: ['<<返回', '取消', '下一步'],
                                    cancel: function(index, layero) { //或者使用btn1
                                        //按钮【按钮一】的回调
                                    },
                                    cancel: function(index) { //或者使用btn2
                                        //按钮【按钮二】的回调
                                    },
                                    btn3: function(index, layero) {

                                        /*  layer.msg('你的申请添加成功了。等待处理。', {
                                            icon: 0
                                        });*/
                                        layer.alert('你的申请添加成功了。等待处理。', {
                                            icon: 0,
                                            title: '注意',
                                            skin: 'layer-ext-moon',
                                            btn: 'ok',
                                            yes: function(index, layero) {
                                                layer.closeAll();
                                            }
                                        })
                                    }
                                });
                            }
                        });
                    } else {
                        layer.alert('请选择其中一个选项', {
                            icon: 2,
                            title: '注意',
                            btn: 'ok',
                            skin: 'layer-ext-moon' //该皮肤由layer.seaning.com友情扩展。关于皮肤的扩展规则，去这里查阅
                        })
                    }

                }
            });
        } else {
            layer.alert('你需要同意', {
                title: '注意',
                icon: 2,
                btn: 'ok',
                skin: 'layer-ext-moon' //该皮肤由layer.seaning.com友情扩展。关于皮肤的扩展规则，去这里查阅
            })
        }
    });
}
function saveset() {
    layer.alert('设置被保存', {
        title: ' ',
        btn: '',
        time: 5000,
        offset: 'rb'
    })
}
function setupBtn() {
   // layer.open({
//        title: '创建询问',
//        type: 2,
//        content: ['test/setUp_page.html'],
//        area: ['800px', '500px'],
//        btn: ['创建', '取消']
//    },
//    function() {
//		
//});
  layer.confirm('test/setUp_page.html', {
        btn: ['创建', '取消'],
        title: ['创建询问'],
        type: 2,
        area: ['800px', '500px']
    },
    function() {
       layer.open({
        title: '创建询问',
        type: 2,
        content: ['test/setUp_page2.html'],
        area: ['800px', '500px'],
       btn: ['保存', '关闭'],
    });

    });
}
function Loadings() {
    layer.load();
    setTimeout(function() {
        layer.closeAll('loading');
    },
    2000);
}
function Loadings2() {
    layer.alert('因为有大量的工作，所以需要花费我们三天的时间来在你的个人主页里显示旧马夫罗', {
        title: '注意',
        area: ['400px', ''],
        btn: 'ok',
        skin: 'layer-ext-moon' //该皮肤由layer.seaning.com友情扩展。关于皮肤的扩展规则，去这里查阅
    })
}
function line() {
    layer.open({
        title: 'A账户业务38288191204',
        type: 2,
        content: ['test/Aaccount.html'],
        area: ['1000px', '500px'],
        btn: ['关闭']
    });
}
function future() {
    layer.open({
        title: 'A账户业务38288191204',
        type: 2,
        content: ['test/future.html'],
        area: ['500px', '300px']
 });
}
function dream() {
    layer.open({
        title: 'A382881912044',
        type: 2,
        content: ['test/dream.html'],
        area: ['500px', '330px'],
        btn: ['保存', '关闭']
    });
}
function Loadings3() {
    layer.msg('处理中，请稍等.....', {
        icon: 16
    });
}
function payment() {
     layer.confirm('test/payment.html', {
		type:2,
        icon: 5,
        title: '确认执行订单',
        area: ['640px', '500px'],
        btn: ['下一步', '取消']
    },
    function(index) {
       layer.open({
        title: '确认执行订单',
        type: 2,
        content: ['test/paymentAgain.html'],
        area: ['640px', '500px'],
        btn: ['<<返回', '取消','下一步'],
		 yes: function(index, layero) {
          },
         can0cel: function(index) {
         },
         btn3:function(index, layero) {
			 layer.alert('订单提交成功！', {
        icon:0,
        title: '注意',
        skin: 'layer-ext-moon',
        btn: 'ok',
        yes: function(index, layero) {
            layer.closeAll();
        }
    })
      }
    });
    });
}
function refuse() {
    layer.alert('我不想参与了！', {
        icon: 0,
        title:'注意',
        skin:'layer-ext-moon',
        btn:'ok',
        yes: function(index, layero) {
          layer.closeAll();
        }  })
}
function sure() {
    layer.alert('确认收到资金！', {
        icon: 0,
        title:'确认',
        skin:'layer-ext-moon',
        btn:['ok','Cancel'],
        yes: function(index, layero) {
          layer.closeAll();
        }  })
}
function deletebar(){
	layer.alert('您确定要删除录象吗？?', {
        icon: 0,
        title:'确认',
        skin:'layer-ext-moon',
        btn:['ok','取消'],
        yes: function(index, layero) {
          layer.closeAll();
        }  })
}
	function show_hide(trid){
		if(trid.style.display=="none"){
	       trid.style.display="block"; 
		   hw.style.display="block";
		}else{
			trid.style.display="none";
		}
}
function show_hide2(trid){
		if(trid.style.display=="none"){
	       trid.style.display="block"; 
		   hw.style.display="block";
		}else{
		}
}
	function show_hide3(trid){
		if(trid.style.display=="none"){
	       trid.style.display="block"; 
		   page.style.display="none";
		}else{
			trid.style.display="none";
			page.style.display="block";
		}
}
function change2(){
	  layer.alert('对不起，该功能暂时停用', {
        icon: 0,
        title:'注意',
        skin:'layer-ext-moon',
        btn:'ok',
        yes: function(index, layero) {phone()
          layer.closeAll();
        }  })
}
function phonec(){
	  layer.open({
        title: '改动',
        type: 2,
        content: ['test/change.html'],
        area: ['500px', '330px'],
        btn: ['保存', '关闭']
    });
}
function leader(){
	 layer.confirm('注意！作领导人为您的经理，您给他完全访问您的帐户！关于经历的更多信息见这里', {
        btn: ['下一步', '取消'],
        title: ['确认'],
        area: ['300px', '']
    }
)
}
function addzj(){
	 layer.open({
        title: '添加掌机',
        type: 2,
        content: ['test/addzj.html'],
        area: ['400px', '280px'],
        btn: ['保存', '关闭']
    });
}

