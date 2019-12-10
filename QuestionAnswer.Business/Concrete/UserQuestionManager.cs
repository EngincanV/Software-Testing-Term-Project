
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

        public UserQuestion GetByQuestionId(int questionId, int userId)
        {
            return _userQuestionDal.GetByQuestionId(questionId, userId);
        }

        public void Update(UserQuestion userQuestion)
        {
            _userQuestionDal.Update(userQuestion);
        }

        public void Add(UserQuestion entity)
        {
            _userQuestionDal.Add(entity);
        }

        public List<UserQuestion> GetAllByUserId(int userId)
        {
            return _userQuestionDal.GetAllByUserId(userId);
        }
    }
}
