// ReSharper disable once UnusedParameter undefined
(function (window, angular, undefined) {
    'use strict';

    angular
        .module('locationApp')
        .config(config);

    config.$inject = ['$httpProvider', 'adalAuthenticationServiceProvider', 'adalConstants'];

    function config($httpProvider, adalAuthenticationServiceProvider, adalConstants) {

        var endpoints = {
            'https://localhost:44310': 'http://comaroundtest.onmicrosoft.com/locationServer'
        };

        var adalConfig = {
            instance: 'https://login.microsoftonline.com/',
            tenant: adalConstants.TENANT,
            clientId: adalConstants.APP_ID,
            endpoints: endpoints//,
       //     extraQueryParameter: 'nux=1',
        //    cacheLocation: 'localStorage' // enable this for IE, as sessionStorage does not work for localhost. 
        };
        adalAuthenticationServiceProvider.init(adalConfig, $httpProvider);
    }

})(window, window.angular);