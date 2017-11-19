mudarApp.controller('productsController', function (categoryProductService, $state, $rootScope) {

    var vm = this;

    this.products = [];

    fnInit();
    function fnInit() {
        fnLoadProducts();
    }

    function fnLoadProducts() {
        categoryProductService.getProducts().then(function (successResponse) {
            vm.products = successResponse;
        }, function (errorResponse) {

        });
    }


    this.onProductEdit = function (productId) {
        $state.go('productDetails', { id: productId });
    }

    this.onProductDelete = function (productId) {
        categoryProductService.deleteProduct(productId).then(function (successResponse) {
            var removeItem = vm.products.filter(itm => itm.productId == productId)[0];
            vm.products.splice(vm.products.indexOf(removeItem), 1);
        }, function (errorResponse) {

        });

    }
});