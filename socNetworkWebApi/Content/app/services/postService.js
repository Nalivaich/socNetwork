/**
 * Created by vitali.nalivaika on 21.08.2015.
 */

socNetworkModule.service('PostService', ['$http', '$resource', function ($http, $resource) {

    var self = this;
    self.post = [];
    self.postsSrc = $resource('api/posts/:action/:id/:cmd',
          { id: "@id", cmd: "@cmd" }, //parameters default
          {
              ListTodos: { method: "GET", isArray: true },
              GetTodo: { method: "GET", params: { id: 0 } },
              CreateTodo: { method: "POST", params: { action: "add" } },
              CreateTodo1: { method: "POST", params: { id: 0 } },
              UpdateTodo: { method: "PATCH", params: { /*...*/ } },
              DeleteTodo: { method: "DELETE", params: { id: 0 } },
              ResetTodos: { method: "GET", params: { cmd: "reset" } }
          });

    self.postSrc = $resource('api/posts/:id',
          { id: "@id" }, //parameters default
          {
              GetTodo: { method: "GET" },
              CreateTodo: { method: "POST", isArray: true },
              UpdateTodo: { method: "PATCH", params: { /*...*/ } },
              DeleteTodo: { method: "DELETE" },
              ResetTodos: { method: "GET" }
          });

    self.postGistsSrc = $resource('api/posts/:id/:gist',
          { id: "@id", gist: "@gist" }, //parameters default
          {
              ListTodos: { method: "GET", isArray: true },
              CreateTodo: { method: "POST", isArray: true },
              UpdateTodo: { method: "PATCH", params: { /*...*/ } },
              DeleteTodo: { method: "DELETE", params: { someId: 0 } },
              ResetTodos: { method: "GET" }
          });

    self.getAll = function (onSuccess, onError) {
        self.postsSrc.ListTodos({}, function (result) {
            onSuccess(result);
        }, function (result) {
            onError(result);
        });
    }

    self.getById = function (id, onSuccess, onError) {
        self.postSrc.GetTodo({ id: id }, function (result) {
            onSuccess(result);
        });
    }

    self.getComments = function (id, onSuccess, onError) {
        self.postGistsSrc.ListTodos({ id: id, gist: "comments" }, function (result) {
            onSuccess(result);
        });
    }

    self.createPost = function (newObj, onSuccess, onError) {
        self.postsSrc.CreateTodo(newObj, function (result) {
            onSuccess(result);
        });
    }

    self.getPictures = function (id, onSuccess, onError) {
        self.postGistsSrc.ListTodos({ id: id, gist: "pictures" }, function (result) {
            onSuccess(result);
        });
    }


}]);
