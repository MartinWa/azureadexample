﻿// ReSharper disable once UnusedParameter undefined
(function (window, angular, undefined) {
    'use strict';

    angular
        .module('locationApp')
        .controller('locationController', locationController);

    locationController.$inject = ['$location', '$routeParams', 'locationService', 'adalAuthenticationService'];

    function locationController($location, $routeParams, locationService, adalService) {
        var vm = this;
        vm.error = '';
        vm.getlocation = getLocation;
        vm.latitude = '';
        vm.login = login;
        vm.logout = logout;
        vm.longitude = '';

        function getLocation() {
            locationService.location().then(function (location) {
                vm.latitude = location.latitude;
                vm.longitude = location.longitude;
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