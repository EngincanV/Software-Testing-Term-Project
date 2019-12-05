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
        private readonly IUserQuestionService _userQuestionService;

        public TestController(IQuestionService service, IStatService statService, IUserService userService, IUserQuestionService userQuestionService)
        {
            _service = service;
            _statService = statService;
            _userService = userService;
            _userQuestionService = userQuestionService;
        }

        public IActionResult Exam()
        {
            var examViewModel = new ExamViewModel()
            {
                AnswerContent = new Answer()
            };

            var userId = _userService.FindUserByName(User.Identity.Name).Id;
            var getUserQuestion = _userQuestionService.GetByUserId(userId); //isAnswerTrue = false ve userid eşit olanları sıralar

            foreach (var userQuestion in getUserQuestion)
            {
                var getQuestion = _service.Get(userQuestion.QuestionId);
                if (getQuestion != null)
                {
                    examViewModel.Question = getQuestion;
                    break;
                }
            }

            if (examViewModel.Question == null)
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
            var getByQuestionId = _userQuestionService.GetByQuestionId(question.Id);

            var userId = _userService.FindUserByName(User.Identity.Name).Id;

            if (answer.AnswerContent == getQuestion.TrueContent)
            {
                getByQuestionId.IsAnswerTrue = true;
                _userQuestionService.Update(getByQuestionId);

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