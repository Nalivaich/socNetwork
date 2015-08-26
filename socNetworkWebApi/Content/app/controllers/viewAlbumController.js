
socNetworkModule.controller('ViewAlbumController', ['$scope', '$location', '$timeout', 'UserService', 'AlbumService', function ($scope, $location, $timeout, UserService, AlbumService) {
    var self = $scope;
    self.currentAlbum;
    self.currentAlbumComments;
    AlbumService.getById(self.currentAlbumId, function (result) {
        self.currentAlbum = result;
    }, function () {
    })

    AlbumService.getComments(self.currentAlbumId, function (result) {
        self.currentAlbumComments = result;
    }, function () {
    })
    self.currentAlbumComments

    self.templates =
        [{ name: 'template1.html', url: 'app/templates/uploadImage.html' },
            { name: 'template2.html', url: 'app/templates/AutorizedHeader.html' }];
    self.Upload = self.templates[0];

    self.pp = 0;
    self.GetSenderName = function (id) {
        console.log(self.pp);
        self.pp++;
        /*return UserService.getById(id, function (result) {
            var fullName = result.name + result.surName;
             return fullName;
        })     */
    }


}]);