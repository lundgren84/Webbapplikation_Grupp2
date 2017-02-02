var turn = 0;
var round = 0;


$(document).ready(function () {
    var round1Spots = data.NumbersOfPlayers;
    console.log("Round one's spots= " + round1Spots)

    var imgHeight = 0;
    //Buttons
    var btn_StartTournament = $('#btn_StartTournament');
    var fight_btn = $('#fight_btn');
    var btn_WIN_1 = $('#btn_WIN_1');
    var btn_WIN_2 = $('#btn_WIN_2');
    //Others
    var vsLabel = $('#vsLabel');
    //Players
    var champ1;
    var champ2;

    //Click Start-Button
    btn_StartTournament.on("click", function () {
        var currentRow = $('#row' + round);
        for (var i = 0; i < round1Spots; i++) {
            var spott = currentRow.find('#spott' + i)
            spott.find('.imgSpott').attr("src", data.Players[i].ImgURL);
            spott.find('.nameSpot').html(data.Players[i].UserName);
            imgHeight = parseInt(spott.find('.imgSpott').css("height"));
            console.log("imgHeight = " + imgHeight)
        }


    });
    // Click FIGHT
    fight_btn.on("click", function () {
        $('.Fighter').removeClass("Fighter");
        var currentRow = $('#row' + round);
        champ1 = currentRow.find('#spott' + turn);
        champ2 = currentRow.find('#spott' + (turn + 1));

        //Fighter1
        champ1.addClass("Fighter");
        var camp1Position = champ1.position();
        var btn1Top = Math.round(camp1Position.top) + (imgHeight / 2)
        btn_WIN_1.css("top", btn1Top);
        btn_WIN_1.css("left", camp1Position.left);

        //Fighter2
        champ2.addClass("Fighter");
        var camp2Position = champ2.position();
        var btn2Top = Math.round(camp2Position.top) + (imgHeight / 2)
        btn_WIN_2.css("top", btn2Top);
        btn_WIN_2.css("left", camp2Position.left);

        // VS Label
        var btwWidth = parseInt(btn_WIN_1.css("width"));
        vsLabel.css("top", btn2Top);
        vsLabel.css("left", (camp1Position.left + btwWidth + 20));
        turn += 2;
    });
});