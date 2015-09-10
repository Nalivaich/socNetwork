/**
 * Created by vitali.nalivaika on 18.08.2015.
 */

socNetworkModule.controller('HeaderController', ['$scope', 'UserService', '$state', function ($scope, UserService, $state) {
    var self = $scope;

    self.LogOut = function (index) {
        UserService.logOut( function (result) {
            self.changeHeaderTemplate(index);
            self.ChangeAutorizedFlag(false);
            self.changeCurrentUserId(0);
            self.changeCurrentUser({});
            $state.go("index.Publications");
        }, function (result) {
            alert("Something wrong")
        })
    }

}]);
