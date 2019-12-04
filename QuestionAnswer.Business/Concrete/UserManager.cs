using System.Collections.Generic;
using QuestionAnswer.Business.Abstract;
using QuestionAnswer.DataAccess.Abstract;
using QuestionAnswer.Entities.Concrete;

namespace QuestionAnswer.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<User> GetAll()
        {
            return _userDal.GetAll();
        }

        public User UserExist(string userName, string password)
        {
            return _userDal.UserExist(userName, password);
        }

        public User FindUserByName(string userName)
        {
            return _userDal.FindUserByName(userName);
        }
    }
}
