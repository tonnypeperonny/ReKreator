using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NLog;
using ReKreator.Web.Helpers;

namespace ReKreator.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        protected void Application_Start()
        {
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DatabaseInitializer.Initialize();
        }

        protected void Application_Error()
        {
            var ex = Server.GetLastError();
            
            Logger.Error($"An unhandled exception occurred: {ex}");
        }
    }
}
