(function () {

    angular.module('application').factory('modalService', modalService);



    function modalService() {
        var self = {};
        function init(ctrl) {
            self = ctrl;
        }

        function showMessage(t, c) {
            self.title = t;
            self.content = t;
            self.show = true;
        }

        var serives = {
            init: init,
            showMessage: showMessage
    };

        return serives;
    }

})();