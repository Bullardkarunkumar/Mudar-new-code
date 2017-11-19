mudarApp.controller('usersController', function (identityService, userContextService, allRoles, $state) {
    var vm = this;
    this.users = [];
    this.roles = allRoles;
    this.selectedRole;
    //fnInit();

    function fnInit() {
        identityService.getRoles().then(function (successResponse) {
            vm.roles = successResponse;
        }, function (errorResponse) {

        });
    }

    this.OnRoleSelected = function (roleName) {
        userContextService.RoleSelected(this.selectedRole);
        identityService.getUsers(roleName).then(function (successResponse) {
            vm.users = successResponse;
        }, function (errorResponse) {

        });
    }

    this.onUserSelected = function (userid) {
        if (userid == null || userid == undefined) {
            $state.go('userDetails');
        }
        else {
            $state.go('userDetails', { id: userid });
        }
    }

    this.onUserDelete = function (userid) {
        identityService.deleteUser(userid).then(function (successResponse) {            
            var removeItem = vm.users.filter(itm => itm.userId == userid)[0];
            vm.users.splice(vm.users.indexOf(removeItem), 1);
        }, function (errorResponse) {

        });
    }


});