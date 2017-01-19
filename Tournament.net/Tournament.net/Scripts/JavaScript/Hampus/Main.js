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
    HL.IndexTopDivOpen = false;
    // -- Clicks --
    //Options
    HL.AccountOptions_btn.on("click", function () {     
        getAccountPartials('/Account/Options');
    });
    //Register
    HL.AccountRegister_btn.on('click', function () {
        getAccountPartials('/Authentication/Register');
    });
    //Login
    HL.AccountLogin_btn.on('click', function () {
        getAccountPartials('/Authentication/Login');
    });

    function getAccountPartials(url) {
        HL.Top_Div_In_Index.hide();
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