/**
 * Created by vitali.nalivaika on 05.08.2015.
 */

socNetworkModule.service('UserService', ['$http', '$resource', function ($http, $resource) {

    var self = this;
    self.users = [];
    self.userid = 10;

    self.usersSrc = $resource('api/users/:action/:id/',
      { id: "@id", action: "@action" }, //parameters default
      {
          ListTodos: { method: "GET", isArray: true },
          CreateTodo: { method: "POST", params: {action:"add"} },
          UpdateTodo: { method: "PATCH", params: { /*...*/ } },
          DeleteTodo: { method: "DELETE" },
      });


    self.userSrc = $resource('api/users/:id',
      { id: "@id"}, //parameters default
      {
          GetTodo: { method: "GET" },
          CreateTodo: { method: "POST", isArray: true },
          UpdateTodo: { method: "PATCH", params: { /*...*/ } },
          DeleteTodo: { method: "DELETE" },
          ResetTodos: { method: "GET" }
      });


    self.userGistsSrc = $resource('api/users/:id/:gist',
      { id: "@id", gist: "@gist" }, //parameters default
      {
          ListTodos: { method: "GET", isArray : true },
          CreateTodo: { method: "POST", isArray: true },
          UpdateTodo: { method: "PATCH", params: { /*...*/ } },
          DeleteTodo: { method: "DELETE", params: { someId: 0 } },
          ResetTodos: { method: "GET"}
      });

    self.userGistSrc = $resource('api/users/:id/:gist/:gistId',
      { id: "@id", gist: "@gist", gistID: "@gistId" }, //parameters default
      {
          GetTodo: { method: "GET" },
          CreateTodo: { method: "POST", isArray: true },
          UpdateTodo: { method: "PATCH", params: { /*...*/ } },
          DeleteTodo: { method: "DELETE", params: { someId: 0 } },
          ResetTodos: { method: "GET" }
      });
    

    self.getAll = function(onSuccess, onError ) {
        self.usersSrc.ListTodos({}, function (result) {
            self.users = result;
            onSuccess(self.users);
        });
    }

    self.getById = function (id, onSuccess, onError) {
        self.userSrc.GetTodo({ id: id }, function (result) {
            onSuccess(result);
        });

    }

    self.getAlbums = function (id, onSuccess, onError) {
        self.userGistsSrc.ListTodos({ id: id, gist: "albums" }, function (result) {
            onSuccess(result);
        });
    }

    self.getPosts = function (id, onSuccess, onError) {
        self.userGistsSrc.ListTodos({ id: id, gist: "posts" }, function (result) {
            onSuccess(result);
        });
    }

    self.getPictures = function (id, onSuccess, onError) {
        self.userGistsSrc.ListTodos({ id: id, gist: "pictures" }, function (result) {
            onSuccess(result);
        });
    }

    self.add = function (object, onSuccess, onError) {
        self.usersSrc.CreateTodo(object, function (result) {
            onSuccess(result);
        });
    }



}]);



/*self.src = $resource('api/user/:someId/:cmd',
      { id: "@someId", cmd: "@cmd" }, //parameters default
      {
          ListTodos: { method: "GET", params: {} },
          GetTodo: { method: "GET", params: { someId: 0 } },
          CreateTodo: { method: "POST", params: { }, isArray: true },
          CreateTodo1: { method: "POST", params: { }, isArray: true  },
          UpdateTodo: { method: "PATCH", params: {} },
          DeleteTodo: { method: "DELETE", params: { someId: 0 } },
          ResetTodos: { method: "GET", params: { cmd: "reset" } }
      });*/