////Namespace
var HB = HB || {};
//Buttons

HB.Start_btn = $("#Start_btn");
HB.Tournament_btn = $("#Tournament");
HB.Highscore_btn = $("#Highscore");
// Contenders buttons

HB.One_btn= $("#1Button");
HB.Two_btn = $("#2Button");
HB.Three_btn = $("#3Button");
HB.Four_btn = $("#4Button");
HB.Five_btn = $("#5Button");
HB.Six_btn = $("#6Button");
HB.Seven_btn = $("#7Button");
HB.Eight_btn = $("#8Button");

////Divs
HB.StartButtonDiv = $('#UserChoice');
////Buttons
//HB.Start_btn = $('#Start_btn');

$(document).ready(function () {

    var clickSound = new Audio("\Items/Sounds/sfx_sounds_interaction3.wav");

 

    var nbrOfPlayers = 0;

    HB.Start_btn.on("click", function () {
        clickSound.play();
        getHtmlToGameTypeMenuDiv('/Main/GameTypeSelection');
       

    })

    HB.Tournament_btn.on("click", function () {
        clickSound.play();
        getHtmlToGameTypeMenuDiv('/Main/NbrOfPlayersSelection');
    })

    HB.Highscore_btn.on("click", function () {
        clickSound.play();
        getHtmlToGameTypeMenuDiv('/Main/NbrOfPlayersSelection');
    });

    HB.One_btn.on("click", function () {
        nbrOfPlayers = 1;
        getHtmlToGameTypeMenuDiv('/Main/ContendersForm');    
    })

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

    function getHtmlToNbrOfPlayersDiv(url,number) {
        HL.Spinner.toggle('300');
        $.ajax({
            dataType: "html",  // dataType = What I get from the action       
            type: "POST",   // type = What im gonna do with the controller         
            url: url,   // url = controller/action 
            data: number,
            success: function (data) {    // if success i run this function and "data" is what the action returns

                let html = data;
                HB.StartButtonDiv.html(html);
                HL.Spinner.toggle('300');
                //HL.Top_Div_In_Index.toggle('500');
            }
        });
    }

})