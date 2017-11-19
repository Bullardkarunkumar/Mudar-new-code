mudarApp.controller('branchesController', function (branchService, userContextService, $state, $rootScope) {
    //$scope.BranchesMessage = "Welcome to Mudar Branch";
    var vm = this;
    this.branchType = '1';
    this.branches = [];
    this.title = '';
    fnInit();
    function fnInit() {
        fnLoadBranchData();
    }

    function fnLoadBranchData() {
        switch (vm.branchType) {
            case "0":
                vm.title = "ICS";
                break;
            case "1":
                vm.title = "Branch";
                break;
            case "2":
                vm.title = "ICS Supplier";
                break;
        }
        branchService.getBranchesByType(vm.branchType).then(function (successResponse) {
            vm.branches = successResponse;
        }, function (errorResponse) {

        });
    }

    branchService.getBranchesByType(vm.branches).then(function (data) { }, function (eoor) { });

    this.onSelectedOption = function () {
        fnLoadBranchData();
    }

    this.onBranchSelected = function (branchId) {
        userContextService.BranchType(this.branchType);
        if (branchId == null) {
            $state.go('branchdetails');
        }
        else {
            $state.go('branchdetails', { id: branchId });
        }
    }

    this.onBranchDeleted = function (branchId) {
        branchService.branchDelete(branchId).then(function (successResponse) {
            //$state.go('branches');
            var removeItem = vm.branches.filter(itm => itm.branchId == branchId)[0];
            vm.branches.splice(vm.branches.indexOf(removeItem), 1);

        }, function (errorResponse) {

        });

    }
});