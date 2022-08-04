angular.module('myApp')
    .service('ProductService', ['$http','$q', function ($http,$q) {

        this.getProducts = getProducts;
        this.getProduct = getProduct;
        this.addProduct = addProduct;
        this.deleteProduct = deleteProduct;
        this.upload = upload;

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
            var formData = new FormData();
            formData.append('name', product.name);
            formData.append('description', product.description);
            formData.append('fileImage', product.fileImage);
            return $http({
                method: 'POST',
                url: 'api/Product/add',
                data: formData,
                enctype: 'multipart/form-data',
                headers: {
                    'Content-Type': undefined
                }
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
            var formData = new FormData();
            formData.append('id', product.id);
            formData.append('name', product.name);
            formData.append('description', product.description);
            formData.append('fileImage', product.fileImage);
            return $http({
                method: 'PUT',
                url: 'api/Product',
                data: formData,
                enctype: 'multipart/form-data',
                headers: {
                    'Content-Type': undefined
                }
            });
        }

        function upload(product,file) {
            var formData = new FormData();
            formData.append('name', product.name);
            formData.append('description', product.description);
            formData.append('fileImage', file);
            return $http({
                method: 'POST',
                url: 'api/Product',
                data: formData,
                enctype:'multipart/form-data',
                headers: {
                    'Content-Type': undefined
                }
            });

        }
    }
]);