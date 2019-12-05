using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuestionAnswer.DataAccess.Abstract;
using QuestionAnswer.Entities.Concrete;

namespace QuestionAnswer.DataAccess.Concrete.Entity_Framework
{
    public class UserQuestionDal : IUserQuestionDal
    {
        private readonly QuestionAnswerContext _context;

        public UserQuestionDal(QuestionAnswerContext context)
        {
            _context = context;
        }

        public List<UserQuestion> GetAll()
        {
            return _context.UserQuestions.ToList();
        }

        public UserQuestion Get(int id)
        {
            return _context.UserQuestions.FirstOrDefault(p => p.Id == id);
        }

        public void Add(UserQuestion entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Update(UserQuestion entity)
        {
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(UserQuestion entity)
        {
            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public List<UserQuestion> GetByUserId(int userId)
        {
            return _context.UserQuestions.Where(p => p.UserId == userId && p.IsAnswerTrue == false).ToList();
        }

        public UserQuestion GetByQuestionId(int questionId)
        {
            return _context.UserQuestions.FirstOrDefault(p => p.QuestionId == questionId);
        }
    }
}
