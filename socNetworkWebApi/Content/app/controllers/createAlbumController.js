/// <reference path="D:\Applications\socNetwork\socNetworkWebApi\Static/uploadImage.html" />
/**
 * Created by vitali.nalivaika on 18.08.2015.
 */


socNetworkModule.controller('CreateAlbumController', ['$scope', '$location', '$timeout', 'AlbumService', '$modal', function ($scope, $location, $timeout, AlbumService, $modal) {
    var self = $scope;
    self.newAlbum = {
        name: '',
        private: false,
        userId: 0,
        likes: 0
    }

    self.templates =
        [{ name: 'template1.html', url: '../Static/uploadImage.html' },
            { name: 'template2.html', url: 'app/templates/AutorizedHeader.html'} ];
    self.Upload = self.templates[0];



    self.create = function () {
        self.newAlbum.userId = self.currentUserId;
        AlbumService.createAlbum(self.newAlbum, function (result) {
                var modalInstance = $modal.open({
                    animation: true,
                    templateUrl: '../Static/infoDialog.html',
                    scope: self,
                    size: 'md',
                    resolve: {
                        items: function () {
                            return $scope.items;
                        }
                    }
                });

                self.cancel = function () {
                    modalInstance.dismiss('cancel');
                };
        }, function () {
        })
    }

    $scope.validate = function (form) {
        if (!form.$valid) {
            return false;
        }
        return true;
    }

}]);