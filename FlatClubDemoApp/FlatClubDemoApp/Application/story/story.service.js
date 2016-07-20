(function() {

    angular.module('application').factory('storyService', storyService);

    storyService.$inject = ['$http'];

    function storyService($http) {


        function getGroupTags(next) {
            return $http.get('/api/Groups/GetGroupsForTags?next=' + next).then(function(response) {
                return response.data;
            });
        }

        function addNewStory(story) {
            return $http.post('/api/Stories/AddStory',story).then(function (response) {
                return response.data;
            });
        }

        function getStoryById(id) {
            return $http.get('/api/Stories/GetStory?id='+id).then(function (response) {
                return response.data;
            });
        }

        function getGroupTagsForEdit(data) {
            return $http.post('/api/Groups/GetGroupTagsFiltered',data).then(function (response) {
                return response.data;
            });
        }

        function updateStory(story) {
            return $http.post('/api/Stories/UpdateStory', story).then(function (response) {
                return response.data;
            });
        }

        var services = {
            getGroupTags: getGroupTags,
            addNewStory: addNewStory,
            getStoryById: getStoryById,
            getGroupTagsForEdit: getGroupTagsForEdit,
            updateStory: updateStory
        };
        return services;
    }

})();