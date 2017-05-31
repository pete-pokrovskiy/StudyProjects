(function() {
    'use strinc';


    var app = angular.module('app', [
        'ngRoute',
        'kendo.directives'
    ]);

    app.config(['$routeProvider', function($routeProvider) {
            $routeProvider
                .when('/', { templateUrl: 'src/welcome/welcome.html' })
                .when('/welcome2', { templateUrl: 'src/welcome/welcome2.html' })
                .when('/welcome3', { templateUrl: 'src/welcome/welcome3.html' })
                .otherwise({ redirectTo: '/' });
        }]
        );

}());