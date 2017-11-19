mudarApp.controller('userInfoController', function ($state, $stateParams, allBranchAndICS, userContextService, identityService) {
    var vm = this;
    this.branches = allBranchAndICS;
    this.userId = $stateParams.id;
    this.userInfo = {};

    this.fnInit = function () {
        identityService.getUserById(this.userId).then(function (response) {
            vm.userInfo = response;
        }, function (err, status) {
        });
    }
    this.fnInit();

    this.onEmployeeSave = function (isValid) {
        if (isValid) {
            var brachRoleValue = userContextService.RoleSelected();
            alert(brachRoleValue);
            identityService.addOrUpdateEmployee(this.userInfo, brachRoleValue).then(function (response) {
                $state.go("users");
            }, function (err, status) {
            });
        }
    }

    this.gotoEmployees = function () {
        $state.go('users');
    }

});