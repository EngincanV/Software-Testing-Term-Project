﻿using System.Collections.Generic;
using QuestionAnswer.Entities.Concrete;

namespace QuestionAnswer.DataAccess.Abstract
{
    public interface IUserQuestionDal : IEntityRepository<UserQuestion>
    {
        List<UserQuestion> GetByUserId(int userId, int takeRecord);
        UserQuestion GetByQuestionId(int questionId, int userId);
        List<UserQuestion> GetAllByUserId(int userId);
    }
}
