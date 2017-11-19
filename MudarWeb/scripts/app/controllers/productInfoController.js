mudarApp.controller('productInfoController', function ($state, $stateParams, categoryProductService, allCategories) {
    var vm = this;
    this.productId = $stateParams.id;
    this.productInfo = {};
    this.categories = allCategories;
    this.fnInit = function () {
        categoryProductService.getProduct(this.productId).then(function (response) {
            vm.productInfo = response;
        }, function (err, status) {
        });
    }
    this.fnInit();
    this.onProductSave = function (isValid) {
        if (isValid) {
            var prod = {
                productId: this.productInfo.productId,
                productName: this.productInfo.productName,
                categoryId: this.productInfo.productCategory.categoryId,
                productCode: this.productInfo.productCode,
                description: this.productInfo.description,
                itcHsCode: this.productInfo.itcHsCode,
                specification: this.productInfo.specification
            }
            categoryProductService.addUpdateProduct(prod).then(function (response) {
                $state.go("products");
            }, function (err, status) {
            });
        }
    }

    this.gotoProducts = function () {
        $state.go('products');
    }

});