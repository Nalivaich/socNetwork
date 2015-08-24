/**
 * Created by vitali.nalivaika on 05.08.2015.
 */
function MessageModel(data) {
    'use strict';

    if ( !(this instanceof MessageModel) ) {
        return new MessageModel(data);
    }

    var self = this;

    data = $.extend({
        idRoom: 0,
        idUser: 0,
        message: '',
        external: ''
    }, data);

    self.idRoom = data.idRoom;
    self.idUser = data.idUser;
    self.message = data.message;
    self.external = data.external;
}