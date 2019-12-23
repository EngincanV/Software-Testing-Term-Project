using QuestionAnswer.Entities.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace QuestionAnswer.DataAccess.Abstract
{
    public interface IQuestionDal : IEntityRepository<Question>
    {
        int FindIdByQuestionImage(string questionImage);
        int GetSubCategoryIdById(int id);
        List<int> GetQuestionCountBySubCategoryId(int userId);
        List<int> GetCategoryCount();
        Question GetQuestionBySubCategoryId(int userId, int subCategoryId);
    }
}
