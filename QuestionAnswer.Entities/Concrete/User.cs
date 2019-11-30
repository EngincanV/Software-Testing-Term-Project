using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using QuestionAnswer.Entities.Abstract;

namespace QuestionAnswer.Entities.Concrete
{
    public class User : IEntity
    {
        public User()
        {
            this.Stats = new List<Stat>();
        }

        public int Id { get; set; }
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; }
        [StringLength(50)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [StringLength(50)]
        public string Role { get; set; }

        public List<Stat> Stats { get; set; }
    }
}
