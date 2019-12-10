using System.Collections.Generic;
using QuestionAnswer.Entities.Concrete;

namespace QuestionAnswer.Business.Abstract
{
    public interface IUserQuestionService
    {
        List<UserQuestion> GetByUserId(int userId);
        UserQuestion GetByQuestionId(int questionId, int userId);
        void Update(UserQuestion userQuestion);
        void Add(UserQuestion entity);
        List<UserQuestion> GetAllByUserId(int userId);
    }
}
