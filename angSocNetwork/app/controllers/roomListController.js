/**
 * Created by vitali.nalivaika on 05.08.2015.
 */

socNetworkModule.controller('RoomListController', ['$scope', '$modal', '$log', 'roomService', 'userService', function($scope, $modal, $log, roomService, userService) {
    var self = $scope;

    self.templates =
        [ { name: 'template1.html', url: 'app/templates/userList.html'},
            { name: 'template2.html', url: 'autorisation.html'} ];
    self.roomBlock = $scope.templates[0];

    self.open = function (size) {
        self.SetNewRoomName('');
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: 'app/templates/roomDialog.html',
            scope: self,
            size: size,
            resolve: {
                items: function () {
                    return $scope.items;
                }
            }
        });

        self.ok = function (value) {
            self.SetNewRoomName(value);
            modalInstance.dismiss('cancel');

            self.addRoom(self.newRoomName, self.currentUserId, self.privateFlag, function(newId) {
                self.SetCurrentRoomId(newId);
                self.addUserRoom(self.currentUserId, self.currentRoomId, function() {
                    self.setRoomCreaterFlag(self.isCurrentUserRoom(self.currentRoomId , self.currentUserId));
                    self.setActiveRoomFlag(true);
                    self.SetNewRoomName('');
                    self.$apply();
                });
            });
        };

        self.cancel = function () {
            modalInstance.dismiss('cancel');
        };
    };

    self.changeCurrentRoom = function(newRoomId, currentPrivateFlag) {
        if(self.currentUserId == '' || self.currentUserId == undefined) {
            return false;
        }

        if(currentPrivateFlag && !(self.isUserInRoom(self.currentUserId,newRoomId))){
            alert("access denied");
            return false;
        }

        self.SetCurrentRoomId(newRoomId);
        self.setRoomCreaterFlag(self.isCurrentUserRoom(self.currentRoomId, self.currentUserId));
        self.addUserToRoom(self.currentUserId, self.currentRoomId);
        self.setActiveRoomFlag(true);
    };

    self.addRoom = function(name, createrID, privateFlag, nextfunction) {
        roomService.add({
            name: name,
            createrId: createrID,
            privateFlag: privateFlag,
            usersIDInRoom: [{
                userIndex: createrID
            }]
        }, function(room) {
            var newRoom = new RoomModel(room);
            self.addNewRoom(newRoom);
            nextfunction(newRoom.id);

            return true;
        }, function() {
            console.log('can\'t add room');
        });
    };

    self.addUserRoom = function(userId, roomId, nextFunction) {
        userService.addUserRoom({
            userIndex: userId
        }, {
            roomIndex: roomId
        }, function () {
            var observableUser = $.grep(self.usersRepository, function(item) {
                return item.id === userId;
            })[0];

            observableUser.userRooms.push({
                roomIndex: roomId
            });

            nextFunction();
        }, function () {
            console.log('can\'t add user`s room');
        });
    };

    self.isUserInRoom = function(userIndex, currentRoomIndex, nextFunction) {
        if(currentRoomIndex === '' || currentRoomIndex === '') {
            return false;
        }

        var observableRoom = $.grep(self.roomsRepository, function(item) {
            return item.id === currentRoomIndex;
        })[0];

        var foundUserInRoom = $.grep(observableRoom.usersIDInRoom, function (userItem, index) {

            return userItem.userIndex === userIndex;
        });

        return foundUserInRoom.length;
    }


}]);
