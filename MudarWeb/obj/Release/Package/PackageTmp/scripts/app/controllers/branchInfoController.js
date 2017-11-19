mudarApp.controller('branchInfoController', function ($state, $stateParams, $rootScope, userContextService, branchService) {
    var vm = this;
    var title = '';
    this.branchIid = $stateParams.id;
    this.branch = {};
    function fnInit() {
        switch (userContextService.BranchType()) {
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

        if (vm.branchIid != null && vm.branchIid != '') {
            branchService.getBranchOrICSById(vm.branchIid).then(function (successResponse) {
                vm.branch = successResponse;
            }, function (err, status) {

            })
        }
    }
    fnInit();


    this.onBranchSave = function (isvalid) {
        //console.log(this.branch);
        if (isvalid) {
            this.branch.branchType = userContextService.BranchType();
            branchService.addOrUpdateBranchOrICS(this.branch).then(function (successReponse) {
                console.log(successReponse);
                vm.gotoBranches();
            }, function (err, status) {

            });
        }
    }

    this.gotoBranches = function () {
        $state.go("branches");
    }
});