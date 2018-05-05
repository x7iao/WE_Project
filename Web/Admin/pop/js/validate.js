//验证方式及错误提示信息
var errorInfo = {
    "require": "该项不能为空",
    "digit": "请填写正确的数字",
    "integer": "请填写整数",
    "letter": "只能填写英文字母",
    "minlength": "字符长度不能少于@个字符",
    "maxlength": "字符长度不能多于@个字符",
    "pwdrep": "两次输入的密码不一致",
    "email": "邮箱格式不正确"
};
var reg_integer = /^[0-9]*[1-9][0-9]*$/;
var reg_email = /^(\w)+(\.\w+)*@(\w)+((\.\w{2,3}){1,3})$/;

//验证正则表达式
function validateRegExp(type, value) {
    //var reg = new RegExp(type);
    return type.test(value);
}

//添加错误信息到页面
function addErrorInfo(obj, info) {
    var next = $(obj).next();
    if (next.hasClass("error")) {
        if (info == "") {
            next.remove();
        } else {
            next.html(info);
        }
    } else {
        if (info != "") {
            $(obj).after($("<lable class='error'>" + info + "</lable>"));
        }
    }
}

//获取提示信息
function defaultInfo(type, info, isnumber) {
    if (info != "") {
        if (isnumber) {
            return errorInfo[type].replace("@", info);
        }
        return info;
    } else {
        return errorInfo[type];
    }
}

//绑定事件
$(function () {
    $("input[validate]").blur(function () {
        validateF(this);
    });
});

function validateF(obj) {
    var data = $(obj).attr("validate");
    var value = $(obj).val();
    data = eval("(" + data + ")");
    for (var key in data) {
        var error = validateFunc(obj, key, data[key]);
        if (error != "") {
            //添加
            addErrorInfo(obj, error);
            break;
        } else {
            addErrorInfo(obj, error);
        }
    }
}

//验证
function validateFunc(obj, type, info) {
    var error = "";
    var value = $(obj).val();
    switch (type) {
        case "require":
            error = v_require(value, type, info);
            break;
        case "minlength":
            error = v_minlength(value, type, info);
            break;
        case "pwdrep":
            error = v_pwdrep(obj, type, info);
            break;
        case "email":
            error = v_email(value, type, info);
            break;
        default:
            break;
    }
    return error;
}

//必填验证
function v_require(value, type, info) {
    if (value == "") {
        return defaultInfo(type, info);
    }
    return "";
}

//最短长度验证
function v_minlength(value, type, info) {
    if (validateRegExp(reg_integer, value)) {
        if (value.length < info) {
            return defaultInfo(type, info, true);
        }
    }
    return "";
}

//密码一致验证
function v_pwdrep(obj, type, info) {
    var first = $(obj).prev("input[type='password']");
    var list = $("input[type='password']");
    for (var i = 0; i < list.length; i++) {
        if ($(list[i]).attr("id") == $(obj).attr("id")) {
            if ($(list[i - 1]).val() != $(obj).val()) {
                return defaultInfo(type, info);
            }
        }
    }
    return "";
}

//邮箱验证
function v_email(value, type, info) {
    if (!validateRegExp(reg_email, value)) {
        return defaultInfo(type, info);
    }
    return "";
}
