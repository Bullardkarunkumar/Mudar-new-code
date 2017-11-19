mudarApp.factory('userContextService', function (localStorageService, $cookies) {
    var userContext = {};
    _branchType = function (value) {
        if (value == null || value == undefined)
            return localStorageService.get('BranchType');
        else {
            localStorageService.set('BranchType', value);
            return value;
        }
    }

    _roleSelected = function (value) {
        if (value == null || value == undefined)
            return localStorageService.get('RoleSelected');
        else {
            localStorageService.set('RoleSelected', value);
            return value;
        }
    }

    _isLoggedIn = function (value) {
        if (value == null || value == undefined)
            return localStorageService.get('IsLoggedIn');
        else {
            localStorageService.set('IsLoggedIn', value);
            return value;
        }
    }

    _userDetails = function (value) {
        if (value == null || value == undefined) {
            //return JSON.parse($cookies.get("UserDetails"));
            return localStorageService.get('UserDetails');
        }            
        else {
            localStorageService.set('UserDetails', value);
            //$cookies.set("UserDetails", JSON.stringify(value));
            return value;
        }
    }

    _clearAll = function () {
        localStorageService.clearAll();
    }
    
    userContext.BranchType = _branchType;
    userContext.RoleSelected = _roleSelected;
    userContext.IsLoggedIn = _isLoggedIn;
    userContext.UserDetails = _userDetails;
    userContext.clearAll = _clearAll;
    return userContext;

});