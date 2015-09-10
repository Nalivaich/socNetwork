/// <reference path="D:\Applications\socNetwork\socNetworkWebApi\Static/autorizedHeader.html" />
socNetworkModule.controller('ContentController', ['$scope', 'UserService', '$state', '$modal', function ($scope, UserService, $state, $modal) {
    var self = $scope;

    self.redirection = function () {
        if (self.autorized) {
            $state.go("index.NewPost")
            return;
        }
        self.open('md');
    }


    self.open = function (size) {

        modalInstance = $modal.open({
            animation: true,
            templateUrl: '../Static/noAutorizedDialog.html',
            scope: self,
            size: size,
            resolve: {
                editId: function () {
                    return size;
                }
            }
        });

        self.cancel = function () {
            $state.go("LogIn");
            modalInstance.dismiss('cancel');
        };

    };

    self.LogOut = function (index) {
        UserService.logOut(function (result) {
            self.changeHeaderTemplate(index);
            self.autorized = false;
            self.changeCurrentUserId(0);
            self.changeCurrentUser({});
            $state.go("index.Publications");
        }, function (result) {
            alert("Something wrong")
        })
    }

}]);
