(function () {
    'use strict';

    angular
        .module('myApp')
        .controller('ProductDetailController', ProductDetailController);

    ProductDetailController.$inject = ['$scope','$routeParams','ProductService'];

    function ProductDetailController($scope,$routeParams, ProductService) {
        $scope.defaultImage = "https://kare.ee/images/no-image.jpg";
        $scope.isAddForm = true;
        $scope.buttonName = "Add Product";

        var productId = $routeParams.id;
        if (productId !== undefined) {
            $scope.buttonName = "Update Prouduct";
            $scope.isAddForm = false;
            $scope.product = ProductService.getProduct(productId).then(function (res) {
                $scope.product = res.data;
            });
        }

        $scope.addProduct = function () {
            if ($scope.product != undefined) {
                $scope.product.fileImage = $scope.file;
                ProductService.addProduct($scope.product).then(function (res) {
                });
            } else if ($scope.product === undefined){
                alert('Please fill this form');
            }
           
        }

        $scope.updateProduct = function () {
            $scope.product.fileImage = $scope.file;
            var isConfirm = confirm("Are you sure to update this item");
            if (isConfirm) {
                ProductService.updateProduct($scope.product).then(function (res) {
                    console.log(res);
                    window.location.href = "#!/";
                });
            }     
        }
    }
})();
