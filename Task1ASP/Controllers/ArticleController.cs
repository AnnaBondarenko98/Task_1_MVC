using System;
using System.Web.Mvc;
using BlogAsp.BLL.Interfaces;

namespace Task1ASP.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService1)
        {
            _articleService = articleService1;
        }

        public ActionResult Articles()
        {
            var articles = _articleService.GetAll();

            return View(articles);
        }

        [HttpPost]
        public JsonResult CheckDate(DateTime date)
        {
            var result = date.Day == DateTime.UtcNow.Date.Day;

            return Json(result);
        }
    }
}