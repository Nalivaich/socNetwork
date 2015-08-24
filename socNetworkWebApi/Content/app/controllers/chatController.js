/**
 * Created by vitali.nalivaika on 05.08.2015.
 */

socNetworkModule.controller('ChatController', ['$scope', '$modal', '$log', '$timeout', function($scope, $modal, $log, $timeout) {
    var self = $scope;
    self.setMode = {};
    self.make = '';

    self.getCurrentRoom = function() {
        return self.roomsRepository.filter(function (item) {
            return item.id == self.currentRoomId;
        })[0];
    };

    self.getUserByID = function(userId) {
        return self.usersRepository.filter(function (item) {
            return item.id == userId;
        })[0];
    };

    self.open = function (mode) {
        if(mode) {
            self.make = 'add in ';
        } else {
           self.make = 'remove from ';
        }
        self.SetNewRoomName('');
        var modalInstance = $modal.open({
            animation: true,
            templateUrl: 'app/templates/addUserDialog.html',
            scope: self,
            size: 'sm',
            resolve: {
                items: function () {
                    return $scope.items;
                }
            }
        });

        modalInstance.result.then(function (selectedItem) {
            $scope.selected = selectedItem;
        }, function () {
            $log.info('Modal dismissed at: ' + new Date());
        });

        self.choseUser = function(userId, make) {
            modalInstance.dismiss('cancel');
            if(make.length < 9) {
                self.addUserToRoom(userId, self.currentRoomId);
            } else {
                self.removeUserFromRoom(userId, self.currentRoomId);
            }
        };

        self.cancel = function () {
            modalInstance.dismiss('cancel');
        };
    };

    self.activeState = {};
    self.sendMessage = function(message) {
        self.addMessageInRep({
            idRoom: self.currentRoomId,
            idUser: self.currentUserId,
            message: self.currentMessage
        });

        self.addMessageInRoom({
            currentRoomId: self.currentRoomId,
            message: (self.currentUserName + " Say: " + self.currentMessage),
            userId: self.currentUserId
        });
    };

    self.addMessageInRoom = function(object) {
        roomService.addMessage(object, function () {
            var observableRoom = $.grep(self.roomsRepository, function(item) {
                return item.id === object.currentRoomId;
            })[0];

            observableRoom.messagesHistory.push({message: object.message, userId: object.userId });
            self.setCurrentMessage('');
            self.refresh();
            return true;
        }, function () {
            console.log('can\'t add message in roomHistory');
        });
    };

    self.addMessageInRep = function(data) {
        var newMessageObject = new MessageModel({
            idRoom: data.idRoom,
            idUser: data.idUser,
            message: data.message
        });
        messageService.add(newMessageObject, function (newObj) {
            self.messagesRepository.push(newObj);
            return true;
        }, function () {
            console.log('can\'t add message in repository');
        });
    };

    self.removeRoom = function(roomId) {
        self.remove(self.currentRoomId, function(param) {
            self.SetCurrentRoomId(param);
            self.setRoomCreaterFlag(self.isCurrentUserRoom(self.currentRoomId, self.currentUserId));
            self.setActiveRoomFlag(false);
            self.refresh();
        });
    };

    self.remove = function(currentRoomIndex, nextFunction) {
        roomService.remove({
            id: ''
        }, function() {

            var str = '.cl' + currentRoomIndex;
            var elem = $(str);
            elem.removeClass('bounceInUp');
            elem.addClass('bounceOutRight');

            $timeout(function() {
                self.removeRoomObject(currentRoomIndex);
            }, 700);

            nextFunction('');

            return true;
        }, function() {
            console.log('can\'t remove room');
        });
    };

    self.removeUserFromRoom = function(userId, currentRoomId) {
        roomService.removeUserFromRoom({
            userIndex: userId
        }, {
            id: currentRoomId
        }, function() {

            console.log(self.roomsRepository);
            var observableRoom = $.grep(self.roomsRepository, function(item) {
                return item.id === currentRoomId;
            })[0];

            if (!observableRoom) {
                return;
            }

            var foundUserInRoom = $.grep(observableRoom.usersIDInRoom, function (userItem, index) {

                return userItem.userIndex === userId;
            });
            if (foundUserInRoom.length) {
                observableRoom.usersIDInRoom = _.filter(observableRoom.usersIDInRoom, function(n) {
                    return n.userIndex !== userId;
                });

                self.$apply();
            }
        }, function() {
            console.log('can\'t add user to room');
        });

    }

}]);
