/**
 * Created by vitali.nalivaika on 18.08.2015.
 */


socNetworkModule.controller('ManageAlbumController', ['$scope', '$location', '$timeout', 'AlbumService', 'UserService', function ($scope, $location, $timeout, AlbumService, UserService) {
    var self = $scope;

    self.greeting = "from ManageAlbumController";

    self.dataFilesArray = [];


    self.AddDataFiles = function (data) {
        if (!data) {
            return false;
        }
        for (var i = 0; i < data.length; i++) {
            self.dataFilesArray.push(data[i].newName);
        }
        return true;
    }

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
        newAlbum.picturesName = self.dataFilesArray;
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