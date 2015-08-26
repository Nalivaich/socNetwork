/**
 * Created by vitali.nalivaika on 19.08.2015.
 */

socNetworkModule.controller('SearchUserController', ['$scope', '$location', '$timeout', 'UserService', '$modal', function ($scope, $location, $timeout, UserService, $modal) {
    var self = $scope;
    self.users = [];
    self.selectedUser;
    self.selectedUserAlbums;
    var pp = $("#autorisation");


    UserService.getAll(function (result) {
        self.users = result;
        }, function() {
        });

    self.getUser = function (size, item) {
        UserService.getById(item.id, function (result) {
            self.selectedUser = result;
            self.open(size);
        }, function () {
        })
    };

    self.open = function (size) {
        var modalInstance;
        UserService.getAlbums(self.selectedUser.id, function (result) {
            self.selectedUserAlbums = result;
            modalInstance = $modal.open({
                animation: true,
                templateUrl: '../Static/userAlbumsDialog.html',
                scope: self,
                size: size,
                resolve: {
                    editId: function () {
                        return size;
                    }
                }
            });

        }, function () {

        })

        self.cancel = function () {
            modalInstance.dismiss('cancel');
        };

        self.choseAlbum = function (id) {
            modalInstance.dismiss('cancel');
            self.changeCurrentAlbumId(id);
        }

    };

}]);