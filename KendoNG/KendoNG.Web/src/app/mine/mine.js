(function() {

    var app = angular.module('app');

    var MineController = function($scope) {

        $scope.maxValue = 10;

        $scope.jobFirstDayOptions = {
            format: "dd.MM.yyyy"
        };
    };

    app.controller('MineController', MineController);

}());