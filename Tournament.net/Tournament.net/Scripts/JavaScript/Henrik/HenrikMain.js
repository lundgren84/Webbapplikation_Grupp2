////Namespace
var HB = HB || {};
//Buttons
HB.Start_btn = $("#Start_btn");
HB.Tournament_btn = $("#Tournament");
HB.Highscore_btn = $("#Highscore");
HB.testbutton = $("#testbutton");
// Contenders buttons
HB.btns = $('.btns');
//participants buttons
HB.AddGuest = $(".AddGuest_btn");
//Add Score btns
HB.AddScore = $(".AddScore");
//input fields
HB.Score_field = $("#AddScores")
////Divs
HB.StartButtonDiv = $('#UserChoice');


$(document).ready(function () {

    var clickSound = new Audio("/Items/Sounds/sfx_sounds_interaction3.wav");
    var clickSound2 = new Audio("\Items/Sounds/Short Circuit-SoundBible.com-1450168875.wav");



    var nbrOfPlayers = 0;

    HB.AddGuest.one("click", function () {
        var newGuest = $(this).prev("input").val();
        AddNewGuest("/Tournament/ParticiPants", newGuest);
        $(this).css("background-color", "Green");

    });
    function AddNewGuest(url, username) {
        alert("hej");
        HL.Spinner.toggle('300');
        $.ajax({
            dataType: "html",  // dataType = What I get from the action       
            type: "POST",   // type = What im gonna do with the controller    
            data: { username: username },
            url: url,   // url = controller/action 
            success: function (data) {    // if success i run this function and "data" is what the action returns
                alert("player added");
                //let html = data;
                //HB.StartButtonDiv.html(html);
                HL.Spinner.toggle('300');

            }
        });
    }



    HB.AddScore.on("click", function () {
        var currentRow = $(this).closest("tr");
        var newHighScore = $(this).prev("input").val();
        var username = currentRow.find("td:eq(0)").html();
        AddNewScores("/Main/HighscoreBracket", newHighScore, username);
    
    });

    function AddNewScores(url, number, username) {

        HL.Spinner.toggle('300');
        $.ajax({
            dataType: "html",  // dataType = What I get from the action       
            type: "POST",   // type = What im gonna do with the controller    
            data: { number: number, username: username },
            url: url,   // url = controller/action 
            success: function (data) {    // if success i run this function and "data" is what the action returns

                let html = data;
                HB.StartButtonDiv.html(html);
                HL.Spinner.toggle('300');

            }
        });
    }





    HB.testbutton.on("click", function () {
        clickSound2.play();
        getHtmlToGameTypeMenuDiv('/Main/HighscoreBracket');
    });

    HB.Start_btn.on("click", function () {
        $('#Start_btn').addClass('greenButton').removeClass('userChoice');
        clickSound2.play();
        setTimeout(function () {
            getHtmlToGameTypeMenuDiv('/Main/GameTypeSelection');
            
           
        }, 220);
        
    });
    HB.Start_btn.on("mouseover", function () {
        clickSound.play();  
    });

    HB.Tournament_btn.on("click", function () {
        clickSound2.play();
        getHtmlToGameTypeMenuDiv('/Main/NbrOfPlayersSelection');
    });
    HB.Tournament_btn.on("mouseover", function () {
        clickSound.play();
    });

    HB.Highscore_btn.on("click", function () {
        clickSound2.play();
        getHtmlToGameTypeMenuDiv('/Main/NbrOfPlayersSelection');
    });
    HB.Highscore_btn.on("mouseover", function () {
        clickSound.play();
    });

 


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

    function getHtmlToNbrOfPlayersDiv(url, number) {

        HL.Spinner.toggle('300');
        $.ajax({
            dataType: "html",  // dataType = What I get from the action       
            type: "POST",   // type = What im gonna do with the controller    
            data: { number: number },
            url: url,   // url = controller/action 
            success: function (data) {    // if success i run this function and "data" is what the action returns

                let html = data;
                HB.StartButtonDiv.html(html);
                HL.Spinner.toggle('300');
              
            }
        });
    }
    

    HB.btns.on("click", function () {

        var selectednumber = $(this).attr('data-value')
        getHtmlToNbrOfPlayersDiv('/Main/NbrOfPlayersSelection', selectednumber);
    });

});

 
 //html
 //<input type="botton" class="btns" data-value="1" />
 //<input type="botton" class="btns" data-value="2" />

 //Javascript

