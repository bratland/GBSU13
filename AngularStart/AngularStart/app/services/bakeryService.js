angular.module('bakery', [])
    .service('bakeryService', function ($http) {
        this.get = function () {
            return $http({
                method: 'get',
                url: 'http://bakeryapi.azurewebsites.net/api/pastry/'
            });
        };
    });
