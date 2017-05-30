(function() {

    angular.module('app').controller('welcome', [welcome]);

    function welcome() {

        var vm = this;

        vm.activate = activate;

        activate();

        function activate() {
            
        }
    }

}());