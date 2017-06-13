(function() {

    var TimesheetsCtrl = function($scope) {


        //настройки грида
        $scope.gridOptions = {
        
            dataSource: {},
            height: 400,
            scrollable: true,
            filterable: false,
            pageable: {
                input: false,
                numeric: false
            },
            columns: [
                { field: "ResourceName", title: "Сотрудник", width: "100px" },
                { field: "Status", title: "Статус", width: "100px" },
                { field: "TimesheetLink", title: "Ссылка на табель", width: "100px" },
                { field: "PeriodBegin", title: "Начало периода", type: "date", width: "100px" },
                { field: "PeriodEnd", title: "Окончание периода", type: "date", width: "100px" },
                { field: "ActualsSum", title: "Сумма списанного времени (часы)", width: "100px" },
                { field: "PlanSum", title: "Сумма по базовому плану (часы)", width: "100px" },
                { field: "Variance", title: "Отклонение", width: "100px" },
                { field: "HasTaskComments", title: "Комментарии по задачам", width: "100px" },
                { field: "HasTimesheetComments", title: "Комментарии по табелю", width: "100px" }
            ]


        };

    };

    var app = angular.module("app");
    app.controller("TimesheetsCtrl", TimesheetsCtrl);


}());