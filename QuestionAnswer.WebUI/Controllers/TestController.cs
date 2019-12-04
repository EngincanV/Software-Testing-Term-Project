using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuestionAnswer.Business.Abstract;
using QuestionAnswer.Entities.Concrete;
using QuestionAnswer.WebUI.Models;

namespace QuestionAnswer.WebUI.Controllers
{
    [Authorize(Roles = "Student, Admin")]
    public class TestController : Controller
    {
        private readonly IQuestionService _service;
        private readonly IStatService _statService;
        private readonly IUserService _userService;

        public TestController(IQuestionService service, IStatService statService, IUserService userService)
        {
            _service = service;
            _statService = statService;
            _userService = userService;
        }

        public IActionResult Exam()
        {
            var userId = _userService.FindUserByName(User.Identity.Name).Id;
            var getQuestion = _service.GetQuestion(userId);

            var examViewModel = new ExamViewModel()
            {
                Question = getQuestion,
                AnswerContent = new Answer()
            };

            if (getQuestion == null)
            {
                ViewData["notExistQuestions"] = "Bütün soruları cevapladınız. Öğretmenler tarafından yeni sorular eklenince testlerinize devam edebileceksiniz";
                return View();
            }

            return View(examViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Exam([Bind("Id")] Question question , [Bind("AnswerContent")] Answer answer)
        {
            var getQuestion = _service.Get(question.Id);
            var userId = _userService.FindUserByName(User.Identity.Name).Id;

            if (answer.AnswerContent == getQuestion.TrueContent)
            {
                getQuestion.IsAnswerTrue = true;
                _service.Update(getQuestion);

                ViewData["trueAnswer"] = "Cevap Doğru";

                _statService.Add(new Stat
                {
                    UserId = userId,
                    TrueCount = 1,
                    SubCategoryId = getQuestion.SubCategoryId
                });
            }

            else 
                ViewData["trueAnswer"] = "Cevap Yanlış";

            var examViewModel = new ExamViewModel()
            {
                Question = getQuestion,
                AnswerContent = new Answer()
            };

            return View(examViewModel);
        }
    }
}