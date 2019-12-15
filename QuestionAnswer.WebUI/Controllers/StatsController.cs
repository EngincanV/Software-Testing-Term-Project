using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuestionAnswer.Business.Abstract;
using QuestionAnswer.WebUI.Models;

namespace QuestionAnswer.WebUI.Controllers
{
    public class StatsController : Controller
    {
        private readonly IStatService _statService;
        private readonly IUserService _userService;
        public StatsController(IStatService statService, IUserService userService)
        {
            _statService = statService;
            _userService = userService;
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
            var trueCount = _statService.SumTrueAnswerByDate(statView.SelectedDate, userId);

            return Json(trueCount);
        }
    }
}