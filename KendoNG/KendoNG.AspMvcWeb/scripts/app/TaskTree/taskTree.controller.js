
//лучшие практики - https://www.telerik.com/blogs/a-few-angular-kendo-ui-best-practices
//раскрытие дерева - http://jsbin.com/ESOjAmi/8/edit?html,js,output
//динамическое раскрытие грилда при скролле - https://docs.telerik.com/kendo-ui/controls/data-management/grid/how-to/binding/load-and-append-records
(function () {

    var app = angular.module("app");

    //полезная штука по дереву
    //http://jsbin.com/ESOjAmi/8/edit?html,js,output

    var TaskTreeCtrl = function($scope, $log) {
        var vm = this;

        vm.message = "Angular is working!";
        vm.filterAndExpand = function() {

            $log.info(vm.filter);

            var treeDataSource = $scope.taskTree.dataSource;

            var tree = $scope.taskTree;

            vm.uncheckAll();

            //временно отключим возможность автоматического проставления галок на дочерних узлах
            tree.options.checkboxes.checkChildren = false;

            if (vm.filter === "") {
                vm.collapseAll();
                return;
            }

            var checkedNodesIds = [];
            filter(treeDataSource, vm.filter.toLowerCase(), checkedNodesIds);

            var data = treeDataSource.data();

            //treeDataSource.filter({ field: "hidden", operator: "neq", value: true });
            if (checkedNodesIds.length > 0){
                //$scope.taskTree.expandPath(checkedNodesIds);
            }
            else {
                vm.collapseAll();
            }


            //expandAllCheckedNodes(treeDataSource);


            tree.options.checkboxes.checkChildren = true;

            printCheckedNodes();

        };

        function expandAllCheckedNodes(dataSource) {

            var data = dataSource instanceof kendo.data.HierarchicalDataSource && dataSource.data();

            for (var i = 0; i < data.length; i++) {

                var node = data[i];

                if (node.hasChildren && node.checked) {
                    node.load();
                    $scope.taskTree.expand($scope.taskTree.findByUid(node.uid));

                }
                //if (node.checked) {
                //}
            }
        }
    

    vm.test = function() {

        $scope.taskTree.expandPath([123, 12, 1]);
            //$scope.taskTree.expandTo(123);
        };


        var treeData = [
            {
                id: 1,
                text: "Test project",
                type: 0,
                items:
                [
                    {
                        id: 12,
                        text: "Task12",
                        type: 1,
                        items: [
                            {
                                id: 121,
                                text: "Adam Johns",
                                type: 2,
                                items: [
                                    {
                                        id: 1211,
                                        text: "10.12.2017 - 5",
                                        type: 3
                                    }
                                ]
                            },
                            {
                                id: 122,
                                text: "Ben Raver",
                                type: 2,
                                items: [
                                    {
                                        id: 1221,
                                        text: "10.12.2017 - 3",
                                        type: 3
                                    }
                                ]
                            },
                            {
                                id: 123,
                                text: "Adam Johns",
                                type: 2,
                                items: [
                                    {
                                        id: 1231,
                                        text: "10.12.2017 - 5",
                                        type: 3
                                    }
                                ]
                            }
                        ]

                    },
                    {
                        id: 13,
                        text: "Task12",
                        type: 1,
                        items: [
                            {
                                id: 131,
                                text: "Scott Allen",
                                type: 2,
                                items: [
                                    {
                                        id: 1311,
                                        text: "10.12.2017 - 5",
                                        type: 3
                                    }
                                ]
                            },
                            {
                                id: 132,
                                text: "Barney",
                                type: 2,
                                items: [
                                    {
                                        id: 1321,
                                        text: "10.12.2017 - 3",
                                        type: 3
                                    }
                                ]
                            },
                            {
                                id: 133,
                                text: "Alice Gray",
                                type: 2,
                                items: [
                                    {
                                        id: 1331,
                                        text: "10.12.2017 - 5",
                                        type: 3
                                    }
                                ]
                            }
                        ]
                    }
                ]
            }
        ];

        var myDataSource = new kendo.data.HierarchicalDataSource({
            data: [
                {
                    id: 1,
                    text: "Furniture",
                    expanded: true,
                    items: [
                        { id: 2, text: "tables & chairs", type: 1, data: { someStr: "test string" } },
                        { id: 3, text: "sofas" },
                        { id: 4, text: "occasional furniture" },
                        { id: 5, text: "childrens furniture" },
                        { id: 6, text: "beds", checked: true }
                    ]
                },
                {
                    id: 7,
                    text: "Decor",
                    expanded: true,
                    items: [
                        { id: 8, text: "bed linen" },
                        { id: 9, text: "throws" },
                        { id: 10, text: "curtains & blinds" },
                        { id: 11, text: "rugs" },
                        { id: 12, text: "carpets" }
                    ]
                },
                {
                    id: 13,
                    text: "Storage",
                    expanded: true,
                    items: [
                        { id: 14, text: "wall shelving" },
                        { id: 15, text: "kids storage" },
                        { id: 16, text: "multimedia storage" },
                        { id: 17, text: "floor shelving" },
                        { id: 18, text: "toilet roll holders" },
                        { id: 19, text: "storage jars" },
                        { id: 20, text: "drawers" },
                        { id: 21, text: "boxes" }
                    ]
                }
            ]
        });


        vm.taskTreeOptions = {
            dataSource: treeData,
            autoScroll: true,
            //dataBound: function (e) {
            //    e.sender.expand(e.node);
            //},
            check: function(e) {
                //var checkedNodes = [], message;
                //var treeNodes = $scope.taskTree.dataSource.view();

                //checkedNodeIds(treeNodes, checkedNodes);

                //if (checkedNodes.length > 0) {
                //    message = "selected ids: " + checkedNodes.join(", ");
                //} else {
                //    message = "no ids selected";
                //}


                //http://jimhoskins.com/2012/12/17/angularjs-and-apply.html
                $scope.$apply(function() {

                    printCheckedNodes();


                    //vm.checkedNodesStr = message;
                });

                var checkedNodes = getCheckedItems($scope.taskTree);
                $log.info(checkedNodes);
                //vm.checkedNodesStr = message;
                //$scope.$digest();
            },
            select: function(e) {
                e.preventDefault();
            },
            checkboxes: {
                checkChildren: false
            },
            dataTextField: "text",
            messages: {
                loading: "Загрузка дерева.."
            }
        };

        function checkedNodeIds(nodes, checkedNodes) {
            for (var i = 0; i < nodes.length; i++) {
                var node = nodes[i];

                if (node.checked)
                    checkedNodes.push(node.id);

                if (node.hasChildren)
                    checkedNodeIds(node.children.view(), checkedNodes);
            }
        }


        vm.checkAll = function () {

            var treeNodes = $scope.taskTree.dataSource.data();

            if (treeNodes.length > 0) {
                
                for (var i = 0; i < treeNodes.length; i++) {
                    treeNodes[i].set("checked", true);
                }

                printCheckedNodes();
            }  

        };

        function printCheckedNodes() {
            var checkedNodes = [], message;
            var treeNodes = $scope.taskTree.dataSource.view();

            checkedNodeIds(treeNodes, checkedNodes);

            if (checkedNodes.length > 0) {
                message = "selected ids: " + checkedNodes.join(", ");
            } else {
                message = "no ids selected";
            }
            vm.checkedNodesStr = message;
        }

        vm.collapseAll = function() {

            $scope.taskTree.collapse(".k-item");
        };

        vm.showAll = function(data) {
            if (data.length > 0) {
                for (var i = 0; i < data.length; i++) {
                    var item = data[i];
                    item.hidden = false;
                    if (item.hasChildren) {
                        
                    }
                }
            }

        }

        vm.expandAll = function () {

            $scope.taskTree.expand(".k-item");
        };


        vm.uncheckAll = function() {
            var treeNodes = $scope.taskTree.dataSource.data();

            if (treeNodes.length > 0) {

                for (var i = 0; i < treeNodes.length; i++) {
                    treeNodes[i].set("checked", false);
                }

                printCheckedNodes();

                var checkedNodes = getCheckedItems($scope.taskTree);
                $log.info(checkedNodes);
            }

        };


        function getCheckedItems(treeview) {
            var nodes = treeview.dataSource.data();
            return getCheckedNodes(nodes);
        }

        function getCheckedNodes(nodes) {
            var node, childCheckedNodes;
            var checkedNodes = [];

            for (var i = 0; i < nodes.length; i++) {
                node = nodes[i];
                if (node.checked) {
                    checkedNodes.push(node);
                }

                if (node.hasChildren) {
                    childCheckedNodes = getCheckedNodes(node.children.data());
                    if (childCheckedNodes.length > 0) {
                        checkedNodes = checkedNodes.concat(childCheckedNodes);
                    }
                }

            }

            return checkedNodes;
        }

        //function filter2(dataSource, query) {
        //    var hasVisibleChildren = false;
        //    var data = dataSource.data();
        //    //var data = dataSource instanceof kendo.data.HierarchicalDataSource && dataSource.data();

        //    for (var i = 0; i < data.length; i++) {
        //        var item = data[i];
        //        var text = item.text.toLowerCase();
        //        //TODO: ПОПРОБОВАТЬ НОВЫЙ ПОДХОД
        //        var itemVisible =
        //            query === true // parent already matches
        //            || query === "" // query is empty
        //            || text.indexOf(query) >= 0; // item text matches query

        //        var anyVisibleChildren = filter(item.children, itemVisible || query); // pass true if parent matches

        //        hasVisibleChildren = hasVisibleChildren || anyVisibleChildren || itemVisible;

        //        //item.hidden = !itemVisible && !anyVisibleChildren;

        //        var success = itemVisible || anyVisibleChildren;

        //        //найдем узел по уиду
        //        var correspondedNode = $scope.taskTree.findByUid(item.uid);

        //        //if (!item.hidden) {
        //        if(success){
        //            //item.set("checked", true);
        //            item.checked = true;

        //            //item.hidden = true;

        //            $scope.taskTree.expand(correspondedNode);
        //        } else {
        //            //item.set("checked", false);
        //            item.checked = true;

        //            //item.hidden = true;
        //            $scope.taskTree.collapse(correspondedNode);

        //        }
        //    }

        //    if (data) {
        //        // re-apply filter on children
        //        dataSource.filter({ field: "hidden", operator: "neq", value: true });
        //    }

        //    return hasVisibleChildren;

        //}

        function filter(dataSource, query, checkedNodesIds) {

            var isBranchChecked = false;

            //var data = dataSource.data();
            var data = dataSource instanceof kendo.data.HierarchicalDataSource && dataSource.data();

            for (var i = 0; i < data.length; i++) {
                var item = data[i];

                var id = data[i].id;

                var itemSatisfied = false;
                var anyChildreChecked = false;

                //сравним id с введенным значением

                itemSatisfied = id == query;
                isBranchChecked = isBranchChecked || itemSatisfied;
                //если совпадает, то выделим и раскроем всю ветку вниз
                if (itemSatisfied) {



                    if (item.hasChildren)
                        checkAndExpandBranch(item.items);

                } else {
                    //если нет, то проверим, есть ли совпадения по детям
                    if (item.hasChildren) {
                        anyChildreChecked = filter(item.children, query, checkedNodesIds);
                        isBranchChecked = isBranchChecked || anyChildreChecked;
                    }
                }

                if (itemSatisfied || anyChildreChecked) {
                    //найдем узел по уиду
                    item.set("checked", true);
                    item.set("hidden", false);
                    checkedNodesIds.push(item.id);

                    if (item.hasChildren) {
                        item.set("expanded", true);
                        //$scope.taskTree.expand($scope.taskTree.findByUid(item.uid));
                    }

                    //$scope.taskTree.expand($scope.taskTree.findByUid(item.uid));
                } else {
                    var correspondedNode = $scope.taskTree.findByUid(item.uid);
                    item.set("checked", false);
                    item.set("hidden", true);
                    if (item.hasChildren) {
                        item.set("expanded", false);
                        //$scope.taskTree.collapse($scope.taskTree.findByUid(item.uid));
                    }
                }


            }

            if (data) {
                // re-apply filter on children
                dataSource.filter({ field: "hidden", operator: "neq", value: true });
            }

            return isBranchChecked;

        }

        function checkAndExpandBranch(nodes) {
          
            if (nodes.length > 0) {

                for (var i = 0; i < nodes.length; i++) {
                    var node = nodes[i];

                    node.set("checked", true);
                    node.set("hidden", false);
                    var correspondedNode = $scope.taskTree.findByUid(node.uid);
                    $scope.taskTree.expand(correspondedNode);

                    if (node.hasChildren) {
                        checkAndExpandBranch(node.items);
                    }

                }
                
            }

        };

    };

    app.controller("TaskTreeCtrl", TaskTreeCtrl);

})()