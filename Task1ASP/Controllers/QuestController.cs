using System.Web.Mvc;
using BlogAsp.BLL.Interfaces;
using BlogAsp.Models.Models;


namespace Task1ASP.Controllers
{
    public class QuestController : Controller
    {
        private readonly IQuestionService _questionService;

        public QuestController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        public ActionResult Question(Question questionnaire, string[] names, string eye)
        {
            if (Request.HttpMethod == "GET")
            {
                ModelState.Clear();

                return View("Questin", new Question());
            }

            if (!ModelState.IsValid)
            {
                return View("Questin", questionnaire);
            }

            _questionService.Create(questionnaire);

            return View("QuestinPost", questionnaire);
        }
    }
}