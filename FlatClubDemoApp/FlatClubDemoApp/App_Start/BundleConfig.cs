using System.Web.Optimization;

namespace FlatClubDemoApp
{
    public class BundleConfig
    {

        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/site.css"));


            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));


            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/app/default.js").Include(
                "~/Scripts/angular.js",
                "~/Scripts/angular-route.js"));


            bundles.Add(new ScriptBundle("~/app/application.js").Include(
                "~/scripts/angular-ui/ui-bootstrap.js",
                "~/scripts/angular-ui/ui-bootstrap-tpls.js",
                "~/Application/modules/application.module.js",
                "~/Application/stories/stories.controller.js",
                "~/Application/stories/stories.service.js",
                "~/Application/story/story.controller.js",
                "~/Application/story/edit-story.controller.js",
                "~/Application/story/new-story.controller.js",
                "~/Application/story/story.service.js",
                "~/Application/groups/groups.controller.js",
                "~/Application/groups/groups.service.js",
                "~/Application/group/new-group.controller.js",
                "~/Application/group/group.service.js",
                "~/Application/common/modal.controller.js",
                "~/Application/common/modal.service.js" ,
                "~/Application/common/layout.controller.js"
                ));
        }
    }
}