/**
 * Created by vitali.nalivaika on 19.08.2015.
 */

socNetworkModule.controller('SearchUserController', ['$scope', '$location', '$timeout', 'UserService', function ($scope, $location, $timeout, UserService) {
    var self = $scope;
    self.users = [];
    var pp = $("#autorisation");


    UserService.getAll(function (result) {
        self.users = result;
        }, function() {
        });

    self.getUser = function (item) {
        alert(item.id)
        UserService.getById(item.id, function (result) {
        }, function () {
        })
    };

    

}]);