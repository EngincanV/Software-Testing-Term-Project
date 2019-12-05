using System.Collections.Generic;
using QuestionAnswer.Entities.Concrete;

namespace QuestionAnswer.DataAccess.Abstract
{
    public interface IUserQuestionDal : IEntityRepository<UserQuestion>
    {
        List<UserQuestion> GetByUserId(int userId);
        UserQuestion GetByQuestionId(int questionId, int userId);
    }
}
