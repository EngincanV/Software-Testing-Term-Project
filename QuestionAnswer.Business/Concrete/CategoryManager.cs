using System.Collections.Generic;
using QuestionAnswer.Business.Abstract;
using QuestionAnswer.DataAccess.Abstract;
using QuestionAnswer.Entities.Concrete;

namespace QuestionAnswer.Business.Concrete
{
    public class CategoryManager:ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Add(Category entity)
        {
            _categoryDal.Add(entity);
        }

        public List<string> GetCategoriesName()
        {
            return _categoryDal.GetCategoriesName();
        }

        public Category GetCategoryByName(string categoryName)
        {
            return _categoryDal.GetCategoryByName(categoryName);
        }
    }
}
