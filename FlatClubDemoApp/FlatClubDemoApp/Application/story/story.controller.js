(function () {

    angular.module('application').controller('storyController', storyController);

    storyController.$inject = ['storyService', '$location', '$routeParams'];
    function storyController(storyService, $location, $routeParams) {

        var vm = this;
        vm.story = {};
        vm.goto = goto;
        function activate() {
            getStoryForView();
        }

        activate();

        
        function goto(path) {
            $location.path(path);
        }
        function getStoryForView() {
            var id = $routeParams.id;
            if (angular.isUndefined(id)) {
                return;
            }
            storyService.getStoryById(id).then(function (res) {
                if (res.status == -1) {
                    alert('Some error occured. Please try again.');
                    return;
                }
                vm.story = res.data;
            });
        }
    }

})();