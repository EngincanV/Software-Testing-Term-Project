using System.Collections.Generic;
using QuestionAnswer.Entities.Concrete;

namespace QuestionAnswer.WebUI.Models
{
    public class ExamViewModel
    {
        public Answer AnswerContent { get; set; }
        public Question Question { get; set; }
    }
}
