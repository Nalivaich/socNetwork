/**
 * Created by vitali.nalivaika on 18.08.2015.
 */


socNetworkModule.controller('ManageAlbumController', ['$scope', '$location', '$timeout', 'UserService', function ($scope, $location, $timeout, UserService) {
    var self = $scope;

    self.templates =
        [ { name: 'template1.html', url: 'app/templates/uploadImage.html'},
            { name: 'template2.html', url: 'app/templates/AutorizedHeader.html'} ];
    self.Upload = self.templates[0];



}]);