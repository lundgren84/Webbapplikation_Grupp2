

var myApp = angular.module("TournamentApp",[]);

//myApp.config(function ($routeProvider) {
//    var viewBase = '/Views/Account/';
//    $routeProvider
//    .when('/one', {
//        controller: "OneController",
//        templateUrl:"/Views/Account/Options.html "
//    })
//    .when('/two', {
//        controller: "OneController",
//        templateUrl: "PartialViews/two.html"
//    })
//     .otherwise({
//         template: ""
//     });
//});

myApp.factory("OneFactory", function () {
    var factory = {};


    return factory;
});
var controllers = {};
controllers.OneController = function ($scope, OneFactory) {


};


myApp.controller(controllers);