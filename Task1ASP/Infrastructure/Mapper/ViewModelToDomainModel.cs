using AutoMapper;
using BlogAsp.Models.Models;
using Task1ASP.Areas.Admin.Models;
using Task1ASP.Models.Article;

namespace Task1ASP.Infrastructure.Mapper
{
    public class ViewModelToDomainModel : Profile
    {
        public ViewModelToDomainModel()
        {
            CreateMap<ArticleVm, Article>();

            CreateMap<EditArticle, Article>();

            CreateMap<string, Tag>()
            .ForMember(dest => dest.Text, otp => otp.MapFrom(src => src.ToString()));
        }
    }
}