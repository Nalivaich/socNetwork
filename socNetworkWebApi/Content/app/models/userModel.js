/**
 * Created by vitali.nalivaika on 05.08.2015.
 */
function UserModel(data) {
    'use strict';

    if ( !(this instanceof UserModel) ) {
        return new UserModel(data);
    }

    var self = this;

    data = $.extend({
        id: 0,
        name: '',
        lastName: '',
        password: '',
        userRooms: [],
        external: ''
    }, data);

    self.id = data.id;
    self.name = data.name;
    self.lastName = data.lastName;
    self.password = data.password;
    self.userRooms = data.userRooms.map(function (currentvalue) {
        return {
            roomIndex: currentvalue.roomIndex
        };
    });
    self.external = data.external;

    self.fullName = function () {
        return (self.name + " " + self.lastName);
    };
}
