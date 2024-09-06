using System.Web;
using System.Web.Optimization;

namespace FixedAssetSolutions
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));
            
            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                      "~/Scripts/jquery-2.2.3.min.js",
                      "~/Scripts/select2.js",
                      "~/Script/angular.min.js",
                      "~/Script/app.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/fastclick.js",
                      "~/Scripts/ app.min.js",
                      "~/Scripts/jquery.sparkline.min.js",
                      "~/Scripts/jquery - jvectormap - 1.2.2.min.js",
                      "~/Scripts/ jquery - jvectormap - world - mill - en.js",
                      "~/Scripts/jquery.slimscroll.min.js",
                      "~/Scripts/Chart.min.js",
                      "~/Scripts/ dashboard2.js",
                      "~/Scripts/ jquery.table2excel.min.js",
                      "~/Scripts/demo.js"));

            bundles.Add(new ScriptBundle("~/bundles/main/js").Include(
                      "~/Scripts/config.js",
                      "~/Scripts/utility.js",
                      "~/Scripts/main.js",
                      "~/Scripts/Common.js"
                   ));

            bundles.Add(new ScriptBundle("~/bundles/login/js").Include(
                     "~/Scripts/jquery-2.2.3.min.js",
                     "~/Scripts/bootstrap.min.js"
                   ));

            bundles.Add(new StyleBundle("~/bundles/Content").Include(

                      "~/Content/bootstrap.min.css",
                      "~/Content/font-awesome.min.css",
                      "~/Content/ionicons.min.css",
                       "~/Content/jquery-jvectormap-1.2.2.css",
                      "~/Content/dataTables.bootstrap.css",
                      "~/Content/buttons.dataTables.min.css",
                       "~/Content/AdminLTE.min.css",
                      "~/Content/_all-skins.min.css",
                      "~/Content/datepicker3.css",
                      "~/Content/select2.css",
                      "~/Content/style.css"));
        }
    }
}
