using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using QuestionAnswer.Entities.Abstract;

namespace QuestionAnswer.Entities.Concrete
{
    public class Category : IEntity
    {
        public Category()
        {
            this.SubCategories = new List<SubCategory>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string CategoryName { get; set; }

        public List<SubCategory> SubCategories { get; set; }
    }
}
