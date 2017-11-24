mudarApp.directive('ngFiles', ['$parse', function ($parse) {

    function fn_link(scope, element, attrs) {
        var onChange = $parse(attrs.ngFiles);
        element.on('change', function (event) {
            onChange(scope, { $files: event.target.files });
        });
    };

    return {
        link: fn_link
    }
}])

    .controller('farmerInfoController', function ($http,$state, appSettings) {
        debugger;
        var self = this;        

        var formdata = new FormData();
        this.getTheFiles = function ($files) {
            debugger;
            angular.forEach($files, function (value, key) {
                formdata.append(key, value);
            });
        };
      
        var _url =appSettings.apiServiceBaseUri + 'uploadfile/';
        // NOW UPLOAD THE FILES.
        this.uploadFiles = function () {
            debugger;
            var request = {
                method: 'POST',
                url: _url,
                data: formdata,
                headers: {
                    'Content-Type': undefined
                }              
            };

            // SEND THE FILES.
            $http(request)
                .success(function (d) {
                    alert(d);
                })
                .error(function () {
                });
        }
    });