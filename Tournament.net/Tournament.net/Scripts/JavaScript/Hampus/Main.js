//Namespace
var HL = HL || {};

// Divs
HL.Top_Div_In_Index = $('#Top_Div_In_Index');
HL.Top_Div_In_Index.removeClass('hide'); HL.Top_Div_In_Index.hide();
HL.Spinner = $('#Spinner');
HL.Spinner.removeClass('hide'); HL.Spinner.hide();
// Buttons
HL.AccountOptions_btn = $('#AccountOptions_btn');
HL.AccountRegister_btn = $('#AccountRegister_btn');
HL.AccountLogin_btn = $('#AccountLogin_btn');



$(document).ready(function () {
    // Variables
   
    HL.OpenInIndexDiv = "";
    // -- Clicks --
    //Options
    HL.AccountOptions_btn.on("click", function () {
        if (HL.OpenInIndexDiv === "options") {
            HL.OpenInIndexDiv = "";
            HL.Top_Div_In_Index.toggle('500');
        }
        else if (HL.OpenInIndexDiv === "") {
            getAccountPartials('/Account/Options');
            HL.OpenInIndexDiv = "options";
        }
        else {
            HL.Top_Div_In_Index.toggle('200');
            setTimeout(function () {
                getAccountPartials('/Account/Options');
            }, 220);

            HL.OpenInIndexDiv = "options";
        }
        
    });
    //Register
    HL.AccountRegister_btn.on('click', function () {

        if (HL.OpenInIndexDiv === "Register") {
            HL.OpenInIndexDiv = "";
            HL.Top_Div_In_Index.toggle('500');
        }
        else if (HL.OpenInIndexDiv === "") {
            getAccountPartials('/Authentication/Register');
            HL.OpenInIndexDiv = "Register";
        }
        else {
            HL.Top_Div_In_Index.toggle('200');
            setTimeout(function () {
                getAccountPartials('/Authentication/Register');
            }, 220);

            HL.OpenInIndexDiv = "Register";
        }


        //getAccountPartials('/Authentication/Register');
    });
    //Login
HL.AccountLogin_btn.on('click', function () {

    if (HL.OpenInIndexDiv === "Login") {
        HL.OpenInIndexDiv = "";
        HL.Top_Div_In_Index.toggle('500');
    }
    else if (HL.OpenInIndexDiv === "") {
        getAccountPartials('/Authentication/Login');
        HL.OpenInIndexDiv = "Login";
    }
    else {
        HL.Top_Div_In_Index.toggle('200');
        setTimeout(function () {
            getAccountPartials('/Authentication/Login');
        }, 220);

        HL.OpenInIndexDiv = "Login";
    }

    //getAccountPartials('/Authentication/Login');

    });

    function getAccountPartials(url) {    
        HL.Spinner.toggle('300');

        $.ajax({
            dataType: "html",
            type: "GET",
            url: url,
            success: function (data) {

                let html = data;
                HL.Top_Div_In_Index.html(html);
                HL.Spinner.toggle('300');
                HL.Top_Div_In_Index.toggle('500');
            }
        });
    }

});