angular.module('CMS')
    .factory('StudentSvc', ['$http', 'Constant.BaseUrl', function ($http, baseUrl) {

    var url = baseUrl + 'student/';


    function saveGrade(admission) {
        return $http.post(url + 'EditGrade', admission);
    }


    return {
        saveGrade: saveGrade
    };
}]);