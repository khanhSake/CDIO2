(function ($) {
    $(function () {
        // reload captcha khi modal show
        $('#loginModal').on('shown.bs.modal', function () {
            $('#captchaImage').attr('src', window.appSettings.captchaUrl + '?' + Date.now());
        });

        // click vào reload captcha
        $('#loginModal').on('click', '#captchaImage', function () {
            $(this).attr('src', window.appSettings.captchaUrl + '?' + Date.now());
        });

        // submit login
        $('#loginModal').on('click', '#btnLogin', function (e) {
            e.preventDefault();
            var $form = $('#loginForm');
            $.post(window.appSettings.loginUrl, $form.serialize(), function (res) {
                if (res.success) {
                    $('#loginModal').modal('hide');
                    location.reload();
                } else {
                    $('#loginError').text(res.message);
                    $('#captchaImage').click();
                }
            });
        });
    });
})(jQuery);
