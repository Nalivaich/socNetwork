/**
 * Created by vitali.nalivaika on 05.08.2015.
 */

socNetworkModule.controller('UserListController', ['$scope', 'UserService', function ($scope, UserService) {
    var self = $scope;
    self.templates =
        [ { name: 'template1.html', url: 'app/templates/userList.html'},
            { name: 'template2.html', url: 'app/templates/roomDialog.html'} ];
    self.userBlock = $scope.templates[0];

    self.findFullName = function(userID) {
        var observableUser = $.grep(self.usersRepository, function(item) {
            return item.id === userID;
        })[0];
        alert( observableUser.fullName() );
    };

}]);
