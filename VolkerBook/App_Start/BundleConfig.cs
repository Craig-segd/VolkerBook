using System.Web.Optimization;

namespace VolkerBook
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/jquery").Include(
                        "~/Scripts/jquery.min.js",
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.dataTables.min.js"
                        ));

            bundles.Add(new ScriptBundle("~/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.

            bundles.Add(new ScriptBundle("~/bootstrap").Include(
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/dataTables.bootstrap.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap.min.css",
                      "~/Content/dataTables.bootstrap.min.css",
                      "~/Content/Site.css"));

        }
    }
}
