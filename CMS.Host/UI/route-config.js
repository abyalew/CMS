angular.module('CMS').
    config(['$stateProvider',
        function config($stateProvider) {

            $stateProvider.state({
                name: 'students',
                url: '/students',
                templateUrl: 'partials/Pages/StudentList.html',
                controller: 'StudentsCtrl'
            });

            $stateProvider.state({
                name: 'teachers',
                url: '/teachers',
                templateUrl: 'partials/Pages/TeacherList.html',
                controller: 'TeachersCtrl'
            });

            $stateProvider.state({
                name: 'courses',
                url: '/courses',
                templateUrl: 'partials/Pages/CourseList.html',
                controller: 'CoursesCtrl'
            });
        }
    ]);