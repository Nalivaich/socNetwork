/**
 * Created by vitali.nalivaika on 05.08.2015.
 */

socNetworkModule.controller('AppController', ['$scope', 'userService', "$http", '$resource', function ($scope, userService, $http, $resource) {
    var self = $scope;

    /*$http.get('api/values/5').
      then(function (response) {
      }, function (response) {
      });*/

    var src = $resource('api/values/:id:cmd',
              { id: "@id", cmd: "@cmd" }, //parameters default
              {
                  ListTodos: { method: "GET", params: {} },
                  GetTodo: { method: "GET", params: { id: 0 } },
                  CreateTodo: { method: "POST", params: { content: "", order: 0, done: false  }, isArray: true },
                  UpdateTodo: { method: "PATCH", params: { /*...*/ } },
                  DeleteTodo: { method: "DELETE", params: { id: 0 } },
                  ResetTodos: { method: "GET", params: { cmd: "reset" } }
              });

    console.log('before ' + $scope.ss);

    $scope.res;
    var pp = src.CreateTodo({}, function (result) {
        $scope.res = result;
        console.log($scope.res[0].email);
    });

    
    /*$scope.phone = src.GetTodo({ phoneId:100500 }, function (phone) {
  
    });*/
    console.log(pp);
    self.headerBlock = '';

    self.templates =
        [ { name: 'template1.html', url: '../Static/noAutorizedHeader.html'},
            { name: 'template2.html', url: '../Static/autorizedHeader.html' }];
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



    

}]);