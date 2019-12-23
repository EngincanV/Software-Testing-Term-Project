using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace QuestionAnswer.WebUI.Models
{
    public class StatViewModel
    {
        public SelectList GetAllDates { get; set; }
        public string SelectedDate { get; set; }
        public string DateForCategory { get; set; }
        public List<string> GetLastThreeDay { get; set; }
        public List<int> GetLastThreeDayPoint { get; set; }
        public string IsTrue { get; set; }
    }
}
