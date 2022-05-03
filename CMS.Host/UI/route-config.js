angular.module('CMS').
    config(['$stateProvider',
        function config($stateProvider) {

            $stateProvider.state({
                name: 'students',
                url: '/students',
                templateUrl: 'partials/Pages/StudentList.html',
                controller: 'StudentsCtrl'
            });
        }
    ]);