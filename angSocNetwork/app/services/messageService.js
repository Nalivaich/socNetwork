/**
 * Created by vitali.nalivaika on 05.08.2015.
 */

socNetworkModule.service('messageService' ,[ function() {
    var self = this;


    var messages = [];

    function asyncImitation(callback) {
        window.setTimeout(callback, Math.random() * 1000 + 1000);
    }

    function getNewId() {
        var lastItem = messages[messages.length - 1] || { id: 0 };

        return lastItem.id + 1;
    }

    self.add = function(message, onSuccess, onError) {
        asyncImitation(function() {
            message.id = getNewId();
            messages.push(message);
            onSuccess(message);
        });
    };


    var messagesList = [
        'tell me something interesting',
        'blue whale weighs up to 150 tons ',
        'wow',
        'I\'m bored',
        'it would be nice to go to rest',
        'you are right',
        'in the neck of the giraffe, only 5 vertebrae',
        'nice',
        'We need to find a job',
        'enough to sit in the chat, you need to get down to business'
    ];


}]);
