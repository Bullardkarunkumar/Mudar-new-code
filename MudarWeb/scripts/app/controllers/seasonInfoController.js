mudarApp.controller('seasonInfoController', function ($state, $stateParams, seasonService, categoryProductService) {
    var self = this;
    this.seasonId = $stateParams.id;
    this.seasonInfo = {};
    var currentDate = new Date();
    this.years = [currentDate.getFullYear(), currentDate.getFullYear() - 1, currentDate.getFullYear() - 2]
    this.fnInit = function () {
        seasonService.getSeason(this.seasonId).then(function (response) {
            self.seasonInfo = response[0];
        }, function (err, status) {
            });

        categoryProductService.getProducts().then(function (successResponse) {
            self.products = successResponse;
        }, function (errorResponse) {

        });
    }
    this.fnInit();
    this.onSeasonSave = function (isValid) {
        if (isValid) {
            console.log(self.seasonInfo);
            seasonService.addUpdateSeason(self.seasonInfo).then(function (response) {
                $state.go("seasons");
            }, function (err, status) {
            });
        }
    }

    this.gotoSeasons = function () {
        $state.go('seasons');
    }

});