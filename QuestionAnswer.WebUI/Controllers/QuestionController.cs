using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuestionAnswer.Business.Abstract;
using QuestionAnswer.Entities.Concrete;
using QuestionAnswer.WebUI.Models;

namespace QuestionAnswer.WebUI.Controllers
{
    [Authorize(Roles = "Teacher")]
    public class QuestionController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IQuestionService _questionService;
        private readonly IUserService _userService;
        private readonly IUserQuestionService _userQuestionService;

        public QuestionController(IHostingEnvironment hostingEnvironment, ICategoryService categoryService,
            ISubCategoryService subCategoryService, IQuestionService questionService, IUserService userService, IUserQuestionService userQuestionService)
        {
            _hostingEnvironment = hostingEnvironment;
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
            _questionService = questionService;
            _userService = userService;
            _userQuestionService = userQuestionService;
        }

        public IActionResult Add()
        {
            var questionAddViewModel = new QuestionAddViewModel
            {
                GetAllCategories = new SelectList(_categoryService.GetCategoriesName()),
                SubCategories = new SelectList(_subCategoryService.GetSubCategoriesByName())
            };

            return View(questionAddViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(
            [Bind("FirstContent, SecondContent, ThirdContent, FourthContent, TrueContent")]
            Question question, List<IFormFile> file, [Bind("CategoryName")] Category category, [Bind("SubCategoryName")] SubCategory subCategory)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool isEqual = false;
                    foreach (var categoryName in _categoryService.GetCategoriesName())
                    {
                        if (category.CategoryName == categoryName) //if category exists dont add it
                            isEqual = true;
                    }

                    if (!isEqual) //if category not exist add a new one
                    {
                        _categoryService.Add(category);
                        subCategory.CategoryId = category.Id;
                        _subCategoryService.Add(subCategory);
                    }
                    var fileName = Path.Combine(_hostingEnvironment.WebRootPath + "/img/", Path.GetFileName(file[0].FileName));
                    file[0].CopyTo(new FileStream(fileName, FileMode.Create));
                    question.QuestionImage = "/img/" + file[0].FileName;

                    var subCategoryId = _subCategoryService.GetSubCategoryIdByName(subCategory.SubCategoryName);
                    question.SubCategoryId = subCategoryId;
                    _questionService.Add(question);

                    foreach (var user in _userService.GetAll())
                    {
                        if(user.Role == "Student") //add questions to user who has student role
                        {
                            _userQuestionService.Add(new UserQuestion
                            {
                                IsAnswerTrue = false,
                                QuestionId = question.Id,
                                UserId = user.Id,
                            });
                        }
                    }
                    return RedirectToAction("Index", "Home");
                }
                catch { }
            }
            var questionAddViewModel = new QuestionAddViewModel
            {
                GetAllCategories = new SelectList(_categoryService.GetCategoriesName()),
                SubCategories = new SelectList(_subCategoryService.GetSubCategoriesByName())
            };

            ViewData["error"] = "Bir hata oluştu tekrar deneyiniz";
            return View(questionAddViewModel);
        }
    }
}