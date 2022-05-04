angular.
    module('CMS').
    controller('CoursesCtrl', ['$scope', 'HttpClient', function ($scope, httpClient) {


        var courseClient = httpClient.getClient('course');
        var subjectClient = httpClient.getClient('subject');

        var vm = $scope.VM = {
            includes: {
                pagePartials: [
                    'partials/Modals/CourseEditorModal.html',
                ],
                courseForm: 'partials/Forms/CourseForm.html',
            }
        };

        (function () {
            loadCourses();
            subjectClient.getAll()
                .then(function (response) {
                    vm.subjectOpts = _.map(response.data.Content, function (c) {
                        return { id: c.Id, text: c.Name };
                    });
                });
        })();


        vm.onCreate = function () {
            vm.item = {};
            $scope.openModal('#courseEditorModal');
        }

        vm.onEdit = function (course) {
            courseClient.getById(course.Id)
                .then(function (response) {
                    response.data.Content.Birthday = new Date(response.data.Content.Birthday);
                    vm.item = response.data.Content;
                    vm.item.selectedSubejcts = _.map(response.data.Content.Subjects,
                        function (s) { return s.Id.toString() });
                    $scope.openModal('#courseEditorModal');
                });
        }

        vm.onSave = function () {
            var course = angular.copy(vm.item);
            course.Subjects = _.map(vm.item.selectedSubejcts, function (id) {
                return { Id: id };
            });

            courseClient.save(course).then(function (response) {
                loadCourses().then(function () {
                    $scope.closeModal('#courseEditorModal');
                });
            });
        }

        vm.onDelete = function (course) {
            courseClient.delete(course.Id).then(function () {
                loadCourses();
            });
        }

        function loadCourses() {
            return courseClient.getAll()
                .then(function (response) {
                    vm.courseList = response.data.Content;
                });
        }


    }]);