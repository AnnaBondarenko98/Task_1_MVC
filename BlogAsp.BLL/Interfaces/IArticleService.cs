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

        void Create(Article article);

        void Update(Article article);

        IEnumerable<Tag> GetTags(int id);

        Article GetTvTariffWithChannels(Article article, string[] names);

        void Delete(int id);


    }
}