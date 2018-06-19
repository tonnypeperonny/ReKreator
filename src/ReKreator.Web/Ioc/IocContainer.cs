using System.Configuration;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using ReKreator.Business.Core.DbUpdate;
using ReKreator.Business.Core.EventProviderFolder;
using ReKreator.Business.Core.ImageService;
using ReKreator.Data.Context;
using ReKreator.Data.Core.Repository;
using ReKreator.Data.Core.UnitOfWork;
using ReKreator.Data.Models;
using ReKreator.HtmlParser.Config;
using ReKreator.HtmlParser.Config.Models;
using ReKreator.Web.Authorization.SignIn;
using ReKreator.Web.Authorization.SignOut;
using ReKreator.HtmlParser.ContentProvider;
using ReKreator.HtmlParser.ContentProvider.AfishaTutBy;
using ReKreator.HtmlParser.Core.EventsProvider;
using ReKreator.HtmlParser.Core.Handlers;
using ReKreator.HtmlParser.Core.HtmlProvider;
using ReKreator.Web.Authorization.SignUp;
using ReKreator.Web.Authorization.Validator;

namespace ReKreator.Web.Ioc
{
    public static class IocContainer
    {
        public static IContainer ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            // Identity dependencies
            builder.RegisterType<SignUpOperation>().As<ISignUpOperation>().InstancePerRequest();
            builder.RegisterType<SignInOperation>().As<ISignInOperation>().InstancePerRequest();
            builder.RegisterType<SignOutOperation>().As<ISignOutOperation>().InstancePerRequest();
            builder.Register(c => new UserStore<User>(c.Resolve<ReKreatorContext>())).AsImplementedInterfaces().InstancePerRequest();
            builder.RegisterType<UserManager<User>>().AsSelf().InstancePerRequest();
            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).As<IAuthenticationManager>();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<SignUpUserValidator>().As<IIdentityValidator<User>>().InstancePerRequest();
            builder.RegisterType<CookieAuthenticationOptions>().AsSelf().SingleInstance();

            // Bussiness Layer Dependencies
            builder.RegisterType<DbUpdateService>().As<IDbUpdateService>().InstancePerRequest();
            builder.RegisterType<EventProvider>().As<IEventProvider>();
            builder.RegisterType<PosterService>().As<IPosterService>();

            // DAL dependencies
            builder.RegisterType<ReKreatorContext>().AsSelf().InstancePerRequest();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>));

            // Parser dependencies
            builder.Register(c => (ParserConfig)ConfigurationManager.GetSection("parserConfig")).As<ParserConfig>();
            builder.RegisterType<ParserConfigProvider>().As<IParserConfigProvider>();
            builder.RegisterType<AngleSharp.Parser.Html.HtmlParser>().AsSelf();
            builder.RegisterType<EventsProvider>().As<IEventsProvider>();
            builder.RegisterType<HtmlProvider>().As<IHtmlProvider>();
            builder.RegisterType<ConcertProvider>().Named<IContentProvider>("concertProvider");
            builder.RegisterType<MovieProvider>().Named<IContentProvider>("movieProvider");
            builder.RegisterType<SpectacleProvider>().Named<IContentProvider>("spectacleProvider");

            builder.RegisterType<ContentProvidersFacade>()
                .As<IContentProvidersFacade>()
                .WithParameter(
                    (p, c) => p.Name == "concertProvider",
                    (p, c) => c.ResolveNamed<IContentProvider>("concertProvider"))
                .WithParameter(
                    (p, c) => p.Name == "movieProvider",
                    (p, c) => c.ResolveNamed<IContentProvider>("movieProvider"))
                .WithParameter(
                    (p, c) => p.Name == "spectacleProvider",
                    (p, c) => c.ResolveNamed<IContentProvider>("spectacleProvider"));

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            return container;
        }
    }
}