/// <reference path="E:\Rahman\Projects\Asp.Net.CORS.WebConfig\Asp.Net.CORS.WebConfig.Mvc\Scripts/angular.js" />

var angular = angular.module("app", []);

angular.controller("CorsController", function ($http) {

    var ctrl = this;

    ctrl.values = [];

    ctrl.ReadValues = function () {

        $http.get("http://localhost:16980/api/Values/")
            .success(function (data) {
                ctrl.values = data;
            })
            .error(function (data, status, headers, config) {
                alert("Error cannot do Cross Origin Request. Check console for detailed errors.");
            });
    };

});