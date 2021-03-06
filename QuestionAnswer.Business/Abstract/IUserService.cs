﻿using QuestionAnswer.Entities.Concrete;
using System.Collections.Generic;

namespace QuestionAnswer.Business.Abstract
{
    public interface IUserService
    {
        List<User> GetAll();
        User UserExist(string userName, string password);
        User FindUserByName(string userName);
    }
}
