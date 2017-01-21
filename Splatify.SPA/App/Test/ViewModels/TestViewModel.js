testModule.controller("testViewModel", function ($scope, testService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    $scope.viewModelHelper = viewModelHelper;
    $scope.testService = testService;

    var initialize = function () {
        $scope.refreshTest($routeParams.testId);
    }

    $scope.refreshTest = function (testId) {

        alert("ENTERED REFRESHTEST");

        viewModelHelper.apiGet('api/test/' + testId, null,
            function (result) {
                testService.testId = testId;
                $scope.test = result.data;
            });
    }

    initialize();
});
