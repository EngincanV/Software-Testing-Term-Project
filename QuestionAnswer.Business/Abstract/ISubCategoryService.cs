using QuestionAnswer.Entities.Concrete;
using System.Collections.Generic;

namespace QuestionAnswer.Business.Abstract
{
    public interface ISubCategoryService
    {
        void Add(SubCategory entity);
        List<string> GetSubCategoriesByName();
        int GetSubCategoryIdByName(string subCategoryName);
    }
}
