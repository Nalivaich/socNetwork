/**
 * Created by vitali.nalivaika on 05.08.2015.
 */

socNetworkModule.service('UserService', ['$http', '$resource', function ($http, $resource) {

    var self = this;
    self.users = [];

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

    self.userGistSrc = $resource('api/users/:id/:gist/:gistId/:action/:object',
      { id: "@id", gist: "@gist", gistId: "@gistId" }, //parameters default
      {
          GetTodo: { method: "GET" },
          CreateTodo: { method: "POST", isArray: true },
          UpdateAlbum: { method: "PATCH", params: { gist: "albums", action: "manage" } },
          DeleteTodo: { method: "DELETE", params: { action: "rollback", gist: "pictures" } },
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

    self.rollbackChanges = function (id, onSuccess, onError) {
        self.userGistSrc.DeleteTodo({id:id}, function (result) {
            onSuccess(result);
        });
    }

    /*self.updateAlbum = function (object, onSuccess, onError) {
        console.log(object);
        self.userGistSrc.UpdateAlbum({ id: 2, gistId: 3, object: object, }, function (result) {
            onSuccess(result);
        });
    }*/

   /* self.addAlbum = function (object, onSuccess, onError) {
        self.usersSrc.CreateTodo(object, function (result) {
            onSuccess(result);
        });
    }*/



}]);