angular.
    module('CMS').
    controller('SubjectsCtrl', ['$scope', 'HttpClient', function ($scope, httpClient) {


        var subjectClient = httpClient.getClient('subject');
        var teacherClient = httpClient.getClient('teacher');

        var vm = $scope.VM = {
            includes: {
                pagePartials: [
                    'partials/Modals/SubjectEditorModal.html',
                ],
                subjectForm: 'partials/Forms/SubjectForm.html',
            }
        };

        (function () {
            loadSubjects();
            teacherClient.getAll()
                .then(function (response) {
                    vm.teacherOpts = _.map(response.data.Content, function (c) {
                        return { id: c.Id, text: c.Name };
                    });
                });
        })();


        vm.onCreate = function () {
            vm.item = {};
            $scope.openModal('#subjectEditorModal');
        }

        vm.onEdit = function (subject) {
            subjectClient.getById(subject.Id)
                .then(function (response) {
                    response.data.Content.Birthday = new Date(response.data.Content.Birthday);
                    vm.item = response.data.Content;
                    vm.item.selectedSubejcts = _.map(response.data.Content.Subjects,
                        function (s) { return s.Id.toString() });
                    $scope.openModal('#subjectEditorModal');
                });
        }

        vm.onSave = function () {
            subjectClient.save(vm.item).then(function () {
                loadSubjects().then(function () {
                    $scope.closeModal('#subjectEditorModal');
                });
            });
        }

        vm.onDelete = function (subject) {
            subjectClient.delete(subject.Id).then(function () {
                loadSubjects();
            });
        }

        function loadSubjects() {
            return subjectClient.getAll()
                .then(function (response) {
                    vm.subjectList = response.data.Content;
                });
        }


    }]);