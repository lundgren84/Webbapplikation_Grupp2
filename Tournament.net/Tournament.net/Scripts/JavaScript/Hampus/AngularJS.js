var HL = HL || {};

myApp.factory("TournamentFactory", function () {
    var factory = {};

    factory.CheckVS = function(Tournament){
    

        return "VS";
    }
 

    return factory;
});

controllers.TournamentBracketController = function ($scope, TournamentFactory) {  
    $scope.init = function (Tournament) {
        $scope.Tournament = Tournament;
        $scope.Players = Tournament.Players;
    }
   
 
   
};

HL.NumberOFPlayers = 0;

$(document).ready(function () {







});