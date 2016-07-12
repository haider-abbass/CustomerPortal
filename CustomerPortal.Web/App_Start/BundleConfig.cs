using System.Web.Optimization;

namespace CustomerPortal.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            #region Jquery
            bundles.Add(new ScriptBundle("~/scripts/jquery").Include(
                        "~/scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/scripts/jqueryval").Include(
                        "~/scripts/jquery.validate*"));

            #endregion

            #region Common
            //bundles.Add(new ScriptBundle("~/scripts/common").Include(
            //            ""));

            bundles.Add(new StyleBundle("~/bundles/styles/common").Include(
                        "~/content/common.css", "~/content/responsive.css"));

            #endregion

            #region Modernizer
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/scripts/modernizr").Include(
                        "~/scripts/modernizr-*"));
            #endregion

            #region Bootstrap
            //bundles.Add(new ScriptBundle("~/scripts/bootstrap").Include(
            //          "~/scripts/bootstrap.js",
            //          "~/scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/styles/css").Include(
            //          "~/content/bootstrap.css"));
            #endregion

            #region Font Awesome
            bundles.Add(new StyleBundle("~/styles/font-awesome").Include("~/content/font-awesome.min.css"));
            #endregion

            #region Kendo
            bundles.Add(new ScriptBundle("~/scripts/kendo").Include(
                      "~/scripts/kendo/2016.2.504/kendo.all.min.js"));

            bundles.Add(new StyleBundle("~/styles/kendo").Include("~/content/kendo/2016.2.504/kendo.common.min.css"));
            #endregion
        }
    }
}
