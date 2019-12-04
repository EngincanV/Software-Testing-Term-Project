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
    }
}
