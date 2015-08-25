/**
 * Created by vitali.nalivaika on 06.08.2015.
 */

socNetworkModule.controller('LogInController', ['$scope', '$location', '$timeout', 'UserService', function ($scope, $location, $timeout, UserService) {
    var self = $scope;

    var pp = $("#autorisation");

    self.signUp = function(object, form) {
        if(!form.$valid){
            return false;
        }

        var elem = $('#autorisation');
        elem.removeClass('bounceInLeft');
        elem.addClass('bounceOutRight');
        self.SetCurrentUserName(object.name);
        self.SetCurrentUserPass(object.password);
        self.SetAuthorizationFlag(true);
        $timeout(function() {
            $location.path('/greeting');
        }, 900);

        UserService.add({
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

    self.LogIn = function(index) {
        self.changeHeaderTemplate(index);

    }

}]);