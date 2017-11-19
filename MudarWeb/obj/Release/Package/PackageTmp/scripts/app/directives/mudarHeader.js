mudarApp.directive('mudarHeader', function () {
    var mudarHeaderDirective = {};

    mudarHeaderDirective.restrict = "E";
    mudarHeaderDirective.templateUrl = "/scripts/app/directives/mudarHeader-template.html";
    return mudarHeaderDirective;
})