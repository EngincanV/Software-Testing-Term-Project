using System;
using QuestionAnswer.Entities.Abstract;

namespace QuestionAnswer.Entities.Concrete
{
    public class Stat : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int SubCategoryId { get; set; }
        public int TrueCount { get; set; }
        public int FalseCount { get; set; }
        public string Date { get; set; }

        public User User { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}
