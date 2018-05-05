
//提供帮助
function Offer_Help() {
    if ($('#txtSQMoneyOff').val().Trim() == "") {
        v5.error('援助金额不能为空', '1', 'true');
        return;
    }
    else {
        var reg1 = /^\d+$/;
        if (!reg1.test(parseInt($('#txtSQMoneyOff').val()))) {
            v5.error('援助金额应该为正数', '1', 'true');
            return;
        }
    }
    verifypsd(function () {
        $.ajax({
            type: 'post',
            url: '/Mafull/OfferHelp.aspx?Action=add',
            data: { txtSQMoneyOff: $('#txtSQMoneyOff').val(), offerrdo: $('#offerrdo').val() },
            success: function (info) {
                info = info.split('*')[1];
                if (info == 0) {
                    v5.alert('提交申请成功，请等待系统为您匹配', '2', 'true');
                    setTimeout(function () {
                        v5.clearall();
                        callhtml('../Mafull/OfferHelpList.aspx', '提供援助列表 ');
                    }, 2000);
                }
                else {
                    v5.alert(info, '2', 'true');
                }
            }
        });
    });
}

//获得帮助
function Get_Help() {
    if ($('#txtSQMoneyGet').val().Trim() == "") {
        v5.error('申请金额不能为空', '1', 'true');
        return;
    }
    else {
        var reg1 = /^\d+$/;
        if (!reg1.test(parseInt($('#txtSQMoneyGet').val()))) {
            v5.error('申请金额应该为正数', '1', 'true');
            return;
        }
    }
    verifypsd(function () {
        $.ajax({
            type: 'post',
            url: '/Mafull/GetHelp.aspx?Action=add',
            data: { txtSQMoneyGet: $('#txtSQMoneyGet').val(), rdo: $("#rdo").val() },
            success: function (info) {
                info = info.split('*')[1];
                if (info == 0) {
                    v5.alert('提交申请成功，请等待系统为您匹配', '2', 'true');
                    setTimeout(function () {
                        v5.clearall();
                        callhtml('../Mafull/GetHelpList.aspx', '获得帮助列表');
                    }, 2000);
                }
                else {
                    v5.alert(info, '2', 'true');
                }
            }
        });
    });
}


function GetHelpList(type, selector) {
    $.ajax({
        url: "/Mafull/Handler/TradeAllList.ashx",
        data: { type: type },
        type: "post",
        dataType: "text",
        success: function (data) {
            $(selector).html(data);
        }
    });
}