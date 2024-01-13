var app = angular.module('myApp', ['ngRoute']);

app.config(['$routeProvider', function ( $routeProvider) {

    $routeProvider.when('/', { 
        templateUrl: '../Angular_Templates/CustomerList.html',
        controller: 'CustomerController'
    })
    .when('/AddCustomer', { 
        templateUrl: '../Angular_Templates/AddCustomer.html',
        controller: 'CustomerController'
    })
    .when('/AddOrder', { 
        templateUrl: '../Angular_Templates/AddOrder.html',
        controller: 'CustomerController'
    })
    .when('/OrderReport', { 
            templateUrl: '../Angular_Templates/OrderReport.html',
            controller: 'CustomerController'
    })
    .when('/UsersReport', { 
        templateUrl: '../Angular_Templates/UsersReport.html',
        controller: 'CustomerController'
    })
    .when('/ProductReport', { 
        templateUrl: '../Angular_Templates/ProductReport.html',
        controller: 'CustomerController'
    })
    .when('/EditCustomer/:Id', { 
        templateUrl: '../Angular_Templates/EditCustomer.html',
        controller: 'CustomerController'
    })
    .when('/DeleteCustomer/:Id', { 
        templateUrl: '../Angular_Templates/DeleteCustomer.html',
        controller: 'CustomerController'
    })
    .otherwise({ redirectTo: '/' });
}]);

