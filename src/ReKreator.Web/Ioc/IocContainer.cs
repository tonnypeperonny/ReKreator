using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using ReKreator.Data.Context;
using ReKreator.Data.Models;
using ReKreator.Scheduler;
using ReKreator.Web.Authorization.SignUp;
using ReKreator.Web.Authorization.Validator;

namespace ReKreator.Web.Ioc
{
    public static class IocContainer
    {
        public static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<SignUpOperation>().As<ISignUpOperation>().InstancePerRequest();
            builder.RegisterType<ReKreatorContext>().AsSelf().InstancePerRequest();
            builder.Register(c => new UserStore<User>(c.Resolve<ReKreatorContext>())).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<UserManager<User>>().AsSelf().InstancePerRequest();
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).As<IAuthenticationManager>();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<SignUpUserValidator>().As<IIdentityValidator<User>>().InstancePerRequest();
            builder.RegisterType<HangFireManager>().As<IHangFireManager>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            return container;
        }
    }
}