var FixedAssetSolution = angular.module("FAS", []);
FixedAssetSolution.factory("FASservices", function ($http) {
    return {
        Company = function(){
            return $http.get('API/Login/1');
        }
    };
});

FixedAssetSolution.controller("locationManagement", function($scope, FASservices){
    
    $scope.save = function(){
        console.log("Hello");
    }
});