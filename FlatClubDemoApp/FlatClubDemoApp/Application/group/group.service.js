(function() {
    angular.module('application').factory('groupService', groupService);


    groupService.$inject = ['$http'];
    function groupService($http) {

        function createGroup(group) {
            return $http.post('/api/Groups/CreateNewGroup', group).then(function(res) {
                return res.data;
            });
        }
        var service = {
            createGroup: createGroup
        };


        return service;
    }
})();