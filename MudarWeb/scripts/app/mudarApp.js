var mudarApp = angular.module('mudarApp', ['ui.router', 'LocalStorageModule', 'blockUI', 'ngCookies']);

mudarApp.config(function ($stateProvider, $urlRouterProvider, $locationProvider, blockUIConfig) {
    $urlRouterProvider.otherwise('/login');
    //$locationProvider.html5Mode(true);
    $stateProvider
    .state('login', {
        url: '/login',
        controller: 'loginController',
        controllerAs: 'loginCtrl',
        templateUrl: '/scripts/app/templates/mudar-login.html'
    })
    .state('dashboard', {
        url: '/dashboard',
        controller: 'dashboardController',
        controllerAs: 'dashboardCtrl',
        templateUrl: '/scripts/app/templates/mudar-dashboard.html'
    }).state('branches', {
        url: '/branches',
        controller: 'branchesController',
        controllerAs: 'branchCtrl',
        templateUrl: '/scripts/app/templates/mudar-branches.html'
    }).state('branchdetails', {
        url: '/branches/:id?',
        controller: 'branchInfoController',
        controllerAs: 'branchInfoCtrl',
        templateUrl: '/scripts/app/templates/mudar-branchInfo.html'
    }).state('users', {
        url: '/users',
        controller: 'usersController',
        controllerAs: 'userCtrl',
        templateUrl: '/scripts/app/templates/mudar-users.html',
        resolve: {
            allRoles: function (identityService) {
                return identityService.getRoles().then(function (response) {
                    console.log(response);
                    return response;
                }, function () {
                    alert("Error while fetching roles");
                })
            }
        }
    }).state('userDetails', {
        url: '/users/:id?',
        controller: 'userInfoController',
        controllerAs: 'userInfoCtrl',
        templateUrl: '/scripts/app/templates/mudar-userInfo.html',
        resolve: {
            allBranchAndICS: function (branchService, userContextService) {
                var btype = userContextService.RoleSelected();
                return branchService.getBranchesByType(btype).then(function (response) {
                    //console.log(response);
                    return response;
                }, function () {
                    alert("Error while fetching branch list");
                })
            }
        }
    }).state('categories', {
        url: '/categories',
        controller: 'categoriesController',
        controllerAs: 'categoryCtrl',
        templateUrl: '/scripts/app/templates/mudar-categories.html'
    }).state('categoryDetails', {
        url: '/categories/:id?',
        controller: 'categoryInfoController',
        controllerAs: 'categoryInfoCtrl',
        templateUrl: '/scripts/app/templates/mudar-categoryInfo.html'
    }).state('products', {
        url: '/products',
        controller: 'productsController',
        controllerAs: 'productsCtrl',
        templateUrl: '/scripts/app/templates/mudar-products.html'
    }).state('productDetails', {
        url: '/products/:id?',
        controller: 'productInfoController',
        controllerAs: 'productInfoCtrl',
        templateUrl: '/scripts/app/templates/mudar-productInfo.html',
        resolve: {
            allCategories: function (categoryProductService) {
                return categoryProductService.getCategories().then(function (response) {
                    //console.log(response);
                    return response;
                }, function () {
                    alert("Error while fetching branch list");
                })
            }
        }
    })
    .state('pricelist', {
        url: '/pricelist',
        controller: 'priceListController',
        controllerAs: 'priceListCtrl',
        templateUrl: '/scripts/app/templates/mudar-pricelist.html'
    }).state('buyerList', {
        url: '/buyerList',
        controller: 'buyerListController',
        controllerAs: 'buyerListCtrl',
        templateUrl: '/scripts/app/templates/buyer/mudar-buyer-list.html',
        resolve: {
            allBuyers: function (identityService) {
                return identityService.getAllBuyers().then(function (response) {
                    //console.log(response);
                    return response;
                }, function () {
                    alert("Error while fetching buyers list");
                });
            }
        }
    }).state('buyer', {
        abstract:true,
        url: '/buyer',
        controller: 'buyerController',
        controllerAs: 'buyerCtrl',
        templateUrl: '/scripts/app/templates/buyer/mudar-buyer.html'
    }).state('buyer.step1', {
        url: '/step1',
        controller: 'buyerStep1Controller',
        controllerAs: 'buyerStep1Ctrl',
        templateUrl: '/scripts/app/templates/buyer/mudar-buyer-step1.html'
    }).state('buyer.step2', {
        url: '/step2',
        controller: 'buyerStep2Controller',
        controllerAs: 'buyerStep2Ctrl',
        templateUrl: '/scripts/app/templates/buyer/mudar-buyer-step2.html'
    }).state('buyer.step3', {
        url: '/step3',
        controller: 'buyerStep3Controller',
        controllerAs: 'buyerStep3Ctrl',
        templateUrl: '/scripts/app/templates/buyer/mudar-buyer-step3.html'
    })
    .state('buyer.step4', {
        url: '/step4',
        controller: 'buyerStep4Controller',
        controllerAs: 'buyerStep4Ctrl',
        templateUrl: '/scripts/app/templates/buyer/mudar-buyer-step4.html'
    })
    .state('buyer.step5', {
        url: '/step5',
        controller: 'buyerStep5Controller',
        controllerAs: 'buyerStep5Ctrl',
        templateUrl: '/scripts/app/templates/buyer/mudar-buyer-step5.html'
    })
    .state('buyer.step6', {
        url: '/step6',
        controller: 'buyerStep6Controller',
        controllerAs: 'buyerStep6Ctrl',
        templateUrl: '/scripts/app/templates/buyer/mudar-buyer-step6.html'
    })
    .state('buyer.step7', {
        url: '/step7',
        controller: 'buyerStep7Controller',
        controllerAs: 'buyerStep7Ctrl',
        templateUrl: '/scripts/app/templates/buyer/mudar-buyer-step7.html'
    })
    .state('buyer.step8', {
        url: '/step8',
        controller: 'buyerStep8Controller',
        controllerAs: 'buyerStep8Ctrl',
        templateUrl: '/scripts/app/templates/buyer/mudar-buyer-step8.html'
    });
    //$locationProvider.html5Mode(true);

    blockUIConfig.message = "Please wait...";
});

mudarApp.constant('appSettings', {
    apiServiceBaseUri: 'http://localhost:49452/'
});

mudarApp.controller('mudarRootCtrl', function ($scope, $rootScope, blockUI, userContextService, $window, $state) {
    $scope.Message = "Welcome to Mudar Organic";
    //debugger;
    $scope.IsLoggedIn = userContextService.IsLoggedIn() == null ? null : userContextService.IsLoggedIn();
    $scope.userRole = userContextService.UserDetails() == null ? null : userContextService.UserDetails().roleName;

    $scope.$on('setUserDetails', function (event, args) {
        $scope.IsLoggedIn = userContextService.IsLoggedIn();
        $scope.userRole = userContextService.UserDetails().roleName;
    });

    $rootScope.$on('$stateChangeStart', function (event, toState, toParams, fromState, fromParams) {
        //console.log(fromState);
        //console.log(toState);
       // alert("state start")
        blockUI.start();        
    });

    $rootScope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState, fromParams) {        
        if (toState.name != 'login') {
            if (!$scope.IsLoggedIn) {
                userContextService.clearAll();
                $state.go('login');
            }
        }
        blockUI.stop();
    });

    $scope.logout = function () {        
        userContextService.clearAll();
        $scope.IsLoggedIn = false;
        $state.go('login');
    }

    //$window.onbeforeunload = function (e) {
    //    //userContextService.clearAll();
    //    alert("onbeforeunload");
    //}

});