/// <reference path="../Scripts/angular.js" />
/// <reference path="../Scripts/angular-mocks.js" />
/// <reference path="../Scripts/angular-animate.js" />
/// <reference path="../Scripts/jasmine.js" />
/// <reference path="../app/controllers/bakeryController.js" />
/// <reference path="../app/services/bakeryService.js" />

describe('Controllers', function () {

    beforeEach(module('app'));

    var ctrl, scope; 

    beforeEach(inject(function ($rootScope, $controller, bakeryService) {
        scope = $rootScope.$new();
        ctrl = $controller('BakeryController', { $scope: scope, bakeryService: bakeryService });
    }));

    it('should have scope defined', function () {
        expect(scope).toBeDefined();
    });

    it('No pastries in scope', function () {
        expect(scope.pastry.length).toBe(0);
    });

    it('delete should remove one item', function () {
        scope.pastry = [{ Id: 1 }, { Id: 2 }];
        scope.delete(1);
        expect(scope.pastry.length).toBe(1);
    });

});
