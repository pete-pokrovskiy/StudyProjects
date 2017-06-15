(function() {

    var gridData = function($http) {

        var getActionItems = function() {

            return $http.get("/Grid/GetActionItems").then(function(response) {
                return response.data;
            });
        };

        var postActionItems = function(actionItems) {

            return $http.post("/Grid/PostActionItems", actionItems).then(function(response) {
                return response.data;
            });
        };

        return{
            getActionItems: getActionItems,
            postActionItems: postActionItems
    };
    };

    var app = angular.module("app");
    app.factory("gridData", gridData);
}());