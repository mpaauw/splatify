testModule.controller("rootViewModel", function ($scope, testService, $http, $q, $routeParams, $window, $location, viewModelHelper) {

    // This is the parent controller/viewmodel for 'customerModule' and its $scope is accesible
    // down controllers set by the routing engine. This controller is bound to the Customer.cshtml in the
    // Home view-folder.

    $scope.viewModelHelper = viewModelHelper;
    $scope.testService = testService;

    $scope.flags = { shownFromList: false };

    var initialize = function () {

        ALERT("entered init");

        //$scope.pageHeading = "Customer Section";
    }

    $scope.showTest = function () {

        alert("ENTERED SCOPE.SHOWTEST()");

        if (testService.testId != 0) {

            alert("ENTERED IF()");

            //$scope.flags.shownFromList = false;
            viewModelHelper.navigateTo('test/show/' + testService.testId);
        }
    }

    initialize();
});
