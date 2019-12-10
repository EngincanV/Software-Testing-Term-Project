using QuestionAnswer.Entities.Abstract;

namespace QuestionAnswer.Entities.Concrete
{
    public class UserQuestion : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public bool IsAnswerTrue { get; set; }
        public bool IsVisited { get; set; }

        public User User { get; set; }
        public Question Question { get; set; }
    }
}
