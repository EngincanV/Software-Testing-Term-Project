using QuestionAnswer.Entities.Concrete;

namespace QuestionAnswer.DataAccess.Abstract
{
    public interface IStatDal : IEntityRepository<Stat>
    {
        Stat GetByDate(string date, int subCategoryId);
        int SumDailyAnswer(int userId);
        int SumDailyTrueAnswer(int userId);
        int SumDailyFalseAnswer(int userId);
    }
}
