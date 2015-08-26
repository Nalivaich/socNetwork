
/**
 * Created by vitali.nalivaika on 05.08.2015.
 */

var isOnGitHub = window.location.hostname === 'blueimp.github.io',
    url = isOnGitHub ? '//jquery-file-upload.appspot.com/' : 'server/php/';


var socNetworkModule = angular.module('socNetworkModule', ["ui.router", "ngAnimate", 'blueimp.fileupload', 'ngResource', 'ui.bootstrap'])
    .config([
        '$httpProvider', 'fileUploadProvider',
        function ($httpProvider, fileUploadProvider) {
            delete $httpProvider.defaults.headers.common['X-Requested-With'];
            fileUploadProvider.defaults.redirect = window.location.href.replace(
                /\/[^\/]*$/,
                '/cors/result.html?%s'
            );
            if (isOnGitHub) {
                // Demo settings:
                angular.extend(fileUploadProvider.defaults, {
                    // Enable image resizing, except for Android and Opera,
                    // which actually support image resizing, but fail to
                    // send Blob objects via XHR requests:
                    disableImageResize: /Android(?!.*Chrome)|Opera/
                        .test(window.navigator.userAgent),
                    maxFileSize: 999000,
                    acceptFileTypes: /(\.|\/)(gif|jpe?g|png)$/i
                });
            }
        }
    ])
    .controller('DemoFileUploadController', [
        '$scope', '$http', '$filter', '$window',
        function ($scope, $http) {
            $scope.options = {
                url: url
            };
            if (!isOnGitHub) {
                $scope.loadingFiles = true;
                $http.get(url)
                    .then(
                    function (response) {
                        $scope.loadingFiles = false;
                        $scope.queue = response.data.files || [];
                    },
                    function () {
                        $scope.loadingFiles = false;
                    }
                );
            }
        }
    ])

    .controller('FileDestroyController', [
        '$scope', '$http',
        function ($scope, $http) {
            var file = $scope.file,
                state;
            if (file.url) {
                file.$state = function () {
                    return state;
                };
                file.$destroy = function () {
                    state = 'pending';
                    return $http({
                        url: file.deleteUrl,
                        method: file.deleteType
                    }).then(
                        function () {
                            state = 'resolved';
                            $scope.clear(file);
                        },
                        function () {
                            state = 'rejected';
                        }
                    );
                };
            } else if (!file.$cancel && !file._index) {
                file.$cancel = function () {
                    $scope.clear(file);
                };
            }
        }
    ]);

socNetworkModule.run(function($state){
    //$state.transitionTo('index.Publications');

});
socNetworkModule.config(  function($stateProvider,$urlRouterProvider){

    $urlRouterProvider.when('/', '/Publications');
    $urlRouterProvider.otherwise("/Publications");

    var baseSiteUrlPath = $("base").first().attr("href");

    var baseTemplateUrl = baseSiteUrlPath + "app/templates/";

    $stateProvider
        .state('index', {
            url: "",
            abstract: true,
            views: {
                "contentView": {
                    templateUrl: "../Static/Content.html"
                }
            }
        })
        .state('index.SearchUsers', {
            url: "/SearchUsers",
            templateUrl: "../Static/SearchUsers.html",
            controller: function($scope){
                $scope.items = ["A", "List", "Of", "Items"];
            }
        })
        .state('index.NewPost', {
            url: "/NewPost",
            templateUrl: "../Static/NewPost.html",
            controller: function($scope){
                $scope.items = ["A", "List", "Of", "Items"];
            }
        })
        .state('index.Publications', {
            url: "/Publications",
            templateUrl: "../Static/Publications.html",
            controller: function($scope){
                $scope.items = ["A", "List", "Of", "Items"];
            }
        })

        .state('Registration', {
            url: "/Registration",
            views: {
                "contentView": {
                    templateUrl: "../Static/Registration.html"
                },
                "viewB": {
                    template: "route2.viewB"
                }
            }
        })
        .state('LogIn', {
            url: "/LogIn",
            views: {
                "contentView": {
                    templateUrl: "../Static/LogIn.html"
                },
                "viewB": {
                    template: "route2.viewB"
                }
            }
        })
        .state('PersonalRoom', {
            url: "/PersonalRoom",
            views: {
                "contentView": {
                    templateUrl: "../Static/PersonalRoom.html"
                },
                "viewB": {
                    template: "route2.viewB"
                }
            }
        })
        .state('NewAlbum', {
            url: "/NewAlbum",
            views: {
                "contentView": {
                    templateUrl: "../Static/NewAlbum.html"
                },
                "viewB": {
                    template: "route2.viewB"
                }
            }
        })
        .state('ManageAlbum', {
            url: "/ManageAlbum",
            views: {
                "contentView": {
                    templateUrl: "../Static/ManageAlbum.html"
                },
                "viewB": {
                    template: "route2.viewB"
                }
            }
        })
        .state('ViewAlbum', {
            url: "/ViewAlbum",
            views: {
                "contentView": {
                    templateUrl: "../Static/ViewAlbum.html"
                },
                "viewB": {
                    template: "route2.viewB"
                }
            }
        })
});



/*
var socNetworkModule = angular.module('socNetworkModule', ['ngRoute', 'ui.bootstrap']);

socNetworkModule.config(function($stateProvider, $urlRouterProvider){

    $urlRouterProvider.otherwise("/route1")

    $stateProvider
        .state('route1', {
            url: "/route1",
            templateUrl: "route1.html"
        })
        .state('route1.list', {
            url: "/list",
            templateUrl: "route1.list.html",
            controller: function($scope){
                $scope.items = ["A", "List", "Of", "Items"];
            }
        })

        .state('route2', {
            url: "/route2",
            templateUrl: "route2.html"
        })
        .state('route2.list', {
            url: "/list",
            templateUrl: "route2.list.html",
            controller: function($scope){
                $scope.things = ["A", "Set", "Of", "Things"];
            }
        })
});
*/
socNetworkModule.controller('aboutController',['$scope' , '$http', '$location', function($scope, $http, $location) {
    $scope.auto = [];
    $scope.message = 'Look! I am an about page.';
}]);