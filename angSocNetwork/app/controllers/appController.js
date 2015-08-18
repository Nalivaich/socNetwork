/**
 * Created by vitali.nalivaika on 05.08.2015.
 */

socNetworkModule.controller('AppController', ['$scope', 'userService', 'roomService', function($scope, userService, roomService) {
    var self = $scope;


    self.headerBlock = '';

    self.templates =
        [ { name: 'template1.html', url: 'app/templates/noAutorizedHeader.html'},
            { name: 'template2.html', url: 'app/templates/AutorizedHeader.html'} ];
    self.headerBlock = self.templates[0];

    self.changeHeaderTemplate = function(index) {
        self.headerBlock = self.templates[index];
     };




    self.usersRepository = [];
    self.roomsRepository = [];
    self.messagesRepository = [];
    self.currentUser = {name:'', password: ''};
    self.currentUser = {};
    self.currentUserName = 'Guest';
    self.currentUserPassword = '';
    self.currentUserId = 0;
    self.currentMessage = '';
    self.currentRoomId = '';
    self.privateFlag = false;
    self.newRoomName = 's';
    self.activeRoomFlag = false;
    self.roomCreaterFlag = false;
    self.authorizationFlag = false;
    self.addOrRemove  = false;

    self.getAllUsers = function getAll() {
        userService.getAll(function(receivedUsers) {
            $.each(receivedUsers, function(index, receivedUser) {
                self.usersRepository.push(new UserModel(receivedUser));
            });
            $scope.$apply();
        }, function() {
            console.log('can\'t receive users');
        });
    }();

    self.getAllRooms = function getAll() {
        roomService.getAll(function(receivedRooms) {
            $.each(receivedRooms, function(index, receivedRoom) {
                self.roomsRepository.push(new RoomModel(receivedRoom));
            });
            $scope.$apply();
        }, function() {
            console.log('can\'t receive rooms');
        });
    }();

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
    self.SetCurrentUserId = function(newValue) {
        self.currentUserId = newValue;
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

    self.isCurrentUserRoom = function(currentRoomIndex, currentUserIndex) {
        if(currentRoomIndex === '' || currentUserIndex === '') {
            return false;
        }
        var observableUser = $.grep(self.usersRepository, function(item) {
            return item.id === currentUserIndex;
        })[0];

        var foundUserInRoom = $.grep(observableUser.userRooms, function (userItem, index) {
            return userItem.roomIndex === currentRoomIndex;
        });

        return foundUserInRoom.length;
    };

    self.addUserToRoom = function(userId, currentRoomId, nextfunction) {
        roomService.addUserToRoom({
            userIndex: userId
        }, {
            id: currentRoomId
        }, function() {

            var observableRoom = $.grep(self.roomsRepository, function(item) {
                return item.id === currentRoomId;
            })[0];

            if (!observableRoom) {
                return;
            }

            var foundUserInRoom = $.grep(observableRoom.usersIDInRoom, function (userItem, index) {

                return userItem.userIndex === userId;
            });
            if (!foundUserInRoom.length) {
                observableRoom.usersIDInRoom.push({
                    userIndex: userId
                });
                self.$apply();
            }
        }, function() {
            console.log('can\'t add user to room');
        });
    };

}]);