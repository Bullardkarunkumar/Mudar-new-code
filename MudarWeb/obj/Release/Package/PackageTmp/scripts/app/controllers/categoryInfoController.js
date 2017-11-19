mudarApp.controller('categoryInfoController', function ($state, $stateParams, categoryProductService) {
    var vm = this;
    this.categoryId = $stateParams.id;
    this.categoryInfo = {};

    this.fnInit = function () {
        categoryProductService.getCategory(this.categoryId).then(function (response) {
            vm.categoryInfo = response;
        }, function (err, status) {
        });
    }
    this.fnInit();
    this.onCategorySave = function (isValid) {
        if (isValid) {
            console.log(JSON.stringify(this.categoryInfo));
            var category = {
                categoryId: this.categoryInfo.categoryId,
                categoryName: this.categoryInfo.categoryName
            }
            categoryProductService.addUpdateCategory(category).then(function (response) {
                $state.go("categories");
            }, function (err, status) {
            });
        }
    }

    this.gotoCategories = function () {
        $state.go('categories');
    }

});