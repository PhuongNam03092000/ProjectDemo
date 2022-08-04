(function () {
    'use strict';

    angular
        .module('myApp')
        .directive('fileModel', fileModel);

    fileModel.$inject = ['$parse'];

    function fileModel($parse) {
        // Usage:
        //     <directive></directive>
        // Creates:
        // 
        var directive = {
            link: link,
            restrict: 'A'
        };
        return directive;

        function link(scope, element, attrs) {
            var model = $parse(attrs.fileModel);
            var modelSetter = model.assign;
            element.bind("change", function (e) {
                var file = element[0].files;
                var reader = new FileReader();
                reader.onload = function (loadEvent) {
                    let dataURL = loadEvent.target.result;
                    document.getElementById('myFile').setAttribute('src', `${dataURL}`);
                }
                reader.readAsDataURL(file[0]);

                scope.$apply(function () {
                    console.log(element[0].files[0]);
                    modelSetter(scope, element[0].files[0]);
                });
            });
        }
    }
})();