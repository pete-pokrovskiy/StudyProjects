(function() {

    var gridData = function($http) {

        var getActionItems = function() {

            return $http.get("/Grid/GetActionItems").then(function(response) {
                return response.data;
            });
        };

        return{
            getActionItems: getActionItems
        };
    };

    var app = angular.module("app");
    app.factory("gridData", gridData);
}());