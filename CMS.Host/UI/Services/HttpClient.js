angular.module('CMS')
    .factory('HttpClient', ['$http', 'Constant.BaseUrl', function ($http, baseUrl) {


        function getClient(apiName) {
            var url = baseUrl + apiName + '/';
            return {
                getAll: function() {
                    return $http.get(url + 'GetAll');
                },
                getById: function (id) {
                    return $http.get(url + 'GetById/'+ id);
                },
                save: function (data) {
                    return $http.post(url + 'edit', data);
                },
                delete: function (id) {
                    return $http.post(url + 'delete/' + id);
                }
            }
        }


        return {
            getClient: getClient
        };
    }]);