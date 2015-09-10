socNetworkModule.controller('CurrentPostController', ['$scope', 'AlbumService', '$modal', 'PostService', 'CommentService', function ($scope, AlbumService, $modal, PostService, CommentService) {
    var self = $scope;
   // self.currentPostId;
    self.pictures = [];
    self.currentPostComments;
    self.sayHello = function () {
        alert("hello");
    }
    self.comment = {
        comment:""
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
        self.currentPostComments = result;
    }, function () {
    })

    self.addComment = function (comment) {
        if (self.autorized) {
            comment.postId = self.post.id;
            comment.userId = self.currentUser.id;
            CommentService.createComment(comment, function (result) {
                PostService.getComments(self.post.id, function (result) {
                    self.currentPostComments = result;
                    self.comment.comment = "";
                });
            }, function (result) {
                alert("error") //show template
            })
            return;
        }
        alert("have no access")
    }

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
