// ReSharper disable once UnusedParameter undefined
(function (window, angular, undefined) {
    'use strict';

    angular
        .module('locationApp')
        .config(config);

    config.$inject = ['$httpProvider', 'adalAuthenticationServiceProvider', 'adalConstants'];

    function config($httpProvider, adalProvider, adalConstants) {

        var endpoints = {
            'https://localhost:44310': 'https://comaroundtest.onmicrosoft.com/locationServer'
        };

        var adalConfig = {
            instance: 'https://login.microsoftonline.com/',
            tenant: adalConstants.TENANT,
            clientId: adalConstants.APP_ID,
            endpoints: endpoints,
            extraQueryParameter: 'nux=1'
        };
        adalProvider.init(adalConfig, $httpProvider);
    }

})(window, window.angular);