﻿// -##- Namespace -##-
var HL = HL || {};

// -##- Divs -##-
HL.Top_Div_In_Index = $('#Top_Div_In_Index');
HL.Top_Div_In_Index.removeClass('hide'); HL.Top_Div_In_Index.hide();
HL.Spinner = $('#Spinner');
HL.Spinner.removeClass('hide'); HL.Spinner.hide();
// -##- Buttons -##-
HL.AccountOptions_btn = $('#AccountOptions_btn');
HL.AccountRegister_btn = $('#AccountRegister_btn');
HL.AccountLogin_btn = $('#AccountLogin_btn');

$(document).ready(function () {
    // -##- Variables -##-
    HL.OpenInIndexDiv = "";

    // -##- Clicks -##-
    //Options
    HL.AccountOptions_btn.on("click", function () {
        toggleIndexTopDiv('/Account/Options', 'options');
    });

    //Register
    HL.AccountRegister_btn.on('click', function () {
        toggleIndexTopDiv('/Authentication/Register', 'Register');
    });

    //Login
    HL.AccountLogin_btn.on('click', function () {
        toggleIndexTopDiv('/Authentication/Login', 'Login');
    });

    // -##- Functions -##-
    // function to get html to top div in index
    function getHtmlToTopIndexDiv(url) {
        HL.Spinner.toggle('300');
        $.ajax({
            dataType: "html",  // dataType = Wath i get from the action       
            type: "GET",   // type = Wath im gona do with the controler         
            url: url,   // url = controler/action           
            success: function (data) {    // if success i run this function and "data" is wath the action returns

                let html = data;
                HL.Top_Div_In_Index.html(html);
                HL.Spinner.toggle('300');
                HL.Top_Div_In_Index.toggle('500');
            }
        });
    }
    // function to toggle top div in index right
    function toggleIndexTopDiv(url, type) {
        if (HL.OpenInIndexDiv === type) {
            HL.OpenInIndexDiv = "";
            HL.Top_Div_In_Index.toggle('500');
        }
        else if (HL.OpenInIndexDiv === "") {
            getHtmlToTopIndexDiv(url);
            HL.OpenInIndexDiv = type;
        } else {
            HL.Top_Div_In_Index.toggle('200');
            setTimeout(function () {
                getHtmlToTopIndexDiv(url);
            }, 220);
            HL.OpenInIndexDiv = type;
        }
    }

});