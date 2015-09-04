
socNetworkModule.controller('ViewPostsController', ['$scope', '$location', '$timeout', 'UserService', 'PostService', function ($scope, $location, $timeout, UserService, PostService) {
    var self = $scope;
    self.currentPost;
    self.currentPostId;
    self.currentAlbumComments;
    self.posts = [];
    PostService.getAll(function (result) {
        self.posts = result;
    }, function () {
    })

    self.setCurrentPostId = function (newValue) {
        self.currentPostId = newValue;
        
    }

    //self.getPictures = function(postId){
     //   return [1,2,3,4,5,6];
        /*return PostService.getById(postId, function () {
        }, function () {
        })*/
    //}

   /* AlbumService.getComments(self.currentAlbumId, function (result) {
        self.currentAlbumComments = result;
    }, function () {
    })*/

    self.templates =
        [{ name: 'template1.html', url: 'app/templates/uploadImage.html' },
            { name: 'template2.html', url: 'app/templates/AutorizedHeader.html' }];
    self.Upload = self.templates[0];

    self.pp = 0;
    self.GetSenderName = function (id) {
        self.pp++;
        /*return UserService.getById(id, function (result) {
            var fullName = result.name + result.surName;
             return fullName;
        })     */
    }


}]);