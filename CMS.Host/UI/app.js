angular.module('CMS', ['ui.router'])
    .constant('Constant.BaseUrl', 'https://localhost:44388/api/')
    .controller('Main', ['$rootScope', '$scope','$q', function ($rootScope,$scope,$q) {
        $rootScope.openModal = function (modalId) {
            var defer = $q.defer();
            $(modalId).modal({ backdrop: 'static', keyboard: false }, 'show');
            $(modalId).on('shown.bs.modal',
                function (e) {
                    defer.resolve();
                });
            return defer.promise;
        };

        $rootScope.closeModal = function (modalId) {
            $(modalId).modal('hide');
        };
    }]);

angular.element(function () {
    angular.bootstrap(document, ['CMS']);
});