using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Task1ASP.Infrastructure.Autofac.DIModules;

namespace Task1ASP.Infrastructure.Autofac
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterModule(new ServiceModule("BlogContext"));
            builder.RegisterModule(new WebModule());

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}