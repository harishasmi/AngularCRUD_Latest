/// <reference path="angular.js" />
angular.module("CrudDemo.controller",[]).
    controller("MainController", function ($scope, PlayerService) {
        $scope.message = "Frm the Main Controller";

        PlayerService.GetPlayerFromDB().then(function (response) {
            $scope.listPlayers = response.data.players;
        })
    }).
    controller("AddPlayerController", function ($scope, PlayerService) {
        $scope.message = "Add Player Controller";

        $scope.AddPlayer = function () {
            PlayerService.AddPlayer($scope.player);
            //alert("Player added successfully");
        }; 
    }).
    controller("EditPlayerController", function ($scope, PlayerService, $routeParams) {
        $scope.message = "Edit Player Controller";
        var id = $routeParams.id;
        PlayerService.GetPlayerByID(id).then(function (response) {
            $scope.player = response.data.player;   
        });

        $scope.UpdatePlayer = function()
        {
            PlayerService.UpdatePlayer($scope.player);
        }

    }).
    factory("PlayerService", ["$http", function ($http) {
        var fac = {};
        fac.GetPlayerFromDB = function ()
        {
            return $http.get("/Player/GetPlayers");
        }
        fac.GetPlayerByID = function (id)
        {
            return $http.get("/Player/GetPlayerById", { params: {id : id}});
        }
        fac.AddPlayer = function (player)
        {
            $http.post("/Player/AddPlayer", player).then(function (response) {
                alert(response.data.status);
            });
        }
        fac.UpdatePlayer = function (player) {
            $http.post("/Player/UpdatePlayer", player).then(function (response) {
                alert(response.data.status);
            });
        }

        fac.DeletePlayer = function (player) {
            $http.post("/Player/DeletePlayer", {id : id}).success(function (response) {
                alert(response.data.status);
            });
        }

        return fac;

}])