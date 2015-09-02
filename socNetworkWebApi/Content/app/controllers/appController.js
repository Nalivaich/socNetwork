/**
 * Created by vitali.nalivaika on 05.08.2015.
 */

socNetworkModule.controller('AppController', ['$scope', "$http", '$resource', function ($scope, $http, $resource) {
    var self = $scope;
    self.headerBlock = '';
    self.greeting = "from appController";

    self.templates =
        [ { name: 'template1.html', url: '../Static/noAutorizedHeader.html'},
            { name: 'template2.html', url: '../Static/autorizedHeader.html' }];
    self.headerBlock = self.templates[0];

    self.changeHeaderTemplate = function(index) {
        self.headerBlock = self.templates[index];
     };


    self.currentUser = { name: '', password: '' };

    self.currentUserId = 1; //!!!!!!!!!!!!!!!!!!!!!!!!!!!! change value, default 0 , = current user id
    self.usersRepository = [];
    self.roomsRepository = [];
    self.messagesRepository = [];
    self.currentUser = {name:'', password: ''};
    self.currentUser = {};
    self.currentUserName = 'Guest';
    self.currentUserPassword = '';
    self.currentMessage = '';
    self.currentRoomId = '';
    self.privateFlag = false;
    self.newRoomName = 's';
    self.activeRoomFlag = false;
    self.roomCreaterFlag = false;
    self.authorizationFlag = false;
    self.addOrRemove = false;
    self.currentAlbumId = 0;
    self.currentGist = '';
    self.currentAction = 'add';
    self.currentAlbum;

    self.changeParams = function (object) {
        self.currentAction = object.action;
        self.currentGist = object.gist;
    }

    self.ChangeCurrentAlbum = function (newObj) {
        self.currentAlbum = newObj;
    }

    self.ChangeCurrentGist = function (newValue) {
        self.currentGist = newValue;
    }
    self.ChangeCurrentAction = function (newValue) {
        self.currentAction = newValue;
    }

    self.changeCurrentAlbumId = function (newValue) {
        self.currentAlbumId = newValue;
    };

    self.changeCurrentUserId = function (newValue) {
        self.currentUserId = newValue;
    };

    
    self.addNewUser = function(object) {
        self.usersRepository.push(object);
        $scope.$apply();
    };
    self.addNewRoom = function(object) {
        self.roomsRepository.push(object);
        $scope.$apply();
    };

    self.removeRoomObject = function(roomId) {
        self.roomsRepository = _.filter(self.roomsRepository, 'id');
    };

    self.SetCurrentUserName = function(name) {
        self.currentUserName = name;
    };
    self.SetCurrentUserPass = function(pass) {
        self.currentUserPassword = pass;
    };

    self.SetAuthorizationFlag = function(newValue) {
        self.authorizationFlag = newValue;
    };
    self.SetNewRoomName =function(newValue) {
        self.newRoomName = newValue;
    };
    self.SetCurrentRoomId = function(newValue) {
        self.currentRoomId = newValue;
    };

    self.SetCurrentMessage = function(newValue) {
        self.currentMessage = newValue;
    };

    self.setRoomCreaterFlag = function(newValue) {
        self.roomCreaterFlag = newValue;
    };
    self.setActiveRoomFlag = function(newValue) {
            self.activeRoomFlag = newValue;
    };
    self.setCurrentMessage = function(newValue) {
            self.currentMessage = newValue;
    };

    self.refresh = function() {
        $scope.$apply();
    };



    

}]);