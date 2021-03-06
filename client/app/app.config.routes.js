﻿// ReSharper disable once UnusedParameter undefined
(function (window, angular, undefined) {
    'use strict';

    angular
        .module('locationApp')
        .config(config);

    config.$inject = ['$routeProvider'];

    function config($routeProvider) {
        $routeProvider
          .when('/', {
              templateUrl: 'app/views/location.html',
              controller: 'locationController',
              controllerAs: 'vm'//,
              //requireADLogin: true
          });

        $routeProvider.otherwise({ redirectTo: '/' });
    }

})(window, window.angular);