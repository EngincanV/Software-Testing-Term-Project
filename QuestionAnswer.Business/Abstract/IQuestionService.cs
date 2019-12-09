using QuestionAnswer.Entities.Concrete;
using System.Collections.Generic;

namespace QuestionAnswer.Business.Abstract
{
    public interface IQuestionService
    {
        List<Question> GetAll();
        Question Get(int id);
        void Update(Question entity);
        void Add(Question entity);
        int FindIdByQuestionImage(string questionImage);
    }
}
