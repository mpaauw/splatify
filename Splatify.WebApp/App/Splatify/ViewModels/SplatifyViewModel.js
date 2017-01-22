splatifyModule.controller("splatifyViewModel", function ($scope, splatifyService, $http, $q, $routeParams, $window, $location, viewModelHelper) {
    $scope.viewModelHelper = viewModelHelper;
    $scope.splatifyService = splatifyService;

    var token;
    var url;
    var relatedArtists = [];

    var initialize = function () {       
        url = window.location.href;
        parseUrl(url);
        if (token) {
            $("#LoginButton").hide();
            $("#loggedInButton").show();
            $("#artistInput").show();
        }
        else {
            $("#LoginButton").show();
            $("#loggedInButton").hide();
            $("#artistInput").hide();
        }       
    }

    var parseUrl = function (url) {
        var trimmedUrl;
        if (url) {
            var pos = url.lastIndexOf("/");
            trimmedUrl = url.substr(pos + 1);
        }
        var parsedValues = trimmedUrl.split("&");
        var t = parsedValues[0].split("=");
        token = t[1];
    }

    $scope.submitArtist = function () {
        viewModelHelper.apiGet('api/artist/' + splatifyService.artistId + "/" + token, null,
            function (result) {
                var flag = 0;
                angular.forEach(result, function (value) {
                    if (flag == 0) {
                        angular.forEach(value, function (item) {
                            var artist = {
                                Name: item.name,
                                Image: item.images[0].url,
                                Url: item.external_urls.spotify
                            }
                            relatedArtists.push(artist);
                        });
                    }                  
                    flag = 1;
                });
                if (flag == 1) {
                    $("#LoadingModal").modal('hide');
                    $("#RelatedArtistsModal").modal('show');
                }
            });
    }

    $scope.RelatedArtists = relatedArtists;

    $scope.submitLogin = function () {
        viewModelHelper.apiGet('api/login', null,
            function (result) {
                var redirectString = result.data;
                redirectString = redirectString.replace(/"/g, "");
                window.location.replace(redirectString);
            });
    }

    initialize();
});