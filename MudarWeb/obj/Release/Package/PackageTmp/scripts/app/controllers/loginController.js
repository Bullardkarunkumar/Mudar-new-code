mudarApp.controller('loginController', function ($scope, $state, userContextService, identityService) {

    this.loginInfo = {};
    this.onSignIn = function () {
        identityService.login(this.loginInfo).then(function (successResponse) {
            userContextService.UserDetails(successResponse);
            userContextService.IsLoggedIn(true);

            $scope.$emit('setUserDetails', {});
            $state.go('dashboard');
        }, function (errorResponse) {

        });
    }
    this.onRegister = function () {
        $state.go('buyer.step1');
    }
});