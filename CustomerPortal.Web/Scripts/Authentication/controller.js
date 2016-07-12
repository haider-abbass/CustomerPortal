
//apply MVVM bindings
$(document).ready(function() {
    ko.applyBindings(ViewModel);
    //focus first element
    $("#userName").focus();
});

    
    /* Form validation */
 /*   $('.login-form input[type="text"], .login-form input[type="password"], .login-form textarea').on('focus', function () {
        $(this).removeClass('input-error');
    });

    $('.login-form').on('submit', function (e) {
        $(this).find('input[type="text"], input[type="password"], textarea').each(function () {
            if ($(this).val() == "") {
                e.preventDefault();
                $(this).addClass('input-error');
            }
            else {
                $(this).removeClass('input-error');
            }
        });
    });
}); */


//Service Call
$("#btnLogin").click(function () {
    debugger;
    if ($("#frmLogin").valid()) {
        $("#btnLogin").attr("disabled", true);
        var payload = ko.toJS(ViewModel);
        var json = JSON.stringify(payload);
        $.ajax({
            url: "/umbraco/surface/authentication/loginuser/",
            cache: false,
            type: "POST",
            contentType: "application/json",
            data: json,
            success: function() {
                LoggedIn();
            },
            error: function(error) {
                window.alert("ErrorStatus " + error.status + "  StatusText " + error.statusText);
                $("#btnLogin").attr("disabled", false);
            }
        });
    }
});
        