using Autofac;
using BlogAsp.DAL.EF;
using BlogAsp.DAL.Interfaces;
using BlogAsp.DAL.Repositories;

namespace BlogAsp.BLL.Infrastructure.Autofac
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
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().SingleInstance();

            builder.RegisterType<BlogContext>().As<IBlogContext>().WithParameter("connection", _connection);
        }
    }
}