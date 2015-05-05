
angular
    .module('areaGuides', [
        'areaGuides.ctrl.home',
        'areaGuides.ctrl.contact',
        'areaGuides.ctrl.about',
        'areaGuides.ctrl.mapping'
    ])
    .config(['$routeProvider', '$locationProvider', function ($routeProvider, $locationProvider) {

        //$routeProvider.when('/Home', {
        //    templateUrl: '/Home/Index',
        //    controller: 'ctrlHome',
        //});
        $routeProvider.when('/About', {
            templateUrl: '/Home/About',
            controller: 'ctrlAbout',
        });
        $routeProvider.when('/Contact', {
            templateUrl: '/Home/Contact',
            controller: 'ctrlContact',
        });
        $routeProvider.when('/Mapping', {
            templateUrl: '/Mapping/Index',
            controller: 'ctrlMapping'
        });

        // Specify HTML5 mode (using the History APIs) or HashBang syntax.
        $locationProvider.html5Mode(false).hashPrefix('!');
    }]);

