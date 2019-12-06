using System.Collections.Generic;
using QuestionAnswer.Business.Abstract;
using QuestionAnswer.DataAccess.Abstract;
using QuestionAnswer.Entities.Concrete;

namespace QuestionAnswer.Business.Concrete
{
    public class SubCategoryManager : ISubCategoryService
    {
        private readonly ISubCategoryDal _subCategoryDal;

        public SubCategoryManager(ISubCategoryDal subCategoryDal)
        {
            _subCategoryDal = subCategoryDal;
        }

        public void Add(SubCategory entity)
        {
            _subCategoryDal.Add(entity);
        }

        public List<string> GetSubCategoriesByName()
        {
            return _subCategoryDal.GetSubCategoriesByName();
        }

        public int GetSubCategoryIdByName(string subCategoryName)
        {
            return _subCategoryDal.GetSubCategoryIdByName(subCategoryName);
        }
    }
}
