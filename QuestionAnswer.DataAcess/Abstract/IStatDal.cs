using QuestionAnswer.Entities.Concrete;

namespace QuestionAnswer.DataAccess.Abstract
{
    public interface IStatDal : IEntityRepository<Stat>
    {
        Stat GetByDate(string date, int subCategoryId);
    }
}
