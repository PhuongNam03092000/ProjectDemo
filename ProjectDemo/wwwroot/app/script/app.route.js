angular.module('myApp').config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: '/app/views/productlist.html',
            controller:'ProductController'
        })
        .when("/products", {
            templateUrl: '/app/views/productlist.html',
            controller: 'ProductController'
        })
        .when("/add", {
            templateUrl: '/app/views/addeditproduct.html',
            controller: 'ProductDetailController'
        })
        .when("/edit/:id", {
            templateUrl: '/app/views/addeditproduct.html',
            controller: 'ProductDetailController'
        })
        .otherwise({
            redirectTo: '/'
        });
});