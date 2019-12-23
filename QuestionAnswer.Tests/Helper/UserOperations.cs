using System;
using System.Collections.Generic;
using System.Text;

namespace QuestionAnswer.Tests.Helper
{
    public class UserOperations
    {
        private readonly User _user;
        public UserOperations()
        {
            _user = new User
            {
                Id = 1,
                Username = "Teacher",
                Password = "Teacher"
            };
        }
        public bool IsUserExist(string username, string password)
        {
            return true
                ? username == _user.Username && password == _user.Password
                : false;
        }

    }
}
