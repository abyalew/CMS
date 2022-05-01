angular.module('CMS', ['ui.router'])
    .controller('Main', ['$scope', function ($scope) {
        $scope.title = 'Student';
    }]);

angular.element(function () {
    angular.bootstrap(document, ['CMS']);
});