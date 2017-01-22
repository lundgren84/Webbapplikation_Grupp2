////Namespace
var HB = HB || {};
//Buttons

HB.Start_btn = $("#Start_btn");

////Divs
HB.StartButtonDiv = $('#UserChoice');
////Buttons
//HB.Start_btn = $('#Start_btn');

$(document).ready(function () {

    HB.Start_btn.on("click", function () {
        alert("Klick!");
        getHtmlToGameTypeMenuDiv('/Main/GameTypeSelection');
    });

    function hideElement() {
        alert("Inne!");
        document.getElementById("UserChoice").className = "hidden";
        document.getElementById("SelectType").className = "unhidden";
    }

    function getHtmlToGameTypeMenuDiv(url) {
        alert("GetHTml");
        HL.Spinner.toggle('300');
        $.ajax({
            dataType: "html",  // dataType = Wath i get from the action       
            type: "GET",   // type = Wath im gona do with the controler         
            url: url,   // url = controler/action           
            success: function (data) {    // if success i run this function and "data" is wath the action returns

                let html = data;
                HB.StartButtonDiv.html(html);
                HL.Spinner.toggle('300');
                //HL.Top_Div_In_Index.toggle('500');
            }
        });
    }

})