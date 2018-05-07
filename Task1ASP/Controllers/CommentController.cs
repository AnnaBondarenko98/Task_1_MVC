using System.Linq;
using System.Web.Mvc;
using BlogAsp.BLL.Interfaces;
using BlogAsp.Models.Models;

namespace Task1ASP.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public ActionResult Comments()
        {
            var comments = _commentService.GetAll().OrderByDescending(o => o.Date);

            return View(comments);
        }

        [HttpPost]
        public ActionResult Comments(Comment comment)
        {
            if (ModelState.IsValid)
            {
                _commentService.Create(comment);
            }

            return RedirectToAction("Comments");
        }
    }
}