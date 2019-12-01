using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using QuestionAnswer.Business.Abstract;
using QuestionAnswer.Entities.Concrete;

namespace QuestionAnswer.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _service;

        public AccountController(IUserService service)
        {
            _service = service;
        }

        public IActionResult Login()
        {
            if ((User.FindFirst(claim => claim.Type == ClaimTypes.Role)?.Value == "Teacher") ||
                (User.FindFirst(claim => claim.Type == ClaimTypes.Role)?.Value == "Student") ||
                (User.FindFirst(claim => claim.Type == ClaimTypes.Role)?.Value == "Admin"))
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("Username, Password")] User user)
        {
            if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password))
            {
                ViewBag.emptyFields = "Lütfen kullanıcı adı ve şifrenizi boş bırakmayınız..";
                return View();
            }

            //check the username and password
            //here can be implemented checking logic from the database
            ClaimsIdentity identity = null;

            var isUserExist = _service.UserExist(user.Username, user.Password);

            if (isUserExist != null)
            {
                //create the identity for the user
                identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, isUserExist.Username),
                    new Claim(ClaimTypes.Role, isUserExist.Role),
                });

                var principal = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", "Home");
            }

            ViewBag.emptyFields = "Lütfen giriş bilgilerinizi kontrol ediniz.";
            return View();
        }

        public IActionResult Logout()
        {
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}