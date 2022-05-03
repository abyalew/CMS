angular.module('CMS')
    .factory('StudentSvc', ['$http', 'Constant.BaseUrl', function ($http, baseUrl) {

    var url = baseUrl + 'student/';


    function getAll() {
        return $http.get(url + 'GetAll');
    }


    return {
        getAll: getAll
    };
}]);