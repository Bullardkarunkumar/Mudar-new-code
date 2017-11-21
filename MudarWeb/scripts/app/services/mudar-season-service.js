mudarApp.factory('seasonService', function ($http, $q, appSettings) {
    var seasonProductFactory = {};


    _getSeasons = function () {
        var deferred = $q.defer();
        $http.get(appSettings.apiServiceBaseUri + 'seasons').success(function (response) {
            deferred.resolve(response);
        }).error(function (err, status) {
            deferred.reject(err);
        });
        return deferred.promise;
    }

    _getSeason = function (id) {
        var deferred = $q.defer();
        $http.get(appSettings.apiServiceBaseUri + 'seasons/' + id).success(function (response) {
            deferred.resolve(response);
        }).error(function (err, status) {
            deferred.reject(err);
        }); 
        return deferred.promise;
    }
    _addUpdateSeason = function (season) {
        var deferred = $q.defer();
        $http.post(appSettings.apiServiceBaseUri + 'seasons/addUpdate', season).success(function (response) {
            deferred.resolve(response);
        }).error(function (err, status) {
            deferred.reject(err);
        });
        return deferred.promise;
    }


    _deleteSeason = function (id) {
        var deferred = $q.defer();
        $http.post(appSettings.apiServiceBaseUri + 'seasons/delete/' + id)
            .success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });
        return deferred.promise;
    }
 
    seasonProductFactory.getSeasons = _getSeasons;
    seasonProductFactory.getSeason = _getSeason;
    seasonProductFactory.addUpdateSeason = _addUpdateSeason;
    seasonProductFactory.deleteSeason = _deleteSeason;
    return seasonProductFactory;
});