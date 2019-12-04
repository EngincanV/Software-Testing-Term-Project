using QuestionAnswer.Entities.Concrete;
using System.Collections.Generic;

namespace QuestionAnswer.Business.Abstract
{
    public interface IQuestionService
    {
        List<Question> GetAll();
        Question GetQuestion(int userId);
        Question Get(int id);
        void Update(Question entity);
    }
}
