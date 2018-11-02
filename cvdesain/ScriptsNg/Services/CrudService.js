app.service('CrudServices', function ($http) {
    var urlGet = '';
    this.post = function (apiRoute, Model) {
        debugger
        var request = $http({
            method: "post",
            url: apiRoute,
            data: Model
        });
        return request;
    }
    this.put = function (apiRoute, Model) {
        var request = $http({
            method: "put",
            url: apiRoute,
            data: Model
        })
        return request;
    }
    this.delete = function (apiRoute) {
        var request = $http({
            method: "delete",
            url: apiRoute
        })
        return request;
    }
    this.getall = function (apiRoute) {
        urlGet = apiRoute;
        return $http.get(urlGet);
    }
    this.getById = function (apiRoute, Id) {
        urlGet = apiRoute + '/' + Id;
        return $http.get(urlGet);
    }
})