socNetworkModule.controller('CurrentPostController', ['$scope', 'AlbumService', '$modal', 'PostService', function ($scope, AlbumService, $modal, PostService) {
    var self = $scope;
   // self.currentPostId;
    self.pictures = [];
    self.currentAlbumComments;
    self.sayHello = function () {
        alert("hello");
    }
    PostService.getPictures(self.post.id, function (result) {
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

    PostService.getComments(self.post.id, function (result) {
        self.currentAlbumComments = result;
    }, function () {
    })

    self.templates =
        [{ name: 'template1.html', url: 'app/templates/userList.html' },
            { name: 'template2.html', url: 'app/templates/roomDialog.html' }];
    self.userBlock = $scope.templates[0];

    self.findFullName = function (userID) {
        var observableUser = $.grep(self.usersRepository, function (item) {
            return item.id === userID;
        })[0];
        alert(observableUser.fullName());
    };

}]);
