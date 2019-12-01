using QuestionAnswer.Entities.Concrete;

namespace QuestionAnswer.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        User UserExist(string userName, string password);
    }
}
