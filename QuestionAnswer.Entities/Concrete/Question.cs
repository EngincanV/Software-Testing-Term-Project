using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QuestionAnswer.Entities.Abstract;

namespace QuestionAnswer.Entities.Concrete
{
    public class Question : IEntity
    {
        public int Id { get; set; }
        public int SubCategoryId { get; set; }
        public int UserId { get; set; }

        [StringLength(150)]
        public string QuestionImage { get; set; }

        [Column(TypeName = "text")]
        public string FirstContent { get; set; }

        [Column(TypeName = "text")]
        public string SecondContent { get; set; }

        [Column(TypeName = "text")]
        public string ThirdContent { get; set; }

        [Column(TypeName = "text")]
        public string FourthContent { get; set; }

        [StringLength(50)]
        public string TrueContent { get; set; }

        public bool IsAnswerTrue { get; set; }

        public SubCategory SubCategory { get; set; }
        public User User { get; set; }
    }
}
