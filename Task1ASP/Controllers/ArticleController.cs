﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BlogAsp.BLL.Interfaces;
using Task1ASP.Models.Article;

namespace Task1ASP.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ITagService _tagService;
        private readonly IMapper _mapper;

        public ArticleController(IArticleService articleService, ITagService tagService, IMapper mapper)
        {
            _articleService = articleService;
            _tagService = tagService;
            _mapper = mapper;
        }

        public ActionResult GetArticles()
        {
            var articles = _articleService.GetAll();

            var articlesVm = _mapper.Map<IEnumerable<ArticleVm>>(articles);

            return View(articlesVm);
        }

        [HttpGet]
        public ActionResult Vote()
        {
            if (HttpContext.Request.Cookies["cookie"] == null)
            {
                return PartialView("Vote");
            }

            return PartialView("VoteComplete");
        }

        [HttpPost]
        public ActionResult Vote(string gender)
        {
            var cookie = HttpContext.Request.Cookies["cookie"];

            if (cookie == null)
            {
                HttpContext.Response.Cookies.Add(new HttpCookie("cookie")
                {
                    HttpOnly = false,
                    Value = "value",
                    Expires = DateTime.UtcNow.AddMonths(1)
                });
            }

            return PartialView("VoteComplete");
        }

        public ActionResult Details(int id)
        {
            var article = _articleService.Get(id);

            return View(article);
        }

        public ActionResult TagActive(int id)
        {
            var articles = _tagService.GetArticlesByTag(id);

            var articlesVm = _mapper.Map<IEnumerable<ArticleVm>>(articles);

            return View("GetArticles", articlesVm);
        }

        [HttpPost]
        public JsonResult CheckDate(DateTime date)
        {
            var result = date.Day == DateTime.UtcNow.Date.Day;

            return Json(result);
        }
    }
}