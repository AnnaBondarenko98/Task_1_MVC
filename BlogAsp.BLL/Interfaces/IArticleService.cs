using System.Collections.Generic;
using BlogAsp.Models.Models;

namespace BlogAsp.BLL.Interfaces
{
    public interface IArticleService
    {
        /// <summary>
        /// Getting all entities
        /// </summary>
        /// <returns></returns>
        IEnumerable<Article> GetAll();

        /// <summary>
        /// Get <see cref="Article"/>
        /// </summary>
        /// <returns></returns>
        Article Get(int id);

    }
}