using System;
using Hangfire;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using ReKreator.Scheduler;
using ReKreator.Web.Ioc;

namespace ReKreator.Web
{
    public class OwinConfig
    {
        public void Configuration(IAppBuilder app)
        {
            var container = IocContainer.ConfigureContainer();
            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Home/Index"),
            });
            
            GlobalConfiguration.Configuration.UseSqlServerStorage("ReKreatorSheduler");
            GlobalConfiguration.Configuration.UseActivator(new ContainerJobActivator(container));
            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}