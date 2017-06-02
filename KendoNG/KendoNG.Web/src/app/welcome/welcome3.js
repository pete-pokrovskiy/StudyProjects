(function () {

    angular.module('app').controller('welcome3', [welcome3]);

    function welcome3() {
        
        var vm = this;

        vm.activate = activate;
        vm.computerChosen = false;

        vm.selectedComputer = '';


        activate();

        function activate() {

            vm.computerOptions = {
                dataSource: {
                    data: [
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
                    ]
                },
                dataTextField: 'name',
                dataValueField: 'id',
                optionLabel: 'Select a computer...'
            };

            vm.computerChange = function(e) {
                console.log(e.sender.text());
                vm.computerChosen = true;

                if (e.sender.text() === 'Select a computer...') {
                    vm.computerChosen = false;
                }

            };



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