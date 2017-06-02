(function() {

    var app = angular.module('app');

    var GridController = function($scope) {

        $scope.message = "grid's here";

        $scope.changeDropDown = function (e) {

            //console.log(e);
        };


        $scope.statuses = [
            {
                name: 'Открыто',
                id: 1
            },
            {
                name: 'Утверждено',
                id: 2
            },
            {
                name: 'Завершено',
                id: 3
            }
        ];


        $scope.showData = function() {

            for (var i = 0; i < $scope.testObjects.length; i++) {

                console.log($scope.testObjects[i].status.id);

            }

        };



        $scope.statusOptions = {
            dataSource: {
                data: $scope.statuses
            },
            dataTextField: 'name',
            dataValueField: 'id',
        };

        $scope.showDataStatuses = function () {

            for (var i = 0; i < $scope.statuses.length; i++) {

                console.log($scope.statuses[i].id);

            }

        };


        $scope.testObjects = [
            {
                resource: 'Resource1',
                status: {
                    name: 'Открыто',
                    id: 1
                },
                timesheetLink: 'text1',
                startDate: new Date(2017, 1, 1),
                count: 9,
                changeDropDown: function (e) {

                    //this.status = e.sender.value();
                    //console.log(e.sender.value());
                }

            },
            {
                resource: 'Resource2',
                status: {
                    name: 'Утверждено',
                    id: 2
                },
                timesheetLink: 'text2',
                startDate: new Date(2017, 1, 1),
                count: 8,
                changeDropDown: function (e) {
                    //this.status = e.sender.value();
                }
            },
            {
                resource: 'Resource3',
                status: {
                    name: 'Возвращено',
                    id: 3
                },
                timesheetLink: 'text3',
                startDate: new Date(2017, 1, 1),
                count: 1,
                changeDropDown: function (e) {

                    //this.status = e.sender.value();

                    //console.log(e.sender.value());
                }
            }
        ];


        $scope.testGridOptions = {
            dataSource: {
                data: $scope.testObjects,
                //schema: {
                //    model: {
                //        fields: {
                //            resource: { type: "string" },
                //            status: { type: "number" },
                //            timesheetLink: { type: "string" },
                //            startDate: { type: "date" },
                //            count: { type: "number" }
                //        }
                //    }
                //},
                pageSize: 5
            },
            height: 400,
            scrollable: true,
            sortable: true,
            filterable: true,
            pageable: {
                input: false,
                numeric: false
            },
            columns: [
                { field: "resource", title: "Resource name", width: "100px" },
                { field: "status", title: "Status", width: "100px" },
                { field: "timesheetLink", title: "Link to smth", width: "100px" },
                {
                    field: "startDate", title: "Start date", type: "date", width: "100px"
                },
               { field: "count", title: "Count", width: "100px" }

            ]
        };


    };

    app.controller('GridController', GridController);



}());