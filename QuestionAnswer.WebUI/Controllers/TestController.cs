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

        private void VisitedQuestions(int userId)
        {
            var getAllByUserId = _userQuestionService.GetAllByUserId(userId);
            foreach (var question in getAllByUserId)
            {
                question.IsVisited = false;
                _userQuestionService.Update(question);
            }
        }

        public IActionResult Exam()
        {
            var userId = _userService.FindUserByName(User.Identity.Name).Id;
            var dailyTestQuestionNo = 50;
            var dailyAnswerSum = _statService.SumDailyAnswer(userId);

            VisitedQuestions(userId);

            var examViewModel = new ExamViewModel()
            {
                AnswerContent = new Answer()
            };

            var getUserQuestion = _userQuestionService.GetByUserId(userId);

            foreach (var userQuestion in getUserQuestion)
            {
                var getQuestion = _service.Get(userQuestion.QuestionId);
                if (getQuestion != null)
                {
                    examViewModel.Question = getQuestion;
                    break;
                }
            }

            if (examViewModel.Question == null || dailyTestQuestionNo == dailyAnswerSum)
            {
                ViewData["notExistQuestions"] = "Bütün soruları cevapladınız. Bugünlük yapmanız gereken testi başarı ile gerçekleştirdiniz.";
                return View();
            }

            return View(examViewModel);
        }

        private Stat NewStat(bool isAnswerTrue, int userId, int subCategoryId)
        {
            var addedState = new Stat()
            {
                UserId = userId,
                Date = DateTime.Now.ToShortDateString(),
                SubCategoryId = subCategoryId
            };

            if (isAnswerTrue)
                addedState.TrueCount = 1;

            else addedState.FalseCount = 1;

            return addedState;
        }

        [HttpPost]
        public IActionResult Exam([FromBody] Answer answer)
        {
            var getQuestion = _service.Get(answer.QuestionId);
            var userId = _userService.FindUserByName(User.Identity.Name).Id;

            var getByQuestionId = _userQuestionService.GetByQuestionId(answer.QuestionId, userId);
            var subCategoryId = getQuestion.SubCategoryId;

            var isDateExist = _statService.GetByDate(DateTime.Now.ToShortDateString(), subCategoryId);
            getByQuestionId.IsVisited = true;

            if (answer.AnswerContent == getQuestion.TrueContent)
            {
                getByQuestionId.IsAnswerTrue = true;
                _userQuestionService.Update(getByQuestionId);

                if (isDateExist != null)
                {
                    isDateExist.TrueCount++;
                    _statService.Update(isDateExist);
                }
                else
                    _statService.Add(NewStat(getByQuestionId.IsAnswerTrue, userId, subCategoryId));
            }
            else
            {
                if (isDateExist != null)
                {
                    isDateExist.FalseCount++;
                    _statService.Update(isDateExist);
                }
                else
                    _statService.Add(NewStat(getByQuestionId.IsAnswerTrue, userId, subCategoryId));
            }
            var dailyTestQuestionNo = 50;
            var dailyAnswerSum = _statService.SumDailyAnswer(userId);

            if (dailyAnswerSum == dailyTestQuestionNo)
                return Json("testResult");

            var getUserQuestion = _userQuestionService.GetByUserId(userId);
            var examViewModel = new ExamViewModel();

            foreach (var userQuestion in getUserQuestion)
            {
                var getQuestionByQuestionId = _service.Get(userQuestion.QuestionId);
                if (getQuestionByQuestionId != null)
                {
                    examViewModel.Question = getQuestionByQuestionId;
                    break;
                }
            }

            if (examViewModel.Question != null)
            {
                var newQuestionJson = new Question
                {
                    FirstContent = examViewModel.Question.FirstContent,
                    SecondContent = examViewModel.Question.SecondContent,
                    ThirdContent = examViewModel.Question.ThirdContent,
                    FourthContent = examViewModel.Question.FourthContent,
                    QuestionImage = examViewModel.Question.QuestionImage,
                    Id = examViewModel.Question.Id
                };

                return Json(newQuestionJson);
            }
            else
                return Json("");
        }

        public IActionResult ExamResult()
        {
            var userId = _userService.FindUserByName(User.Identity.Name).Id;

            ViewData["trueAnswerCount"] = _statService.SumDailyTrueAnswer(userId);
            ViewData["falseAnswerCount"] = _statService.SumDailyFalseAnswer(userId);

            return View();
        }
    }
}