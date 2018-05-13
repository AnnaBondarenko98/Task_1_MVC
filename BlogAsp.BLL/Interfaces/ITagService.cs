using System.Collections.Generic;
using BlogAsp.Models.Models;

namespace BlogAsp.BLL.Interfaces
{
    public interface ITagService
    {
        IEnumerable<Article> GetArticlesByTag(int id);
    }
}