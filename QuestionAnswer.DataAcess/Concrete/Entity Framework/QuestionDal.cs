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

        public int GetSubCategoryIdById(int id)
        {
            return _context.Questions.FirstOrDefault(p => p.Id == id).SubCategoryId;
        }

        public List<int> GetQuestionCountBySubCategoryId(int userId)
        {
            var getQuestionCount = (from q in _context.Questions
                                   join uq in _context.UserQuestions on q.Id equals uq.QuestionId
                                   join u in _context.Users on uq.UserId equals u.Id
                                   where uq.IsAnswerTrue == true && u.Id == userId
                                   group q by q.SubCategoryId into getQuestion
                                   select getQuestion.Count()).ToList();
            return getQuestionCount;
        }

        public List<int> GetCategoryCount()
        {
            var getCategoryCount = (from q in _context.Questions
                                    group q by q.SubCategoryId into getQuestion
                                    select getQuestion.Count()).ToList();

            return getCategoryCount;
        }
        public Question GetQuestionBySubCategoryId(int userId, int subCategoryId)
        {
            var getQuestion = (from uq in _context.UserQuestions
                               join q in _context.Questions on uq.QuestionId equals q.Id
                               join u in _context.Users on uq.UserId equals u.Id
                               where q.SubCategoryId == subCategoryId && u.Id == userId
                               select q).FirstOrDefault();
            return getQuestion;
        }
    }
}