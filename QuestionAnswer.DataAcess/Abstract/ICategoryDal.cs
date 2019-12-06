using System.Collections.Generic;
using QuestionAnswer.Entities.Concrete;

namespace QuestionAnswer.DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
        List<string> GetCategoriesName();
        Category GetCategoryByName(string categoryName);
    }
}
