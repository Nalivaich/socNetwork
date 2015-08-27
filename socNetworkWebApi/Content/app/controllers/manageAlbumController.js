/**
 * Created by vitali.nalivaika on 18.08.2015.
 */


socNetworkModule.controller('ManageAlbumController', ['$scope', '$location', '$timeout', 'AlbumService', function ($scope, $location, $timeout, AlbumService) {
    var self = $scope;

    self.UrlPartsObject = {
        gist: 'albums',
        userId: self.currentUserId,
        gistId: self.currentAlbumId,
        action: 'add'
    }

    self.Upload;

    self.templates =
        [{ name: 'template1.html', url: '../Static/uploadImage.html' },
            { name: 'template2.html', url: 'app/templates/AutorizedHeader.html'} ];
    self.Upload = self.templates[0];


    self.updateAlbum = function (newAlbum) {
        AlbumService.updateAlbum(newAlbum, function (result) {
        }, function () {
        })
    }

    self.removeAlbum = function (albumId) {
        AlbumService.removeAlbum(albumId, function (result) {
        }, function () {
        })
    }

}]);