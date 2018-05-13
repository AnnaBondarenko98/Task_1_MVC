using System.Collections.Generic;
using BlogAsp.Models.Models;

namespace BlogAsp.BLL.Interfaces
{
    public interface ICommentService
    {
        /// <summary>
        /// Creating 
        /// </summary>
        /// <param name="item">entity</param>
        /// <returns></returns>
        void Create(Comment item);

        /// <summary>
        /// Getting all entities
        /// </summary>
        /// <returns></returns>
        IEnumerable<Comment> GetAll();
    }
}