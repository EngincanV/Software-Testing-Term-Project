using Microsoft.AspNetCore.Mvc.Rendering;
using QuestionAnswer.Entities.Concrete;

namespace QuestionAnswer.WebUI.Models
{
    public class QuestionAddViewModel
    {
        public Question Question { get; set; }
        public Category Category { get; set; }
        public SubCategory SubCategory { get; set; }
        public SelectList GetAllCategories { get; set; }
        public SelectList SubCategories { get; set; }
    }
}
