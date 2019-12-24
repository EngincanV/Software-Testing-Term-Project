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

        //if all questions of specific categories solved 
        //make one of them false and ask it again
        private void SolvedQuestionUpdate(int userId)
        {
            var getQuestionCount = _service.GetQuestionCountBySubCategoryId(userId);
            var getCategoryCount = _service.GetCategoryCount();

            for(int i=0; i < getQuestionCount.Count; i++)
            {
                if (getQuestionCount[i] == getCategoryCount[i])
                {
                    var questionId = _service.GetQuestionBySubCategoryId(userId, i+1).Id;
                    var getQuestion = _userQuestionService.GetByQuestionId(questionId, userId);
                    getQuestion.IsAnswerTrue = false;
                    _userQuestionService.Update(getQuestion);
                }
            }
        }

        public IActionResult Exam()
        {
            var userId = _userService.FindUserByName(User.Identity.Name).Id;
            var dailyTestQuestionNo = 50;
            var dailyAnswerSum = _statService.SumDailyAnswer(userId);

            SolvedQuestionUpdate(userId);
            VisitedQuestions(userId);

            var examViewModel = new ExamViewModel()
            {
                AnswerContent = new Answer()
            };

            var getUserQuestion = _userQuestionService.GetByUserId(userId, dailyTestQuestionNo);

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

        private void StatUpdate(string givenAnswer, string trueContent, UserQuestion userQuestion, Stat dailyStat, int userId, int subCategoryId)
        {
            if (givenAnswer == trueContent)
            {
                userQuestion.IsAnswerTrue = true;
                _userQuestionService.Update(userQuestion);
                if (dailyStat != null)
                {
                    dailyStat.TrueCount++;
                    _statService.Update(dailyStat);
                }
                else
                    _statService.Add(NewStat(userQuestion.IsAnswerTrue, userId, subCategoryId));
            }
            else
            {
                if (dailyStat != null)
                {
                    dailyStat.FalseCount++;
                    _statService.Update(dailyStat);
                }
                else
                    _statService.Add(NewStat(userQuestion.IsAnswerTrue, userId, subCategoryId));
            }
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

            StatUpdate(answer.AnswerContent, getQuestion.TrueContent, getByQuestionId, isDateExist, userId, subCategoryId);

            var dailyTestQuestionNo = 50;
            var dailyAnswerSum = _statService.SumDailyAnswer(userId);

            if (dailyAnswerSum == dailyTestQuestionNo)
                return Json("testResult");

            var getUserQuestion = _userQuestionService.GetByUserId(userId, dailyTestQuestionNo);
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

        public IActionResult ExamResult() //end of the exam display this view
        {
            var dailyQuestionNo = 50;
            var userId = _userService.FindUserByName(User.Identity.Name).Id;
            var sumDailyTrueAnswer = _statService.SumDailyTrueAnswer(userId);
            var sumDailyFalseAnswer = _statService.SumDailyFalseAnswer(userId);

            var emptyAnswers = dailyQuestionNo - sumDailyTrueAnswer - sumDailyFalseAnswer;
            var getUserQuestion = _userQuestionService.GetByUserId(userId, emptyAnswers);

            foreach (var userQuestion in getUserQuestion)
            {
                var subCategoryId = _service.GetSubCategoryIdById(userQuestion.QuestionId);
                var isDateExist = _statService.GetByDate(DateTime.Now.ToShortDateString(), subCategoryId);
                if (isDateExist != null)
                {
                    isDateExist.FalseCount++;
                    _statService.Update(isDateExist);
                }
                else
                    _statService.Add(new Stat() { FalseCount = 1, Date = DateTime.Now.ToShortDateString(), SubCategoryId = subCategoryId, UserId = userId });
            }

            ViewData["trueAnswerCount"] = _statService.SumDailyTrueAnswer(userId);
            ViewData["falseAnswerCount"] = _statService.SumDailyFalseAnswer(userId);
            return View();
        }
    }
}