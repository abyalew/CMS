angular.
    module('CMS').
    controller('TeachersCtrl', ['$scope', 'HttpClient', function ($scope, httpClient) {


        var teacherClient = httpClient.getClient('teacher');

        var vm = $scope.VM = {
            includes: {
                pagePartials: [
                    'partials/Modals/TeacherEditorModal.html',
                ],
                teacherForm: 'partials/Forms/TeacherForm.html',
            }
        };

        (function () {
            loadTeachers();
            //courseClient.getAll()
            //    .then(function (response) {
            //        vm.courseOpts = _.map(response.data.Content, function (c) {
            //            return { id: c.Id, text: c.AwardTitle };
            //        });
            //    });
        })();


        vm.onCreate = function () {
            vm.item = {};
            $scope.openModal('#teacherEditorModal');
        }

        vm.onEdit = function (teacher) {
            teacherClient.getById(teacher.Id)
                .then(function (response) {
                    response.data.Content.Birthday = new Date(response.data.Content.Birthday);
                    vm.item = response.data.Content;
                    $scope.openModal('#teacherEditorModal');
                });
        }

        vm.onSave = function () {
            teacherClient.save(vm.item).then(function (response) {
                loadTeachers().then(function () {
                    $scope.closeModal('#teacherEditorModal');
                });
            });
        }

        vm.onDelete = function (teacher) {
            teacherClient.delete(teacher.Id).then(function () {
                loadTeachers();
            });
        }

        function loadTeachers() {
            return teacherClient.getAll()
                .then(function (response) {
                    vm.teacherList = response.data.Content;
                });
        }


    }]);