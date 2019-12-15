using QuestionAnswer.Entities.Concrete;
using System.Collections.Generic;

namespace QuestionAnswer.Business.Abstract
{
    public interface IStatService
    {
        List<string> GetAllDates(int userId);
        void Add(Stat stat);
        Stat GetByDate(string date, int subCategoryId);
        void Update(Stat stat);
        int SumDailyAnswer(int userId);
        int SumDailyTrueAnswer(int userId);
        int SumDailyFalseAnswer(int userId);
        int SumTrueAnswerByDate(string date, int userId);
    }
}
