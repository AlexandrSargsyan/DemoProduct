(function () {
    angular.module('application').controller('groupsController', groupsController);

    groupsController.$inject = ['groupsService', '$routeParams','$location'];

    function groupsController(groupsService, $routeParams, $location) {

        var vm = this;
        vm.totalItems = 0;
        vm.groups = [];
        vm.currentPage = $routeParams.page;
        vm.currentPage = angular.isUndefined(vm.currentPage) ? 1 : vm.currentPage;

        vm.pageChanged = pageChanged;
        vm.join = join;
        vm.goto = goto;

        activate();


        function activate() {
            getAllGroups();
        }
        function getAllGroups() {
            groupsService.getGroups(vm.currentPage).then(function (res) {
                if (res.status == -1) {
                    alert('Some error occured. Please try again.');
                    return;
                }
                vm.groups = res.data.groups;
                vm.totalItems = res.data.count;
            });
        }


        function goto(path) {
            $location.path(path);
        }
        function pageChanged() {
            $location.path('/groups/' + vm.currentPage);
        }

        function join(group) {
            groupsService.joinToGroup(group.groupId).then(function (res) {
                if (res.status == -1) {
                    alert('Some error occured. Please try again.');
                    return;
                }
                group.userJoined = true;
            });
        }
    }
    
})();