using System;
using System.Collections.Generic;
using System.Data.Entity;
using BlogAsp.Models.Identity;
using BlogAsp.Models.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

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
            var userManager = new ApplicationUserManager(new UserStore<IdentityUser>(db));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));

            var role1 = new IdentityRole
            {
                Name = "user"
            };

            var role2 = new IdentityRole
            {
                Name = "admin"
            };

            roleManager.Create(role1);

            roleManager.Create(role2);

            var user = new IdentityUser { Email = "admin@admin.ua", UserName = "admin@admin.ua" };
            var result = userManager.Create(user, "Qwerty12");

            if (result != null)
            {
                userManager.AddToRole(user.Id, "admin");
            }

            db.Comments.Add(
                new Comment
                {
                    Text = "Some text......",
                    Author = "Anna",
                    Date = DateTime.UtcNow
                });

            var tag1 = new Tag
            {
                Text = "статья"
            };

            db.Articles.Add(
                new Article
                {
                    Date = DateTime.UtcNow,
                    Name = "Article1",
                    Text = "Передовая статья выражает точку" +
                           " зрения редакции по самому актуальному" +
                           " вопросу в данный момент. Передовая статья" +
                           "помогает правильно ориентироваться в проблемах " +
                           "общественной жизни, реагирует на самые актуальные " +
                           "вопросы.Основные требования: актуальность темы," +
                           " глубокое раскрытие и обоснование выдвигаемых задач," +
                           " конкретность и лаконичность обобщений,выводов,аргументов." +
                           " вопросу в данный момент. Передовая статья" +
                           "помогает правильно ориентироваться в проблемах " +
                           "общественной жизни, реагирует на самые актуальные " +
                           "вопросы.Основные требования: актуальность темы," +
                           " глубокое раскрытие и обоснование выдвигаемых задач," +
                           " конкретность и лаконичность обобщений,выводов,аргументов." +
                           "помогает правильно ориентироваться в проблемах " +
                           "общественной жизни, реагирует на самые актуальные " +
                           "вопросы.Основные требования: актуальность темы," +
                           " глубокое раскрытие и обоснование выдвигаемых задач," +
                           " конкретность и лаконичность обобщений,выводов,аргументов.",
                    Tags = new List<Tag>
                    {
                        tag1,
                        new Tag
                        {
                            Text = "требования"
                        },
                        new Tag
                        {
                            Text = "актуальность"
                        }
                    }
                });

            db.Articles.Add(
                new Article
                {
                    Date = DateTime.UtcNow,
                    Name = "Article2",
                    Text = "Существует теория, согласно которой абсолютно любая статья Википедии по цепочке ведёт к статье «Философия»" +
                           ". Для этого нужно кликать по первой ссылке в каждой статье цепочки. Важно: ссылка должна быть не в скобках" +
                           " и не курсивная. Если ссылка повторяется, следует кликнуть следующую после неё, иначе вы будете ходить по кругу." +
                           "Итак: первая ссылка в статье, затем первая ссылка в следующей статье и так далее, пока не доберётесь до философии," +
                           " а вы обязательно до неё доберётесь :) Редакция Фактрума проверила эту теорию на примере статьи об астероиде J002E3," +
                           " и вот как выглядела цепочка. J002E3, астероид, планета, орбита, материальная точка, физическая модель, цунами, волна," +
                           " сплошная среда, механическая система, механическое движение, тело (физика), физика, естествознание, наука, познание," +
                           " метод, систематизация, теория множеств, математика, (тут нам второй раз встречается «наука», поэтому мы её пропускаем" +
                           " и нажимаем следующую ссылку) идеализация, реальность и — бинго! — философия. Есть даже статья Википедии, посвящённая" +
                           " этой теории — «Википедия: как добраться до философии». В ней говорится, что к философии ведут 94,5% всех статей," +
                           " остальные просто содержат нерабочие ссылки. Объясняется этот феномен довольно просто: как можно заметить по приведённой" +
                           " для примера цепочке, Википедия имеет тенденцию двигаться вверх по классификационной цепи, которая становится всё шире" +
                           " и шире и в итоге приводит к философии.",
                    Tags = new List<Tag>
                    {
                       tag1,
                        new Tag
                        {
                            Text = "операции"
                        },
                        new Tag
                        {
                            Text = "услуги"
                        }
                    }
                });

            db.SaveChanges();
            base.Seed(db);
        }
    }
}
