(function() {

    angular.module('application').controller('modalController', modalController);

    modalController.$inject = ['modalService'];

    function modalController(modalService) {
        var vm = this;
        vm.show = false;
        vm.title = '';
        vm.content = '';
        modalService.init(vm);

    }

})();