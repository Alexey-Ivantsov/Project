var test1 = angular.module("test1", []);
test1.controller("siteCtrl",
    function ($scope, $http) {
        $http({
            url: '/home/GetListSite',
            method: 'GET'
        }).success(function (data, status, headers, config) {
            $scope.GetListSite = data;
        });
    });



