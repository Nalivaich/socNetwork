/// <reference path="D:\Applications\socNetwork\socNetworkWebApi\Static/roomDialog.html" />
/**
 * Created by vitali.nalivaika on 18.08.2015.
 */

socNetworkModule.controller('PersonalRoomController', ['$scope', '$location', '$timeout', 'AlbumService', 'UserService', '$modal', function ($scope, $location, $timeout, AlbumService, UserService, $modal) {
    var self = $scope;
    self.albums = [];

    UserService.getAlbums(self.currentUserId ,function (result) {
        self.albums = result;
    }, function () {
    });

    self.open = function (size) {
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '../Static/albumsListDialog.html',
            scope: self,
            size: size,
            resolve: {
                items: function () {
                    return $scope.items;
                }
            }
        });

        self.cancel = function () {
            modalInstance.dismiss('cancel');
        };

        self.choseAlbum = function (id) {
            modalInstance.dismiss('cancel');
            self.changeCurrentAlbum(id);
        }
    };




}]);