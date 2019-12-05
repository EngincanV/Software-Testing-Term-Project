using System.Collections.Generic;
using QuestionAnswer.Entities.Concrete;

namespace QuestionAnswer.Business.Abstract
{
    public interface IUserQuestionService
    {
        List<UserQuestion> GetByUserId(int userId);
        UserQuestion GetByQuestionId(int questionId);
        void Update(UserQuestion userQuestion);
    }
}
