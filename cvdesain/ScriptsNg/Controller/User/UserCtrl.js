
app.controller('UserCtrl', ['$scope', 'CrudServices',
    function ($scope, CrudService) {
        var BaseUrl = '/Api/User/';
        $scope.btnText = "Register";
        $scope.userID = 0;
        $scope.SaveUpdate = function () {
            var users = {
                Username: $scope.username,
                Password: $scope.password
                /*
                FirstName: $scope.firstName,
                LastName: $scope.lastName,
                Password: $scope.password,
                CreateDate: $scope.createDate,
                Status: $scope.status,
                UserID: $scope.userID
                */
            }
            if ($scope.btnText === "Register") {
                debugger
                var apiRoute = BaseUrl + 'SaveUsers/';
                var saveUser = CrudService.post(apiRoute, users);
                saveUser.then(function (response) {
                    if (response.data !== "") {
                        alert("Data Save Successfully");
                        $scope.Clear();
                    }
                    else {
                        alert("Some error");
                    }
                }, function (error) {
                    console.log("Error: " + error);
                });
            }
        }
        $scope.Clear = function () {
            $scope.userID = 0;
            $scope.username = "";
            $scope.firstName = "";
            $scope.lastName = "";
            $scope.password = "";
            $scope.createDate = "";
            $scope.status = "";
        }

        
        $scope.GetUsers = function () {
            var apiRoute = BaseUrl + 'GetUsersByUsername/';
            var user = CrudService.getall(apiRoute);
            user.then(function (response) {
                debugger
                var userByname  = response.data;
                console.log(response.data);
            }, function (error) {
                console.log("Error: " + error);
            });
        }
        $scope.GetUsers();
        
    }]);

