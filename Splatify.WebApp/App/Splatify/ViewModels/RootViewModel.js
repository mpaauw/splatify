splatifyModule.controller("rootViewModel", function ($scope, splatifyService, $http, $q, $routeParams, $window, $location, viewModelHelper) {
    $scope.viewModelHelper = viewModelHelper;
    $scope.splatifyService = splatifyService;
    $scope.flags = { shownFromList: false };
    var initialize = function () {
        $scope.pageHeading = "Splatify"
    }
    initialize();
});