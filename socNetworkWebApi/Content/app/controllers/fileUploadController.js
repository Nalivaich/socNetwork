
socNetworkModule.controller('DemoFileUploadController', [
        '$scope', '$http', '$filter', '$window',
        function ($scope, $http) {
            var self = $scope;
            self.options = {
                url: 'api/pictures'
            };

            self.changeUrl = function (object) {

                self.options = {
                    url: 'api/users/' + object.userId + '/pictures/' + object.action
                };
            }

            self.$on('fileuploaddone', function (event, data) {
                var dataResponse = data.response().result.files;
                self.AddDataFiles(dataResponse);
            });

            self.$on('fileuploadfail', function (event, data) {
                //new exception
            });

            /*'fileuploadadd',
           'fileuploadsubmit',
           'fileuploadsend',
           'fileuploaddone',
           'fileuploadfail',
           'fileuploadalways',
           'fileuploadprogress',
           'fileuploadprogressall',
           'fileuploadstart',
           'fileuploadstop',
           'fileuploadchange',
           'fileuploadpaste',
           'fileuploaddrop',
           'fileuploaddragover',
           'fileuploadchunksend',
           'fileuploadchunkdone',
           'fileuploadchunkfail',
           'fileuploadchunkalways',
           'fileuploadprocessstart',
           'fileuploadprocess',
           'fileuploadprocessdone',
           'fileuploadprocessfail',
           'fileuploadprocessalways',
           'fileuploadprocessstop'*/

            if (!isOnGitHub) {
                self.loadingFiles = true;
                $http.get(url)
                    .then(
                    function (response) {
                        self.loadingFiles = false;
                        self.queue = response.data.files || [];
                    },
                    function () {
                        self.loadingFiles = false;
                    }
                );
            }



        }
])