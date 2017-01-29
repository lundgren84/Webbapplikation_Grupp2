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
    factory.ToNextRound = function (Player) {
        HL.Round2.push(Player);
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
        $scope.Round0 = Tournament.Players;
    }



    $scope.SHUFFLE = function () {
        $scope.Round0 = shuffle($scope.Players);
    }

    $scope.Round2 = TournamentFactory.getRound(2);

    $scope.ToNextRound = function () {
        TournamentFactory.ToNextRound($scope.Players[nr]);
        nr++;
    }
};
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