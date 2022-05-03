angular.
    module('CMS').
    controller('StudentsCtrl', ['$scope', 'StudentSvc', 'HttpClient', function ($scope, studentSvc, httpClient) {


        var studentClient = httpClient.getClient('student');
        var courseClient = httpClient.getClient('course');

        var vm = $scope.VM = {
            includes: {
                pagePartials: [
                    'partials/Modals/StudentEditorModal.html',
                    'partials/Modals/StudentGradeEditorModal.html'
                ],
                studentForm: 'partials/Forms/StudentForm.html',
                studentGradeForm: 'partials/Forms/StudentGradeForm.html'
            }
        };

        (function () {
            loadStudents();
            courseClient.getAll()
                .then(function (response) {
                    vm.courseOpts = _.map(response.data.Content, function (c) {
                        return { id: c.Id, text: c.AwardTitle };
                    });
                });
        })();


        vm.onCreate = function () {
            vm.item = {};
            $scope.openModal('#studentEditorModal');
        }

        vm.onEditGrade = function (s) {
            vm.item = {};
            studentClient.getById(s.Id)
                .then(function (response) {
                    vm.item = response.data.Content;
                    $scope.openModal('#studentGradeEditorModal');
                });
        }

        vm.onSave = function () {
            studentClient.save(vm.item).then(function (response) {
                vm.studentList.push(response.data.Content);
                $scope.closeModal('#studentEditorModal');
            });
        }

        vm.onSaveGrade = function () {
            studentSvc.saveGrade(vm.item)
                .then(function (response) {
                    loadStudents().then(function () {
                        $scope.closeModal('#studentGradeEditorModal');
                    });
                });
        }

        function loadStudents() {
            return studentClient.getAll()
                .then(function (response) {
                    vm.studentList = response.data.Content;
                });
        }


    }]);