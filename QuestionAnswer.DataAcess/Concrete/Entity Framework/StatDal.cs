using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using QuestionAnswer.DataAccess.Abstract;
using QuestionAnswer.Entities.Concrete;

namespace QuestionAnswer.DataAccess.Concrete.Entity_Framework
{
    public class StatDal : IStatDal
    {
        private readonly QuestionAnswerContext _context;

        public StatDal(QuestionAnswerContext context)
        {
            _context = context;
        }

        public List<Stat> GetAll()
        {
            return _context.Stats.ToList();
        }

        public Stat Get(int id)
        {
            return _context.Stats.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Stat entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Update(Stat entity)
        {
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Stat entity)
        {
            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public Stat GetByDate(string date, int subCategoryId)
        {
            return _context.Stats.FirstOrDefault(p => p.Date == date && p.SubCategoryId == subCategoryId);
        }

        public int SumDailyAnswer(int userId)
        {
            var trueCount = _context.Stats.Where(p => p.UserId == userId && p.Date == DateTime.Now.ToShortDateString()).Sum(p => p.TrueCount);
            var falseCount = _context.Stats.Where(p => p.UserId == userId && p.Date == DateTime.Now.ToShortDateString()).Sum(p => p.FalseCount);

            return trueCount + falseCount;
        }

        public int SumDailyTrueAnswer(int userId)
        {
            return _context.Stats.Where(p => p.UserId == userId && p.Date == DateTime.Now.ToShortDateString()).Sum(p => p.TrueCount);
        }

        public int SumDailyFalseAnswer(int userId)
        {
            return _context.Stats.Where(p => p.UserId == userId && p.Date == DateTime.Now.ToShortDateString()).Sum(p => p.FalseCount);
        }

        public List<string> GetAllDates(int userId)
        {
            return _context.Stats.Where(p => p.UserId == userId).Select(p => p.Date).Distinct().ToList();
        }

        public int SumTrueAnswerByDate(string date, int userId)
        {
            return _context.Stats.Where(p => p.Date == date && p.UserId == userId).Sum(p => p.TrueCount);
        }
    }
}
