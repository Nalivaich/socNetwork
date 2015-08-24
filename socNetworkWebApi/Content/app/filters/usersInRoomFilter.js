/**
 * Created by vitali.nalivaika on 10.08.2015.
 */


socNetworkModule.filter('formatText', function(){
    var self = this;
    return function (items, mode, roomId, userId, roomRep, userRep) {
        var allUsersId = [];
        var allUsersIdInRoom = [];
        var resultArray = [];

        allUsersId = findAllUsersId(userRep);
        allUsersIdInRoom = findAllUsersIdInRoom(roomRep, roomId);

        if(mode.length < 9 ) {
            return findUsersOutsideRoom (allUsersId, allUsersIdInRoom, userRep);
        }
        return findUsersInsideRoom (allUsersIdInRoom, userRep , userId);
    };

    function findAllUsersId (userRep) {
        var resultArray = [];
        resultArray = _.map(userRep, function(n) {
            return n.id
        });

        return resultArray;
    }

    function findAllUsersIdInRoom (roomRep, roomId) {
        var resultArray = [];
        var currentRoom = _.filter(roomRep, function(n) {
            return n.id == roomId;
        })[0];
        resultArray = _.map(currentRoom.usersIDInRoom, function(n) {
            return n.userIndex;
        });

        return resultArray
    }

    function findUsersInsideRoom (allUsersIdInRoom, userRep , userId) {
        var resultArray = [];
        var UsersOutsideRoom = [];
        resultArray = _.filter(allUsersIdInRoom, function(n) {
            return n != userId;
        });

        UsersOutsideRoom = _.filter(userRep, function(n) {
            var result = _.filter(resultArray, function(m) {
                return m == n.id;
            });

            return (result.length);
        });

        return UsersOutsideRoom;
    }

    function findUsersOutsideRoom (allUsersId, allUsersIdInRoom, userRep) {
        var resultArray = [];
        var UsersOutsideRoom = [];
        resultArray = _.filter(allUsersId, function(n) {
            var result = _.filter(allUsersIdInRoom, function(m) {
               return m == n;
            });

            return (!result.length);
        });

        UsersOutsideRoom = _.filter(userRep, function(n) {
            var result = _.filter(resultArray, function(m) {
                return m == n.id;
            });

            return (result.length);
        });

        return UsersOutsideRoom;
    }

});

