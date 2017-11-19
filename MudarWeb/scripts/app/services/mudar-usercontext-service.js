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

    _buyerId = function (value) {
        if (value == null || value == undefined) {
            return localStorageService.get('BuyerId');
        }
        else {
            localStorageService.set('BuyerId', value);
            return value;
        }
    }

    _fromRegister = function (value) {
        if (value == null || value == undefined) {
            return localStorageService.get('FromRegister');
        }
        else {
            localStorageService.set('FromRegister', value);
            return value;
        }
    }
    
    userContext.BranchType = _branchType;
    userContext.RoleSelected = _roleSelected;
    userContext.IsLoggedIn = _isLoggedIn;
    userContext.UserDetails = _userDetails;
    userContext.clearAll = _clearAll;
    userContext.buyerId = _buyerId;
    userContext.fromRegister = _fromRegister;
    return userContext;

});