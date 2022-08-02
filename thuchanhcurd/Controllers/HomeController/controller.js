(function () {
    'use strict';

    angular
        .module('app')
        .controller('controller', controller);

    controller.$inject = ['$location'];

    function controller($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'controller';

        activate();

        function activate() { }
    }
})();

app.controller('StudentInfo', function ($scope, $rootScope, $compile, DTOptionsBuilder, DTColumnBuilder, dataservice, $uibModal, $filter) {
    // declare variable : khai báo biến
    $scope.model = {

        ID: '',
        ActivityCode: '',
        Title: '',
        Duration: '',
        Unit: '',
        Located: '',
        Status: '',
        Desc: '',
        ShapeJson: '',
        Group: '',
        Type: '',
        WorkflowCode: '',
        CreatedBy: '',
        CreatedTime: '',
        UpdatedBy: '',
        UpdatedTime: '',
        DeletedBy: '',
        DeletedTime: '',
        IsDeleted: '',
        NestedWF: '',
        RoleDefault: '',
        ListGroupData: '',
    }
    // config main table 
    var vm = $scope;
    $scope.selected = [];
    $scope.selectAll = false;
    $scope.toggleAll = toggleAll;
    $scope.toggleOne = toggleOne;
    var titleHtml = '<label class="mt-checkbox"><input type="checkbox" ng-model="selectAll" ng-click="toggleAll(selectAll, selected)"/><span></span></label>';
    vm.dtOptionsCast = DTOptionsBuilder.newOptions()
        .withOption('ajax', {
            url: "/HomeController/JTableCast", // Href link to function in database.
            beforeSend: function (jqXHR, settings) {
                App.blockUI({
                    target: "#contentMain",
                    boxed: true,
                    message: 'loading...'
                });
            },
            type: 'POST',
            data: function (d) {              // phaanf nayf la truyeenf dieeufd kieenj ddeer chayj hamf search.

            },
            complete: function () {
                App.unblockUI("#contentMain");
                heightTableAuto();
            }
        })
        .withPaginationType('full_numbers').withDOM("<'table-scrollable't>ip")
        .withDataProp('data').withDisplayLength(pageLength)
        .withOption('order', [0, 'desc'])
        .withOption('serverSide', true)
        .withOption('headerCallback', function (header) {
            if (!$scope.headerCompiled) {
                $scope.headerCompiled = true;
                $compile(angular.element(header).contents())($scope);
            }
        })
        .withOption('initComplete', function (settings, json) {
        })
        .withOption('createdRow', function (row, data, dataIndex) {
            const contextScope = $scope.$new(true);
            contextScope.data = data;
            contextScope.contextMenu = $scope.contextMenu;
            $compile(angular.element(row).contents())($scope);
            $compile(angular.element(row).attr('context-menu', 'contextMenu'))(contextScope);

            $(row).find('td:not(:has(label.mt-checkbox))').on('click', function (evt) {
                if (evt.target.localName == 'input' && evt.target.type == 'checkbox') {
                    $scope.selected[data.Id] = !$scope.selected[data.Id];
                } else {
                    var self = $(this).parent();
                    if ($(self).hasClass('selected')) {
                        $(self).removeClass('selected');
                        $scope.selected[data.Id] = false;
                    } else {
                        $('#tblData').DataTable().$('tr.selected').removeClass('selected');
                        $scope.selected.forEach(function (obj, index) {
                            if ($scope.selected[index])
                                $scope.selected[index] = false;
                        });
                        $(self).addClass('selected');
                        $scope.selected[data.Id] = true;
                    }
                }

                vm.selectAll = false;
                $scope.$apply();
            });
            $(row).find('td:not(:has(label.mt-checkbox))').on('dblclick', function (evt) {
                if (evt.target.localName == 'input' && evt.target.type == 'checkbox') {

                } else {
                    var Id = data.Id;
                    $scope.edit(Id);
                }
            });
        });

    // creat collumn
    vm.dtColumnsCast = [];
    vm.dtColumnsCast.push(DTColumnBuilder.newColumn("Id").withTitle(titleHtml).notSortable()
        .renderWith(function (data, type, full, meta) {
            $scope.selected[full.Id] = false;
            return '<label class="mt-checkbox"><input type="checkbox" ng-model="selected[' + full.Id + ']" ng-click="toggleOne(selected)"/><span></span></label>';
        }).withOption('sWidth', '30px').withOption('sClass', ' hidden'));
    // creat column ID
    //vm.dtColumnsCast.push(DTColumnBuilder.newColumn('ID').withTitle('{{"ID"}}').withOption('sClass', 'nowrap w20').renderWith(function (data, full, type) {
    //   return data;
    //}));
    // creat column ID
    vm.dtColumnsCast.push(DTColumnBuilder.newColumn('ActivityCode').withTitle('{{"x.ActivityCode"}}').withOption('sClass', 'nowrap w50').renderWith(function (data, full, type) {
        return data;
    }));
    vm.dtColumnsCast.push(DTColumnBuilder.newColumn('Title').withTitle('{{"Title"}}').withOption('sClass', 'nowrap w50', 'dashed').renderWith(function (data, full, type) {
        return data;
    }));
    vm.dtColumnsCast.push(DTColumnBuilder.newColumn('Duration').withTitle('{{"Duration"}}').withOption('sClass', 'nowrap w50', 'dashed').renderWith(function (data, full, type) {
        return data;
    }));
    vm.dtColumnsCast.push(DTColumnBuilder.newColumn('Unit').withTitle('{{"Unit"}}').withOption('sClass', 'nowrap w50', 'dashed').renderWith(function (data, full, type) {
        return data;
    }));
    vm.dtColumnsCast.push(DTColumnBuilder.newColumn('Located').withTitle('{{"Located"}}').withOption('sClass', 'nowrap w50', 'dashed').renderWith(function (data, full, type) {
        return data;
    }));
    vm.dtColumnsCast.push(DTColumnBuilder.newColumn('Status').withTitle('{{"Status"}}').withOption('sClass', 'nowrap w50', 'dashed').renderWith(function (data, full, type) {
        return data;
    }));
    vm.dtColumnsCast.push(DTColumnBuilder.newColumn('Title').withTitle('{{"Title"}}').withOption('sClass', 'nowrap w50', 'dashed').renderWith(function (data, full, type) {
        return data;
    }));
    vm.dtColumnsCast.push(DTColumnBuilder.newColumn('Title').withTitle('{{"Title"}}').withOption('sClass', 'nowrap w50', 'dashed').renderWith(function (data, full, type) {
        return data;
    }));
    vm.dtColumnsCast.push(DTColumnBuilder.newColumn('Title').withTitle('{{"Title"}}').withOption('sClass', 'nowrap w50', 'dashed').renderWith(function (data, full, type) {
        return data;
    }));
    vm.dtColumnsCast.push(DTColumnBuilder.newColumn('Title').withTitle('{{"Title"}}').withOption('sClass', 'nowrap w50', 'dashed').renderWith(function (data, full, type) {
        return data;
    }));
    vm.dtColumnsCast.push(DTColumnBuilder.newColumn('Title').withTitle('{{"Title"}}').withOption('sClass', 'nowrap w50', 'dashed').renderWith(function (data, full, type) {
        return data;
    }));
    vm.dtColumnsCast.push(DTColumnBuilder.newColumn('Title').withTitle('{{"Title"}}').withOption('sClass', 'nowrap w50', 'dashed').renderWith(function (data, full, type) {
        return data;
    }));
    vm.dtColumnsCast.push(DTColumnBuilder.newColumn('Title').withTitle('{{"Title"}}').withOption('sClass', 'nowrap w50', 'dashed').renderWith(function (data, full, type) {
        return data;
    }));
    vm.dtColumnsCast.push(DTColumnBuilder.newColumn('Title').withTitle('{{"Title"}}').withOption('sClass', 'nowrap w50', 'dashed').renderWith(function (data, full, type) {
        return data;
    }));
    vm.dtColumnsCast.push(DTColumnBuilder.newColumn('Title').withTitle('{{"Title"}}').withOption('sClass', 'nowrap w50', 'dashed').renderWith(function (data, full, type) {
        return data;
    }));
    vm.dtColumnsCast.push(DTColumnBuilder.newColumn('Title').withTitle('{{"Title"}}').withOption('sClass', 'nowrap w50', 'dashed').renderWith(function (data, full, type) {
        return data;
    }));

    //tạo stick thao tác

  /*  vm.reloadDataCast = reloadDataCast;
    vm.dtInstanceCast = {};
    function reloadDataCast(resetPaging) {
        vm.dtInstanceCast.reloadDataCast(callback, resetPaging);
    }
    function toggleAll(All, selectedItems) {
        for (var id in selectedItems) {
            if (selectedItems.hasOwnProperty(id)) {
                selectedItems[id] = selectAll;
            }
        }
    }
    function toggleOne(selectedItems) {
        for (var id in selectedItems) {
            if (selectedItems.hasOwnProperty(id)) {
                if (!selectedItems[id]) {
                    vm.selectAll = false;
                    return;
                }
            }
        }
        vm.selectAll = true;
    }
    $scope.searchCast = function () {
        reloadData(true);
    }
    $rootScope.reloadCast = function () {
        reloadData(true);
    }
    $scope.reloadCast = function () {
        reloadData(true);
    }
    $scope.reloadNoResetPage = function () {
        reloadData(false);
    };

    $scope.isSearch = false;
    $scope.showSearch = function () {
        if (!$scope.isSearch) {
            $scope.isSearch = true;
        } else {
            $scope.isSearch = false;
        }
    }
    $filter('date')(new Date($scope.model.EffectiveDate), 'dd/MM/yyyy'); // Convert time 

    $scope.delete1 = function (ID) {
        dataservice.delete1(ID, function (rs) {
            rs = rs.data;
            if (rs.Error) {
                App.toastrError(rs.Title);
                setTimeout(window.location.reload(), 1000);
            }
            else {
                App.toastrSuccess(rs.Title);
                setTimeout(window.location.reload(), 1000);
            }
        });

    }
*/


});
