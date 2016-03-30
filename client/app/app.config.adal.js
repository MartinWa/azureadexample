// ReSharper disable once UnusedParameter undefined
(function (window, angular, undefined) {
    'use strict';

    angular
        .module('locationApp')
        .config(config)
        .run(function () {
            Logging = {
                level: 3,
                log: function (message) {
                    console.log(message);
                }
            };
        });
    config.$inject = ['$httpProvider', 'adalAuthenticationServiceProvider'];

    function config($httpProvider, adalProvider) {

        var endpoints = {
            'https://azureadbackend.azurewebsites.net/': 'https://comaroundtest.onmicrosoft.com/locationServer'
        };

        var adalConfig = {
            instance: 'https://login.microsoftonline.com/',
            tenant: 'comaroundtest.onmicrosoft.com',
            clientId: '43705a81-3993-4804-a0c5-1c08898283b8',
            endpoints: endpoints
        };
        adalProvider.init(adalConfig, $httpProvider);
    }

})(window, window.angular);