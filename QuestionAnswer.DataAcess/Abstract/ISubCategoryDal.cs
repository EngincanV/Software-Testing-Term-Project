using System.Collections.Generic;
using QuestionAnswer.Entities.Concrete;

namespace QuestionAnswer.DataAccess.Abstract
{
    public interface ISubCategoryDal : IEntityRepository<SubCategory>
    {
        List<string> GetSubCategoriesByName();
        int GetSubCategoryIdByName(string subCategoryName);
    }
}
