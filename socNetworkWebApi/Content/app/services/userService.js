/**
 * Created by vitali.nalivaika on 05.08.2015.
 */

socNetworkModule.service('UserService', ['$http', '$resource', function ($http, $resource) {

    var self = this;
    self.users = [];
    self.userid = 10;
    self.src = $resource('api/user/:someId/:cmd',
          { id: "@someId", cmd: "@cmd" }, //parameters default
          {
              ListTodos: { method: "GET", params: {} },
              GetTodo: { method: "GET", params: { someId: 0 } },
              CreateTodo: { method: "POST", params: { }, isArray: true },
              CreateTodo1: { method: "POST", params: { }, isArray: true  },
              UpdateTodo: { method: "PATCH", params: { /*...*/ } },
              DeleteTodo: { method: "DELETE", params: { someId: 0 } },
              ResetTodos: { method: "GET", params: { cmd: "reset" } }
          });

    //api/user/id
    self.src2 = $resource('api/user/' + self.userid + '/:someId/:cmd',
      { id: "@someId", cmd: "@cmd" },
      {
          ListTodos: { method: "GET", params: {} },
          GetTodo: { method: "GET", params: { someId: 0 } },
          CreateTodo: { method: "POST", params: {}, isArray: true },
          UpdateTodo: { method: "PATCH", params: { /*...*/ } },
          DeleteTodo: { method: "DELETE", params: { someId: 0 } },
          ResetTodos: { method: "GET", params: { cmd: "reset" } }
      });

    self.getAll = function(onSuccess, onError ) {
            self.src.CreateTodo({ }, function (result) {
            self.users = result;
            onSuccess(self.users);
        });
    }

    self.getAlbums = function (id, onSuccess, onError) {
        self.src2.CreateTodo({ id: id, album: "album" }, function (result) {
            onSuccess(result);
        });
    }

    self.getPosts = function (id, onSuccess, onError) {
        self.src2.CreateTodo({ id: id, post: "post" }, function (result) {
            onSuccess(result);
        });
    }

    self.getPictures = function (id, onSuccess, onError) {
        self.src2.CreateTodo({ id: id, picture: "picture" }, function (result) {
            onSuccess(result);
        });
    }

    self.getById = function (id, onSuccess, onError) {
        self.src.GetTodo({id: id}, function (result) {
            onSuccess(result);
        });

    }

}]);
