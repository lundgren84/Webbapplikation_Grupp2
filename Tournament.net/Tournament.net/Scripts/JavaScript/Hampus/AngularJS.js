var HL = HL || {};
HL.NumberOFPlayers = 0;
HL.CurrentRound = 1;

myApp.factory("TournamentFactory", function () {
    var factory = {};
    HL.Round2 = [];
    HL.Round3 = [];

    factory.getRound = function (roundNr) {
        if (roundNr === 2) {
            return HL.Round2;
        }
        return null;
    }
    factory.ToNextRound = function (Player) {
        HL.Round2.push(Player);
    }
 

    return factory;
});

controllers.TournamentBracketController = function ($scope, TournamentFactory) {  
    $scope.init = function (Tournament) {
        $scope.Tournament = Tournament;
        $scope.Players = Tournament.Players;
        GetNumberOfPlayers($scope.Tournament.NumbersOfPlayers);
    }
    $scope.Round2 = TournamentFactory.getRound(2);

    $scope.ToNextRound = function () {
        TournamentFactory.ToNextRound($scope.Players[nr]);
        nr++;
    }
 
   
};

function GetNumberOfPlayers(number) {
    HL.NumberOFPlayers = number;
    console.log(number);

}

HL.NumberOFPlayers = 0;

$(document).ready(function () {







});