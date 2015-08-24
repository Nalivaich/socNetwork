/// <reference path="D:\Applications\socNetwork\socNetworkWebApi\Static/uploadImage.html" />
/**
 * Created by vitali.nalivaika on 18.08.2015.
 */


socNetworkModule.controller('CreateAlbumController', ['$scope', '$location', '$timeout', 'userService',  function($scope, $location,  $timeout, userService) {
    var self = $scope;

    self.templates =
        [{ name: 'template1.html', url: '../Static/uploadImage.html' },
            { name: 'template2.html', url: 'app/templates/AutorizedHeader.html'} ];
    self.Upload = self.templates[0];



}]);