﻿////Namespace
var HB = HB || {};
//Buttons

HB.Start_btn = $("#Start_btn");

////Divs
HB.StartButtonDiv = $('#UserChoice');
////Buttons
//HB.Start_btn = $('#Start_btn');

$(document).ready(function () {

    HB.Start_btn.on("click", function () {
        getHtmlToGameTypeMenuDiv('/Main/GameTypeSelection');
    });

    function hideElement() {
        document.getElementById("UserChoice").className = "hidden";
        document.getElementById("SelectType").className = "unhidden";
    }

    function getHtmlToGameTypeMenuDiv(url) {
        HL.Spinner.toggle('300');
        $.ajax({
            dataType: "html",  // dataType = What I get from the action       
            type: "GET",   // type = What im gonna do with the controller         
            url: url,   // url = controller/action           
            success: function (data) {    // if success i run this function and "data" is what the action returns

                let html = data;
                HB.StartButtonDiv.html(html);
                HL.Spinner.toggle('300');
                //HL.Top_Div_In_Index.toggle('500');
            }
        });
    }

})