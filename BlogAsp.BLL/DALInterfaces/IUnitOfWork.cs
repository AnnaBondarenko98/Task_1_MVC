using System;
using BlogAsp.Models.Identity;
using BlogAsp.Models.Models;


namespace BlogAsp.BLL.DALInterfaces
{
    /// <summary>
    /// Unit of Repositories
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Question> QuestGenericRepository { get; }

        IGenericRepository<User> UserGenericRepository { get; }

        IGenericRepository<Article> ArticleGenericRepository { get; }

        IGenericRepository<Comment> CommentGenericRepository { get; }

        IGenericRepository<Tag> TagGenericRepository { get; }

        ApplicationRoleManager RoleManager { get; }

        ApplicationUserManager UserManager { get; }


        void Commit();
    }
}
