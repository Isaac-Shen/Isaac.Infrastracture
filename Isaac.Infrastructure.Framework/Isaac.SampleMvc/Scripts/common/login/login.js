$('#button-login').on('click', function () {
    var name = $('#inputUserId').val();
    var pwd = $('#inputPassword').val();

    //检测网络状态
    if (!window.navigator.onLine) {
        return;
    }

    $.post('/Login/Login', { userId: name, password: pwd, type: 0 }, function (loginResult) {
        if (d.success) {
            location.href = loginResult.result.url;
        }
    });
});