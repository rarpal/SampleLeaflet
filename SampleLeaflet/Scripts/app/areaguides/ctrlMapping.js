
angular
    .module('areaGuides.ctrl.mapping', [])
    .controller('ctrlMapping', ['$scope','$location','$http', function ($scope, $location, $http) {

        $scope.name = "Area Mapping";
        $scope.areaguides = [];
        $scope.areaid = "2232322";

        $http({
            method: 'GET',
            url: '/api/AreaGuidesAPI'
        }).success(function (data) {
            $scope.areaguides = data;
        });
    }]);
