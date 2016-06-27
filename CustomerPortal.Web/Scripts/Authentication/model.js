// view model initialization
var ViewModel = {
    userName: ko.observable(""),
    password: ko.observable(""),
    rememberMe: ko.observable("")
};


//set validation defaults
$.validator.setDefaults({
    errorPlacement: function (error, element) {
        error.appendTo("#invalid-" + element.attr("id"));
    }
});

//apply validation rules
$("#frmLogin").validate({
    rules: {
        userName: {
            required: true,
            email: true,
            maxlength:80
        },
        password: {
            required: true,
            minLength: 4,
            maxLength: 20
        }
    }
});
