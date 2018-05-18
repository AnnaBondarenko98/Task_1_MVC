using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using BlogAsp.BLL.DTO;
using BlogAsp.Models.Models;

namespace BlogAsp.BLL.Interfaces
{
    public interface IUserService:IDisposable
    {
        /// <summary>
        /// Getting all entities
        /// </summary>
        /// <returns></returns>
        IEnumerable<User> GetAll();

        /// <summary>
        /// Get <see cref="Article"/>
        /// </summary>
        /// <returns></returns>
        User Get(int id);

        Task<ClaimsIdentity> Authenticate(LoginDto loginDto);
    }
}
