(function () {

    angular.module('application').controller('layoutController', layoutController);

    layoutController.$inject = ['$location'];

    function layoutController($location) {
        var vm = this;
        vm.isActive = isActive;
        vm.goto = goto;

        function isActive(path) {
           return $location.path().toLowerCase().indexOf(path.toLowerCase()) > -1; 
        }

        function goto(path) {
            $location.path(path);
        }

    }

})();