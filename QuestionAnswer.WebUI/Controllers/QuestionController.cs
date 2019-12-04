using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuestionAnswer.Entities.Concrete;

namespace QuestionAnswer.WebUI.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class QuestionController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(
            [Bind("QuestionImage, FirstContent, SecondContent, ThirdContent, FourthContent, TrueContent")]
            Question question)
        {
            //receive datas and save them into the database
            return View();
        }
    }
}