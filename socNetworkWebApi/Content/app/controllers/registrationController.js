/**
 * Created by vitali.nalivaika on 18.08.2015.
 */

socNetworkModule.controller('RegistrationController', ['$scope', '$location', '$timeout', 'UserService', function ($scope, $location, $timeout, UserService) {
    var self = $scope;
    self.newUser = {firstName:'', surName: '', pseudonym: '', email: '', password: '', confirmPassword: ''};
    self.validForm = false;

    self.signUp = function (object, form, index) {
        if (!form.$valid) {
            return false;
        }
        
        self.validForm = true;

        UserService.add({
            name: object.firstName,
            surName: object.surName,
            alias: object.pseudonym,
            password: object.password,
            email: object.email,
            phoneNumber: 0,
            address: '',
            avaUrl: "#",
            isRemoved: 0,
            modified: 0
        }, function (newObject) {
            /*var newUser = UserModel(newObject);
            self.addNewUser(newUser);
            self.SetCurrentUserId(newUser.id);
            self.SetAuthorizationFlag(true);
            self.changeHeaderTemplate(index);
            return true;*/
            self.validForm = false;
        }, function () {
            console.log('can\'t add user');
        });
    };


    $scope.validate = function (form) {
        if (!form.$valid) {
            return false;
        }
        return true;
    }
}]);