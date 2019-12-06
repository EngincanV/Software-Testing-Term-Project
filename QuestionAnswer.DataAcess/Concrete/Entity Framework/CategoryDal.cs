using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuestionAnswer.DataAccess.Abstract;
using QuestionAnswer.Entities.Concrete;

namespace QuestionAnswer.DataAccess.Concrete.Entity_Framework
{
    public class CategoryDal : ICategoryDal
    {
        private readonly QuestionAnswerContext _context;

        public CategoryDal(QuestionAnswerContext context)
        {
            _context = context;
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category Get(int id)
        {
            return _context.Categories.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Category entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Update(Category entity)
        {
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Category entity)
        {
            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public List<string> GetCategoriesName()
        {
            return _context.Categories.Select(p => p.CategoryName).ToList();
        }

        public Category GetCategoryByName(string categoryName)
        {
            var getCategoryByName = _context.Categories.FirstOrDefault(p => p.CategoryName == categoryName);
            return getCategoryByName;
        }
    }
}
