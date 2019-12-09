using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuestionAnswer.DataAccess.Abstract;
using QuestionAnswer.Entities.Concrete;

namespace QuestionAnswer.DataAccess.Concrete.Entity_Framework
{
    public class QuestionDal : IQuestionDal
    {
        private readonly QuestionAnswerContext _context;
        public QuestionDal(QuestionAnswerContext context)
        {
            _context = context;
        }

        public List<Question> GetAll()
        {
            return _context.Questions.ToList();
        }

        public Question Get(int id)
        {
            return _context.Questions.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Question entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Update(Question entity)
        {
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Question entity)
        {
            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public int FindIdByQuestionImage(string questionImage)
        {
            return _context.Questions.FirstOrDefault(p => p.QuestionImage == questionImage).Id;
        }
    }
}
