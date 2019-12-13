using QuestionAnswer.Entities.Concrete;

namespace QuestionAnswer.Business.Abstract
{
    public interface IStatService
    {
        void Add(Stat stat);
        Stat GetByDate(string date, int subCategoryId);
        void Update(Stat stat);
        int SumDailyAnswer(int userId);
        int SumDailyTrueAnswer(int userId);
        int SumDailyFalseAnswer(int userId);
    }
}
