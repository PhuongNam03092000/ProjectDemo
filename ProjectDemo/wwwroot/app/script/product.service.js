angular.module('myApp')
    .service('ProductService', ['$http','$q', function ($http,$q) {

        this.getProducts = getProducts;
        this.getProduct = getProduct;
        this.addProduct = addProduct;
        this.deleteProduct = deleteProduct;

        function getProducts() {
            return $http({
                method: 'GET',
                url: 'api/Product',
            });
        }

        function getProduct(id) {
            return $http({
                method: 'GET',
                url: 'api/Product/' + id
            });
        }

        function addProduct(product) {
              var deferred = $q.defer();
               $http({
                    method: 'POST',
                    url: 'api/Product/',
                    data: JSON.stringify(product),
                    headers: {
                        'Content-Type': 'application/json'
                  },
               }).then(function (res) {
                  deferred.resolve(res);
                 
               }, function (err) {
                  deferred.resolve(err);
                  
               });
               return deferred.promise;
        }

        function deleteProduct(id) {
            return $http({
                method: 'DELETE',
                url: 'api/Product/'+id,
                headers: {
                    'Content-Type': 'application/json'
                },
            });
        }

        this.updateProduct = function (product) {
            return $http({
                method: 'PUT',
                url: 'api/Product',
                data: JSON.stringify(product),
                headers: {
                    'Content-Type':'application/json'
                }
            });
        }
    }
]);