/**
 * Created by vitali.nalivaika on 21.08.2015.
 */

socNetworkModule.service('CommentService', ['$http', '$resource', function ($http, $resource) {

    var self = this;
    self.comments = [];
    self.commentsSrc = $resource('api/comments/:action/:id/',
      {}, //parameters default
      {
          ListTodos: { method: "GET", isArray: true },
          CreateTodo: { method: "POST" },
          UpdateTodo: { method: "PATCH", params: { action: "manage" } },
          DeleteTodo: { method: "DELETE", params: { action: "delete" } },
      });


    self.commentSrc = $resource('api/comments/:id',
      { id: "@id" }, //parameters default
      {
          GetTodo: { method: "GET" },
          CreateTodo: { method: "POST", isArray: true },
          UpdateTodo: { method: "PATCH", params: { /*...*/ } },
          DeleteTodo: { method: "DELETE" },
          ResetTodos: { method: "GET" }
      });

    self.getAll = function (onSuccess, onError) {
        self.commentsSrc.ListTodos({}, function (result) {
            self.comments = result;
            onSuccess(self.comments);
        });
    }

    self.getById = function (id, onSuccess, onError) {
        self.albumSrc.GetTodo({ id: id }, function (result) {
            onSuccess(result);
        });
    }


    self.createComment = function (newObj, onSuccess, onError) {
        self.commentsSrc.CreateTodo(newObj, function (result) {
            onSuccess(result);
        }, function (result) {
            onError(result);
        });
    }

    self.updateComment = function (newObj, onSuccess, onError) {
        self.commentsSrc.UpdateTodo(newObj, function (result) {
            onSuccess(result);
        });
    }

    self.removeComment = function (id, onSuccess, onError) {
        self.commentsSrc.DeleteTodo({ id: id }, function (result) {
            onSuccess(result);
        });
    }

}]);