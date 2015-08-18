/**
 * Created by vitali.nalivaika on 06.08.2015.
 */

socNetworkModule.directive('myFullName', function() {
    return {
        restrict: 'AEC',
            template: 'Name: {{currentUserName}}'
    };
});