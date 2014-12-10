angular.module('app')
    .directive('cake', function () {
    return {
        restrict: 'EC',
        templateUrl: '/app/views/cakeTemplate.html',
        scope: { item: '=ngModel' }
    };
});

