/**
 * Created by vitali.nalivaika on 06.08.2015.
 */

socNetworkModule.controller('LogInController', ['$scope', '$location', '$timeout', 'UserService', '$state', function ($scope, $location, $timeout, UserService, $state) {
    var self = $scope;

    var pp = $("#autorisation");
    self.userInfo = {
        name: "",
        password: null
    }
    self.signUp = function(object, form) {
        if(!form.$valid){
            return false;
        }
    };

    self.LogIn = function (index, userInfo) {
        UserService.logIn(userInfo, function (result) {
            self.changeHeaderTemplate(index);
            self.ChangeAutorizedFlag(true);
            self.changeCurrentUserId(result.id);
            self.changeCurrentUser(result);
            $state.go("index.Publications");
        }, function (result) {
            alert("Wrong name or password")
        })
    }

    $scope.validate = function (form) {
        if (!form.$valid ) {
            return false;
        }
        return true;
    }

    self.redirection = function () {
        if (!self.autorized) {
            return "-";
        }
        $state.go("index.Publications");
        return "index.Publications"
    }
    

}]);