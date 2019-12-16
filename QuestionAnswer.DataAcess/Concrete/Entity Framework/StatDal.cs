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

        private List<int> TrueAnswerCount(int userId, string date)
        {
            var query = from sub in _context.SubCategories
                        join stat in _context.Stats on sub.Id equals stat.SubCategoryId
                        where stat.UserId == userId && stat.Date == date
                        group stat by stat.SubCategoryId into g
                        select g.Sum(stat => stat.TrueCount) * 100;
            var listed = query.ToList();
            return listed;
        } 

        private List<int> TotalAnswerCount(int userId, string date)
        {
            var query = from sub in _context.SubCategories
                        join stat in _context.Stats on sub.Id equals stat.SubCategoryId
                        where stat.UserId == userId && stat.Date == date
                        group stat by stat.SubCategoryId into g
                        select g.Sum(stat => stat.TrueCount + stat.FalseCount);
            var listed = query.ToList();
            return listed;
        }

        public List<int> SuccessRateByCategory(int userId, string date)
        {
            var trueAnswerCount = TrueAnswerCount(userId, date);
            var totalAnswerCount = TotalAnswerCount(userId, date);
            var successRateList = new List<int>();

            for(int i=0; i < totalAnswerCount.Count; i++)
            {
                successRateList.Add(trueAnswerCount[i] / totalAnswerCount[i]);
            }

            return successRateList;
        }
    }
}
