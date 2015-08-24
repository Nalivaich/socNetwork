/**
 * Created by vitali.nalivaika on 19.08.2015.
 */

socNetworkModule.controller('SearchUserController', ['$scope', '$location', '$timeout', 'userService', function ($scope, $location, $timeout, userService) {
    var self = $scope;
    self.users = [];
    var pp = $("#autorisation");


    userService.getAll(function(result){
        self.users = result;
        }
        , function(){
        });

    self.getUser = function (item) {
        alert(item.id)
        userService.getById(item.id, function (result) {
        }, function () {
        })
    };

    

}]);