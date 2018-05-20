using System.Security.Claims;
using System.Threading.Tasks;
using BlogAsp.BLL.DALInterfaces;
using BlogAsp.BLL.DTO;
using BlogAsp.BLL.Interfaces;
using Microsoft.AspNet.Identity;

namespace BlogAsp.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ClaimsIdentity> Authenticate(LoginDto loginDto)
        {
            ClaimsIdentity claim = null;

            var user = await _unitOfWork.UserManager.FindAsync(loginDto.Email, loginDto.Password);

            if (user != null)
            {
                claim = await _unitOfWork.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            }

            return claim;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
