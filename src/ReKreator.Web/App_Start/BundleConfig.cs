using System.Web.Optimization;

namespace ReKreator.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/modern")
                .Include(
                    "~/Scripts/modernizr-2.6.2.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/js")
                .Include(
                    "~/Scripts/bootstrap.min.js", 
                    "~/Scripts/jquery-3.3.1.min.js"
                ));

            bundles.Add(new StyleBundle("~/bundles/css")
                .Include(
                    "~/Content/bootstrap.min.css", 
                    "~/Content/rekreator.css"
                ));
        }
    }
}