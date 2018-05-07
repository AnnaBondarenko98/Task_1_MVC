using BlogAsp.Models.Models;

namespace BlogAsp.BLL.Interfaces
{
    public interface IQuestionService
    {
        /// <summary>
        /// Creating 
        /// </summary>
        /// <param name="item">entity</param>
        /// <returns></returns>
        void Create(Question item);
    }
}