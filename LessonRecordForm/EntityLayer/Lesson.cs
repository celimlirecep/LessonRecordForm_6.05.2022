using System.Collections.Generic;

namespace EntityLayer
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        public string LessonBos { get; set; }
        public int LessonCredit { get; set; }
        public char LessonTerm { get; set; }
        public List<StudentLesson> StudentLessons { get; set; }


    }
}
