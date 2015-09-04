/**
 * Created by vitali.nalivaika on 06.08.2015.
 */

socNetworkModule.directive('myDirective', [ function () {
    return {
            scope: {
        methodFromController: '=',
        },
    link: function($scope, element, $attrs) {
        $scope.methodFromController();
    }
};
}]);


