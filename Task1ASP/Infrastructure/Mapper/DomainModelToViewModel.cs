using AutoMapper;
using BlogAsp.Models.Models;
using Task1ASP.Models.Article;

namespace Task1ASP.Infrastructure.Mapper
{
    public class DomainModelToViewModel : Profile
    {
        public DomainModelToViewModel()
        {
            CreateMap<Article, ArticleVm>();
        }
    }
}