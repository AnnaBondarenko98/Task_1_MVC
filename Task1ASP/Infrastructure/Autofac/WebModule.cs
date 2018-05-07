using Autofac;
using BlogAsp.BLL.Interfaces;
using BlogAsp.BLL.Services;

namespace Task1ASP.Infrastructure.Autofac
{
    public class WebModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ArticleService>().As<IArticleService>();
            builder.RegisterType<CommentService>().As<ICommentService>();
            builder.RegisterType<QuestionService>().As<IQuestionService>();
        }
    }
}