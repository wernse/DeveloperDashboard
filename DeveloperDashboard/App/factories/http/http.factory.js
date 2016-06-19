(function () {
    'use strict';
    angular.module('http')
        .factory('httpFactory', [
            '$http',
            '$rootScope',
            '$q',
            httpFactory
        ]);

    function httpFactory($http, $rootScope, $q) {
        var httpFactory = {
            get: get,
            post: post
        };
        return httpFactory;

        //Sends ajax GET to a URL, rejects if error
        //helper function to only return the body rather than headers
        function get(url) {
            var deferred = $q.defer();
            $http.get(url)
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });
            return deferred.promise;
        }

        //post constructor function to enable defer
        function post(settings) {
            var deferred = $q.defer();
            $http(settings)
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });
            return deferred.promise;
        }
    }
})();