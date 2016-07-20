(function() {
    angular.module('application').controller('newGroupController', newGroupController);

    newGroupController.$inject = ['groupService','$location'];

    function newGroupController(groupService, $location) {

        var vm = this;
        vm.newGroup = {};
        vm.create = create;
        vm.goto = goto;

        function create() {
            if (!vm.groupForm.$valid) return;
            groupService.createGroup(vm.newGroup).then(function(res) {
                if (res.status == -1) {
                    alert('Some error occured. Please try again.');
                    return;
                }
                $location.path('/groups');
            });
        }

        function goto(path) {
            $location.path(path);
        }
    }
})();