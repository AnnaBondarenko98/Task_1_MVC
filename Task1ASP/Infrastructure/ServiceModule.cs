using Autofac;
using BlogAsp.BLL.DALInterfaces;
using BlogAsp.DAL.EF;
using BlogAsp.DAL.Repositories;


namespace Task1ASP.Infrastructure.Autofac
{
    public class ServiceModule : Module
    {
        private readonly string _connection;

        public ServiceModule(string connection)
        {
            _connection = connection;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();

            builder.RegisterType<BlogContext>().As<IBlogContext>().WithParameter("connection", _connection);
        }
    }
}