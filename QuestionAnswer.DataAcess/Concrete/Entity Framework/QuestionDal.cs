using QuestionAnswer.DataAccess.Abstract;
using QuestionAnswer.Entities.Concrete;

namespace QuestionAnswer.DataAccess.Concrete.Entity_Framework
{
    public class QuestionDal : EntityRepository<Question, QuestionAnswerContext>, IQuestionDal
    {
    }
}
