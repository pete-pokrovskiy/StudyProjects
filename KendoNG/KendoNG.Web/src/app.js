(function() {
    'use strinc';


    var app = angular.module('app', [
        'ngRoute',
        'kendo.directives'
    ]);

    app.config(['$routeProvider', function($routeProvider) {
            $routeProvider
                .when('/', { templateUrl: 'src/welcome/welcome.html' })
                .otherwise({ redirectTo: '/' });
        }]
        );

}());