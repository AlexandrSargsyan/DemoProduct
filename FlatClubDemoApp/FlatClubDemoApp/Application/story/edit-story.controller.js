(function() {

    angular.module('application').controller('editStoryController', editStoryController);

    editStoryController.$inject = ['storyService', '$location','$routeParams'];
    function editStoryController(storyService,$location,$routeParams) {

        var vm = this;
        vm.current = 1;
        vm.story = {};
        vm.totalGroups = 0;
        vm.availableGroups = [];
        vm.availableGroupsDefault = [];

        vm.save = save;
        vm.removeTag = removeTag;
        vm.addTag = addTag;
        vm.loadNext = loadNext;
        vm.goto = goto;
       
        function activate() {
            getStoryForEdit();
        }

        activate();

        function loadNext() {
            vm.current += 1;
        }

        function getStoryForEdit() {
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
                getGroupTags();
            });
        }

        function getGroupTags() {
            storyService.getGroupTagsForEdit({ groups: vm.story.groups, next: vm.current }).then(function (groupResult) {
                if (groupResult.status == -1) {
                    alert('Some error occured. Please try again.');
                    return;
                }
                if (groupResult.data.groups != null) {
                    vm.availableGroupsDefault = vm.availableGroupsDefault.concat(groupResult.data.groups);
                    vm.availableGroups = vm.availableGroups.concat(groupResult.data.groups);
                    vm.totalGroups = groupResult.data.count;
                }
            });
        }
        function goto(path) {
            $location.path(path);
        }

        function save() {
            if (!vm.storyForm.$valid) return;
            storyService.updateStory(vm.story).then(function (res) {
                if (res.status == -1) {
                    alert('Some error occured. Please try again.');
                    return;
                }
                $location.path('/stories');
                return;
            });
        }

        function removeTag(group) {
            vm.availableGroups.push(group);
            var index = -1;
            for (var i = 0; i < vm.story.groups.length; i++) {
                if (vm.story.groups[i].groupId == group.groupId) {
                    index = i;
                    break;
                }
            }
            if (index > -1) {
                vm.story.groups.splice(index, 1);
            }
        }

        function addTag(group) {
            var index = -1;
            vm.story.groups = vm.story.groups || [];
            vm.story.groups.push(group);
            for (var i = 0; i < vm.availableGroups.length; i++) {
                if (vm.availableGroups[i].groupId == group.groupId) {
                    index = i;
                    break;
                }
            }
            if (index > -1) {
                vm.availableGroups.splice(index, 1);
            }
        }
    }

})();