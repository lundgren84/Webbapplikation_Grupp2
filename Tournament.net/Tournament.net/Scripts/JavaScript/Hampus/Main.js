//Namespace
var HL = HL || {};
// Divs
HL.Top_Div_In_Index = $('#Top_Div_In_Index');
HL.Top_Div_In_Index.removeClass('hide'); HL.Top_Div_In_Index.hide();
HL.Spinner = $('#Spinner');
HL.Spinner.removeClass('hide'); HL.Spinner.hide();
// Buttons
HL.AccountOptions_btn = $('#AccountOptions_btn');





$(document).ready(function () {

    //Clicks
    HL.AccountOptions_btn.on("click", function () {
        HL.Spinner.toggle('300');
        $.ajax({
            dataType: "html",
            type: "GET",
            url: "/Account/Options",
            success: function (data) {
               
                var html = data;              
                HL.Top_Div_In_Index.html(html);
                HL.Spinner.toggle('300');
                HL.Top_Div_In_Index.toggle('500');
              
            }
        });

    });
});