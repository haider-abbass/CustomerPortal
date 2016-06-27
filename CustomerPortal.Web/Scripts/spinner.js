//Show spinner on ajax send
$(document).ajaxSend(function () {
    $("#spinner").show();
});

//Show spinner on ajax complete
$(document).ajaxComplete(function () {
    $("#spinner").hide();
});


function showSpinner() {
    $("#spinner").show();
}

function hideSpinner() {
    $("#spinner").hide();
}

function toggleSpinner() {
    $("#spinner").toggle();
}