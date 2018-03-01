using System.Web;
using System.Web.Optimization;

namespace ISD
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            //md bootstrap bundles..      
            bundles.Add(new ScriptBundle("~/mdbundles/bootstrap").Include(
                        "~/Content/MDB/js/jquery-3.1.1.min.js",
                        "~/Content/MDB/js/popper.min.js",
                        "~/Content/MDB/js/bootstrap.min.js",
                        "~/Content/MDB/js/mdb.min.js"
                        ));

            bundles.Add(new StyleBundle("~/mdbundles/design").Include(
                     "~/Content/MDB/css/bootstrap.min.css",
                     "~/Content/MDB/css/mdb.min.css",
                     "~/Content/MDB/css/style.css",
                     "~/Content/MDB/css/compiled.min.css"
                     ));








        }
    }
}
