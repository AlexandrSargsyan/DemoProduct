(function () {

    angular.module('application', ['ngRoute', 'ui.bootstrap']);
    angular.module('application').config([
        '$routeProvider',
        function($routerProvider) {
            $routerProvider.when('/stories/:page?', {
                templateUrl: '/Application/stories/stories.html',
                title: 'My Stories',
                caseInsensitiveMatch: true
               }).when('/story/edit/:id', {
                templateUrl: '/Application/story/edit-story.html',
                title: 'Edit Story',
                caseInsensitiveMatch: true
               }).when('/story/view/:id', {
                templateUrl: '/Application/story/view-story.html',
                title: 'View Story',
                caseInsensitiveMatch: true
               }).when('/story/create', {
                templateUrl: '/Application/story/create-new-story.html',
                title: 'Add',
                caseInsensitiveMatch: true
               }).when('/groups/:page?', {
                templateUrl: '/Application/groups/groups.html',
                title: 'Add',
                caseInsensitiveMatch: true
               }).when('/group/create', {
                   templateUrl: '/Application/group/create-new-group.html',
                   title: 'Add',
                   caseInsensitiveMatch: true
               });
        }
    ]);

})()