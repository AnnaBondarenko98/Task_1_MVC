using System.Collections.Generic;
using System.Data.Entity.Core;
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
    }
}