app.controller("CustomerController", ['$scope', '$http', '$location', '$log','$routeParams','$rootScope', function ($scope, $http, $location, $log,$routeParams,$rootScope) {

    $scope.isLogined = true;
    if(!localStorage.getItem('Username')){
        $(document).ready(function (){
            $('#LoginModal').modal('show')
        });
        $scope.isLogined = false;
    }

    $scope.ListOfCustomers;
    $rootScope.displayUserName = localStorage.getItem('Username')
    $scope.config =  {
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
        }
    };
    $scope.Status;
    $scope.baseUrl = 'https://localhost:44321';

    $log.log( 'Url : ', $location.absUrl())

    

    $scope.updateTotal = function(){
        $scope.Total = $scope.Price * $scope.Quantity
    }

    $scope.updatePrice = function(){
        filteredData = {}
        for ( product of $scope.ListOfProducts){
            filteredData[product["Id"]] = product["price"]
        }
        $scope.Price =  filteredData [$scope.ProductName];
    }

    $scope.Close = function () {
        $location.path('/CustomersList');
    }

    $scope.GetCity = function () {
        // $log.log($scope.State)
        if ($scope.State != undefined) {
            $http.get($scope.baseUrl+'/Api/Customers/GetCityById?id=' + $scope.State).then(function (response) {
                $scope.Cities = response.data;
                // $log.log($scope.Cities);
            });
        }
    }

    $scope.GetArea = function () {
        // $log.log($scope.City)
        if ($scope.City != undefined) {
            $http.get($scope.baseUrl+'/Api/Customers/GetAreaById?id=' + $scope.City).then(function (response) {
                $scope.Areas = response.data;
                // $log.log($scope.Areas);
            });
        }
    }

    $scope.currentPage = $location.path()
    // $log.log( 'Current Page' , $scope.currentPage)
    let currentPage = $scope.currentPage

    if (  currentPage == '/AddCustomer' ||  currentPage.includes('EditCustomer')) {
        $http.get($scope.baseUrl+'/Api/Customers/GetAllStates').then(function (response) {
            $scope.States = response.data;
            // $log.log($scope.States)
        });
        $http.get($scope.baseUrl+'/Api/Customers/GetAllDepartments').then(function (response) {
            $scope.Departments = response.data;
            // $log.log($scope.Departments);
        });
        $http.get($scope.baseUrl+'/Api/Customers/GetAllGenders').then(function (response) {
            $scope.Genders = response.data;
            // $log.log($scope.Genders);
        });
        $http.get($scope.baseUrl+'/Api/Customers/GetAllTypes').then(function (response) {
            $scope.Types = response.data;
            // $log.log($scope.Types);
        });

    }

    if(currentPage == '/OrderReport'){
        $http({
            url: $scope.baseUrl+'/Api/Customers/GetAllOrders',
            method: 'GET',

        }).then(function (response) {
            $scope.ListOfOrders = response.data;
        }
        , function (response) {
            $scope.Status = "Data Not Found";
        })
    }
    if(currentPage == '/ProductReport' || currentPage == '/AddOrder'){
        $http({
            url: $scope.baseUrl+'/Api/Customers/GetAllProducts',
            method: 'GET',
        }).then(function (response) {
            $scope.ListOfProducts = response.data;
        }
        , function (response) {
            $scope.Status = "Data Not Found";
        })

    }

    $log.log()

    if ($scope.currentPage == '/' || currentPage == '/AddOrder') {
        $scope.displayUserName = $rootScope.displayUserName;
        $http({
            url: $scope.baseUrl+'/Api/Customers/GetAllCustomers',
            method: 'GET',
        }).then(function (response) {
            $scope.ListOfCustomers = response.data;
        }
        , function (response) {
            $scope.Status = "Data Not Found";
        })
    }

    $scope.postData = function(id = 0){

        var data = {
            Id: id,
            Name: $scope.Name,
            Type: $scope.Type,
            Gender: $scope.Gender,
            Department: $scope.Department,
            State: $scope.State,
            City: $scope.City,
            Area: $scope.Area,
            ZipCode: $scope.ZipCode
        }

        $http.post($scope.baseUrl+'/Api/Customers/ManageCustomers', data, $scope.config)
            .then(function (data, status, headers, config) {
                // $log.log(data)
                $location.path('/CustomersList');
            }
            , function (data, status, header, config) {
                // $log.log(data)
            });

    }

    $scope.AddOrder = function(){
        let orderDate = $scope.OrderDate;
        let selectedDate = new Date(orderDate).toLocaleDateString('en-ZA').slice(0, 10).replaceAll('/','-');

        var data = {
            Id: 0,
            OrderDate: selectedDate,
            Quantity: $scope.Quantity,
            Price: $scope.Price,
            Total: $scope.Total,
            ProductName: $scope.ProductName,
            CustomerName: $scope.CustomerName,
            startDate: '',
            endDate: ''
        }

        $http.post($scope.baseUrl+'/Api/Customers/InsertOrder', data, $scope.config)
            .then(function (data, status, headers, config) {
                $log.log(data)
                $location.path('/OrderReport');
            }
            , function (data) {
                $log.log(data)  
            });
    }

    $scope.Add = function () {
        // $log.log('inside add')
        var customerData = {

            Id: 0,
            Name: $scope.Name,
            Type: $scope.Type,
            Gender: $scope.Gender,
            Department: $scope.Department,
            State: $scope.State,
            City: $scope.City,
            Area: $scope.Area,
            ZipCode: $scope.ZipCode

        };
        // $log.log('---------------------------------------------------------------------')
        // $log.log(customerData)
        // $log.log('---------------------------------------------------------------------')
        // debugger;
        $scope.postData()
        
    }

    // $log.log('Route Id',$routeParams.Id)

    if ($routeParams.Id && currentPage.includes('EditCustomer')) {
        $scope.Id = $routeParams.Id;
        // $log.log($scope.Id)
        $http.get($scope.baseUrl+'/Api/Customers/GetCustomerById/' + $scope.Id).then(function (response) {
            
            // $log.log(response);
            let data = response.data;
            $scope.Id = data.Id;
            $scope.Name = data.Name;
            $scope.Type = data.Type;
            $scope.Gender = data.Gender;
            $scope.Department = data.Department
            $scope.State = data.State;
            $scope.GetCity();
            $scope.City = data.City;
            $scope.GetArea();
            $scope.Area = data.Area;
            $scope.ZipCode = data.ZipCode;
            
        });
    }

    if ($routeParams.Id && currentPage.includes('DeleteCustomer')) {
        $scope.Id = $routeParams.Id;
        // $log.log($scope.Id)
        $http.get($scope.baseUrl+'/Api/Customers/GetCustomerByIdInString/' + $scope.Id).then(function (response) {
            
            // $log.log(response);
            let data = response.data;
            $scope.Id = data.Id;
            $scope.Name = data.Name;
            $scope.Type = data.Type;
            $scope.Gender = data.Gender;
            $scope.Department = data.Department
            $scope.State = data.State;            
            $scope.City = data.City;
            $scope.Area = data.Area;
            $scope.ZipCode = data.ZipCode;
            
        });
    }

    $scope.Update = function () {
        // $log.log('inside Update')
        var customerData = {

            Id: $scope.Id,
            Name: $scope.Name,
            Type: $scope.Type,
            Gender: $scope.Gender,
            Department: $scope.Department,
            State: $scope.State,
            City: $scope.City,
            Area: $scope.Area,
            ZipCode: $scope.ZipCode

        };
        // $log.log('---------------------------------------------------------------------')
        // $log.log(customerData)
        // $log.log('---------------------------------------------------------------------')
        // debugger;
        $scope.postData($scope.Id)
        
    }

    $scope.Delete = function () {
        // $log.log('Delete')
        $http.get($scope.baseUrl+'/Api/Customers/DeleteCustomer/' + $scope.Id).then(function (response) {
            $location.path('/CustomersList');
        });
    }

    $scope.OrdersReport = function () {
        $log.log('OrdersReport')
        let startDate = $scope.startDate
        let endDate = $scope.endDate
        let fromDate = new Date(startDate).toLocaleDateString('en-ZA').slice(0, 10).replaceAll('/','-');
        let tillDate = new Date(endDate).toLocaleDateString('en-ZA').slice(0, 10).replaceAll('/','-');
        console.log(fromDate,tillDate)
        $log.log($scope.startDate)
        $log.log($scope.endDate)
        $http.get($scope.baseUrl+'/Api/Customers/GetOrdersReport?startDate='+fromDate+'&endData='+tillDate).then(function (response) {
            $scope.ordersReport = response.data;
        });
    }

    if(currentPage == '/UsersReport'){
        $http({
            url: $scope.baseUrl+'/Api/Customers/GetAllUsers',
            method: 'GET',

        }).then(function (response) {
            $scope.ListOfUsers = response.data;
        }
        , function (response) {
            $scope.Status = "Data Not Found";
        })
    }

   

    
    
}]);

