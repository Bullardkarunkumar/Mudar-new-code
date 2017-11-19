mudarApp.factory('identityService', function ($http, $q, appSettings) {
    var idenityFactory = {};
    var _getUsers = function (roleName) {
        var deferred = $q.defer();
        $http.get(appSettings.apiServiceBaseUri + 'users/' + roleName).success(function (response) {
            deferred.resolve(response);
        }).error(function (err, status) {
            deferred.reject(err);
        });
        return deferred.promise;
    };

    var _getUserById = function (id) {
        var deferred = $q.defer();
        $http.get(appSettings.apiServiceBaseUri + 'user/' + id).success(function (response) {
            deferred.resolve(response);
        }).error(function (err, status) {
            deferred.reject(err);
        });
        return deferred.promise;
    };

    var _getRoles = function () {
        var deferred = $q.defer();
        $http.get(appSettings.apiServiceBaseUri + 'roles').success(function (response) {
            deferred.resolve(response);
        }).error(function (err, status) {
            deferred.reject(err);
        });
        return deferred.promise;
    };

    var _addOrUpdateEmployee = function (employee, brachRoleValue) {
        var deferred = $q.defer();
        $http.post(appSettings.apiServiceBaseUri + 'employees/' + brachRoleValue, employee).success(function (response) {
            deferred.resolve(response);
        }).error(function (err, status) {
            deferred.reject(err);
        });
        return deferred.promise;
    };

    var _deleteUser = function (id) {
        var deferred = $q.defer();
        $http.post(appSettings.apiServiceBaseUri + 'employees/delete/', id).success(function (response) {
            deferred.resolve(response);
        }).error(function (err, status) {
            deferred.reject(err);
        });
        return deferred.promise;
    };

    var _login = function (userloginInfo) {
        var deferred = $q.defer();
        $http.post(appSettings.apiServiceBaseUri + 'login', userloginInfo).success(function (response) {
            deferred.resolve(response);
        }).error(function (err, status) {
            deferred.reject(err);
        });
        return deferred.promise;
    };

    idenityFactory.getUsers = _getUsers;
    idenityFactory.getUserById = _getUserById;
    idenityFactory.getRoles = _getRoles;
    idenityFactory.addOrUpdateEmployee = _addOrUpdateEmployee;
    idenityFactory.login = _login;
    idenityFactory.deleteUser = _deleteUser;   

    return idenityFactory;
});