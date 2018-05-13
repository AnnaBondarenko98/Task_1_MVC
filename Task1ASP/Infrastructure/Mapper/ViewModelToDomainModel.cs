using AutoMapper;
using BlogAsp.Models.Models;
using Task1ASP.Models.Article;

namespace Task1ASP.Infrastructure.Mapper
{
    public class ViewModelToDomainModel:Profile
    {
        public ViewModelToDomainModel()
        {
            CreateMap<Article, ArticleVm>();
        }
    }
}