
    $('.warp2').hide();
var PlayersFromParticipants = new Array();

function addPlayerToPlayerList(index, playerName) {
    PlayersFromParticipants[index] = playerName;
}
function checkIfGameIsReady(numbersOfPlayersNeeded, PlayerList) {
    let gameIsReady = true;
    for (var i = 0; i < numbersOfPlayersNeeded; i++) {
        if (PlayerList[i] === undefined) {
            gameIsReady = false;
            break;
        }
    }
    return gameIsReady;
}
function gerUrlByType(type) {
    let rightUrl = "";
    if (type === "Tournament") {
        rightUrl = "/Tournament/TournamentBracket";
    }
    else {
        rightUrl = "/Main/HighscoreBracket";
    }
    console.log("Game type= "+type);
    return rightUrl;
}

$(document).ready(function () {

    // -- Start Game --
    var ParticipantsPlay_btn = $('#ParticipantsPlay_btn')
    var numbersOfPlayers = parseInt(ParticipantsPlay_btn.attr("data-PlayerNumber"));
    var startGamebtns_errorDiv = $('#startGamebtns_errorDiv');
    var gameType = sessionStorage.gameType;

    ParticipantsPlay_btn.on("click", function () {
        var rightUrl = gerUrlByType(gameType);
        startGamebtns_errorDiv.html("");
        if (checkIfGameIsReady(numbersOfPlayers, PlayersFromParticipants)) {
            // Start Game
            console.log(" Start Game")
            var playerData = { Players: PlayersFromParticipants };
            /// FIX Tournament shud have a post and highscore a get

            //if (gameType === "Tournament") {
            //    window.location.href = rightUrl;

            //} else {
                //Highscore
                $.ajax({
                    url: rightUrl,
                    type: "GET",
                    dataType: "html",
                    data: playerData,
                    traditional: true,
                    success: function (data) {

                        let html = data;
                        let StartButtonDiv = $('#UserChoice');
                        StartButtonDiv.html(html);
                    },
                    error: function (data) {
                        alert("ERROR: " + data);
                    }
                });
            //}
        }
        else {
            // Game not ready
            console.log("Game not ready")
            startGamebtns_errorDiv.html("All PlayerSpots need to be filled! If u want other amount of players you need to restart from begining!!");
        }
    })

    // -- Add Players to game __
    var checkUser_btn = $('.checkUser_btn');

    checkUser_btn.on("click", function () {


        startGamebtns_errorDiv.html("");
        //var form = $(this).parents('form:first');
        //var  = $(this).attr("data-id")
        var iAmThis = $(this);
        var wrap1 = iAmThis.closest('.wrap');
        var password = iAmThis.closest('.wrap').find('.passwordInput').val();
        var username = iAmThis.closest('.wrap').find('.usernameInput').val();
        var errorDivinParticipants = iAmThis.closest('.wrap').find('.errorDiv');
        var particiPants_DivIndex = iAmThis.attr("data-id");
        console.log("Form Index= " + particiPants_DivIndex);
        console.log("Username= " + username);
        console.log("Password= " + password);




        $.ajax({
            url: "/Authentication/CheckLogin",
            type: "POST",
            dataType: "json",
            data: { 'username': username, 'password': password },
            success: function (data) {
                errorDivinParticipants.html("");
                let Players = data;

                console.log(data.UserName)
                var warp2 = wrap1.closest(".alfaWrap").find(".warp2");

                if ((password === undefined || password === "") && data.UserName === "Guest" && username.length > 0) {
                    // Add as guest
                    let userName = username + "(" + data.UserName + ")";
                    warp2.find(".img_From_Participants_SelectedAccount").attr("src", data.ImgURL)
                    warp2.find(".Label_for_Username_img_From_Participants_SelectedAccount").html(userName)
                    warp2.toggle();
                    wrap1.hide();
                    addPlayerToPlayerList(particiPants_DivIndex, userName);
                    console.log("Add as guest")

                }
                else if (data.UserName !== "Guest") {
                    // Add Registerd user
                    warp2.find(".img_From_Participants_SelectedAccount").attr("src", data.ImgURL)
                    warp2.find(".Label_for_Username_img_From_Participants_SelectedAccount").html(data.UserName)
                    warp2.toggle();
                    wrap1.hide();
                    addPlayerToPlayerList(particiPants_DivIndex, data.UserName);
                    console.log("Add as Registerd user")
                }
                else {
                    if (username.length < 1)
                        errorDivinParticipants.html("You need a username!");
                    else
                        errorDivinParticipants.html("Username or password wrong!");
                }
            },
            error: function (data) {
                alert("ERROR: " + data);
            }
        });

    })
});
