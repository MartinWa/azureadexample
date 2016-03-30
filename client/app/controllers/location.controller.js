// ReSharper disable once UnusedParameter undefined
(function (window, angular, undefined) {
    'use strict';

    angular
        .module('locationApp')
        .controller('locationController', locationController);

    locationController.$inject = ['$location', '$routeParams', 'locationService', 'adalAuthenticationService'];

    function locationController($location, $routeParams, locationService, adalService) {
        var vm = this;
        vm.error = '';
        vm.date = '';
        vm.getlocation = getLocation;
        vm.latitude = '';
        vm.login = login;
        vm.logout = logout;
        vm.longitude = '';
        vm.userInfo = adalService.userInfo;

        function getLocation() {
            locationService.location().then(function (response) {
                vm.latitude = response.data.latitude;
                vm.longitude = response.data.longitude;
                vm.date = response.data.dateTime;
            }, function (error) {
                vm.error = error;
            });
        }

        function login() {
            adalService.login();
        }

        function logout() {
            adalService.logOut();
        }
    };

})(window, window.angular);