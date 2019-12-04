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
    }
}
