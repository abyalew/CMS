angular.
    module('CMS').
    controller('StudentsCtrl', ['$scope', 'StudentSvc', 'HttpClient', function ($scope, studentSvc, httpClient) {
        

        var studentClient = httpClient.getClient('student');
        var courseClient = httpClient.getClient('course');
        var vm = $scope.VM = {
            includes: {
                pagePartials: [
                    'partials/Modals/StudentEditorModal.html'
                ],
                studentForm: 'partials/Forms/StudentFrom.html'
            }
        };

        (function () {
            studentClient.getAll()
                .then(function (response) {
                    vm.studentList = response.data.Content;
                });

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

        vm.onSave = function () {
            studentClient.save(vm.item).then(function (response) {
                vm.studentList.push(response.data.Content);
            });
        }




    }]);