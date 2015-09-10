/**
 * Created by vitali.nalivaika on 18.08.2015.
 */

socNetworkModule.controller('RegistrationController', ['$scope', '$location', '$timeout', 'UserService', function ($scope, $location, $timeout, UserService) {
    var self = $scope;
    self.newUser = {firstName:'', surName: '', pseudonym: '', email: '', password: '', confirmPassword: ''};

    self.signUp = function (object, form, index) {
        if (!form.$valid) {
            return false;
        }
        object.address = "not indicated";
        UserService.signUp(object, function (result) {
            console.log(result);
            self.changeHeaderTemplate(index);
            self.ChangeAutorizedFlag(true);
            self.changeCurrentUserId(result.id);
            self.changeCurrentUser(result);
            $state.go("index.Publications");
        }, function (result) {
            alert("Wrong name or password")
        })
    };

    $scope.validate = function (form) {
        if (!form.$valid) {
            return false;
        }
        return true;
    }
}]);