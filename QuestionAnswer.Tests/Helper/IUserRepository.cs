using System.Collections.Generic;

namespace QuestionAnswer.Tests.Helper
{
    public interface IUserRepository
    {
        IList<User> GetAll();
        void Add(User user);
        void Update(User user);
    }
}
