mudarApp.controller('categoriesController', function (categoryProductService, $state, $rootScope) {

    var vm = this;

    this.categories = [];

    fnInit();
    function fnInit() {
        fnLoadCategories();
    }

    function fnLoadCategories() {
        categoryProductService.getCategories().then(function (successResponse) {
            vm.categories = successResponse;
        }, function (errorResponse) {

        });
    }


    this.onCategoryEdit = function (categoryId) {
        $state.go('categoryDetails', { id: categoryId });
    }

    this.onCategoryDelete = function (categoryId) {
        categoryProductService.deleteCategory(categoryId).then(function (successResponse) {
            var removeItem = vm.categories.filter(itm => itm.categoryId == categoryId)[0];
            vm.categories.splice(vm.categories.indexOf(removeItem), 1);
        }, function (errorResponse) {

        });

    }
});