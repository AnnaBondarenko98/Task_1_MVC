using BlogAsp.BLL.Interfaces;
using BlogAsp.BLL.Services;
using BlogAsp.DAL.EF;
using BlogAsp.DAL.Repositories;

namespace Task1ASP
{
    public class ServiceCreator : IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new UnitOfWork(new BlogContext(connection)));
        }
    }
}
