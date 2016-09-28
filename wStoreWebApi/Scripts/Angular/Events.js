var EventApp = angular.module('EventApp', [])

EventApp.controller('EventController', function ($scope, EventService) {

    getEvents();
    function getEvents() {
        EventService.getEvents()
        .success(function (events) {
            $scope.events = events;
            console.log($scope.events);
        })
        .error(function (error) {
            $scope.status = 'Unable to load events data: ' + error.message;
            console.log($scope.status);
        });
    }
});

EventApp.factory('EventService', ['$http', function ($http) {

    var EventService = {};
    EventService.getEvents = function () {
        return $http.get('/Classic/Events/GetEventsJson');
    };
    return EventService;

}]);

var app = angular.module('myApp', ['angularTreeview']);

app.controller('HomeController', function ($scope, $http) {
    $http.get('/Home/GetFileStructure').then(function (response) {
        $scope.List = response.data.treeList;
    });
});