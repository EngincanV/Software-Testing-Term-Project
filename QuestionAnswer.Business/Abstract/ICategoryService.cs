using System.Collections.Generic;
using QuestionAnswer.Entities.Concrete;

namespace QuestionAnswer.Business.Abstract
{
    public interface ICategoryService
    {
        void Add(Category entity);
        List<string> GetCategoriesName();
        Category GetCategoryByName(string categoryName);
    }
}
