/**
 * Created by vitali.nalivaika on 18.08.2015.
 */

socNetworkModule.controller('RegistrationController', ['$scope', '$location', '$timeout', 'UserService', function ($scope, $location, $timeout, UserService) {
    var self = $scope;
    self.newUser = {firstName:'', surName: '', pseudonym: '', email: '', password: '', confirmPassword: ''};

    self.signUp = function (object, form) {
        if (!form.$valid) {
            return false;
        }
        alert(object);
        console.log(object);
        userService.add({
            name: self.currentUserName,
            password: self.currentUserPassword
        }, function (newObject) {
            var newUser = UserModel(newObject);
            self.addNewUser(newUser);
            self.SetCurrentUserId(newUser.id);
            self.SetAuthorizationFlag(true);
            return true;
        }, function () {
            console.log('can\'t add user');
        });
    };

    self.Register = function (newUserObject, index) {
        console.log(newUserObject);
        //self.changeHeaderTemplate(index);

    }

}]);