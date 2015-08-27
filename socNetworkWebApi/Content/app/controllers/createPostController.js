socNetworkModule.controller('CreatePostController', ['$scope', '$location', '$timeout', 'AlbumService', '$modal', function ($scope, $location, $timeout, AlbumService, $modal) {
    var self = $scope;
    self.newPost = {
        name: '',
        userId: 0,
        likes: 0
    }
    self.UrlPartsObject = {
        gist: 'posts',
        userId: self.currentUserId,
        gistId: 0,
        action: 'add'
    }
    self.templates =
        [{ name: 'template1.html', url: '../Static/uploadImage.html' },
            { name: 'template2.html', url: 'app/templates/AutorizedHeader.html' }];
    self.Upload = self.templates[0];



    /*self.create = function () {
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
    }*/

    self.create = function () {

    }

    self.restore = function () {

    }



}]);