using System.Web;
using System.Web.Optimization;

namespace PullList
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            // *.min.* files will not load locally
            BundleTable.EnableOptimizations = true;

            bundles.Add(new ScriptBundle("~/js/pulllist").Include(
                        "~/js/jquery-{version}.js",
                        "~/js/jquery-ui.js", // custom: only includes sortables, draggables and droppables
                        "~/js/pulllist.js"));

            bundles.Add(new StyleBundle("~/css/pulllist").Include(
                        "~/css/bootstrap.css", // custom: only includes bootstrap grid and responsive utilities
                        "~/css/font-awesome.css",
                        "~/css/pulllist.css"));
        }
    }
}