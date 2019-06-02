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

$(function() {
    $('#firstQuestion').click(firstQuestionClick);
    $('#sixQuestion').click(sixQuestionClick);
    $('#nineQuestion').click(nineQuestionClick);
    $('#tenQuestion').click(tenQuestionClick);
    $('#nineteenQuestion').click(twentyQuestionClick);
});

function tenQuestionClick() {
    if (this.checked) {
        $("#tenQuestionAddition").removeAttr("disabled");
    } else {
        $("#tenQuestionAddition").attr("disabled", true);
        $("#tenQuestionAddition").prop("checked", false);
    }
}

function firstQuestionClick() {
    if (this.checked) {
        $("#firstQuestionAddition").removeAttr("disabled");
    } else {
        $("#firstQuestionAddition").attr("disabled", true);
        $("#firstQuestionAddition").prop("checked", false);
    }
}

function sixQuestionClick() {
    if (this.checked) {
        $("#sixQuestionAddition").removeAttr("disabled");
    } else {
        $("#sixQuestionAddition").attr("disabled", true);
        $("#sixQuestionAddition").prop("checked", false);
    }
}

function nineQuestionClick() {
    if (this.checked) {
        $("#nineQuestionAddition").removeAttr("disabled");
    } else {
        $("#nineQuestionAddition").attr("disabled", true);
        $("#nineQuestionAddition").val('');
    }
}

function twentyQuestionClick() {
    if (this.checked) {
        $("#twentyQuestionAddition").removeAttr("disabled");
    } else {
        $("#twentyQuestionAddition").attr("disabled", true);
        $("#twentyQuestionAddition").val('');
    }
}