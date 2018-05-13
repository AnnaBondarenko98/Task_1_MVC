using System.Data.Entity;
using BlogAsp.BLL.DALInterfaces;
using BlogAsp.Models.Models;

namespace BlogAsp.DAL.EF
{
    /// <summary>
    /// Database context
    /// </summary>
    public class BlogContext : DbContext, IBlogContext
    {
        public BlogContext(string connection) : base(connection)
        {
        }

        static BlogContext()
        {
            Database.SetInitializer(new DbInitializer());
        }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}
