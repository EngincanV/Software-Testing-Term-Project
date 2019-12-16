using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuestionAnswer.Business.Abstract;
using QuestionAnswer.WebUI.Models;
using System;

namespace QuestionAnswer.WebUI.Controllers
{
    public class StatsController : Controller
    {
        private readonly IStatService _statService;
        private readonly IUserService _userService;
        private readonly ISubCategoryService _subCategoryService;
        public StatsController(IStatService statService, IUserService userService, ISubCategoryService subCategoryService)
        {
            _statService = statService;
            _userService = userService;
            _subCategoryService = subCategoryService;
        }

        public IActionResult Index()
        {
            var userId = _userService.FindUserByName(User.Identity.Name).Id;

            var statViewModel = new StatViewModel();
            statViewModel.GetAllDates = new SelectList(_statService.GetAllDates(userId));

            return View(statViewModel);
        }

        [HttpPost]
        public IActionResult Index([FromBody] StatViewModel statView)
        {
            var userId = _userService.FindUserByName(User.Identity.Name).Id;

            if (!string.IsNullOrWhiteSpace(statView.SelectedDate))
            {
                var trueCount = _statService.SumTrueAnswerByDate(statView.SelectedDate, userId);
                return Json(trueCount);
            }

            else if(!string.IsNullOrWhiteSpace(statView.DateForCategory))
            {
                var successDetail = new SuccessDetailView()
                {
                    SubCategoryNames = _subCategoryService.GetSubCategoriesByName(),
                    SuccessRate = _statService.SuccessRateByCategory(userId, DateTime.Now.ToShortDateString())
                };

                return Json(successDetail);
            }

            return Json("");
        }
    }
}