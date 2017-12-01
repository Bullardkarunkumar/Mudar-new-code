mudarApp.controller('buyerListController', function ($scope, $state, allBuyers, userContextService) {
    $scope.buyers = allBuyers;
    $scope.onBuyerEdit = function (id) {
        userContextService.buyerId(id);
        $state.go('buyer.step1');
    }

    $scope.onBuyerAdd = function () {
        userContextService.buyerId('');
        $state.go('buyer.step1');
    }

}).controller('buyerController', function ($scope, $state, $stateParams, $window, identityService, userContextService) {

    $scope.id = userContextService.buyerId();
    $scope.buyers = [];
    $scope.progressWidth = "12.5%";
    $scope.buyerInfo = {};
    $scope.steps = [
        { number: 1, title: 'Company Details', isActive: false, isCompleted: false, cssClass: '', hide: false },
        { number: 2, title: 'Contact Details', isActive: false, isCompleted: false, cssClass: '', hide: false },
        { number: 3, title: 'Product Details', isActive: false, isCompleted: false, cssClass: '', hide: false },
        { number: 4, title: 'Notify Details', isActive: false, isCompleted: false, cssClass: '', hide: false },
        { number: 5, title: 'Bank Details', isActive: false, isCompleted: false, cssClass: '', hide: false },
        { number: 6, title: 'Port Details', isActive: false, isCompleted: false, cssClass: '', hide: false },
        { number: 7, title: 'Price Terms', isActive: false, isCompleted: false, cssClass: '', hide: false },
        { number: 8, title: 'Payment Terms', isActive: false, isCompleted: false, cssClass: '', hide: false }
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

    if ($scope.id) {
        identityService.getBuyer($scope.id).then(function (successRespone) {
            $scope.buyerInfo = successRespone;
            console.log($scope.buyerInfo);
        }, function (errorResponse) { })
    }
    else {
        $scope.buyerInfo.bankorConsignee = null;
    }

    $scope.addUpdateBuyer = function () {
        if ($scope.id != null && $scope.id != undefined && $scope.id != '') {
            identityService.updateBuyer($scope.id, $scope.buyerInfo).then(function (successRespone) {
                //alert(successRespone);
            }, function (errorResponse) { })
        }
        else {
            identityService.addBuyer($scope.buyerInfo).then(function (successRespone) {
                //alert(successRespone);
                userContextService.buyerId(successRespone);
            }, function (errorResponse) { })
        }
    }

}).controller('buyerStep1Controller', function ($scope, $state, $stateParams, identityService, userContextService) {
    $scope.setProgressWith(1);
    this.nextStep = function () {
        $scope.addUpdateBuyer();
        $state.go('buyer.step2');
    }
}).controller('buyerStep2Controller', function ($scope, $state, $stateParams) {
    $scope.setProgressWith(2);
    this.nextStep = function () {
        $scope.addUpdateBuyer();
        $state.go('buyer.step3');
    }

    this.previousStep = function () {
        $state.go('buyer.step1');
    }
}).controller('buyerStep3Controller', function ($scope, $state, $stateParams, categoryProductService, identityService, userContextService) {
    $scope.setProgressWith(3);
    var vm = this;
    this.products = [];

    categoryProductService.getBuyerProducts($scope.id).then(function (successResponse) {
        vm.products = successResponse;
    }, function (errorResponse) {

    });

    this.nextStep = function () {
        var bid = userContextService.buyerId();
        //alert(bid);
        angular.forEach(this.products, function (value, key) {
            value.buyerId = bid;
            value.isDeleted = !value.isBuyerProduct;
        })
        categoryProductService.addUpdateBuyerProducts(this.products).then(function (successResponse) {
            $state.go('buyer.step4');
        }, function (errorResponse) {

        });
    }

    this.previousStep = function () {
        $state.go('buyer.step2');
    }
}).controller('buyerStep4Controller', function ($scope, $state, $stateParams, identityService) {
    $scope.setProgressWith(4);

    $scope.OnNotifySameAsBuyer = function () {
        if ($scope.notifySameAsBuyer) {
            $scope.buyerInfo.notifyName = $scope.buyerInfo.buyerCompanyName;
            $scope.buyerInfo.nAddressLine1 = $scope.buyerInfo.cAddressLine1;
            $scope.buyerInfo.nAddressLine2 = $scope.buyerInfo.cAddressLine2;
            $scope.buyerInfo.nCity = $scope.buyerInfo.cCity;
            $scope.buyerInfo.nState = $scope.buyerInfo.cState;
            $scope.buyerInfo.nPincode = $scope.buyerInfo.cPincode;
            $scope.buyerInfo.nCountry = $scope.buyerInfo.cCountry;
        }
        else {
            $scope.buyerInfo.notifyName = '';
            $scope.buyerInfo.nAddressLine1 = '';
            $scope.buyerInfo.nAddressLine2 = '';
            $scope.buyerInfo.nCity = '';
            $scope.buyerInfo.nState = '';
            $scope.buyerInfo.nPincode = '';
            $scope.buyerInfo.nCountry = '';
        }
    }
    this.nextStep = function () {
        $scope.addUpdateBuyer();
        $state.go('buyer.step5');
    }

    this.previousStep = function () {
        $state.go('buyer.step3');
    }
}).controller('buyerStep5Controller', function ($scope, $state, $stateParams, identityService) {
    $scope.setProgressWith(5);
    
    this.nextStep = function () {
        $scope.addUpdateBuyer();
        $state.go('buyer.step6');
    }

    this.previousStep = function () {
        $state.go('buyer.step4');
    }
    }).controller('buyerStep6Controller', function ($scope, $state, $stateParams, userContextService, identityService, categoryProductService) {
        $scope.setProgressWith(6);
        $scope.id = userContextService.buyerId();
        $scope.buyerTransportDetails = {};
        $scope.buyerTransportDetails.buyerId = $scope.id;
    if ($scope.id) {
        categoryProductService.getBuyerTransportDetails($scope.id).then(function (successRespone) {
            $scope.buyerTransportDetails = successRespone;
            console.log($scope.buyerTransportDetails);
        }, function (errorResponse) {
            
            })
    }

    this.nextStep = function () {
        categoryProductService.addUpdateBuyerTransport($scope.buyerTransportDetails).then(function (successResponse) {
            $state.go('buyer.step7');
        }, function (errorResponse) {

        });
    }

    this.previousStep = function () {
        $state.go('buyer.step5');
    }
    }).controller('buyerStep7Controller', function ($scope, $state, $stateParams, userContextService, categoryProductService) {
        $scope.setProgressWith(7);
        $scope.id = userContextService.buyerId();
        $scope.buyerPriceTermDetails = {
            cIF_Seaport: 0,
            fOB_India: 0,
            cIF_Sea_By: 0,
            cIF_Air_By_EuropeandEastUSA: 0,
            cIF_AIR_By_WEST_USA: 0,
            bpt_100_advance: 0,
            bpt_50_adv_50_againstDocs: 0,
            bpt_100_againstDocs: 0,
            no_of_Days_Count_fromInvoice: 0,
            noofDaysfromInvoice: 0
        };
        $scope.buyerPriceTermDetails.buyerId = $scope.id;
    if ($scope.id) {
        categoryProductService.getBuyerPriceTermDetails($scope.id).then(function (successRespone) {
            $scope.buyerPriceTermDetails = successRespone;
            console.log($scope.buyerTransportDetails);
        }, function (errorResponse) {
            
            })
    }
   
    this.nextStep = function () {
        categoryProductService.addUpdateBuyerPriceTerm($scope.buyerPriceTermDetails).then(function (successResponse) {
            $state.go('buyer.step8');
        }, function (errorResponse) {

        });
    }

    this.previousStep = function () {
        $state.go('buyer.step6');
    }
    }).controller('buyerStep8Controller', function ($scope, $state, $stateParams, userContextService, categoryProductService) {
    $scope.setProgressWith(8);
    $scope.id = userContextService.buyerId();
    $scope.buyerPriceTermDetails = {
        cIF_Seaport: 0,
        fOB_India: 0,
        cIF_Sea_By: 0,
        cIF_Air_By_EuropeandEastUSA: 0,
        cIF_AIR_By_WEST_USA: 0,
        bpt_100_advance: 0,
        bpt_50_adv_50_againstDocs: 0,
        bpt_100_againstDocs: 0,
        no_of_Days_Count_fromInvoice: 0,
        noofDaysfromInvoice: 0
    };
    $scope.buyerPriceTermDetails.buyerId = $scope.id;
    if ($scope.id) {
        categoryProductService.getBuyerPriceTermDetails($scope.id).then(function (successRespone) {
            $scope.buyerPriceTermDetails = successRespone;
            console.log($scope.buyerTransportDetails);
        }, function (errorResponse) {
            $scope.buyerPriceTermDetails.buyerId = $scope.id;})
    }
    this.previousStep = function () {
        $state.go('buyer.step7');
    }
    this.lastStep = function () {
        categoryProductService.addUpdateBuyerPriceTerm($scope.buyerPriceTermDetails).then(function (successResponse) {
            $state.go('buyer.step8');
            alert("Email will be sent to your registored e-mail ID");
            categoryProductService.sendEmail($scope.id);
            $state.go('buyerList');    
        }, function (errorResponse) {

        });
    }
});








