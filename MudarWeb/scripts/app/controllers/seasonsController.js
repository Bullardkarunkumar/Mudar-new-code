mudarApp.controller('seasonsController', function (seasonService, $state) {

    var self = this;

    this.seasons = [];

    fnInit();
    function fnInit() {
        fnLoadSeasons();
    }

    function fnLoadSeasons() {
        seasonService.getSeasons().then(function (successResponse) {
            self.seasons = successResponse;
        }, function (errorResponse) {

        });
    }


    this.onseasonEdit = function (seasonId) {
        $state.go('seasonDetails', { id: seasonId });
    }

    this.onSeasonDelete = function (seasonId) {
        seasonService.deleteSeason(seasonId).then(function (successResponse) {
            var removeItem = self.seasons.filter(itm => itm.seasonId == seasonId)[0];
            self.seasons.splice(self.seasons.indexOf(removeItem), 1);
        }, function (errorResponse) {

        });

    }
});