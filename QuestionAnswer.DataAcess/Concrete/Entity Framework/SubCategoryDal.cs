using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuestionAnswer.DataAccess.Abstract;
using QuestionAnswer.Entities.Concrete;

namespace QuestionAnswer.DataAccess.Concrete.Entity_Framework
{
    public class SubCategoryDal : ISubCategoryDal
    {
        private readonly QuestionAnswerContext _context;

        public SubCategoryDal(QuestionAnswerContext context)
        {
            _context = context;
        }

        public List<SubCategory> GetAll()
        {
            return _context.SubCategories.ToList();
        }

        public SubCategory Get(int id)
        {
            return _context.SubCategories.FirstOrDefault(p => p.Id == id);
        }

        public void Add(SubCategory entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Update(SubCategory entity)
        {
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(SubCategory entity)
        {
            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public List<string> GetSubCategoriesByName()
        {
            return _context.SubCategories
                .Select(p => p.SubCategoryName)
                .ToList();
        }

        public int GetSubCategoryIdByName(string subCategoryName)
        {
            return _context.SubCategories.FirstOrDefault(p => p.SubCategoryName == subCategoryName).Id;
        }
    }
}
