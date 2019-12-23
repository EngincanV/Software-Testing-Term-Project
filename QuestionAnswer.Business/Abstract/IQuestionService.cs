using QuestionAnswer.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace QuestionAnswer.Business.Abstract
{
    public interface IQuestionService
    {
        List<Question> GetAll();
        Question Get(int id);
        void Update(Question entity);
        void Add(Question entity);
        int FindIdByQuestionImage(string questionImage);
        int GetSubCategoryIdById(int id);
        List<int> GetQuestionCountBySubCategoryId(int userId);
        List<int> GetCategoryCount();
        Question GetQuestionBySubCategoryId(int userId, int subCategoryId);
    }
}
