var module = angular.module('testModule', []); //, ['ngSanitize', 'ui.select', 'kendo.directives', 'ui.filters']);

module.controller('testController', function ($scope, $http) {

    // Populate Unit
    $scope.getAllEmployee = function () {
        $http.get('/Home/getAllEmployee').then(function (data) {
            $scope.lstEmp = data.data.lstEmployee;
            //alert(angular.toJson($scope.lstEmp));
            //console.log($scope.lstEmp);
        }, function (error) {
            $.notify('Error is ' + error.data.message, { globalPosition: 'top right', className: error.data.type });
        });
    }

    $scope.createEmployee = function () {
        $http({
            url: '/Home/createEmp',
            method: 'POST',
            data: JSON.stringify({
                RegID: $scope.RegID, EmpID: $scope.EmpID, EmpName: $scope.EmpName,
                DepartmentName: $scope.DepartmentName, SectionName: $scope.SectionName,
                Designation: $scope.Designation, Salary: $scope.Salary
            })
        }).then(function (data) {
            debugger;
            $scope.getAllEmployee();
            window.location = '../Home/ViewEmp';
        }, function (data) {
        });
    }
    $scope.setEditEmployee = function (emp) {
        $scope.RegID = emp.RegID;
        $scope.EmpID = emp.EmpID;
        $scope.EmpName = emp.EmpName;
        $scope.DepartmentName = emp.DepartmentName;
        $scope.SectionName = emp.SectionName;
        $scope.Designation = emp.Designation;
        $scope.Salary = emp.Salary;
    }

    $scope.editEmployee = function () {
        $http({
            url: '/Home/editEmp',
            method: 'POST',
            data: JSON.stringify({
                RegID: $scope.RegID, EmpID: $scope.EmpID, EmpName: $scope.EmpName,
                DepartmentName: $scope.DepartmentName, SectionName: $scope.SectionName,
                Designation: $scope.Designation, Salary: $scope.Salary
            })
        }).then(function (data) {
            $scope.getAllEmployee();
        }, function (data) {
        });
    }


    $scope.DeleteEmployee = function (emp) {
        $http({
            url: '/Home/deleteEmp',
            method: 'POST',
            data: JSON.stringify({
                RegID: $scope.RegID
            })
        }).then(function (data) {
            $scope.getAllEmployee();
        }, function (data) {
        });
    }
});
