using Microsoft.EntityFrameworkCore;
using QuestionAnswer.Entities.Concrete;

namespace QuestionAnswer.DataAccess.Concrete.Entity_Framework
{
    public class QuestionAnswerContext : DbContext
    {
        public QuestionAnswerContext(DbContextOptions<QuestionAnswerContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Stat> Stats { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserQuestion> UserQuestions { get; set; }
    }
}
