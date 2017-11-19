mudarApp.controller('loginController', function ($scope, $state, userContextService, identityService) {

    this.loginInfo = {};
    this.onSignIn = function () {
        userContextService.clearAll();
        userContextService.fromRegister(false);
        identityService.login(this.loginInfo).then(function (successResponse) {
            userContextService.UserDetails(successResponse);
            userContextService.IsLoggedIn(true);

            $scope.$emit('setUserDetails', {});
            $state.go('dashboard');
        }, function (errorResponse) {

        });
    }
    this.onRegister = function () {
        userContextService.clearAll();
        userContextService.fromRegister(true);
        $state.go('buyer.step1');
    }
});