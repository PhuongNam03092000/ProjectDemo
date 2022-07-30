(function () {
    'use strict';

    angular
        .module('myApp')
        .controller('ProductDetailController', ProductDetailController);

    ProductDetailController.$inject = ['$scope','$routeParams','ProductService'];

    function ProductDetailController($scope,$routeParams, ProductService) {
        $scope.defaultImage = "https://kare.ee/images/no-image.jpg";
        $scope.isAddButton = true;
        $scope.buttonName = "Add Product";

        var productId = $routeParams.id;
        if (productId !== undefined) {
            $scope.buttonName = "Update Prouduct";
            $scope.isAddButton = false;
            $scope.product = ProductService.getProduct(productId).then(function (res) {
                $scope.product = res.data;
            });
        }

        $scope.addProduct = function() {
            ProductService.addProduct($scope.product).then(function (res) {  
               var errors = res.data.errors;
                if (errors == null) {
                    document.getElementBy('myForm').reset();
                }
           })
        }

        $scope.updateProduct = function () {
            var isConfirm = confirm("Are you sure to update this item");
            if (isConfirm) {
                ProductService.updateProduct($scope.product).then(function (res) {
                    window.location.href = "#!/products";
                });
            }     
        }
    }
})();
