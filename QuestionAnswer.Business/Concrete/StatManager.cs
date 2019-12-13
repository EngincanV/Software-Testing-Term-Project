using QuestionAnswer.Business.Abstract;
using QuestionAnswer.DataAccess.Abstract;
using QuestionAnswer.Entities.Concrete;

namespace QuestionAnswer.Business.Concrete
{
    public class StatManager : IStatService
    {
        private readonly IStatDal _statDal;

        public StatManager(IStatDal statDal)
        {
            _statDal = statDal;
        }

        public void Add(Stat stat)
        {
            _statDal.Add(stat);
        }

        public Stat GetByDate(string date, int subCategoryId)
        {
            return _statDal.GetByDate(date, subCategoryId);
        }

        public int SumDailyAnswer(int userId)
        {
            return _statDal.SumDailyAnswer(userId);
        }

        public int SumDailyFalseAnswer(int userId)
        {
            return _statDal.SumDailyFalseAnswer(userId);
        }

        public int SumDailyTrueAnswer(int userId)
        {
            return _statDal.SumDailyTrueAnswer(userId);
        }

        public void Update(Stat stat)
        {
            _statDal.Update(stat);
        }
    }
}
