using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BlogAsp.BLL.DALInterfaces;
using BlogAsp.BLL.DTO;
using BlogAsp.BLL.Interfaces;
using BlogAsp.Models.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BlogAsp.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<User> GetAll()
        {
            return _unitOfWork.UserGenericRepository.GetAll();
        }

        public User Get(int id)
        {
            return _unitOfWork.UserGenericRepository.Get(id);
        }

        public async Task<ClaimsIdentity> Authenticate(LoginDto loginDto)
        {
            ClaimsIdentity claim = null;

            IdentityUser user = await _unitOfWork.UserManager.FindAsync(loginDto.Email, loginDto.Password);

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
