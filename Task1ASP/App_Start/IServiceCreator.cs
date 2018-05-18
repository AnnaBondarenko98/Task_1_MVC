using BlogAsp.BLL.Interfaces;

namespace Task1ASP
{
    public interface IServiceCreator
    {
        IUserService CreateUserService(string connection);
    }
}
