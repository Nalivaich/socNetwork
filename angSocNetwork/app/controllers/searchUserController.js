/**
 * Created by vitali.nalivaika on 19.08.2015.
 */

socNetworkModule.controller('SearchUserController', ['$scope', '$location', '$timeout', 'userService',  function($scope, $location,  $timeout, userService) {
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

    self.Register = function(index) {
        self.changeHeaderTemplate(index);

    }

}]);