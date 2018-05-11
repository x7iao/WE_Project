

//聊天
function chat(code) {
    layer.open({
        title: '聊天',
        type: 2,
        content: ['/Mafull/chat/chat.aspx?id=' + code],
        area: ['900px', '550px']
    });
}


