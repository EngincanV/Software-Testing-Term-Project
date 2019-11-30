using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QuestionAnswer.Business.Abstract;
using QuestionAnswer.WebUI.Models;

namespace QuestionAnswer.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _service;

        public HomeController(IUserService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var userList = _service.GetAll();
            ViewBag.user = userList;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
