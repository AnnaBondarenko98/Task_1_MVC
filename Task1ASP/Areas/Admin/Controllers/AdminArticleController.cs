using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AutoMapper;
using BlogAsp.BLL.Interfaces;
using BlogAsp.Models.Models;
using Task1ASP.Areas.Admin.Models;
using Task1ASP.Models.Article;

namespace Task1ASP.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminArticleController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IArticleService _articleService;
        private static int _articleId;
        private ITagService _tagService;

        public AdminArticleController(IMapper mapper, IArticleService articleService, ITagService tagService)
        {
            _mapper = mapper;
            _articleService = articleService;
            _tagService = tagService;
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ArticleVm articleVm)
        {
            articleVm.Date = DateTime.UtcNow;

            _articleService.Create(_mapper.Map<Article>(articleVm));

            return RedirectToAction("GetArticles", "Article", new
            {
                area = ""
            });
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<CheckModel> tags = new List<CheckModel>();

            foreach (var item in _tagService.GetAll())
            {
                if (_tagService.GetAll().Except(_articleService.Get((int)id).Tags).Contains(item))
                {
                    CheckModel ch = new CheckModel()
                    {
                        Tag = item,
                        Checked = false
                    };
                    tags.Add(ch);
                }
                else
                {
                    CheckModel ch = new CheckModel()
                    {
                        Tag = item,
                        Checked = true
                    };
                    tags.Add(ch);
                }

            }

            ViewBag.Checked = tags;

            return View(_articleService.Get((int)id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Text")] Article article, string[] names)
        {

            if (ModelState.IsValid)
            {
                Article newArticle = _articleService.Get(article.Id);
                newArticle.Name = article.Name;
                newArticle.Tags.Clear();
                newArticle.Text = article.Text;

                if (names != null)
                {
                    _articleService.GetTvTariffWithChannels((newArticle), names);
                }
                else
                {
                    newArticle.Tags = _articleService.GetTags(article.Id).ToArray();
                }
                _articleService.Update(newArticle);

                return RedirectToAction("GetArticles", new
                {
                    area = "",
                    controller = "Article"
                });
            }
            return View(article);
        }

        [HttpGet]
        public ActionResult AddTag(int id)
        {
            Article article = _articleService.Get(id);

            _articleId = id;

            var err = article.Text.Split(' ').Where(c => c.Length > 5).GroupBy(c => c).OrderByDescending(g => g.Count()).Take(5).ToArray();

            List<string> tags = new List<string>();

            foreach (var item in err)
            {
                tags.Add(item.Key);
            }

            ViewBag.Tags = tags;

            return View("AddTagDetails", article);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(_articleService.Get(id));
        }

        [HttpPost]
        public ActionResult Delete(Article article)
        {
            _articleService.Delete(article.Id);

            return RedirectToAction("GetArticles", "Article", new
            {
                area = ""
            });

        }

        [HttpPost]
        public ActionResult AddTag(string[] selectedTags)
        {
            Article article = _articleService.Get(_articleId);

            foreach (var item in selectedTags)
            {
                article.Tags.Add(new Tag { Text = item });
            }

            _articleService.Update(article);

            return RedirectToAction("GetArticles", "Article", new
            {
                area = ""
            });
        }
    }
}