/**
 * Created by vitali.nalivaika on 05.08.2015.
 */

socNetworkModule.service('userService' ,[ function() {

    var self = this;
    var users = [];

    function asyncImitation(callback) {
        window.setTimeout(callback, Math.random() * 1000 + 1000);
    }

    function getNewId() {
        var lastItem = users[users.length - 1] || { id: 0 };

        return lastItem.id + 1;
    }


    self.add = function(user, onSuccess, onError) {
        asyncImitation(function() {
            user.id = getNewId();
            user.userRooms = [];
            users.push(user);
            onSuccess(user);
        });
    };

    self.addUserRoom = function(user, room, onSuccess, onError) {
        asyncImitation(function() {

            var foundItem = $.grep(users, function (item) {
                return item.id === user.userIndex;
            })[0];

            foundItem.userRooms.push(room);
            onSuccess();
        });
    };

    self.isCurrentUserRoom = function(object, onSuccess, onError) {
        window.setTimeout(
            function() {
            }, Math.random() * 1000 + 1000);
    };

    self.getAll = function(onSuccess, onError) {
        asyncImitation(function() {
            onSuccess(users);
        });
    };

    function getRandomValue(min , max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    (function prepopulate(repeats) {
        var userTemplate = {
            name: [ 'Kirill', 'Vlad', 'Anton', 'Sergey', 'Genadiy', 'Aleksandr', 'Leonid', 'Dmitry', 'Artem', 'Pavel' ],
            lastName: [  'Kirillovich', 'Vladimirovich', 'Antonovich', 'Sergeevich', 'Genadievich', 'Aleksandrovich', 'Leonidovich', 'Dmitrievich', 'Artemovich', 'Kazimirovich' ]
        };

        function generateUser() {
            var generatedUser = {
                id: getNewId(),
                password: 1111,
                userRooms: []
            };

            $.each(userTemplate, function (prop, value) {
                generatedUser[prop] = value[getRandomValue(0, value.length - 1)];
            });

            return generatedUser;
        }

        while (repeats--) {
            users.push(generateUser());
        }
    })(4);


}]);
