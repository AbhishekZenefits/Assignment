using System.Web;
using System.Web.Optimization;

namespace Zenefits.Assignment.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
            "~/Scripts/flDefault-1.0.0.js",
            "~/Scripts/flScripts-1.0.1.js",
            "~/Scripts/init.js",
            "~/Scripts/raphael.js",
            "~/Scripts/Treant.js",
            "~/Scripts/jquery.min.js",
            "~/Scripts/jquery.easing.js",
            "~/Scripts/perfect-scrollbar.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/Treant.css",
                      "~/Content/collapsable.css",
                      "~/Content/perfect-scrollbar.css"));
        }
    }
}
