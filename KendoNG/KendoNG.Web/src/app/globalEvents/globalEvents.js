
(function() {

    var app = angular.module("app");


    var GlobalEventsController = function($scope) {


        $scope.treeOptions = {
            dataSource: makeData(),
            checkboxes: {
                template: "<input type='checkbox' ng-model='dataItem.checked' />"
            }

        };

        $scope.$on("kendoWidgetCreated", function (event, widget) {

            if (widget === $scope.treeWidget) {

                widget.element.find(".k-checkbox-wrapper .ng-not-empty")
                .each(function () {
                    widget.expand($(this).parents(".k-item"));
                });

            }
        });


        function makeData() {

            return [
                {
                    text: "ParentNode1",
                    items: [
                        {
                            text: "ChildNode1"
                        },
                        {
                            text: "ChildNode2"
                        },
                        {
                            text: "ChildNode2",
                            items:
                            [
                                {
                                    text: "ChildNode1_1"
                                },
                                {
                                    text: "ChildNode1_2",
                                    checked: true
                                }
                            ]
                        }
                    ]
                },
                {
                    text: "ParentNode2",
                    items: [{ text: "ChildNode2", items: [{ text: "ChildNode2_1" }, { text: "ChildNode2_2" }] }]

                }
            ];

        }

    };


    app.controller("GlobalEventsController", GlobalEventsController);


}());
