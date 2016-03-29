// ReSharper disable once UnusedParameter undefined
(function (window, angular, undefined) {
    'use strict';

    angular
        .module('locationApp', ['ngRoute', 'ngSanitize', 'AdalAngular'])
        .run(function() {
            Logging = {
                level: 3,
                log: function (message) {
                    console.log(message);
                }
            };
        });

})(window, window.angular);