/// <reference path="angular.js" />
/// <reference path="angular-route.js" />

var app = angular.module("CrudDemo", ["CrudDemo.controller", "ngRoute"]);

app.config(["$routeProvider", function ($routeProvider) {
    $routeProvider.
    when("/", {
        templateUrl: "Partials/PlayerList.html",
        controller: "MainController"
    }).
    when("/AddPlayer", {
        templateUrl: "Partials/AddPlayer.html",
        controller: "AddPlayerController"
    }).
    when("/EditPlayer/:id", {
        templateUrl: "Partials/EditPlayer.html",
        controller: "EditPlayerController"
    }).
    otherwise({ redirectTo: "/" });
}]);