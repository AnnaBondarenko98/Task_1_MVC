using AutoMapper;
using BlogAsp.Models.Models;
using Task1ASP.Areas.Admin.Models;
using Task1ASP.Models.Article;

namespace Task1ASP.Infrastructure.Mapper
{
    public class DomainModelToViewModel : Profile
    {
        public DomainModelToViewModel()
        {
            CreateMap<Article, ArticleVm>();

            CreateMap<Article, ArticleAddTagVm>();

            CreateMap<Article, EditArticle>()
            .ForMember(dest => dest.CheckTags, otp => otp.Ignore());

            CreateMap<Tag, CheckModel>()
                .ForMember(dest => dest.Tag, otp => otp.MapFrom(src => src));
        }
    }
}