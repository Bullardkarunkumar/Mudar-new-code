mudarApp.controller('seasonInfoController', function ($state, $stateParams, seasonService) {
    var self = this;
    this.seasonId = $stateParams.id;
    this.seasonInfo = {};
    var currentDate = new Date();
    this.years = [currentDate.getFullYear(), currentDate.getFullYear() - 1, currentDate.getFullYear() - 2]
    this.fnInit = function () {
        seasonService.getSeason(this.seasonId).then(function (response) {
            self.seasonInfo = response;
        }, function (err, status) {
        });
    }
    this.fnInit();
    this.onSeasonSave = function (isValid) {
        if (isValid) {
            console.log(JSON.stringify(this.seasonInfo));
            var season = {
                seasonId: this.seasonInfo.seasonId,
                seasonName: this.seasonInfo.seasonName
            }
            seasonService.addUpdateSeason(season).then(function (response) {
                $state.go("seasons");
            }, function (err, status) {
            });
        }
    }

    this.gotoSeasons = function () {
        $state.go('seasons');
    }

});