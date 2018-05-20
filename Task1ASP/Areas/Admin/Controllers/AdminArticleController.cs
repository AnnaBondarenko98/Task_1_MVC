using System.Collections.Generic;
using System.Linq;
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
        private readonly ITagService _tagService;

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
            _articleService.Create(_mapper.Map<Article>(articleVm));

            return RedirectToAction("GetArticles", "Article", new { area = "" });
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var tags = _tagService.GetAll();
            var checkTags = _mapper.Map<ICollection<CheckModel>>(tags);

            var article = _articleService.Get(id);
            var editArticle = _mapper.Map<EditArticle>(article);

            foreach (var item in checkTags)
            {
                if (editArticle.Tags.Any(tag => tag.Text == item.Tag?.Text))
                {
                    item.Checked = true;
                }
            }

            editArticle.CheckTags = checkTags;

            return View(editArticle);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditArticle editArticle, string[] names)
        {
            if (!ModelState.IsValid)
            {
                return View(editArticle);
            }

            var article = _articleService.Get(editArticle.Id);

            _mapper.Map(editArticle, article);

            if (names != null)
            {
                article.Tags.Clear();
                _articleService.GetArticlesWithTags(article, names);
            }
            else
            {

                article.Tags = _articleService.GetTags(article.Id).ToList();
            }

            _articleService.Update(article);

            return RedirectToAction("GetArticles", "Article", new { area = "" });
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

            return RedirectToAction("GetArticles", "Article", new { area = "" });
        }

        [HttpGet]
        public ActionResult AddTag(int id)
        {
            var article = _articleService.Get(id);
            var articleAddTag = _mapper.Map<ArticleAddTagVm>(article);

            articleAddTag.PopularTags = _articleService.GetMostPopularTags(article, 5).ToList();

            return View("AddTagDetails", articleAddTag);
        }

        [HttpPost]
        public ActionResult AddTag(ArticleAddTagVm articleAddTag)
        {
            var article = _articleService.Get(articleAddTag.Id);

            foreach (var item in articleAddTag.PopularTags)
            {
                if (article.Tags.All(tag => tag.Text != item))
                {
                    article.Tags.Add(new Tag { Text = item });
                }
            }

            _articleService.Update(article);

            return RedirectToAction("GetArticles", "Article", new { area = "" });
        }
    }
}