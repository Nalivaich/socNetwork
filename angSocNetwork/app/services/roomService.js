/**
 * Created by vitali.nalivaika on 05.08.2015.
 */

socNetworkModule.service('roomService' ,[ function() {
    var self = this;

    var rooms = [];

    function asyncImitation(callback) {
        window.setTimeout(callback, Math.random() * 1000 + 1000);
    }

    function getNewId() {
        var lastItem = rooms[rooms.length - 1] || { id: 0 };

        return lastItem.id + 1;
    }

    self.add = function(room, onSuccess, onError) {
        asyncImitation(function() {
            room.id = getNewId();
            room.messagesHistory = [];
            rooms.push(room);
            onSuccess(room);
        });
    };

    self.remove = function(room, onSuccess, onError) {
        asyncImitation(function() {
            rooms = $.grep(rooms, function (item) {
                return item.id !== room.id;
            });

            onSuccess();
        });
    };

    self.addUserToRoom = function(user, room, onSuccess, onError) {
        asyncImitation(function() {

            var foundItem = $.grep(rooms, function (item) {
                return item.id === room.id;
            })[0];
            var foundUserInRoom = $.grep(foundItem.usersIDInRoom, function (userItem) {

                return userItem.userIndex === user.userIndex;
            });

            if (!foundUserInRoom.length) {
                foundItem.usersIDInRoom.push(user);
            }
            onSuccess();
        });
    };

    self.removeUserFromRoom = function(user, room, onSuccess, onError) {
        asyncImitation(function() {

            var foundItem = $.grep(rooms, function (item) {
                return item.id === room.id;
            })[0];
            var foundUserInRoom = $.grep(foundItem.usersIDInRoom, function (userItem) {

                return userItem.userIndex === user.userIndex;
            });

            if (foundUserInRoom.length) {
                foundItem.usersIDInRoom = _.filter(foundItem.usersIDInRoom, function(n) {
                    return n.userIndex !== user.userIndex;
                });
            }

            onSuccess();
        });
    };

    self.getAll = function(onSuccess, onError) {
        asyncImitation(function() {
            onSuccess(rooms);
        });
    };

    self.addMessage = function(object, onSuccess, onError) {
        var observableRoom = $.grep(rooms, function(item) {
            return item.id == object.currentRoomId;
        })[0];

        observableRoom.messagesHistory.push({message: object.message, userId: object.userId });

        asyncImitation(function() {
            onSuccess();
        });
    };

    function getRandomValue(min , max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    (function prepopulate(repeats) {
        var roomTemplate = {
            name: [ 'My Best Room', 'Only men)', 'bookworms', 'Gough died', 'hitch-hiking', 'fishing', 'hunting', 'fishing & hunting', 'like a boss now', 'news' ],
            privateFlag: [  true, false, true, false, true, false, true, false, true, false ]
        };

        function generateRoom() {
            var generatedRoom = {
                id: getNewId(),
                messagesHistory: [],
                createrId: getRandomValue(0, 5),
                usersIDInRoom: [
                    { userIndex: getRandomValue(1, 4) }
                ]
            };

            $.each(roomTemplate, function (prop, value) {
                generatedRoom[prop] = value[getRandomValue(0, value.length - 1)];
            });

            return generatedRoom;
        }

        while (repeats--) {
            rooms.push(generateRoom());
        }
    })(5);


}]);