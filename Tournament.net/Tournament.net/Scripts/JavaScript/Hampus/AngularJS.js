var HL = HL || {};

myApp.factory("TournamentFactory", function () {
    var factory = {};

    factory.hello = function (hello) {
        let result = hello + " 'factory been here'";
        return result;
    }
    factory.CheckVS = function(Tournament){
    

        return "VS";
    }
 

    return factory;
});

controllers.TournamentBracketController = function ($scope, TournamentFactory) {  
    $scope.init = function (Tournament) {
        $scope.Tournament = Tournament;
    }
   
    $scope.hello = TournamentFactory.hello("Im from Controller in Angular");
    // Style Side
    $scope.sideUsernameStyle = "font-size:xx-large";

};

HL.NumberOFPlayers = 0;

$(document).ready(function () {







});