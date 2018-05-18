using Autofac;
using BlogAsp.BLL.Interfaces;
using BlogAsp.BLL.Services;
using Task1ASP.Infrastructure.Mapper;

namespace Task1ASP.Infrastructure.Autofac.DIModules
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ArticleService>().As<IArticleService>();
            builder.RegisterType<CommentService>().As<ICommentService>();
            builder.RegisterType<QuestionService>().As<IQuestionService>();
            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<TagService>().As<ITagService>();

            var mapper = MapperInitialize.InitializeAutoMapper().CreateMapper();
            builder.RegisterInstance(mapper);
        }
    }
}