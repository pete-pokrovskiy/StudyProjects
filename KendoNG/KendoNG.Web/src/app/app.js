(function() {
    'use strinc';


    var app = angular.module('app', [
        'ngRoute',
        'kendo.directives'
    ]);


    app.config(function($routeProvider) {
        $routeProvider
            .when('/', { templateUrl: 'app/welcome/welcome.html' })
            .when('/welcome2', { templateUrl: 'app/welcome/welcome2.html' })
            .when('/welcome3', { templateUrl: 'app/welcome/welcome3.html' })
            .when('/main', { templateUrl: 'app/main/main.html' })
            .when('/mine', {
                templateUrl: 'app/mine/mine.html',
                controller: 'MineController'
            })
            .when('/modal', { templateUrl: 'app/modal/modal.html' })
            .when('/kendo_modal', { templateUrl: 'app/modal/kendo_tutorial_modal.html' })
            .when('/grid', {
                templateUrl: 'app/grid/grid.html',
                controller: 'GridController'
            })
            .when('/dataSource', {
                templateUrl: 'app/dataSource/dataSource.html'
            })
            .when('/globalEvents', { templateUrl: 'app/globalEvents/globalEvents.html', controller: 'GlobalEventsController' })
            .otherwise({ redirectTo: '/' });
    });

    //https://stackoverflow.com/questions/41272314/angular-all-slashes-in-url-changed-to-2f
    //https://github.com/angular/angular.js/commit/aa077e81129c740041438688dff2e8d20c3d7b52
    //https://stackoverflow.com/questions/41211875/angularjs-1-6-0-latest-now-routes-not-working
    app.config([
        '$locationProvider', function($locationProvider) {
            $locationProvider.hashPrefix('');
        }
    ]);
}());