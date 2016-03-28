// ReSharper disable once UnusedParameter undefined
(function (window, angular, undefined) {
    'use strict';

    angular
        .module('locationApp')
        .factory('locationService', locationService);

    locationService.$inject = ['$http'];

    function locationService($http) {
        return {
            location: function () {
                return $http.get('https://localhost:44300/api/location/');
            }
        }
    };

})(window, window.angular);