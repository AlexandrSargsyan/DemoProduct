(function () {
    angular.module('application').factory('groupsService', groupsService);

    groupsService.$inject = ['$http'];

    function groupsService($http) {

        var services = {
            getGroups: getGroups,
            joinToGroup:joinToGroup
        };

        function getGroups(page) {
            return $http.get('/api/Groups/GetAllGroups?page=' + page).then(function(res) {
                return res.data;
            });
        }
        function joinToGroup(id) {
            return $http.get('/api/Groups/JoinToGroup?id=' + id).then(function (res) {
                return res.data;
            });
        }
        return services;

    }


})();