﻿using QuestionAnswer.Entities.Concrete;

namespace QuestionAnswer.DataAccess.Abstract
{
    public interface IQuestionDal : IEntityRepository<Question>
    {
    }
}