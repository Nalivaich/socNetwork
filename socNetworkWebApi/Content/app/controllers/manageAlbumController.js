/**
 * Created by vitali.nalivaika on 18.08.2015.
 */


socNetworkModule.controller('ManageAlbumController', ['$scope', '$location', '$timeout', 'AlbumService', 'UserService', function ($scope, $location, $timeout, AlbumService, UserService) {
    var self = $scope;

    self.UrlPartsObject = {
        userId: self.currentUserId,
        action: 'add'
    }

    self.Upload;

    self.templates =
        [{ name: 'template1.html', url: '../Static/uploadImage.html' },
            { name: 'template2.html', url: 'app/templates/AutorizedHeader.html'} ];
    self.Upload = self.templates[0];


    self.updateAlbum = function (newAlbum) {
        newAlbum.created = null;
        newAlbum.modified = null;
        AlbumService.updateAlbum(newAlbum, function (result) {
        }, function () {
        })
    }

    self.removeAlbum = function (albumId) {
        AlbumService.removeAlbum(albumId, function (result) {
        }, function () {
        })
    }

    self.rollbackChanges = function () {
        UserService.rollbackChanges(self.currentUserId, function (result) {
        }, function () {
        })
    }

}]);