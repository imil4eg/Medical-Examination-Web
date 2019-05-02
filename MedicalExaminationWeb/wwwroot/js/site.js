// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function validateAuthorization() {
    var login = $('#UserName').val();

    if (login == "") {
        $("#loginError").text("Логин не может быть пустым.");
        $("#loginError").show();
        return false;
    }

    var password = $("#Password").val();

    if (password == "") {
        $("#passwordError").text("Пароль не может быть пустым.");
        $("#loginError").hide();
        $("#passwordError").show();
        return false;
    }

    return true;
}