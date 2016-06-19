angular.module('app', [
    'ngRoute',
    'templates',
    'ngMaterial',
    'http',
    'date',
    'dashboard',
    'userSchedule',
    'report'
])
    .config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {
        $routeProvider
        .when('/', {
            templateUrl: '/App/dashboard/dashboard.html',
            controller: 'dashboardCtrl',
            controllerAs: 'dashboard'
        })
        .when('/userSchedule', {
            templateUrl: '/App/userSchedule/userSchedule.html',
            controller: 'userScheduleCtrl',
            controllerAs: 'user'
        })
        .when('/report', {
            templateUrl: '/App/report/report.html',
            controller: 'reportCtrl',
            controllerAs: 'report'
        })
        .otherwise({
            redirectTo: '/'
        });
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        });
    }]);