using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer
{
    [Table("tbLesson")]
    public class Lesson
    {
        [Key]
        public int LessonId { get; set; }
        [StringLength(20)]
        public string LessonName { get; set; }
        [Column("Lesson Teacher")]
        public string LessonBos { get; set; }
        public int LessonCredit { get; set; }
        public char LessonTerm { get; set; }
        public List<StudentLesson> StudentLessons { get; set; }
        public string LessonImage { get; set; }

        [NotMapped]
        public string LessonImageFullName { get; set; }



    }
}
