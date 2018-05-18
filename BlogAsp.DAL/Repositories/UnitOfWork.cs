using System;
using BlogAsp.BLL.DALInterfaces;
using BlogAsp.DAL.EF;
using BlogAsp.Models.Identity;
using BlogAsp.Models.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BlogAsp.DAL.Repositories
{
    /// <summary>
    /// Implementing of Unit of repositories
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IBlogContext _db;

        private readonly Lazy<GenericGenericRepository<Question>> _questRepos;
        private readonly Lazy<GenericGenericRepository<Article>> _articleRepos;
        private readonly Lazy<GenericGenericRepository<Comment>> _commentRepos;
        private readonly Lazy<GenericGenericRepository<User>> _userRepos;
        private readonly Lazy<GenericGenericRepository<Tag>> _tagRepos;
        private readonly ApplicationRoleManager _appRoleManager;
        private readonly ApplicationUserManager _appUserManager;

        private bool _disposed;

        public UnitOfWork(IBlogContext db)
        {
            _db = db;

            _questRepos = new Lazy<GenericGenericRepository<Question>>(
                () => new GenericGenericRepository<Question>(_db));
            _articleRepos = new Lazy<GenericGenericRepository<Article>>(
                () => new GenericGenericRepository<Article>(_db));
            _commentRepos = new Lazy<GenericGenericRepository<Comment>>(
                () => new GenericGenericRepository<Comment>(_db));
            _userRepos = new Lazy<GenericGenericRepository<User>>(
                () => new GenericGenericRepository<User>(_db));
            _tagRepos = new Lazy<GenericGenericRepository<Tag>>(
                () => new GenericGenericRepository<Tag>(_db));
            _appUserManager = new ApplicationUserManager(new UserStore<IdentityUser>((BlogContext)_db));
            _appRoleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>((BlogContext)_db));
        }

        public IGenericRepository<Question> QuestGenericRepository => _questRepos.Value;

        public IGenericRepository<Article> ArticleGenericRepository => _articleRepos.Value;

        public IGenericRepository<Comment> CommentGenericRepository => _commentRepos.Value;

        public IGenericRepository<User> UserGenericRepository => _userRepos.Value;

        public IGenericRepository<Tag> TagGenericRepository => _tagRepos.Value;

        public ApplicationRoleManager RoleManager => _appRoleManager;

        public ApplicationUserManager UserManager => _appUserManager;

        public void Commit()
        {
            _db.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _db.Dispose();

                _disposed = true;
            }
        }
    }
}
