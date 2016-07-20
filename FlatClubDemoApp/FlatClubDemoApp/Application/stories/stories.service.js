(function() {
    angular.module('application').factory('storiesService', storiesService);

    storiesService.$inject = ['$http'];
    function storiesService($http) {

        function getUserStories(page) {
            return $http.get('/api/Stories/GetStories?page=' + page).then(function(res) {
                return res.data;
            });
        }

        var services = {
            getUserStories: getUserStories
        };



        return services;

    }


})();