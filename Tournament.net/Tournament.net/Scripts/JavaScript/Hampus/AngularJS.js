var HL = HL || {};
HL.NumberOFPlayers = 0;
HL.CurrentRound = 0;
HL.Rounds = 0;
HL.Players;



myApp.factory("TournamentFactory", function () {
    var factory = {};
    HL.Round1 = [];
    HL.Round2 = [];
    HL.Round3 = [];
    HL.Round4 = [];

    factory.getRound = function (roundNr) {
        if (roundNr === 2) {
            return HL.Round2;
        }
        return null;
    }
  
    factory.GetRoundsArray = function (Rounds) {
        let RoundArray = [];

        for (var i = 0; i < Rounds; i++) {
            RoundArray.push(i);
        }
        return RoundArray;
    }


    return factory;
});
var nr = 0;
controllers.TournamentBracketController = function ($scope, TournamentFactory) {
    $scope.init = function (Tournament) {
        $scope.Tournament = Tournament;
        $scope.Players = Tournament.Players;
        GetNumberOfPlayers($scope.Tournament.NumbersOfPlayers);
        GetNumberOfRounds($scope.Tournament.Rounds);
        $scope.TournamentRounds = TournamentFactory.GetRoundsArray($scope.Tournament.Rounds);
        HL.Players = Tournament.Players;
        $scope.Round0 = GetFirstRound(Tournament.Players);
        checkRound($scope.Round0);
    }


    $scope.START = function () {
        $('#btn_Shuffle').fadeOut();
    }
    $scope.SHUFFLE = function () {
        $scope.Round0 = shuffle($scope.Round0);    
        checkRound($scope.Round0);
    }

    $scope.Round1 = HL.Round1;
};
function checkRound(Round) {
    let i = Round.length
    if (i % 2 !== 0) {
        console.log("Odd round ")
        addToNextRound(Round[Round.length-1])
    }
}
function addToNextRound(FreeWinner) {
    switch (HL.CurrentRound) {
        case 0:
            HL.Round1[0] = FreeWinner;
            break;
        case 1:
            HL.Round1[2] = FreeWinner;
            break;
        case 2:
            HL.Round1[3] = FreeWinner;
            break;
        case 3:
            HL.Round1[4] = FreeWinner;
            break;
        case 4:
            HL.Round1[5] = FreeWinner;
            break;
        case 5:
            HL.Round1[6] = FreeWinner;
            break;
        case 6:
            HL.Round1[7] = FreeWinner;
    }
}
function GetFirstRound(Players) {
    let firstRound = [];
    for (var i = 0; i < Players.length; i++) {
        firstRound.push(Players[i])
    }
    return firstRound
}
function shuffle(scopePlayers) {
    let players = scopePlayers
    let nr = 0;
    while (nr < 100) {
        var random = Math.floor((Math.random() * players.length));
        let holder = players[0]
        players[0] = players[random]
        players[random] = holder;
        nr++;
    }
    return players;
}
function GetNumberOfRounds(number) {
    HL.Rounds = number;
    console.log("Rounds= " + number);
}
function GetNumberOfPlayers(number) {
    HL.NumberOFPlayers = number;
    console.log("Players= " + number);
}

$(document).ready(function () {







});