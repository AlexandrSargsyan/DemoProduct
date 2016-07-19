(function() {

    angular.module('application').controller('storiesController', storiesController);

    storiesController.$inject = ['storiesService','$routeParams','$location'];

    function storiesController(storiesService, $routeParams,$location) {
        var vm = this;
        vm.totalItems = 0;
        vm.stories = [];
        vm.currentPage = $routeParams.page;
        vm.currentPage = angular.isUndefined(vm.currentPage) ? 1 : vm.currentPage;

        vm.pageChanged = pageChanged;
        vm.goto = goto;

        function pageChanged() {
            $location.path('/stories/' + vm.currentPage);
        }
        function goto(path) {
            $location.path(path);
        }
        function activate() {
            getStories();
        }

        activate();

        function getStories() {
            
            storiesService.getUserStories(vm.currentPage).then(function (res) {
                if (res.status == -1) {
                    alert('Some error occured. Please try again.');
                    return;
                }
                vm.totalItems = res.data.count;
                vm.stories = res.data.stories;

            });

        }



    }

})();