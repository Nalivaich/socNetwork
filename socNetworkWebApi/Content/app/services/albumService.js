/**
 * Created by vitali.nalivaika on 21.08.2015.
 */

socNetworkModule.service('AlbumService', ['$http', '$resource', function ($http, $resource) {

    var self = this;
    self.albums = [];
    self.albumsSrc = $resource('api/albums/:action/:id/',
      {  }, //parameters default
      {
          ListTodos: { method: "GET", isArray: true },
          CreateTodo: { method: "POST", params: { action: "add" } },
          UpdateTodo: { method: "PATCH", params: {action:"update" } },
          DeleteTodo: { method: "DELETE",params: {action:"delete"} },
      });


    self.albumSrc = $resource('api/albums/:id',
      { id: "@id" }, //parameters default
      {
          GetTodo: { method: "GET" },
          CreateTodo: { method: "POST", isArray: true },
          UpdateTodo: { method: "PATCH", params: { /*...*/ } },
          DeleteTodo: { method: "DELETE" },
          ResetTodos: { method: "GET" }
      });


    self.albumGistsSrc = $resource('api/albums/:id/:gist',
      { id: "@id", gist: "@gist" }, //parameters default
      {
          ListTodos: { method: "GET", isArray: true },
          CreateTodo: { method: "POST", isArray: true },
          UpdateTodo: { method: "PATCH", params: { /*...*/ } },
          DeleteTodo: { method: "DELETE", params: { someId: 0 } },
          ResetTodos: { method: "GET" }
      });


    self.getAll = function (onSuccess, onError) {
        self.albumsSrc.ListTodos({}, function (result) {
            self.albums = result;
            onSuccess(self.albums);
        });
    }

    self.getById = function (id, onSuccess, onError) {
        self.albumSrc.GetTodo({ id: id }, function (result) {
            onSuccess(result);
        });
    }

    self.getComments = function (id, onSuccess, onError) {
        self.albumGistsSrc.ListTodos({ id: id, gist: "comments" }, function (result) {
            onSuccess(result);
        });
    }

    self.createAlbum = function (newObj, onSuccess, onError) {
        console.log(newObj);
        self.albumsSrc.CreateTodo(newObj, function (result) {
            onSuccess(result);
        });
    }

    self.updateAlbum = function (newObj, onSuccess, onError) {
        self.albumsSrc.UpdateTodo(newObj, function (result) {
            onSuccess(result);
        });
    }

    self.removeAlbum = function (id, onSuccess, onError) {
        self.albumsSrc.DeleteTodo({id:id}, function (result) {
            onSuccess(result);
        });
    }

}]);