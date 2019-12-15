using Microsoft.AspNetCore.Mvc.Rendering;

namespace QuestionAnswer.WebUI.Models
{
    public class StatViewModel
    {
        public SelectList GetAllDates { get; set; }
        public string SelectedDate { get; set; }
    }
}
