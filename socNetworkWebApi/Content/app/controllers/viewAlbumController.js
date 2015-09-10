
socNetworkModule.controller('ViewAlbumController', ['$scope', '$location', '$timeout', 'UserService', 'AlbumService', '$modal', 'CommentService', function ($scope, $location, $timeout, UserService, AlbumService, $modal, CommentService) {
    var self = $scope;
    self.currentAlbum;
    self.pictures = [];
    self.comment = {
        comment: ""
    }
    self.currentAlbumComments;
    AlbumService.getById(self.currentAlbumId, function (result) {
        self.currentAlbum = result;
    }, function () {
    })

    AlbumService.getComments(self.currentAlbumId, function (result) {
        self.currentAlbumComments = result;
    }, function () {
    })

    self.addComment = function (comment) {
        if (self.autorized) {
            comment.albumId = self.currentAlbum.id;
            comment.userId = self.currentUser.id;
            CommentService.createComment(comment, function (result) {
                AlbumService.getComments(self.currentAlbumId, function (result) {
                    self.currentAlbumComments = result;
                    self.comment.comment = "";
                });
            }, function (result) {
                alert("error") //show template
            })
            return;
        }
        alert("have no access")
    }

    AlbumService.getPictures(self.currentAlbumId, function (result) {
        self.pictures = result;
    }, function () {
    })

    self.open = function (size, pictureId) {
        self.currentPictureId = pictureId;
        self.ChangeCurrentGist('album');
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: '../Static/showImageDialog.html',
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

        self.choseAlbum = function (album) {
            self.ChangeCurrentAlbum(album);
            self.changeCurrentAlbumId(album.id);
            modalInstance.dismiss('cancel');
        }
    };

    self.templates =
        [{ name: 'template1.html', url: 'app/templates/uploadImage.html' },
            { name: 'template2.html', url: 'app/templates/AutorizedHeader.html' }];
    self.Upload = self.templates[0];

    self.GetSenderName = function (id) {

    }


}]);