// ReSharper disable once UnusedParameter undefined
(function (window, angular, undefined) {
    'use strict';

    angular
        .module('locationApp')
        .controller('locationController', locationController);

    locationController.$inject = ['locationService'];

    function locationController(locationService) {
        var vm = this;
        vm.getlocation = getLocation;

        function getLocation() {
            locationService.location().success(function (location) {
                vm.latitude = location.latitude;
                vm.longitude = location.longitude;
            });
        }
    };

})(window, window.angular);