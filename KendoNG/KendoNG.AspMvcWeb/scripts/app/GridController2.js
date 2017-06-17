(function () {

    var app = angular.module("app");


    var GridController = function ($scope, gridData) {

        $scope.message = "Testing Grid";

        //флаг - показывать ли только открытые action item-ы
        $scope.showOnlyOpenItems = false;

        //фильтруем записи в гриде
        $scope.showOnlyOpenItemsOnChange = function () {
            if ($scope.showOnlyOpenItems) {
                $scope.gridDataSource.filter({ field: "OldStatus.Id", operator: "eq", value: 1 });
            } else {
                $scope.gridDataSource.filter({});
            }

        };

        $scope.groupingOption = "project";

        $scope.updateGrouping = function () {

            if ($scope.groupingOption === "project") {

                $scope.gridDataSource.group({ field: "ActivityCode" });

                $scope.gridOptions.columns[3].hidden = false;
                $scope.gridOptions.columns[1].hidden = true;

                $scope.timesheetGrid.showColumn("ActivityName");
                $scope.timesheetGrid.hideColumn("ResourceName");


                //$scope.gridOptions.dataSource.read();
            }
            else if ($scope.groupingOption === "resource") {

                $scope.gridDataSource.group({ field: "ResourceUniqueName" });

                $scope.timesheetGrid.showColumn("ResourceName");
                $scope.timesheetGrid.hideColumn("ActivityName");

                $scope.gridOptions.columns[3].hidden = true;
                $scope.gridOptions.columns[1].hidden = false;

                //$scope.gridOptions.dataSource.read();
            }
        };


        $scope.gridDataSource = new kendo.data.DataSource({
            pageSize: 5,
            transport: {
                read: function (e) {
                    gridData.getActionItems().then(function (records) {
                        e.success(records);
                    }, function (error) {
                        alert(error);
                    });
                }
            },
            group: [{ field: "ActivityCode" }]
        });

        //группируем по коду проекта, но нужно отображать его имя
        $scope.getActivityName = function (code) {

            var collection = $scope.gridDataSource.view();

            for (var i = 0; i < collection.length; i++) {
                if (collection[i].value === code)
                    return collection[i].items[0].ActivityName;
            }
            return "name not found";
        };

        //группируем по идентификатору ресурса, но нужно отображать его имя
        $scope.getResourceName = function (resourceUniqueName) {
            var collection = $scope.gridDataSource.view();

            for (var i = 0; i < collection.length; i++) {
                if (collection[i].value === resourceUniqueName)
                    return collection[i].items[0].ResourceName;
            }
            return "name not found";
        }


        $scope.gridOptions = {
            dataSource: $scope.gridDataSource,
            sortable: true,
            columns: [
                { field: "ResourceUniqueName", hidden: true, groupHeaderTemplate: "{{getResourceName('#=value#')}}" },
                { field: "ActivityName", hidden: true, title: "Наименование активности" },
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


        $scope.statuses = [
            {
                Name: 'Открыто',
                Id: 1
            },
            {
                Name: 'Утверждено',
                Id: 2
            },
            {
                Name: 'Завершено',
                Id: 3
            }
        ];

        $scope.statusOptions = {
            dataSource: {
                data: $scope.statuses
            },
            dataTextField: "Name",
            dataValueField: "Id"
        };


        var onPostActionItemsCompleted = function (result) {
            console.log(result);
        };

        var onError = function (reason) {
            console.log(reason);
        };

        $scope.postActionItems = function () {

            $scope.timesheetGrid.hideColumn("Variance");


            //$scope.gridOptions.columns[3].hidden = true;
            //$scope.gridOptions.columns[1].hidden = false;

            //$scope.gridOptions.dataSource.read();

            //var options = $scope.gridOptions;


            //var dataSource = $scope.gridDataSource;

            //console.log(dataSource);

            //console.log(options);

            //var dataSource = $scope.gridDataSource.data();
            //var jsonDataSource = dataSource.toJSON();
            //gridData.postActionItems(jsonDataSource).then(onPostActionItemsCompleted, onError);

        };

        $scope.getItemBackgroundColor = function (dataItem) {

            if (dataItem.Variance < 0)
                return "{'background-color':'red'}";
            else if (dataItem.Variance == 0)
                return "{'background-color':'yellow'}";
            else if (dataItem.Variance > 0)
                return "{'background-color':'green'}";
        }


    };

    app.controller("GridController", GridController);


}());

//function getActivityName(value) {
//    return "from getActivityName: " + value;
//}