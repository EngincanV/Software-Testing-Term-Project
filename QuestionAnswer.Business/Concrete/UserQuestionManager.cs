
using System.Collections.Generic;
using QuestionAnswer.Business.Abstract;
using QuestionAnswer.DataAccess.Abstract;
using QuestionAnswer.Entities.Concrete;

namespace QuestionAnswer.Business.Concrete
{
    public class UserQuestionManager : IUserQuestionService
    {
        private readonly IUserQuestionDal _userQuestionDal;

        public UserQuestionManager(IUserQuestionDal userQuestionDal)
        {
            _userQuestionDal = userQuestionDal;
        }

        public List<UserQuestion> GetByUserId(int userId)
        {
            return _userQuestionDal.GetByUserId(userId);
        }

        public UserQuestion GetByQuestionId(int questionId)
        {
            return _userQuestionDal.GetByQuestionId(questionId);
        }

        public void Update(UserQuestion userQuestion)
        {
            _userQuestionDal.Update(userQuestion);
        }
    }
}
