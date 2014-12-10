angular.module('app', ['bakery', 'ngAnimate'])
    .controller('BakeryController', ['$scope', 'bakeryService',
        function ($scope, bakeryService) {

            $scope.pastry = [];

            $scope.delete = function (itemid) {
                var oldItems = $scope.pastry;
                $scope.pastry = [];
                angular.forEach(oldItems, function (item) {
                    if (item.Id != itemid) $scope.pastry.push(item);
                });
            };

            bakeryService.get().success(function (data) {
                $scope.pastry = data;
            });
        }
    ]);