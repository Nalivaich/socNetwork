/**
 * Created by vitali.nalivaika on 18.08.2015.
 */

socNetworkModule.controller('HeaderController', ['$scope', function($scope) {
    var self = $scope;

    /*self.templates =
        [ { name: 'template1.html', url: 'app/templates/noAutorizedHeader.html'},
            { name: 'template2.html', url: 'app/templates/AutorizedHeader.html'} ];

    self.SetHeaderBlock($scope.templates[0]);


    /*self.changeHeaderTemplate = function() {
        SetHeaderBlock($scope.templates[1]);
    }*/

    self.LogOut = function(index) {
        self.changeHeaderTemplate(index);

    }

}]);
