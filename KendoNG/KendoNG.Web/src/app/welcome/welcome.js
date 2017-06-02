(function() {

    angular.module('app').controller('welcome', [welcome]);

    function welcome() {

        var vm = this;

        vm.activate = activate;

        activate();

        function activate() {
            vm.computers = [
                {
                    name: 'mac book 1',
                    id: 1
                },
                {
                    name: 'mac book 2',
                    id: 2
                },
                {
                    name: 'mac book 3',
                    id: 3
                }
            ];

        }
    }

}());