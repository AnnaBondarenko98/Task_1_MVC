using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using BlogAsp.BLL.DALInterfaces;
using BlogAsp.BLL.Interfaces;
using BlogAsp.Models.Models;

namespace BlogAsp.BLL.Services
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TagService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Article> GetArticlesByTag(int id)
        {
            var tag = _unitOfWork.TagGenericRepository.Get(id);

            if (tag == null)
            {
                throw new ObjectNotFoundException(nameof(Tag));
            }

            return tag.Articles;
        }

        public IEnumerable<Tag> GetAll()
        {
            return _unitOfWork.TagGenericRepository.GetAll();
        }

        public IEnumerable<Tag> Find(Func<Tag, bool> predicate)
        {
            var tags = _unitOfWork.TagGenericRepository.Find(predicate);

            return tags;
        }
    }
}
