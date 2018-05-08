using System;
using BlogAsp.BLL.DALInterfaces;
using BlogAsp.BLL.Interfaces;
using BlogAsp.Models.Models;

namespace BlogAsp.BLL.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public QuestionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(Question item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            _unitOfWork.QuestGenericRepository.Create(item);
            _unitOfWork.Commit();
        }
    }
}
