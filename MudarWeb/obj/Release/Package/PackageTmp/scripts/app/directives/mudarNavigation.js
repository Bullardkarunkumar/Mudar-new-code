mudarApp.directive('mudarNavigation', function () {
    var mudarNavigationDirective = {};

    mudarNavigationDirective.restrict = "E";
    mudarNavigationDirective.templateUrl = "/scripts/app/directives/mudarNavigation-template.html";

    mudarNavigationDirective.scope = {
        role: '=role'
    };
    return mudarNavigationDirective;
})