app.controller("UsersController", ['$scope', '$http', '$location', '$log','$rootScope', function ($scope, $http, $location, $log,$rootScope) {

    $rootScope.displayUserName = localStorage.getItem('Username')
    $scope.currentPage = $location.path()
    let currentPage = $scope.currentPage;
    $scope.config =  {
        headers: {
            'Content-Type': 'application/x-www-form-urlencoded;charset=utf-8;'
        }
    };
    $scope.baseUrl = 'https://localhost:44321';
    
        
    $scope.SignOut = function(){
        localStorage.removeItem('Username')
        $rootScope.displayUserName = localStorage.getItem('Username');
        $location.path('/CustomerList');
    }
    

    $scope.AddUser = function(){

        $log.log('Add User')
        var data = {
            Id : 0,
            UserName : $scope.UserName,
            Password : $scope.Password,
            Email : $scope.Email,
            PhoneNumber : $scope.PhoneNumber
        }
        // $('#RegisterModal').modal('hide')
        // $('#LoginModal').modal('show')
        console.log(data)
        $http.post($scope.baseUrl+'/Api/Customers/InsertUser', data, $scope.config)
            .then(function (data, status, headers, config) {
                // $log.log(data)
                $('#RegisterModal').modal('hide')
                $('#LoginModal').modal('show')
                
            }
            , function (data, status, header, config) {
                // $log.log(data)
            });

    }
    $scope.ValidateUser = function(){

        var data = {
            Id : 0,
            UserName : $scope.LoginUserName,
            Password : $scope.LoginPassword,
            Email : '',
            PhoneNumber : ''
        }
        
        console.log(data)
        $http.post($scope.baseUrl+'/Api/Customers/ValidateUser', data, $scope.config)
            .then(function (data, status, headers, config) {
                $log.log(data.data)
                if(data.data == 'valid'){
                    $('#LoginModal').modal('hide')
                    localStorage.setItem("Username", $scope.LoginUserName);
                    $location.path('/CustomerList');
                }else{
                    $scope.WrongCredentials = 'true';
                }
        
            }
            , function (data, status, header, config) {
                // $log.log(data)
            });
    }

   

}]);