mudarApp.factory('categoryProductService', function ($http, $q, appSettings) {
    var categoryProductFactory = {};


    _getCategories = function () {
        var deferred = $q.defer();
        $http.get(appSettings.apiServiceBaseUri + 'categories').success(function (response) {
            deferred.resolve(response);
        }).error(function (err, status) {
            deferred.reject(err);
        });
        return deferred.promise;
    }

    _getCategory = function (id) {
        var deferred = $q.defer();
        $http.get(appSettings.apiServiceBaseUri + 'categories/' + id).success(function (response) {
            deferred.resolve(response);
        }).error(function (err, status) {
            deferred.reject(err);
        });
        return deferred.promise;
    }
    _addUpdateCategory = function (category) {
        var deferred = $q.defer();
        $http.post(appSettings.apiServiceBaseUri + 'categories/addUpdate', category).success(function (response) {
            deferred.resolve(response);
        }).error(function (err, status) {
            deferred.reject(err);
        });
        return deferred.promise;
    }


    _deleteCategory = function (id) {
        var deferred = $q.defer();
        $http.post(appSettings.apiServiceBaseUri + 'categories/delete/' + id)
            .success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });
        return deferred.promise;
    }



    _getProducts = function () {
        var deferred = $q.defer();
        $http.get(appSettings.apiServiceBaseUri + 'products').success(function (response) {
            deferred.resolve(response);
        }).error(function (err, status) {
            deferred.reject(err);
        });
        return deferred.promise;
    }
    _getBuyerProducts = function (id) {
        var deferred = $q.defer();
        $http.get(appSettings.apiServiceBaseUri + 'buyerProducts/' + id).success(function (response) {
            deferred.resolve(response);
        }).error(function (err, status) {
            deferred.reject(err);
        });
        return deferred.promise;
    }
    _getProduct = function (id) {
        var deferred = $q.defer();
        $http.get(appSettings.apiServiceBaseUri + 'products/' + id).success(function (response) {
            deferred.resolve(response);
        }).error(function (err, status) {
            deferred.reject(err);
        });
        return deferred.promise;
    }
    _addUpdateProduct = function (product) {
        var deferred = $q.defer();
        $http.post(appSettings.apiServiceBaseUri + 'products/addUpdate', product).success(function (response) {
            deferred.resolve(response);
        }).error(function (err, status) {
            deferred.reject(err);
        });
        return deferred.promise;
    }


    _deleteProduct = function (id) {
        var deferred = $q.defer();
        $http.post(appSettings.apiServiceBaseUri + 'products/delete/' + id)
            .success(function (response) {
                deferred.resolve(response);
            }).error(function (err, status) {
                deferred.reject(err);
            });
        return deferred.promise;
    }

    var _addUpdateBuyerProducts = function (buyerProducts) {
        var deferred = $q.defer();
        $http.post(appSettings.apiServiceBaseUri + 'buyerProducts', buyerProducts).success(function (response) {
            deferred.resolve(response);
        }).error(function (err, status) {
            deferred.reject(err);
        });
        return deferred.promise;
    };

    categoryProductFactory.getCategories = _getCategories;
    categoryProductFactory.getCategory = _getCategory;
    categoryProductFactory.addUpdateCategory = _addUpdateCategory;
    categoryProductFactory.deleteCategory = _deleteCategory;

    categoryProductFactory.getProducts = _getProducts;
    categoryProductFactory.getProduct = _getProduct;
    categoryProductFactory.addUpdateProduct = _addUpdateProduct;
    categoryProductFactory.deleteProduct = _deleteProduct;
    categoryProductFactory.getBuyerProducts = _getBuyerProducts;
    categoryProductFactory.addUpdateBuyerProducts = _addUpdateBuyerProducts;
    

    return categoryProductFactory;
});