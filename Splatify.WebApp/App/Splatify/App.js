var splatifyModule = angular.module('splatify', ['common']);

splatifyModule.config(function ($routeProvider,
                                $locationProvider) {
    $routeProvider.when('/artist', {
        //templateUrl: '/App/Customer/Views/CustomerHomeView.html',
        controller: 'splatifyViewModel'
    });
    $routeProvider.when('/login', {
        //templateUrl: '/App/Customer/Views/CustomerHomeView.html',
        controller: 'splatifyViewModel'
    });
    $routeProvider.otherwise({
        redirectTo: '/artist'
    });
    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });
});

splatifyModule.factory('splatifyService',
    function ($http, $location, viewModelHelper) {
        return MyApp.splatifyService($http,
            $location, viewModelHelper);
    });

(function (myApp) {
    var splatifyService = function ($http, $location,
        viewModelHelper) {

        var self = this;

        self.customerId = 0;

        return this;
    };
    myApp.splatifyService = splatifyService;
}(window.MyApp));