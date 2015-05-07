using System.Web.Optimization;

namespace Driller
{
    public static class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jqm").Include(
                "~/Scripts/jquery.mobile-{version}.js",
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/gamescripts").Include(
                            "~/Scripts/Driller/Const/GameStateCode.js",
                            "~/Scripts/Driller/Const/SquareStateCode.js",
                            "~/Scripts/Driller/Const/SquareTypeCode.js",
                            "~/Scripts/Driller/Const/SquareActionCode.js",
                            "~/Scripts/Driller/Log.js",
                            "~/Scripts/Driller/Server.js",
                            "~/Scripts/Driller/Game.js"));

            bundles.Add(new StyleBundle("~/Content/gamecss").Include(
                 "~/Content/Driller/Game.css"));

            bundles.Add(new StyleBundle("~/Content/jqm").Include(
               "~/Content/jquery.mobile.structure-{version}.min.css",
               "~/Content/jquery.mobile-{version}.css"));
        }
    }
}
