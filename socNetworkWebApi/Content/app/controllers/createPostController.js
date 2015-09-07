socNetworkModule.controller('CreatePostController', ['$scope', '$location', '$timeout', 'PostService', 'UserService', '$modal', function ($scope, $location, $timeout, PostService, UserService, $modal) {
    var self = $scope;
    self.dataFilesArray = [];
    self.currentPost = {};

    self.newPost = {
        name: '',
        userId: 0,
        likes: 0
    }

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
    self.templates =
        [{ name: 'template1.html', url: '../Static/uploadImage.html' },
            { name: 'template2.html', url: 'app/templates/AutorizedHeader.html' }];
    self.Upload = self.templates[0];


    self.create = function (newPost) {
        newPost.picturesName = self.dataFilesArray;
        newPost.userId = self.currentUserId;
        newPost.likes = 0;
        PostService.createPost(newPost, function (result) {
        }, function () {
        })
    }


    self.rollbackChanges = function () {
        UserService.rollbackChanges(self.currentUserId, function (result) {
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