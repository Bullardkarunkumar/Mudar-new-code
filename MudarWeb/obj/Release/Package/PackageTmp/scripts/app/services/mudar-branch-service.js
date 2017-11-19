mudarApp.factory('branchService', function ($http, $q, appSettings) {

    var branchFactory = {};

    _getAllBranchAndICS = function () {
        var deferred = $q.defer();
        $http.get(appSettings.apiServiceBaseUri + 'branchesandics').success(function (response) {
            deferred.resolve(response);
        }).error(function (err, status) {
            deferred.reject(err);
        });
        return deferred.promise;
    }

    _getBranchesByType = function (branchtype) {
        var deferred = $q.defer();
        $http.get(appSettings.apiServiceBaseUri + 'branches/type/' + branchtype).success(function (response) {
            deferred.resolve(response);
        }).error(function (err, status) {
            deferred.reject(err);
        });
        return deferred.promise;
    }

    _getBranchOrICSById = function (id) {
        var deferred = $q.defer();
        $http.get(appSettings.apiServiceBaseUri + 'branches/' + id).success(function (response) {
            deferred.resolve(response);
        }).error(function (err, status) {
            deferred.reject(err);
        });
        return deferred.promise;
    }

    _addOrUpdateBranchOrICS = function (brannchOrIcs) {
        var deferred = $q.defer();
        $http.post(appSettings.apiServiceBaseUri + 'addUpdateBranch', brannchOrIcs).success(function (response) {
            deferred.resolve(response);
        }).error(function (err, status) {
            deferred.reject(err);
        });
        return deferred.promise;
    }

    _branchDelete = function (id) {
        var deferred = $q.defer();
        $http.post(appSettings.apiServiceBaseUri + 'BranchDelete/' + id).success(function (response) {
            deferred.resolve(response);
        }).error(function (err, status) {
            deferred.reject(err);
        });
        return deferred.promise;
    }

    branchFactory.getAllBranchAndICS = _getAllBranchAndICS;
    branchFactory.getBranchesByType = _getBranchesByType;
    branchFactory.getBranchOrICSById = _getBranchOrICSById;
    branchFactory.addOrUpdateBranchOrICS = _addOrUpdateBranchOrICS;
    branchFactory.branchDelete = _branchDelete;

    return branchFactory;
});