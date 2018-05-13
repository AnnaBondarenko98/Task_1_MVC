using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Task1ASP.Infrastructure.Autofac;
using Task1ASP.Infrastructure.Mapper;

namespace Task1ASP
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.ConfigureContainer();
            MapperInitialize.InitializeAutoMapper();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
