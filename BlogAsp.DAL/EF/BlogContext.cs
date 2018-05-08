using System;
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
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Question> Questions { get; set; }

        public BlogContext(string connection) : base(connection)
        {
        }

        static BlogContext()
        {
            Database.SetInitializer(new DbInitializer());
        }
    }

    /// <summary>
    /// Database initializer
    /// </summary>
    internal class DbInitializer : CreateDatabaseIfNotExists<BlogContext>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="db">Database Context</param>
        protected override void Seed(BlogContext db)
        {
            db.Comments.Add(
                new Comment
                {
                    Text = "Some text......",
                    Author = "Anna",
                    Date = DateTime.UtcNow
                });

            db.Articles.Add(
                new Article
                {
                    Date = DateTime.UtcNow,
                    Name = "Article1",
                    Text = "text text text text textext"
                           + " text text tex ext text text tex"
                           + "ext text text texext text text tex"
                           + "ext text text tex"
                           + "ext text text tex "
                });

            db.SaveChanges();
            base.Seed(db);
        }
    }
}
