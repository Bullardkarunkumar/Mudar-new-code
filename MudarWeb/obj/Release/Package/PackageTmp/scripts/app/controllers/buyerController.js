mudarApp.controller('buyerController', function ($scope, $state, $stateParams, $window) {
    $scope.progressWidth = "12.5%";
    $scope.steps = [
        { number: 1, title: 'Company Details', isActive: false, isCompleted: false, cssClass: '' },
        { number: 2, title: 'Contact Details', isActive: false, isCompleted: false, cssClass: '' },
        { number: 3, title: 'Product Details', isActive: false, isCompleted: false, cssClass: '' },
        { number: 4, title: 'Notify Details', isActive: false, isCompleted: false, cssClass: '' },
        { number: 5, title: 'Bank Details', isActive: false, isCompleted: false, cssClass: '' },
        { number: 6, title: 'Port Details', isActive: false, isCompleted: false, cssClass: '' },
        { number: 7, title: 'Price Terms', isActive: false, isCompleted: false, cssClass: '' },
        { number: 8, title: 'Payment Terms', isActive: false, isCompleted: false, cssClass: '' }
    ];
    $scope.setProgressWith = function (step) {
        //$scope.activeStep = step;
        angular.forEach($scope.steps, function (value, key) {
            if (value.number < step) {
                value.isCompleted = true;
                value.cssClass = 'done';
            }
            else if (value.number === step) {
                value.isActive = true;
                value.isCompleted = false;
                value.cssClass = 'active';
            }
            else if (value.number > step) {
                value.isActive = false;
                value.isCompleted = false;
                value.cssClass = '';
            }
        });
        $scope.progressWidth = (12.5 * step).toString() + "%";
        $window.scrollTo(0, 0);
    }

}).controller('buyerStep1Controller', function ($scope, $state, $stateParams) {
    $scope.setProgressWith(1);
    this.nextStep = function () {
        $state.go('buyer.step2');
    }
}).controller('buyerStep2Controller', function ($scope, $state, $stateParams) {
    $scope.setProgressWith(2);
    this.nextStep = function () {
        $state.go('buyer.step3');
    }

    this.previousStep = function () {
        $state.go('buyer.step1');
    }
}).controller('buyerStep3Controller', function ($scope, $state, $stateParams, categoryProductService) {
    $scope.setProgressWith(3);
    var vm = this;
    this.products = [];
    this.showProducts = function () {
        categoryProductService.getProducts().then(function (successResponse) {
            vm.products = successResponse;
        }, function (errorResponse) {

        });
    }

    this.nextStep = function () {
        $state.go('buyer.step4');
    }

    this.previousStep = function () {
        $state.go('buyer.step2');
    }
}).controller('buyerStep4Controller', function ($scope, $state, $stateParams, categoryProductService) {
    $scope.setProgressWith(4);

    this.nextStep = function () {
        $state.go('buyer.step5');
    }

    this.previousStep = function () {
        $state.go('buyer.step3');
    }
}).controller('buyerStep5Controller', function ($scope, $state, $stateParams, categoryProductService) {
    $scope.setProgressWith(5);

    this.nextStep = function () {
        $state.go('buyer.step6');
    }

    this.previousStep = function () {
        $state.go('buyer.step4');
    }
}).controller('buyerStep6Controller', function ($scope, $state, $stateParams, categoryProductService) {
    $scope.setProgressWith(6);

    this.nextStep = function () {
        $state.go('buyer.step7');
    }

    this.previousStep = function () {
        $state.go('buyer.step5');
    }
}).controller('buyerStep7Controller', function ($scope, $state, $stateParams, categoryProductService) {
    $scope.setProgressWith(7);

    this.nextStep = function () {
        $state.go('buyer.step8');
    }

    this.previousStep = function () {
        $state.go('buyer.step6');
    }
}).controller('buyerStep8Controller', function ($scope, $state, $stateParams, categoryProductService) {
    $scope.setProgressWith(8);

    this.previousStep = function () {
        $state.go('buyer.step7');
    }
});








