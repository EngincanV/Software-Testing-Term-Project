using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using QuestionAnswer.Entities.Abstract;

namespace QuestionAnswer.Entities.Concrete
{
    public class SubCategory : IEntity
    {
        public SubCategory()
        {
            this.Questions = new List<Question>();
            this.Stats = new List<Stat>();
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }

        [StringLength(50)]
        public string SubCategoryName { get; set; }

        public List<Question> Questions { get; set; }
        public Category Category { get; set; }
        public List<Stat> Stats { get; set; }
    }
}
