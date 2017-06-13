(function() {

    'use strict';

    var app = angular.module('app')
                     .controller('dataSourceController', [dataSourceController]);

    function dataSourceController() {
        var vm = this;

        vm.activate = activate;

        activate();

        vm.selectedItem = null;
        vm.dataInGrid = null;


        function activate() {

            vm.gridData = new kendo.data.ObservableArray(
                [
                    { feature: 'Disk', details: '256 MB' },
                    { feature: 'RAM', details: '16 GB' },
                    { feature: 'Monitor', details: 'Thunderbolt' }
                ]);


            vm.gridColumns = [
            {
                field: 'feature', title: 'Feature'
            },
            {
                field:'details', title: 'Details'
            }];

            vm.update = function() {

                vm.gridData[0].set('details', '1 TB');
            };

            vm.onSelectionChange = function (selected, data) {
                vm.selectedItem = selected;
                vm.dataInGrid = data;

                vm.selectedItem = vm.dataInGrid;

            }


        }
    };

}());