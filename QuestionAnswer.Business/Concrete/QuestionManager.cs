using System.Collections.Generic;
using System.Linq;
using QuestionAnswer.Business.Abstract;
using QuestionAnswer.DataAccess.Abstract;
using QuestionAnswer.Entities.Concrete;

namespace QuestionAnswer.Business.Concrete
{
    public class QuestionManager : IQuestionService
    {
        private readonly IQuestionDal _questionDal;

        public QuestionManager(IQuestionDal questionDal)
        {
            _questionDal = questionDal;
        }

        public List<Question> GetAll()
        {
            return _questionDal.GetAll();
        }

        public Question Get(int id)
        {
            return _questionDal.Get(id);
        }

        public void Update(Question entity)
        {
            _questionDal.Update(entity);
        }

        public void Add(Question entity)
        {
            _questionDal.Add(entity);
        }

        public int FindIdByQuestionImage(string questionImage)
        {
            return _questionDal.FindIdByQuestionImage(questionImage);
        }

        public int GetSubCategoryIdById(int id)
        {
            return _questionDal.GetSubCategoryIdById(id);
        }

        public List<int> GetQuestionCountBySubCategoryId(int userId)
        {
            return _questionDal.GetQuestionCountBySubCategoryId(userId);
        }

        public List<int> GetCategoryCount()
        {
            return _questionDal.GetCategoryCount();
        }

        public Question GetQuestionBySubCategoryId(int userId, int subCategoryId)
        {
            return _questionDal.GetQuestionBySubCategoryId(userId, subCategoryId);
        }
    }
}
