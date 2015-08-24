/**
 * Created by vitali.nalivaika on 05.08.2015.
 */
function RoomModel(data) {
    'use strict';

    if ( !(this instanceof RoomModel) ) {
        return new RoomModel(data);
    }

    var self = this;

    data = $.extend({
        id: '',
        createrId: 0,
        name: '',
        privateFlag: false,
        usersIDInRoom: [],
        messagesHistory: [],
        external: ''
    }, data);

    self.id = data.id;
    self.createrId = data.createrId;
    self.name = data.name;
    self.privateFlag = data.privateFlag;
    self.usersIDInRoom = data.usersIDInRoom.map(function (currentvalue) {
        return {
            userIndex: currentvalue.userIndex
        };
    });
    self.messagesHistory = data.usersIDInRoom.map(function (currentvalue) {
        return {
            message: currentvalue.message,
            userId: currentvalue.userId
        };
    });
    self.external = data.external;
}