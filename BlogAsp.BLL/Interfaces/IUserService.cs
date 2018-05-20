using System;
using System.Security.Claims;
using System.Threading.Tasks;
using BlogAsp.BLL.DTO;

namespace BlogAsp.BLL.Interfaces
{
    public interface IUserService : IDisposable
    {
        Task<ClaimsIdentity> Authenticate(LoginDto loginDto);
    }
}
