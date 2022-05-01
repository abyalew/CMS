angular.module('CMS').
    config(['$stateProvider',
        function config($stateProvider) {

            $stateProvider.state({
                name: 'students',
                url: '/students',
                templateUrl: 'partials/StudentList.html',
                controller: 'StudentsCtrl'
            });
        }
    ]);