mudarApp.controller('seasonInfoController', function ($state, $stateParams, seasonService, categoryProductService) {
    this.seasonId = $stateParams.id;
    this.seasonInfo = {};
    var currentDate = new Date();
    var self = this;

    this.years = [currentDate.getFullYear(), currentDate.getFullYear() - 1, currentDate.getFullYear() - 2]
    this.fnInit = function () {      
            categoryProductService.getProducts().then(function (successResponse) {
                self.products = successResponse;
                if (self.seasonId) {
                    seasonService.getSeason(self.seasonId).then(function (response) {
                        console.log(response);
                        self.seasonInfo = response;
                        self.products.forEach(function (product) {
                            self.seasonInfo.products.forEach(function (seasonProduct) {
                                if (seasonProduct.productId === product.productId) {
                                    product.isSeasonProduct = true;
                                }
                            });
                        });
                    }, function (err, status) {
                    });
                }
            }, function (errorResponse) {

            });
    }
    this.fnInit();
    this.onSeasonSave = function (isValid) {
        if (isValid) {
            self.seasonInfo.products = [];self.products.forEach(function (item) {
                if (item.isSeasonProduct === true) {
                    self.seasonInfo.products.push({
                        seasonId: 0,
                        productId: item.productId
                    });
                }
            });
            
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