/**
 * Created by vitali.nalivaika on 21.08.2015.
 */

socNetworkModule.service('PostService' ,[ function() {

    var self = this;
    self.post = [];
    self.src = $resource('api/post/:id:cmd',
          { id: "@id", cmd: "@cmd" }, //parameters default
          {
              ListTodos: { method: "GET", params: {} },
              GetTodo: { method: "GET", params: { id: 0 } },
              CreateTodo: { method: "POST", params: { content: "", order: 0, done: false }, isArray: true },
              CreateTodo1: { method: "POST", params: { id: 0 } },
              UpdateTodo: { method: "PATCH", params: { /*...*/ } },
              DeleteTodo: { method: "DELETE", params: { id: 0 } },
              ResetTodos: { method: "GET", params: { cmd: "reset" } }
          });

    self.getAll = function (onSuccess, onError) {
        self.src.CreateTodo({}, function (result) {
            self.post = result;
            onSuccess(self.post);
        });
    }

    self.getById = function (id, onSuccess, onError) {
        self.src.GetTodo({ id: id }, function (result) {
            onSuccess(result);
            alert(result.name);
        });

    }


}]);
