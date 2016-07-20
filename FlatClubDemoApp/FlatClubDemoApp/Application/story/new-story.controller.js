(function () {

    angular.module('application').controller('newStoryController', newStoryController);

    newStoryController.$inject = ['storyService', '$location','modalService'];
    function newStoryController(storyService, $location, modalService) {

        var vm = this;
        vm.newStory = {};
        vm.groupTags = [];
        vm.groupTagsDefault = [];
        vm.current = 1;
        vm.totalGroups = 0;


        vm.loadNext = loadNext;
        vm.addTag = addTag;
        vm.removeTag = removeTag;
        vm.create = create;
        vm.goto = goto;

        function loadNext() {
            vm.current += 1;
            getGroupTags();
        }

        function create() {
            if (!vm.storyForm.$valid) return;
            storyService.addNewStory(vm.newStory).then(function (res) {
                if (res.status == -1) {
                    alert('Some error occured. Please try again.');
                    return;
                }
                $location.path('/stories');
            });

        }

        function removeTag(group) {
            vm.groupTags.push(group);
            var index = -1;
            for (var i = 0; i < vm.newStory.groups.length; i++) {
                if (vm.newStory.groups[i].groupId == group.groupId) {
                    index = i;
                    break;
                }
            }
            if (index > -1) {
                vm.newStory.groups.splice(index, 1);
            }
        }

        function addTag(group) {
            var index = -1;
            vm.newStory.groups = vm.newStory.groups || [];
            vm.newStory.groups.push(group);
            for (var i = 0; i < vm.groupTags.length;i++) {
                if (vm.groupTags[i].groupId == group.groupId) {
                    index = i;
                    break;
                }
            }
            if (index > -1) {
                vm.groupTags.splice(index, 1);
            }
        }
        function activate() {
            getGroupTags();
        }

        function goto(path) {
            $location.path(path);
        }
        activate();
        function getGroupTags() {
            storyService.getGroupTags(vm.current).then(function (res) {
                if (res.status == -1) {
                    alert('Some error occured. Please try again.');
                    return;
                }
                vm.totalGroups = res.data.count;
                vm.groupTagsDefault = vm.groupTagsDefault.concat(res.data.groups);
                vm.groupTags = vm.groupTags.concat(res.data.groups);
               
            });
        }

    }

})();