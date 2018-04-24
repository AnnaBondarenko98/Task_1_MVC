using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public ActionResult Question()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}