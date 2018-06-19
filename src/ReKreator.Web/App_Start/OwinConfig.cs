using Autofac;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
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
            var cookie = container.Resolve<CookieAuthenticationOptions>();
            
            cookie.AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie;
            cookie.LoginPath = new PathString("/Home/Index");
            cookie.LogoutPath = new PathString("/Home/Index");

            app.UseCookieAuthentication(cookie);
        }
    }
}