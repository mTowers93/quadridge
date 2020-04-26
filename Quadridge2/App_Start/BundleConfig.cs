using System.Web;
using System.Web.Optimization;

namespace Quadridge2
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/popper.min.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootstrap-select.min.js",
                        "~/Scripts/bootstrap/i18n/defaults-en_US.min.js",
                        "~/Scripts/toastr.js",
                        "~/Scripts/datepicker.min.js",
                        "~/Scripts/datepicker.en.js",
                        "~/Scripts/respond.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/dashboard").Include(
                "~/Content/dashboard/vendor/chart.js/Chart.min.js",
                //"~/Content/dashboard/vendor/jquery-validation/jquery.validate.min.js",
                "~/Content/dashboard/vendor/jquery.cookie/jquery.cookie.js",
                "~/Content/dashboard/js/front.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                "~/scripts/datatables/jquery.datatables.js",
                "~/scripts/datatables/datatables.bootstrap4.js"
                ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/dashboard/vendor/font-awesome/css/font-awesome.min.css",
                      "~/Content/dashboard/css/style.blue.css",
                      "~/Content/dashboard/css/fontastic.css",
                      "~/Content/bootstrap.css",
                      "~/Content/datatables/css/datatables.bootstrap4.css",
                      "~/Content/toastr.css",
                      "~/Content/airdatepicker/datepicker.min.css",
                      "~/Content/bootstrap-select.min.css",
                      "~/Content/site.css",
                      "~/Content/dashboard/vendor/font-awesome/fonts/fontawesome-webfont.woff2",
                      "~/Content/dashboard/vendor/font-awesome/fonts/fontawesome-webfont.woff",
                      "~/Content/dashboard/vendor/font-awesome/fonts/fontawesome-webfont.ttf"
                      ));
        }
    }
}
