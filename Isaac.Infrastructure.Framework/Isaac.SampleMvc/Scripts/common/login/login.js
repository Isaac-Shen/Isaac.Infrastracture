$('#button-login').on('click', function () {
    var name = $('#inputUserId').val();
    var pwd = $('#inputPassword').val();

    //检测网络状态
    if (!window.navigator.onLine) {
        return;
    }

    if (name.length * pwd.length === 0) {
        showErrorMessage("无法在用户名密码缺失的情况下登陆!请填写用户名密码!");
        return;
    }

    $.post('/Login/Login', { userId: name, password: pwd, type: 0 }, function (loginResult) {
        if (loginResult.success) {
            location.href = loginResult.result.url;
        }
        else {
            showErrorMessage(loginResult.result + ": 不合法的登陆!请检查用户名密码!");
        }
    });
});

function showErrorMessage(message) {
    $(".errorMsg").find("span").text(message);
    $(".errorMsg").fadeIn("fast").delay(2000).fadeOut("slow");
}