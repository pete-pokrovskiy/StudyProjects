(function() {

    var app = angular.module("app");


    var GridController = function($scope, gridData) {

        $scope.message = "Testing Grid";


        $scope.groupingOption = "project";

        $scope.updateGrouping = function() {

            if ($scope.groupingOption === "project")
                $scope.gridDataSource.group({ field: "ActivityCode" });
            else if ($scope.groupingOption === "resource")
                $scope.gridDataSource.group({ field: "ResourceUniqueName" });
        };


        $scope.gridDataSource = new kendo.data.DataSource({
            pageSize: 5,
            transport: {
                read: function(e) {
                    gridData.getActionItems().then(function(records) {
                        e.success(records);
                    }, function(error) {
                        alert(error);
                    });
                }
            },
            group: [{ field: "ActivityCode" }]
        });

        $scope.getActivityName = function (code) {

            var collection = $scope.gridDataSource.view();

            for (var i = 0; i < collection.length; i++) {
                if (collection[i].value === code)
                    return collection[i].items[0].ActivityName;
            }
            return "name not found";
        };


        $scope.gridOptions = {
            dataSource: $scope.gridDataSource
            //    {
            //    pageSize: 5,
            //    transport:{
            //        read: function(e) {
            //            gridData.getActionItems().then(function(records) {
            //                e.success(records);
            //            }, function(error) {
            //                alert(error);
            //            });
            //        }
            //    },
            //    //group: [{ field: "ActivityCode" }]
            //}
            ,
            sortable: true,
            columns: [
                { field: "ResourceUniqueName", hidden: true, groupHeaderTemplate: "#=value#" },
                { field: "ActivityName", hidden: true },
                { field: "ActivityCode", hidden: true, groupHeaderTemplate: "{{getActivityName('#=value#')}}" },
                { field: "ResourceName", title: "Сотрудник" },
                { field: "NewStatus", title: "Статус" },
                { field: "TimesheetLink", title: "Ссылка на табель" },
                { field: "PeriodBegin", title: "Начало периода", type: "date", format: "{0: dd.MM.yyyy}" },
                { field: "PeriodEnd", title: "Окончание периода", type: "date", format: "{0: dd.MM.yyyy}" },
                { field: "ActualsSum", title: "Сумма списанного времени (часы)" },
                { field: "PlanSum", title: "Сумма по базовому плану (часы)" },
                { field: "Variance", title: "Отклонение", width: "100px" },
                { field: "HasTaskComments", title: "Комментарии по задачам" },
                { field: "HasTimesheetComments", title: "Комментарии по табелю" }
            ]

        };

    };

    app.controller("GridController", GridController);


}());

//function getActivityName(value) {
//    return "from getActivityName: " + value;
//}