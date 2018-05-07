using System;
using System.Collections.Generic;
using BlogAsp.BLL.Interfaces;
using BlogAsp.DAL.Interfaces;
using BlogAsp.Models.Models;

namespace BlogAsp.BLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(Comment item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            item.Date = DateTime.UtcNow;

            _unitOfWork.CommentGenericRepository.Create(item);
            _unitOfWork.Commit();
        }

        public IEnumerable<Comment> GetAll()
        {
            return _unitOfWork.CommentGenericRepository.GetAll();
        }
    }
}
