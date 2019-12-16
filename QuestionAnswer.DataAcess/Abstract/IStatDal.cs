using QuestionAnswer.Entities.Concrete;
using System.Collections.Generic;

namespace QuestionAnswer.DataAccess.Abstract
{
    public interface IStatDal : IEntityRepository<Stat>
    {
        Stat GetByDate(string date, int subCategoryId);
        int SumDailyAnswer(int userId);
        int SumDailyTrueAnswer(int userId);
        int SumDailyFalseAnswer(int userId);
        List<string> GetAllDates(int userId);
        int SumTrueAnswerByDate(string date, int userId);
        List<int> SuccessRateByCategory(int userId, string date);
    }
}
