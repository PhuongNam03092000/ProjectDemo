(function () {
    'use strict';

    angular
        .module('myApp')
        .controller('ProductController', ProductController);

    ProductController.$inject = ['$scope', 'ProductService'];

    function ProductController($scope, ProductService) {
        var getProducts = ProductService.getProducts();
        getProducts.then(function (res) {
            $scope.ProductList = res.data;
        });

        $scope.deleteProduct = deleteProduct;
        function deleteProduct(id) {
            var isConfirm = confirm('Are you sure to delete this item');
            if (isConfirm) {
                ProductService.deleteProduct(id).then(function (res) {
                    ProductService.getProducts().then(function (res) {
                        $scope.ProductList = res.data;
                    });
                }, function (err) {
                    console.log('Can not delete this item :' + err);
                });
            }
        }

        $scope.searchFilter = function (item) {
            if ($scope.search === undefined)
                return true;
            return item.name.toLowerCase().includes($scope.search.toLowerCase())
                || item.description.toLowerCase().includes($scope.search.toLowerCase());
        }
    }
})();
