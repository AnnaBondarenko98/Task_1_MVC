using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogAsp.Models.Models;

namespace BlogAsp.DAL.EF
{
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
