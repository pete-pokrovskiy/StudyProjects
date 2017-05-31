﻿(function () {

    angular.module('app').controller('welcome2', [welcome]);

    function welcome() {

        var vm = this;

        vm.activate = activate;

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