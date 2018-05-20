using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using BlogAsp.BLL.DALInterfaces;
using BlogAsp.BLL.Interfaces;
using BlogAsp.Models.Models;

namespace BlogAsp.BLL.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ArticleService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Article> GetAll()
        {
            return _unitOfWork.ArticleGenericRepository.GetAll();
        }

        public Article Get(int id)
        {
            if (id <= 0)
            {
                throw new ObjectNotFoundException(nameof(Article));
            }

            return _unitOfWork.ArticleGenericRepository.Get(id);
        }

        public void Create(Article article)
        {
            article.Date = DateTime.UtcNow;

            _unitOfWork.ArticleGenericRepository.Create(article);
        }

        public void Update(Article article)
        {
            article.Date = DateTime.UtcNow;

            _unitOfWork.ArticleGenericRepository.Update(article);
        }

        public IEnumerable<Tag> GetTags(int id)
        {
            return _unitOfWork.ArticleGenericRepository.Get(id).Tags;
        }

        public void GetArticlesWithTags(Article article, IEnumerable<string> names)
        {
            var tags = _unitOfWork.TagGenericRepository.Find(tag => names.Contains(tag.Text));

            article.Tags = tags.ToList();
        }

        public IEnumerable<string> GetMostPopularTags(Article article, int count)
        {
            var words = article.Text.Split(' ');

            var mostPopularWords = words.Where(c => c.Length > 5)
            .GroupBy(c => c).OrderByDescending(g => g.Count())
            .Take(count);

            var tags = mostPopularWords.Select(item => item.Key);

            return tags;
        }

        public void Delete(int id)
        {
            if (id <= 0)
            {
                throw new ObjectNotFoundException(nameof(Article));
            }

            _unitOfWork.ArticleGenericRepository.Delete(id);
        }
    }
}
