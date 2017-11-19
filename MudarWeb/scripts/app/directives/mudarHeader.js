mudarApp.directive('mudarHeader', function () {
    var mudarHeaderDirective = {};

    mudarHeaderDirective.restrict = "E";
    mudarHeaderDirective.scope = {
        logout: '&'
    };
    mudarHeaderDirective.templateUrl = "/scripts/app/directives/mudarHeader-template.html";
    return mudarHeaderDirective;
})