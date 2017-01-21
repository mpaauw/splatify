
var testModule = angular.module('test', ['common'])
    .config(function ($routeProvider, $locationProvider) {
        $routeProvider.when('/test/show/:testId', { controller: 'testViewModel' });
        $routeProvider.otherwise({ redirectTo: '/test' });
        $locationProvider.html5Mode(true);
    });

testModule.factory('testService', function ($rootScope, $http, $q, $location, viewModelHelper) { return MyApp.testService($rootScope, $http, $q, $location, viewModelHelper); });

(function (myApp) {
    var testService = function ($rootScope, $http, $q, $location, viewModelHelper) {

        alert("ENTERED TESTSERVICE()");

        var self = this;

        self.testId = 0;

        return this;
    };
    myApp.testService = testService;
}(window.MyApp));