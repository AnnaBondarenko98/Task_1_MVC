using System;
using System.Linq;
using System.Web.Mvc;
using Task1ASP.EF;
using Task1ASP.Models;

namespace Task1ASP.Controllers
{
    public class HomeController : Controller
    {
        private BlogContext context=new BlogContext("MyBlogDB");
        public ActionResult Main()
        {
             
             
            return View(context.Articles);
        }
        [HttpGet]
        public ActionResult Guest()
        {
            ViewBag.Message = "Your application description page.";

            return View(context.Set<Comment>().OrderByDescending(o => o.date).ToArray());
        }
        [HttpPost]
        public ActionResult Guest(Comment comment)
        {
            context.Comments.Add(new Comment() {Text = comment.Text, Author = comment.Author, date = DateTime.Now});
            context.SaveChanges();

            return View(context.Set<Comment>().OrderByDescending(o=>o.date).ToArray());
        }
        
        public ActionResult Questin(Questionnaire q, string[] names,string eye)
        {
            if (Request.HttpMethod=="GET" )
            {
                

                return View("Questin");
            }
            else
            {
                q.Eye = eye;
                q.Animals = names.ToList();
                return View("QuestinPost",q);
            }
           
        }
    }
}